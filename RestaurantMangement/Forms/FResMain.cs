﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMangement.Forms {
    public partial class FResMain : Form {
        public FResMain() {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnOrder_Click(object sender, EventArgs e) {
            this.Hide();
            FResOrder f = new FResOrder();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btnBill_Click(object sender, EventArgs e) {
            this.Hide();
            FResBillHistory f = new FResBillHistory();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btnTable_Click(object sender, EventArgs e) {
            this.Hide();
            FResBookingTable f = new FResBookingTable();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e) {
            this.Hide();
            FResLogin f = new FResLogin();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void FResMain_Load(object sender, EventArgs e) {
            lblName.Text = FResLogin.currentAcc.Fullname;
            lblBalance.Text = Code.DAO.AccountDAO.instance().getAccountBalance().ToString();
        }
    }
}
