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
    public class AdminsMenuController : Controller
    {
        MenuContext db;
        public AdminsMenuController(MenuContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Admins(string searchStr)
        {
            var admins = from i in db.AdminList select i;
            if (!String.IsNullOrEmpty(searchStr))
            {
                admins = admins.Where(s => s.FirstName.Contains(searchStr) ||s.SecondName.Contains(searchStr));
            }
            return View(await admins.ToListAsync());
        }

        public IActionResult InfoAdm(int? id)
        {
            if (id == null) return RedirectToAction("Admins");
            var admin = db.AdminList.Find(id);
            if (admin == null)
                return NotFound();
            return View(admin);
        }


        [HttpGet]
        public ActionResult AddAdm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdm(Admin admin)
        {
            if (db.AdminList.Contains(admin))
            {
                return BadRequest();
            }
            db.AdminList.Add(admin);
            db.SaveChanges();

            return RedirectToAction("Admins");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            
            Admin adm = db.AdminList.Find(id);

            if (adm != null)
                return View(adm);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Edit(Admin adm)
        {
            db.Entry(adm).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Admins");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Admin adm = db.AdminList.Find(id);
            if (adm == null)
                return NotFound();

            return View(adm);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var adm = db.AdminList.Find(id);
            if (adm == null)
            {
                return NotFound();
            }
            db.AdminList.Remove(adm);
            db.SaveChanges();

            return RedirectToAction("Admins");
        }

    }
}
