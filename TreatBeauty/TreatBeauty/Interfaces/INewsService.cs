using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Model;
using TreatBeauty.Model.Requests;


namespace TreatBeauty.Interfaces
{
    public interface INewsService:ICrudService<News,NewsSearchObject, NewsInsertRequest, NewsInsertRequest>
    {

    }
}
