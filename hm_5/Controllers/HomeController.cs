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

        public IActionResult Index(int? categoryId)
        {
            List<CategoryModel> catModels = db.Categories.Select(
                 c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();

            IQueryable<Game> games = db.Games.Include(x => x.Category);

            catModels.Insert(0, new CategoryModel { Id = 0, Name = "Any" });
 
            IndexViewModel indexVM = new IndexViewModel { Categories = catModels, Games = games };

            if (categoryId != null && categoryId > 0)
            {
                indexVM.Games = games.Where(c => c.Category.Id == categoryId);
            }

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

            if (!t)
                db.Categories.Add(game.Category);
            
            game.CreationDate = DateTime.Now;
            db.Games.Add(game);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
