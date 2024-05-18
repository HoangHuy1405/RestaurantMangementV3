using RestaurantMangement.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMangement.Forms
{
    public partial class FResEditDelBillHistory : Form {
        DBConnection db = new DBConnection();
        private string billID;
        public FResEditDelBillHistory() {
            InitializeComponent();
        }
        public FResEditDelBillHistory(string billID) {
            InitializeComponent();
            this.billID = billID;
        }
        private void btnGoBack_Click(object sender, EventArgs e) {
            this.Hide();
            FResBillHistory f = new FResBillHistory();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void gvBillHistory_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void FResEditDelBillHistory_Load(object sender, EventArgs e) {
            gvBillHistory.DataSource = db.getBillFromBillID(this.billID);
            gvBillHistory.ColumnHeadersHeight = 30;
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e) {
            if(this.billID != null) {
                if (cbBillStatus.SelectedItem == null) {
                    MessageBox.Show("Please choose bill status before update!");
                    return;
                } else {
                    string billStatus = cbBillStatus.SelectedItem.ToString();
                    db.UpdateBillStatus(this.billID, billStatus);
                    MessageBox.Show("Updated successfully");
                    this.Hide();
                    FResBillHistory f = new FResBillHistory();
                    f.Closed += (s, args) => this.Close();
                    f.Show();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if(this.billID!= null) {
                db.deleteBIll(this.billID);
                MessageBox.Show("Deleted successfully!");
                this.Hide();
                FResBillHistory f = new FResBillHistory();
                f.Closed += (s, args) => this.Close();
                f.Show();
            }
        }
    }
}
