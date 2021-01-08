using System;
using PetShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Locations
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<Location> locations = db.Locations.ToList();
            List<Address> addresses = db.Addresses.ToList();
            ViewBag.Locations = locations;
            return View();
        }


        [HttpGet]
        public ActionResult New()
        {
            Location location = new Location();
            return View(location);
        }

        [HttpPost]
        public ActionResult New(Location newLocation)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Locations.Add(newLocation);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(newLocation);
            }
            catch (Exception e)
            {
                return View(newLocation);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                Location location = db.Locations.Find(id);

                if (location == null)
                {
                    return HttpNotFound("Couldn't find the location with id " + id.ToString());
                }
                return View(location);
            }

            return HttpNotFound("Missing location id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, Location locationRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Location location = db.Locations.Find(id);

                    if (TryUpdateModel(location))
                    {
                        location.LocationType = locationRequest.LocationType;
                        

                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(locationRequest);
            }
            catch (Exception e)
            {
                return View(locationRequest);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Location location = db.Locations.Find(id);
                ViewBag.Locations = new List<Location>() { location };

                List<Address> addresses = db.Addresses.ToList();
                ViewBag.Addresses = addresses;

                if (location != null)
                {
                    return View(location);
                }
                return HttpNotFound("Couldn't find the location with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing location id parameter!");
        }

        public ActionResult Delete(int id)
        {
            Location location = db.Locations.Find(id);

            if (location != null)
            {

                db.Locations.Remove(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound("Couldn't find the location with id " + id.ToString());
        }
    }
}