using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FlightTestAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();

        }

        public DbSet<Flights> Flights { get; set; }
        public DbSet<PassengerInfo> Passengers { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}