using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using hm_4.Models;

namespace hm_4.Controllers
{
    public class ModeratorsMenuController : Controller
    {
        MenuContext db;
        public ModeratorsMenuController(MenuContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Moderators(string searchStr)
        {
            var moderators = from i in db.ModeratorList select i;
            if (!String.IsNullOrEmpty(searchStr))
            {
                moderators = moderators.Where(
                    s => s.FirstName.Contains(searchStr) || s.SecondName.Contains(searchStr));
            }
            return View(await moderators.ToListAsync());
        }

        public IActionResult InfoMod(int? id)
        {
            if (id == null) return RedirectToAction("Moderators");
            var moderator = db.ModeratorList.Find(id);
            if (moderator == null)
                return NotFound();
            return View(moderator);
        }

        [HttpGet]
        public ActionResult AddMod()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMod(Moderator moderator)
        {
            if (db.ModeratorList.Contains(moderator))
            {
                return BadRequest();
            }
            db.ModeratorList.Add(moderator);
            db.SaveChanges();

            return RedirectToAction("Moderators");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Moderator mod = db.ModeratorList.Find(id);
            if (mod != null)
            {
                return View(mod);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Edit(Moderator mod)
        {
            db.Entry(mod).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Moderators");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Moderator mod = db.ModeratorList.Find(id);
            if (mod == null)
                return NotFound();

            return View(mod);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Moderator mod = db.ModeratorList.Find(id);
            if (mod == null)
            {
                return NotFound();
            }
            db.ModeratorList.Remove(mod);
            db.SaveChanges();

            return RedirectToAction("Moderators");
        }
    }
}
