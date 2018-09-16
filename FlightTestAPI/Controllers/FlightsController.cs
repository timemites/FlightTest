using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;
using FlightTestAPI.Models;

namespace FlightTestAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FlightsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET ALL FLIGHTS FROM CSV

        //http://localhost:4200/Flight
        public IEnumerable<Flights> Get()
        {
            List<Flights> flights = new List<Flights>();

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
            return flights;
        }

        // GET: api/Flights/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Flights
        // UPDATES FLIGHTS FROM CSV FILE TO DATABASE
        [HttpPost]
        public void Post(string value)
        {

            List<Flights> flights = new List<Flights>();

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
            if (flights.Count!= 0)
            {
                db.Database.ExecuteSqlCommand("DELETE FROM [Flights]");
                foreach (var flight in flights)
                {
                    db.Flights.Add(flight);
                    db.SaveChanges();
                }
            }
            
          
        }

        // PUT: api/Flights/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Flights/5
        public void Delete(int id)
        {
        }
    }
}
