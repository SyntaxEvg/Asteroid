using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroid
{
    public abstract class BaseObject :ICollision
    {

        protected Point Pos;

        protected Point speed;// скорость движения объекта 

        protected Size Size; //размер объекта


        //public Rectangle Rectangle { get; set; }  => new Rectangle(Posic, Sizes);              
        
        public Point Posic
        {
            get { return Pos; }
            set { Pos = value; }
        }
        public Point Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public Size Sizes
        {
            get { return Size; }
            set { Size = value; }
        }

        public Rectangle rectengle => new Rectangle(Posic, Sizes);

        public bool Collision(ICollision collision)
        {
            return collision.rectengle.IntersectsWith(this.rectengle);
        }
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            speed = dir;
            Size = size;
        }


        public virtual void Draw()
        {
        }

        public  virtual void Update(bool fals) //анимация
        {
            Pos.X += speed.X;
            Pos.Y += speed.Y;

            if (Pos.X <= 0 || Pos.X >= StartForm.Width) speed.X = -1 * speed.X;
            if (Pos.Y <= 0 || Pos.Y >= StartForm.Height) speed.Y = -1 * speed.Y;






            //Pos.X = Pos.Y + Dir.X;//новая позиция объекта по x
            //Pos.Y = Pos.Y + Dir.Y;//новая позиция объекта по y
            //if (Pos.X < 0 || Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0 || Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }

      
    }

    

}
