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

        public CustomerUpdateForm(int id) 
        {
            InitializeComponent();
            this.id = id;
        }

        private void CustomerUpdateForm_Load(object sender, EventArgs e)
        {
            //Variables
            Customer customer;

            //Load Customer
            ICustomerUtility custUtil = DependencyInjectorUtility.GetCustomerUtility();
            customer = custUtil.GetCustomers(id);

            //Populate the form
            txtFName.Text = customer.FirstName;
            txtMName.Text = customer.MiddleName;
            txtLName.Text = customer.LastName;
            txtEmail.Text = customer.EmailAddress;
            txtCompName.Text = customer.CompanyName;
            txtSalesPerson.Text = customer.SalesPerson;
            txtPhone.Text = customer.Phone;

        }
    }
}
