using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreatBeauty.Model;

namespace TreatBeauty.WinUI.TermForms
{
    public partial class TimeItem : UserControl
    {
        public TimeItem()
        {
            InitializeComponent();
        }

        private void TimeItem_Load(object sender, EventArgs e)
        {

        }

        #region Properties

        private Term _termItem;
        private string _time;
        private string _serviceName;


        [Category("Custom props")]
        public string Time
        {
            get { return $"{_termItem?.StartTime} - {_termItem?.EndTime}"; }
            set { _time = value; lblTime.Text = value; }

        }
        [Category("Custom props")]

        public string ServiceName
        {
            get { return _termItem?.Service?.Name; }
            set { _serviceName = value; lblServiceName.Text = value; }
        }
        [Category("Custom props")]
        public Term Term
        {
            get { return _termItem; }
            set { _termItem = value;  }
        }

        #endregion
    }
}
