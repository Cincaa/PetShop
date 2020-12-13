using PetShop.DataAccessLayer;
using PetShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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