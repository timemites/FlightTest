using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlightTestMVC.Models
{
    public class BookingDetails
    {
        public int Id { get; set; }
        [ForeignKey("Flights")]
        public int FlightId { get; set; }

        [ForeignKey("PassengerInfo")]
        public int PassengerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Display(Name = "No of Passengers")]
        public int NoOfPassenger { get; set; }

        public PassengerInfo Passenger { get; set; }
        public Flights Flight { get; set; }
    }
}