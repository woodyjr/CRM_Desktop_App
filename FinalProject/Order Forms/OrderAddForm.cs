using FinalProject.Models;
using FinalProject.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Order_Forms
{
    public partial class OrderAddForm : Form
    {
        public OrderAddForm()
        {
            InitializeComponent();
        }
        
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            //Decimal variables
            decimal newTax;
            decimal newFRT;
            int newID;

            if (!decimal.TryParse(txtTaxAmt.Text, out newTax))
            {
                MessageBox.Show("Tax Amount must be a valid number. $0.00");
                return; //Exit the event handler
            }
            if (!decimal.TryParse(txtFreight.Text, out newFRT))
            {
                MessageBox.Show("Freight must be a decimal number");
                return; //Exit the event handler
            }
            if (!int.TryParse(txtCustID.Text, out newID))
            {
                MessageBox.Show("ID must be a valid number");
                return; //Exit the event handler
            }
            //Customer object
            Order orderToAdd = new Order()
            {
                OrderDate = dtpOrderDate.Value,
                DueDate = dtpDueDate.Value,
                ShipMethod = txtShipMethod.Text,
                TaxAmt = newTax,
                Freight = newFRT,
                CustomerID = newID

            };

            //ICustomerUtility
            IOrderUtility orderUtil = DependencyInjectorUtility.GetOrdersUtility();

            //UpdateCustomer
            try
            {
                orderUtil.AddOrderUtility(orderToAdd);
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
        private void txtSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
