namespace FlightTestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingDetails",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(nullable: false),
                        PassengerId = c.Int(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        NoOfPassenger = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.PassengerInfo", t => t.PassengerId, cascadeDelete: true)
                .Index(t => t.FlightId)
                .Index(t => t.PassengerId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        PassengerCapacity = c.Int(nullable: false),
                        DepartureCity = c.String(),
                        ArrivalCity = c.String(),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateTable(
                "dbo.PassengerInfo",
                c => new
                    {
                        PassengerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(),
                    })
                .PrimaryKey(t => t.PassengerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingDetails", "PassengerId", "dbo.PassengerInfo");
            DropForeignKey("dbo.BookingDetails", "FlightId", "dbo.Flights");
            DropIndex("dbo.BookingDetails", new[] { "PassengerId" });
            DropIndex("dbo.BookingDetails", new[] { "FlightId" });
            DropTable("dbo.PassengerInfo");
            DropTable("dbo.Flights");
            DropTable("dbo.BookingDetails");
        }
    }
}
