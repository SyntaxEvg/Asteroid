using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid.ObjectGames
{
    internal class Ship : BaseObject
    {
        public  event EventHandler EventDia=null;
         
        protected int liveShip = 100;

        public int LiveShip { get { return liveShip; } }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public void UP()
        {
            Pos.Y=  Pos.Y> 0 ? Pos.Y - speed.Y : Pos.Y;
        }
        public void Down()
        {
            Pos.Y = Pos.Y < StartForm.Height -Size.Height-40 ? Pos.Y + speed.Y : Pos.Y;
        }
        public void Left()
        {
            if (Pos.X > 0 && Pos.X >= 10 && Pos.Y < StartForm.Height - Size.Height)
            {
                Pos.X-=speed.X;
            }
        }
        public void Right()
        {
            if (Pos.X > 0 && Pos.X <= StartForm.Width-40 && Pos.Y < StartForm.Height - Size.Height)
            {
                Pos.X += speed.X;
            }
        }
        public override void Update(bool fals)
        {
           // base.Update(fals);
        }

        Bitmap ship = new Bitmap(Resources.ship);
        public override void Draw()
        {
            Bitmap _ship = new Bitmap(ship, new Size(Size.Width, Size.Height));
            StartForm.Buffer.Graphics.DrawImage(_ship, Pos.X, Pos.Y);
        }

        public void Dia()//событие на смерть коробля подписка будет  в game
        {
            EventDia?.Invoke(this, EventArgs.Empty);    
        }


        internal bool Loss(int v)
        {
            
            liveShip = liveShip - v;
            if (liveShip <= 0)
            {
                
                return true;
                //убит  закончить игру
            }
            return false;
        }
    }
}
