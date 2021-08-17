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
        private readonly ApiService _salonService = new ApiService("Salon");
        private readonly ApiService _salonServicesService = new ApiService("SalonServices");

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
            await LoadSalons();
            //await LoadServices();
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

        private async Task LoadServices(int salonId)
        {
            try
            {
                SalonServicesSearchObject search = new SalonServicesSearchObject()
                {
                    IncludeList = new string[] {
                    "Service",
                    "Service.Category",
                    "Salon"

                },
                    SalonId = salonId,
                };

                var result = await _salonServicesService.GetAll<IEnumerable<Model.SalonServices>>(search);

                List<Service> serviceList = new List<Service>();

                result.ToList().ForEach(x =>
                {
                    serviceList.Add(x.Service);
                });

                fpnlServices.Controls.Clear();
                foreach (var categoryItem in serviceList.GroupBy(x => new { x.CategoryId, x.Category.Name }).ToList())
                {
                    Label lblCategoryName = new Label()
                    {
                        Text = categoryItem.Key.Name,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.FromArgb(2, 48, 71),
                        Margin = new Padding(8)
                    };

                    fpnlServices.Controls.Add(lblCategoryName);

                    foreach (var listItem in serviceList)
                    {
                        if (listItem.CategoryId == categoryItem.Key.CategoryId)
                        {
                            ServiceListItem serviceItem = new ServiceListItem()
                            {
                                Price = listItem.Price + " KM",
                                Title = listItem.Name,
                                Service = listItem
                            };
                            fpnlServices.Controls.Add(serviceItem);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }

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

        private async void cmbSalon_SelectedIndexChanged(object sender, EventArgs e)
        {

            int salonId;
            if (int.TryParse(cmbSalon.SelectedValue.ToString(), out salonId))
            {
                await LoadServices(salonId);
            }
        }
    }
}
