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
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public static Random Rand { get; } = new Random();
        static BaseObject[] _objects;

        static Image background = Image.FromFile("Images/Space.jpg");
        static Game()
        {

        }

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            form.Closed += Window_Closed;
            
            timer.Interval = 100;
            timer.Tick += delegate(object s, EventArgs r)
                {
                    Draw();
                    Update();
                };
            timer.Start();
            Load();
            
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            Buffer.Graphics.DrawImage(Resources.spac, Point.Empty);
            foreach (BaseObject baseObject in _objects)
            {             
                //if (baseObject.Posic.X <= 0 && baseObject is Asteroid)
                //{
                //   var s= Rand.Next(10,47);
                //    var t = Rand.Next(1, 30) * Rand.Next(1, 30);
                //    var pos = new Point(Width, t+s);
                //    var Скорость = new Point(Rand.Next(5, 20), 0);
                //    var size = new Size(s,s);
                //    baseObject.Posic = pos;
                //    baseObject.Speed = Скорость;
                //    baseObject.Sizes = size;
                //}
                if (baseObject !=null)
                {
                    baseObject.Draw();//Полиморфизм
                }
                //Star obj = baseObject as Star;
                //if (baseObject is Star) (baseObject as Star).Draw();//Wrong!
               
            }
            Buffer.Render();//отобразить изменения
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
