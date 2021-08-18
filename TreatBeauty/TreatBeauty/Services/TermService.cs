using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Model.Requests;

namespace TreatBeauty.Services
{
    public class TermService: CrudService<Model.Term, Database.Term, object, TermInsertRequest, TermInsertRequest>
    {
        public TermService(MyContext context, IMapper mapper) : base(context, mapper) { }
    }
}
