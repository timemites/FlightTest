using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightTestMVC.Models
{
    public class Flights
    {
        public int FlightId { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }
      
        public int PassengerCapacity { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
    }
}