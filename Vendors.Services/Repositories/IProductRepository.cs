using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Models;

namespace Vendors.Services.Repositories
{
    public interface IProductRepository:IRepository<IProduct> 
        
    {
        IEnumerable<IProduct> GetByCategory(long id);
        
    }
}
