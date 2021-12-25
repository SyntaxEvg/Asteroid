using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Lesson4
{
    internal class Program
    {
        static Dictionary<string, int> dict = new Dictionary<string, int>();


        //      а) Свернуть обращение к OrderBy с использованием лямбда-выражения $.
        //      б) *Развернуть обращение к OrderBy с использованием делегата Predicate<T>.

        static void Main(string[] args)
        {
           

            // Display the first structure found.
            Console.WriteLine("Found: X = {0}, Y = {1}", first.X, first.Y);



            //это запускать не надо
            dict = new Dictionary<string, int>()
            {
              {"four",4 },
              {"two",2 },
              { "one",1 },
              {"three",3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            // в язык запросов
            var d1 = from item in dict orderby item.Value select item;
            var dList = d1.ToList();
            //а) Свернуть обращение к OrderBy с использованием лямбда - выражения.
            var Collapsed = dict.OrderBy(pair=> { return pair.Value; });

            //б) *Развернуть обращение к OrderBy с использованием делегата
            d = dict.OrderBy(PredicatB);

            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
       
       static int PredicatB(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }
    }
}
