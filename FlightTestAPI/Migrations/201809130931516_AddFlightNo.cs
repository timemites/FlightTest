namespace FlightTestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlightNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "FlightNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "FlightNo");
        }
    }
}
