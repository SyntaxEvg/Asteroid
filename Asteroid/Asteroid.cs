using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid
{
    public class Asteroid : BaseObject
    {
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.DarkRed, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.Ast, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Cкорость.X;
            Pos.Y = Pos.Y - Cкорость.Y;
            
            //if (Pos.X < 0) Cкорость.X = -Cкорость.X;
            //if (Pos.X > Game.Width) Cкорость.X = -Cкорость.X;
            //if (Pos.Y < 0) Cкорость.Y = -Cкорость.Y;
            //if (Pos.Y > Game.Height) Cкорость.Y = -Cкорость.Y;
        }
    }
}
