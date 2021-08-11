using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Interfaces;

namespace TreatBeauty.Services
{
    public class CategoryService : CrudService<Model.Category, Database.Category, Model.Category,Model.Category,object>, ICategoryService
    {
        public CategoryService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
