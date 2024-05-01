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
    public partial class FResOrder : Form {

        private MenuItemDAO menuItemDAO = new MenuItemDAO();

        public FResOrder() {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e) {

        }

        private void btnHome_Click(object sender, EventArgs e) {
            this.Hide();
            FResMain frm = new FResMain();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void FoodCart_Click(object sender, EventArgs e) {

        }

        private void btnAddFood_Click(object sender, EventArgs e) {
            // add new UCFood to grid
            UCFood uCFood = new UCFood();
        }

        // retrieve data from database
        private void FResOrder_Load(object sender, EventArgs e) {
            DataTable table = menuItemDAO.load();

            dataGridView1.DataSource = table;
        }

        private void ucFood3_Load(object sender, EventArgs e) {

        }

        private void btnPurchase_Click(object sender, EventArgs e) {

        }
    }
}
