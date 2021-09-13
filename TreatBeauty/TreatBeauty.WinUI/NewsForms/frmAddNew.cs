using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreatBeauty.Model;
using TreatBeauty.Model.Requests;
using TreatBeauty.WinUI.helper;
using System.IO;

namespace TreatBeauty.WinUI.NewsForms
{
    public partial class frmAddNew : Form
    {
        private readonly ApiService _salonService = new ApiService("Salon");
        private readonly ApiService _newsService = new ApiService("News");

        private readonly News _news = null;
        public frmAddNew(News news=null)
        {
            InitializeComponent();
            if (news != null)
                _news = news;

            this.cmbSalon.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public async Task LoadSalons()
        {
            List<Salon> result = new List<Salon>();
            if (UserHelper.IsCurrentUserSuAdmin(ApiService.UserRoles))
            {
                result = await _salonService.GetAll<List<Salon>>();
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

        private void pbxPhoto_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;

                var file = File.ReadAllBytes(fileName);
                pbxPhoto.Image = Image.FromFile(fileName);
            }
        }

        private async void btnAddNews_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren() && PictureBoxValidator.ValidatePictureBox(pbxPhoto, errorProvider, pbxPhoto))
                {
                    if (int.TryParse(cmbSalon.SelectedValue.ToString(), out int SalonId))
                    {
                        NewsInsertRequest request = new NewsInsertRequest()
                        {
                            Title = txtTitle.Text,
                            Description = rtbDescription?.Text,
                            Photo = ImageHelper.ConvertFromImageToByte(pbxPhoto.Image),
                            Active = cbxActive.Checked,
                            SalonId = SalonId,
                            CreatedAt = DateTime.Now
                        };
                        if (_news == null)
                        {
                            await _newsService.Insert<News>(request);
                            MessageBox.Show(Resource.SuccessAdd);

                            frmNewsHome frmNewsHome = new frmNewsHome();
                            FormMaker.CreateForm(frmNewsHome, this);
                        }
                        else
                        {
                            await _newsService.Update<News>(_news.Id,request);
                            MessageBox.Show(Resource.SuccessEdit);

                        }
                    }
                    else
                        MessageBox.Show(Resource.ErrorMsg);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void LoadNewsForEdit()
        {
            if (_news != null)
            {
                txtTitle.Text = _news.Title;
                rtbDescription.Text = _news.Description;
                cbxActive.Checked = _news.Active;
                pbxPhoto.Image = ImageHelper.ConvertFromByteToImage(_news.Photo);

                Dictionary<string, string> comboSource = new Dictionary<string, string>();
                comboSource.Add(_news.SalonId.ToString(), _news.Salon?.Name);

                cmbSalon.DataSource = new BindingSource(comboSource, null);
                cmbSalon.DisplayMember = "Value";
                cmbSalon.ValueMember = "Key";

                cmbSalon.Enabled = false;
            }
        }
        private async void frmAddNew_Load(object sender, EventArgs e)
        {
            if (_news != null)
            {
                LoadNewsForEdit();
                lblHeader.Text = Resource.NewsEdit;
            }
            else
               await LoadSalons();
        }

        private void cmbSalon_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoPoljeComboBox(sender as ComboBox,e, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.RequiredMessage);
        }

    }
}
