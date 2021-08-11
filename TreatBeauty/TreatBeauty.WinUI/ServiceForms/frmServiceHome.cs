using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using TreatBeauty.Model;
using TreatBeauty.WinUI.helper;

namespace TreatBeauty.WinUI.ServiceForms
{
    public partial class frmServiceHome : Form
    {
        private readonly ApiService _service = new ApiService("Service");
        private bool isCollapsed = false;
        public frmServiceHome()
        {
            InitializeComponent();
            pnlButtons.Size = pnlButtons.MinimumSize;

            CustomizeScroll();

        }
        private void CustomizeScroll()
        {
            fpnlServices.AutoScroll = false;

            fpnlServices.VerticalScroll.Maximum = 0;
            fpnlServices.VerticalScroll.Visible = false;

            fpnlServices.HorizontalScroll.Maximum = 0;
            fpnlServices.HorizontalScroll.Visible = false;

            fpnlServices.AutoScroll = true;
        }

        private async void frmServiceHome_Load(object sender, EventArgs e)
        {
            await LoadServices();

        }

        private async Task LoadServices()
        {
            ServiceSearchObject search = new ServiceSearchObject()
            {
                IncludeList = new string[] {
                    "Category",
                },
            };

            var result = await _service.GetAll<IEnumerable<Model.Service>>(search);

            foreach (var categoryItem in result.GroupBy(x => new { x.CategoryId, x.Category.Name }).ToList())
            {
                Label lblCategoryName = new Label()
                {
                    Text = categoryItem.Key.Name,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(2, 48, 71),
                    Margin = new Padding(8)
                };

                fpnlServices.Controls.Add(lblCategoryName);

                foreach (var listItem in result)
                {
                    if (listItem.CategoryId == categoryItem.Key.CategoryId)
                    {
                        ServiceListItem serviceItem = new ServiceListItem()
                        {
                            Price = listItem.Price + " KM",
                            Title = listItem.Name,
                            Service=listItem
                        };
                        fpnlServices.Controls.Add(serviceItem);
                    }
                }

            }

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pnlButtons.Size = pnlButtons.MinimumSize;
                isCollapsed = false;
            }
            frmAddCategory frmAddCategory = new frmAddCategory();
            frmAddCategory.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pnlButtons.Size = pnlButtons.MinimumSize;
                isCollapsed = false;
            }
            frmAddService frmAddService = new frmAddService();
            FormMaker.CreateForm(frmAddService, this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pnlButtons.Size = pnlButtons.MinimumSize;
                isCollapsed = false;
            }
            else
            {
                pnlButtons.Size = pnlButtons.MaximumSize;
                isCollapsed = true;

            }

        }
    }
}
