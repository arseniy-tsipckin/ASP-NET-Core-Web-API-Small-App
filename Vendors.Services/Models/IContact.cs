namespace Vendors.Services.Models
{
    public interface IContact:IModel
    {
        string Email { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
    }
}
