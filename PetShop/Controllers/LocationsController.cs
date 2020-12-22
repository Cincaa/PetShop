using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Locations
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Location()
        {
            List<Location> locations = db.Locations.ToList();
            ViewBag.Locations = locations;
            return View();
        }

    }
}