using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Model;
using static TreatBeauty.Services.TermCustomService;

namespace TreatBeauty.Interfaces
{
    public interface ITermCustomService
    {
        List<SalonCustom> GetAll(TermCustomSearchObject search = null);
    }
}
