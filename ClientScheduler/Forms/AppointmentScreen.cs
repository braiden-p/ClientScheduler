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
    public partial class AppointmentScreen : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        private readonly AppointmentService _appointment;
        private readonly ClientScheduleContext _context;
        int currentAppointmentID = -1;

        public AppointmentScreen(AppointmentService appointment, ClientScheduleContext context)
        {
            _appointment = appointment;
            _context = context;

            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            InitializeComponent();
            apptDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";

            RefreshAppointmentData();
            setComboBoxes();
            saveApptBtn.Enabled = false;

            //cleaning up DGV
            dgvAppointment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointment.MultiSelect = false;
            dgvAppointment.RowHeadersVisible = false;
            dgvAppointment.ReadOnly = true;
            dgvAppointment.AllowUserToAddRows = false;

            //Formatting collumn headers
            dgvAppointment.Columns["AppointmentId"].HeaderText = "Appointment ID";
            dgvAppointment.Columns["CustomerId"].HeaderText = "Customer ID";
            dgvAppointment.Columns["UserId"].HeaderText = "User ID";

            //Hiding blank collumns
            //dgvAppointment.Columns["Title"].Visible = false;
            //dgvAppointment.Columns["Description"].Visible = false;
            //dgvAppointment.Columns["Location"].Visible = false;
            //dgvAppointment.Columns["Contact"].Visible = false;
            //dgvAppointment.Columns["Url"].Visible = false;
            //dgvAppointment.Columns["Customer"].Visible = false;
            //dgvAppointment.Columns["User"].Visible = false;


        }

        private void setComboBoxes()
        {
            var customerIDs = _appointment.getCustomerIDs();
            var userIDs = _appointment.getUserIDs();

            customerIDcb.Items.AddRange(customerIDs.Cast<object>().ToArray());
            userIDcb.Items.AddRange(userIDs.Cast<object>().ToArray());
        }

        private void RefreshAppointmentData()
        {


            dgvAppointment.DataSource = _appointment.GetAllAppointments();
            verifyInputs();
        }

        private void rbModifyAppt_CheckedChanged(object sender, EventArgs e)
        {
            dgvAppointment.ClearSelection();
            LockInputs();
         
        }
        private void rbAddAppt_CheckedChanged(object sender, EventArgs e)
        {
            clearInputs();
            LockInputs();
            currentAppointmentID = -1;
        }

        private void saveApptBtn_Click(object sender, EventArgs e)
        {
            if (rbAddAppt.Checked == true)
            {
                try
                {
                    if (_appointment.checkForOverlappingAppointment(apptDateTimePicker.Value, apptEndDateTimePicker.Value, Convert.ToInt32(userIDcb.Text), -1, Convert.ToInt32(customerIDcb.Text)))
                    {
                        _appointment.AddAppointment(Convert.ToInt32(customerIDcb.Text), Convert.ToInt32(userIDcb.Text), apptTypeTxt.Text, apptDateTimePicker.Value, apptEndDateTimePicker.Value);
                        RefreshAppointmentData();

                    }
                    else 
                    {
                        throw new Exception("Cannot Schedule overlapping appointments, please pick a different date/time");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            if (rbModifyAppt.Checked == true && currentAppointmentID != -1)
            {
                try
                {
                    if (_appointment.checkForOverlappingAppointment(apptDateTimePicker.Value, apptEndDateTimePicker.Value, Convert.ToInt32(userIDcb.Text), currentAppointmentID, Convert.ToInt32(customerIDcb.Text)))
                    {
                        _appointment.ModifyAppointment(currentAppointmentID, Convert.ToInt32(customerIDcb.Text), Convert.ToInt32(userIDcb.Text), apptTypeTxt.Text, apptDateTimePicker.Value, apptEndDateTimePicker.Value);
                        RefreshAppointmentData();
                    }
                    else 
                    {
                        throw new Exception("Cannot Schedule overlapping appointments, please pick a different date/time");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void clearInputs()
        {
            apptTypeTxt.Text = "";
            customerIDcb.Text = "";
            userIDcb.Text = "";
            apptDateTimePicker.Value = DateTime.Now;

        }

        private void deleteApptBtn_Click(object sender, EventArgs e)
        {
            if (!verifySelected())
            {
                MessageBox.Show("Please select the appointment you would like to delete");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show($"Are you sure you want to delete the appointment with ID # {dgvAppointment.CurrentRow.Cells[0].Value}?", "Delete Appointment", MessageBoxButtons.YesNo);

                    if (res == DialogResult.No)
                    {
                        return;
                    }
                    _appointment.DeleteAppointment((int)dgvAppointment.CurrentRow.Cells[0].Value);
                    MessageBox.Show("Appointment Deleted");
                    RefreshAppointmentData();
                    clearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private bool verifySelected()
        {
            bool selected = true;
            if (!dgvAppointment.CurrentRow.Selected || dgvAppointment.CurrentRow == null)
            {
                selected = false;
            }
            return selected;
        }

        private bool verifyInputs()
        {

            bool validInput = true;

            if (string.IsNullOrWhiteSpace(customerIDcb.Text.Trim()))
            {
                customerIDcb.BackColor = Color.Red;
                errorProvider.SetError(customerIDcb, "Please enter a valid Customer ID");
                validInput = false;
            }
            else
            {
                customerIDcb.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(customerIDcb, "");
            }
            if (string.IsNullOrWhiteSpace(userIDcb.Text.Trim()))
            {
                userIDcb.BackColor = Color.Red;
                errorProvider.SetError(userIDcb, "Please enter a valid User ID");
                validInput = false;
            }
            else
            {
                userIDcb.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(userIDcb, "");
            }
            if (string.IsNullOrWhiteSpace(apptTypeTxt.Text.Trim()))
            {
                apptTypeTxt.BackColor = Color.Red;
                errorProvider.SetError(apptTypeTxt, "Please enter a valid appointment type");
                validInput = false;
            }
            else
            {
                apptTypeTxt.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(apptTypeTxt, "");
            }

            if (apptDateTimePicker.Value >= apptEndDateTimePicker.Value)
            {
                apptDateTimePicker.BackColor = Color.Red;
                apptEndDateTimePicker.BackColor = Color.Red;
                errorProvider.SetError(apptEndDateTimePicker, "End time must be after start time");
                errorProvider.SetError(apptDateTimePicker, "End time must be after start time");
                validInput = false;
            }
            else
            {
                apptDateTimePicker.BackColor = System.Drawing.Color.White;
                apptEndDateTimePicker.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(apptEndDateTimePicker, "");
                errorProvider.SetError(apptDateTimePicker, "");
            }
            if (!_appointment.IsWithinBusinessHours(apptDateTimePicker.Value, apptEndDateTimePicker.Value))
            {
                apptDateTimePicker.BackColor = Color.Red;
                apptEndDateTimePicker.BackColor = Color.Red;
                errorProvider.SetError(apptDateTimePicker, "Please select a valid appointment time Mon-Fri, 9AM - 5PM EST in the future");
                errorProvider.SetError(apptEndDateTimePicker, "Please select a valid appointment time Mon-Fri, 9AM - 5PM EST in the future");
                validInput = false;
            }
            else
            {
                apptDateTimePicker.BackColor = System.Drawing.Color.White;
                apptEndDateTimePicker.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(apptDateTimePicker, "");
                errorProvider.SetError(apptEndDateTimePicker, "");
            }

            return validInput;
        }


        private void apptTypeTxt_TextChanged(object sender, EventArgs e)
        {
            saveApptBtn.Enabled = verifyInputs();
        }

        private void apptDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            saveApptBtn.Enabled = verifyInputs();
        }


        private void customerIDcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveApptBtn.Enabled = verifyInputs();
        }

        private void userIDcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveApptBtn.Enabled = verifyInputs();
        }

        private void apptEndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            saveApptBtn.Enabled = verifyInputs();
        }

        private void dgvAppointment_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAppointment.ClearSelection();
        }

        private void dgvAppointment_SelectionChanged(object sender, EventArgs e)
        {
            
            if (rbModifyAppt.Checked == true)
            {
                currentAppointmentID = (int)dgvAppointment.CurrentRow.Cells[0].Value;
                customerIDcb.Text = dgvAppointment.CurrentRow.Cells[1].Value.ToString();
                userIDcb.Text = dgvAppointment.CurrentRow.Cells[2].Value.ToString();
                apptTypeTxt.Text = dgvAppointment.CurrentRow.Cells[3].Value.ToString();
                apptDateTimePicker.Value = (DateTime)dgvAppointment.CurrentRow.Cells[4].Value;
                apptEndDateTimePicker.Value = (DateTime)dgvAppointment.CurrentRow.Cells[5].Value;
            }
            LockInputs();
        }

        private void LockInputs()
        {
            if (rbModifyAppt.Checked && currentAppointmentID == -1)
            {
                apptTypeTxt.Enabled = false;
                customerIDcb.Enabled = false;
                userIDcb.Enabled = false;
                apptEndDateTimePicker.Enabled = false;
                apptDateTimePicker.Enabled = false;
                lblFeedback.Text = "Please select an appointment to modify";
            }
            else 
            {
                apptTypeTxt.Enabled = true;
                customerIDcb.Enabled = true;
                userIDcb.Enabled = true;
                apptEndDateTimePicker.Enabled = true;
                apptDateTimePicker.Enabled = true;
                lblFeedback.Text = "";
            }
        }

    }
}
