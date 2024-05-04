using Guna.UI2.WinForms;
using RestaurantMangement.Code;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantMangement.Forms
{
    public partial class FResOrder : Form {
        DBConnection db = new DBConnection();

        public FResOrder() {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e) {
            this.Hide();
            FResMain frm = new FResMain();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        // retrieve data from database
        public void FResOrder_Load(object sender, EventArgs e) {
            DataTable table = db.Load("SELECT p.ProductID, p.productName, p.description, p.price, c.cateName FROM Product p INNER JOIN category c ON p.cateID = c.cateID");
            dataGridView1.DataSource = table;
            if (dataGridView1.Columns.Contains("productName"))
                dataGridView1.Columns["productName"].HeaderText = "Prduct Name";

            if (dataGridView1.Columns.Contains("cateName"))
                dataGridView1.Columns["cateName"].HeaderText = "Category";

            if (dataGridView1.Columns.Contains("description"))
                dataGridView1.Columns["description"].HeaderText = "Description";

            if (dataGridView1.Columns.Contains("price"))
                dataGridView1.Columns["price"].HeaderText = "Price";


            dataGridView1.ColumnHeadersHeight = 30;
        }

        private void btnAddItem_Click(object sender, EventArgs e) {
            this.Hide();
            FResAddDelEditMenuItem f = new FResAddDelEditMenuItem();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private int itemId;
        private string itemName;
        private double price;
        private int quantity = 0;
        private double totalPrice = 0;
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {
            //int index = e.RowIndex;
            //if (index >= 0) {
            //    DataGridViewRow selectedRow = dataGridView1.Rows[index];
            //    itemId = Convert.ToInt32(selectedRow.Cells[0].Value);
            //    itemName = selectedRow.Cells[1].Value.ToString();
            //    price = Convert.ToDouble(selectedRow.Cells[3].Value);
            //    quantity = Convert.ToInt32(selectedRow.Cells[4].Value);
            //    //display total price
            //    totalPrice += price;
            //    txtTotalPrice.Text = totalPrice.ToString() + " VND";

            //    bool isAdded = false;
            //    foreach (DataGridViewRow row in dataGridView2.Rows) {
            //        if (row.Cells[0].Value == itemName) {
            //            int quantity = Convert.ToInt32(row.Cells["dgvQuantityOrder"].Value);
            //            quantity++;
            //            row.Cells["dgvQuantityOrder"].Value = quantity;
            //            isAdded = true; 
            //            break;
            //        }
            //    }
            //    foreach (MenuItem item in menuItems) {
            //        if(item.ItemID == itemId) {
            //            item.Quantity = quantity;
            //        }
            //    }
            //    if(!isAdded) {
            //        dataGridView2.Rows.Add(itemName, 1);
            //        menuItems.Add(new MenuItem(itemId, price, quantity));
            //    }
            //}
        }
        private void btnProceed_Click(object sender, EventArgs e) {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
