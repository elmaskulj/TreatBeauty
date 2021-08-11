using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreatBeauty.WinUI.helper
{
    public class PictureBoxValidator
    {
        public static bool ValidatePictureBox(PictureBox pictureBox,ErrorProvider err,Control control)
        {
            if (pictureBox == null || pictureBox.Image == null)
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
    }
}
