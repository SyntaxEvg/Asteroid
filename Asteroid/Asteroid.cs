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
        Bitmap Ast = new Bitmap(Resources.Ast);
        public override void Draw()
        {
            Bitmap Aster = new Bitmap(Ast, new Size(Size.Width, Size.Height));
            Game.Buffer.Graphics.DrawImage(Aster, Pos.X, Pos.Y);
        }

        public override void Update()
        {
            if (Posic.X <= 0 )
            {
                var s = Game.Rand.Next(10, 47);
                var t = Game.Rand.Next(1, 30) * Game.Rand.Next(1, 30);
                var pos = new Point(Game.Width, t + s);
                var Скорость = new Point(Game.Rand.Next(5, 20), 0);
                var size = new Size(s, s);
                 Posic = pos;
                 Speed = Скорость;
                 Sizes = size;
            }



            Pos.X = Pos.X - Cкорость.X;
            Pos.Y = Pos.Y - Cкорость.Y;
            
            //if (Pos.X < 0) Cкорость.X = -Cкорость.X;
            //if (Pos.X > Game.Width) Cкорость.X = -Cкорость.X;
            //if (Pos.Y < 0) Cкорость.Y = -Cкорость.Y;
            //if (Pos.Y > Game.Height) Cкорость.Y = -Cкорость.Y;
        }
    }
}
