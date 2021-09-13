using System;
using System.Windows.Forms;
using TreatBeauty.Model.Requests;
using TreatBeauty.WinUI.helper;
using System.IO;
using System.Drawing;
using TreatBeauty.Model.Enumerations;
using System.Threading.Tasks;
using TreatBeauty.Model;
using System.Collections.Generic;


namespace TreatBeauty.WinUI.EmployeeForms
{
    public partial class frmAddEmployee : Form
    {
        private readonly ApiService _baseUserService = new ApiService("BaseUser");
        private readonly ApiService _employeeService = new ApiService("Employee");
        private readonly ApiService _salonService = new ApiService("Salon");

        private readonly Employee _employee = null;
        public frmAddEmployee(Employee employee = null)
        {
            InitializeComponent();

            if (employee != null)
            {
                _employee = employee;
                lblHeader.Text = "Uređivanje zaposlenika";
            }
            this.cmbSalon.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public async Task LoadSalons()
        {
            List<Salon> result = new List<Salon>();
            if (UserHelper.IsCurrentUserSuAdmin(ApiService.UserRoles))
                result = await _salonService.GetAll<List<Salon>>();
            else
            {
                var salon = await _salonService.GetById<Salon>(ApiService.CurrentUserSalonId);
                result.Add(salon);
            }
            cmbSalon.ValueMember = "Id";
            cmbSalon.DisplayMember = "Name";
            cmbSalon.DataSource = result;
        }

        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren() && PictureBoxValidator.ValidatePictureBox(pbxPhoto, errorProvider, btnUploadPhoto))
                {
                    string password = null;
                    if (_employee == null)
                        password = PasswordGenerator.GetRandomAlphanumericString(10);

                    BaseUser baseUserResult;

                    BaseUserInsertRequest baseUserRequest = new BaseUserInsertRequest
                    {
                        Email = txtEmail?.Text,
                        FirstName = txtFirstName?.Text,
                        LastName = txtLastName?.Text,
                        isActive = true,
                        PhoneNumber = txtPhone?.Text,
                        Password = password,
                        ConfirmPassword = password,
                        RoleId = (int)UserRole.Employee

                    };
                    if (_employee == null)
                        baseUserResult = await _baseUserService.Insert<Model.BaseUser>(baseUserRequest);
                    else
                    {
                        baseUserResult = await _baseUserService.Update<Model.BaseUser>(_employee.Id, baseUserRequest);
                    }

                    var SalonId = _employee != null ? int.Parse(((KeyValuePair<string, string>)cmbSalon.SelectedItem).Key) : (int)cmbSalon.SelectedValue;

                    EmployeeInsertRequest employeeRequest = new EmployeeInsertRequest
                    {
                        Photo = ImageHelper.ConvertFromImageToByte(pbxPhoto.Image),
                        SalonId = SalonId,
                        Id = baseUserResult.Id
                    };
                    if (_employee == null)
                    {
                        await _employeeService.Insert<Model.Employee>(employeeRequest);
                        MessageBox.Show(Resource.SuccessAdd);
                    }
                    else
                    {
                        await _employeeService.Update<Employee>(_employee.Id, employeeRequest);
                        MessageBox.Show(Resource.SuccessEdit);
                    }
                    frmEmployeeHome employeeHome = new frmEmployeeHome();
                    FormMaker.CreateForm(employeeHome, this);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resource.ErrorMsg);
                throw ex;
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            var result = ofdAddPhoto.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = ofdAddPhoto.FileName;

                //var file = File.ReadAllBytes(fileName);
                pbxPhoto.Image = System.Drawing.Image.FromFile(fileName);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void frmAddEmployee_Load(object sender, EventArgs e)
        {
            if (_employee != null)
            {
                LoadEmployeeForEdit();
            }
            else
                await LoadSalons();
        }
        private void LoadEmployeeForEdit()
        {
            txtEmail.Text = _employee.Email;
            txtFirstName.Text = _employee.FirstName;
            txtLastName.Text = _employee.LastName;
            txtPhone.Text = _employee.PhoneNumber;

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add(_employee.SalonId.ToString(), _employee.SalonName);

            cmbSalon.DataSource = new BindingSource(comboSource, null);
            cmbSalon.DisplayMember = "Value";
            cmbSalon.ValueMember = "Key";

            cmbSalon.Enabled = false;
            pbxPhoto.Image = ImageHelper.ConvertFromByteToImage(_employee.Photo);

        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void cmbSalon_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.ObaveznoPoljeComboBox(sender as ComboBox,e, errorProvider, Properties.Resources.RequiredMessage);
        }


        private bool ValidatePictureBox(PictureBox pb, ErrorProvider err, Control control)
        {
            if (pb == null || pbxPhoto.Image == null)
            {
                err.SetError(control, Properties.Resources.RequiredImageMessage);
                return false;
            }
            else
            {
                err.Clear();
                return true;

            }

        }

        private void cmbSalon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
