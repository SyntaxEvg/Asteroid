using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;



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
        static public Random Random { get; } = new Random();
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
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
            Load();
            
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Load()
        {
            _objects = new BaseObject[30];
            for (int i = 0; i < _objects.Length/2; i++)
                _objects[i] = new BaseObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));
            for (int i = 15; i < _objects.Length; i++)
                _objects[i] = new Star(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20),Brushes.Blue);

        }

        public static void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(background, Point.Empty);
            foreach (BaseObject baseObject in _objects)
            {
                //Star obj = baseObject as Star;
                //if (baseObject is Star) (baseObject as Star).Draw();//Wrong!
                baseObject.Draw();//Полиморфизм
            }
            Buffer.Render();
        }

        public static void Update()
        {            
            foreach (BaseObject baseObject in _objects)
                baseObject.Update();            
        }

    }
}
