namespace FlightTestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBookingDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingDetails", "PassengerId", "dbo.PassengerInfo");
            DropIndex("dbo.BookingDetails", new[] { "PassengerId" });
            AddColumn("dbo.BookingDetails", "FirstName", c => c.String());
            AddColumn("dbo.BookingDetails", "LastName", c => c.String());
            AddColumn("dbo.BookingDetails", "ContactNumber", c => c.String());
            AddColumn("dbo.BookingDetails", "Email", c => c.String());
            DropColumn("dbo.BookingDetails", "PassengerId");
            DropColumn("dbo.BookingDetails", "NoOfPassenger");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingDetails", "NoOfPassenger", c => c.Int(nullable: false));
            AddColumn("dbo.BookingDetails", "PassengerId", c => c.Int(nullable: false));
            DropColumn("dbo.BookingDetails", "Email");
            DropColumn("dbo.BookingDetails", "ContactNumber");
            DropColumn("dbo.BookingDetails", "LastName");
            DropColumn("dbo.BookingDetails", "FirstName");
            CreateIndex("dbo.BookingDetails", "PassengerId");
            AddForeignKey("dbo.BookingDetails", "PassengerId", "dbo.PassengerInfo", "PassengerId", cascadeDelete: true);
        }
    }
}
