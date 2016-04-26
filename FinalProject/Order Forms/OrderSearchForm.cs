using FinalProject.Models;
using FinalProject.Order_Forms.View_Model;
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
    public partial class OrderSearchForm : Form
    {
        public OrderSearchForm()
        {
        InitializeComponent();
        }
        private void btnOrderSearch_Click(object sender, EventArgs e)
        {
            //Injector for both searches
            IOrderUtility orderUtil = DependencyInjectorUtility.GetOrdersUtility();
            List<Order> AllOrders = orderUtil.GetSalesOrder();

            string search = txtOrderSearch.Text;

            /*************************************Return all orders for blank search*******************************************/
            if (search == "")
            {
                
                List<OrderSearchViewModel> osVMCollection = new List<OrderSearchViewModel>();

                foreach (Order OrderDTO in AllOrders)
                {
                    //create new view model object
                    OrderSearchViewModel osVM = new OrderSearchViewModel(OrderDTO);

                    //add to pVMVollection collection
                    osVMCollection.Add(osVM);
                }
                //datasource grid view
                dgvOrderSearch.DataSource = null;
                dgvOrderSearch.DataSource = osVMCollection;
            }
            /*************************************Return orders for GOOD search************************************************/
            else
            {
                int ordersearch = int.Parse(txtOrderSearch.Text);
                //good search
                List<Order> orderSearchResults = orderUtil.OrderSearch(ordersearch);

                List<OrderSearchViewModel> osNVMCollection = new List<OrderSearchViewModel>();
            foreach (Order ordersDTO in orderSearchResults)
            {
                //create new view model object
                OrderSearchViewModel osVM = new OrderSearchViewModel(ordersDTO);

                //add to psVMVollection collection
                osNVMCollection.Add(osVM);
            }
                dgvOrderSearch.DataSource = null;
                dgvOrderSearch.DataSource = osNVMCollection;
            }

        }

        private void dgvOrderSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderSearchViewModel orderVM = null;
            if (dgvOrderSearch.SelectedRows.Count > 0)
            {
                orderVM = (OrderSearchViewModel)dgvOrderSearch.SelectedRows[0].DataBoundItem;
            }
            if (orderVM == null) { return; /*Exit the Function*/}
            OrderUpdateForm orderUpdateForm = new OrderUpdateForm(orderVM.CustomerID);
            orderUpdateForm.ShowDialog();
            
        }

        private void OrderSearchForm_Load(object sender, EventArgs e)
        {

        }
    }
}

