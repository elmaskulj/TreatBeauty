
using TreatBeauty.Database;
using TreatBeauty.Interfaces;
using TreatBeauty.Model.Requests;
using TreatBeauty.Model;


namespace TreatBeauty.Controllers
{
    public class TermController : CrudController<Model.Term, object, TermInsertRequest, TermInsertRequest>
    {
        public TermController(ICrudService<Model.Term, object, TermInsertRequest, TermInsertRequest> service) : base(service) { }
    }
}

