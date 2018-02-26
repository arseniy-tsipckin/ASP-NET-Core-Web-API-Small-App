

namespace Vendors.API.Models
{
    public class Company : IModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Location Address { get; set;}
        public Contact Contact { get; set; }
    }
}