﻿using FinalProject.Data;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Forms
{
    public partial class CustomerAddForm : Form
    {
        public CustomerAddForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            

            //Customer object
            Customer custToAdd = new Customer()
            {
                FirstName = txtFName.Text,
                MiddleName = txtMName.Text,
                LastName = txtLName.Text,
                EmailAddress = txtEmail.Text,
                CompanyName = txtCompName.Text,
                SalesPerson = txtSalesPerson.Text,
                Phone = txtPhone.Text,
                Suffix = txtSuffix.Text,
                PasswordHash = txtPassHash.Text,
                PasswordSalt = txtPassSalt.Text

            };

            //ICustomerUtility
            ICustomerUtility custUtil = DependencyInjectorUtility.GetCustomerUtility();

            //UpdateCustomer
            try
            {
                custUtil.AddCustomerUtility(custToAdd);
            }
            catch (Exception ex)
            {
                //Logging*
                //Error Handling*
                this.Close();
            }
            //Close the form
            this.Close();
        }
    }
}
