using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using TreatBeauty.Model;
using TreatBeauty.WinUI.helper;

namespace TreatBeauty.WinUI
{
    public partial class frmLogin : Form
    {
        ApiService _baseUserService = new ApiService("BaseUser");
        ApiService _employeeService = new ApiService("Employee");

        public frmLogin()
        {
            InitializeComponent();
        }


        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            ApiService.UserName = txtUserName.Text;
            ApiService.Password = txtPassword.Text;

            try
            {
                var result = await _baseUserService.GetAll<IEnumerable<Model.BaseUser>>();
                Model.BaseUser user = result.FirstOrDefault(x => x.Email == ApiService.UserName);

                if (result != null)
                {
                    ApiService.UserRoles = user?.BaseUserRoles.ToList();
                    var employee = await _employeeService.GetById<Model.Employee>(user.Id);
                    if (employee != null)
                        ApiService.CurrentUserSalonId = employee.SalonId;

                    frmParent frmParent = new frmParent();
                    this.Hide();
                    frmParent.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nije proslo");
            }


        }
    }
}
