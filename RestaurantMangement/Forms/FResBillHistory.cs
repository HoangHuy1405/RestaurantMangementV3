using RestaurantMangement.Code;
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
            lblName.Text = currentAcc.Fullname;
            if (FResLogin.isAdmin) {
                // if you are a manager => you are allowed to see all bill history
                gvBillHistory.DataSource = Code.DAO.BillDAO.instance().GetAllBillHistory();
            } else {
                gvBillHistory.DataSource = Code.DAO.BillDAO.instance().GetBillHistoryFromDBOfThatAccount(currentAcc.AccID);
            }

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

        private void btnHome_Click_1(object sender, EventArgs e) {
            this.Hide();
            FResMain f = new FResMain();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
