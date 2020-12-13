using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetShop.DataAccessLayer;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class FishController : Controller
    {
        private DbCtx db = new DbCtx();
        // GET: Fish
        public ActionResult Fish()
        {
            List<Fish> fish = db.Fish.ToList();
            ViewBag.Fish = fish;
            return View();
        }
    }
}