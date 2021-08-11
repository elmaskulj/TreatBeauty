using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreatBeauty.WinUI.helper
{
    public static class FormMaker
    {
        public static void CreateForm(Form newForm, Form oldForm)
        {
            newForm.TopLevel = false;
            newForm.AutoScroll = true;

            oldForm.ParentForm.Controls[0].Controls.Add(newForm);
            oldForm.Hide();
            newForm.Show();
        }
        public static void CreateFormFromParent(Form newForm, Form oldForm,Panel panel )
        {
            newForm.MdiParent = oldForm;
            newForm.TopLevel = false;
            newForm.AutoScroll = true;
            panel.Controls.Clear();
            panel.Controls.Add(newForm);
            newForm.Show();
        }

    }
}
