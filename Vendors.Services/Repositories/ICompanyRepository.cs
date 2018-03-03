using System.Collections.Generic;
using Vendors.Services.Models;

namespace Vendors.Services.Repositories
{
    public interface ICompanyRepository: IRepository<ICompany>
       
    {
        IEnumerable<ICompany> GetByContact(long id);
        IEnumerable<ICompany> GetByLocation(long id);
    }
}