using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatBeauty.Mapping
{
    public class TreatBeutyProfile:Profile
    {
        public TreatBeutyProfile()
        {
            CreateMap<Database.Category, Model.Category>();
            CreateMap<Model.Category, Database.Category>();

            CreateMap<Database.Service, Model.Service>();
            CreateMap<Model.Requests.ServiceInsertRequest, Database.Service>();

            CreateMap<Database.BaseUser, Model.BaseUser>().ReverseMap();
            CreateMap<Model.Requests.BaseUserInsertRequest, Database.BaseUser>();
            CreateMap<Database.Role, Model.Role>();
            CreateMap<Database.BaseUserRole, Model.BaseUserRole>();
            CreateMap<Database.City, Model.City>();
            CreateMap<Database.Salon, Model.Salon>();
            CreateMap<Model.Requests.SalonInsertRequest, Database.Salon>();
            CreateMap<Model.Requests.EmployeeInsertRequest, Database.Employee>();
            CreateMap<Database.Employee, Model.Employee>();
            CreateMap<Database.SalonServices, Model.SalonServices>().ReverseMap();
            CreateMap<Model.Term, Database.Term>().ReverseMap();
            CreateMap<Model.Requests.TermInsertRequest, Database.Term>().ReverseMap();
            CreateMap<Model.News, Database.News>().ReverseMap();
            CreateMap<Model.Requests.NewsInsertRequest, Database.News>();
            CreateMap<Model.Requests.CouponInsertRequest, Database.Coupon>();
            CreateMap<Database.Coupon, Model.Coupon>();
            CreateMap<Database.CustomerCoupon, Model.CustomerCoupon>();
            CreateMap<Database.Customer, Model.Customer>();














        }
    }
}
