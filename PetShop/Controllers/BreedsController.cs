using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetShop.DataAccessLayer;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class BreedsController : Controller
    {
        private DbCtx db = new DbCtx();
        // GET: Fish
        public ActionResult Breed()
        {
            List<Breed> breeds = db.Breeds.ToList();
                ViewBag.Breeds = breeds;
                return PartialView("_Breed");
            
        }
    }
}