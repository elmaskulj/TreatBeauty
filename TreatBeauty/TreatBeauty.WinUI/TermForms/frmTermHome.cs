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

namespace TreatBeauty.WinUI.TermForms
{
    public partial class frmTermHome : Form
    {
        private readonly ApiService _salonService = new ApiService("Salon");
        private readonly ApiService _termService = new ApiService("Term");

        public frmTermHome()
        {
            InitializeComponent();
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }
        public async Task LoadSalons()
        {
            List<Salon> result = new List<Salon>();
            if (UserHelper.IsCurrentUserSuAdmin(ApiService.UserRoles))
            {
                result = await _salonService.GetAll<List<Salon>>();
                result.Insert(0, new Salon());
            }
            else
            {
                var salon = await _salonService.GetById<Salon>(ApiService.CurrentUserSalonId);
                result.Add(salon);
            }
            cmbSalon.ValueMember = "Id";
            cmbSalon.DisplayMember = "Name";
            cmbSalon.DataSource = result;
        }


        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var date = this.dateTimePicker?.Value.Date;
                if (int.TryParse(cmbSalon?.SelectedValue?.ToString(), out int SalonId) && date != null)
                {
                    TermSearchObject search = new TermSearchObject()
                    {
                        SalonId = SalonId,
                        Date = date.Value,
                        IsReport = false,
                        IncludeList = new string[]
                        {
                        "Service",
                        "Employee",
                        "Employee.BaseUser"
                        }
                    };
                    var result = await _termService.GetAll<List<Term>>(search);

                    LoadDataToDataGrid(result);
                }
                else
                    MessageBox.Show(Resource.ErrorMsg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resource.ErrorMsg,ex.Message);
            }
        }
        public void LoadDataToDataGrid(List<Term>terms)
        {
            this.dgwTerms.DataSource = terms;
            this.dgwTerms.RowHeadersVisible = false;
            this.dgwTerms.Columns["Date"].Visible = false;
            this.dgwTerms.Columns["EmployeeId"].Visible = false;
            this.dgwTerms.Columns["Employee"].Visible = false;
            this.dgwTerms.Columns["CustomerId"].Visible = false;
            this.dgwTerms.Columns["ServiceId"].Visible = false;
            this.dgwTerms.Columns["Service"].Visible = false;
            this.dgwTerms.Columns["StartTime"].Visible = false;
            this.dgwTerms.Columns["EndTime"].Visible = false;
            this.dgwTerms.Columns["Reserved"].Visible = false;

            this.dgwTerms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgwTerms.EnableHeadersVisualStyles = false;
            this.dgwTerms.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
            this.dgwTerms.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(169, 49, 102);

            for (int i = 0; i < this.dgwTerms.Rows.Count; i++)
                this.dgwTerms.Rows[i].DefaultCellStyle.ForeColor = Color.Black;

            //this.dgwTerms.DefaultCellStyle.SelectionBackColor = this.dgwTerms.DefaultCellStyle.BackColor;

        }

        private async void frmTermHome_Load(object sender, EventArgs e)
        {
            await LoadSalons();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddTerm frmAddTerm = new frmAddTerm();
            FormMaker.CreateForm(frmAddTerm, this);
        }

        private void pnlHome_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
