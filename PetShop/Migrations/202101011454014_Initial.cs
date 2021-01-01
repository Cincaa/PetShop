namespace PetShop.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                {
                    Location_Id = c.Int(nullable: false),
                    City = c.String(),
                    Street = c.String(),
                    Number = c.Int(nullable: false),
                    PostalCode = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Location_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);

            CreateTable(
                "dbo.Locations",
                c => new
                {
                    Location_Id = c.Int(nullable: false, identity: true),
                    LocationType = c.String(),
                })
                .PrimaryKey(t => t.Location_Id);

            CreateTable(
                "dbo.Breeds",
                c => new
                {
                    BreedId = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 20),
                    Size = c.String(),
                    Color = c.String(),
                    Food_Id = c.Int(),
                })
                .PrimaryKey(t => t.BreedId)
                .ForeignKey("dbo.Foods", t => t.Food_Id)
                .Index(t => t.Food_Id);

            CreateTable(
                "dbo.Foods",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ProductName = c.String(),
                    Diet = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Hamsters",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HasCage = c.Boolean(nullable: false),
                    BreedId = c.Int(nullable: false),
                    ToyId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId, cascadeDelete: true)
                .Index(t => t.BreedId);

            CreateTable(
                "dbo.Toys",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ProductName = c.String(),
                    hamster_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hamsters", t => t.hamster_Id)
                .Index(t => t.hamster_Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.HamsterFoods",
                c => new
                {
                    Hamster_Id = c.Int(nullable: false),
                    Food_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Hamster_Id, t.Food_Id })
                .ForeignKey("dbo.Hamsters", t => t.Hamster_Id, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.Food_Id, cascadeDelete: true)
                .Index(t => t.Hamster_Id)
                .Index(t => t.Food_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Toys", "hamster_Id", "dbo.Hamsters");
            DropForeignKey("dbo.HamsterFoods", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.HamsterFoods", "Hamster_Id", "dbo.Hamsters");
            DropForeignKey("dbo.Hamsters", "BreedId", "dbo.Breeds");
            DropForeignKey("dbo.Breeds", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.Addresses", "Location_Id", "dbo.Locations");
            DropIndex("dbo.HamsterFoods", new[] { "Food_Id" });
            DropIndex("dbo.HamsterFoods", new[] { "Hamster_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Toys", new[] { "hamster_Id" });
            DropIndex("dbo.Hamsters", new[] { "BreedId" });
            DropIndex("dbo.Breeds", new[] { "Food_Id" });
            DropIndex("dbo.Addresses", new[] { "Location_Id" });
            DropTable("dbo.HamsterFoods");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Toys");
            DropTable("dbo.Hamsters");
            DropTable("dbo.Foods");
            DropTable("dbo.Breeds");
            DropTable("dbo.Locations");
            DropTable("dbo.Addresses");
        }
    }
}
