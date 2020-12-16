using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class Food
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        public bool Diet { get; set; }

         public List<Hamster> Hamsters  { get; set; }
         public List<Breed> Fishes { get; set; }
    }
}