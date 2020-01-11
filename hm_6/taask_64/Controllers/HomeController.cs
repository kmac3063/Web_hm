using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using taask_64.Models;

namespace taask_64.Controllers
{
    public class HomeController : Controller
    {
        PerfumeStoreContext db;
        public HomeController(PerfumeStoreContext context)
        {
            db = context;
            // добавляем начальные данные
            if (db.Brands.Count() == 0)
            {
                Brand Chanel = new Brand { Name = "Chanel", Country = "France" };
                Brand Armani = new Brand { Name = "Armani", Country = "Italy" };
                Brand Versace = new Brand { Name = "Versace", Country = "Italy" };
                Brand Givenchy = new Brand { Name = "Givenchy", Country = "France" };
                Brand Burberry = new Brand { Name = "Burberry", Country = "UK" };
                Brand Kenzo = new Brand { Name = "Kenzo", Country = "France" };
                Brand Lanvin = new Brand { Name = "Lanvin", Country = "France" };

                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(Chanel, Armani, Versace, Givenchy, Burberry, Kenzo, Lanvin);
                    context.SaveChanges();
                }

                if (!context.Perfumes.Any())
                {
                    context.Perfumes.AddRange(
                        new Perfume
                        {
                            Name = "Coco Mademoiselle",
                            Price = 6000,
                            Count = 10,
                            Volume = 30,
                            Brand = Chanel
                        },
                        new Perfume
                        {
                            Name = "Eclat d’Arpege",
                            Price = 1500,
                            Count = 50,
                            Volume = 50,
                            Brand = Lanvin
                        },
                        new Perfume
                        {
                            Name = "Acqua di Gioia",
                            Price = 4700,
                            Count = 15,
                            Volume = 50,
                            Brand = Armani
                        },
                        new Perfume
                        {
                            Name = "Bright Crystal",
                            Price = 4000,
                            Count = 10,
                            Volume = 50,
                            Brand = Versace
                        },
                        new Perfume
                        {
                            Name = "Very Irresistible",
                            Price = 4500,
                            Count = 15,
                            Volume = 50,
                            Brand = Givenchy
                        },
                        new Perfume
                        {
                            Name = "Chance Eau Tendre",
                            Price = 7400,
                            Count = 15,
                            Volume = 50,
                            Brand = Chanel
                        },
                        new Perfume
                        {
                            Name = "Body Tender",
                            Price = 2500,
                            Count = 15,
                            Volume = 60,
                            Brand = Burberry
                        },
                        new Perfume
                        {
                            Name = "L'eau par",
                            Price = 2400,
                            Count = 15,
                            Volume = 50,
                            Brand = Kenzo
                        }
                    );
                    context.SaveChanges();
                }
            }
        }

        public IActionResult EagerLoadingIndex()
        {
            var orders = db.Perfumes
                    .Include(x => x.Brand)
                    .ToList();
            return View(orders.ToList());
        }

        public IActionResult ExplicitLoadingIndex()
        {
            db.Perfumes.Load();
            db.Brands.Load();
            return View(db.Perfumes.ToList());
        }

        public IActionResult LazyLoadingIndex()
        {
            var perfumes = db.Perfumes.ToList();
            return View(db.Perfumes.ToList());
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
