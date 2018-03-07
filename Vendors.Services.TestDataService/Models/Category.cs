using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Vendors.Infrastructure.Automapper;
using Vendors.Services.Models;

namespace Vendors.Services.TestDataService.Models
{
    
    public class Category : AbstractModel, ICategory
    {
        

        public string Name { get; set; }
        [NotMapped]
        ICollection<IProduct> ICategory.Products
        {
            get
            {
                if (Products == null)
                {
                    Products = new List<Product>();
                }
                return Products.ConvertAll(converter);
            }
            set => Products = (List<Product>)value;
        }
        public List<Product> Products { get; set; }

        private IProduct converter(Product input)
        {
            return input;
        }
    }
}
