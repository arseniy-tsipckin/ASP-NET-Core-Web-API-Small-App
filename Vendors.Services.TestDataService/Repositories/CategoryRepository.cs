using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;

namespace Vendors.Services.TestDataService.Repositories
{
    public class CategoryRepository:BaseRepository<Category,ICategory>,ICategoryRepository
    {
        public CategoryRepository(VendorsDbContext context) : base(context)
        {

        }

        public override IEnumerable<ICategory> Search(string keyword)
        {
           return _entities.Where(c => keyword.Contains(c.Name) || c.Name.Contains(keyword));
        }
    }
}
