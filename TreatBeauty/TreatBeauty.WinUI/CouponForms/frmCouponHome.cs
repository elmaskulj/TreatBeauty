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

namespace TreatBeauty.WinUI.CouponForms
{
    public partial class frmCouponHome : Form
    {
        private readonly ApiService _couponService = new ApiService("Coupon");


        public frmCouponHome()
        {
            InitializeComponent();
        }
        public async void LoadData()
        {
            var result = await _couponService.GetAll<List<Coupon>>();
            if (result != null)
            {
                dataGridView1.DataSource = result;
                StyleDataGridView();
            }
        }
        private void frmCouponHome_Load(object sender, EventArgs e)
        {
             LoadData();
        }
        private void StyleDataGridView()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["Id"].Visible = false;
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

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmAddCoupon frmAddCoupon = new frmAddCoupon();
            frmAddCoupon.Show();
        }
    }
}
