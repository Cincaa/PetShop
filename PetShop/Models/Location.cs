using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class Location
    {
        [Column("Location_Id")]
        [Required]
        public int Id { get; set; }

        public string LocationType { get; set; }

        //one-to-one
        public Address Address { get; set; }
    }
}