using Asteroid.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Asteroid
{
    class Program 
    {



        static void Main(string[] args)
        {
            Form SplashScreen = new Form();
            SplashScreen= StartForm.CreatForms(SplashScreen);//создание типовых форм
            SplashScreen.BackgroundImage = Resources.spac;                                             //
            new Menu().Init(SplashScreen);
            Application.Run(SplashScreen);






        }
    }
}
