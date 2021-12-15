using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroid
{
    public abstract class BaseObject
    {

        protected Point Pos;

        protected Point Cкорость;// скорость движения объекта 

        protected Size Size; //размер объекта

        
        public Point Posic
        {
            get { return Pos; }
            set { Pos = value; }
        }
        public Point Speed
        {
            get { return Cкорость; }
            set { Cкорость = value; }
        }
        public Size Sizes
        {
            get { return Size; }
            set { Size = value; }
        }


        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Cкорость = dir;
            Size = size;
        }


        public virtual void Draw()
        {

            //Game.Buffer.Graphics.DrawEllipse(Pens.DarkRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public  virtual void Update() //анимация
        {
            Pos.X += Cкорость.X;
            Pos.Y += Cкорость.Y;

            if (Pos.X <= 0 || Pos.X >= Game.Width) Cкорость.X = -1 * Cкорость.X;
            if (Pos.Y <= 0 || Pos.Y >= Game.Height) Cкорость.Y = -1 * Cкорость.Y;






            //Pos.X = Pos.Y + Dir.X;//новая позиция объекта по x
            //Pos.Y = Pos.Y + Dir.Y;//новая позиция объекта по y
            //if (Pos.X < 0 || Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0 || Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }


    }

    class Star : BaseObject
    {
        System.Drawing.Brush Brush=Brushes.Red;
        static System.Drawing.Image Image { get; } = Image.FromFile("Images/star.png");

        public Star():base(pos:new Point(),size:new Size(), dir: new Point())
        {

        }

        public Star(Point pos, Point dir, Size size, Brush brush=null):base(pos,dir,size)
        {
            Pos = pos;
            Cкорость = dir;
            Size = size;
            if (brush!=null)
                Brush = brush;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }
        public override void Update()
        {
            base.Update();
        }
    }

}
