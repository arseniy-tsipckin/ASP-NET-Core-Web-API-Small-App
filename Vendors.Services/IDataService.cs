using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
namespace Vendors.Services
{
    public interface IDataService
    {
        TRepository GetRepository<TRepository,TDataModel>() where TRepository : IRepository<TDataModel>
            where TDataModel:IModel;
        ITitlesRepository Titles { get; }
        ICategoryRepository Categories { get; }
        IContactRepository  Contacts { get; }
        ILocationRepository Locations { get; }
    }
}
