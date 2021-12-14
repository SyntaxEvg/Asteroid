using System;
using System.Windows.Forms;


namespace Asteroid
{


 

    class Program
    {
        static void Main(string[] args)
        {

            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.Show();
            Game.Init(form);
            Game.Draw();
            Application.Run(form);

        }
    }
}
