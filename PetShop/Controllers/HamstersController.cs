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
            List<Breed> breeds = db.Breeds.ToList();
            List<Food> food = db.Food.ToList();
            
            ViewBag.Hamsters = hamsters;
            ViewBag.Breeds =  breeds;
            ViewBag.Food = food;

            return View();
        }
        [HttpGet]
        public ActionResult New()
        {
            Hamster hamster = new Hamster();
            hamster.BreedSizeList = GetAllSizes();
            hamster.BreedColorList = GetAllColors();
            return View(hamster);
        }

        [HttpPost]
        public ActionResult New(Hamster newHamster)
        {
            newHamster.BreedSizeList = GetAllSizes();
            newHamster.BreedColorList = GetAllColors();
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
                hamster.BreedSizeList = GetAllSizes();
                hamster.BreedColorList = GetAllColors();
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
                        .Include("Breed")
                        .SingleOrDefault(b => b.Id.Equals(id));
                    if (TryUpdateModel(hamster))
                    {
                        hamster.Breed = hamsterRequest.Breed;
                        hamster.HasCage = hamsterRequest.HasCage;
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

        [NonAction]
        public IEnumerable<SelectListItem> GetAllSizes()
        {
            var selectList = new List<SelectListItem>();

                selectList.Add(new SelectListItem
                {
                    Value = "Small",
                    Text = "Small"
                });

            selectList.Add(new SelectListItem
            {
                Value = "Medium",
                Text = "Medium"
            });

            selectList.Add(new SelectListItem
            {
                Value = "Large",
                Text = "Large"
            });
            return selectList;
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllColors()
        {
            var selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem
            {
                Value = "Brown",
                Text = "Brown"
            });

            selectList.Add(new SelectListItem
            {
                Value = "White",
                Text = "White"
            });

            selectList.Add(new SelectListItem
            {
                Value = "Black",
                Text = "Black"
            });

            selectList.Add(new SelectListItem
            {
                Value = "Gray",
                Text = "Gray"
            });
            return selectList;
        }
    }
    // TODO: Implement CRUD also for one-to-many and many-to-many(lab4)
}