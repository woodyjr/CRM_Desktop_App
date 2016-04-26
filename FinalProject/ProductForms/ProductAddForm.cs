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

namespace FinalProject.ProductForms
{
    public partial class ProductAddForm : Form
    {
        public ProductAddForm()
        {
            InitializeComponent();
        }

        private void ProductAddForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            //Validate ListPrice, StandardCost and Weight as numbers
            decimal newLP; //New ListPrice
            decimal newSC; //New StandardCost
            decimal newWeight; //New Weight


            if (!decimal.TryParse(txtListPrice.Text, out newLP))
            {
                MessageBox.Show("Standard Cost must be a valid number. $0.00");
                return; //Exit the event handler
            }
            if (!decimal.TryParse(txtStandardCost.Text, out newSC))
            {
                MessageBox.Show("List Price must be a valid number. $0.00");
                return; //Exit the event handler
            }
            if (!decimal.TryParse(txtListPrice.Text, out newWeight))
            {
                MessageBox.Show("Weight must be a valid number.");
                return; //Exit the event handler
            }
            //Product object
            Product prodToAdd = new Product()
            {
                ProductNumber = txtProdNumber.Text,
                Name = txtProdName.Text,
                Color = txtColor.Text,
                ListPrice = newLP,
                Weight = newWeight,
                Size = txtSize.Text,
                StandardCost = newSC,
                SellStartDate = dtpStartDate.Value,
                ModifiedDate = DateTime.Now

            };

            //ICustomerUtility
            IProductUtility prodUtil = DependencyInjectorUtility.GetProductsUtility();

            //UpdateCustomer
            try
            {
                prodUtil.AddProductUtility(prodToAdd);
                
            }
            catch (Exception ex)
            {
                //Logging*
                //Error Handling*
                this.Close();
            }
            //Close the form
            Close();
        }
    }
}
