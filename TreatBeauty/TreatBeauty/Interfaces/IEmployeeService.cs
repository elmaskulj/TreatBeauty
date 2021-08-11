using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Model;

namespace TreatBeauty.Interfaces
{
    public interface IEmployeeService:ICrudService<Model.Employee, EmployeeSearchObject, Model.Requests.EmployeeInsertRequest, Model.Requests.EmployeeInsertRequest>
    {
    }
}
