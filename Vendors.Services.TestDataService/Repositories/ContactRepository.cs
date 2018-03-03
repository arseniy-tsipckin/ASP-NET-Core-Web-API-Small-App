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
    public class ContactRepository : BaseRepository<Contact,IContact>, IContactRepository
    {
        public ContactRepository(VendorsDbContext context) : base(context)
        {
        }

        public override IEnumerable<IContact> Search(string keyword)
        {
            return _entities.Where(c => keyword.Contains(c.Email) 
            || keyword.Contains(c.Fax) 
            || keyword.Contains(c.Phone)
            || c.Email.Contains(keyword)
            || c.Fax.Contains(keyword)
            || c.Phone.Contains(keyword)
             );
        }
    }
}
