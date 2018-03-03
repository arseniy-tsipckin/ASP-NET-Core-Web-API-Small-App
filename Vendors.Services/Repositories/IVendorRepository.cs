using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Models;

namespace Vendors.Services.Repositories
{
    public interface IVendorRepository : 
        IRepository<IVendor>
        
        
    {
        IEnumerable<IVendor> GetByTitle(long id);
        IEnumerable<IVendor> GetByCompany(long id);
        IEnumerable<IVendor> GetByContact(long id);
    }
}
