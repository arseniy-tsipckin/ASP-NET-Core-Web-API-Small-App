using NUnit.Framework;
using System;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;
using Autofac;
using AutoMapper;
using System.Net;
using System.Linq;

namespace Vendors.Services.TestDataService.Tests
{
    
    
    [TestFixture]
    public class VendorRepoTests
    {
        ContainerBuilder builder;
        IContainer container;
        IDataService dataService;
        
        public VendorRepoTests()
        {
            builder = new ContainerBuilder();
            var dataServiceType =
                Type.GetType("Vendors.Services.TestDataService.DataService, Vendors.Services.TestDataService, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null");
            var dataServiceConnection = "Vendors";
            builder.RegisterType(dataServiceType)
                .As<IDataService>()
                .WithParameter(new TypedParameter(typeof(string), value: dataServiceConnection));

            container = builder.Build();
            var profile = API.Configuration.MapConfiguration.Profiles;
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddProfiles(profile); });
            dataService = container.Resolve<IDataService>();
        }
        IVendor vendorEntry1;
        IVendor vendorEntry2;
        Vendor vendor1;
        Vendor vendor2;
        
        private IVendor AddVendor1()
        {
            ITitle title = CreateTitle(new Title() { Name = "Sale Manager" });
            IContact companyContact = CreateContact(new Contact() { Email = "abc@gmail.com", Fax = "(111)111-1111", Phone = "(222)222-2222" });
            ILocation address = CreateLocation(new Location()
            { City = "Toronto", PostalCode = "M3C", StateProvince = "ON", Country = "Canada", Street = "Some Street" });
            ICompany company = CraeteCompany(companyContact, address, "New Company");
            var vendorContact = CreateContact(new Contact() { Email = "abcd@gmail.com", Fax = "(113)111-1111", Phone = "(225)222-2222" });
            vendor1 = new Vendor()
            {
                Company = (Company)company,
                Contact = (Contact)vendorContact,
                FirstName = "Joe",
                LastName = "Brawn",
                Title = (Title)title
            };
            return dataService.GetRepository<IVendorRepository, IVendor>().Add(vendor1);
        }
        private IVendor AddVendor2()
        {
            ITitle title2 = CreateTitle(new Title() { Name = "XX xxx" });
            IContact companyContact2 = CreateContact(new Contact() { Email = "xxx@xxx.com", Fax = "(444)444-4444", Phone = "(555)555-5555" });
            ILocation address2 = CreateLocation(new Location()
            { City = "xxxxx", PostalCode = "xxxxxx", StateProvince = "XX", Country = "Xxxxxx", Street = "Xxxx Xxxxxx" });
            ICompany company2 = CraeteCompany(companyContact2, address2, "xx xxx");
            var vendorContact2 = CreateContact(new Contact() { Email = "yyyy@yyyyy.com", Fax = "(666)666-66661", Phone = "(777)777-7777" });
            vendor2 = new Vendor()
            {
                Company = (Company)company2,
                Contact = (Contact)vendorContact2,
                FirstName = "Tom",
                LastName = "Jackson",
                Title = (Title)title2
            };
            return CreateVendor(vendor2);
        }
        [Test]
        public void Create()
        {
            if(vendorEntry1==null)
            vendorEntry1 = AddVendor1();
            vendor1.Id = vendorEntry1.Id;
            Assert.IsFalse(!vendor1.EqualsToModel(vendorEntry1));
            if (vendorEntry2 == null)
                vendorEntry2 = AddVendor2();
            vendor2.Id = vendorEntry2.Id;
            Assert.IsFalse(!vendor2.EqualsToModel(vendorEntry2));

        }
        [Test]
        public void Get()
        {
            if (vendorEntry1 == null)
                vendorEntry1 = AddVendor1();
            if (vendorEntry2 == null)
                vendorEntry2 = AddVendor2();
            var actualVendor = dataService.GetRepository<IVendorRepository, IVendor>().Get(vendorEntry1.Id);
            Assert.IsTrue(vendorEntry1.EqualsToModel(actualVendor));
            actualVendor = dataService.GetRepository<IVendorRepository, IVendor>().Get(vendorEntry2.Id);
            Assert.IsTrue(vendorEntry2.EqualsToModel(actualVendor));
        }
        [Test]
        [TestCase("abc+Manager")]
        [TestCase("abc+++Manager")]
        [TestCase("Sal+Ma")]
        [TestCase("Sal+ma")]
        [TestCase("Sa")]
        [TestCase("Joe")]
        public void Search(string keyword)
        {
            if (vendorEntry1 == null)
                vendorEntry1 = AddVendor1();
            if (vendorEntry2 == null)
                vendorEntry2 = AddVendor2();
            var _keyword = WebUtility.UrlDecode(keyword);
            var vendors = (dataService.GetRepository<IVendorRepository, IVendor>().Search(_keyword));
            foreach(var actualVendor in vendors)
            {
                Assert.IsFalse(!vendorEntry1.EqualsToModel(actualVendor));
                
            }
            
        }
        [Test]
        public void GetByCompany()
        {
            if (vendorEntry1 == null)
                vendorEntry1 = AddVendor1();
            if (vendorEntry2 == null)
                vendorEntry2 = AddVendor2();
            var vendors=dataService.GetRepository<IVendorRepository, IVendor>().GetByCompany(vendorEntry1.Company.Id);
            Assert.IsTrue(vendorEntry1.EqualsToModel(vendors.FirstOrDefault()));
            vendors = dataService.GetRepository<IVendorRepository, IVendor>().GetByCompany(vendorEntry2.Company.Id);
            Assert.IsTrue(vendorEntry2.EqualsToModel(vendors.FirstOrDefault()));

        }
        [Test]
        public void GetByContact()
        {
            if (vendorEntry1 == null)
                vendorEntry1 = AddVendor1();
            if (vendorEntry2 == null)
                vendorEntry2 = AddVendor2();

            var vendors = dataService.GetRepository<IVendorRepository, IVendor>().GetByContact(vendorEntry1.Contact.Id);
            Assert.IsTrue(vendorEntry1.EqualsToModel(vendors.FirstOrDefault()));
            vendors = dataService.GetRepository<IVendorRepository, IVendor>().GetByContact(vendorEntry2.Contact.Id);
            Assert.IsTrue(vendorEntry2.EqualsToModel(vendors.FirstOrDefault()));

        }
        [Test]
        public void GetByTitle()
        {
            if (vendorEntry1 == null)
                vendorEntry1 = AddVendor1();
            if (vendorEntry2 == null)
                vendorEntry2 = AddVendor2();
            var vendors = dataService.GetRepository<IVendorRepository, IVendor>().GetByTitle(vendorEntry1.Id);
            Assert.IsTrue(vendorEntry1.EqualsToModel(vendors.FirstOrDefault()));
            vendors = dataService.GetRepository<IVendorRepository, IVendor>().GetByTitle(vendorEntry2.Id);
            Assert.IsTrue(vendorEntry2.EqualsToModel(vendors.FirstOrDefault()));
        }
        [Test]
        public void Remove()
        {
            if (vendorEntry1 == null)
                vendorEntry1 = AddVendor1();
            if (vendorEntry2 == null)
                vendorEntry2 = AddVendor2();
            dataService.GetRepository<IVendorRepository, IVendor>().Remove(vendorEntry1.Id);
            var vendor1 = dataService.GetRepository<IVendorRepository, IVendor>().Get(vendorEntry1.Id);
            var vendor2 = dataService.GetRepository<IVendorRepository, IVendor>().Get(vendorEntry2.Id);
            Assert.IsNull(vendor1);
            Assert.IsNotNull(vendor2);
            vendorEntry1 = AddVendor1();
            dataService.GetRepository<IVendorRepository, IVendor>().Remove(vendorEntry2.Id);
            vendor1 = dataService.GetRepository<IVendorRepository, IVendor>().Get(vendorEntry1.Id);
            vendor2 = dataService.GetRepository<IVendorRepository, IVendor>().Get(vendorEntry2.Id);
            Assert.IsNull(vendor2);
            Assert.IsNotNull(vendor1);
        }
        private IVendor CreateVendor(IVendor vendor)
        {
            var vendorRepo = dataService.GetRepository<IVendorRepository, IVendor>();
            return vendorRepo.Add(vendor);
        }

        private ICompany CraeteCompany(IContact contact, ILocation address, string companyName)
        {
            var companyRepo = dataService.GetRepository<ICompanyRepository, ICompany>();
            return companyRepo.Add(new Company() { Address = (Location)address, Contact = (Contact)contact, Name = companyName });

        }

        private ILocation CreateLocation(ILocation location)
        {
            var locationRepo = dataService.GetRepository<ILocationRepository, ILocation>();
            return locationRepo.Add(location);

        }

        private IContact CreateContact(IContact contact)
        {
            var contactRepo = dataService.GetRepository<IContactRepository, IContact>();
            return contactRepo.Add(contact);
        }

        private ITitle CreateTitle(ITitle title)
        {
            var titleRepo = dataService.GetRepository<ITitlesRepository, ITitle>();
            return titleRepo.Add(title);

        }

    }
}
