using NUnit.Framework;
using System;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;
using Autofac;
using AutoMapper;
namespace Vendors.Services.TestDataService.Tests
{
    [TestFixture]
    public class CompanyRepoTests
    {
        ContainerBuilder builder;
        IContainer container;
        IDataService dataService;
        public CompanyRepoTests()
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
            Mapper.Initialize(cfg => { cfg.AddProfiles(profile); });
            dataService = container.Resolve<IDataService>();
        }
        [Test]
        public void Create()
        {
            var contactRepo = dataService.GetRepository<IContactRepository, IContact>();
            var contact = contactRepo.Add(new Contact() { Email = "abc@gmail.com", Fax = "(111)111-1111", Phone = "(222)222-2222" });
            var locationRepo = dataService.GetRepository<ILocationRepository, ILocation>();
            var address = locationRepo.Add(new Location()
            { City = "Toronto", PostalCode = "M3C", StateProvince = "ON", Country = "Canada", Street = "Some Street" });
            var companyRepo = dataService.GetRepository<ICompanyRepository, ICompany>();
            var company = new Company() { Address = (Location)address, Contact = (Contact)contact, Name = "New Company" };
            var actualCompany = companyRepo.Add(company);
            company.Id = actualCompany.Id;
            Assert.IsTrue(company.EqualsToModel(actualCompany));

        }
    }
}
