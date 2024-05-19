namespace RestaurantMangement.Forms {
    partial class FResBill {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            btnHome = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblAddr = new Label();
            label8 = new Label();
            label9 = new Label();
            lblStatusFill = new Label();
            lblNameFill = new Label();
            lblEmailFill = new Label();
            lblPhoneFill = new Label();
            lblAddressFill = new Label();
            lblDateFill = new Label();
            lblTotalPriceFill = new Label();
            lblPaymentFill = new Label();
            label11 = new Label();
            dataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            label2 = new Label();
            lblBIllID = new Label();
            lblVoucherID = new Label();
            lblVoucher = new Label();
            guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel3
            // 
            guna2Panel3.BackColor = Color.White;
            guna2Panel3.Controls.Add(btnHome);
            guna2Panel3.Controls.Add(label1);
            guna2Panel3.CustomizableEdges = customizableEdges7;
            guna2Panel3.FillColor = Color.FromArgb(52, 73, 85);
            guna2Panel3.Location = new Point(1, 1);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel3.Size = new Size(1064, 75);
            guna2Panel3.TabIndex = 4;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Transparent;
            btnHome.BorderRadius = 10;
            btnHome.CustomizableEdges = customizableEdges5;
            btnHome.DisabledState.BorderColor = Color.DarkGray;
            btnHome.DisabledState.CustomBorderColor = Color.DarkGray;
            btnHome.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnHome.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnHome.FillColor = Color.FromArgb(80, 114, 123);
            btnHome.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.HoverState.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.Location = new Point(926, 8);
            btnHome.Name = "btnHome";
            btnHome.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnHome.Size = new Size(126, 56);
            btnHome.TabIndex = 3;
            btnHome.Text = "Home";
            btnHome.Click += btnHome_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(403, 18);
            label1.Name = "label1";
            label1.Size = new Size(261, 46);
            label1.TabIndex = 0;
            label1.Text = "Bill Information";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 13.2F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(23, 140);
            label3.Name = "label3";
            label3.Size = new Size(109, 30);
            label3.TabIndex = 5;
            label3.Text = "Bill Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 13.2F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(23, 198);
            label4.Name = "label4";
            label4.Size = new Size(178, 30);
            label4.TabIndex = 6;
            label4.Text = "Customer name: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 13.2F);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(23, 253);
            label5.Name = "label5";
            label5.Size = new Size(176, 30);
            label5.TabIndex = 7;
            label5.Text = "Customer email: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 13.2F);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(504, 198);
            label6.Name = "label6";
            label6.Size = new Size(186, 30);
            label6.TabIndex = 8;
            label6.Text = "Customer phone: ";
            // 
            // lblAddr
            // 
            lblAddr.AutoSize = true;
            lblAddr.BackColor = Color.Transparent;
            lblAddr.Font = new Font("Segoe UI", 13.2F);
            lblAddr.ForeColor = Color.Black;
            lblAddr.Location = new Point(504, 253);
            lblAddr.Name = "lblAddr";
            lblAddr.Size = new Size(96, 30);
            lblAddr.TabIndex = 9;
            lblAddr.Text = "Address:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 13.2F);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(23, 311);
            label8.Name = "label8";
            label8.Size = new Size(58, 30);
            label8.TabIndex = 10;
            label8.Text = "Date";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 13.2F);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(23, 363);
            label9.Name = "label9";
            label9.Size = new Size(112, 30);
            label9.TabIndex = 11;
            label9.Text = "Total Price";
            // 
            // lblStatusFill
            // 
            lblStatusFill.AutoSize = true;
            lblStatusFill.BackColor = Color.Transparent;
            lblStatusFill.Font = new Font("Segoe UI", 13.2F);
            lblStatusFill.ForeColor = Color.Black;
            lblStatusFill.Location = new Point(226, 140);
            lblStatusFill.Name = "lblStatusFill";
            lblStatusFill.Size = new Size(109, 30);
            lblStatusFill.TabIndex = 13;
            lblStatusFill.Text = "Bill Status:";
            // 
            // lblNameFill
            // 
            lblNameFill.AutoSize = true;
            lblNameFill.BackColor = Color.Transparent;
            lblNameFill.Font = new Font("Segoe UI", 13.2F);
            lblNameFill.ForeColor = Color.Black;
            lblNameFill.Location = new Point(226, 198);
            lblNameFill.Name = "lblNameFill";
            lblNameFill.Size = new Size(178, 30);
            lblNameFill.TabIndex = 14;
            lblNameFill.Text = "Customer name: ";
            // 
            // lblEmailFill
            // 
            lblEmailFill.AutoSize = true;
            lblEmailFill.BackColor = Color.Transparent;
            lblEmailFill.Font = new Font("Segoe UI", 13.2F);
            lblEmailFill.ForeColor = Color.Black;
            lblEmailFill.Location = new Point(226, 253);
            lblEmailFill.Name = "lblEmailFill";
            lblEmailFill.Size = new Size(176, 30);
            lblEmailFill.TabIndex = 15;
            lblEmailFill.Text = "Customer email: ";
            // 
            // lblPhoneFill
            // 
            lblPhoneFill.AutoSize = true;
            lblPhoneFill.BackColor = Color.Transparent;
            lblPhoneFill.Font = new Font("Segoe UI", 13.2F);
            lblPhoneFill.ForeColor = Color.Black;
            lblPhoneFill.Location = new Point(708, 198);
            lblPhoneFill.Name = "lblPhoneFill";
            lblPhoneFill.Size = new Size(186, 30);
            lblPhoneFill.TabIndex = 16;
            lblPhoneFill.Text = "Customer phone: ";
            // 
            // lblAddressFill
            // 
            lblAddressFill.AutoSize = true;
            lblAddressFill.BackColor = Color.Transparent;
            lblAddressFill.Font = new Font("Segoe UI", 13.2F);
            lblAddressFill.ForeColor = Color.Black;
            lblAddressFill.Location = new Point(708, 253);
            lblAddressFill.Name = "lblAddressFill";
            lblAddressFill.Size = new Size(96, 30);
            lblAddressFill.TabIndex = 17;
            lblAddressFill.Text = "Address:";
            // 
            // lblDateFill
            // 
            lblDateFill.AutoSize = true;
            lblDateFill.BackColor = Color.Transparent;
            lblDateFill.Font = new Font("Segoe UI", 13.2F);
            lblDateFill.ForeColor = Color.Black;
            lblDateFill.Location = new Point(226, 311);
            lblDateFill.Name = "lblDateFill";
            lblDateFill.Size = new Size(58, 30);
            lblDateFill.TabIndex = 18;
            lblDateFill.Text = "Date";
            // 
            // lblTotalPriceFill
            // 
            lblTotalPriceFill.AutoSize = true;
            lblTotalPriceFill.BackColor = Color.Transparent;
            lblTotalPriceFill.Font = new Font("Segoe UI", 13.2F);
            lblTotalPriceFill.ForeColor = Color.Black;
            lblTotalPriceFill.Location = new Point(226, 363);
            lblTotalPriceFill.Name = "lblTotalPriceFill";
            lblTotalPriceFill.Size = new Size(112, 30);
            lblTotalPriceFill.TabIndex = 19;
            lblTotalPriceFill.Text = "Total Price";
            // 
            // lblPaymentFill
            // 
            lblPaymentFill.AutoSize = true;
            lblPaymentFill.BackColor = Color.Transparent;
            lblPaymentFill.Font = new Font("Segoe UI", 13.2F);
            lblPaymentFill.ForeColor = Color.Black;
            lblPaymentFill.Location = new Point(708, 311);
            lblPaymentFill.Name = "lblPaymentFill";
            lblPaymentFill.Size = new Size(178, 30);
            lblPaymentFill.TabIndex = 21;
            lblPaymentFill.Text = "Payment method";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 13.2F);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(505, 311);
            label11.Name = "label11";
            label11.Size = new Size(183, 30);
            label11.TabIndex = 20;
            label11.Text = "Payment method:";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.ColumnHeadersHeight = 4;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            dataGridView1.Location = new Point(0, 406);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1065, 189);
            dataGridView1.TabIndex = 22;
            dataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            dataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dataGridView1.ThemeStyle.BackColor = Color.White;
            dataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ThemeStyle.HeaderStyle.Height = 4;
            dataGridView1.ThemeStyle.ReadOnly = false;
            dataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            dataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridView1.ThemeStyle.RowsStyle.Height = 29;
            dataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 13.2F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(23, 101);
            label2.Name = "label2";
            label2.Size = new Size(79, 30);
            label2.TabIndex = 23;
            label2.Text = "Bill ID: ";
            // 
            // lblBIllID
            // 
            lblBIllID.AutoSize = true;
            lblBIllID.BackColor = Color.Transparent;
            lblBIllID.Font = new Font("Segoe UI", 13.2F);
            lblBIllID.ForeColor = Color.Black;
            lblBIllID.Location = new Point(229, 101);
            lblBIllID.Name = "lblBIllID";
            lblBIllID.Size = new Size(62, 30);
            lblBIllID.TabIndex = 24;
            lblBIllID.Text = "BillID";
            // 
            // lblVoucherID
            // 
            lblVoucherID.AutoSize = true;
            lblVoucherID.BackColor = Color.Transparent;
            lblVoucherID.Font = new Font("Segoe UI", 13.2F);
            lblVoucherID.ForeColor = Color.Black;
            lblVoucherID.Location = new Point(711, 363);
            lblVoucherID.Name = "lblVoucherID";
            lblVoucherID.Size = new Size(93, 30);
            lblVoucherID.TabIndex = 26;
            lblVoucherID.Text = "Voucher";
            // 
            // lblVoucher
            // 
            lblVoucher.AutoSize = true;
            lblVoucher.BackColor = Color.Transparent;
            lblVoucher.Font = new Font("Segoe UI", 13.2F);
            lblVoucher.ForeColor = Color.Black;
            lblVoucher.Location = new Point(505, 363);
            lblVoucher.Name = "lblVoucher";
            lblVoucher.Size = new Size(119, 30);
            lblVoucher.TabIndex = 25;
            lblVoucher.Text = "VoucherID:";
            // 
            // FResBill
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 595);
            Controls.Add(lblVoucherID);
            Controls.Add(lblVoucher);
            Controls.Add(lblBIllID);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(lblPaymentFill);
            Controls.Add(label11);
            Controls.Add(lblTotalPriceFill);
            Controls.Add(lblDateFill);
            Controls.Add(lblAddressFill);
            Controls.Add(lblPhoneFill);
            Controls.Add(lblEmailFill);
            Controls.Add(lblNameFill);
            Controls.Add(lblStatusFill);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(lblAddr);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(guna2Panel3);
            Name = "FResBill";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FBill";
            Load += FBill_Load;
            guna2Panel3.ResumeLayout(false);
            guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblAddr;
        private Label label8;
        private Label label9;
        private Label lblStatusFill;
        private Label lblNameFill;
        private Label lblEmailFill;
        private Label lblPhoneFill;
        private Label lblAddressFill;
        private Label lblDateFill;
        private Label lblTotalPriceFill;
        private Label lblPaymentFill;
        private Label label11;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Label label2;
        private Label lblBIllID;
        private Label lblVoucherID;
        private Label lblVoucher;
    }
}