using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;

namespace Vendors.Services.TestDataService.Repositories
{
    public class ProductRepository : BaseRepository<Product,IProduct>,IProductRepository
    {
        CategoryRepository categoryRepository;
        public ProductRepository(VendorsDbContext context) : base(context)
        {
            
        }

        public IEnumerable<IProduct> GetByCategory(long id)
        {
            return _entities.Where(p => p.Category.Id == id);
        }

        public override IEnumerable<IProduct> Search(string keyword)
        {
            return _entities.Where(p => keyword.Contains(p.Name)
            || keyword.Contains(p.Category.Name)
            || p.Name.Contains(keyword)
            || p.Category.Name.Contains(keyword));
        }
        public override IProduct Add(IProduct entity)
        {
            var category= _context.Categories.Add((Category)entity.Category);
            _context.SaveChanges();
            entity.Category = category.Entity;
            var retval=base.Add(entity);
            retval = _context.Products.SingleOrDefault(p => p.Id == retval.Id);

            return retval;
        }


    }
}
