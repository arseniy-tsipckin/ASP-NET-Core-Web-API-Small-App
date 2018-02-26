using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Models;

namespace Vendors.Services.TestDataService.Models
{
    public class Location : AbstractModel, ILocation
    {
        public string Street { get ; set ; }
        public string City { get; set; }
        public string StateProvince { get ; set; }
        public string Country { get ; set ; }
        public string PostalCode { get ; set ; }
        
    }
}
