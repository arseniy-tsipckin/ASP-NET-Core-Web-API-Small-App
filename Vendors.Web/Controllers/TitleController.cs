using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vendors.Services;
using Vendors.API.Models;
using Vendors.Services.Models;
using Vendors.Services.Repositories;

namespace Vendors.API.Controllers
{
    [Route("api/[controller]")]
    public class TitleController : BaseController<Title,ITitle,ITitlesRepository>
    {
        protected override string RouteName => ROUTE_NAME;
        private const string ROUTE_NAME = "GetTitle";
        public TitleController(IDataService service):base(service)
        {
            
        }
        [HttpGet]
        public override IEnumerable<Title> GetAll()
        {
            return base.GetAll();
        }

        [HttpGet("{id}", Name = ROUTE_NAME)]
        public override IActionResult GetById(long id)
        {
            return base.GetById(id);
        }
        [HttpPost]
        public override IActionResult Create([FromBody] Title title)
        {
            return base.Create(title);
        }
        
        [HttpPut("{id}")]
        public override IActionResult Update(long id, [FromBody] Title item)
        {
            return base.Update(id, item);
        }
        [HttpPut()]
        public override IActionResult UpdateRange([FromBody] IEnumerable<Title> items)
        {
            return base.UpdateRange(items);
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