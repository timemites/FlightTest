using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlightTestAPI.Models;

namespace FlightTestAPI.Controllers
{
    public class AvailabilityController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Availability
        //http://localhost:63395/api/Availability?flightId=2&flightDate=2018-09-15&passenger=1
        [HttpGet]
        public int Get(int flightId, DateTime flightDate, int passenger)
        {
            
            List<Flights> flights = new List<Flights>();

            //Fetch Flights from CSV file
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/");
            string filePath = path + "Flights.csv";
            string csvData = File.ReadAllText(filePath);
            foreach (string row in csvData.Split('\n').Skip(1))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    flights.Add(new Flights()
                    {
                        FlightId = Convert.ToInt32(row.Split(',')[0]),
                        FlightNo = row.Split(',')[1],
                        StartTime = DateTime.Parse(row.Split(',')[2]).TimeOfDay,
                        EndTime = DateTime.Parse(row.Split(',')[3]).TimeOfDay,
                        PassengerCapacity = Convert.ToInt32(row.Split(',')[4]),
                        DepartureCity = row.Split(',')[5],
                        ArrivalCity = row.Split(',')[6],
                    });
                }
            }

            Flights flight = flights.FirstOrDefault(x => x.FlightId == flightId);
            //Fetch all Bookings on the Date
            List<BookingDetails> bookings = db.BookingDetails
                .Where(x => x.FlightId == flightId && x.BookingDate == flightDate)
                .ToList();

            int returnValue = flight.PassengerCapacity-bookings.Count;
            //Deduct no of Passengers
            returnValue = returnValue - passenger;
            if (flightDate < DateTime.Now)
            {
                returnValue=0;
            }
          
            return returnValue;
        }

        // GET: api/Availability/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Availability
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Availability/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Availability/5
        public void Delete(int id)
        {
        }
    }
}
