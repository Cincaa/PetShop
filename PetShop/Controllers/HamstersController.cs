using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class HamstersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Hamsters

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        public ActionResult Index(int? id)
        {

            if (!id.HasValue)
            {
                List<Hamster> hamsters = db.Hamsters.ToList();
                List<Breed> breeds = db.Breeds.ToList();
                List<Food> food = db.Food.ToList();

                ViewBag.Hamsters = hamsters;
                ViewBag.Breeds = breeds;
                ViewBag.Food = food;

                return View();
            }
            else
            {
                Hamster hamsters = db.Hamsters.Find(id);
                Breed breeds = db.Breeds.Find(hamsters.BreedId);
                List<Food> food = db.Food.ToList();

                ViewBag.Hamsters = new List<Hamster>() { hamsters };
                ViewBag.Breeds = breeds;
                ViewBag.Food = food;

                return View();
            }
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
        public ActionResult New(Hamster newHamster, HttpPostedFileBase image1)
        {
            newHamster.BreedSizeList = GetAllSizes();
            newHamster.BreedColorList = GetAllColors();

            if (image1 != null)
            {
                newHamster.Image = new byte[image1.ContentLength];
                newHamster.Breed.Image = new byte[image1.ContentLength];
                image1.InputStream.Read(newHamster.Image, 0, image1.ContentLength);
                newHamster.Breed.Image = newHamster.Image;
            }

            try
            {
                if (ModelState.IsValid)
                {

                    db.Hamsters.Add(newHamster);
                    db.SaveChanges();
                    return RedirectToAction("Index");
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
        public ActionResult Edit(int id, Hamster hamsterRequest, HttpPostedFileBase image1)
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
                        if (image1 != null)
                        {
                            hamster.Image = new byte[image1.ContentLength];
                            image1.InputStream.Read(hamster.Image, 0, image1.ContentLength);
                            hamster.Breed.Image = new byte[image1.ContentLength];
                            hamster.Breed.Image = hamster.Image;
                        }
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(hamsterRequest);
            }
            catch (Exception e)
            {
                return View(hamsterRequest);
            }
        }

        
        
        public ActionResult Delete(int id)
        {
            Hamster hamster = db.Hamsters.Find(id);
            
            if (hamster != null)
            {
                for (int i = 0; i < hamster.Toys.Count(); i++)
                {
                    Toy toy = db.Toys.Find(hamster.Toys[i].Id);
                    db.Toys.Remove(toy);
                }
                db.Hamsters.Remove(hamster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the hamster with id " + id.ToString());
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Hamster hamster = db.Hamsters.Find(id);
                List<Food> food = db.Food.ToList();
                ViewBag.Hamsters = new List<Hamster>() { hamster };
                ViewBag.Food = food;
                if (hamster != null)
                {
                    return View(hamster);
                }
                return HttpNotFound("Couldn't find the hamster with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing hamster id parameter!");
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
}