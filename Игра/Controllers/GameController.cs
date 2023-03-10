using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tanks.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult ListGame()
        {
            var query = new Entity.SearchIn.SearchingGame();
            return View(BL.GameBL.Get(query));
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangeSkin()
        {
            
            return View();
        }

        /*public IActionResult CreateGame()
        {
            
            Entity.Game game = new Entity.Game()
            {
                HostId = BL.PlayerBL.Get(User.Identity.Name).Id,
                Status = true
            };
            
            
            game.Id = BL.GameBL.AddGame(game);
            game.HostId = BL.PlayerBL.Get(User.Identity.Name).Id;
            return RedirectToAction("Play", new { gameId = game.Id, userId = game.HostId });
            
            
        }*/


        ConcurrentDictionary<int, IScheduler> gameFlows = new ConcurrentDictionary<int, IScheduler>();

        StdSchedulerFactory factory = new StdSchedulerFactory();

        //[Authorize]
         public async Task<IActionResult> CreateGame()
         {

             var game = new Entity.Game();

            game.HostId = BL.PlayerBL.Get(User.Identity.Name).Id;
            game.Status = true;

            game.Id = BL.GameBL.AddGame(game);


            var hostSession = new Entity.Session();
            hostSession.UserId = game.HostId;
            hostSession.Status = game.Status;
            hostSession.GameId = game.Id;
            BL.SessionBL.AddOrUpdate(hostSession);

            BL.GameLogic.Initialization(game);


             ITrigger trigger = TriggerBuilder.Create()      // создаем триггер
             .WithIdentity(game.Id.ToString(), "group1")     // идентифицируем триггер с именем и группой
             .StartNow()                                     // запуск сразу после начала выполнения
             .WithSimpleSchedule(x => x                      // настраиваем выполнение действия
                 .WithInterval(new TimeSpan(0, 0, 0, 0, 20)) // каждые 20 мс
                 .RepeatForever())                           // бесконечное повторение
             .Build();

             IJobDetail job = JobBuilder.Create<BL.GamePlay>()
                 .UsingJobData("gameId", game.Id)
                 .Build();



             gameFlows.TryAdd(game.Id, await factory.GetScheduler());
             //IScheduler play = await factory.GetScheduler();



             //await play.Start();
             await gameFlows[game.Id].Start();

             //await play.ScheduleJob(job, trigger);
             await gameFlows[game.Id].ScheduleJob(job, trigger);


             BL.GameLogic.JoinUser(game.Id, game.HostId);

             return RedirectToAction("Play", "Game", new { gameId = game.Id, userId = game.HostId });
         }

        
        public IActionResult Join(int gameId)
        {
            var session = new Entity.Session();
            session.UserId = BL.PlayerBL.Get(User.Identity.Name).Id;
            session.GameId = gameId;

            BL.GameLogic.JoinUser(session.GameId ?? 0, session.UserId);

            BL.SessionBL.AddOrUpdate(session);

            return RedirectToAction("Play", "Game", new { gameId = session.GameId, userId = session.UserId });
        }
        
        public IActionResult Play(int gameId, int userId)
        {
            return View();
        }



        public IActionResult PressButton(int buttonCode, bool isDown, int gameId, int userId)
        {
            if (isDown)
            {
                if (!BL.GameLogic.allButtons.ContainsKey(gameId)) BL.GameLogic.allButtons.TryAdd(gameId, new ConcurrentDictionary<int, ConcurrentDictionary<int, bool>>());
                if (!BL.GameLogic.allButtons[gameId].ContainsKey(userId)) BL.GameLogic.allButtons[gameId].TryAdd(userId, new ConcurrentDictionary<int, bool>());
                if (!BL.GameLogic.allButtons[gameId][userId].ContainsKey(buttonCode))
                {
                    BL.GameLogic.allButtons[gameId][userId].TryAdd(buttonCode, true);
                }
            }
            else
            {
                if (BL.GameLogic.allButtons.ContainsKey(gameId) && BL.GameLogic.allButtons[gameId].ContainsKey(userId))
                {
                    if (BL.GameLogic.allButtons[gameId][userId].ContainsKey(buttonCode))
                    {
                        bool success;
                        BL.GameLogic.allButtons[gameId][userId].Remove(buttonCode, out success);
                    }
                }

            }

            return Ok(Json(true));
        }

        public IActionResult Fire(bool isFire, int gameId, int userId, double left, double bottom)
         {
             if (isFire)
             {
                 if (!BL.GameLogic.allFire.ContainsKey(gameId)) BL.GameLogic.allFire.TryAdd(gameId, new ConcurrentDictionary<int, (bool, double, double)>());
                 if (!BL.GameLogic.allFire[gameId].ContainsKey(userId)) BL.GameLogic.allFire[gameId].TryAdd(userId, (false, 0, 0));
                 if (BL.GameLogic.allFire[gameId][userId].Item1 == false)
                 {
                     BL.GameLogic.allFire[gameId][userId] = (true, left, bottom);
                 }
             }
             else
             {
                 if (BL.GameLogic.allFire.ContainsKey(gameId) && BL.GameLogic.allFire[gameId].ContainsKey(userId))
                 {
                     if (BL.GameLogic.allFire[gameId][userId].Item1 == true)
                     {
                         BL.GameLogic.allFire[gameId][userId] = (false, 0, 0);
                     }
                 }
             }
             return Ok(Json(true));
         }


        public IActionResult GetElements(int gameId, int userId, int WinWidht, int WinHeight)
        {

            if (BL.GameLogic.allGames.ContainsKey(gameId))
            {
                var hero = (Entity.Objects.HeroObject)BL.GameLogic.allGames[gameId].FirstOrDefault(item => item.Value.Type == "hero" && ((Entity.Objects.HeroObject)item.Value).UserId == userId).Value;
                if (hero == null)
                {
                    hero = new Entity.Objects.HeroObject();
                }
                

                Entity.Objects.BaseObject[] temp = BL.GameLogic.allGames[gameId].Values.Where(item => Math.Sqrt(Math.Pow(hero.Left - item.Left, 2) + Math.Pow(hero.Bottom - item.Bottom, 2)) < 1500)
                    .Select(item2 => (Entity.Objects.BaseObject)item2.Clone()).ToArray();

                foreach (var i in temp)
                {
                    i.Left -= (hero.Left - (WinWidht / 2));
                    i.Bottom -= (hero.Bottom - (WinHeight / 2));
                }
                var json = JsonSerializer.Serialize((object[])temp);


                    return Ok(json);
                    
            }
            else return Ok();
        }
    }
}
