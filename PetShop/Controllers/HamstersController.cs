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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Hamster hamster = db.Hamsters.Find(id);
                if (hamster == null)
                {
                    return HttpNotFound("Couldn't find the hamster with id " + id.ToString());
                }
                return View(hamster);
            }
            return HttpNotFound("Missing hamster id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Hamster hamsterRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Hamster hamster = db.Hamsters
                        .Include("Cage")
                        .SingleOrDefault(b => b.Id.Equals(id));
                    if (TryUpdateModel(hamster))
                    {
                        hamster.Breed = hamsterRequest.Breed;
                        hamster.Cage = hamsterRequest.Cage;
                        hamster.Food = hamsterRequest.Food;
                        hamster.Toys = hamsterRequest.Toys;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Hamster");
                }
                return View(hamsterRequest);
            }
            catch (Exception e)
            {
                return View(hamsterRequest);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Hamster hamster = db.Hamsters.Find(id);
            if (hamster != null)
            {
                db.Hamsters.Remove(hamster);
                db.SaveChanges();
                return RedirectToAction("Hamster");
            }
            return HttpNotFound("Couldn't find the hamster with id " + id.ToString());
        }
    }
    // TODO: Implement CRUD also for one-to-many
}