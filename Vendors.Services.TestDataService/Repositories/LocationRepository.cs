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
    public class LocationRepository : BaseRepository<Location,ILocation>, ILocationRepository
    {
        public LocationRepository(VendorsDbContext context) : base(context)
        {
        }

        public override IEnumerable<ILocation> Search(string keyword)
        {
            return _entities.Where(l => keyword.Contains(l.PostalCode)
            || keyword.Contains(l.StateProvince) 
            || keyword.Contains(l.Street)
            || keyword.Contains(l.City)
            || keyword.Contains(l.Country)
            || l.PostalCode.Contains(keyword)
            || l.StateProvince.Contains(keyword)
            || l.Street.Contains(keyword)
            || l.City.Contains(keyword)
            || l.Country.Contains(keyword)
            );
        }
    }
}
