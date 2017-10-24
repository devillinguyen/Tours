namespace Tours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPackageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TourId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        QuantityVehi = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId)
                .ForeignKey("dbo.Tours", t => t.TourId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.TourId)
                .Index(t => t.ServiceId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Place = c.String(nullable: false, maxLength: 255),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cover = c.String(nullable: false, maxLength: 255),
                        Images1 = c.String(),
                        Images2 = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Seat = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Packages", "TourId", "dbo.Tours");
            DropForeignKey("dbo.Packages", "ServiceId", "dbo.Services");
            DropIndex("dbo.Packages", new[] { "VehicleId" });
            DropIndex("dbo.Packages", new[] { "ServiceId" });
            DropIndex("dbo.Packages", new[] { "TourId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Tours");
            DropTable("dbo.Services");
            DropTable("dbo.Packages");
        }
    }
}
