using Asteroid.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid.SERVICE
{
    public static class SaveResults
    {
        static string Puth = "Result.json";
        private static void writeFile(List<Result> list)
        {
            list = list.OrderBy(x => x.Count).ToList();//сортируем  сразу по  Кол-ву сбитых 
            try
            {
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(Puth, JsonConvert.SerializeObject(list));
            }
            catch (Exception)
            {
            }

        }


        private static void SaveResult()
        {
            var write = new Result()
            {
                Name = Game.NameUser,
                Time = Game.TimerGame.Text,
                Count = Game.count

            };


            List<Result> list = new List<Result>();
            list.Add(write);
            if (File.Exists(Puth))
            {
                try
                {
                    //не знаю  кк дописывать всегда делаю так, если умеете ,научите меня
                    using (StreamReader file = File.OpenText(Puth))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        var massResult = (List<Result>)serializer.Deserialize(file, typeof(List<Result>));
                        list.AddRange(massResult);
                    }
                    writeFile(list);

                }
                catch (Exception)
                {
                    //или файл открыт уже где то...
                    //не json
                }
            }
            else
            {
                writeFile(list);
            }
        }
        public  static void StopGame()
        {
            Game.timer.Stop();//
            SaveResult();//пишем результат 
           
            Game.count = 0;//обноляем сбитых
            Menu._SplashScreen.Show();




        }


        internal static List<Result> Deserialize(List<Result> list)
        {
            if (File.Exists(Puth))
            {
                try
                {

                    using (StreamReader file = File.OpenText(Puth))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        var massResult = (List<Result>)serializer.Deserialize(file, typeof(List<Result>));
                        list.AddRange(massResult);
                    }

                }
                catch (Exception)
                {
                    //или файл открыт уже где то...
                    //не json
                }
            }
            return list;
        }
    }
}
