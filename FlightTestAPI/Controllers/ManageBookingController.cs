using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FlightTestAPI.Models;

namespace FlightTestAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ManageBookingController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/ManageBooking
        public IEnumerable<BookingDetails> Get()
        {
            List<BookingDetails> bookings = db.BookingDetails.OrderBy(x => x.BookingDate).ToList();
            return bookings;
        }

        // GET: api/ManageBooking/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ManageBooking
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ManageBooking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ManageBooking/5
        public void Delete(int id)
        {
        }
    }
}
