using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreatBeauty.WinUI.TermForms
{
    public partial class EmployeeTerm : UserControl
    {
        public EmployeeTerm()
        {
            InitializeComponent();
        }
        #region Properties

        public Image _photo { get; set; }
        public string _firstAndLastName { get; set; }
        public string LastName { get; set; }

        public Panel _pnl { get; set; }

        [Category("Custom props")]
        public string FirstAndLastName
        {
            get { return _firstAndLastName; }
            set { _firstAndLastName = value; lblFirstAndLastName.Text = value; }
        }
        [Category("Custom props")]
        public Image Photo
        {
            get { return _photo; }
            set { _photo = value; pbxPhoto.Image = value; }
        }
        [Category("Custom props")]
        public Panel Panel
        {
            get { return _pnl; }
            set { _pnl = value; pnlTerms = value; }
        }
        #endregion
        private void EmployeeTerm_Load(object sender, EventArgs e)
        {

        }
    }
}
