using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Asteroid.Properties;
using System.Security.Cryptography;
using System.Diagnostics;
using Asteroid.ObjectGames;
using Asteroid.SERVICE;
using System.Threading;

namespace Asteroid
{
    //XNA - MONO
    static class Game
    {
       public static int count = 0;
       public  static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public static Random Rand { get; } = new Random();
        static BaseObject[] _objects;
        public static Bullet bull = null;//пули не сущест . перед отрисовкой проверка
        public static Label label;
        public static Label TimerGame;
        public static Ship ship;
        public static string NameUser="";
        public static DateTime Sec = new DateTime(0, 0);
        static Game()
        {
            label = new Label();
            label.Text = $"Всего сбито: {count}";
            TimerGame = new Label();
            TimerGame.Text = "";


        }

        

        public static void Init(Form form)
        {
           
            timer.Interval = 100;
            timer.Tick += delegate (object s, EventArgs r)
            {
                Draw();
                Update();
            };
            timer.Start();
            Load();

            form.KeyDown += delegate (object sender, KeyEventArgs e)
            {
                if (bull == null  && e.KeyCode == Keys.Space) //стрелять
                {
                    //для этого создаем пулю 
                    bull = new Bullet(new Point(ship.rectengle.X, ship.rectengle.Y+ 20), new Point(30, 0), new Size(30, 8));
                }
                if (e.KeyCode== Keys.Up)
                {
                    ship.UP();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    ship.Down();
                }
                else if (e.KeyCode == Keys.Left)
                {
                    ship.Left();
                }
                else if (e.KeyCode == Keys.Right)
                {
                    ship.Right();
                }
            };
            


        }

        public static void Load()
        {
            _objects = new BaseObject[30]; // создание обьектов  в видео  астероидов

            var PosShip = new Point(10, 300);
            var speed = new Point(10, 10);
            ship = new Ship(PosShip,speed,new Size(40,50));

            ship.EventDia += Ship_EventDia;
            for (int i = 0; i < _objects.Length / 2; i++)
            {
                    var s = Rand.Next(10, 47);
                    var t = Rand.Next(1, 30) * Rand.Next(1, 30);
                    var pos = new Point(StartForm.Width, t + s);
                    var Скорость = new Point(Rand.Next(5, 20), 0);
                    var size = new Size(s, s);
                    _objects[i] = new Asteroid(pos, Скорость, size);

            }
            
                //for (int i = 15; i < _objects.Length; i++)
                //_objects[i] = new Star(new Point(Width - 10, i * 20),
                //              new Point(15 - i, 15 - i),
                //              new Size(30, 30), Brushes.Blue);

        }




            private static void Ship_EventDia(object sender, EventArgs e)
        {
            timer.Stop();
            StartForm.Buffer.Graphics.DrawString($"Game Over!",
                        new Font("Arial", 72),
                        new SolidBrush(Color.White), 100, 100);
            StartForm.Buffer.Render();//отобразить изменения
            MessageBox.Show("Ваше результат находится в соответствующем пункте меню!", "Игра завершена",default,default,default,MessageBoxOptions.ServiceNotification);
            SaveResults.StopGame();
            
            Menu.Games.Hide();
            Menu.Games.Close();
            Menu.Games.Dispose();


        }

        static string space = new string(' ', 30);
        static Color LiveSh = Color.White;
        public static void Draw()
        {
            
            StartForm.Buffer.Graphics.DrawImage(Resources.spac, Point.Empty); //перерисовка картинки
            Sec = Sec.AddSeconds(1);
            TimerGame.Text = Sec.ToString("mm:ss");
            StartForm.Buffer.Graphics.DrawString($"{label.Text}{space}Время игры: {TimerGame.Text}",
                         new Font("Arial", 24),
                         new SolidBrush(LiveSh), 0, 0);

            foreach (BaseObject baseObject in _objects)
            {                            
                if (baseObject !=null)
                {                   
                    baseObject.Draw();//Полиморфизм
                }
                //Star obj = baseObject as Star;
                //if (baseObject is Star) (baseObject as Star).Draw();//Wrong!
               
            }
            if (ship !=null)
            {
               var hp = ship.LiveShip;
                if (ship.LiveShip < 30)//если жизни больше 30%  зеленка иначе красный
                {
                    LiveSh = Color.Red;
                }
                else
                {
                    LiveSh = Color.Green;
                }
                StartForm.Buffer.Graphics.DrawString($"HP: {hp}",
                            new Font("Arial", 24),
                            new SolidBrush(LiveSh), 0, 40);
                ship.Draw();
            }
           
            bull?.Draw();//пуля           
            if (ship?.LiveShip>0)
            {
                StartForm.Buffer.Render();//отобразить изменения
            }
            

            
        }

        public static void Update()
        {
            //для каждой фигуры вызвать метод update

            foreach (BaseObject baseObject in _objects)
            {
                if (baseObject != null)
                {
                    
                    if (bull != null && baseObject.Collision(bull))
                    {
                        System.Media.SystemSounds.Beep.Play();
                        label.Text = $"Всего сбито:{count++}";
                        //Task.Run(() =>label.Text = $"Всего сбито:{count++}"); 
                        //Debug.WriteLine("Bax!");//вывод в окно Вывод  в студии
                        baseObject.Update(true);//true- был удар
                        bull.Update(true);
                        bull = null;
                        continue;
                    }
                    if (ship != null && baseObject.Collision(ship))
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        baseObject.Update(true);//убираем астероид
                        var flag =ship.Loss(10)? true :false ;//удар  отнимает  5 хп , можно и рандомно... если убит вернет  тру
                        if (flag)
                        {
                            
                            ship.Dia();
                            ship = null;
                            timer.Stop();
                            return; 
                        }
                    }
                    else
                    baseObject.Update(false);
                }
            }

            bull?.Update(false);

        }

    }
}
