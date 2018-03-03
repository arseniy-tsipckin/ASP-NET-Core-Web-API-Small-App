using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Vendors.Infrastructure.Automapper
{
    public class AutoMapperProfile:Profile
    {

        public AutoMapperProfile()
        {
            StandardMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
        }
        private void LoadCustomMappings(IEnumerable<Type> types)
        {
            
        }

        private void StandardMappings(IEnumerable<Type> types)
        {
            
            (from t in types
             from i in t.GetInterfaces()
             where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMap<>) &&
                   !t.IsAbstract &&
                   !t.IsInterface
             select new
             {
                 Source = t,
                 Destination = i.GetGenericArguments()[0]
             }).ToList()
               .ForEach((map) =>
               {
                   CreateMap(map.Source, map.Destination).ReverseMap();
                   
               });
        }
    }
}
