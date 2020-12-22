using System.Collections.Generic;
using PetShop.Models;

namespace PetShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetShop.Models.ApplicationDbContext ctx)
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
