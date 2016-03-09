﻿namespace FinalProject
{
    partial class CustomersSearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomersSearch = new System.Windows.Forms.TextBox();
            this.btnCustomersSearch = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customers:";
            // 
            // txtCustomersSearch
            // 
            this.txtCustomersSearch.Location = new System.Drawing.Point(74, 17);
            this.txtCustomersSearch.Name = "txtCustomersSearch";
            this.txtCustomersSearch.Size = new System.Drawing.Size(275, 20);
            this.txtCustomersSearch.TabIndex = 1;
            // 
            // btnCustomersSearch
            // 
            this.btnCustomersSearch.Location = new System.Drawing.Point(365, 16);
            this.btnCustomersSearch.Name = "btnCustomersSearch";
            this.btnCustomersSearch.Size = new System.Drawing.Size(77, 20);
            this.btnCustomersSearch.TabIndex = 2;
            this.btnCustomersSearch.Text = "Search";
            this.btnCustomersSearch.UseVisualStyleBackColor = true;
            this.btnCustomersSearch.Click += new System.EventHandler(this.btnCustomersSearch_Click);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(0, 48);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.Size = new System.Drawing.Size(456, 213);
            this.dgvCustomers.TabIndex = 3;
            this.dgvCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellContentClick);
            this.dgvCustomers.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellContentDoubleClick);
            this.dgvCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellDoubleClick);
            // 
            // CustomersSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 261);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.btnCustomersSearch);
            this.Controls.Add(this.txtCustomersSearch);
            this.Controls.Add(this.label1);
            this.Name = "CustomersSearchForm";
            this.Text = "CustomersSearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomersSearch;
        private System.Windows.Forms.Button btnCustomersSearch;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private int id;

        public CustomersSearchForm(int id)
        {
            this.id = id;
        }
    }
}