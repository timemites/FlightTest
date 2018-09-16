using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using FlightTestAPI.Models;
using Newtonsoft.Json;
using Ninject.Activation;

namespace FlightTestAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public ApplicationDbContext context { get; set; }

        public BookingRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public List<BookingDetails> Get()
        {
            return context.BookingDetails.ToList();
        }

        public BookingDetails Get(int id)
        {
            return context.BookingDetails.Find(id);
        }

        public void Add(BookingDetails entity)
        {
            context.BookingDetails.Add(entity);
            context.SaveChanges();
        }

        public void AddList(List<BookingDetails> entity)
        {
            foreach (var book in entity)
            {
                context.BookingDetails.Add(book);
                context.SaveChanges();
            }
        }

        public void Remove(BookingDetails entity)
        {
            var obj = context.BookingDetails.Find(entity.BookingId);
            context.BookingDetails.Remove(obj ?? throw new InvalidOperationException());
            context.SaveChanges();
        }


        public void Dispose()
        {
            context?.Dispose();
        }
    }
}