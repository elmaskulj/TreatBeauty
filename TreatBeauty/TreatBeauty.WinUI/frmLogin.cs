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
        ApiService service = new ApiService("BaseUser");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            ApiService.UserName = txtUserName.Text;
            ApiService.Password = txtPassword.Text;

            try
            {
                var result = await service.GetAll<IEnumerable<Model.BaseUser>>();
                Model.BaseUser user = result.FirstOrDefault(x=>x.Email==ApiService.UserName);
                if (result != null)
                {
                   
                    ApiService.UserRoles = user?.BaseUserRoles;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
