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
using FinalProject.Forms;

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

            List<CustomerSearchViewModel> csVMCollection = new List<CustomerSearchViewModel>();
            foreach (Customer customerDTO in searchResults)
            {
                //create new view model object
                CustomerSearchViewModel csVM = new CustomerSearchViewModel(customerDTO);

                //add to csVMVollection collection
                csVMCollection.Add(csVM);
            }

            //datasource grid view
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = csVMCollection;


        }

        private void dgvCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //Variables
            CustomerSearchViewModel customerVM = null;
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                customerVM = (CustomerSearchViewModel)dgvCustomers.SelectedRows[0].DataBoundItem;
            }

            CustomerUpdateForm custUpdateForm = new CustomerUpdateForm(customerVM.CustomerID);
            custUpdateForm.ShowDialog();
        }
    }
}