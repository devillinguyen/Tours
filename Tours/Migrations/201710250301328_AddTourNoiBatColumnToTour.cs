namespace Tours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTourNoiBatColumnToTour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tours", "TourNoiBat", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tours", "TourNoiBat");
        }
    }
}
