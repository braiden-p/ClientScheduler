using ClientScheduler.Models;
using ClientScheduler.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientScheduler.Forms
{
    public partial class ReportScreen : Form
    {
        private readonly AppointmentService _appointmentService;
        private readonly CustomerService _customerService;
        public string selectedOption { get; set; }
        public ReportScreen(AppointmentService appointmentService, CustomerService customerService)
        {
            _appointmentService = appointmentService;
            _customerService = customerService;
            InitializeComponent();

            //cleaning up DGV
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.MultiSelect = false;
            dgvReport.RowHeadersVisible = false;
            dgvReport.ReadOnly = true;
            dgvReport.AllowUserToAddRows = false;

        }

        private void ReportScreen_Load(object sender, EventArgs e)
        {
            selectedOption = Program.selectedOption;

            if (selectedOption == "rbApptMonth")
            {
                appointmentsReport();
            }
            else if (selectedOption == "rbNumCustByCountry")
            {
                customersReport();
            }
            else if (selectedOption == "rbUserSchedule")
            {
                usersReport();
            }
        }

        private void appointmentsReport()
        {
            dgvReport.DataSource = _appointmentService.GetAppointmentTypesByMonth();

        }

        private void customersReport()
        {
            dgvReport.DataSource = _customerService.GetCustomersByCountry();
        }
        private void usersReport()
        {
            dgvReport.DataSource = _appointmentService.GetAppointmentsOrderedByUser();
        }

        private void dgvReport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvReport.ClearSelection();

        }

        private void reportBackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
