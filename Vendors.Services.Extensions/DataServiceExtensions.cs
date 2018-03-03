using System;
using Vendors.Services.Models;
using Vendors.Services.Repositories;

namespace Vendors.Services.Extensions
{
    public static class DataServiceExtensions
    {
        public static TRepository GetRepository<TRepository, TDataModel>(this IDataService service)
            where TRepository : IRepository<TDataModel>
            where TDataModel : IModel
        {

        }

    }
}
