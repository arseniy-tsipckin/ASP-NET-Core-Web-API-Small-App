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
    public class TitleRepository : BaseRepository<Title,ITitle>, ITitlesRepository
    {


        public TitleRepository(VendorsDbContext context):base(context)
        {
            
        }

        public override IEnumerable<ITitle> Search(string keyword)
        {
            
            return _entities.Where(t => keyword.ToLower().Contains(t.Name.ToLower()) || t.Name.ToLower().Contains(keyword.ToLower()));
        }
    }
}
