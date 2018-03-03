using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;

namespace Vendors.Services.TestDataService.Repositories
{
    public class VendorRepository : BaseRepository<Vendor,IVendor>, IVendorRepository
    {
        public VendorRepository(VendorsDbContext context) : base(context)
        {
        }

        public IEnumerable<IVendor> GetByCompany(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVendor> GetByContact(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVendor> GetByTitle(long id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IVendor> Search(string keyword)
        {
            return _entities.Where(v => keyword.Contains(v.FirstName) 
            || keyword.Contains(v.LastName) 
            || keyword.Contains(v.Title.Name)
            || keyword.Contains(v.Contact.Email)
            || keyword.Contains(v.Contact.Phone)
            || keyword.Contains(v.Contact.Fax)
            || keyword.Contains(v.Company.Name)
            || keyword.Contains(v.Company.Address.City)
            || keyword.Contains(v.Company.Address.Country)
            || keyword.Contains(v.Company.Address.PostalCode)
            || keyword.Contains(v.Company.Address.StateProvince)
            || keyword.Contains(v.Company.Address.Street)
            || keyword.Contains(v.Company.Contact.Email)
            || keyword.Contains(v.Company.Contact.Phone)
            || keyword.Contains(v.Company.Contact.Fax) 
            || v.FirstName.Contains(keyword)
            || v.LastName.Contains(keyword)
            || v.Title.Name.Contains(keyword)
            || v.Contact.Email.Contains(keyword)
            || v.Contact.Phone.Contains(keyword)
            || v.Contact.Fax.Contains(keyword)
            || v.Company.Name.Contains(keyword)
            || v.Company.Address.City.Contains(keyword)
            || v.Company.Address.Country.Contains(keyword)
            || v.Company.Address.StateProvince.Contains(keyword)
            || v.Company.Address.Street.Contains(keyword)
            || v.Company.Contact.Phone.Contains(keyword)
            || v.Company.Contact.Fax.Contains(keyword));

            ;
        }
    }
}
