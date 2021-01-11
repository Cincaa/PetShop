using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetShop.Models.MyValidation;

namespace PetShop.Models
{
    public class Address
    {
        [ForeignKey("Location")]
        [Column("Location_Id")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Id { get; set; }

        [RegularExpression("([a-zA-Z-]+)")]
        public string City { get; set; }
        [RegularExpression("([a-zA-Z. ]+)")]
        public string Street { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Number { get; set; }

        [PostalCodeValidator]
        public int PostalCode { get; set; }

        public Location Location { get; set; }
    }
}