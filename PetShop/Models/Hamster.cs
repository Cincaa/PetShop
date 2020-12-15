using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class Hamster
    {
        [Key]
        [Column("Hamster_Id")]
        [Display(Name= "Hamster Id:")]
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Breed cannot be longer than 20 characters")]
        public string Breed { get; set; }

        //many-to-one
        public Cage Cage { get; set; }

        //many-to-many
        public List<Food> Food { get; set; }
        //one-to-many
        public List<Toy> Toys { get; set; }
    }
    
}