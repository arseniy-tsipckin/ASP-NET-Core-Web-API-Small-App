using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vendors.Services.Models;
using Vendors.Services.TestDataService.Models;

namespace Vendors.Services.TestDataService
{
    public class VendorsDbContext:DbContext
    {
        public VendorsDbContext(DbContextOptions<VendorsDbContext> options) : base(options)
        {
            
        }
        public DbSet<Title>    Titles { get; set; }
        public DbSet<Contact>  Contacts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company>  Companies { get; set; }
        public DbSet<Vendor>   Vendors { get; set; }
    }
}
