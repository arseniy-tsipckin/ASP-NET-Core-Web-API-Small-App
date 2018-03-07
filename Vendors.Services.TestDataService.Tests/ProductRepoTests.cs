using Autofac;
using AutoMapper;
using NUnit.Framework;
using System;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;

namespace Vendors.Services.TestDataService.Tests
{
    [TestFixture]
    public class ProductRepoTests
    {
        ContainerBuilder builder;
        IContainer container;
        IDataService dataService;
        public ProductRepoTests()
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
            dataService= container.Resolve<IDataService>();
        }
        
        [Test]
        public void Create()
        {
            var categoryRepo = dataService.GetRepository<ICategoryRepository, ICategory>();
            ICategory category= categoryRepo.Add(new Category { Name = "Some category" });
            var productRepo=dataService.GetRepository<IProductRepository, IProduct>();

            IProduct newProduct = new Product() { Name = "New Product",  Category= (Category)category };
            IProduct productEntry= productRepo.Add(newProduct);
            IProduct expectedProduct = new Product() { Id = 1, Name = "New Product", Category = (Category)category };
            Assert.IsTrue(expectedProduct.EqualsToModel(productEntry));
        }
        

    }
}
