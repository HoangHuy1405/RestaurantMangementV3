namespace RestaurantMangement.Forms {
    partial class FResBillHistory {
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnHome = new Guna.UI2.WinForms.Guna2Button();
            lblName = new Label();
            label1 = new Label();
            gvBillHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvBillHistory).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(btnHome);
            guna2Panel1.Controls.Add(lblName);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.FillColor = Color.FromArgb(52, 73, 85);
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(1132, 78);
            guna2Panel1.TabIndex = 0;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Transparent;
            btnHome.BorderRadius = 10;
            btnHome.CustomizableEdges = customizableEdges1;
            btnHome.DisabledState.BorderColor = Color.DarkGray;
            btnHome.DisabledState.CustomBorderColor = Color.DarkGray;
            btnHome.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnHome.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnHome.FillColor = Color.FromArgb(80, 114, 123);
            btnHome.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.HoverState.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.Location = new Point(985, 12);
            btnHome.Name = "btnHome";
            btnHome.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnHome.Size = new Size(126, 56);
            btnHome.TabIndex = 3;
            btnHome.Text = "Home";
            btnHome.Click += btnHome_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(605, 19);
            lblName.Name = "lblName";
            lblName.Size = new Size(154, 38);
            lblName.TabIndex = 1;
            lblName.Text = "Your Name";
            lblName.Click += lblName_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(213, 38);
            label1.TabIndex = 0;
            label1.Text = "Your Bill History";
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
            gvBillHistory.Location = new Point(0, 78);
            gvBillHistory.Name = "gvBillHistory";
            gvBillHistory.RowHeadersVisible = false;
            gvBillHistory.RowHeadersWidth = 51;
            gvBillHistory.Size = new Size(1132, 442);
            gvBillHistory.TabIndex = 1;
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
            gvBillHistory.CellClick += gvBillHistory_CellClick;
            gvBillHistory.CellContentClick += gvBillHistory_CellContentClick;
            // 
            // FResBillHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 520);
            Controls.Add(gvBillHistory);
            Controls.Add(guna2Panel1);
            Name = "FResBillHistory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FResBillHistory";
            Load += FResBillHistory_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvBillHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView gvBillHistory;
        private Label label1;
        private Label lblName;
        private Guna.UI2.WinForms.Guna2Button btnHome;
    }
}