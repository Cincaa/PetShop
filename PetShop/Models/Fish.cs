using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class Fish
    {
        public int Id { get; set; }

        public string Breed { get; set; }
        public List<Food> Food { get; set; }
        public List<Toy> Toys { get; set; }

    }
}