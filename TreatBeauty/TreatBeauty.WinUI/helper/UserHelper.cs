using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatBeauty.Model;
using TreatBeauty.Model.Enumerations;

namespace TreatBeauty.WinUI.helper
{
    public static class UserHelper
    {
        public static bool IsCurrentUserEmployee(List<BaseUserRole> roles)
        {
            return roles.Any(x => x.RoleId == (int)UserRole.Employee);
        }
        public static bool IsCurrentUserSuAdmin(List<BaseUserRole> roles)
        {
            return true;// return roles.Any(x => x.RoleId == (int)UserRole.SuAdmin);
        }
        public static bool IsCurrentUserAdmin(List<BaseUserRole> roles)
        {
            return false;//return roles.Any(x => x.RoleId == (int)UserRole.Admin);
        }
    }
}
