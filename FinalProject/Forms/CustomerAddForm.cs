using FinalProject.Data;
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
            //Validate Customer ID as Number
            int newCustID; //new Customer ID

            if (!int.TryParse(txtCustomerID.Text, out newCustID))
            {
                MessageBox.Show("ID must be a valid number.");
                return; //Exit the event handler
            }

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
                CustomerID = newCustID

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
                MessageBox.Show(ex.Message);
                return;
            }
            //Close the form
            this.Close();
        }
    }
}
