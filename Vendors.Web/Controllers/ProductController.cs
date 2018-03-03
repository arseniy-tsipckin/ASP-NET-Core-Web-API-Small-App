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
    public class ProductController : BaseController<Product, IProduct, IProductRepository>
    {
        protected override string RouteNameGet => throw new System.NotImplementedException();
        private const string ROUTE_NAME = "GetProduct";
        public ProductController(IDataService service) : base(service)
        {

        }
        [HttpGet]
        public override IEnumerable<Product> GetAll()
        {
            return base.GetAll();
        }
        [HttpGet("{id}", Name = ROUTE_NAME)]
        public override IActionResult GetById(long id)
        {
            return base.GetById(id);
        }
        [HttpPost]
        public override IActionResult Create([FromBody]Product item)
        {
            return base.Create(item);
        }
        [HttpPut("{id}")]
        public override IActionResult Update(long id, [FromBody]Product item)
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
        public override IEnumerable<Product> Search(string keyword)
        {
            return base.Search(keyword);
        }
        [HttpGet("category/{id}")]
        public IEnumerable<Product> GetByCategory(long id)
        {
            return Mapper.Map<IEnumerable<Product>>(Repo.GetByCategory(id));
        }
        

    }
}