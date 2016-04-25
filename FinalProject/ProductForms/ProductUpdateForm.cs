using FinalProject.Models;
using FinalProject.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.ProductForms
{
    public partial class ProductUpdateForm : Form
    {
        private int id;
        public ProductUpdateForm()
        {
            InitializeComponent();
        }
        public ProductUpdateForm(int id) : this()
        {
            this.id = id;
        }
        private void ProductUpdateForm_Load(object sender, EventArgs e)
        {
            //Variables
            Product product;

            //Load Product
            IProductUtility prodUtil = DependencyInjectorUtility.GetProductsUtility();
            product = prodUtil.GetProductList(id);

            //Populate the Form with the Product Data
            txtName.Text = product.Name;
            txtListPrice.Text = product.ListPrice.ToString();
            txtStandardPrice.Text = product.StandardCost.ToString();
            txtColor.Text = product.Color;
            txtWeight.Text = product.Weight.ToString();

            //Load picture
            ShowPicture(product.ThumbNailPhoto);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validate UnitPrice as Number
            decimal newLP; //new UnitPrice
            decimal newSC;
            decimal newWeight;

            if (!decimal.TryParse(txtListPrice.Text, out newLP))
            {
                MessageBox.Show("Unit Price must be a valid number, $0.00");
                return; //Exit the event handler
            }
            if (!decimal.TryParse(txtStandardPrice.Text, out newSC))
            {
                MessageBox.Show("Standard Cost must be a valid number, $0.00");
                return; //Exit the event handler
            }
            if (!decimal.TryParse(txtWeight.Text, out newWeight))
            {
                MessageBox.Show("Weight must be a valid number.");
                return; //Exit the event handler
            }

            //Product object
            //Copy the values from the textbox into the new product object
            Product prodToUpdate = new Product()
            {
                ListPrice = newLP,
                Name = txtName.Text,
                StandardCost = newSC,
                Weight = newWeight,
                Color = txtColor.Text,
                SellStartDate = dtpProdUpdate.Value,
                SellEndDate = dtpSellEndDate.Value,
                ProductID = this.id

            };

            //IInventoryUtility
            IProductUtility invUtil = DependencyInjectorUtility.GetProductsUtility();

            //UpdateProduct
            try
            {
                invUtil.UpdateProduct(prodToUpdate);
            }
            catch (Exception ex)
            {
                //Logging*
                //Error Handling*
                MessageBox.Show(ex.Message);
            }
            //Close the form
            this.Close();
        }
            

        private void ShowPicture(byte[] pictureBuffer)
        {
            Stream picStream = new MemoryStream(pictureBuffer);
            picBoxPicture.Image = new Bitmap(picStream);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
