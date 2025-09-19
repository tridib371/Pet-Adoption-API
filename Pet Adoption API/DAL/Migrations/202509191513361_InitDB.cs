namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adoptions",
                c => new
                    {
                        AdoptionId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PetId = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20, unicode: false),
                        RequestDate = c.DateTime(nullable: false),
                        DecisionDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.AdoptionId)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PetId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 10, unicode: false),
                        Breed = c.String(nullable: false, maxLength: 100, unicode: false),
                        Category = c.String(nullable: false, maxLength: 50, unicode: false),
                        IsAdopted = c.Boolean(nullable: false),
                        ShelterId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.Shelters", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        FavoriteId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PetId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FavoriteId)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PetId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 15, unicode: false),
                        PasswordHash = c.String(nullable: false, maxLength: 255, unicode: false),
                        Role = c.String(nullable: false, maxLength: 20, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Shelters",
                c => new
                    {
                        ShelterId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Address = c.String(maxLength: 255, unicode: false),
                        Phone = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ShelterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adoptions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Adoptions", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "ShelterId", "dbo.Shelters");
            DropForeignKey("dbo.Favorites", "UserId", "dbo.Users");
            DropForeignKey("dbo.Favorites", "PetId", "dbo.Pets");
            DropIndex("dbo.Favorites", new[] { "PetId" });
            DropIndex("dbo.Favorites", new[] { "UserId" });
            DropIndex("dbo.Pets", new[] { "ShelterId" });
            DropIndex("dbo.Adoptions", new[] { "PetId" });
            DropIndex("dbo.Adoptions", new[] { "UserId" });
            DropTable("dbo.Shelters");
            DropTable("dbo.Users");
            DropTable("dbo.Favorites");
            DropTable("dbo.Pets");
            DropTable("dbo.Adoptions");
        }
    }
}
