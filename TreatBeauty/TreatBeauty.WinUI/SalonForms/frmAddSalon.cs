using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreatBeauty.Model.Requests;
using TreatBeauty.WinUI.helper;
using TreatBeauty.Model;

namespace TreatBeauty.WinUI.SalonForms
{
    public partial class frmAddSalon : Form
    {
        private readonly ApiService _cityService = new ApiService("City");
        private readonly ApiService _salonService = new ApiService("Salon");

        private Salon _salon = null;
        public frmAddSalon(Salon salon = null)
        {
            InitializeComponent();

            if (salon != null)
                _salon = salon;
        }
        private async void frmAddSalon_Load(object sender, EventArgs e)
        {
            if (_salon != null)
            {
                lblHeader.Text = "Uređivanje salona";
                txtName.Text = _salon.Name;
                txtLocation.Text = _salon.Location;
                await LoadCities();
                cmbCity.SelectedText = _salon.CityName;
                cmbCity.SelectedValue = _salon.CityId;
                pbxImage.Image = ImageHelper.ConvertFromByteToImage(_salon.Photo);
                rtbDescription.Text = _salon.Description;
            }
            else
                await LoadData();

        }
        public async Task LoadData()
        {
            await LoadCities();
        }
        public async Task LoadCities()
        {
            var result = await _cityService.GetAll<List<Model.City>>();

            result.Insert(0, new Model.City());
            cmbCity.ValueMember = "Id";
            cmbCity.DisplayMember = "Name";
            cmbCity.DataSource = result;
        }

        private void btnUploadPhoto_Click_1(object sender, EventArgs e)
        {
            var result = ofdImage.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = ofdImage.FileName;

                var file = File.ReadAllBytes(fileName);
                pbxImage.Image = Image.FromFile(fileName);
            }
        }

        private async void btnAddSalon_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren() && PictureBoxValidator.ValidatePictureBox(pbxImage, errorProvider, btnUploadPhoto))
                {
                    SalonInsertRequest request = new SalonInsertRequest
                    {
                        Name = txtName.Text,
                        Photo = ImageHelper.ConvertFromImageToByte(pbxImage.Image),
                        CityId = cmbCity.SelectedIndex,
                        Location = txtLocation.Text,
                        Description = rtbDescription.Text,
                    };
                    if (_salon == null)
                    {
                        request.CreatedAt = DateTime.Now;
                        await _salonService.Insert<Model.Salon>(request);
                        MessageBox.Show(Resource.SuccessAdd);
                    }
                    else
                    {
                        request.CreatedAt = _salon.CreatedAt;
                        await _salonService.Update<Model.Salon>(_salon.Id, request);
                        MessageBox.Show(Resource.SuccessEdit);
                    }
                    frmSalonHome frmSalonHome = new frmSalonHome();
                    FormMaker.CreateForm(frmSalonHome, this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resource.ErrorMsg);
            }
        }
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void txtLocation_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void cmbCity_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoCombo(sender as ComboBox, errorProvider, Properties.Resources.RequiredMessage);
        }
    }
}
