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
            FullAddress fulladdress;

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
            lblCustName.Text = customer.FirstName + " " + customer.LastName;


            //Load address
            fulladdress = customerUtil.GetFullAddress(id);

            //variables
            List<CustomerAddress> customeraddressList;
            List<string> FullAddress = new List<string>();

            //Load customer address
            customeraddressList = customerUtil.GetCustomerAddress(id);

            //Populate groupbox
            if (customeraddressList != null)//As long as the customer in question has addresses
            {

                //loop through list of customer address objects, pulling the AddressType property and adding it to the list 
                foreach (CustomerAddress custadd in customeraddressList)
                {
                    //add Addresstype to the list
                    FullAddress.Add(custadd.AddressType);

                }
            }
            cbAddressType.DropDownStyle = ComboBoxStyle.DropDownList; //combobox read only
            cbAddressType.DataSource = FullAddress;
            

            //Fill in groupbox labels
            lblAddressType.Text = fulladdress.AddressType;
            lblAddressLine1.Text = fulladdress.AddressLine1;
            lblCityStateZip.Text = fulladdress.City + ","+ " " + fulladdress.StateProvince + " " + fulladdress.PostalCode;


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

            //ICustomerUtility
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
            }
            //Close the form
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void gbAddress_Enter(object sender, EventArgs e)
        {

        }

        private void lblState_Click(object sender, EventArgs e)
        {

        }
    }
}
