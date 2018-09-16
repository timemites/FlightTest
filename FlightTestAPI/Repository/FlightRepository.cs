using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web;
using Microsoft.Practices.Unity;
using FlightTestAPI.Models;
using Newtonsoft.Json;

namespace FlightTestAPI.Repository
{
    public class FlightRepository : IRepository
    {
        public ApplicationDbContext context { get; set; }

        public FlightRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public List<Flights> Get()
        {
            return context.Flights.ToList();
        }

        public Flights Get(int id)
        {
            return context.Flights.Find(id);
        }

        public void Add(Flights entity)
        {
            context.Flights.Add(entity);
            context.SaveChanges();
        }

        public void Remove(Flights entity)
        {
            var obj = context.Flights.Find(entity.FlightId);
            context.Flights.Remove(obj ?? throw new InvalidOperationException());
            context.SaveChanges();
        }


        public HttpResponseMessage FlightList()
        {
            var sourceQuery = context.Flights.ToList();

            string result = JsonConvert.SerializeObject(sourceQuery);
            var response = new HttpResponseMessage();
            response.Content = new StringContent(result, System.Text.Encoding.Unicode, "application/json");

            return response;
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}