namespace FinalProject.ProductForms
{
    partial class viewProductsForm
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
            this.dgvViewProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvViewProducts
            // 
            this.dgvViewProducts.AllowUserToAddRows = false;
            this.dgvViewProducts.AllowUserToDeleteRows = false;
            this.dgvViewProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewProducts.Location = new System.Drawing.Point(1, 1);
            this.dgvViewProducts.Name = "dgvViewProducts";
            this.dgvViewProducts.ReadOnly = true;
            this.dgvViewProducts.Size = new System.Drawing.Size(907, 485);
            this.dgvViewProducts.TabIndex = 0;
            this.dgvViewProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewProducts_CellContentClick);
            // 
            // viewProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 488);
            this.Controls.Add(this.dgvViewProducts);
            this.Name = "viewProductsForm";
            this.Text = "All Products";
            this.Load += new System.EventHandler(this.viewProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvViewProducts;
    }
}