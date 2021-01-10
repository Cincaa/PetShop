using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class Location
    {
        [Column("Location_Id")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Id { get; set; }
        [RegularExpression("([a-zA-Z-]+)")]
        public string LocationType { get; set; }

        //one-to-one
        public Address Address { get; set; }
    }
}