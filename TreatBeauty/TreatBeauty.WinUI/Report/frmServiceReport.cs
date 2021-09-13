using Microsoft.Reporting.WinForms;
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

namespace TreatBeauty.WinUI.Report
{
    public partial class frmServiceReport : Form
    {
        private readonly ApiService _salonService = new ApiService("Salon");
        private readonly ApiService _service = new ApiService("Service");
        public frmServiceReport()
        {
            InitializeComponent();
        }

        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var data = await LoadData();

            serviceDataSet.tblDataTable table = new serviceDataSet.tblDataTable();

            for(int i = 0; i < data.Count; i++)
            {
                serviceDataSet.tblRow red = table.NewtblRow();

                red.Name = data[i].Name;
                red.Price = data[i].Price.HasValue ? Convert.ToDecimal(data[i].Price) : 0;
                red.Duration = data[i].Duration.HasValue ? Convert.ToDecimal(data[i].Duration) : 0;

                table.Rows.Add(red);
            }

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dataSet";
            rds.Value = table;

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.Refresh();


            this.reportViewer1.RefreshReport();

        }
        private async Task LoadSalons()
        {
            List<Salon> result = new List<Salon>();

            if (UserHelper.IsCurrentUserAdmin(ApiService.UserRoles))
            {
                var salon = await _salonService.GetById<Salon>(ApiService.CurrentUserSalonId);
                result.Add(salon);
            }
            else
                result = await _salonService.GetAll<List<Salon>>();

            cmbSalon.ValueMember = "Id";
            cmbSalon.DisplayMember = "Name";
            cmbSalon.DataSource = result;
        }

        private async void frmServiceReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            await LoadSalons();
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
    }
}
