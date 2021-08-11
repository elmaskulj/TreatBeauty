using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatBeauty.WinUI.CurrentUser
{
    public class CurrentUser
    {
        private static string _globalVar = "";
        public static string GlobalVar
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }
    }
}
