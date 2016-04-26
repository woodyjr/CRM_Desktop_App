namespace FinalProject.Order_Forms
{
    partial class OrderSearchForm
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
            this.txtOrderSearch = new System.Windows.Forms.TextBox();
            this.btnOrderSearch = new System.Windows.Forms.Button();
            this.dgvOrderSearch = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orders:";
            // 
            // txtOrderSearch
            // 
            this.txtOrderSearch.Location = new System.Drawing.Point(86, 12);
            this.txtOrderSearch.Name = "txtOrderSearch";
            this.txtOrderSearch.Size = new System.Drawing.Size(315, 20);
            this.txtOrderSearch.TabIndex = 1;
            // 
            // btnOrderSearch
            // 
            this.btnOrderSearch.Location = new System.Drawing.Point(416, 10);
            this.btnOrderSearch.Name = "btnOrderSearch";
            this.btnOrderSearch.Size = new System.Drawing.Size(75, 23);
            this.btnOrderSearch.TabIndex = 2;
            this.btnOrderSearch.Text = "Search";
            this.btnOrderSearch.UseVisualStyleBackColor = true;
            this.btnOrderSearch.Click += new System.EventHandler(this.btnOrderSearch_Click);
            // 
            // dgvOrderSearch
            // 
            this.dgvOrderSearch.AllowUserToAddRows = false;
            this.dgvOrderSearch.AllowUserToDeleteRows = false;
            this.dgvOrderSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderSearch.Location = new System.Drawing.Point(-1, 47);
            this.dgvOrderSearch.Name = "dgvOrderSearch";
            this.dgvOrderSearch.ReadOnly = true;
            this.dgvOrderSearch.Size = new System.Drawing.Size(536, 279);
            this.dgvOrderSearch.TabIndex = 3;
            this.dgvOrderSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderSearch_CellDoubleClick);
            // 
            // OrderSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 326);
            this.Controls.Add(this.dgvOrderSearch);
            this.Controls.Add(this.btnOrderSearch);
            this.Controls.Add(this.txtOrderSearch);
            this.Controls.Add(this.label1);
            this.Name = "OrderSearchForm";
            this.Text = "OrderSearchForm";
            this.Load += new System.EventHandler(this.OrderSearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderSearch;
        private System.Windows.Forms.Button btnOrderSearch;
        private System.Windows.Forms.DataGridView dgvOrderSearch;
    }
}