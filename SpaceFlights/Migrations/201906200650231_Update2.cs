namespace SpaceFlights.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "DepartureDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Flights", "ArrivalDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Flights", "NumberOfSeats", c => c.Int(nullable: false));
            AddColumn("dbo.Flights", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Tourists", "Gender", c => c.String());
            AddColumn("dbo.Tourists", "Country", c => c.String());
            AddColumn("dbo.Tourists", "Remarks", c => c.String());
            AddColumn("dbo.Tourists", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tourists", "DateOfBirth");
            DropColumn("dbo.Tourists", "Remarks");
            DropColumn("dbo.Tourists", "Country");
            DropColumn("dbo.Tourists", "Gender");
            DropColumn("dbo.Flights", "Price");
            DropColumn("dbo.Flights", "NumberOfSeats");
            DropColumn("dbo.Flights", "ArrivalDate");
            DropColumn("dbo.Flights", "DepartureDate");
        }
    }
}
