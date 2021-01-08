using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PetShop.Models.MyValidation;

namespace PetShop.Models
{
    public class Food
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Id { get; set; }
        
        public string ProductName { get; set; }
        
        public bool Diet { get; set; }

        public List<Hamster> Hamsters { get; set; }
    }
}