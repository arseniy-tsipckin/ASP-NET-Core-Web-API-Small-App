using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;

namespace Vendors.Services.TestDataService.Repositories
{
    public class CompanyRepository : BaseRepository<Company,ICompany>, ICompanyRepository
    {
        public CompanyRepository(VendorsDbContext context) : base(context)
        {
        }

        public IEnumerable<ICompany> GetByContact(long id)
        {
           return MapFromEntityToProxyRange(_entities.Where(c => c.Contact.Id==id));
        }

        public IEnumerable<ICompany> GetByLocation(long id)
        {
            return MapFromEntityToProxyRange(_entities.Where(c => c.Address.Id == id));
        }

        public override IEnumerable<ICompany> Search(string keyword)
        {
            
             return _entities.Where(c => keyword.Contains(c.Name)
            || keyword.Contains(c.Address.City)
            || keyword.Contains(c.Address.Country)
            || keyword.Contains(c.Address.PostalCode)
            || keyword.Contains(c.Address.StateProvince)
            || keyword.Contains(c.Address.Street)
            || keyword.Contains(c.Contact.Email)
            || keyword.Contains(c.Contact.Phone)
            || keyword.Contains(c.Contact.Fax)
            || c.Name.Contains(keyword)
            || c.Address.City.Contains(keyword)
            || c.Address.Country.Contains(keyword)
            || c.Address.StateProvince.Contains(keyword)
            || c.Address.Street.Contains(keyword)
            || c.Contact.Phone.Contains(keyword)
            || c.Contact.Fax.Contains(keyword));
            
        }
    }
}
