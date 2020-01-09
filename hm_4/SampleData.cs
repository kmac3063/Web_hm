using System.Linq;
using hm_4.Models;

namespace hm_4
{
    public static class SampleData
    {
        public static void Initialize(MenuContext context)
        {
            if (!context.AdminList.Any())
            {
                context.AdminList.AddRange(
                new Admin
                {
                    FirstName = "John",
                    SecondName = "Rich",
                    Age = 32,
                    City = "Moskow"
                },
                new Admin
                {
                    FirstName = "Alexaus",
                    SecondName = "Pokirov",
                    Age = 48,
                    City = "New York"
                },
                new Admin
                {
                    FirstName = "Micha",
                    SecondName = "Korica",
                    Age = 21,
                    City = "Paris"
                }
                );
                context.SaveChanges();
            }

            if (!context.ModeratorList.Any())
            {
                context.ModeratorList.AddRange(
                new Moderator
                {
                    FirstName = "Rahn",
                    SecondName = "Gran",
                    Age = 42,
                    Experience = 3
                },
                new Moderator
                {
                    FirstName = "Elwis",
                    SecondName = "Presley",
                    Age = 25,
                    Experience = 0
                },
                new Moderator
                {
                    FirstName = "Alexey",
                    SecondName = "Verholat",
                    Age = 32,
                    Experience = 1
                },
                new Moderator
                {
                    FirstName = "Hew",
                    SecondName = "Potter",
                    Age = 43,
                    Experience = 25
                }
                );

            context.SaveChanges();
            }
        }
    }
}