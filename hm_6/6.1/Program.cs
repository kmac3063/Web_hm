using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Game> Games= new List<Game>() {
                    new Game { Name = "Doom", Release = 1995},
                    new Game { Name = "Doom 2", Release = 2000},
                    new Game { Name = "Doom 3", Release = 2007},
                    new Game { Name = "Doom 4", Release = 2019},
                };


                // добавляем их в бд
                foreach(var g in Games)
                {
                    if (!db.Games.Contains(g))
                    {
                        db.Games.Add(g);
                    }
                }
                
                db.SaveChanges();
                Console.WriteLine("Игры успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var brands = db.Games.ToList();
                Console.WriteLine("Список игр:");
                foreach (var u in brands)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Release}");
                }
            }
            Console.Read();
        }
    }
}
