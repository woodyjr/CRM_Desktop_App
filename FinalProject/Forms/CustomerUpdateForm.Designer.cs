namespace FinalProject.Forms
{
    partial class CustomerUpdateForm
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
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.txtSalesPerson = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbAddressType = new System.Windows.Forms.ComboBox();
            this.gbAddress = new System.Windows.Forms.GroupBox();
            this.lblCityStateZip = new System.Windows.Forms.Label();
            this.lblAddressLine1 = new System.Windows.Forms.Label();
            this.lblAddressType = new System.Windows.Forms.Label();
            this.lblCustName = new System.Windows.Forms.Label();
            this.gbAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(112, 44);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(155, 20);
            this.txtFName.TabIndex = 0;
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(112, 81);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(155, 20);
            this.txtMName.TabIndex = 1;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(112, 124);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(155, 20);
            this.txtLName.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(112, 167);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(229, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtCompName
            // 
            this.txtCompName.Location = new System.Drawing.Point(112, 216);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(229, 20);
            this.txtCompName.TabIndex = 4;
            // 
            // txtSalesPerson
            // 
            this.txtSalesPerson.Location = new System.Drawing.Point(112, 266);
            this.txtSalesPerson.Name = "txtSalesPerson";
            this.txtSalesPerson.Size = new System.Drawing.Size(229, 20);
            this.txtSalesPerson.TabIndex = 5;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(112, 313);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(229, 20);
            this.txtPhone.TabIndex = 6;
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(274, 124);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(67, 20);
            this.txtSuffix.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(611, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Middle Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Email Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Company Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sales Person";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Phone";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(700, 359);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(366, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Address";
            // 
            // cbAddressType
            // 
            this.cbAddressType.FormattingEnabled = true;
            this.cbAddressType.Location = new System.Drawing.Point(6, 16);
            this.cbAddressType.Name = "cbAddressType";
            this.cbAddressType.Size = new System.Drawing.Size(394, 21);
            this.cbAddressType.TabIndex = 19;
            // 
            // gbAddress
            // 
            this.gbAddress.Controls.Add(this.cbAddressType);
            this.gbAddress.Controls.Add(this.lblCityStateZip);
            this.gbAddress.Controls.Add(this.lblAddressLine1);
            this.gbAddress.Controls.Add(this.lblAddressType);
            this.gbAddress.Location = new System.Drawing.Point(369, 60);
            this.gbAddress.Name = "gbAddress";
            this.gbAddress.Size = new System.Drawing.Size(406, 273);
            this.gbAddress.TabIndex = 20;
            this.gbAddress.TabStop = false;
            this.gbAddress.Enter += new System.EventHandler(this.gbAddress_Enter);
            // 
            // lblCityStateZip
            // 
            this.lblCityStateZip.AutoSize = true;
            this.lblCityStateZip.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCityStateZip.Location = new System.Drawing.Point(11, 107);
            this.lblCityStateZip.Name = "lblCityStateZip";
            this.lblCityStateZip.Size = new System.Drawing.Size(133, 23);
            this.lblCityStateZip.TabIndex = 2;
            this.lblCityStateZip.Text = "city,state zip";
            this.lblCityStateZip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddressLine1
            // 
            this.lblAddressLine1.AutoSize = true;
            this.lblAddressLine1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressLine1.Location = new System.Drawing.Point(11, 84);
            this.lblAddressLine1.Name = "lblAddressLine1";
            this.lblAddressLine1.Size = new System.Drawing.Size(136, 23);
            this.lblAddressLine1.TabIndex = 1;
            this.lblAddressLine1.Text = "addressLine1";
            this.lblAddressLine1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAddressType
            // 
            this.lblAddressType.AutoSize = true;
            this.lblAddressType.BackColor = System.Drawing.Color.Transparent;
            this.lblAddressType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressType.Location = new System.Drawing.Point(23, 62);
            this.lblAddressType.Name = "lblAddressType";
            this.lblAddressType.Size = new System.Drawing.Size(104, 18);
            this.lblAddressType.TabIndex = 0;
            this.lblAddressType.Text = "address type";
            this.lblAddressType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCustName.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustName.Location = new System.Drawing.Point(320, 9);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(2, 27);
            this.lblCustName.TabIndex = 21;
            // 
            // CustomerUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 394);
            this.Controls.Add(this.lblCustName);
            this.Controls.Add(this.gbAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtSalesPerson);
            this.Controls.Add(this.txtCompName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtMName);
            this.Controls.Add(this.txtFName);
            this.Name = "CustomerUpdateForm";
            this.Text = "Customer Update Form";
            this.Load += new System.EventHandler(this.CustomerUpdateForm_Load);
            this.gbAddress.ResumeLayout(false);
            this.gbAddress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCompName;
        private System.Windows.Forms.TextBox txtSalesPerson;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbAddressType;
        private System.Windows.Forms.GroupBox gbAddress;
        private System.Windows.Forms.Label lblCityStateZip;
        private System.Windows.Forms.Label lblAddressLine1;
        private System.Windows.Forms.Label lblAddressType;
        private System.Windows.Forms.Label lblCustName;
    }
}