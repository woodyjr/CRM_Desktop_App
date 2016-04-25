using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.Models;
using System.IO;
using FinalProject.ProductForms.View_Model;

namespace FinalProject.ProductForms.User_Controls
{
    public partial class ucProdSearch : UserControl
    {
        private Product _product;
        public ucProdSearch()
        {
            InitializeComponent();
        }

        public ucProdSearch(Product product):this()
        {
            _product = product;
        }
        private void ucProdSearch_Load(object sender, EventArgs e)
        {

            lblName.Text = _product.Name;
            lblPrice.Text = string.Format("{0:c}", _product.ListPrice);
            Stream picStream = new MemoryStream(_product.ThumbNailPhoto);
            picBoxProduct.Image = new System.Drawing.Bitmap(picStream);

            //Register double click for all
            foreach (Control child in this.Controls)
            {
                child.MouseDoubleClick += ucProdSearch_MouseDoubleClick;
            }

        }

        private void ucProdSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Variables
            ProductUpdateForm prodUpdateForm = new ProductUpdateForm(_product.ProductID);
            prodUpdateForm.ShowDialog();
        }
    }
}
