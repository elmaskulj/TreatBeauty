using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Interfaces;

namespace TreatBeauty.Services
{
    public class CrudService<T, TDB, TSearch, TInsert, TUpdate> : ReadService<T, TDB, TSearch>, 
        ICrudService<T,TSearch, TInsert, TUpdate>
        where T : class where TDB : class where TSearch : class where TInsert : class where TUpdate : class
    {
        public CrudService(MyContext context, IMapper mapper) : base(context, mapper) { }
        public virtual T Insert(TInsert Insert)
        {
            var set = _context.Set<TDB>();
            var entity = _mapper.Map<TDB>(Insert);
            set.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<T>(entity);
        }
        public virtual T Update(int Id,TUpdate Update)
        {
            var set = _context.Set<TDB>();
            var entity = set.Find(Id);
            _mapper.Map(Update, entity);
            _context.SaveChanges();
            return _mapper.Map<T>(entity);
        }
        public virtual bool Delete(int Id)
        {
            try
            {
                var set = _context.Set<TDB>();
                var entity = set.Find(Id);
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
