using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;

namespace Vendors.Services.TestDataService.Repositories
{
    public class CategoryRepository:AbstractRepository<ICategory,Category>,ICategoryRepository
    {
        public CategoryRepository(VendorsDbContext context) : base(context)
        {

        }
    }
}
