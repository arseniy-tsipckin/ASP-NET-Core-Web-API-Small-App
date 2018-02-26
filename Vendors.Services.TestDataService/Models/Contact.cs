using Vendors.Services.Models;

namespace Vendors.Services.TestDataService.Models
{
    public class Contact : AbstractModel, IContact
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax   { get; set; }
    }
}