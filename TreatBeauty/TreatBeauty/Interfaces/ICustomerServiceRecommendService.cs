using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Model;

namespace TreatBeauty.Interfaces
{
    public interface ICustomerServiceRecommendService
    {
        List<Model.CustomerServiceRecommend> Get(int CustomerId);
    }
}
