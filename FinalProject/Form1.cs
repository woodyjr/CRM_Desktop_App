using FinalProject.Customer_Forms.View_Model;
using FinalProject.Forms;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Tool strip name are not correct
        private void customerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersSearchForm custSearchForm = new CustomersSearchForm();
            custSearchForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerAddForm custAddForm = new CustomerAddForm();
            custAddForm.ShowDialog();
        }
    }
}
