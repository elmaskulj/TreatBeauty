using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreatBeauty.Interfaces;

namespace TreatBeauty.Controllers
{
    public class CrudController<T, TSearch,TInsert,TUpdate> : BaseReadController<T,TSearch> 
        where T:class where TSearch:class where TUpdate :class where TInsert :class
    {
        protected readonly ICrudService<T, TSearch, TInsert, TUpdate> _crudService;
        public CrudController(ICrudService<T, TSearch, TInsert, TUpdate> service) : base(service) {
            _crudService = service;
        }
        [HttpPost]
        public T Insert(TInsert Insert)
        {
           return _crudService.Insert(Insert);
        }
        [HttpPut("{Id}")]
        public T Update(int Id,TUpdate Update)
        {
            return _crudService.Update(Id, Update);
        }
        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
            return _crudService.Delete(Id);
        }
    }
}
