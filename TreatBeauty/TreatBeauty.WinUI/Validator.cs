using System.Windows.Forms;
using System.ComponentModel;

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
            if (cmb.SelectedIndex == 0)
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
