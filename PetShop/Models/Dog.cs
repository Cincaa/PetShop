using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace PetShop.Models
{
    public class Dog
    {
        [Key, Column("Dog_Id")]
        public int Id { get; set; }
        public string Breed { get; set; }

        public Leash Leash { get; set; }
        public List<Food> Food { get; set; }
    }

    public class DbCtx : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        
    }
}