using System;
using System.Windows.Forms;


namespace Asteroid
{
    class Program 
    {



        static void Main(string[] args)
        {
            Form SplashScreen = new Form();
            StartForm.CreatForms(SplashScreen);//создание типовых форм           
            new Menu().Init(SplashScreen);
            Application.Run(SplashScreen);

           


            

        }
    }
}
