using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;
using FlightTestAPI.Controllers;
using FlightTestAPI.Models;
using FlightTestAPI.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FlightTestApi.Tests
{
    [TestClass]
    public class FlightUnitTest
    {
        [TestMethod]
        public void GetFlights_ShouldReturnFlightsFromRepository()
        {
            //ARRANGE
            //Mock Flight Repository
           
            Mock<IRepository> mockRepository = new Mock<IRepository>();
            mockRepository
                .Setup(x => x.FlightList())
                .Returns(new HttpResponseMessage(HttpStatusCode.OK));

            var controller = new FlightsController(mockRepository.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            var response = controller.FlightList();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
     
    }
}
