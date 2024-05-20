using Guna.UI2.WinForms;
using RestaurantMangement.Code;
using RestaurantMangement.Code.Model;
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
        Order order = new Order();

        public FResOrder() {
            InitializeComponent();
        }

        public void btnHome_Click(object sender, EventArgs e) {
            this.Hide();
            FResMain frm = new FResMain();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        // retrieve data from database
        public void FResOrder_Load(object sender, EventArgs e) {
            DataTable table = Code.DAO.ProductDAO.instance().loadProductWithCate();
            dataGridView1.DataSource = table;
            if (dataGridView1.Columns.Contains("productName"))
                dataGridView1.Columns["productName"].HeaderText = "Prduct Name";

            if (dataGridView1.Columns.Contains("cateName"))
                dataGridView1.Columns["cateName"].HeaderText = "Category";

            if (dataGridView1.Columns.Contains("description"))
                dataGridView1.Columns["description"].HeaderText = "Description";

            if (dataGridView1.Columns.Contains("price"))
                dataGridView1.Columns["price"].HeaderText = "Price";


            DataGridViewButtonColumn addButtonColumn = new DataGridViewButtonColumn();
            addButtonColumn.HeaderText = "+";
            addButtonColumn.Text = "+";
            addButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Add(addButtonColumn);

            DataGridViewButtonColumn subtractButtonColumn = new DataGridViewButtonColumn();
            subtractButtonColumn.HeaderText = "-";
            subtractButtonColumn.Text = "-";
            subtractButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Add(subtractButtonColumn);

            dataGridView1.ColumnHeadersHeight = 30;
        }

        private void btnAddItem_Click(object sender, EventArgs e) {
            if (FResLogin.isAdmin)
            {
                this.Hide();
                FResAddDelEditProduct f = new FResAddDelEditProduct();
                f.Closed += (s, args) => this.Close();
                f.Show();
            }
            else
            {
                MessageBox.Show("Admin access requirement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private string productId;
        private string productName;
        private decimal price;
        private int quantity = 0;
        private double totalPrice = 0;


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            int index = e.RowIndex;
            if (index >= 0) {
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                productId = selectedRow.Cells[0].Value.ToString();
                productName = selectedRow.Cells[1].Value.ToString();
                price = Convert.ToDecimal(selectedRow.Cells[3].Value);

                bool isAdded = false;
                foreach (DataGridViewRow row in dataGridView2.Rows) {
                    if (row.Cells[0].Value == productName) {
                        isAdded = true;
                        break;
                    }
                }
                if (isAdded) {
                    MessageBox.Show("This food is already in the food cart.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    OrderDetail orderDetail = new OrderDetail(productId, productName, 1, price);
                    order.OrderList.Add(orderDetail);
                    dataGridView2.Rows.Add(productName, 1);
                }
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            int index = e.RowIndex;
            if (index >= 0 && dataGridView2.Columns[e.ColumnIndex] is DataGridViewButtonColumn) {
                if (dataGridView2.Columns[e.ColumnIndex].HeaderText == "+") {
                    // Increment quantity by 1
                    int quantity = Convert.ToInt32(dataGridView2.Rows[index].Cells["dgvQuantity"].Value);
                    order.OrderList[index].Quantity += 1;
                    // no need for this, automatic price calculation in db
                    //bill.bookedProducts[index].Totalprice += bill.bookedProducts[index].NormalPrice;

                    quantity++;
                    dataGridView2.Rows[index].Cells["dgvQuantity"].Value = quantity;
                } else if (dataGridView2.Columns[e.ColumnIndex].HeaderText == "-") {
                    // Decrement quantity by 1, if it's greater than 0
                    int quantity = Convert.ToInt32(dataGridView2.Rows[index].Cells["dgvQuantity"].Value);
                    if (quantity > 0) {

                        order.OrderList[index].Quantity -= 1;
                        // no need for this, automatic price calculation in db
                        //bill.bookedProducts[index].Totalprice -= bill.bookedProducts[index].NormalPrice;

                        quantity--;
                        dataGridView2.Rows[index].Cells["dgvQuantity"].Value = quantity;

                    }
                }
                // Disable the button temporarily
                dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                dataGridView2.BeginEdit(true);
            }
        }
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            // Enable the button after the edit is complete
            dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
        }

        private void btnProceed_Click(object sender, EventArgs e) {
            if(order.OrderList.Count > 0) {
                this.Hide();
                fillOrderInformation();
                string orderID = Code.DAO.OrderDAO.instance().insert(order);
                order.OrderID = orderID;
                FResPayment f = new FResPayment(order);
                f.Closed += (s, args) => this.Close();
                f.Show();
            } else {
                MessageBox.Show("Your order is empty. Please add items to your order before proceeding.", "Order Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }
        private void fillOrderInformation() {
            order.TotalPrice = order.calculateTotalPrice();
            order.AccID = FResLogin.currentAcc.AccID;
            order.Date = DateTime.Now;
        }
    }
}
