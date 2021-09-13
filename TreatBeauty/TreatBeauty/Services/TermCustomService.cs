using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Interfaces;
using TreatBeauty.Model;

namespace TreatBeauty.Services
{
    public class TermCustomService:ITermCustomService
    {
        private readonly MyContext _context;
        protected readonly IMapper _mapper;
        public TermCustomService(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public class SalonCustom
        {
            public int SalonId { get; set; }
            public string SalonName { get; set; }
            public byte[] SalonPhoto { get; set; }
            public string CityName{ get; set; }
            public string Location { get; set; }
            public List<ServiceCustom> services { get; set; }



        }
        public class ServiceCustom
        {
            public int ServiceId { get; set; }
            public string  ServiceName{ get; set; }
            public decimal ServicePrice { get; set; }
            public DateTime TermDate { get; set; }
            public int TermId{ get; set; }


        }

        public List<SalonCustom> GetAll(TermCustomSearchObject search=null)
        {
            if (search != null)
            {
                //var x = _context.Terms.FromSqlRaw("usp_GetTermsBySearch {0}, {1}, {2}", search.Location, search.Date, search.ServiceName).ToList();
                //return _mapper.Map<List<TermCustom>>(x);


                var query = from t in _context.Terms
                            join s in _context.Services on t.ServiceId equals s.Id
                            join e in _context.Employees on t.EmployeeId equals e.Id
                            join sa in _context.Salons on e.SalonId equals sa.Id
                            join ci in _context.Cities on sa.CityId equals ci.Id
                            where ((!string.IsNullOrEmpty(search.ServiceName) && s.Name.ToLower().Contains(search.ServiceName.ToLower())) || string.IsNullOrEmpty(search.ServiceName)) &&
                            ((!string.IsNullOrEmpty(search.Location) && sa.Location.Contains(search.Location) || ci.Name.Contains(search.Location)) || string.IsNullOrEmpty(search.Location)) &&
                            ((search.Date.HasValue && t.Date == search.Date.Value.Date) || search.Date == null)
                            select new
                            {
                                //Id = t.Id,
                                SalonId = sa.Id,
                                SalonName = sa.Name,
                                SalonPhoto = sa.Photo,
                                CityName = ci.Name,
                                Location = sa.Location,
                                ServiceName = s.Name,
                                ServicePrice = s.Price,
                                ServiceId = s.Id,
                                //TermDate = t.Date
                            };
                List<SalonCustom> list=new List<SalonCustom>();
                var listWithSalons = query.ToLookup(x => new { SalonId = x.SalonId, x.SalonName, x.SalonPhoto, x.Location, x.CityName }).ToList();
                foreach(var item in listWithSalons.GroupBy(x=>x.Key.SalonId))
                {
                    list.Add(new SalonCustom
                    {
                        SalonId = item.Key,
                        services =new List<ServiceCustom>()
                    });
                }


                foreach (var x in query.Distinct())
                {
                  foreach(var f in list)
                    {
                        if (x.SalonId == f.SalonId)
                        {
                            f.SalonName = x.SalonName;
                            f.SalonPhoto = x.SalonPhoto;
                            f.Location = x.Location;
                            f.CityName = x.CityName;
                            f.services.Add(new ServiceCustom { ServiceId = x.ServiceId, ServiceName = x.ServiceName, ServicePrice = x.ServicePrice.Value /*TermDate = x.TermDate.Value*/ });
                        }
                    }
                }

                return list;

                //List<Model.Procedura> list = query.Select(x => new Model.Procedura
                //{
                //    Location = x.Location,
                //    TerminId = x.Id,
                //    SalonId = x.SalonId,
                //    SalonName = x.SalonName,
                //    SalonPhoto = x.SalonPhoto,
                //    CityName = x.CityName,
                //    ServiceName = x.ServiceName,
                //    ServicePrice = x.ServicePrice,
                //    ServiceId = x.ServiceId,
                //    TermDate = x.TermDate.Value
                //}).ToList();
                //return list;
            }
            return null;
        }
    }
}
