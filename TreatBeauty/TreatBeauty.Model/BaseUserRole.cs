using System;
using System.Collections.Generic;
using System.Text;

namespace TreatBeauty.Model
{
    public class BaseUserRole
    {
        public int Id { get; set; }
        public int BaseUserId { get; set; }
        //public virtual BaseUser BaseUser { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
