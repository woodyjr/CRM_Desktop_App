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
    public partial class CustomerUpdateForm : Form
    {
        private int id;

        public CustomerUpdateForm() 
        {
            InitializeComponent();
        }

        public CustomerUpdateForm(int id) : this()
        {
            this.id = id;
        }

        private void CustomerUpdateForm_Load(object sender, EventArgs e)
        {
            //Variables
            Customer customer;

            //Load Customer
            ICustomerUtility customerUtil = DependencyInjectorUtility.GetCustomerUtility();
            customer = customerUtil.GetCustomers(id);

            //Populate the form
            txtFName.Text = customer.FirstName;
            txtMName.Text = customer.MiddleName;
            txtLName.Text = customer.LastName;
            txtEmail.Text = customer.EmailAddress;
            txtCompName.Text = customer.CompanyName;
            txtSalesPerson.Text = customer.SalesPerson;
            txtPhone.Text = customer.Phone;
            txtSuffix.Text = customer.Suffix;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //Customer object
            //Copy the values from the textbox into the new customer object
            Customer custToUpdate = new Customer()
            {
                FirstName = txtFName.Text,
                MiddleName = txtMName.Text,
                LastName = txtLName.Text,
                EmailAddress = txtEmail.Text,
                CompanyName = txtCompName.Text,
                SalesPerson = txtSalesPerson.Text,
                Phone = txtPhone.Text,
                Suffix = txtSuffix.Text,
                CustomerID = this.id

            };

            //IInventoryUtility
            ICustomerUtility custUtil = DependencyInjectorUtility.GetCustomerUtility();

            //UpdateProduct
            try
            {
                custUtil.UpdateCustomer(custToUpdate);
            }
            catch (Exception ex)
            {
                //Logging*
                //Error Handling*
                MessageBox.Show(ex.Message);
            }
            //Close the form
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
