namespace FlightTestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingDetailsFlightName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingDetails", "FlightName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingDetails", "FlightName");
        }
    }
}
