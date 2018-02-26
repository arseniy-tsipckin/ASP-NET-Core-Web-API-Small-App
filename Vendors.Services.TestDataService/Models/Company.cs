using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Models;

namespace Vendors.Services.TestDataService.Models
{
    public class Company : ICompany
    {
        public string Name { get ; set ; }
        public ILocation Address { get ; set ; }
        public IContact Contact { get ; set ; }
        public long Id { get ; set; }
    }
}
