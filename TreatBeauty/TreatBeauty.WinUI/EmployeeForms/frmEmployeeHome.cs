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

namespace TreatBeauty.WinUI.EmployeeForms
{
    public partial class frmEmployeeHome : Form
    {
        private readonly ApiService _salonService = new ApiService("Salon");
        private readonly ApiService _employeeService = new ApiService("Employee");

        public frmEmployeeHome()
        {
            InitializeComponent();
        }
        public async Task LoadSalons()
        {
            List<Salon> result = new List<Salon>();

            if (UserHelper.IsCurrentUserAdmin(ApiService.UserRoles)) {
                var salon= await _salonService.GetById<Salon>(ApiService.CurrentUserSalonId);
                result.Add(salon);
            }
            else
            {
                result = await _salonService.GetAll<List<Salon>>();
                result.Insert(0, new Salon());
            }

            cmbSalon.ValueMember = "Id";
            cmbSalon.DisplayMember = "Name";
            cmbSalon.DataSource = result;
        }
        public async Task LoadEmplyees()
        {
            if (cmbSalon.SelectedIndex != 0 || cmbSalon.Items.Count==1)
            {
                int Salonid;
                bool SalonIdOK = Int32.TryParse(cmbSalon.SelectedValue.ToString(), out Salonid);
                if (SalonIdOK) {

                    EmployeeSearchObject searchObject = new EmployeeSearchObject()
                    {
                        IncludeList = new string[] { "BaseUser", "Salon" },
                        SalonId = Salonid
                    };
                    var result = await _employeeService.GetAll<List<Model.Employee>>(searchObject);

                    dgvEmployee.DataSource = result;
                    dgvEmployee.RowHeadersVisible = false;
                    dgvEmployee.Columns["Id"].Visible = false;
                    dgvEmployee.Columns["BaseUser"].Visible = false;
                    dgvEmployee.Columns["Salon"].Visible = false;
                    dgvEmployee.Columns["SalonId"].Visible = false;

                    DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                    {
                        editButton.Name = "btnEdit";
                        editButton.HeaderText = "Akcija";
                        editButton.Text = "Uredi";
                        editButton.UseColumnTextForButtonValue = true;
                        editButton.DefaultCellStyle.BackColor = Color.White;
                        dgvEmployee.Columns.Add(editButton);
                    }
                }
            }

        }



        private async void cmbSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadEmplyees();
        }

        private async void frmEmployeeHome_Load(object sender, EventArgs e)
        {
            await LoadSalons();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmAddEmployee addEmployee = new frmAddEmployee();
            FormMaker.CreateForm(addEmployee, this);
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int rowIndex = senderGrid.CurrentCell.RowIndex;
                var item = senderGrid.Rows[rowIndex].DataBoundItem;

                frmAddEmployee editSalon = new frmAddEmployee(item as Model.Employee);
                FormMaker.CreateForm(editSalon, this);
            }
        }

       
    }
}
