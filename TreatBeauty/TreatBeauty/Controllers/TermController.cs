
using TreatBeauty.Database;
using TreatBeauty.Interfaces;
using TreatBeauty.Model.Requests;
using TreatBeauty.Model;


namespace TreatBeauty.Controllers
{
    public class TermController : CrudController<Model.Term, TermSearchObject, TermInsertRequest, TermInsertRequest>
    {
        public TermController(ITermService service) : base(service) { }
    }
}

