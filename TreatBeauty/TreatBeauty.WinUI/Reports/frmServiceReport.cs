using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreatBeauty.Model;

namespace TreatBeauty.WinUI.Reports
{
    public partial class frmServiceReport : Form
    {
        private readonly ApiService _service = new ApiService("Service");
        private readonly ApiService _salonService = new ApiService("Salon");


        public frmServiceReport()
        {
            InitializeComponent();
        }
        private async Task<List<Model.Service>> LoadData()
        {
            if (int.TryParse(cmbSalon.SelectedValue.ToString(), out int SalonId))
            {
                if (SalonId > 0)
                {
                    ServiceSearchObject search = new ServiceSearchObject()
                    {
                        SalonId = SalonId,
                    };
                    var result = await _service.GetAll<List<Model.Service>>(search);
                    return result;
                }
            }
            else
            {
                MessageBox.Show(Resource.ErrorMsg);
                return null;
            }
            return null;
        }

        private async void frmServiceReport_Load(object sender, EventArgs e)
        {
            await LoadSalons();
        }

        private async void btnAddCategory_Click(object sender, EventArgs e)
        {
           var result= await LoadData();

            //this.reportViewer.LocalReport.ReportPath = "ServiceReport.rdlc";
            //ReportDataSource rds = new ReportDataSource("ServiceDataSet",result);
            //this.reportViewer.LocalReport.DataSources.Add(rds);
            //this.reportViewer.Refresh();
        }
        private async Task LoadSalons()
        {
            List<Salon> result = new List<Salon>();

            //if (UserHelper.IsCurrentUserAdmin(ApiService.UserRoles))
            //{
            //    var salon = await _salonService.GetById<Salon>(ApiService.CurrentUserSalonId);
            //    result.Add(salon);
            //}
            //else
                result = await _salonService.GetAll<List<Salon>>();

            cmbSalon.ValueMember = "Id";
            cmbSalon.DisplayMember = "Name";
            cmbSalon.DataSource = result;
        }
    }
}
