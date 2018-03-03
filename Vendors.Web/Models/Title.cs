using AutoMapper;
using AutoMapper.Configuration;
using Vendors.Infrastructure.Automapper;
using Vendors.Services.Models;

namespace Vendors.API.Models
{
    public class Title : IModel, IMap<ITitle>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
    }
}