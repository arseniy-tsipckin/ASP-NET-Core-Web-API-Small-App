using Vendors.Infrastructure.Automapper;
using Vendors.Services.Models;

namespace Vendors.API.Models
{
    public class Contact : IModel,IMap<IContact>
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public long Id { get; set ; }
    }
}