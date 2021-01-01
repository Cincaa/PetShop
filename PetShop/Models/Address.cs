using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class Address
    {
        [ForeignKey("Location")]
        [Column("Location_Id")]
        [Required]
        public int Id { get; set; }
        public string City { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }
        public int PostalCode { get; set; }

        public Location Location { get; set; }
    }
}