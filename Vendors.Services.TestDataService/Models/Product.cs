using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Vendors.Services.Models;
using AutoMapper;
using Vendors.Infrastructure.Automapper;

namespace Vendors.Services.TestDataService.Models
{
    public class Product :AbstractModel, IProduct,IMap<Product>
    {
        public string Name { get; set ; }
        [NotMapped] //EF
        public ICategory Category { get =>CategoryField ; set =>value=CategoryField; }
        [IgnoreMap] //AutoMapper
        public Category CategoryField { get; set; }

        

       
    }
}
