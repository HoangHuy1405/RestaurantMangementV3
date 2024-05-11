namespace RestaurantMangement.Forms {
    partial class FResEditDelBillHistory {
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
        private void InitializeComponent() {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnDelete = new Guna.UI2.WinForms.Guna2Button();
            label7 = new Label();
            cbBillStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            btnGoBack = new Guna.UI2.WinForms.Guna2Button();
            btnUpdateStatus = new Guna.UI2.WinForms.Guna2Button();
            gvBillHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvBillHistory).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(btnDelete);
            guna2Panel1.Controls.Add(label7);
            guna2Panel1.Controls.Add(cbBillStatus);
            guna2Panel1.Controls.Add(btnGoBack);
            guna2Panel1.Controls.Add(btnUpdateStatus);
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.Dock = DockStyle.Bottom;
            guna2Panel1.FillColor = Color.Transparent;
            guna2Panel1.Location = new Point(0, 90);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(1068, 214);
            guna2Panel1.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Transparent;
            btnDelete.BorderRadius = 10;
            btnDelete.CustomizableEdges = customizableEdges1;
            btnDelete.DisabledState.BorderColor = Color.DarkGray;
            btnDelete.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDelete.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDelete.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDelete.FillColor = Color.FromArgb(80, 114, 123);
            btnDelete.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.HoverState.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(207, 117);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnDelete.Size = new Size(227, 56);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Delete this bill";
            btnDelete.Click += btnDelete_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(29, 13);
            label7.Name = "label7";
            label7.Size = new Size(82, 23);
            label7.TabIndex = 17;
            label7.Text = "Bill status";
            // 
            // cbBillStatus
            // 
            cbBillStatus.AllowDrop = true;
            cbBillStatus.BackColor = Color.Transparent;
            cbBillStatus.CustomizableEdges = customizableEdges3;
            cbBillStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cbBillStatus.DropDownHeight = 200;
            cbBillStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBillStatus.FocusedColor = Color.FromArgb(94, 148, 255);
            cbBillStatus.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbBillStatus.Font = new Font("Segoe UI", 10F);
            cbBillStatus.ForeColor = Color.FromArgb(68, 88, 112);
            cbBillStatus.IntegralHeight = false;
            cbBillStatus.ItemHeight = 40;
            cbBillStatus.Items.AddRange(new object[] { "Pending", "Paid", "Not paid" });
            cbBillStatus.Location = new Point(29, 39);
            cbBillStatus.Name = "cbBillStatus";
            cbBillStatus.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbBillStatus.Size = new Size(152, 46);
            cbBillStatus.TabIndex = 16;
            // 
            // btnGoBack
            // 
            btnGoBack.BackColor = Color.Transparent;
            btnGoBack.BorderRadius = 10;
            btnGoBack.CustomizableEdges = customizableEdges5;
            btnGoBack.DisabledState.BorderColor = Color.DarkGray;
            btnGoBack.DisabledState.CustomBorderColor = Color.DarkGray;
            btnGoBack.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnGoBack.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnGoBack.FillColor = Color.FromArgb(80, 114, 123);
            btnGoBack.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGoBack.ForeColor = Color.White;
            btnGoBack.HoverState.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGoBack.Location = new Point(930, 134);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnGoBack.Size = new Size(126, 56);
            btnGoBack.TabIndex = 5;
            btnGoBack.Text = "Go back";
            btnGoBack.Click += btnGoBack_Click;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.BackColor = Color.Transparent;
            btnUpdateStatus.BorderRadius = 10;
            btnUpdateStatus.CustomizableEdges = customizableEdges7;
            btnUpdateStatus.DisabledState.BorderColor = Color.DarkGray;
            btnUpdateStatus.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdateStatus.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpdateStatus.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpdateStatus.FillColor = Color.FromArgb(80, 114, 123);
            btnUpdateStatus.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdateStatus.ForeColor = Color.White;
            btnUpdateStatus.HoverState.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdateStatus.Location = new Point(207, 42);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnUpdateStatus.Size = new Size(227, 56);
            btnUpdateStatus.TabIndex = 4;
            btnUpdateStatus.Text = "Update bill status";
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // gvBillHistory
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            gvBillHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gvBillHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gvBillHistory.ColumnHeadersHeight = 4;
            gvBillHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gvBillHistory.DefaultCellStyle = dataGridViewCellStyle3;
            gvBillHistory.Dock = DockStyle.Fill;
            gvBillHistory.GridColor = Color.FromArgb(231, 229, 255);
            gvBillHistory.Location = new Point(0, 0);
            gvBillHistory.Name = "gvBillHistory";
            gvBillHistory.RowHeadersVisible = false;
            gvBillHistory.RowHeadersWidth = 51;
            gvBillHistory.Size = new Size(1068, 90);
            gvBillHistory.TabIndex = 2;
            gvBillHistory.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            gvBillHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
            gvBillHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            gvBillHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            gvBillHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            gvBillHistory.ThemeStyle.BackColor = Color.White;
            gvBillHistory.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            gvBillHistory.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            gvBillHistory.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            gvBillHistory.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            gvBillHistory.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            gvBillHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvBillHistory.ThemeStyle.HeaderStyle.Height = 4;
            gvBillHistory.ThemeStyle.ReadOnly = false;
            gvBillHistory.ThemeStyle.RowsStyle.BackColor = Color.White;
            gvBillHistory.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gvBillHistory.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            gvBillHistory.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            gvBillHistory.ThemeStyle.RowsStyle.Height = 29;
            gvBillHistory.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            gvBillHistory.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            gvBillHistory.CellContentClick += gvBillHistory_CellContentClick;
            // 
            // FResEditDelBillHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 304);
            Controls.Add(gvBillHistory);
            Controls.Add(guna2Panel1);
            Name = "FResEditDelBillHistory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FResEditDelBillHistory";
            Load += FResEditDelBillHistory_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvBillHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnGoBack;
        private Guna.UI2.WinForms.Guna2DataGridView gvBillHistory;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button btnUpdateStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cbBillStatus;
        private Label label7;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
    }
}