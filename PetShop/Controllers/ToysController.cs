using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class ToysController : Controller
    {
        // GET: Toys
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Hamsters

        public ActionResult Index(int? id)
        {

            if (!id.HasValue)
            {

                List<Toy> toys = db.Toys.ToList();

                ViewBag.Toys = toys;

                return View();
            }
            else
            {
                Toy toy = db.Toys.Find(id);

                ViewBag.Toys = new List<Toy>() { toy };

                return View();
            }
        }

        [HttpGet]
        public ActionResult New()
        {
            Toy toy = new Toy();
            return View(toy);
        }

        [HttpPost]
        public ActionResult New(Toy newToy)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Toys.Add(newToy);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(newToy);
            }
            catch (Exception e)
            {
                return View(newToy);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                Toy toy = db.Toys.Find(id);

                if (toy == null)
                {
                    return HttpNotFound("Couldn't find the toy with id " + id.ToString());
                }
                return View(toy);
            }

            return HttpNotFound("Missing toy id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Toy toyRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Toy toy = db.Toys.Find(id);

                    if (TryUpdateModel(toy))
                    {
                        toy.ProductName = toyRequest.ProductName;
                        
                        toy.Hamster = toyRequest.Hamster;

                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(toyRequest);
            }
            catch (Exception e)
            {
                return View(toyRequest);
            }
        }


        public ActionResult Delete(int id)
        {
            Toy toy = db.Toys.Find(id);

            if (toy != null)
            {

                db.Toys.Remove(toy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the toy with id " + id.ToString());
        }
    }

}