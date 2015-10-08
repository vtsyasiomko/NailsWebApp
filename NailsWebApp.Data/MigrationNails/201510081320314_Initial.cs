namespace NailsWebApp.Data.MigrationNails
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CityName = c.String(),
                        Active = c.Boolean(nullable: false),
                        Country_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CountryName = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Street",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StreetName = c.String(),
                        OldStreetName = c.String(),
                        City_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.NailsService",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        CreatedBy_Id = c.String(maxLength: 128),
                        NailsService_Id = c.Guid(),
                        UpdatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.CreatedBy_Id)
                .ForeignKey("dbo.NailsService", t => t.NailsService_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.UpdatedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.NailsService_Id)
                .Index(t => t.UpdatedBy_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Phone",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
                        Active = c.Boolean(nullable: false),
                        PhoneType_Id = c.Int(),
                        UserInfo_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhoneType", t => t.PhoneType_Id)
                .ForeignKey("dbo.UserInfo", t => t.UserInfo_Id)
                .Index(t => t.PhoneType_Id)
                .Index(t => t.UserInfo_Id);
            
            CreateTable(
                "dbo.PhoneType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        ImageId = c.Guid(),
                        SkypeName = c.String(),
                        VkId = c.String(),
                        FacebookId = c.String(),
                        OdkId = c.String(),
                        TweeterId = c.String(),
                        Address_Id = c.Guid(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAddress", t => t.Address_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.User_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserAddress",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Building = c.String(),
                        House = c.String(),
                        Appartment = c.String(),
                        PostCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.UserInfo", "User_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Phone", "UserInfo_Id", "dbo.UserInfo");
            DropForeignKey("dbo.UserInfo", "Address_Id", "dbo.UserAddress");
            DropForeignKey("dbo.Phone", "PhoneType_Id", "dbo.PhoneType");
            DropForeignKey("dbo.NailsService", "UpdatedBy_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.NailsService", "NailsService_Id", "dbo.NailsService");
            DropForeignKey("dbo.NailsService", "CreatedBy_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Street", "City_Id", "dbo.City");
            DropForeignKey("dbo.City", "Country_Id", "dbo.Country");
            DropIndex("dbo.UserInfo", new[] { "User_Id" });
            DropIndex("dbo.UserInfo", new[] { "Address_Id" });
            DropIndex("dbo.Phone", new[] { "UserInfo_Id" });
            DropIndex("dbo.Phone", new[] { "PhoneType_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.NailsService", new[] { "UpdatedBy_Id" });
            DropIndex("dbo.NailsService", new[] { "NailsService_Id" });
            DropIndex("dbo.NailsService", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Street", new[] { "City_Id" });
            DropIndex("dbo.City", new[] { "Country_Id" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.UserAddress");
            DropTable("dbo.UserInfo");
            DropTable("dbo.PhoneType");
            DropTable("dbo.Phone");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.NailsService");
            DropTable("dbo.Street");
            DropTable("dbo.Country");
            DropTable("dbo.City");
        }
    }
}
