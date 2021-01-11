using System;
using PetShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class BreedsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                List<Breed> breeds = db.Breeds.ToList();
                ViewBag.Breeds = breeds;
                return View();
            }
            else
            {
                Breed breeds = db.Breeds.Find(id);
                ViewBag.breeds = new List<Breed>() { breeds };
                return View();
            }

        }


        [HttpGet]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult New()
        {
            Breed breed = new Breed();
            breed.BreedSizeList = GetAllSizes();
            breed.BreedColorList = GetAllColors();
            return View(breed);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult New(Breed newBreed, HttpPostedFileBase image2)
        {
            newBreed.BreedSizeList = GetAllSizes();
            newBreed.BreedColorList = GetAllColors();

            if (image2 != null)
            {
                newBreed.Image = new byte[image2.ContentLength];
                image2.InputStream.Read(newBreed.Image, 0, image2.ContentLength);
            }

            try
            {
                if (ModelState.IsValid)
                {

                    db.Breeds.Add(newBreed);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(newBreed);
            }
            catch (Exception e)
            {
                return View(newBreed);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                Breed breed = db.Breeds.Find(id);
                breed.BreedSizeList = GetAllSizes();
                breed.BreedColorList = GetAllColors();
                if (breed == null)
                {
                    return HttpNotFound("Couldn't find the hamster with id " + id.ToString());
                }
                return View(breed);
            }

            return HttpNotFound("Missing hamster id parameter!");
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit(int id, Breed breedRequest, HttpPostedFileBase image2)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Breed breed = db.Breeds
                        .Find(id);
                    if (TryUpdateModel(breed))
                    {
                        breed.Color = breedRequest.Color;
                        breed.Size = breedRequest.Size;
                        breed.Name = breedRequest.Name;
                        
                        if (image2 != null)
                        {
                            breed.Image = new byte[image2.ContentLength];
                            image2.InputStream.Read(breed.Image, 0, image2.ContentLength);
                        }
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(breedRequest);
            }
            catch (Exception e)
            {
                return View(breedRequest);
            }
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Breed breed = db.Breeds.Find(id);

            if (breed != null)
            {
                // for (int i = 0; i < hamster.Toys.Count(); i++)
                // {
                //     Toy toy = db.Toys.Find(hamster.Toys[i].Id);
                //     db.Toys.Remove(toy);
                // }
                db.Breeds.Remove(breed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the breed with id " + id.ToString());
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