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
using TreatBeauty.Model;
using TreatBeauty.Model.Requests;
using TreatBeauty.WinUI.helper;

namespace TreatBeauty.WinUI.ServiceForms
{
    public partial class frmAddService : Form
    {
        private readonly ApiService _categoryService = new ApiService("Category");
        private readonly ApiService _serviceService = new ApiService("Service");
        private readonly ApiService _salonService = new ApiService("Salon");
        private readonly ApiService _salonServicesService = new ApiService("SalonServices");



        private Service _service = null;
        public frmAddService(Service service = null)
        {
            InitializeComponent();

            if (service != null)
                _service = service;

            lblCurrency.Text = Resource.CurrencyKM;
            lblDuration.Text = Resource.DurationMin;
        }
        private async Task LoadSalons()
        {
            List<Salon> result = new List<Salon>();

            if (UserHelper.IsCurrentUserAdmin(ApiService.UserRoles))
            {
                var salon = await _salonService.GetById<Salon>(ApiService.CurrentUserSalonId);
                result.Add(salon);
            }
            else
                result = await _salonService.GetAll<List<Salon>>();

            cmbSalon.ValueMember = "Id";
            cmbSalon.DisplayMember = "Name";
            cmbSalon.DataSource = result;
        }


        private async void frmAddService_Load(object sender, EventArgs e)
        {
            if (_service != null)
            {
                lblHeader.Text = "Uređivanje usluge";
                txtName.Text = _service.Name;
                txtDuration.Text = _service.Duration.ToString();
                txtPrice.Text = _service.Price.ToString();
                await LoadCategories();
                cmbCategory.SelectedText = _service.Category?.Name;
                cmbCategory.SelectedValue = _service.CategoryId;
                cmbSalon.Visible = false;
                lblSalon.Visible = false;
                
                pbxImage.Image = ImageHelper.ConvertFromByteToImage(_service.Photo);
            }
            else
            {
                await LoadCategories();
                await LoadSalons();
            }
        }
        private async Task LoadCategories()
        {
            var result = await _categoryService.GetAll<List<Model.Category>>();

            cmbCategory.DataSource = result;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        private async void btnAddService_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren() && PictureBoxValidator.ValidatePictureBox(pbxImage, errorProvider, btnUploadPhoto))
                {
                    ServiceInsertRequest request = new ServiceInsertRequest()
                    {
                        Name = txtName.Text,
                        Price = decimal.Parse(txtPrice.Text),
                        Duration = decimal.Parse(txtDuration.Text),
                        Photo = ImageHelper.ConvertFromImageToByte(pbxImage.Image),
                        CategoryId = int.Parse(cmbCategory.SelectedValue.ToString())
                    };
                    if (_service == null)
                    {
                        var result =await _serviceService.Insert<Model.Service>(request);
                        int SalonId;
                        if (int.TryParse(cmbSalon.SelectedValue.ToString(), out SalonId))
                        {
                            SalonServices salonService = new SalonServices()
                            {
                                SalonId = SalonId,
                                ServiceId = result.Id
                            };
                            await _salonServicesService.Insert<SalonServices>(salonService);
                            MessageBox.Show(Resource.SuccessAdd);
                        }
                    }
                    else
                    {
                        await _serviceService.Update<Model.Service>(_service.Id, request);
                        MessageBox.Show(Resource.SuccessEdit);
                    }
                    frmServiceHome frmServiceHome = new frmServiceHome();
                    FormMaker.CreateForm(frmServiceHome, this);
                }
            }
            catch (Exception ex)
            {

                throw;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void cmbCategory_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoCombo(sender as ComboBox, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void txtDuration_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
