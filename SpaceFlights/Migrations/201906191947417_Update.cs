namespace SpaceFlights.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateTable(
                "dbo.TouristToFlights",
                c => new
                    {
                        TouristToFLightId = c.Int(nullable: false, identity: true),
                        TouristId = c.Int(nullable: false),
                        FlightId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TouristToFLightId)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.Tourists", t => t.TouristId, cascadeDelete: true)
                .Index(t => t.TouristId)
                .Index(t => t.FlightId);
            
            CreateTable(
                "dbo.Tourists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TouristToFlights", "TouristId", "dbo.Tourists");
            DropForeignKey("dbo.TouristToFlights", "FlightId", "dbo.Flights");
            DropIndex("dbo.TouristToFlights", new[] { "FlightId" });
            DropIndex("dbo.TouristToFlights", new[] { "TouristId" });
            DropTable("dbo.Tourists");
            DropTable("dbo.TouristToFlights");
            DropTable("dbo.Flights");
        }
    }
}
