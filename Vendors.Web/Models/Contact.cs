namespace Vendors.API.Models
{
    public class Contact : IModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public long Id { get; set ; }
    }
}