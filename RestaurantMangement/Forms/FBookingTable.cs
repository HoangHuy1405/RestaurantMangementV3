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
    public partial class FBookingTable : Form {
        public FBookingTable() {
            InitializeComponent();
        }

        private void FBookingTable_Load(object sender, EventArgs e) {

        }

        private void btnHome_Click(object sender, EventArgs e) {
            this.Hide();
            FResMain frm = new FResMain();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        private void btnChooseTable_Click(object sender, EventArgs e) {
            this.Hide();
            FChooseTable f = new FChooseTable();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
