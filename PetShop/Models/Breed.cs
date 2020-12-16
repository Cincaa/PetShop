using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PetShop.Models
{
    public class Breed
    {
        public int BreedId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public virtual IEnumerable<Hamster> Hamsters { get; set; }

        public IEnumerable<SelectListItem> SizeList { get; set; }
    }
}