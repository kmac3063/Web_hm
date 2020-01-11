using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using _6._4.Models;

namespace _6._4.Controllers
{
    public class HomeController : Controller
    {
        GameContext db;
        public HomeController(GameContext context)
        {
            db = context;
            if (db.Categories.Count() == 0)
            {
                var Shooter = new Category { Name = "Shooter"};
                var Horror = new Category { Name = "Horror"};

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(Shooter, Horror);
                    context.SaveChanges();
                }

                if (!context.Games.Any())
                {
                    context.Games.AddRange(
                        new Game { Name = "Doom", Release = 1995, Category = Shooter},
                        new Game { Name = "Doom 2", Release = 2000, Category = Shooter },
                        new Game { Name = "Doom 3", Release = 2007, Category = Shooter },
                        new Game { Name = "Doom 4", Release = 2019, Category = Shooter }
                    );
                    context.SaveChanges();
                }
            }
        }

        public IActionResult EagerLoadingIndex()
        {
            var orders = db.Games
                    .Include(x => x.Category)
                    .ToList();
            return View(orders.ToList());
        }

        public IActionResult ExplicitLoadingIndex()
        {
            db.Games.Load();
            db.Categories.Load();
            return View(db.Games.ToList());
        }

        public IActionResult LazyLoadingIndex()
        {
            var Games = db.Games.ToList();
            return View(db.Games.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
