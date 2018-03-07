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
            var words = keyword.Split(' ');
            return (from word in words
             from product in _entities
             where
             word!=string.Empty &&
            
             (word.Trim().ToLower().Contains(product.Name.Trim().ToLower())
            || word.Trim().ToLower().Contains(product.Category.Name.Trim().ToLower())
            || product.Name.Trim().ToLower().Contains(word.Trim().ToLower())
            || product.Category.Name.Trim().ToLower().Contains(word.Trim().ToLower()))
            select product);
        }
        


    }
}
