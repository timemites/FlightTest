using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlightTestAPI.Models;
using Newtonsoft.Json;

namespace FlightTestAPI.Repository
{
    public interface IRepository:IDisposable
    {
        List<Flights> Get();
        Flights Get(int id);
        void Add(Flights entity);
        void Remove(Flights entity);
        HttpResponseMessage FlightList();

    }
}
