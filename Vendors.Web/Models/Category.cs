using Vendors.Services.Models;
using Vendors.Infrastructure;
using Vendors.Infrastructure.Automapper;

namespace Vendors.API.Models
{
    public class Category : IModel,IMap<ICategory>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
    }
}