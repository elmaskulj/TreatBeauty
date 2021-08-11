using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Model.Requests;

namespace TreatBeauty.Interfaces
{
    public interface IServiceService:ICrudService<Model.Service, Model.ServiceSearchObject, ServiceInsertRequest, ServiceInsertRequest>
    {

    }
}
