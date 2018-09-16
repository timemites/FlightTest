namespace FlightTestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingRefNoInBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingDetails", "BookingRefNo", c => c.String());
            DropColumn("dbo.BookingDetails", "ContactNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingDetails", "ContactNumber", c => c.String());
            DropColumn("dbo.BookingDetails", "BookingRefNo");
        }
    }
}
