using System;
using System.Linq;

namespace _6._2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (GameContext db = new GameContext())
            {
                var games = db.Games.ToList();

                Console.WriteLine("Список игр:");
                foreach (var u in games)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Release}");
                }
            }

            Console.ReadKey();
        }
    }
}
