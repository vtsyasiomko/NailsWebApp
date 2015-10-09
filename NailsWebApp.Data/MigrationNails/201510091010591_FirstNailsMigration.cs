namespace NailsApp.Data.MigrationNails
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstNailsMigration : DbMigration
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
                        NailsService_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NailsService", t => t.NailsService_Id)
                .Index(t => t.NailsService_Id);
            
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
                        UserId = c.Guid(nullable: false),
                        Address_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAddress", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phone", "UserInfo_Id", "dbo.UserInfo");
            DropForeignKey("dbo.UserInfo", "Address_Id", "dbo.UserAddress");
            DropForeignKey("dbo.Phone", "PhoneType_Id", "dbo.PhoneType");
            DropForeignKey("dbo.NailsService", "NailsService_Id", "dbo.NailsService");
            DropForeignKey("dbo.Street", "City_Id", "dbo.City");
            DropForeignKey("dbo.City", "Country_Id", "dbo.Country");
            DropIndex("dbo.UserInfo", new[] { "Address_Id" });
            DropIndex("dbo.Phone", new[] { "UserInfo_Id" });
            DropIndex("dbo.Phone", new[] { "PhoneType_Id" });
            DropIndex("dbo.NailsService", new[] { "NailsService_Id" });
            DropIndex("dbo.Street", new[] { "City_Id" });
            DropIndex("dbo.City", new[] { "Country_Id" });
            DropTable("dbo.UserAddress");
            DropTable("dbo.UserInfo");
            DropTable("dbo.PhoneType");
            DropTable("dbo.Phone");
            DropTable("dbo.NailsService");
            DropTable("dbo.Street");
            DropTable("dbo.Country");
            DropTable("dbo.City");
        }
    }
}
