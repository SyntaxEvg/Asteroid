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


        public static void CreatForms(Form Name)
        {
           Name.StartPosition = FormStartPosition.CenterScreen;
           Name.Width = 800;
           Name.Height = 600;
           Name.Text = "AsterBoom";
           Name.AutoSize = false;
           Name.MinimizeBox = false;
           Name.MinimumSize = new System.Drawing.Size(Name.Width, Name.Height = 600);
           Name.MaximumSize = new System.Drawing.Size(Name.Width, Name.Height = 600);
        }
        public static void GrafBuff(Form form)
        {
            if (_context == null && Buffer == null)
            {
                Graphics g;
                _context = BufferedGraphicsManager.Current;
                g = form.CreateGraphics();
                // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
                Buffer = _context.Allocate(g, new Rectangle(0, 0, form.ClientSize.Width, form.ClientSize.Height));
            }
           
        }

    }
}
