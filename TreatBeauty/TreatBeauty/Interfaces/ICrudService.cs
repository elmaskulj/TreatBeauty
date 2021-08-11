using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatBeauty.Interfaces
{
    public interface ICrudService<T,TSearch,TInsert,TUpdate>:IReadService<T,TSearch>where T:class 
        where TSearch:class where TInsert:class where TUpdate :class
    {
        T Insert(TInsert Insert);
        T Update(int Id,TUpdate Update);
    }
}
