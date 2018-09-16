using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FlightTestAPI.Models;
using FlightTestAPI.Repository;

namespace FlightTestAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ManageBookingController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private IBookingRepository _repository;

        public ManageBookingController(IBookingRepository repository)
        {
            this._repository = repository;
        }
      
        // GET: api/ManageBooking
        public IEnumerable<BookingDetails> Get()
        {
          var bookings = _repository.Get();
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
