using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Interfaces;

namespace TreatBeauty.Services
{
    public class CustomerService : CrudService<Model.Customer, Database.Customer, Model.CustomerSearchObject, object, object>, ICustomerService
    {
        public CustomerService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}