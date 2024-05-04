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
            FBookingTable f = new FBookingTable();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
