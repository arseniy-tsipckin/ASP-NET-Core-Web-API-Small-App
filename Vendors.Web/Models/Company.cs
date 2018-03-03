

using Vendors.Infrastructure.Automapper;
using Vendors.Services.Models;

namespace Vendors.API.Models
{
    public class Company : IModel,IMap<ICompany>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Location Address { get; set;}
        public Contact Contact { get; set; }
    }
}