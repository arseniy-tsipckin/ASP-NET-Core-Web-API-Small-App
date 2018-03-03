using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Vendors.Services.Models;
using Vendors.Services.TestDataService.Models;

namespace Vendors.Services.Infrastructure
{
    public class ServiceMapperProfile : Profile
    {
        protected static Type[] Types => Assembly.GetExecutingAssembly().GetExportedTypes();
        public ServiceMapperProfile()
        {
            //Data Models
            ConfigDataModels(Types);

            //Data Models - Custom

            ConfigureDataModelsCustomMappings();

            //Repositories
            //ConfigRepositories(Types);
        }

        private void ConfigureDataModelsCustomMappings()
        {
            CreateMap<IProduct, Company>().ForMember(p => p.ContactField, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<IProduct, Company>().ForMember(c => c.AddressField, opt => opt.Ignore()).ReverseMap();
            CreateMap<IVendor, Vendor>().ForMember(p => p.CompanyField, opt => opt.Ignore()).ReverseMap();
            CreateMap<IVendor, Vendor>().ForMember(p => p.ContactField, opt => opt.Ignore()).ReverseMap();
            CreateMap<IVendor, Vendor>().ForMember(p => p.TitleField, opt => opt.Ignore()).ReverseMap();
            CreateMap<IProduct, Product>().ForMember(p => p.CategoryField, opt => opt.Ignore()).ReverseMap();
        }

        //protected virtual void ConfigRepositories(Type[] types)
        //{
        //    (from t in types
        //     from i in t.GetInterfaces()
        //     where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(Repositories.IRepository<>)
        //     select new
        //     {
        //         Source = i,
        //         Destination = t
        //     }).ToList()
        //                   .ForEach((map) =>
        //                   {
        //                       CreateMap(map.Source, map.Destination);
        //                       CreateMap(map.Destination, map.Source);
        //                   });
        //}

        protected virtual void ConfigDataModels(Type[] types)
        {
            (from t in types
             from i in t.GetInterfaces()
             where typeof(Models.IModel).IsAssignableFrom(i) &&
                   !t.IsAbstract &&
                   !t.IsInterface
             select new
             {
                 Source = i,
                 Destination = t
             }).ToList()
                           .ForEach((map) =>
                           {
                               CreateMap(map.Source, map.Destination);
                               CreateMap(map.Destination, map.Source);
                           });
        }
    }
}
