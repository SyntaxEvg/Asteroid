using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Asteroid.Properties;
using System.Security.Cryptography;

namespace Asteroid
{
    //XNA - MONO
    static class Game 
    {
        

        public static int Width { get; set; }
        public static int Height { get; set; }

        static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public static Random Rand { get; } = new Random();
        static BaseObject[] _objects;

        //static Image background = Image.FromFile("Images/Space.jpg");
        static Game()
        {

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
            _objects = new BaseObject[30]; // создание обьектов  в видео  астероидов


            for (int i = 0; i < _objects.Length / 2; i++)
            {
                    var s = Rand.Next(10, 47);
                    var t = Rand.Next(1, 30) * Rand.Next(1, 30);
                    var pos = new Point(Width, t + s);
                    var Скорость = new Point(Rand.Next(5, 20), 0);
                    var size = new Size(s, s);
                    _objects[i] = new Asteroid(pos, Скорость, size);

            }

                for (int i = 15; i < _objects.Length; i++)
                _objects[i] = new Star(new Point(Width - 10, i * 20),
                              new Point(15 - i, 15 - i),
                              new Size(30, 30), Brushes.Blue);

        }
   
    public static void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            StartForm.Buffer.Graphics.DrawImage(Resources.spac, Point.Empty);
            foreach (BaseObject baseObject in _objects)
            {                            
                if (baseObject !=null)
                {
                    baseObject.Draw();//Полиморфизм
                }
                //Star obj = baseObject as Star;
                //if (baseObject is Star) (baseObject as Star).Draw();//Wrong!
               
            }
            StartForm.Buffer.Render();//отобразить изменения
        }

        public static void Update()
        {            
            //для каждой фигуры вызвать метод update

            foreach (BaseObject baseObject in _objects)

                if (baseObject !=null)
                {
                    baseObject.Update();

                }        
        }

    }
}
