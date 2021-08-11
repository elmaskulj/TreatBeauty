using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatBeauty.Database
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BaseUserRole> BaseUserRoles { get; set; }
    }
}
