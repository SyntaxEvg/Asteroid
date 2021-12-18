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


        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            speed = dir;
            Size = size;
        }


        public virtual void Draw()
        {

            //Game.Buffer.Graphics.DrawEllipse(Pens.DarkRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public  virtual void Update() //анимация
        {
            Pos.X += speed.X;
            Pos.Y += speed.Y;

            if (Pos.X <= 0 || Pos.X >= Game.Width) speed.X = -1 * speed.X;
            if (Pos.Y <= 0 || Pos.Y >= Game.Height) speed.Y = -1 * speed.Y;






            //Pos.X = Pos.Y + Dir.X;//новая позиция объекта по x
            //Pos.Y = Pos.Y + Dir.Y;//новая позиция объекта по y
            //if (Pos.X < 0 || Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0 || Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }


    }

    

}
