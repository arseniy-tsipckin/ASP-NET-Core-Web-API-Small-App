using System;
using System.Collections.Generic;
using System.Text;

namespace Vendors.Services.Models
{
    public interface ILocation:IModel
    {
        string Street { get; set; }
        string City { get; set; }
        string StateProvince { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
    }
}
