using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class FoodController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Hamsters

        public ActionResult Index(int? id)
        {

            if (!id.HasValue)
            {
                
                List<Food> food = db.Food.ToList();

                ViewBag.Food = food;

                return View();
            }
            else
            {
                Food food = db.Food.Find(id);

                ViewBag.Food = new List<Food>() {food};

                return View();
            }
        }

        [HttpGet]
        public ActionResult New()
        {
            Food food = new Food();
            return View(food);
        }

        [HttpPost]
        public ActionResult New(Food newFood)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Food.Add(newFood);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(newFood);
            }
            catch (Exception e)
            {
                return View(newFood);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                Food food = db.Food.Find(id);
                
                if (food == null)
                {
                    return HttpNotFound("Couldn't find the hamster with id " + id.ToString());
                }
                return View(food);
            }

            return HttpNotFound("Missing hamster id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Food foodRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Food food = db.Food.Find(id);
                        
                    if (TryUpdateModel(food))
                    {
                        food.ProductName = foodRequest.ProductName;
                        food.Diet = foodRequest.Diet;
                        food.Hamsters = foodRequest.Hamsters;
                        
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(foodRequest);
            }
            catch (Exception e)
            {
                return View(foodRequest);
            }
        }



        public ActionResult Delete(int id)
        {
            Food food = db.Food.Find(id);

            if (food != null)
            {
                
                db.Food.Remove(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the hamster with id " + id.ToString());
        }
    }
}