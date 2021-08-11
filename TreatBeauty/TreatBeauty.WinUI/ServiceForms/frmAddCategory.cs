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
using TreatBeauty.Model;
using System.IO;

namespace TreatBeauty.WinUI.ServiceForms
{
    public partial class frmAddCategory : Form
    {
        private readonly ApiService _categoryService = new ApiService("Category");
        public frmAddCategory()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = "";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() && PictureBoxValidator.ValidatePictureBox(pbxImage, errorProvider, btnUploadPhoto))
            {
                Category request = new Category()
                {
                    Name = txtName.Text,
                    Photo = ImageHelper.ConvertFromImageToByte(pbxImage.Image)
                };
                await _categoryService.Insert<Model.Category>(request);
                MessageBox.Show(Resource.SuccessAdd);
                this.Hide();
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            var result = ofdImage.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = ofdImage.FileName;

                var file = File.ReadAllBytes(fileName);
                pbxImage.Image = Image.FromFile(fileName);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void frmAddCategory_Load(object sender, EventArgs e)
        {

        }
    }
}
