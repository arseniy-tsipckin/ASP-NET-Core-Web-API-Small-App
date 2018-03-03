using Vendors.Infrastructure.Automapper;
using Vendors.Services.Models;

namespace Vendors.API.Models
{
    public class Location : IModel, IMap<ILocation>
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string City   { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

    }
}