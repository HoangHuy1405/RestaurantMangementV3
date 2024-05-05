using RestaurantMangement.Code;
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
            dataGridView1.DataSource = db.GetBillHistory(currentAcc.AccId);
            dataGridView1.ColumnHeadersHeight = 30;
        }
    }
}
