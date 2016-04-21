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
    public partial class ProductSearchForm : Form
    {
        public ProductSearchForm()
        {
            InitializeComponent();
        }

        private void btnProdSearch_Click(object sender, EventArgs e)
        {
            IProductUtility prodUtil = DependencyInjectorUtility.GetProductsUtility();

            if (string.IsNullOrWhiteSpace(txtProductSearch.Text)) { MessageBox.Show("Product Search value required."); return; }

            //good search
            List<Product> prodSearchResults = prodUtil.ProductSearch(txtProductSearch.Text);

            List<ProductViewModel> psVMCollection = new List<ProductViewModel>();
            foreach (Product prodDTO in prodSearchResults)
            {
                //create new view model object
                ProductViewModel psVM = new ProductViewModel(prodDTO);

                //add to psVMVollection collection
                psVMCollection.Add(psVM);
            }

            //datasource grid view
            dgvProductSearch.DataSource = null;
            dgvProductSearch.DataSource = psVMCollection;
        }
    }
}
