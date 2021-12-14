using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroid
{
    class BaseObject
    {

        protected Point Pos;

        protected Point Dir;

        protected Size Size; 

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }


        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public void Update()
        {
            Pos.X = Pos.Y + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0 || Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0 || Pos.Y > Game.Height) Dir.Y = -Dir.Y;
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
            Dir = dir;
            Size = size;
            if (brush!=null)
                Brush = brush;
        }

        public override void Draw()
        {
            //Game.Buffer.Graphics.FillEllipse(Brush, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(Image, Pos);
        }
    }

}
