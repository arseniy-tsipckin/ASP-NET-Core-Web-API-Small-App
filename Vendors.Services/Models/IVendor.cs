using System;
using System.Collections.Generic;
using System.Text;

namespace Vendors.Services.Models
{
    public interface IVendor:IModel 
        
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        ITitle Title { get; set; }
        ICompany Company { get; set; }
        IContact Contact { get; set; }
    }
}
