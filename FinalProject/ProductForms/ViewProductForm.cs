using FinalProject.Models;
using FinalProject.ProductForms.User_Controls;
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
    public partial class ViewProductForm : Form
    {
        public ViewProductForm()
        {
            InitializeComponent();
        }

        private void btnSearch(object sender, EventArgs e)
        {


        }


        private void btnProductSearch(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            flpProducts.Controls.Clear(); //removes existing controls

            IProductUtility prodUtil = DependencyInjectorUtility.GetProductsUtility();

            if (string.IsNullOrWhiteSpace(txtProductSearch.Text)) { MessageBox.Show("Product Search value required."); return; }


            //good search
            List<Product> prodSearchResults = prodUtil.ProductSearch(txtProductSearch.Text);

            List<ProductViewModel> psVMCollection = new List<ProductViewModel>();
            foreach (Product prodDTO in prodSearchResults)
            {
                ucProdSearch puc = new ucProdSearch(prodDTO);

                flpProducts.Controls.Add(puc);
            }
        }

        private void flpProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ProductViewModel productVM = null;
            ProductUpdateForm prodUpdateForm = new ProductUpdateForm();
            prodUpdateForm.ShowDialog();
        }
    }
}
