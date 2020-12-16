using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace PetShop.Models
{
    public class Hamster
    {
        [Key]
        [Column("Hamster_Id")]
        [Display(Name= "Hamster Id:")]
        public int Id { get; set; }
        public bool HasCage { get; set; }
        //many-to-one
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        //many-to-many
        public virtual List<Food> Food { get; set; }
        //one-to-many
        public int ToyId { get; set; }
        public virtual List<Toy> Toys { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> BreedSizeList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BreedColorList { get; set; }
    }
    
}