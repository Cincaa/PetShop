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
            //Database.SetInitializer<DbCtx>(new CreateDatabaseIfNotExists<DbCtx>());
            //Database.SetInitializer<DbCtx>(new DropCreateDatabaseIfModelChanges<DbCtx>());
            //Database.SetInitializer<DbCtx>(new DropCreateDatabaseAlways<DbCtx>());
        }
        public DbSet<Hamster> Hamsters { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Food> Food { get; set; }

    }

    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        protected override void Seed(DbCtx ctx)
        {
            ctx.Hamsters.Add(new Hamster
            {
                Id = 1,
                Breed = "Rasa Pura"
            });


            // aceasta linie trebuie sa ramana comentata din momentul in care am introdus relatii intre tabele
            //ctx.Books.Add(new Book { Title = "Data curenta", Author = DateTime.Now.ToString() });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}