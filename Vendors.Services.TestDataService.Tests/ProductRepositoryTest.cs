using Autofac;
using AutoMapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Infrastructure.Automapper;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using Vendors.Services.TestDataService.Models;
using Vendors.Services.TestDataService.Repositories;

namespace Vendors.Services.TestDataService.Tests
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        ContainerBuilder builder;
        IContainer container;
        public ProductRepositoryTest()
        {
            builder = new ContainerBuilder();
            var dataServiceType = 
                Type.GetType("Vendors.Services.TestDataService.DataService, Vendors.Services.TestDataService, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null");
            var dataServiceConnection = "Vendors";
            builder.RegisterType(dataServiceType)
                .As<IDataService>()
                .WithParameter(new TypedParameter(typeof(string), value: dataServiceConnection));

            container = builder.Build();
            var a = Vendors.API.Configuration.MapConfiguration.Profiles;
            Mapper.Initialize(cfg => { cfg.AddProfiles(a); });
        }
        
        [Test]
        public void Create()
        {
            var dataService=container.Resolve<IDataService>();
            var repo=dataService.GetRepository<IProductRepository, IProduct>();

            IProduct product = new Product() { Name = "New Product", CategoryField = new Category { Name = "Some category" } };
            IProduct productEntry= repo.Add(product);
            Assert.IsFalse(new Product() { Name = "New Product", Id = 1,
                Category = new Category { Id = 1, Name = "Some category" } } == product);
        }

    }
}
