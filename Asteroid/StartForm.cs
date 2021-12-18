using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroid
{
    static  class StartForm
    {
        public static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static Form CreatForms(Form Name)
        {
           Name.StartPosition = FormStartPosition.CenterScreen;
            Width= Name.Width = 800;
            Height= Name.Height = 600;
           Name.Text = "AsterBoom";
           Name.AutoSize = false;
           Name.MinimizeBox = false;
           Name.MinimumSize = new System.Drawing.Size(Name.Width, Name.Height = 600);
           Name.MaximumSize = new System.Drawing.Size(Name.Width, Name.Height = 600);
            return Name;
        }
        public static void GrafBuff(Form form)
        {
            
                Graphics g;
                _context = BufferedGraphicsManager.Current;
                // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
                Buffer = _context.Allocate(form.CreateGraphics(), new Rectangle(0, 0, form.ClientSize.Width, form.ClientSize.Height));
                Buffer.Graphics.DrawImage(Resources.spac, Point.Empty);
            
           
        }

    }
}
