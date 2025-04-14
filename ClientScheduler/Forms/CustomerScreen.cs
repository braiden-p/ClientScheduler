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
using Microsoft.EntityFrameworkCore;

namespace ClientScheduler.Forms
{
    public partial class CustomerScreen : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        private readonly CustomerService _customer;
        int currentCustomerID = -1;
        public CustomerScreen(CustomerService customer)
        {
            _customer = customer;
            InitializeComponent();

            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

           
            RefreshCustomerData();
            verifyInputs();

            //cleaning up DGV
            customerDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customerDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            customerDgv.MultiSelect = false;
            customerDgv.RowHeadersVisible = false;
            customerDgv.ReadOnly = true;
            customerDgv.AllowUserToAddRows = false;


            //Formatting collumn headers
            customerDgv.Columns["CustomerId"].HeaderText = "Customer ID";
            customerDgv.Columns["CustomerName"].HeaderText = "Customer Name";
            customerDgv.Columns["PhoneNumber"].HeaderText = "Phone";


            saveCustBtn.Enabled = false;

            

        }

        private void saveCustBtn_Click(object sender, EventArgs e)
        {
            //checks in add is selected
            if (addCustRb.Checked == true)
            {
                try
                {
                    _customer.AddCustomer(fullnameTxt.Text.Trim(), addressTxt.Text.Trim(), cityTxt.Text.Trim(), countryTxt.Text.Trim(), phoneTxt.Text.Trim(), zipCodeTxt.Text.Trim());
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //checks if modify is selected
            else if (modifyCustRb.Checked == true && currentCustomerID != -1)
            {
                try
                {
                    _customer.ModifyCustomer(currentCustomerID, fullnameTxt.Text.Trim(), addressTxt.Text.Trim(), cityTxt.Text.Trim(), countryTxt.Text.Trim(), phoneTxt.Text.Trim(), zipCodeTxt.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            RefreshCustomerData();
            clearInputs();
        }

        private void RefreshCustomerData()
        {


            customerDgv.DataSource = _customer.GetAllCustomers();
        }

        private void custDeleteBtn_Click(object sender, EventArgs e)
        {
            if (!verifySelected())
            {
                MessageBox.Show("Please select the customer you would like to delete");
            }
            else
            {
                try
                {
                    DialogResult res = MessageBox.Show($"Are you sure you want to delete {customerDgv.CurrentRow.Cells[1].Value}?" +
                    $" This will also delete any appointments associated with this customer", "Delete Customer", MessageBoxButtons.YesNo);

                    if (res == DialogResult.No)
                    {
                        return;
                    }
                    _customer.DeleteCustomer((int)customerDgv.CurrentRow.Cells[0].Value);
                    MessageBox.Show("Customer Deleted");
                    RefreshCustomerData();
                    clearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private bool verifyInputs()
        {
            string numberPattern = @"^[0-9-]+$";
            string zipPattern = @"^[0-9]+$";
            bool validInput = true;

            if (string.IsNullOrWhiteSpace(fullnameTxt.Text.Trim()))
            {
                fullnameTxt.BackColor = Color.Red;
                errorProvider.SetError(fullnameTxt, "Please enter a valid name");
                validInput = false;
            }
            else 
            {
                fullnameTxt.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(fullnameTxt, "");
            }

            if (string.IsNullOrWhiteSpace(addressTxt.Text.Trim()))
            {
                addressTxt.BackColor = Color.Red;
                errorProvider.SetError(addressTxt, "Please enter a valid address");
                validInput = false;
            }
            else 
            {
                addressTxt.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(addressTxt, "");
            }

            if (string.IsNullOrWhiteSpace(cityTxt.Text.Trim()))
            {
                cityTxt.BackColor = Color.Red;
                errorProvider.SetError(cityTxt, "Please enter a valid city");
                validInput = false;
            }
            else 
            {
                cityTxt.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(cityTxt, "");
            }

            if (string.IsNullOrWhiteSpace(countryTxt.Text.Trim()))
            {
                countryTxt.BackColor = Color.Red;
                errorProvider.SetError(countryTxt, "Please enter a valid country");
                validInput = false;
            }
            else
            {
                countryTxt.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(countryTxt, "");
            }

            if (string.IsNullOrWhiteSpace(phoneTxt.Text.Trim()) ||
                !System.Text.RegularExpressions.Regex.IsMatch(phoneTxt.Text.Trim(), numberPattern))
            {
                phoneTxt.BackColor = Color.Red;
                errorProvider.SetError(phoneTxt, "Please enter a valid phone number");
                validInput = false;
            }
            else 
            {
                phoneTxt.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(phoneTxt, "");
            }

            if (string.IsNullOrWhiteSpace(zipCodeTxt.Text.Trim()) ||
                !System.Text.RegularExpressions.Regex.IsMatch(zipCodeTxt.Text.Trim(), zipPattern))
            {
                zipCodeTxt.BackColor = Color.Red;
                errorProvider.SetError(zipCodeTxt, "Please enter a valid zip code");
                validInput = false;
            }
            else 
            {
                zipCodeTxt.BackColor = System.Drawing.Color.White;
                errorProvider.SetError(zipCodeTxt, "");
            }
            return validInput;
        }

        private bool verifySelected()
        {
            bool selected = true;
            if (!customerDgv.CurrentRow.Selected || customerDgv.CurrentRow == null)
            {
                selected = false;
            }
            return selected;
        }


        private void fullNameChange(object sender, EventArgs e)
        {
            saveCustBtn.Enabled = verifyInputs();

        }

        private void addressChange(object sender, EventArgs e)
        {
            saveCustBtn.Enabled = verifyInputs();

        }

        private void cityChange(object sender, EventArgs e)
        {
            saveCustBtn.Enabled = verifyInputs();

        }

        private void zipChange(object sender, EventArgs e)
        {
            saveCustBtn.Enabled = verifyInputs();

        }

        private void countryChange(object sender, EventArgs e)
        {
            saveCustBtn.Enabled = verifyInputs();

        }

        private void phoneChange(object sender, EventArgs e)
        {
            saveCustBtn.Enabled = verifyInputs();

        }

        private void customerDgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            customerDgv.ClearSelection();
        }

        private void clearCustBtn_Click(object sender, EventArgs e)
        {
            clearInputs();

        }

        private void customerDgv_SelectionChanged(object sender, EventArgs e)
        {
            if (modifyCustRb.Checked == true)
            {
                currentCustomerID = (int)customerDgv.CurrentRow.Cells[0].Value;
                fullnameTxt.Text = customerDgv.CurrentRow.Cells[1].Value.ToString();
                addressTxt.Text = customerDgv.CurrentRow.Cells[2].Value.ToString();
                cityTxt.Text = customerDgv.CurrentRow.Cells[3].Value.ToString();
                countryTxt.Text = customerDgv.CurrentRow.Cells[4].Value.ToString();
                zipCodeTxt.Text = customerDgv.CurrentRow.Cells[5].Value.ToString();
                phoneTxt.Text = customerDgv.CurrentRow.Cells[6].Value.ToString();
            }
            LockInputs();
        }

        private void modifyCustRb_CheckedChanged(object sender, EventArgs e)
        {
            customerDgv.ClearSelection();
            LockInputs();
            
        }

        private void addCustRb_CheckedChanged(object sender, EventArgs e)
        {
            clearInputs();
            LockInputs();
            currentCustomerID = -1;
            
        }

        private void clearInputs() 
        {
            fullnameTxt.Text = "";
            addressTxt.Text = "";
            cityTxt.Text = "";
            countryTxt.Text = "";
            phoneTxt.Text = "";
            zipCodeTxt.Text = "";
        }

        private void LockInputs()
        {
            if (modifyCustRb.Checked && currentCustomerID == -1)
            {
                lblFeedback.Text = "Please select a customer to modify";

                addressTxt.Enabled = false;
                cityTxt.Enabled = false;
                countryTxt.Enabled = false;
                phoneTxt.Enabled = false;
                zipCodeTxt.Enabled = false;
                fullnameTxt.Enabled = false;
                saveCustBtn.Enabled = false;

            }
            else
            {
                addressTxt.Enabled = true;
                cityTxt.Enabled = true;
                countryTxt.Enabled = true;
                phoneTxt.Enabled = true;
                zipCodeTxt.Enabled = true;
                fullnameTxt.Enabled = true;
                saveCustBtn.Enabled = true;
                lblFeedback.Text = "";
            }
        }
    }
}
