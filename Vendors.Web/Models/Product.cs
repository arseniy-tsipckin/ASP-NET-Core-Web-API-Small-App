using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendors.API.Models
{
    public class Product : IModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
