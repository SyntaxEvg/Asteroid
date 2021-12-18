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
        Bitmap Ast = new Bitmap(Resources.Ast);
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
       
        public override void Draw()
        {
            Bitmap Aster = new Bitmap(Ast, new Size(Size.Width, Size.Height));
            StartForm.Buffer.Graphics.DrawImage(Aster, Pos.X, Pos.Y);
        }

        public override void Update(bool knock_down)
        {
            

            if (Posic.X <= 0 || knock_down) //если был  удар нулим 
            {
                var s = Game.Rand.Next(10, 47);
                var t = Game.Rand.Next(1, 30) * Game.Rand.Next(1, 30);
                var pos = new Point(StartForm.Width, t + s);
                var speed = new Point(Game.Rand.Next(5, 20), 0);
                var size = new Size(s, s);
                 Posic = pos;
                 Speed = speed;
                 Sizes = size;
            }

            Pos.X = Pos.X - speed.X;
            Pos.Y = Pos.Y - speed.Y;
            
            //if (Pos.X < 0) Cкорость.X = -Cкорость.X;
            //if (Pos.X > Game.Width) Cкорость.X = -Cкорость.X;
            //if (Pos.Y < 0) Cкорость.Y = -Cкорость.Y;
            //if (Pos.Y > Game.Height) Cкорость.Y = -Cкорость.Y;
        }
    }
}
