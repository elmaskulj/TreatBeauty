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
using TreatBeauty.WinUI.helper;

namespace TreatBeauty.WinUI.ServiceForms
{
    public partial class ServiceListItem : UserControl
    {
        private readonly ApiService _service = new ApiService("Service");
        public ServiceListItem()
        {
            InitializeComponent();
        }
        #region Properties

        private string _title;
        private Service _serviceItem;
        public string _price { get; set; }
        public Image _icon { get; set; }
        public PictureBox _pbxDelete { get; set; }
        public PictureBox _pbxEdit { get; set; }

        [Category("Custom props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; lblText.Text = value; }
        }
        [Category("Custom props")]

        public string Price
        {
            get { return _price; }
            set { _price = value; lblPrice.Text = value; }
        }

        [Category("Custom props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox1.Image = value; }

        }
        [Category("Custom props")]
        public Service Service
        {
            get { return _serviceItem; }
            set { _serviceItem = value;  }
        }
        #endregion

        private async void pbxDelete_Click(object sender, EventArgs e)
        {
            var result =await  _service.Delete<bool>(_serviceItem.Id);
            if (result)
            {
                MessageBox.Show(Resource.SuccessDelete);
                frmServiceHome frmServiceHome = new frmServiceHome();
                FormMaker.CreateForm(frmServiceHome, this.ParentForm);

            }
            else
                MessageBox.Show(Resource.ErrorMsg);
        }

        private void pbxEdit_Click(object sender, EventArgs e)
        {
            frmAddService frmAddService = new frmAddService(_serviceItem);
            FormMaker.CreateForm(frmAddService, this.ParentForm);
        }

        private void ServiceListItem_Load(object sender, EventArgs e)
        {

        }
    }
}
