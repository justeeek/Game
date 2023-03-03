using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace BL
{
    public static class GameLogic
    {
        public static ConcurrentDictionary<int, ConcurrentDictionary<string, Entity.Objects.BaseObject>> allGames = new ConcurrentDictionary<int, ConcurrentDictionary<string, Entity.Objects.BaseObject>>();

        public static ConcurrentDictionary<int, ConcurrentDictionary<int, (bool, double, double)>> allFire = new ConcurrentDictionary<int, ConcurrentDictionary<int, (bool, double, double)>>();

        public static ConcurrentDictionary<int, ConcurrentDictionary<int, ConcurrentDictionary<int, bool>>> allButtons = new ConcurrentDictionary<int, ConcurrentDictionary<int, ConcurrentDictionary<int, bool>>>();

        public static ConcurrentDictionary<int, ConcurrentDictionary<int, bool>> usersInGame = new ConcurrentDictionary<int, ConcurrentDictionary<int, bool>>();

        public static void Initialization(Entity.Game game)
        {
            allButtons.TryAdd(game.Id, new ConcurrentDictionary<int, ConcurrentDictionary<int, bool>>());
            allFire.TryAdd(game.Id, new ConcurrentDictionary<int, (bool, double, double)>());
            usersInGame.TryAdd(game.Id, new ConcurrentDictionary<int, bool>());

            var arr = new ConcurrentDictionary<string, Entity.Objects.BaseObject>();
            //var array = new ConcurrentDictionary<string, Entity.Objects.Item>();

            

            var enemy = new Entity.Objects.EnemyObjects();
            enemy.Left = 650;
            enemy.Bottom = 750;
            arr.TryAdd(enemy.Id, enemy);

            var enemy1 = new Entity.Objects.EnemyObjects();
            enemy1.Left = 550;
            enemy1.Bottom = 400;
            arr.TryAdd(enemy1.Id, enemy1);

            var enemy2 = new Entity.Objects.EnemyObjects();
            enemy2.Left = 450;
            enemy2.Bottom = 250;
            arr.TryAdd(enemy2.Id, enemy2);

            var enemy3 = new Entity.Objects.EnemyObjects();
            enemy3.Left = 1300;
            enemy3.Bottom = 465;
            arr.TryAdd(enemy3.Id, enemy3);

            var enemy4 = new Entity.Objects.EnemyObjects();
            enemy4.Left = 1100;
            enemy4.Bottom = 645;
            arr.TryAdd(enemy4.Id, enemy4);

            var enemy5 = new Entity.Objects.EnemyObjects();
            enemy5.Left = 400;
            enemy5.Bottom = -200;
            arr.TryAdd(enemy5.Id, enemy5);

             var pol1 = new Entity.Objects.Pol7Objects();
             pol1.Width = 1220;
             pol1.Height = 245;
             pol1.Left = 800;
             pol1.Bottom = -120;
             arr.TryAdd(pol1.Id, pol1);

             var pol2 = new Entity.Objects.Pol6Objects();
             pol2.Width = 350;
             pol2.Height = 365;
             pol2.Left = 1450;
             pol2.Bottom = 515;
             arr.TryAdd(pol2.Id, pol2);


             var pol4 = new Entity.Objects.Pol1Objects();
             pol4.Width = 380;
             pol4.Height = 300;
             pol4.Left = 1060;
             pol4.Bottom = 125;
             arr.TryAdd(pol4.Id, pol4);

             var pol5 = new Entity.Objects.Pol3Objects();
             pol5.Width = 240;
             pol5.Height = 375;
             pol5.Left = 300;
             pol5.Bottom = 505;
             arr.TryAdd(pol5.Id, pol5);

            var pol25 = new Entity.Objects.Pol1Objects();
            pol25.Width = 310;
            pol25.Height = 375;
            pol25.Left = 550;
            pol25.Bottom = 505;
            arr.TryAdd(pol25.Id, pol25);

            var pol6 = new Entity.Objects.Pol4Objects();
             pol6.Width = 460;
             pol6.Height = 295;
             pol6.Left = 1060;
             pol6.Bottom = 585;
             arr.TryAdd(pol6.Id, pol6);

             var pol7 = new Entity.Objects.Pol2Objects();
             pol7.Width = 940;
             pol7.Height = 540;
             pol7.Left = 2000;
             pol7.Bottom = -415;
             arr.TryAdd(pol7.Id, pol7);

             

             var pol9 = new Entity.Objects.Pol2Objects();
             pol9.Width = 300;
             pol9.Height = 375;
             pol9.Left = 2060;
             pol9.Bottom = 505;
             arr.TryAdd(pol9.Id, pol9);

             var pol10 = new Entity.Objects.Pol4Objects();
             pol10.Width = 580;
             pol10.Height = 755;
             pol10.Left = 2360;
             pol10.Bottom = 125;
             arr.TryAdd(pol10.Id, pol10);

             var pol11 = new Entity.Objects.Pol3Objects();
             pol11.Width = 380;
             pol11.Height = 300;
             pol11.Left = 2560;
             pol11.Bottom = 125;
             arr.TryAdd(pol11.Id, pol11);

             var pol12 = new Entity.Objects.Pol1Objects();
             pol12.Width = 240;
             pol12.Height = 375;
             pol12.Left = 1800;
             pol12.Bottom = 505;
             arr.TryAdd(pol12.Id, pol12);

             var pol13 = new Entity.Objects.Pol7Objects();
             pol13.Width = 460;
             pol13.Height = 295;
             pol13.Left = 2560;
             pol13.Bottom = 585;
             arr.TryAdd(pol13.Id, pol13);

             var pol14 = new Entity.Objects.Pol6Objects();
             pol14.Width = 630;
             pol14.Height = 430;
             pol14.Left = 1730;
             pol14.Bottom = 75;
             arr.TryAdd(pol14.Id, pol14);

             var pol15 = new Entity.Objects.Pol1Objects();
             pol15.Width = 580;
             pol15.Height = 755;
             pol15.Left = 1360;
             pol15.Bottom = -857;
             arr.TryAdd(pol15.Id, pol15);

             var pol16 = new Entity.Objects.Pol7Objects();
             pol16.Width = 630;
             pol16.Height = 430;
             pol16.Left = 730;
             pol16.Bottom = -925;
             arr.TryAdd(pol16.Id, pol16);

             var pol17 = new Entity.Objects.Pol6Objects();
             pol17.Width = 460;
             pol17.Height = 295;
             pol17.Left = 1560;
             pol17.Bottom = -415;
             arr.TryAdd(pol17.Id, pol17);

             var pol18 = new Entity.Objects.Pol3Objects();
             pol18.Width = 240;
             pol18.Height = 375;
             pol18.Left = 800;
             pol18.Bottom = -495;
             arr.TryAdd(pol18.Id, pol18);

             var pol19 = new Entity.Objects.Pol2Objects();
             pol19.Width = 380;
             pol19.Height = 300;
             pol19.Left = 1560;
             pol19.Bottom = -875;
             arr.TryAdd(pol19.Id, pol19);

             var pol20 = new Entity.Objects.Pol8Objects();
             pol20.Width = 300;
             pol20.Height = 375;
             pol20.Left = 1060;
             pol20.Bottom = -495;
             arr.TryAdd(pol20.Id, pol20);

             var pol21 = new Entity.Objects.Pol2Objects();
             pol21.Width = 270;
             pol21.Height = 380;
             pol21.Left = 1450;
             pol21.Bottom = 125;
             arr.TryAdd(pol21.Id, pol21);

             var pol22 = new Entity.Objects.Pol2Objects();
             pol22.Width = 500;
             pol22.Height = 430;
             pol22.Left = 220;
             pol22.Bottom = -925;
             arr.TryAdd(pol22.Id, pol22);

             var pol23 = new Entity.Objects.Pol1Objects();
             pol23.Width = 580;
             pol23.Height = 560;
             pol23.Left = 220;
             pol23.Bottom = -495;
             arr.TryAdd(pol23.Id, pol23);

             var pol24 = new Entity.Objects.Pol3Objects();
             pol24.Width = 1000;
             pol24.Height = 460;
             pol24.Left = 1940;
             pol24.Bottom = -875;
             arr.TryAdd(pol24.Id, pol24);

            for (int i = 0; i < 61; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 300 + i * 20;
                wall.Bottom = 880;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 18; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 300;
                wall.Bottom = 525 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 8; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 220 + i * 20;
                wall.Bottom = 505;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 73; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 220;
                wall.Bottom = -935 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 31; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 240 + i * 20;
                wall.Bottom = 65;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 10; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 840;
                wall.Bottom = 85 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 2; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 860 + i * 20;
                wall.Bottom = 125;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 5; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1620 + i * 20;
                wall.Bottom = 125;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 28; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 980 + i * 20;
                wall.Bottom = 125;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 23; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1440;
                wall.Bottom = 145 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 3; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1460 + i * 20;
                wall.Bottom = 585;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 3; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1500;
                wall.Bottom = 605 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1500;
                wall.Bottom = 745 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 4; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1060;
                wall.Bottom = 145 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1060;
                wall.Bottom = 305 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 18; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1080 + i * 20;
                wall.Bottom = 425;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 15; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 840;
                wall.Bottom = 365 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 840;
                wall.Bottom = 745 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 460 + i * 20;
                wall.Bottom = 505;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 8; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 680 + i * 20;
                wall.Bottom = 505;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 18; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 540;
                wall.Bottom = 525 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 15; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1060;
                wall.Bottom = 585 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 6; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1080 + i * 20;
                wall.Bottom = 585;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 8; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1280 + i * 20;
                wall.Bottom = 585;
                arr.TryAdd(wall.Id, wall);
            }


            for (int i = 0; i < 13; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1460 + i * 20;
                wall.Bottom = 505;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 14; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1520 + i * 20;
                wall.Bottom = 880;
                arr.TryAdd(wall.Id, wall);
            }







            for (int i = 0; i < 61; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1800 + i * 20;
                wall.Bottom = 880;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1800;
                wall.Bottom = 525 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1800;
                wall.Bottom = 745 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 8; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1720 + i * 20;
                wall.Bottom = 505;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 23; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1720;
                wall.Bottom = 65 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 31; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1740 + i * 20;
                wall.Bottom = 65;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 10; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2340;
                wall.Bottom = 85 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 2; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2360 + i * 20;
                wall.Bottom = 125;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 74; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2940;
                wall.Bottom = -875 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 24; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2480 + i * 20;
                wall.Bottom = 125;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 3; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2960 + i * 20;
                wall.Bottom = 585;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 14; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 3000;
                wall.Bottom = 605 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 4; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2560;
                wall.Bottom = 145 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2560;
                wall.Bottom = 305 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 18; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2580 + i * 20;
                wall.Bottom = 425;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 15; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2340;
                wall.Bottom = 365 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2340;
                wall.Bottom = 745 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1960 + i * 20;
                wall.Bottom = 505;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 8; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2180 + i * 20;
                wall.Bottom = 505;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 18; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2040;
                wall.Bottom = 525 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 15; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2560;
                wall.Bottom = 585 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 6; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2580 + i * 20;
                wall.Bottom = 585;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 8; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2780 + i * 20;
                wall.Bottom = 585;
                arr.TryAdd(wall.Id, wall);
            }






            for (int i = 0; i < 61; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 800 + i * 20;
                wall.Bottom = -120;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 2; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 800;
                wall.Bottom = -100 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }

            for (int i = 0; i < 2; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 800;
                wall.Bottom = 20 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 18; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 800;
                wall.Bottom = -475 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }

            for (int i = 0; i < 10; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 240 + i * 20;
                wall.Bottom = -495;
                arr.TryAdd(wall.Id, wall);
            }

            for (int i = 0; i < 18; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 520 + i * 20;
                wall.Bottom = -495;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 22; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 720;
                wall.Bottom = -915 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 57; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 220 + i * 20;
                wall.Bottom = -935;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 10; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1340;
                wall.Bottom = -915 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 2; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1360 + i * 20;
                wall.Bottom = -875;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 78; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1400 + i * 20;
                wall.Bottom = -875;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 23; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1940;
                wall.Bottom = -855 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 3; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1960 + i * 20;
                wall.Bottom = -415;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 3; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2000;
                wall.Bottom = -395 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2000;
                wall.Bottom = -255 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 4; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1560;
                wall.Bottom = -855 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1560;
                wall.Bottom = -695 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 18; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1580 + i * 20;
                wall.Bottom = -575;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 15; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1340;
                wall.Bottom = -635 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1340;
                wall.Bottom = -255 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 7; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 960 + i * 20;
                wall.Bottom = -495;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 8; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1180 + i * 20;
                wall.Bottom = -495;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 18; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1040;
                wall.Bottom = -475 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 15; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1560;
                wall.Bottom = -415 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 6; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1580 + i * 20;
                wall.Bottom = -415;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 28; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 1780 + i * 20;
                wall.Bottom = -415;
                arr.TryAdd(wall.Id, wall);
            }

            for (int i = 0; i < 26; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2440 + i * 20;
                wall.Bottom = -415;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 2; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2000;
                wall.Bottom = -100 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }
            for (int i = 0; i < 2; i++)
            {
                var wall = new Entity.Objects.WallObjects();
                wall.Left = 2000;
                wall.Bottom = 20 + i * 20;
                arr.TryAdd(wall.Id, wall);
            }


            var divan = new Entity.Objects.DivanObjects();
            arr.TryAdd(divan.Id, divan);

            var stol = new Entity.Objects.StolObjects();
            stol.Transform = "rotate(180deg)";
            arr.TryAdd(stol.Id, stol);

            var stoll = new Entity.Objects.StolObjects();
            stoll.Left = 1200;
            stoll.Bottom = 250;
            arr.TryAdd(stoll.Id, stoll);

            var stol2 = new Entity.Objects.Stol2Objects();
            arr.TryAdd(stol2.Id, stol2);

            var cvetok = new Entity.Objects.CvetokObjects();
            arr.TryAdd(cvetok.Id, cvetok);

            var cvetok1 = new Entity.Objects.CvetokObjects();
            cvetok1.Left = 969;
            cvetok1.Bottom = 796; 
            arr.TryAdd(cvetok1.Id, cvetok1);

            var cvetok2 = new Entity.Objects.CvetokObjects();
            cvetok2.Left = 1349;
            cvetok2.Bottom = 501;
            arr.TryAdd(cvetok2.Id, cvetok2);

            var kitchen = new Entity.Objects.KitchenObjects();
            arr.TryAdd(kitchen.Id, kitchen);

            var stul = new Entity.Objects.StulObjects();
            arr.TryAdd(stul.Id, stul);

            var stul2 = new Entity.Objects.StulObjects();
            stul2.Left = 1262;
            stul2.Bottom = 275;
            stul2.Transform = "rotate(90deg)";
            arr.TryAdd(stul2.Id, stul2);

            var stul3 = new Entity.Objects.StulObjects();
            stul3.Left = 1215;
            stul3.Bottom = 210;
            stul3.Transform = "rotate(180deg)";
            arr.TryAdd(stul3.Id, stul3);

            var stul4 = new Entity.Objects.StulObjects();
            stul4.Left = 1160;
            stul4.Bottom = 275;
            stul4.Transform = "rotate(270deg)";
            arr.TryAdd(stul4.Id, stul4);

            for (int i = 0; i < 3; i++)
            {
                var stul5 = new Entity.Objects.StulObjects();
                stul5.Left = 1100 + i * 94;
                stul5.Bottom = 768;
                stul5.Transform = "rotate(180deg)";
                arr.TryAdd(stul5.Id, stul5);
            }

            var laba = new Entity.Objects.LabaObjects();
            arr.TryAdd(laba.Id, laba);

            var vanna = new Entity.Objects.VannaObjects();
            arr.TryAdd(vanna.Id, vanna);

            var tualet = new Entity.Objects.TualetObjects();
            arr.TryAdd(tualet.Id, tualet);

            var rakovina = new Entity.Objects.RakovinaObjects();
            arr.TryAdd(rakovina.Id, rakovina);

            var korobka = new Entity.Objects.KorobkaObjects();
            arr.TryAdd(korobka.Id, korobka);

            var stol3 = new Entity.Objects.StolObjects();
            arr.TryAdd(stol3.Id, stol3);

            var pol8 = new Entity.Objects.Pol4Objects();
            pol8.Width = 630;
            pol8.Height = 430;
            pol8.Left = 230;
            pol8.Bottom = 75;
            arr.TryAdd(pol8.Id, pol8);

            var pol3 = new Entity.Objects.Pol2Objects();
            pol3.Width = 580;
            pol3.Height = 755;
            pol3.Left = 860;
            pol3.Bottom = 125;
            arr.TryAdd(pol3.Id, pol3);

            var pistol = new Entity.Objects.PistolObject();
            pistol.Left = 260;
            pistol.Bottom = 425;
            arr.TryAdd(pistol.Id, pistol);

            var ak = new Entity.Objects.AkObject();
            ak.Left = 290;
            ak.Bottom = 305;
            arr.TryAdd(ak.Id, ak);

            var rifle = new Entity.Objects.RifleObject();
            rifle.Left = 350;
            rifle.Bottom = 425;
            arr.TryAdd(rifle.Id, rifle);

            var minigun = new Entity.Objects.MinigunObject();
            minigun.Left = 650;
            minigun.Bottom = 190;
            arr.TryAdd(minigun.Id, minigun);

            var BlueFlag = new Entity.Objects.BlueFlag();
            BlueFlag.Left = 350;
            BlueFlag.Bottom = -200;
            arr.TryAdd(BlueFlag.Id, BlueFlag);

            var RedFlag = new Entity.Objects.RedFlag();
            RedFlag.Left = 550;
            RedFlag.Bottom = -200;
            arr.TryAdd(RedFlag.Id, RedFlag);

            var armor = new Entity.Objects.ArmorObject();
            armor.Left = 650;
            armor.Bottom = 300;
            arr.TryAdd(armor.Id, armor);

            var armor2 = new Entity.Objects.ArmorObject();
            armor2.Left = 550;
            armor2.Bottom = 350;
            arr.TryAdd(armor2.Id, armor2);

            allGames.TryAdd(game.Id, arr);
        }

        public static void JoinUser(int gameId, int userId)
        {
            allButtons[gameId].TryAdd(userId, new ConcurrentDictionary<int, bool>());
            allFire[gameId].TryAdd(userId, (false, 0, 0));
            usersInGame[gameId].TryAdd(userId, true);

            
            var userHero = new Entity.Objects.HeroObject();
            userHero.UserId = userId;
            allGames[gameId].TryAdd(userHero.Id, userHero);
            

        }

        public static bool Intersects(Entity.Objects.BaseObject o1, /* Entity.Objects.BaseObject o2 */ double ax, double ax1, double ay, double ay1 /* double bx, double bx1, double by, double by1*/)
        {
            /*var ax = o1.Left;
            var ax1 = o1.Left + o1.Width;
            var ay = o1.Bottom;
            var ay1 = o1.Bottom + o1.Height;
            */
            var bx = o1.Left;
            var bx1 = o1.Left + o1.Width;
            var by = o1.Bottom;
            var by1 = o1.Bottom + o1.Height;
            
            return (
                (
                    (
                        (ax >= bx && ax <= bx1) || (ax1 >= bx && ax1 <= bx1)
                    ) && (
                        (ay >= by && ay <= by1) || (ay1 >= by && ay1 <= by1)
                    )
                ) || (
                    (
                        (bx >= ax && bx <= ax1) || (bx1 >= ax && bx1 <= ax1)
                    ) && (
                        (by >= ay && by <= ay1) || (by1 >= ay && by1 <= ay1)
                    )
                )
            ) || (
                (
                    (
                        (ax >= bx && ax <= bx1) || (ax1 >= bx && ax1 <= bx1)
                    ) && (
                        (by >= ay && by <= ay1) || (by1 >= ay && by1 <= ay1)
                    )
                ) || (
                    (
                        (bx >= ax && bx <= ax1) || (bx1 >= ax && bx1 <= ax1)
                    ) && (
                        (ay >= by && ay <= by1) || (ay1 >= by && ay1 <= by1)
                    )
                )
            );
        }
    }
}
