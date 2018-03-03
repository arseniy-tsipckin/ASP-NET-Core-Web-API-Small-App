using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendors.Infrastructure.Automapper;
using Vendors.Services.Models;

namespace Vendors.API.Models
{
    public class Product : IModel, IMap<IProduct>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
