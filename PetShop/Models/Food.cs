using System.Collections.Generic;

namespace PetShop.Models
{
    public class Food
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        public bool Diet { get; set; }

        public List<Hamster> Hamsters { get; set; }
    }
}