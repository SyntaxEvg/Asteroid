using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid
{

    //ИНКАПСУЛЯЦИЯ
    class Time
    {
        //ПОЛЯ (Fields)
        private int hour;
        private int minute;
        private int second;

        //методы для доступа к полям
        public void SetHour(int value)
        {
            if (value >= 0 && value <= 23) hour = value;
            else throw new ArgumentOutOfRangeException("Час не правильный");
        }


        public int GetHour()
        {
            return hour;
        }

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value >= 0 && value <= 23) hour = value;
                else throw new ArgumentOutOfRangeException("Час не правильный");
            }
        }

        public Time(int hour,int minute,int second) 
        {
            
            if (hour >= 0 && hour <= 23) this.hour = hour;
                else throw new ArgumentOutOfRangeException("Час не правильный");
            this.minute = minute;
            this.second = second;
        }




    }


    class Date
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {

            //DateTime dateTime = new DateTime(-1, -1, 1);
            Time time;
            //time.SetHour(100);
            //time.Hour = 100;
            time.GetHour();

        }
    }
}
