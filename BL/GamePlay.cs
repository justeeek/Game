using System;
using System.Collections.Generic;
using System.Text;
using Quartz;
using System.Net;
using System.Threading.Tasks;

namespace BL
{
    public class GamePlay : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;
            JobDataMap dataMap = context.JobDetail.JobDataMap;

            int gameId = dataMap.GetInt("gameId");
           

            //For every players
            foreach (var userId in BL.GameLogic.usersInGame[gameId].Keys)
            {

                //Check MOVE
                
                foreach (var i in BL.GameLogic.allGames[gameId].Values)
                {
                    if (i.Type == "hero")
                    {
                        var hero = (Entity.Objects.HeroObject)i;
                        
                        if (hero.UserId == userId)
                        {
                           
                            //left
                            if (GameLogic.allButtons[gameId][userId].ContainsKey(37))
                            {
                                hero.XPos = -10;
                                hero.XDelta = -2;
                                hero.Angle = 180;
                                hero.Transform = "rotate(" + hero.Angle + "deg)";
                               
                            }
                            //right
                            if (GameLogic.allButtons[gameId][userId].ContainsKey(39))
                            {
                                hero.XPos = 10;
                                hero.XDelta = 2;
                                hero.Angle = 0;
                                hero.Transform = "rotate(" + hero.Angle + "deg)";
                               
                            }
                            //up
                            if (GameLogic.allButtons[gameId][userId].ContainsKey(38))
                            {
                                hero.YPos = 10;
                                hero.YDelta = 2;
                                hero.Angle = 270;
                                hero.Transform = "rotate(" + hero.Angle + "deg)";
                            }
                            //down
                            if (GameLogic.allButtons[gameId][userId].ContainsKey(40))
                            {
                                hero.YPos = -10;
                                hero.YDelta = -2;
                                hero.Angle = 90;
                                hero.Transform = "rotate(" + hero.Angle + "deg)";
                            }

                            // attack
                            if (GameLogic.allButtons[gameId][userId].ContainsKey(49))
                            {
                                var PistolBullet = new Entity.Objects.PistolBullet();

                                if (PistolBullet.Cd <= 0)
                                {
                                    PistolBullet.Cd = 25;

                                    if (hero.Angle == 0)
                                    {
                                        PistolBullet.Left = hero.Left + 5 + hero.Width;
                                        PistolBullet.Bottom = hero.Bottom - 2 + hero.Height / 2;
                                        PistolBullet.XPos = 700;

                                        PistolBullet.XDelta = 10;

                                    }
                                    else if (hero.Angle == 180)
                                    {
                                        PistolBullet.Left = hero.Left - 20;
                                        PistolBullet.Bottom = hero.Bottom + hero.Height / 2;
                                        PistolBullet.XPos = -700;

                                        PistolBullet.XDelta = -10;
                                        PistolBullet.Transform = "rotate(180deg)";
                                    }
                                    else if (hero.Angle == 90)
                                    {
                                        PistolBullet.Left = hero.Left + (hero.Width / 2);
                                        PistolBullet.Bottom = hero.Bottom - 25;
                                        PistolBullet.YPos = -700;

                                        PistolBullet.YDelta = -10;
                                        PistolBullet.Transform = "rotate(90deg)";
                                    }
                                    else if (hero.Angle == 270)
                                    {
                                        PistolBullet.Left = hero.Left + (hero.Width / 2);
                                        PistolBullet.Bottom = hero.Bottom + hero.Height + 10;
                                        PistolBullet.YPos = 700;

                                        PistolBullet.YDelta = 10;
                                        PistolBullet.Transform = "rotate(270deg)";
                                    }
                                    PistolBullet.Curent++;
                                    if (GameLogic.allButtons[gameId][userId].ContainsKey(32))
                                    {
                                    
                                       
                                        GameLogic.allGames[gameId].TryAdd(PistolBullet.Type, PistolBullet);

                                    }
                                    
                                }
                                else
                                {
                                    PistolBullet.Cd--;
                                }
                            }
                            if (GameLogic.allButtons[gameId][userId].ContainsKey(50))
                            {
                                var RifleBullet = new Entity.Objects.RifleBullet();

                                if (RifleBullet.Cd <= 0)
                                {

                                    RifleBullet.Cd = 100;

                                    if (hero.Angle == 0)
                                    {
                                        RifleBullet.Left = hero.Left + 5 + hero.Width;
                                        RifleBullet.Bottom = hero.Bottom - 2 + hero.Height / 2;

                                        RifleBullet.XPos = 1400;
                                        RifleBullet.XDelta = 10;

                                    }
                                    else if (hero.Angle == 180)
                                    {
                                        RifleBullet.Left = hero.Left - 20;
                                        RifleBullet.Bottom = hero.Bottom + hero.Height / 2;

                                        RifleBullet.XPos = -1400;
                                        RifleBullet.XDelta = -10;
                                        RifleBullet.Transform = "rotate(180deg)";
                                    }
                                    else if (hero.Angle == 90)
                                    {
                                        RifleBullet.Left = hero.Left + (hero.Width / 2);
                                        RifleBullet.Bottom = hero.Bottom - 25;

                                        RifleBullet.YPos = -1400;
                                        RifleBullet.YDelta = -10;
                                        RifleBullet.Transform = "rotate(90deg)";
                                    }
                                    else if (hero.Angle == 270)
                                    {
                                        RifleBullet.Left = hero.Left + (hero.Width / 2);
                                        RifleBullet.Bottom = hero.Bottom + hero.Height + 10;

                                        RifleBullet.YPos = 1400;
                                        RifleBullet.YDelta = 10;
                                        RifleBullet.Transform = "rotate(270deg)";
                                    }

                                    RifleBullet.Curent++;
                                    if (GameLogic.allButtons[gameId][userId].ContainsKey(32))
                                    {
                                        GameLogic.allGames[gameId].TryAdd(RifleBullet.Type, RifleBullet); 
                                    }
                                    
                                }
                                else
                                {
                                    RifleBullet.Cd--;
                                }
                            }
                               /* if (GameLogic.allButtons[gameId][userId].ContainsKey(32))
                                {
                                var PistolBullet = new Entity.Objects.PistolBullet();
                                var AkBullet = new Entity.Objects.AkBullet();
                                var RifleBullet = new Entity.Objects.RifleBullet();
                                var MinigunBullet = new Entity.Objects.MinigunBullet();
                                if (PistolBullet.Cd <= 0 || AkBullet.Cd <= 0 || RifleBullet.Cd <= 0 || MinigunBullet.Cd <= 0)
                                {
                                    PistolBullet.Cd = 25;
                                    AkBullet.Cd = 20;
                                    RifleBullet.Cd = 100;
                                    MinigunBullet.Cd = 5;
                                    if (hero.Angle == 0)
                                    {
                                        PistolBullet.Left = AkBullet.Left = RifleBullet.Left = MinigunBullet.Left = hero.Left + 5 + hero.Width;
                                        PistolBullet.Bottom = AkBullet.Bottom = RifleBullet.Bottom = MinigunBullet.Bottom = hero.Bottom - 2 + hero.Height / 2;
                                        PistolBullet.XPos = AkBullet.XPos = MinigunBullet.XPos = 700;
                                        RifleBullet.XPos = 1400;
                                        PistolBullet.XDelta = AkBullet.XDelta = RifleBullet.XDelta = MinigunBullet.XDelta = 10;
                                        
                                    }
                                    else if (hero.Angle == 180)
                                    {
                                        PistolBullet.Left = AkBullet.Left = RifleBullet.Left = MinigunBullet.Left = hero.Left - 20;
                                        PistolBullet.Bottom = AkBullet.Bottom = RifleBullet.Bottom = MinigunBullet.Bottom = hero.Bottom + hero.Height / 2;
                                        PistolBullet.XPos = AkBullet.XPos = MinigunBullet.XPos = -700;
                                        RifleBullet.XPos = -1400;
                                        PistolBullet.XDelta = AkBullet.XDelta = RifleBullet.XDelta = MinigunBullet.XDelta = -10;
                                        PistolBullet.Transform = AkBullet.Transform = RifleBullet.Transform = "rotate(180deg)";
                                    }
                                    else if (hero.Angle == 90)
                                    {
                                        PistolBullet.Left = AkBullet.Left = RifleBullet.Left = MinigunBullet.Left = hero.Left + (hero.Width / 2);
                                        PistolBullet.Bottom = AkBullet.Bottom = RifleBullet.Bottom = MinigunBullet.Bottom = hero.Bottom - 25;
                                        PistolBullet.YPos = AkBullet.YPos = MinigunBullet.YPos = -700;
                                        RifleBullet.YPos = -1400;
                                        PistolBullet.YDelta = AkBullet.YDelta = RifleBullet.YDelta = MinigunBullet.YDelta = -10;
                                        PistolBullet.Transform = AkBullet.Transform = RifleBullet.Transform = "rotate(90deg)";
                                    }
                                    else if (hero.Angle == 270)
                                    {
                                        PistolBullet.Left = AkBullet.Left = RifleBullet.Left = MinigunBullet.Left = hero.Left + (hero.Width / 2);
                                        PistolBullet.Bottom = AkBullet.Bottom = RifleBullet.Bottom = MinigunBullet.Bottom = hero.Bottom + hero.Height + 10;
                                        PistolBullet.YPos = AkBullet.YPos = MinigunBullet.YPos = 700;
                                        RifleBullet.YPos = 1400;
                                        PistolBullet.YDelta = AkBullet.YDelta = RifleBullet.YDelta = MinigunBullet.YDelta = 10;
                                        PistolBullet.Transform = AkBullet.Transform = RifleBullet.Transform = "rotate(270deg)";
                                    }
                                    PistolBullet.Curent++;
                                    AkBullet.Curent++;
                                    RifleBullet.Curent++;
                                    MinigunBullet.Curent++; ;
                                    GameLogic.allGames[gameId].TryAdd(PistolBullet.Type, PistolBullet);
                                    GameLogic.allGames[gameId].TryAdd(AkBullet.Type, AkBullet);
                                    GameLogic.allGames[gameId].TryAdd(RifleBullet.Type, RifleBullet);
                                    GameLogic.allGames[gameId].TryAdd(MinigunBullet.Type, MinigunBullet);

                                }
                                else
                                {
                                    PistolBullet.Cd--;
                                    AkBullet.Cd--;
                                    RifleBullet.Cd--;
                                    MinigunBullet.Cd--;
                                }
                            }*/
                            // attack suriken
                            if (GameLogic.allButtons[gameId][userId].ContainsKey(81))
                            {
                                var suriken = new Entity.Objects.SurikenBullet();
                                if (suriken.Cd <= 0)
                                {
                                    suriken.Cd = 200;
                                    if (hero.Angle == 0)
                                    {
                                        suriken.Left = hero.Left + 5 + hero.Width;
                                        suriken.Bottom = hero.Bottom - 2 + hero.Height / 2;
                                        suriken.XPos = 300;
                                        suriken.XDelta = 10;

                                    }
                                    else if (hero.Angle == 180)
                                    {
                                        suriken.Left = hero.Left - 20;
                                        suriken.Bottom = hero.Bottom + hero.Height / 2;
                                        suriken.XPos = -300;
                                        suriken.XDelta = -10;
                                        
                                    }
                                    else if (hero.Angle == 90)
                                    {
                                        suriken.Left = hero.Left + (hero.Width / 2);
                                        suriken.Bottom = hero.Bottom - 25;
                                        suriken.YPos = -300;
                                        suriken.YDelta = -10;
                                        
                                    }
                                    else if (hero.Angle == 270)
                                    {
                                        suriken.Left = hero.Left + (hero.Width / 2);
                                        suriken.Bottom = hero.Bottom + hero.Height + 10;
                                        suriken.YPos = 300;
                                        suriken.YDelta = 10;
                                        
                                    }
                                    suriken.Curent++;
                                    GameLogic.allGames[gameId].TryAdd(suriken.Type, suriken);

                                }
                                else
                                {
                                    suriken.Cd--;
                                }
                            }

                            // Inventory
                            /*if (GameLogic.allButtons[gameId][userId].ContainsKey(69))
                            {
                                var table = new Entity.Objects.TableObjects();
                                for (var j = 0; j < 20; j++)
                                {                              
                                    table.Left = 250 + j * 20;
                                    for (var n = 0; n < j; n++)
                                    {
                                        table.Bottom = 200 + j * 20;
                                        
                                    }
                                    GameLogic.allGames[gameId].TryAdd(table.Id, table);
                                }
                                if (GameLogic.allButtons[gameId][userId].ContainsKey(27))
                                {
                                    Entity.Objects.BaseObject myTemp;
                                    GameLogic.allGames[gameId].Remove(table.Id, out myTemp);
                                }


                            }*/

                        }
                    }
                }

                


                //MoveX
                foreach (var i in GameLogic.allGames[gameId].Values)
                {

                    if (i.Type == "hero")
                    {

                        var temp = (Entity.Objects.HeroObject)i;
                        if (temp.IsMoveble == true)
                        {
                            if (temp.XPos != 0)
                            {
                                temp.XPos = temp.XPos - temp.XDelta;
                                var ax = temp.Left + temp.XDelta;
                                var ax1 = temp.Left + temp.XDelta + temp.Width;
                                var ay = temp.Bottom + temp.YDelta;
                                var ay1 = temp.Bottom + temp.YDelta + temp.Height;
                                bool canMove = true;
                                foreach (var k in GameLogic.allGames[gameId].Values)
                                {

                                    if (temp.Type == k.Type) continue;
                                    if (k.Type == "hero") continue;
                                    if (k.Type == "Pol") continue;
                                    if (k.Type == "deadhero") continue;
                                    
                                    
                                    if (GameLogic.Intersects(k, ax, ax1, ay, ay1) == true)
                                    {
                                        if (temp.Team == "red")
                                        {
 
                                            if (k.Type == "blueflag")
                                            {

                                                k.Left = temp.Left;
                                                k.Bottom = temp.Bottom - 10;
                                                continue;
                                            }
                                            if (k.Type == "redflag")
                                            {
                                                continue;
                                            }
                                        }
                                        else if (temp.Team == "blue")
                                        {
       
                                            if (k.Type == "redflag")
                                            {

                                                k.Left = temp.Left;
                                                k.Bottom = temp.Bottom;
                                                continue;
                                            }
                                            if (k.Type == "blueflag")
                                            {
                                                continue;
                                            }
                                        }
                                        if (k.Type == "guns")
                                        {
                                            if (temp.UserId == userId)
                                            {
                                                var obj = (Entity.Objects.Item)k;
                                                temp.Items.Add(obj);
                                                Entity.Objects.BaseObject myTemp;
                                                GameLogic.allGames[gameId].Remove(obj.Id, out myTemp);
                                                
                                            }
                                        }
                                        if (k.Type == "armor")
                                        {
                                            if (temp.UserId == userId)
                                            {
                                                var obj = (Entity.Objects.Item)k;
                                                temp.Items.Add(obj);
                                                
                                                Entity.Objects.BaseObject myTemp;
                                                GameLogic.allGames[gameId].Remove(k.Id, out myTemp);
                                            }
                                        }
                                        
                                        
                                            canMove = false;
                                            break;
                                    }
                                   
                                }
                                if (canMove == true)
                                {
                                    temp.Left += temp.XDelta;
                                    
                                }
                            }
                        }
                    }
                    if (i.Type == "blueflag")
                    {
                        var blue = (Entity.Objects.BlueFlag)i;
                        var ax = blue.Left;
                        var ax1 = blue.Left + blue.Width;
                        var ay = blue.Bottom;
                        var ay1 = blue.Bottom + blue.Height;
                        foreach (var k in GameLogic.allGames[gameId].Values)
                        {

                            if (blue.Type == k.Type) continue;
                            if (k.Type == "hero") continue;
                            if (k.Type == "Pol") continue;
                            if (k.Type == "deadhero") continue;
                            //if (k.Type == "redflag") continue;
                            if (GameLogic.Intersects(k, ax, ax1, ay, ay1) == true)
                            {
                                if (k.Type == "redflag")
                                {
                                    Entity.Objects.BaseObject myTemp;
                                    GameLogic.allGames[gameId].Remove(blue.Id, out myTemp);
                                    var newblue = new Entity.Objects.BlueFlag();
                                    newblue.Left = 350;
                                    newblue.Bottom = -200;
                                    GameLogic.allGames[gameId].TryAdd(newblue.Id, newblue);
                                    //var newblue = new Entity.Objects.BlueFlag();
                                    //GameLogic.allGames[gameId].TryAdd;
                                }
                                
                            }
                        }
                    }
                    if (i.Type == "redflag")
                    {
                        var red = (Entity.Objects.RedFlag)i;
                        var ax = red.Left;
                        var ax1 = red.Left + red.Width;
                        var ay = red.Bottom;
                        var ay1 = red.Bottom + red.Height;
                        foreach (var k in GameLogic.allGames[gameId].Values)
                        {

                            if (red.Type == k.Type) continue;
                            if (k.Type == "hero") continue;
                            if (k.Type == "Pol") continue;
                            if (k.Type == "deadhero") continue;
                            //if (k.Type == "blueflag") continue;
                            if (GameLogic.Intersects(k, ax, ax1, ay, ay1) == true)
                            {
                                if (k.Type == "blueflag")
                                {
                                    Entity.Objects.BaseObject myTemp;
                                    GameLogic.allGames[gameId].Remove(red.Id, out myTemp);
                                    var newred = new Entity.Objects.RedFlag();
                                    newred.Left = 550;
                                    newred.Bottom = -200;
                                    GameLogic.allGames[gameId].TryAdd(newred.Id, newred);
                                    //var newblue = new Entity.Objects.BlueFlag();
                                    //GameLogic.allGames[gameId].TryAdd;
                                }

                            }
                        }
                    }

                }


                //MoveY
                foreach (var i in GameLogic.allGames[gameId].Values)
                {

                    if (i.Type == "hero")
                    {

                        var temp = (Entity.Objects.HeroObject)i;
                        if (temp.IsMoveble == true)
                        {
                            if (temp.YPos != 0)
                            {
                                temp.YPos = temp.YPos - temp.YDelta;
                                var ax = temp.Left;
                                var ax1 = temp.Left + temp.Width;
                                var ay = temp.Bottom + temp.YDelta;
                                var ay1 = temp.Bottom + temp.YDelta + temp.Height;
                                bool canMove = true;
                                foreach (var k in GameLogic.allGames[gameId].Values)
                                {
                                    if (temp.Type == k.Type) continue;
                                    if (k.Type == "hero") continue;
                                    if (k.Type == "Pol") continue;
                                    if (k.Type == "deadhero") continue;
                                    if (GameLogic.Intersects(k, ax, ax1, ay, ay1) == true)
                                    {
                                        if (temp.Team == "red")
                                        {

                                            if (k.Type == "blueflag")
                                            {

                                                k.Left = temp.Left;
                                                k.Bottom = temp.Bottom - 10;
                                                continue;
                                            }
                                            if (k.Type == "redflag")
                                            {
                                                continue;
                                            }
                                        }
                                        else if (temp.Team == "blue")
                                        {

                                            if (k.Type == "redflag")
                                            {

                                                k.Left = temp.Left;
                                                k.Bottom = temp.Bottom;
                                                continue;
                                            }
                                            if (k.Type == "blueflag")
                                            {
                                                continue;
                                            }
                                        }


                                        if (k.Type == "guns")
                                        {
                                            if (temp.UserId == userId)
                                            {
                                                var obj = (Entity.Objects.Item)k;
                                                temp.Items.Add(obj);
                                                Entity.Objects.BaseObject myTemp;
                                                GameLogic.allGames[gameId].Remove(obj.Id, out myTemp);
                                            }
                                        }
                                        canMove = false;
                                        break;
                                    }
                                }
                                if (canMove == true)
                                {
                                    temp.Bottom += temp.YDelta;
                                   
                                }
                            }
                        }
                    }
                    if (i.Type == "redflag")
                    {
                        var red = (Entity.Objects.RedFlag)i;
                        var ax = red.Left;
                        var ax1 = red.Left + red.Width;
                        var ay = red.Bottom;
                        var ay1 = red.Bottom + red.Height;
                        foreach (var k in GameLogic.allGames[gameId].Values)
                        {

                            if (red.Type == k.Type) continue;
                            if (k.Type == "hero") continue;
                            if (k.Type == "Pol") continue;
                            if (k.Type == "deadhero") continue;
                           // if (k.Type == "blueflag") continue;
                            if (GameLogic.Intersects(k, ax, ax1, ay, ay1) == true)
                            {
                                if (k.Type == "blueflag")
                                {
                                    Entity.Objects.BaseObject myTemp;
                                    GameLogic.allGames[gameId].Remove(red.Id, out myTemp);
                                    var newred = new Entity.Objects.RedFlag();
                                    newred.Left = 550;
                                    newred.Bottom = -200;
                                    GameLogic.allGames[gameId].TryAdd(newred.Id, newred);
                                    //var newblue = new Entity.Objects.BlueFlag();
                                    //GameLogic.allGames[gameId].TryAdd;
                                }

                            }
                        }
                    }
                    if (i.Type == "blueflag")
                    {
                        var blue = (Entity.Objects.BlueFlag)i;
                        var ax = blue.Left;
                        var ax1 = blue.Left + blue.Width;
                        var ay = blue.Bottom;
                        var ay1 = blue.Bottom + blue.Height;
                        foreach (var k in GameLogic.allGames[gameId].Values)
                        {

                            if (blue.Type == k.Type) continue;
                            if (k.Type == "hero") continue;
                            if (k.Type == "Pol") continue;
                            if (k.Type == "deadhero") continue;
                           // if (k.Type == "redflag") continue;
                            if (GameLogic.Intersects(k, ax, ax1, ay, ay1) == true)
                            {
                                if (k.Type == "redflag")
                                {
                                    Entity.Objects.BaseObject myTemp;
                                    GameLogic.allGames[gameId].Remove(blue.Id, out myTemp);
                                    var newblue = new Entity.Objects.BlueFlag();
                                    newblue.Left = 350;
                                    newblue.Bottom = -200;
                                    GameLogic.allGames[gameId].TryAdd(newblue.Id, newblue);
                                    //var newblue = new Entity.Objects.BlueFlag();
                                    //GameLogic.allGames[gameId].TryAdd;
                                }

                            }
                        }
                    }
                    
                }

                // moveX bullet
                foreach (var i in GameLogic.allGames[gameId].Values)
                {
                    var bul = (Entity.Objects.BaseObject)i;
                    if (bul.Type == "bullet")
                    {
                        
                        
                        if (bul.IsMoveble == true)
                        {
                            if (bul.XPos != 0)
                            {
                                bul.XPos = bul.XPos - bul.XDelta;
                                var ax = bul.Left + bul.XDelta;
                                var ax1 = bul.Left + bul.XDelta + bul.Width;
                                var ay = bul.Bottom + bul.YDelta;
                                var ay1 = bul.Bottom + bul.YDelta + bul.Height;
                                bool canMove = true;

                                foreach (var k in GameLogic.allGames[gameId].Values)
                                {
                                    if (bul.Type == k.Type) continue;
                                    if (k.Type == "bullet") continue;
                                    if (k.Type == "Pol") continue;
                                    if (k.Type == "deadhero") continue;
                                    if (k.Type == "guns") continue;
                                    if (k.Type == "redflag") continue;
                                    if (k.Type == "blueflag") continue;
                                    if (GameLogic.Intersects(k, ax, ax1, ay, ay1) == true)
                                    {
                                        Entity.Objects.BaseObject myTemp;
                                        GameLogic.allGames[gameId].Remove(i.Type, out myTemp);
                                        if (k.Type == "enemy")
                                        {
                                            var target = (Entity.Objects.EnemyObjects)k;
                                            target.HP -= bul.Damage;
                                            canMove = false;
                                            if (target.HP <= 0)
                                            {
                                                var dead = new Entity.Objects.DeadHero();
                                                dead.Left = target.Left;
                                                dead.Bottom = target.Bottom;
                                                GameLogic.allGames[gameId].TryAdd(dead.Id, dead);
                                                Entity.Objects.BaseObject myTemp2;
                                                GameLogic.allGames[gameId].Remove(target.Id, out myTemp2);


                                            }
                                        }
                                        else if (k.Type == "hero")
                                        {
                                            var target1 = (Entity.Objects.HeroObject)k;
                                            target1.HP -= bul.Damage;
                                            canMove = false;
                                            if (target1.HP <= 0)
                                            {
                                                var dead = new Entity.Objects.DeadHero();
                                                dead.Left = target1.Left;
                                                dead.Bottom = target1.Bottom;
                                                GameLogic.allGames[gameId].TryAdd(dead.Id, dead);
                                                Entity.Objects.BaseObject myTemp4;
                                                GameLogic.allGames[gameId].Remove(target1.Id, out myTemp4);

                                            }
                                        }
                                        else
                                        {
                                            canMove = false;
                                            break;
                                        }



                                    }
                                }
                                if (canMove == true)
                                {
                                    bul.Left += bul.XDelta;
                                }
                            }
                            else if (bul.YPos != 0)
                            {
                                bul.YPos = bul.YPos - bul.YDelta;
                                var ax = bul.Left;
                                var ax1 = bul.Left + bul.Width;
                                var ay = bul.Bottom + bul.YDelta;
                                var ay1 = bul.Bottom + bul.YDelta + bul.Height;
                                bool canMove = true;
                                foreach (var k in GameLogic.allGames[gameId].Values)
                                {
                                    if (bul.Type == k.Type) continue;
                                    if (k.Type == "bullet") continue;
                                    if (k.Type == "Pol") continue;
                                    if (k.Type == "deadhero") continue;
                                    if (k.Type == "guns") continue;
                                    if (k.Type == "redflag") continue;
                                    if (k.Type == "blueflag") continue;
                                    if (GameLogic.Intersects(k, ax, ax1, ay, ay1) == true)
                                    {
                                        Entity.Objects.BaseObject myTemp;
                                        GameLogic.allGames[gameId].Remove(i.Type, out myTemp);
                                        if (k.Type == "enemy")
                                        {
                                            var target = (Entity.Objects.EnemyObjects)k;
                                            target.HP -= bul.Damage;
                                            canMove = false;
                                            if (target.HP <= 0)
                                            {
                                                var dead = new Entity.Objects.DeadHero();
                                                dead.Left = target.Left;
                                                dead.Bottom = target.Bottom;
                                                GameLogic.allGames[gameId].TryAdd(dead.Id, dead);
                                                Entity.Objects.BaseObject myTemp2;
                                                GameLogic.allGames[gameId].Remove(target.Id, out myTemp2);

                                            }
                                        }
                                        else if (k.Type == "hero")
                                        {
                                            var target1 = (Entity.Objects.HeroObject)k;
                                            target1.HP -= bul.Damage;
                                            canMove = false;
                                            if (target1.HP <= 0)
                                            {
                                                var dead = new Entity.Objects.DeadHero();
                                                dead.Left = target1.Left;
                                                dead.Bottom = target1.Bottom;
                                                GameLogic.allGames[gameId].TryAdd(dead.Id, dead);
                                                Entity.Objects.BaseObject myTemp4;
                                                GameLogic.allGames[gameId].Remove(target1.Id, out myTemp4);

                                            }
                                        }

                                        else
                                        {
                                            canMove = false;
                                            break;
                                        }



                                    }
                                }
                                if (canMove == true)
                                {
                                    bul.Bottom += bul.YDelta;
                                }
                            }
                            else
                            {
                                Entity.Objects.BaseObject myTemp3;
                                GameLogic.allGames[gameId].Remove(i.Type, out myTemp3);
                            }
                        }
                        
                    }
                }



               /* // move suriken
                foreach (var i in GameLogic.allGames[gameId].Values)
                {
                    if (i.Type == "suriken")
                    {
                        var bul = (Entity.Objects.SurikenBullet)i;
                        if (bul.IsMoveble == true)
                        {
                            if (bul.XPos != 0)
                            {
                                bul.XPos = bul.XPos - bul.XDelta;
                                var ax = bul.Left + bul.XDelta;
                                var ax1 = bul.Left + bul.XDelta + bul.Width;
                                var ay = bul.Bottom + bul.YDelta;
                                var ay1 = bul.Bottom + bul.YDelta + bul.Height;
                                bool canMove = true;

                                foreach (var k in GameLogic.allGames[gameId].Values)
                                {
                                    if (bul.Type == k.Type) continue;
                                    if (k.Type == "bullet") continue;
                                    if (k.Type == "Pol") continue;
                                    if (k.Type == "deadhero") continue;
                                    if (k.Type == "guns") continue;
                                    if (GameLogic.Intersects(k, ax, ax1, ay, ay1) == true)
                                    {
                                        Entity.Objects.BaseObject myTemp;
                                        GameLogic.allGames[gameId].Remove(i.Type, out myTemp);
                                        if (k.Type == "enemy")
                                        {
                                            var target = (Entity.Objects.EnemyObjects)k;
                                            target.HP -= bul.Damage;
                                            canMove = false;
                                            if (target.HP <= 0)
                                            {
                                                var dead = new Entity.Objects.DeadHero();
                                                dead.Left = target.Left;
                                                dead.Bottom = target.Bottom;
                                                GameLogic.allGames[gameId].TryAdd(dead.Id, dead);
                                                Entity.Objects.BaseObject myTemp2;
                                                GameLogic.allGames[gameId].Remove(target.Id, out myTemp2);


                                            }
                                        }
                                        else if (k.Type == "hero")
                                        {
                                            var target1 = (Entity.Objects.HeroObject)k;
                                            target1.HP -= bul.Damage;
                                            canMove = false;
                                            if (target1.HP <= 0)
                                            {
                                                var dead = new Entity.Objects.DeadHero();
                                                dead.Left = target1.Left;
                                                dead.Bottom = target1.Bottom;
                                                GameLogic.allGames[gameId].TryAdd(dead.Id, dead);
                                                Entity.Objects.BaseObject myTemp4;
                                                GameLogic.allGames[gameId].Remove(target1.Id, out myTemp4);

                                            }
                                        }
                                        else
                                        {
                                            canMove = false;
                                            break;
                                        }



                                    }
                                }
                                if (canMove == true)
                                {
                                    bul.Left += bul.XDelta;
                                }
                            }
                            else if (bul.YPos != 0)
                            {
                                bul.YPos = bul.YPos - bul.YDelta;
                                var ax = bul.Left;
                                var ax1 = bul.Left + bul.Width;
                                var ay = bul.Bottom + bul.YDelta;
                                var ay1 = bul.Bottom + bul.YDelta + bul.Height;
                                bool canMove = true;
                                foreach (var k in GameLogic.allGames[gameId].Values)
                                {
                                    if (bul.Type == k.Type) continue;
                                    if (k.Type == "bullet") continue;
                                    if (k.Type == "Pol") continue;
                                    if (k.Type == "deadhero") continue;
                                    if (k.Type == "guns") continue;
                                    if (GameLogic.Intersects(k, ax, ax1, ay, ay1) == true)
                                    {
                                        Entity.Objects.BaseObject myTemp;
                                        GameLogic.allGames[gameId].Remove(i.Type, out myTemp);
                                        if (k.Type == "enemy")
                                        {
                                            var target = (Entity.Objects.EnemyObjects)k;
                                            target.HP -= bul.Damage;
                                            canMove = false;
                                            if (target.HP <= 0)
                                            {
                                                var dead = new Entity.Objects.DeadHero();
                                                dead.Left = target.Left;
                                                dead.Bottom = target.Bottom;
                                                GameLogic.allGames[gameId].TryAdd(dead.Id, dead);
                                                Entity.Objects.BaseObject myTemp2;
                                                GameLogic.allGames[gameId].Remove(target.Id, out myTemp2);

                                            }
                                        }
                                        else if (k.Type == "hero")
                                        {
                                            var target1 = (Entity.Objects.HeroObject)k;
                                            target1.HP -= bul.Damage;
                                            canMove = false;
                                            if (target1.HP <= 0)
                                            {
                                                var dead = new Entity.Objects.DeadHero();
                                                dead.Left = target1.Left;
                                                dead.Bottom = target1.Bottom;
                                                GameLogic.allGames[gameId].TryAdd(dead.Id, dead);
                                                Entity.Objects.BaseObject myTemp4;
                                                GameLogic.allGames[gameId].Remove(target1.Id, out myTemp4);

                                            }
                                        }

                                        else
                                        {
                                            canMove = false;
                                            break;
                                        }



                                    }
                                }
                                if (canMove == true)
                                {
                                    bul.Bottom += bul.YDelta;
                                }
                            }
                            else
                            {
                                Entity.Objects.BaseObject myTemp3;
                                GameLogic.allGames[gameId].Remove(i.Type, out myTemp3);
                            }
                        }
                    }
                }*/


                

            }
            return Task.CompletedTask;
        }
    }
}
