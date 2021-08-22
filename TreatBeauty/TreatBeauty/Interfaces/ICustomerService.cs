using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatBeauty.Interfaces
{
    public interface ICustomerService : ICrudService<Model.Customer, Model.CustomerSearchObject, object, object>
    {
    }
}
