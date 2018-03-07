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
            return _entities.Where(vendor => vendor.Company.Id==id);
        }

        public IEnumerable<IVendor> GetByContact(long id)
        {
            return _entities.Where(vendor => vendor.Contact.Id == id); 
        }

        public IEnumerable<IVendor> GetByTitle(long id)
        {
            return _entities.Where(vendor => vendor.Title.Id == id); 
        }

        public override IEnumerable<IVendor> Search(string keyword)
        {
            var wodrds = keyword.Split(' ');

            return (from word in wodrds
                    from vendor in 
                _entities
                where word!=string.Empty &&
             (word.Trim().ToLower().Contains(vendor.FirstName.Trim().ToLower()) 
            || word.Trim().ToLower().Contains(vendor.LastName.Trim().ToLower()) 
            || word.Trim().ToLower().Contains(vendor.Title.Name.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Contact.Email.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Contact.Phone.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Contact.Fax.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Company.Name.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Company.Address.City.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Company.Address.Country.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Company.Address.PostalCode.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Company.Address.StateProvince.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Company.Address.Street.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Company.Contact.Email.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Company.Contact.Phone.Trim().ToLower())
            || word.Trim().ToLower().Contains(vendor.Company.Contact.Fax.Trim().ToLower()) 
            || vendor.FirstName.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.LastName.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.Title.Name.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.Contact.Email.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.Contact.Phone.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.Contact.Fax.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.Company.Name.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.Company.Address.City.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.Company.Address.Country.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.Company.Address.StateProvince.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.Company.Address.Street.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.Company.Contact.Phone.Trim().ToLower().Contains(word.Trim().ToLower())
            || vendor.Company.Contact.Fax.Trim().ToLower().Contains(word.Trim().ToLower()))

            select vendor).Distinct();

            ;
        }
    }
}
