namespace PetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeRogggggMergi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        Dog_____Id = c.Int(nullable: false, identity: true),
                        Breed = c.String(),
                        Leash_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Dog_____Id)
                .ForeignKey("dbo.Leashes", t => t.Leash_Id)
                .Index(t => t.Leash_Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        productName = c.String(),
                        CanBeEatenByDogs = c.Boolean(nullable: false),
                        CanBeEatenByFish = c.Boolean(nullable: false),
                        Dog_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dogs", t => t.Dog_Id)
                .Index(t => t.Dog_Id);
            
            CreateTable(
                "dbo.Leashes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dogs", "Leash_Id", "dbo.Leashes");
            DropForeignKey("dbo.Foods", "Dog_Id", "dbo.Dogs");
            DropIndex("dbo.Foods", new[] { "Dog_Id" });
            DropIndex("dbo.Dogs", new[] { "Leash_Id" });
            DropTable("dbo.Leashes");
            DropTable("dbo.Foods");
            DropTable("dbo.Dogs");
        }
    }
}
