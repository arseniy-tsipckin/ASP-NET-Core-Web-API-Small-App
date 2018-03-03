using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendors.Infrastructure.Automapper;
using Vendors.Services.Models;

namespace Vendors.API.Models
{
    public class Vendor : IModel,IMap<IVendor>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public Title Title { get; set; }
        public Company Company { get; set; }
        public Contact Contact { get; set; }

    }
}
