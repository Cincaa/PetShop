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
        public DbSet<Breed> Breeds { get; set; }
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
                HasCage = true,
                Breed = new Breed
                {
                    Name = "Rasa 1",
                    Size = "Medium",
                    Color = "Red"
                },
                Food = new List<Food>
                {
                    new Food
                    {

                        ProductName = "ProHamster",
                        Diet = false

                    }
                },

                Toys = new List<Toy>{
                    new Toy
                    {

                        ProductName = "Wheel"
                    }
                }
            });

            // ctx.Breeds.Add(new Breed()
            // {
            //     Name = "Rasa2",
            //     Size = "Small",
            //     Color = "Green"
            // }
            // );

            ctx.Locations.Add(new Location
            {
                Id = 1,
                Address = new Address
                {
                    Id = 1,
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