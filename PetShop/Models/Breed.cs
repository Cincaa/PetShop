using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace PetShop.Models
{
    public class Breed
    {
        public int BreedId { get; set; }

        [MinLength(3, ErrorMessage = "Breed name cannot be less than 3!"),
         MaxLength(20, ErrorMessage = "Breed name cannot be more than 20!")]
        public string Name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public byte[] Image { get; set; }
        public virtual IEnumerable<Hamster> Hamsters { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> BreedSizeList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BreedColorList { get; set; }
    }
}