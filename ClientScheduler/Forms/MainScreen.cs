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
using ClientScheduler.Models;
using Microsoft.Extensions.DependencyInjection;


namespace ClientScheduler.Forms
{
    public partial class MainScreen : Form
    {
        private readonly ClientScheduleContext _context;
        private readonly AppointmentService _appointmentService;
        private readonly IServiceProvider _serviceProvider;
        public MainScreen(ClientScheduleContext context, AppointmentService appointmentService, IServiceProvider serviceProvider)
        {
            _context = context;
            _appointmentService = appointmentService;
            _serviceProvider = serviceProvider;

            InitializeComponent();
            appointmentsdgv.DataSource = _appointmentService.GetAllAppointments();


            //cleaning up DGV
            appointmentsdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentsdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            appointmentsdgv.MultiSelect = false;
            appointmentsdgv.RowHeadersVisible = false;
            appointmentsdgv.ReadOnly = true;
            appointmentsdgv.AllowUserToAddRows = false;

            //Formatting collumn headers
            appointmentsdgv.Columns["AppointmentId"].HeaderText = "Appointment ID";
            appointmentsdgv.Columns["CustomerId"].HeaderText = "Customer ID";
            appointmentsdgv.Columns["UserId"].HeaderText = "User ID";

            //Hiding blank collumns
            //appointmentsdgv.Columns["Title"].Visible = false;
            //appointmentsdgv.Columns["Description"].Visible = false;
            //appointmentsdgv.Columns["Location"].Visible = false;
            //appointmentsdgv.Columns["Contact"].Visible = false;
            //appointmentsdgv.Columns["Url"].Visible = false;
            //appointmentsdgv.Columns["Customer"].Visible = false;
            //appointmentsdgv.Columns["User"].Visible = false;







        }

        private void customerBtn_Click(object sender, EventArgs e)
        {


            var custScreen = _serviceProvider.GetRequiredService<CustomerScreen>();
            custScreen.FormClosed += (s, args) => this.Show();

            this.Hide();

            custScreen.Show();

        }

        private void appointmentsBtn_Click(object sender, EventArgs e)
        {
            var apptScreen = _serviceProvider.GetRequiredService<AppointmentScreen>();
            apptScreen.FormClosed += (s, args) => this.Show();

            this.Hide();

            apptScreen.Show();
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            string selectedOption = "";

            if (rbApptMonth.Checked)
            {
                selectedOption = rbApptMonth.Name;
            }
            else if (rbNumCustByCountry.Checked)
            {
                selectedOption = rbNumCustByCountry.Name;
            }
            else
            {
                selectedOption = rbUserSchedule.Name;
            }



            var reportScreen = _serviceProvider.GetRequiredService<ReportScreen>();

            Program.selectedOption = selectedOption;
            reportScreen.FormClosed += (s, args) => this.Show();
            this.Hide();

            reportScreen.Show();





        }

        private void MonthCalendar_DataChanged(object sender, DateRangeEventArgs e)
        {


            string selectedDate = ("Appointments on " + calender.SelectionStart.ToShortDateString() + " - " + calender.SelectionEnd.ToShortDateString());
            
            lblDate.Text = selectedDate;        
            
            appointmentsdgv.DataSource = _appointmentService.GetAppointmentsByDate(calender.SelectionStart.ToUniversalTime(), calender.SelectionEnd.ToUniversalTime());
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            _appointmentService.apptWarning();
        }

        private void MonthCalendar_DataChanged(object sender, MouseEventArgs e)
        {


            string selectedDate = ("Appointments on " + calender.SelectionStart.ToShortDateString() + " - " + calender.SelectionEnd.ToShortDateString());

            lblDate.Text = selectedDate;

            appointmentsdgv.DataSource = _appointmentService.GetAppointmentsByDate(calender.SelectionStart.ToUniversalTime(), calender.SelectionEnd.ToUniversalTime());

        }
    }
}
