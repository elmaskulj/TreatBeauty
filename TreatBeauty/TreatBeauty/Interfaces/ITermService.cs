using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Model;
using TreatBeauty.Model.Requests;

namespace TreatBeauty.Interfaces
{
    public interface ITermService: ICrudService<Model.Term, TermSearchObject, TermInsertRequest, TermInsertRequest>
    {
    }
}
