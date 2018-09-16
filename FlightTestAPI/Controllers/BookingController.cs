using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Cors;
using FlightTestAPI.Models;
namespace FlightTestAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookingController : ApiController
    {
         private ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Booking
        public int Get()
        {
            int bookingId = 0;
            bookingId = db.BookingDetails.Count();
            bookingId = bookingId + 1;

            return bookingId;
        }

        // GET: api/Booking/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        [HttpPost]
        public void Post(BookingDetails[] bookings )
        {
            int bookingId = db.BookingDetails.Count() + 1;
            foreach (var book in bookings)
            {
                BookingDetails bookingDetails = new BookingDetails
                {
                    FlightId = book.FlightId,
                    FlightName = book.FlightName,
                    BookingRefNo = "AC0" + bookingId,
                    BookingDate = Convert.ToDateTime(book.BookingDate),
                    FirstName = book.FirstName,
                    LastName = book.LastName,
                    Email = book.Email
                };
                db.BookingDetails.Add(bookingDetails);
                db.SaveChanges();
            }
        }

        // PUT: api/Booking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Booking/5
        public void Delete(int id)
        {
        }
    }
}
