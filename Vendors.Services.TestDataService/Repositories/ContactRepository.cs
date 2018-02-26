using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;

namespace Vendors.Services.TestDataService.Repositories
{
    public class ContactRepository : AbstractRepository<IContact, Contact>, IContactRepository
    {
        public ContactRepository(DbContext context) : base(context)
        {
        }
    }
}
