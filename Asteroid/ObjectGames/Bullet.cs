using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid
{
    class Bullet : BaseObject
    {

        Bitmap bullet = new Bitmap(Resources.bullets1);
        

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public Rectangle rectengle => new Rectangle(Posic, Sizes);

        public bool Collision(ICollision collision)
        {
            return collision.rectengle.IntersectsWith(this.rectengle);
        }

        public override void Draw()
        {
            Bitmap bullets = new Bitmap(bullet, new Size(Size.Width, Size.Height));
            StartForm.Buffer.Graphics.DrawImage(bullets, Pos.X, Pos.Y);
        }

        public override void Update(bool Bax)//если сбил запускаем пулю  по-новому
        {
            if (Bax)
            {
                //var y =new Random().Next(10, 350);
                //Pos.X = 0;
                //Pos.Y = y;
                return;
            }

            Pos.X = Pos.X + Speed.X;
            if (Pos.X > StartForm.Width)
            {
                 Game.bull=null;
                return ;
            }
        }

    }
}
