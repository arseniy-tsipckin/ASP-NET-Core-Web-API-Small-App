using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Vendors.Services;
using System.Reflection;
using System;
using StructureMap;
using StructureMap.Configuration;
using Vendors.Services.TestDataService;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Vendors.API.nfrastructure;

namespace Vendors.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration
        {
            get;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var dataServiceConfig = Configuration.GetSection("DataService");
            var dataServiceType =Type.GetType(dataServiceConfig["Type"]);
            var dataServiceConnection = dataServiceConfig["Connection"];
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType(dataServiceType)
                .As<IDataService>()
                .WithParameter(new TypedParameter(typeof(string), value: dataServiceConnection));
                
            var container = builder.Build();
            Mapper.Initialize(cfg => { cfg.AddProfile<AutoMapperProfile>();});
            return new AutofacServiceProvider(container);

        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            
            app.UseMvc();
        }
        
    }
}
