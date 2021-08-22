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
using TreatBeauty.Model.Requests;
using TreatBeauty.WinUI.helper;

namespace TreatBeauty.WinUI.NewsForms
{
    public partial class frmNewsHome : Form
    {
        private readonly ApiService _salonService = new ApiService("Salon");
        private readonly ApiService _newsService = new ApiService("News");


        public frmNewsHome()
        {
            InitializeComponent();
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
        private async void frmNewsHome_Load(object sender, EventArgs e)
        {
            await LoadSalons();
        }
        private void StyleDataGridView()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Salon"].Visible = false;
            dataGridView1.Columns["SalonId"].Visible = false;
            dataGridView1.Columns["Description"].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.EnableHeadersVisualStyles = false;

            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
            }
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(169, 49, 102);

            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
        }
        private async void cmbSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(cmbSalon.SelectedValue?.ToString(), out int SalonId))
                {
                    NewsSearchObject search = new NewsSearchObject()
                    {
                        SalonId = SalonId,
                        IncludeList= new string[]
                        {
                            "Salon",
                        },
                    };
                    var result= await _newsService.GetAll<IList<News>>(search);
                    if (result != null)
                    {
                        dataGridView1.DataSource = result;
                        StyleDataGridView();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resource.ErrorMsg, ex?.Message);
            }
            
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmAddNew frmAddNew = new frmAddNew();
            FormMaker.CreateForm(frmAddNew, this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            int rowIndex = senderGrid.CurrentCell.RowIndex;
            if (rowIndex != -1)
            {
                var item = senderGrid.Rows[rowIndex].DataBoundItem;

                frmAddNew frm = new frmAddNew(item as News);
                FormMaker.CreateForm(frm, this);
            }

        }
    }
}
