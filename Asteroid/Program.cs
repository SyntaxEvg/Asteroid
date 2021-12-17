using System;
using System.Windows.Forms;


namespace Asteroid
{
    class Program
    {



        static void Main(string[] args)
        {
            //Form Заставка = new Form();
            //Заставка.StartPosition = FormStartPosition.CenterScreen;
            //Заставка.Width = 800;
            //Заставка.Height = 600;
            //Заставка.Text = "AsterBoom";
            //Заставка.Show();
            //Заставка.AutoSize = false;
            //Заставка.MinimizeBox = false;
            //Заставка.MinimumSize = new System.Drawing.Size(Заставка.Width, Заставка.Height = 600);
            //Заставка.MaximumSize = new System.Drawing.Size(Заставка.Width, Заставка.Height = 600);
            //Application.Run(Заставка);


            Form form = new Form();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Width = 800;
            form.Height = 600;
            form.Text = "AsterBoom";
            form.Show();
            form.AutoSize = false;
            form.MinimizeBox = false;
            form.MinimumSize = new System.Drawing.Size(form.Width, form.Height = 600);
            form.MaximumSize = new System.Drawing.Size(form.Width, form.Height = 600);
            Game.Init(form);
            //Game.Draw();
            Application.Run(form);

        }
    }
}
