namespace Vendors.Services.Models
{
    public interface ICompany:IModel
    {
        
        string Name { get; set; }
        ILocation Address { get; set; }
        IContact Contact { get; set; }
    }
}