using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Vendors.API.Models;
using Vendors.Services;
using Vendors.Services.Models;
using Vendors.Services.Repositories;

namespace Vendors.API.Controllers
{
    public abstract class BaseController<TViewModel,TDataModel,TRepository> :Controller 
        where TViewModel: Models.IModel
        where TRepository:IRepository<TDataModel> 
        where TDataModel : Services.Models.IModel
    {
        protected readonly IDataService _service;
        protected TRepository Repo
        {
            get
            {
                return _service.GetRepository<TRepository, TDataModel>();
            }
        }
        protected abstract string RouteNameGet { get; }
        public BaseController(IDataService service)
        {
            _service=service;
        }

        public virtual IEnumerable<TViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TViewModel>>(Repo.GetAll());
        }


        public virtual IActionResult GetById(long id)
        {
            var item = Repo.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        public virtual IActionResult Create(TViewModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            
            TDataModel entry = Repo.Add(Mapper.Map<TViewModel, TDataModel>(item));
            item = Mapper.Map<TDataModel, TViewModel>(entry);
            return CreatedAtRoute(RouteNameGet, new { id = item.Id }, item);
        }


        public virtual IActionResult Update(long id, TViewModel item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var _item = Repo.Get(item.Id);
            if (_item == null)
            {
                return NotFound();
            }
            Repo.Update(Mapper.Map<TViewModel, TDataModel>(item));
            return new NoContentResult();
        }

        public virtual IActionResult UpdateRange(IEnumerable<TViewModel> items)
        {
            if (items == null || items.Count() == 0)
            {
                return BadRequest();
            }

            var titlesNumber = Repo.Count(t => (from i in items select i.Id).Contains(t.Id));
            if (titlesNumber != items.Count())
            {
                return NotFound();
            }
            Repo.UpdateRange(Mapper.Map<IEnumerable<TViewModel>, IEnumerable<TDataModel>>(items));
            return new NoContentResult();
        }


        public virtual IActionResult Delete(long id)
        {
            var item = Repo.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            Repo.Remove(id);
            return new NoContentResult();
        }

        public virtual IActionResult DeleteRange(IEnumerable<long> ids)
        {
            if (ids == null || ids.Count() == 0)
            {
                return BadRequest();
            }

            var itemCount = Repo.Count(t => (ids).Contains(t.Id));
            if (itemCount != ids.Count())
            {
                return NotFound();
            }

            Repo.RemoveRange(ids);
            return new NoContentResult();
        }
        public virtual IEnumerable<TViewModel> Search(string keyword)
        {
            
            return Mapper.Map<IEnumerable<TViewModel>>(Repo.Search(WebUtility.UrlDecode(keyword)));

        }
    }
}
