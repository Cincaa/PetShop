using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetShop.DataAccessLayer;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Locations
        private DbCtx db = new DbCtx();

        public ActionResult Location()
        {
            List<Location> locations = db.Locations.ToList();
            ViewBag.Locations = locations;
            return View();
        }

    }
}