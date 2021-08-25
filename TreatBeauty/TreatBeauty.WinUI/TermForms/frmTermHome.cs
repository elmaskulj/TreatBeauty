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
            //if (UserHelper.IsCurrentUserSuAdmin(ApiService.UserRoles))
            //{
            result = await _salonService.GetAll<List<Salon>>();
            //result.Insert(0, new Salon());
            //}
            //else
            //{
            //    var salon = await _salonService.GetById<Salon>(ApiService.CurrentUserSalonId);
            //    result.Add(salon);
            ////}
            cmbSalon.ValueMember = "Id";
            cmbSalon.DisplayMember = "Name";
            cmbSalon.DataSource = result;
        }


        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var date = this.dateTimePicker?.Value.Date;
            if (int.TryParse(cmbSalon.SelectedValue.ToString(), out int SalonId) && date!=null)
            {
                TermSearchObject search = new TermSearchObject()
                {
                    SalonId = SalonId,
                    Date = date.Value,
                    IsReport = false,
                    IncludeList = new string[]
                    {
                        "Service",
                        "Employee"
                    }
                };
                var result = await _termService.GetAll<List<Term>>(search);

                pnlHome.Controls.Clear();

            }
            else
            {
                MessageBox.Show(Resource.ErrorMsg);
            }

        }

        private async void frmTermHome_Load(object sender, EventArgs e)
        {
            await LoadSalons();
        }
    }
}
