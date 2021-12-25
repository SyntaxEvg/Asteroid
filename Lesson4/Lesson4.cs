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
            Point[] points = { new Point(100, 200),
            new Point(150, 250), new Point(250, 375),
            new Point(275, 395), new Point(295, 450) };

            // Find the first Point structure for which X times Y
            // is greater than 100000.
            Point first = Array.Find(points, ProductGT10);

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
            //а) Свернуть обращение к OrderBy с использованием лямбда - выражения $.
            var Collapsed = dict.OrderBy(pair=> { return pair.Value; });

            //б) *Развернуть обращение к OrderBy с использованием делегата Predicate<T>.
           
            Func<KeyValuePair<string, int>, int> predicate = myMethod;
            d = dict.OrderBy(predicate);

            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }


            Console.WriteLine("Hello World!");
        }
        //static bool PredBool(string Value)
        //{
        //    return pair.Value;
        //}
        int PredicatB(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }
    }
}
