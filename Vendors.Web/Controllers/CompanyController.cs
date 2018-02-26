using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vendors.Services;
using Vendors.API.Models;
using Vendors.Services.Models;
using Vendors.Services.Repositories;

namespace Vendors.API.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : BaseController<Company, ICompany, ICompanyRepository>
    {
        private const string ROUTE_NAME = "GetCompany";
        protected override string RouteName => ROUTE_NAME;
        public CompanyController(IDataService service) : base(service)
        {

        }
        [HttpGet]
        public override IEnumerable<Company> GetAll()
        {
            return base.GetAll();
        }

        [HttpGet("{id}", Name = ROUTE_NAME)]
        public override IActionResult GetById(long id)
        {
            return base.GetById(id);
        }
        [HttpPost]
        public override IActionResult Create([FromBody] Company item)
        {
            return base.Create(item);
        }

        [HttpPut("{id}")]
        public override IActionResult Update(long id, [FromBody] Company item)
        {
            return base.Update(id, item);
        }
        [HttpDelete("{id}")]
        public override IActionResult Delete(long id)
        {
            return base.Delete(id);
        }
        [HttpDelete()]
        public override IActionResult DeleteRange([FromBody]IEnumerable<long> ids)
        {
            return base.DeleteRange(ids);
        }


    }
}