using System.Collections.Generic;

namespace PetShop.Models
{
    public class Hamster
    {
        public int Id { get; set; }
        public string Breed { get; set; }

        public Cage Cage { get; set; }

        public List<Food> Food { get; set; }

        public List<Toy> Toys { get; set; }
    }
    
}