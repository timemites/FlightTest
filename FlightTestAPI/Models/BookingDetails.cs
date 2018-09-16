using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlightTestAPI.Models
{
    public class BookingDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        [ForeignKey("Flights")]
        public int FlightId { get; set; }
        public string FlightName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }
        public string BookingRefNo { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
     
        public string Email { get; set; }

        public Flights Flights { get; set; }
    }
}