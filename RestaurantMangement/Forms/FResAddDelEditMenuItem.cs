using Guna.UI2.WinForms;
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
    public partial class FResAddDelEditMenuItem : Form {
        MenuItemDAO menuItemDAO = new MenuItemDAO();
        public FResAddDelEditMenuItem(Guna2DataGridView dgv) {
            InitializeComponent();
        }
        public FResAddDelEditMenuItem() {
            InitializeComponent();
        }

        private void FResAddDelEditMenuItem_Load(object sender, EventArgs e) {
            DataTable table = menuItemDAO.load();
            dataGridView2.DataSource = table;
            if (dataGridView2.Columns.Contains("item_name"))
                dataGridView2.Columns["item_name"].HeaderText = "Item Name";

            if (dataGridView2.Columns.Contains("item_type"))
                dataGridView2.Columns["item_type"].HeaderText = "Item Type";

            if (dataGridView2.Columns.Contains("description"))
                dataGridView2.Columns["description"].HeaderText = "Description";

            if (dataGridView2.Columns.Contains("price"))
                dataGridView2.Columns["price"].HeaderText = "Price";

            if (dataGridView2.Columns.Contains("quantity"))
                dataGridView2.Columns["quantity"].HeaderText = "Quantity";

            dataGridView2.ColumnHeadersHeight = 30;
        }

        private void btnAdd_Click(object sender, EventArgs e) {

            if (string.IsNullOrEmpty(txtItemName.Text)) {
                MessageBox.Show("Item name has not been filled in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (string.IsNullOrEmpty(txtItemType.Text)) {
                MessageBox.Show("Item type has not been filled in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //
            double price;
            if (double.TryParse(txtPrice.Text, out price)) {

            } else {
                MessageBox.Show("Invalid price");
                return;
            }
            int quantity;
            if (int.TryParse(txtQuantity.Text, out quantity)) {

            } else {
                MessageBox.Show("Invalid quantity");
                return;
            }
            MenuItem menuItem = new MenuItem(txtItemName.Text, txtItemType.Text, price, txtDescription.Text, quantity);
            menuItemDAO.add(menuItem);
            // update 
            FResAddDelEditMenuItem_Load(sender, e);
            // reset to empty
            txtItemName.Text = "";
            txtItemType.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
        }
        private void btnDelete_Click(object sender, EventArgs e) {

        }
        private void btnExit_Click(object sender, EventArgs e) {
            this.Hide();
            FResOrder f = new FResOrder();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
