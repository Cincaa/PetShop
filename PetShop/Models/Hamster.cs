using PetShop.Models.MyValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace PetShop.Models
{
    public class Hamster
    {
        [Required]
        [Display(Name = "Hamster Id:")]
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
        public virtual List<Toy> Toys { get; set; }

        public byte[] Image { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BreedSizeList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BreedColorList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ToysList { get; set; }


    }

}