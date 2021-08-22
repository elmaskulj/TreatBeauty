using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Model.Requests;
using TreatBeauty.Interfaces;

namespace TreatBeauty.Services
{
    public class TermService: CrudService<Model.Term, Database.Term, Model.TermSearchObject, TermInsertRequest, TermInsertRequest>, ITermService
    {
        public TermService(MyContext context, IMapper mapper) : base(context, mapper) { }

       
    }
}
