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

        // protected override void OnModelCreating(DbModelBuilder modelBuilder)
        // {
        //
        //     modelBuilder.Entity<Hamster>()
        //         .HasMany<Food>(s => s.Food)
        //         .WithMany(c => c.Hamsters)
        //         .Map(cs =>
        //         {
        //             cs.MapLeftKey("HmasterRefId");
        //             cs.MapRightKey("FoodRefId");
        //             cs.ToTable("Hamsters");
        //         });
        //
        // }
        public DbSet<Hamster> Hamsters { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }


    public class Initp : CreateDatabaseIfNotExists<DbCtx>
    {
        //DropCreateDatabaseAlways
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