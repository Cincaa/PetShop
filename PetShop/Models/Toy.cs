using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Toy
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Id { get; set; }
        public string ProductName { get; set; }
        
        public Hamster Hamster { get; set; }

    }
}