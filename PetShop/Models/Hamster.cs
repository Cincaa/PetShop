using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using PetShop.Models.MyValidation;


namespace PetShop.Models
{
    public class Hamster
    {
        [Required]
        [Column("Hamster_Id")]
        [Display(Name= "Hamster Id:")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Id { get; set; }
        [BoolValidator]
        public bool HasCage { get; set; }
        //many-to-one
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        //many-to-many
        public virtual List<Food> Food { get; set; }
        //one-to-many
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int ToyId { get; set; }
        public virtual List<Toy> Toys { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> BreedSizeList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BreedColorList { get; set; }
    }
    
}