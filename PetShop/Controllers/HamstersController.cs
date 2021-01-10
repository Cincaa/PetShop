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


        [AllowAnonymous]
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
        [Authorize(Roles = "Admin, Editor")]
        [HttpGet]
        public ActionResult New()
        {
            Hamster hamster = new Hamster();
            hamster.BreedSizeList = GetAllSizes();
            hamster.BreedColorList = GetAllColors();
            hamster.ToysList = GetAllToys();
            hamster.FoodList = GetAllFood();
            hamster.Food = new List<Food>();
            return View(hamster);
        }
        [Authorize(Roles = "Admin, Editor")]
        [HttpPost]
        public ActionResult New(Hamster newHamster, HttpPostedFileBase image1)
        {
            newHamster.BreedSizeList = GetAllSizes();
            newHamster.BreedColorList = GetAllColors();
            newHamster.ToysList = GetAllToys();

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
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                Hamster hamster = db.Hamsters.Find(id);
                hamster.BreedSizeList = GetAllSizes();
                hamster.BreedColorList = GetAllColors();
                hamster.FoodList = GetAllFood();

                foreach (Food checkedFood in hamster.Food)
                {   
                    // iteram prin genurile care erau atribuite cartii inainte de momentul accesarii formularului
                    // si le selectam/bifam  in lista de checkbox-uri
                    hamster.FoodList.FirstOrDefault(g => g.Id == checkedFood.Id).Checked = true;
                }

                if (hamster == null)
                {
                    return HttpNotFound("Couldn't find the hamster with id " + id.ToString());
                }
                return View(hamster);
            }

            return HttpNotFound("Missing hamster id parameter!");
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Editor")]
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


        [Authorize(Roles = "Admin")]
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
        [AllowAnonymous]
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

        [NonAction]
        public IEnumerable<SelectListItem> GetAllToys()
        {
            var selectList = new List<SelectListItem>();
            foreach (var toy in db.Toys.ToList())
            {
                if(toy.ProductName != null)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = toy.ProductName,
                        Text = toy.ProductName
                    });
                }
            }
            return selectList;
        }
        [NonAction]
        public List<CheckBoxViewModel> GetAllFood()
        {
            var checkboxList = new List<CheckBoxViewModel>();
            foreach (var food in db.Food.ToList())
            {
                checkboxList.Add(new CheckBoxViewModel
                {
                    Id = food.Id,
                    Name = food.ProductName,
                    Checked = false
                });
            }
            return checkboxList;
        }
    }
}