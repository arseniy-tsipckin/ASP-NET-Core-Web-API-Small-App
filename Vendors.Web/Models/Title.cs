using AutoMapper;
using AutoMapper.Configuration;
using Vendors.Services.Models;

namespace Vendors.API.Models
{
    public class Title : IModel,IMappingAction<Title,ITitle>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public void Process(Title source, ITitle destination)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
        }
    }
}