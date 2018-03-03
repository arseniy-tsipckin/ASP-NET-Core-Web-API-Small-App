using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Vendors.Services.TestDataService.Repositories;
using Vendors.Services.Models;
using System.Linq;
using Vendors.Services.TestDataService.Models;
using System.Reflection;
using AutoMapper;
using Vendors.Services.Infrastructure;


namespace Vendors.Services.TestDataService
{
    public class DataService : IDataService
    {
        private VendorsDbContext _context;
        private TitleRepository _titleRepo;
        private CategoryRepository _categoryRepo;
        private ContactRepository _contactRepo;
        private LocationRepository _locationRepo;
        private CompanyRepository _companyRepo;
        private VendorRepository _vendorRepo;
        private ProductRepository _productRepo;

        public DataService(string connection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VendorsDbContext>();
            optionsBuilder.UseInMemoryDatabase(connection);
            _context =new VendorsDbContext(optionsBuilder.Options);
            
         
        }

        

        protected TitleRepository TitleRepo { get => _titleRepo==null?new TitleRepository(_context):_titleRepo;  }
        protected CategoryRepository CategoryRepo { get => _categoryRepo==null?new CategoryRepository(_context):_categoryRepo;  }
        protected ContactRepository ContactRepo { get => _contactRepo==null?new ContactRepository(_context):_contactRepo;  }
        protected LocationRepository LocationRepo { get => _locationRepo==null?new LocationRepository(_context):_locationRepo;  }
        protected CompanyRepository CompanyRepo{ get => _companyRepo == null ? new CompanyRepository(_context) : _companyRepo;}
        protected ProductRepository ProductRepo { get => _productRepo == null ? new ProductRepository(_context) : _productRepo; }
        protected VendorRepository VendorRepo { get => _vendorRepo==null?new VendorRepository(_context):_vendorRepo;  }

        public TIRepository GetRepository<TIRepository, TIDataModel>()
            where TIRepository : IRepository<TIDataModel>
            where TIDataModel : IModel
        {

           var properties = from property in GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                        where property.Name.Contains("Repo")
                             select property ;
            PropertyInfo _property= null;
            foreach(var prop in properties)
            {
                if(IsAType(typeof(TIDataModel), prop.PropertyType.GetInterfaces()[0].GetGenericArguments()[0]))
                {
                    _property = prop;
                    break;
                }
            }
            
            var retvalue = _property.GetMethod.Invoke(this, null);
            return (TIRepository)Mapper.Map(retvalue, retvalue.GetType(), typeof(TIRepository));
            
        }

        private bool IsAType(Type interfaceType, Type implType)
        {
            
            if(!interfaceType.IsGenericType)
            {
                return interfaceType.IsAssignableFrom(implType);
            }
            var iGeneric = interfaceType.GetGenericTypeDefinition();
            var tGeneric = implType.GetInterfaces()[1].GetGenericTypeDefinition();
            
            return iGeneric==tGeneric;
            
        }
    }
}
