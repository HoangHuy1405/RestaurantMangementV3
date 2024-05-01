using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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

        // retrieve data from database
        public void FResOrder_Load(object sender, EventArgs e) {
            DataTable table = menuItemDAO.load();
            dataGridView1.DataSource = table;
            if (dataGridView1.Columns.Contains("item_name"))
                dataGridView1.Columns["item_name"].HeaderText = "Item Name";

            if (dataGridView1.Columns.Contains("item_type"))
                dataGridView1.Columns["item_type"].HeaderText = "Item Type";

            if (dataGridView1.Columns.Contains("description"))
                dataGridView1.Columns["description"].HeaderText = "Description";

            if (dataGridView1.Columns.Contains("price"))
                dataGridView1.Columns["price"].HeaderText = "Price";

            if (dataGridView1.Columns.Contains("quantity"))
                dataGridView1.Columns["quantity"].HeaderText = "Quantity";

            dataGridView1.ColumnHeadersHeight = 30;
        }

        private void ucFood3_Load(object sender, EventArgs e) {

        }

        private void btnAddItem_Click(object sender, EventArgs e) {
            this.Hide();
            FResAddDelEditMenuItem f = new FResAddDelEditMenuItem();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
