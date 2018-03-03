using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vendors.Services;
using Vendors.API.Models;
using Vendors.Services.Models;
using Vendors.Services.Repositories;
using AutoMapper;

namespace Vendors.API.Controllers
{
    [Route("api/[controller]")]
    public class VendorController : BaseController<Vendor,
        IVendor,IVendorRepository>
    {
        protected override string RouteNameGet => ROUTE_NAME;
        private const string ROUTE_NAME = "GetVendor";
        public VendorController(IDataService service) : base(service)
        {
        }
        [HttpGet]
        public override IEnumerable<Vendor> GetAll()
        {
            return base.GetAll();
        }
        [HttpGet("{id}", Name = ROUTE_NAME)]
        public override IActionResult GetById(long id)
        {
            return base.GetById(id);
        }
        [HttpPost]
        public override IActionResult Create([FromBody]Vendor item)
        {
            return base.Create(item);
        }
        [HttpPut("{id}")]
        public override IActionResult Update(long id, [FromBody]Vendor item)
        {
            return base.Update(id, item);
        }
        [HttpDelete("{id}")]
        public override IActionResult Delete(long id)
        {
            return base.Delete(id);
        }
        [HttpDelete]
        public override IActionResult DeleteRange([FromBody]IEnumerable<long> ids)
        {
            return base.DeleteRange(ids);
        }
        [HttpGet("search/{keyword}")]
        public override IEnumerable<Vendor> Search(string keyword)
        {
            return base.Search(keyword);
        }
        [HttpGet("title/{id}")]
        public IEnumerable<Vendor> GetByTitle(long id)
        {
            return Mapper.Map<IEnumerable<Vendor>>(Repo.GetByTitle(id));
        }
        [HttpGet("company/{id}")]
        public IEnumerable<Vendor> GetByCompany(long id)
        {
            return Mapper.Map<IEnumerable<Vendor>>(Repo.GetByCompany(id));
        }
        [HttpGet("location/{id}")]
        public IEnumerable<Vendor> GetLocation(long id)
        {
            return Mapper.Map<IEnumerable<Vendor>>(Repo.GetByContact(id));
        }

    }
}