using Vendors.Services.Models;
using Vendors.Services.Repositories;
namespace Vendors.Services
{
    public interface IDataService
    {
        TRepository GetRepository<TRepository,TDataModel>() 
            where TRepository : IRepository<TDataModel>
            where TDataModel:IModel;

        
    }
}
