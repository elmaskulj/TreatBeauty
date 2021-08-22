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

namespace TreatBeauty.WinUI.CouponForms
{
    public partial class frmAddCoupon : Form
    {
        private readonly ApiService _couponService = new ApiService("Coupon");

        public frmAddCoupon()
        {
            InitializeComponent();

            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            checkBox1.Checked = true;
        }

        private async void btnAddNews_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren())
                {
                    if (dtpEnd.Value < dtpStart.Value)
                        errorProvider.SetError(dtpEnd as DateTimePicker, Resource.EndDateEarierThenStartDate);
                    else
                        errorProvider.SetError(dtpEnd as DateTimePicker, null);

                    CouponInsertRequest request = new CouponInsertRequest()
                    {
                        StartDate = dtpStart.Value.Date,
                        EndDate = dtpEnd.Value.Date,
                        IsActive = checkBox1.Checked,
                        Title = txtTitle.Text,
                        Value=decimal.Parse(txtValue.Text)
                    };

                    await _couponService.Insert<Coupon>(request);
                    MessageBox.Show(Resource.SuccessAdd);

                    this.Hide();

                    frmCouponHome frmCouponHome = new frmCouponHome();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Resource.ErrorMsg);
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.RequiredMessage);
        }

        private void dtpStart_Validating(object sender, CancelEventArgs e)
        {
            Validator.ValidanDatum(sender as DateTimePicker, e, errorProvider, Resource.PastDateErrorMessageCoupon);
        }

        private void dtpEnd_Validating(object sender, CancelEventArgs e)
        {
            Validator.ValidanDatum(sender as DateTimePicker, e, errorProvider, Resource.PastDateErrorMessageCoupon);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxtBrojcanaVrijednost(sender as TextBox, e, errorProvider, Resource.RequiredNumberValue);

        }
    }
}
