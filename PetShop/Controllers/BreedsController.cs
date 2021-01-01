﻿using PetShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class BreedsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Fish
        public ActionResult Breed()
        {
            List<Breed> breeds = db.Breeds.ToList();
            ViewBag.Breeds = breeds;
            return PartialView("_Breed");

        }
    }
}