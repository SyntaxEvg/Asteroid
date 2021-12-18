using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid
{
    class Star : BaseObject
    {
        System.Drawing.Brush Brush = Brushes.Red;
        static System.Drawing.Image Image { get; } = Image.FromFile("Images/star.png");

        public Star() : base(pos: new Point(), size: new Size(), dir: new Point())
        {

        }

        public Star(Point pos, Point dir, Size size, Brush brush = null) : base(pos, dir, size)
        {
            Pos = pos;
            speed = dir;
            Size = size;
            if (brush != null)
                Brush = brush;
        }

        public override void Draw()
        {
            StartForm.Buffer.Graphics.DrawImage(Image, Pos);
        }
        public override void Update(bool knock)
        {
            base.Update(knock);
        }
    }
}
