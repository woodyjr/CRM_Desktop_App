namespace FinalProject.Order_Forms.View_Model
{
    partial class OrderUpdateForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpDueDateUD = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderDateUD = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaxAmtUD = new System.Windows.Forms.TextBox();
            this.txtFreightUD = new System.Windows.Forms.TextBox();
            this.txtShipMethodUD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(356, 203);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(264, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpDueDateUD
            // 
            this.dtpDueDateUD.Location = new System.Drawing.Point(117, 70);
            this.dtpDueDateUD.Name = "dtpDueDateUD";
            this.dtpDueDateUD.Size = new System.Drawing.Size(113, 20);
            this.dtpDueDateUD.TabIndex = 71;
            // 
            // dtpOrderDateUD
            // 
            this.dtpOrderDateUD.Location = new System.Drawing.Point(117, 23);
            this.dtpOrderDateUD.Name = "dtpOrderDateUD";
            this.dtpOrderDateUD.Size = new System.Drawing.Size(113, 20);
            this.dtpOrderDateUD.TabIndex = 70;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 69;
            this.label4.Text = "Due Date";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = "Freight";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Tax Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Ship Method";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Order Date";
            // 
            // txtTaxAmtUD
            // 
            this.txtTaxAmtUD.Location = new System.Drawing.Point(331, 28);
            this.txtTaxAmtUD.Name = "txtTaxAmtUD";
            this.txtTaxAmtUD.Size = new System.Drawing.Size(100, 20);
            this.txtTaxAmtUD.TabIndex = 64;
            // 
            // txtFreightUD
            // 
            this.txtFreightUD.Location = new System.Drawing.Point(331, 73);
            this.txtFreightUD.Name = "txtFreightUD";
            this.txtFreightUD.Size = new System.Drawing.Size(100, 20);
            this.txtFreightUD.TabIndex = 63;
            // 
            // txtShipMethodUD
            // 
            this.txtShipMethodUD.Location = new System.Drawing.Point(117, 118);
            this.txtShipMethodUD.Name = "txtShipMethodUD";
            this.txtShipMethodUD.Size = new System.Drawing.Size(100, 20);
            this.txtShipMethodUD.TabIndex = 62;
            // 
            // OrderUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 239);
            this.Controls.Add(this.dtpDueDateUD);
            this.Controls.Add(this.dtpOrderDateUD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTaxAmtUD);
            this.Controls.Add(this.txtFreightUD);
            this.Controls.Add(this.txtShipMethodUD);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "OrderUpdateForm";
            this.Text = "OrderUpdateForm";
            this.Load += new System.EventHandler(this.OrderUpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpDueDateUD;
        private System.Windows.Forms.DateTimePicker dtpOrderDateUD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaxAmtUD;
        private System.Windows.Forms.TextBox txtFreightUD;
        private System.Windows.Forms.TextBox txtShipMethodUD;
    }
}