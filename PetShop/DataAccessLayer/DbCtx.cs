using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PetShop.Models;

namespace PetShop.DataAccessLayer
{
    public class DbCtx : DbContext
    {
        public DbCtx() : base("DbConnectionString")
        {
            Database.SetInitializer<DbCtx>(new Initp());
        }
        public DbSet<Hamster> Hamsters { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }

    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        protected override void Seed(DbCtx ctx)
        {
            ctx.Hamsters.Add(new Hamster
            {
                Id = 1,
                Breed = "Rasa Pura",
                Cage = new Cage
                {
                    
                    Size = "Medium",
                    Color = "Red"
                },
                Food = new List<Food>
                {
                    new Food
                    {
                        
                        ProductName = "ProHamster",
                        CanBeEatenByFish = false,
                        CanBeEatenByHamster = true

                    }
                },

                Toys = new List<Toy>{
                    new Toy
                    {
                        
                        ProductName = "Wheel"
                    }
                }
            });

            ctx.Cages.Add(new Cage()
            {
                
                Size = "Small",
                Color = "Green"
            }
            );

            ctx.Locations.Add(new Location
            {
                Id = 1,
                Address = new Address
                {
                    Id = 001,
                    City = "Bucharest",
                    Street = "Ciobanasului",
                    Number = 65
                }
            });

            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}