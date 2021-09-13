using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreatBeauty.WinUI.helper;

namespace TreatBeauty.WinUI.SalonForms
{
    public partial class frmSalonHome : Form
    {
        private readonly ApiService _salon = new ApiService("Salon");
        public frmSalonHome()
        {
            InitializeComponent();
            this.MdiParent = frmParent.ActiveForm;
        }
        public async Task LoadData()
        {
            await LoadSalons();
        }
        public async Task LoadSalons(string searchName=null)
        {
            dgvSalons.DataSource = null;
            dgvSalons.Columns.Clear();

            Model.SalonSearchObject search = new Model.SalonSearchObject();
            search.IncludeList = new string[] { "City" };

            if (!string.IsNullOrEmpty(searchName))
                search.Name = searchName;
           
            var result=await _salon.GetAll<List<Model.Salon>>(search);
           
            dgvSalons.DataSource = result;
            dgvSalons.Columns["City"].Visible = false;
            dgvSalons.Columns["CityId"].Visible = false;
            dgvSalons.Columns["Description"].Visible = false;
            dgvSalons.RowHeadersVisible = false;
            dgvSalons.Columns["Id"].Visible = false;
            dgvSalons.Columns["Lat"].Visible = false;
            dgvSalons.Columns["Lng"].Visible = false;



            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            {
                editButton.Name = "btnEdit";
                editButton.HeaderText = "Akcija";
                editButton.Text = "Uredi";
                editButton.UseColumnTextForButtonValue = true;
                editButton.DefaultCellStyle.BackColor = Color.White;
                dgvSalons.Columns.Add(editButton);
            }

        }
        private async void frmSalonHome_Load(object sender, EventArgs e)
        {
            await LoadSalons();
        }

        private async void btnSearchSalon_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchSalon.Text))
                await LoadSalons(txtSearchSalon.Text);
            else
                await LoadSalons();
        }

        private void btnAddSalon_Click(object sender, EventArgs e)
        {
            frmAddSalon addSalon = new frmAddSalon();

            FormMaker.CreateForm(addSalon, this);

        }
        private void dgvSalons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int rowIndex = senderGrid.CurrentCell.RowIndex;
                var item = senderGrid.Rows[rowIndex].DataBoundItem;

                frmAddSalon editSalon = new frmAddSalon(item as Model.Salon);
                FormMaker.CreateForm(editSalon, this);
            }
        }
    }
}
