using System;
using System.Collections.Generic;
using System.Net.Http;
using FlightTestAPI.Models;

namespace FlightTestAPI.Repository
{
    public interface IBookingRepository:IDisposable
    {
        List<BookingDetails> Get();
        BookingDetails Get(int id);
        void Add(BookingDetails entity);
        void AddList(List<BookingDetails> entity);
        void Remove(BookingDetails entity);
       
    }
}
