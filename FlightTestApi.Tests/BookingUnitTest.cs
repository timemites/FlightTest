using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using FlightTestAPI.Controllers;
using FlightTestAPI.Migrations;
using FlightTestAPI.Models;
using FlightTestAPI.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FlightTestApi.Tests
{
    [TestClass]
    public class BookingUnitTest
    {
        [TestMethod]
        public void BookingController_PostReturnsSuccessCodeTest()
        {
            //ARRANGE
            //Mock Booking Repository
            var bookingDetails = new List<BookingDetails>();
           var booking= new BookingDetails{
               BookingId = 100,
               BookingRefNo = "TS01",
               FlightId = 3,
               FlightName = "Caloundra",
               BookingDate = Convert.ToDateTime("2018-09-30"),
               FirstName = "Test First",
               LastName = "Test Last",
               Email = "Test Email"

           };
            bookingDetails.Add(booking);

            Mock<IBookingRepository> mockRepository = new Mock<IBookingRepository>();
            mockRepository
                .Setup(x => x.AddList(bookingDetails));
              

            var controller = new BookingController(mockRepository.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            var result = controller.Post(bookingDetails);

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
            
        }
    }
}
