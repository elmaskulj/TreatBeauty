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
    public partial class frmCustomerReport : Form
    {
        private readonly ApiService _salonService = new ApiService("Salon");
        private readonly ApiService _customerService = new ApiService("Customer");


        public frmCustomerReport()
        {
            InitializeComponent();
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
        private async  void frmCustomerReport_Load(object sender, EventArgs e)
        {
            await LoadSalons();
            this.reportViewer1.RefreshReport();
        }
        private async Task<List<Model.Customer>> LoadData()
        {
            if (int.TryParse(cmbSalon.SelectedValue.ToString(), out int SalonId))
            {
                if (SalonId > 0)
                {
                    CustomerSearchObject search = new CustomerSearchObject()
                    {
                        SalonId = SalonId,
                        ReportData=true,
                        IncludeList=new string[]
                        {
                            "BaseUser",
                        },
                    };
                    var result = await _customerService.GetAll<List<Model.Customer>>(search);
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
        private async void btnAddTerm_Click(object sender, EventArgs e)
        {
            var data = await LoadData();

            customerDataSet.tblCustomerDataTable table = new customerDataSet.tblCustomerDataTable();

            for (int i = 0; i < data.Count; i++)
            {
                customerDataSet.tblCustomerRow red = table.NewtblCustomerRow();

                red.FirstName = data[i].BaseUser.FirstName;
                red.LastName = data[i].BaseUser.LastName;
                red.PhoneNumber = data[i].BaseUser.PhoneNumber;

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
    }
}
