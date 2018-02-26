using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Vendors.Services.TestDataService.Repositories;
using Vendors.Services.Models;
using System.Linq;

namespace Vendors.Services.TestDataService
{
    public class DataService : IDataService
    {
        private VendorsDbContext _context;
        private ITitlesRepository _titles;
        private ICategoryRepository _categories;
        private IContactRepository _contacts;
        private ILocationRepository _locations;
        public DataService(string connection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VendorsDbContext>();
            optionsBuilder.UseInMemoryDatabase(connection);
            _context =new VendorsDbContext(optionsBuilder.Options);
            
            
            

        }
        
        public ITitlesRepository Titles
        {
            get
            {
                if(_titles==null)
                {
                    _titles = new TitleRepository(_context);
                }
                return _titles;
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                if(_categories==null)
                {
                    _categories = new CategoryRepository(_context);
                }
                return _categories;
            }
        }

        public IContactRepository Contacts
        {
            get
            {
                if(_contacts==null)
                {
                    _contacts = new ContactRepository(_context);
                }
                return _contacts;
            }
        }

        public ILocationRepository Locations
        {
            get
            {
                if (_locations == null)
                {
                    _locations = new LocationRepository(_context);
                }
                return _locations;
            }
        }

        public TRepository GetRepository<TRepository, TDataModel>()
            where TRepository : IRepository<TDataModel>
            where TDataModel : IModel
        {
            var properties = from property in GetType().GetProperties()
                        where typeof(TRepository)==property.PropertyType
                             select property ;
            var _property= properties.FirstOrDefault();
            return (TRepository)_property.GetMethod.Invoke(this,null);
        }
    }
}
