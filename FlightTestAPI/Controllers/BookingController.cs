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
    public class BookingController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IBookingRepository _repository;

        public BookingController(IBookingRepository repository)
        {
            this._repository = repository;
        }

        // GET ALL BOOKINGS
        //http://localhost:4200/Booking
        public int Get()
        {
            int bookingId = 0;
            bookingId = _repository.Get().Count;
            bookingId = bookingId + 1;

            return bookingId;
        }

        // GET: api/Booking/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        //http://localhost:4200/Booking/
        //{FlightId: 3, BookingRefNo: "", FlightName: "Caloundra", BookingDate: "2018-09-30", FirstName: "Jamey",
        //LastName="Fox", Email="jameyfox@email.com"}

        [HttpPost]
        public HttpResponseMessage Post(List<BookingDetails> bookings)
        {
            int bookingId =db.BookingDetails.Count() + 1;
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
                _repository.Add(bookingDetails);

            }

            HttpResponseMessage response = Request.CreateResponse<List<BookingDetails>>(HttpStatusCode.Created, bookings, this.Configuration);

            return response;

        }
      
        // PUT: api/Booking/5
        public void Put(int id, [FromBody]string value)
        {
        }
      
        //public HttpResponseMessage BookingPost(BookingDetails book)
        //{
        //    try
        //    {
        //        BookingDetails bookingDetails = new BookingDetails
        //        {
        //            FlightId = book.FlightId,
        //            FlightName = book.FlightName,
        //            BookingRefNo = book.BookingRefNo,
        //            BookingDate = Convert.ToDateTime(book.BookingDate),
        //            FirstName = book.FirstName,
        //            LastName = book.LastName,
        //            Email = book.Email
        //        };
        //        _repository.Add(bookingDetails);
        //        HttpResponseMessage response = Request.CreateResponse<BookingDetails>(HttpStatusCode.Created, bookingDetails, this.Configuration);

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        var message = ex;
        //        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotModified));
        //    }
            
        //}
        // DELETE: api/Booking/5
        public void Delete(int id)
        {
        }
    }
}
