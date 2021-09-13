using System.Windows.Forms;
using System.ComponentModel;
using System;
using System.Text.RegularExpressions;

namespace TreatBeauty.WinUI
{
    public class Validator
    {
        public static void ObaveznoPoljeTxt(TextBox textBox, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                err.SetError(textBox, poruka);
                e.Cancel = true;
            }
            else
                err.SetError(textBox, null);
        }
        public static void ObaveznoPoljeTxtBrojcanaVrijednost(TextBox textBox, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            Regex r = new Regex(@"^[1-9][\.\d]*(,\d+)?$");
           if(r.IsMatch(textBox.Text.ToString()))
            {
                err.SetError(textBox, null);
            }
            else
            {
                err.SetError(textBox, poruka);
                e.Cancel = true;

            }
        }
        //public static void ValidanDecimalFormat(TextBox textBox, CancelEventArgs e, ErrorProvider err, string poruka)
        //{
        //    if (textBox.Value.Date < DateTime.Now.Date)
        //    {
        //        err.SetError(date, poruka);
        //        e.Cancel = true;
        //    }
        //    else
        //        err.SetError(date, null);
        //}
        public static void ValidanDatum(DateTimePicker date, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (date.Value.Date< DateTime.Now.Date)
            {
                err.SetError(date, poruka);
                e.Cancel = true;
            }
            else
                err.SetError(date, null);
        }
        public static void ObaveznoPoljeDuzina(TextBox txtBox, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (txtBox.Text.Length > 255)
            {
                err.SetError(txtBox, poruka);
                e.Cancel = true;
            }
            else
                err.SetError(txtBox, null);
        }

        public static bool ObaveznoPoljeText(TextBox txtBox, ErrorProvider err, string poruka)
        {
            if (string.IsNullOrWhiteSpace(txtBox.Text))
            {
                err.SetError(txtBox, poruka);
                return false;
            }
            else
                err.SetError(txtBox, null);
            return true;
        }

        public static bool ObaveznoCombo(ComboBox cmb, ErrorProvider err, string poruka)
        {
            if (string.IsNullOrWhiteSpace(cmb.Text))
            {
                err.SetError(cmb, poruka);
                return false;
            }
            else
                err.SetError(cmb, null);
            return true;
        }

        public static void ObaveznoPoljeComboBox(ComboBox cmb, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (cmb.SelectedValue == null)
            {
                err.SetError(cmb, poruka);
                e.Cancel = true;
            }
            else
                err.SetError(cmb, null);
        }
        public static void ObaveznoPoljeCheckListBox(CheckedListBox clb, CancelEventArgs e, ErrorProvider err, string poruka)
        {
            if (clb.CheckedItems.Count == 0)
            {
                err.SetError(clb, poruka);
                e.Cancel = true;
            }
            else
                err.SetError(clb, null);
        }

        public static bool ObaveznoPoljeSlika(TextBox txtBox, ErrorProvider err, string poruka)
        {
            if (string.IsNullOrWhiteSpace(txtBox.Text))
            {
                err.SetError(txtBox, poruka);
                return false;
            }
            else
                err.SetError(txtBox, null);
            return true;
        }
        public static bool ObaveznoPoljeSlikaPB(PictureBox pbxBox, ErrorProvider err, string poruka)
        {
            if (pbxBox.Image == null || pbxBox == null)
            {
                err.SetError(pbxBox, poruka);
                return false;
            }
            else
                err.SetError(pbxBox, null);
            return true;
        }
    }

}
