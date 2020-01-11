using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using hm_5.Models;
using hm_5.ViewModels;

namespace hm_5.Controllers
{
    public class HomeController : Controller
    {
        const int NUMB_PAGES = 6;

        GameContext db;
        public HomeController(GameContext context)
        {
            db = context;

            if (db.Categories.Count() == 0)
            {
                var horror = new Category {Name = "Horror" };
                var shooter = new Category {Name = "Shooter" };
                var idle = new Category {Name = "Idle" };
                var racing = new Category {Name = "Racing" };

                var dt = DateTime.Now;

                db.Games.AddRange
                (
                    new Game {Name = "Cookie Clicker", Category = idle, Release = 2013, CreationDate = dt},
                    new Game {Name = "Doom 3", Category = shooter, Release = 2005, CreationDate = dt },
                    new Game {Name = "NFS World", Category = racing, Release = 2010, CreationDate = dt },
                    new Game {Name = "Amnesia", Category = horror, Release = 2016, CreationDate = dt }
                );

                db.Categories.AddRange(horror, shooter, idle, racing);

                db.SaveChanges();
            }
        }

        public async Task<IActionResult> Index(int? categoryId, string? name, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {

            IQueryable<Game> games = db.Games.Include(x => x.Category);
            

            if (categoryId != null && categoryId > 0)
            {
                games = games.Where(
                    g => g.Category.Id == categoryId);
            }
            
            if (!String.IsNullOrEmpty(name))
            {
                name = name.ToLower();
                games = games.Where(
                    g => g.Name.ToLower().Contains(name)
                );
            }

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    games = games.OrderByDescending(s => s.Name);
                    break;
                case SortState.RelAsc:
                    games = games.OrderBy(s => s.Release);
                    break;
                case SortState.RelDesc:
                    games = games.OrderByDescending(s => s.Release);
                    break;
                case SortState.CatAsc:
                    games = games.OrderBy(s => s.Category.Name);
                    break;
                case SortState.CatDesc:
                    games = games.OrderByDescending(s => s.Category.Name);
                    break;
                default:
                    games = games.OrderBy(s => s.Name);
                    break;
            }

            // пагинация
            var count = await games.CountAsync();
            var items = await games.Skip((page - 1) * NUMB_PAGES).Take(NUMB_PAGES).ToListAsync();


            IndexViewModel indexVM = new IndexViewModel {
                PageViewModel = new PageViewModel(count, page, NUMB_PAGES),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Categories.ToList(), categoryId, name),
                Games = items
            };


            return View(indexVM);
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();    
        }

        [HttpPost]
        public IActionResult Add(Game game)
        {
            if (db.Games.Contains(game))
                return BadRequest();

            bool t = false;
            foreach (var c in db.Categories)
            {
                if (c.Name == game.Category.Name)
                {
                    game.Category = c;
                    t = true;
                }
            }

            //var x = db.Categories.FirstOrDefault(x => x.Name == game.Category.Name);

            if (!t)
                db.Categories.Add(game.Category);
            
            game.CreationDate = DateTime.Now;
            db.Games.Add(game);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
