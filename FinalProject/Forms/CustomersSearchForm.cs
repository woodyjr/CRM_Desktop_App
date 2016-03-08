using FinalProject.Models;
using FinalProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
   
    public partial class CustomersSearchForm : Form
    {
        public CustomersSearchForm()
        {
            InitializeComponent();
        }

        private void btnCustomersSearch_Click(object sender, EventArgs e)
        {
            Data.ICustomerUtility custUtil = DependencyInjectorUtility.GetCustomerUtility();

            if (string.IsNullOrWhiteSpace(txtCustomersSearch.Text)) { MessageBox.Show("Customer Search value required."); return; }

            //good search
            List<Customer> searchResults = custUtil.CustomerSearch(txtCustomersSearch.Text);

            List<CustomerSearchViewModels> csVMCollection = new List<CustomerSearchViewModels>();
            foreach (Customer customerDTO in searchResults)
            {
                //create new view model object
                CustomerSearchViewModels csVM = new CustomerSearchViewModels(customerDTO);

                //add to csVMVollection collection
                csVMCollection.Add(csVM);
            }

            //datasource grid view
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = csVMCollection;

            
        }
    }
}
