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

namespace FinalProject.Order_Forms.View_Model
{
    public partial class OrderUpdateForm : Form
    {
        private int id;

        public OrderUpdateForm()
        {
            InitializeComponent();
        }
        public OrderUpdateForm(int id) : this()
        {
            this.id = id;
        }
        private void OrderUpdateForm_Load(object sender, EventArgs e)
        {
            //Variables
            Order order;

            //Load Order
            IOrderUtility orderUtil = DependencyInjectorUtility.GetOrdersUtility();
            order = orderUtil.GetOrderList(id);


            //Populate the Form with the Order Data
            txtFreightUD.Text = order.Freight.ToString();
            txtShipMethodUD.Text = order.ShipMethod;
            txtTaxAmtUD.Text = order.TaxAmt.ToString();
            dtpDueDateUD.Value = order.DueDate;
            dtpOrderDateUD.Value = order.OrderDate;

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //decimal variables
            decimal udTax;
            decimal udFreight;

            if (!decimal.TryParse(txtTaxAmtUD.Text, out udTax))
            {
                MessageBox.Show("Tax Amount must be a valid number. $0.00");
                return; //Exit the event handler
            }
            if (!decimal.TryParse(txtFreightUD.Text, out udFreight))
            {
                MessageBox.Show("Freight must be a decimal number");
                return; //Exit the event handler
            }

            //Order object
            //Copy the values from the textbox into the new order object
            Order orderToUpdate = new Order()
            {
                DueDate = dtpDueDateUD.Value,
                OrderDate = dtpOrderDateUD.Value,
                ShipMethod = txtShipMethodUD.Text,
                TaxAmt = udTax,
                Freight = udFreight,
                CustomerID = this.id


            };

            //ICustomerUtility
            IOrderUtility orderUtil = DependencyInjectorUtility.GetOrdersUtility();

            //UpdateProduct
            try
            {
                orderUtil.UpdateOrder(orderToUpdate);
            }
            catch (Exception ex)
            {
                //Logging*
                //Error Handling*
            }
            //Close the form
            this.Close();
        }
    }
}
