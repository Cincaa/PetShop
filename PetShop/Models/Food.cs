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
        public bool CanBeEatenByFish { get; set; }
        public bool CanBeEatenByHamster { get; set; }
    }
}