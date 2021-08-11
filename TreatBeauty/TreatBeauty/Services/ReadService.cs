using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Interfaces;

namespace TreatBeauty.Services
{
    public class ReadService<T, TDB, TSearch> : IReadService<T, TSearch> where T :class where TSearch : class where TDB : class
    {
        public MyContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public ReadService(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var entity = _context.Set<TDB>();
            var list = entity.ToList();
            return _mapper.Map<List<T>>(list);
        }

        public virtual T GetById(int Id)
        {
            var entity = _context.Set<TDB>();
            var set = entity.Find(Id);
            return _mapper.Map<T>(set);
        }
    }
}
