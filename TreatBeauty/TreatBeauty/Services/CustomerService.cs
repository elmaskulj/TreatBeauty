using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public override IEnumerable<Model.Customer> Get(Model.CustomerSearchObject search)
        {
            if (search!=null && search.ReportData)
                return GetDataForReport(search);

            var entity = _context.Set<Database.Customer>().AsQueryable();

            var list = entity.ToList();

            return _mapper.Map<List<Model.Customer>>(list);
        }
        private List<Model.Customer> GetDataForReport(Model.CustomerSearchObject search)
        {
            var query = from t in _context.Terms
                        join c in _context.Customers on t.CustomerId equals c.Id
                        join bu in _context.BaseUsers on c.Id equals bu.Id
                        join e in _context.Employees on t.EmployeeId equals e.Id
                        where e.SalonId == search.SalonId
                        group new { bu } by new { bu.FirstName,bu.LastName,bu.Id,bu.PhoneNumber} into g
                        select new{ FirstName = g.Key.FirstName, LastName = g.Key.LastName, Count = g.Count(), Id = g.Key.Id,Phone=g.Key.PhoneNumber };

            List<Model.Customer> list = query.OrderByDescending(x => x.Count).Select(x => new Model.Customer { Id = x.Id, BaseUser = new Model.BaseUser { FirstName=x.FirstName,LastName=x.LastName,Id=x.Id,PhoneNumber=x.Phone}}).Take(5).ToList();

            return list;
        }

    }
}