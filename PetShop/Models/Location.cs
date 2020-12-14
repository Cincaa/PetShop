using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class Location
    {
        [Column("Location_Id")]
        [Required]
        public int Id{ get; set; }

        public string LocationType { get; set; }

        //one-to-one
        public Address Address { get; set; }
    }
}