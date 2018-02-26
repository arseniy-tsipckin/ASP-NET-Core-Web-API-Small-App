using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;

namespace Vendors.Services.TestDataService.Repositories
{
    public class TitleRepository : AbstractRepository<ITitle,Title>, ITitlesRepository
    {


        public TitleRepository(VendorsDbContext context):base(context)
        {
            
        }

        
    }
}
