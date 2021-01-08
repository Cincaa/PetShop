using PetShop.Models;
using System.Collections.Generic;
using System.IO;

namespace PetShop.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PetShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PetShop.Models.ApplicationDbContext ctx)
        {
            Hamster hamster1 = new Hamster
            {
                Id = 1,
                HasCage = true,
                Breed = new Breed
                {
                    Name = "Rasa 1",
                    Size = "Medium",
                    Color = "Red",
                    Image = File.ReadAllBytes("C: \\Users\\adria\\Desktop\\Facultate\\Anul 3\\Semestrul 1\\DAW\\PetShop\\PetShop\\Images\\1.jpg")
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
                },

                Image = File.ReadAllBytes("C: \\Users\\adria\\Desktop\\Facultate\\Anul 3\\Semestrul 1\\DAW\\PetShop\\PetShop\\Images\\1.jpg")

            };

            ctx.Hamsters.Add(hamster1);



            ctx.Locations.Add(new Location
            {
                Id = 1,
                LocationType = "Classic",
                Address = new Address
                {
                    Id = 1,
                    City = "Bucharest",
                    Street = "Ciobanasului",
                    Number = 65,
                    PostalCode = 610192
                }
            });

            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}
