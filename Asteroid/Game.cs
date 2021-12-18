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

namespace Asteroid
{
    //XNA - MONO
    static class Game
    {
       public static int count = 0;
       public  static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public static Random Rand { get; } = new Random();
        static BaseObject[] _objects;
        public static Bullet bull =new Bullet(new Point(0,200),new Point(30,0),new Size(30,8));
        public static Label label;
        public static Label TimerGame;

        public static string NameUser="";
        public static DateTime Sec = new DateTime(0, 0);
        static Game()
        {
            label = new Label();
            label.Text = $"Всего сбито: {count}";
            TimerGame = new Label();
            TimerGame.Text = "";


        }

       //static Form form1 =new Form();

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
 
        }

      
       

        public static void Load()
        {
            _objects = new BaseObject[60]; // создание обьектов  в видео  астероидов

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
   
        static string space = new string(' ', 30);
        public static void Draw()
        {
            
            StartForm.Buffer.Graphics.DrawImage(Resources.spac, Point.Empty); //перерисовка картинки
            Sec = Sec.AddSeconds(1);
            TimerGame.Text = Sec.ToString("mm:ss");
            StartForm.Buffer.Graphics.DrawString($"{label.Text}{space}Время игры: {TimerGame.Text}",
                         new Font("Arial", 24),
                         new SolidBrush(Color.White), 0, 0);

            foreach (BaseObject baseObject in _objects)
            {                            
                if (baseObject !=null)
                {
                    
                    baseObject.Draw();//Полиморфизм
                }
                //Star obj = baseObject as Star;
                //if (baseObject is Star) (baseObject as Star).Draw();//Wrong!
               
            }
            bull.Draw();



            StartForm.Buffer.Render();//отобразить изменения
        }

        public static void Update()
        {
            //для каждой фигуры вызвать метод update

            foreach (BaseObject baseObject in _objects)
            {
                if (baseObject != null)
                {
                    
                    if (baseObject.Collision(bull))
                    {
                        System.Media.SystemSounds.Beep.Play();
                        label.Text = $"Всего сбито:{count++}";
                        //Task.Run(() =>label.Text = $"Всего сбито:{count++}"); 
                        Debug.WriteLine("Bax!");//вывод в окно Вывод  в студии
                        baseObject.Update(true);//true- был удар
                        bull.Update(true);
                        continue;
                    }
                    else
                    baseObject.Update(false);
                }
            }

            bull.Update(false);

        }

    }
}
