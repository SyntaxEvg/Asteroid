using System;
using System.Windows.Forms;


namespace Asteroid
{
    class Program
    {
        static void Main(string[] args)
        {

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
