using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace PetShop.Models
{
    public class Breed
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int BreedId { get; set; }

        [MinLength(3, ErrorMessage = "Breed name cannot be less than 3!"),
         MaxLength(20, ErrorMessage = "Breed name cannot be more than 20!")]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = "Breed size cannot be less than 3!"),
         MaxLength(20, ErrorMessage = "Breed size cannot be more than 20!")]
        public string Size { get; set; }

        [MinLength(3, ErrorMessage = "Breed color cannot be less than 3!"),
         MaxLength(20, ErrorMessage = "Breed color cannot be more than 20!")]
        public string Color { get; set; }
        public byte[] Image { get; set; }
        public virtual IEnumerable<Hamster> Hamsters { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> BreedSizeList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BreedColorList { get; set; }
    }
}