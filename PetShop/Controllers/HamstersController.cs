using System;
using PetShop.DataAccessLayer;
using PetShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class HamstersController : Controller
    {
        private DbCtx db = new DbCtx();
        // GET: Hamsters

        public ActionResult Hamster()
        {
            List<Hamster> hamsters = db.Hamsters.ToList();
            List<Cage> cages = db.Cages.ToList();
            List<Food> food = db.Food.ToList();
            
            ViewBag.Hamsters = hamsters;
            ViewBag.Cages = cages;
            ViewBag.Food = food;

            return View();
        }
        [HttpGet]
        public ActionResult New()
        {
            Hamster hamster = new Hamster();
           
            return View(hamster);
        }

        [HttpPost]
        public ActionResult New(Hamster newHamster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // newHamster.Publisher = db.Publishers
                    //     .FirstOrDefault(p => p.PublisherId.Equals(1));
                    db.Hamsters.Add(newHamster);
                    db.SaveChanges();
                    return RedirectToAction("Hamster");
                }
                return View(newHamster);
            }
            catch (Exception e)
            {
                return View(newHamster);
            }
        }

    }
    // TODO: Implement CRUD 
}