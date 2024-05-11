﻿using RestaurantMangement.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMangement.Forms {
    public partial class FResBillHistory : Form {
        DBConnection db = new DBConnection();
        Account currentAcc = FResLogin.currentAcc;


        public FResBillHistory() {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e) {

        }

        private void FResBillHistory_Load(object sender, EventArgs e) {
            lblName.Text = currentAcc.FullName;
            gvBillHistory.DataSource = db.GetBillHistoryFromDBOfThatAccount(currentAcc.AccId);
            gvBillHistory.ColumnHeadersHeight = 30;
        }

        private void lblName_Click(object sender, EventArgs e) {

        }

        private void btnHome_Click(object sender, EventArgs e) {
            this.Hide();
            FResMain frm = new FResMain();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        private void gvBillHistory_CellClick(object sender, DataGridViewCellEventArgs e) {
            if(FResLogin.isAdmin) {

            } else {
                MessageBox.Show("Admin access requirement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
