﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreatBeauty.Model;
using TreatBeauty.WinUI.helper;

namespace TreatBeauty.WinUI.TermForms
{
    public partial class frmAddTerm : Form
    {
        private readonly ApiService _salonService = new ApiService("Salon");
        private readonly ApiService _salonServicesService = new ApiService("SalonServices");
        private readonly ApiService _employeeService= new ApiService("Employee");

        public frmAddTerm()
        {
            InitializeComponent();
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "HH:mm tt";
            dtpStart.ShowUpDown = true;

            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "HH:mm tt";
            dtpEnd.ShowUpDown = true;

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
        private async Task LoadEmployee()
        {
            
            cmbEmployee.ResetText();

            if (cmbSalon.SelectedIndex != -1)
            {
                EmployeeSearchObject search = new EmployeeSearchObject()
                {
                    IncludeList = new string[]
                    {"BaseUser", },
                };

                int SalonId;

                if (int.TryParse(cmbSalon.SelectedValue.ToString(), out SalonId))
                    search.SalonId = SalonId;


                List<Employee> result = new List<Employee>();

                result = await _employeeService.GetAll<List<Employee>>(search);

                if (result != null)
                {
                    List<BaseUser> baseUsers = result.Select(x => x.BaseUser).ToList();

                    cmbEmployee.DataSource = baseUsers;
                    cmbEmployee.DisplayMember = "FirstAndLastName";
                    cmbEmployee.ValueMember = "Id";
                }
            }
        }
        private async Task LoadServices()
        {
           
            cmbService.ResetText();

            if (cmbSalon.SelectedIndex != -1)
            {
                List<SalonServices> result = new List<SalonServices>();

                SalonServicesSearchObject search = new SalonServicesSearchObject()
                {
                    IncludeList = new string[] {
                    "Service",
                    }
                };

                int SalonId;

                if (int.TryParse(cmbSalon.SelectedValue.ToString(), out SalonId))
                    search.SalonId = SalonId;

                result = await _salonServicesService.GetAll<List<SalonServices>>(search);

                if (result != null)
                {
                    List<Service> services = result.Select(x => x.Service).ToList();

                    cmbService.DataSource = services;
                    cmbService.ValueMember = "Id";
                    cmbService.DisplayMember = "ServiceForCombo";
                }
            }
        }

        private async void frmAddTerm_Load(object sender, EventArgs e)
        {
            await LoadSalons();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }


        private async void cmbSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadServices();
            await LoadEmployee();
        }
    }
}
