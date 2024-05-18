﻿using RestaurantMangement.Code;
using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMangement.Forms
{
    public partial class FResBillHistory : Form {
        DBConnection db = new DBConnection();
        Account currentAcc = FResLogin.currentAcc;


        public FResBillHistory() {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e) {

        }

        private void FResBillHistory_Load(object sender, EventArgs e) {
            /*blName.Text = currentAcc.FullName;
            if(FResLogin.isAdmin) {
                // if you are a manager => you are allowed to see all bill history
                gvBillHistory.DataSource = db.GetAllBillHistory();
            } else {
                gvBillHistory.DataSource = db.GetBillHistoryFromDBOfThatAccount(currentAcc.AccId);
            }
            
            gvBillHistory.ColumnHeadersHeight = 30;*/
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
            int index = e.RowIndex;
            if (FResLogin.isAdmin && index >= 0) {
                DataGridViewRow selectedRow = gvBillHistory.Rows[index];
                string billId = selectedRow.Cells[0].Value.ToString();
                this.Hide();
                FResEditDelBillHistory frm = new FResEditDelBillHistory(billId);
                frm.Closed += (s, args) => this.Close();
                frm.Show();

            } else {
                MessageBox.Show("Admin access requirement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gvBillHistory_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}
