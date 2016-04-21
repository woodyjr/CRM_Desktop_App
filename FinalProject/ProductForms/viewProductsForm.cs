using FinalProject.Models;
using FinalProject.ProductForms.View_Model;
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

namespace FinalProject.ProductForms
{
    public partial class viewProductsForm : Form
    {
        public viewProductsForm()
        {
            InitializeComponent();
        }

        private void viewProductsForm_Load(object sender, EventArgs e)
        {
            IProductUtility prodUtil = DependencyInjectorUtility.GetProductsUtility();

            List<Product> AllCustomers = prodUtil.GetProductList();

            List<ProductViewModel> pVMCollection = new List<ProductViewModel>();

            foreach (Product ProductDTO in AllCustomers)
            {
                //create new view model object
                ProductViewModel pVM = new ProductViewModel(ProductDTO);

                //add to pVMVollection collection
                pVMCollection.Add(pVM);
            }

            //datasource grid view
            dgvViewProducts.DataSource = null;
            dgvViewProducts.DataSource = pVMCollection;

        }

        private void dgvViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
