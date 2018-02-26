using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Vendors.API.nfrastructure
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            //View Models 
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();
            (from t in types
             from i in t.GetInterfaces()
             where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapping<>) &&
                   !t.IsAbstract &&
                   !t.IsInterface
             select new
             {
                 Source = t,
                 Destination = i.GetGenericArguments()[0]
             }).ToList()
               .ForEach((map) => {
                   CreateMap(map.Source, map.Destination);
                   CreateMap(map.Destination, map.Source);
               });

            //Data Models
            (from t in types
             from i in t.GetInterfaces()
             where typeof(Services.Models.IModel).IsAssignableFrom(i) &&
                   !t.IsAbstract &&
                   !t.IsInterface
             select new
             {
                 Source = i,
                 Destination = t
             }).ToList()
               .ForEach((map) => {
                   CreateMap(map.Source, map.Destination);
                   CreateMap(map.Destination, map.Source);
               });

        }
        


    }
}
