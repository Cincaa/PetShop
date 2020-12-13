using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class HamstersController : Controller
    {
        private DbCtx db = new DbCtx();
        // GET: Hamsters

        public ActionResult Hamster()
        {
            List<Hamster> hamsters = db.Hamsters.ToList();
            ViewBag.Hamsters = hamsters;
            return View();
        }

    }
}