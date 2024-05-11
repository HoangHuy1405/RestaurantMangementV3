using Guna.UI2.WinForms;
using RestaurantMangement.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMangement.Forms
{
    public partial class FResAddDelEditMenuItem : Form {
        DBConnection db = new DBConnection();
        private string productID;
        private string productCategory;

        public FResAddDelEditMenuItem() {
            InitializeComponent();
        }

        private void FResAddDelEditMenuItem_Load(object sender, EventArgs e) {
            DataTable table = db.Load("SELECT p.ProductID, p.productName, p.description, p.price, c.cateName FROM Product p INNER JOIN category c ON p.cateID = c.cateID");
            dataGridView2.DataSource = table;
            if (dataGridView2.Columns.Contains("productName"))
                dataGridView2.Columns["productName"].HeaderText = "Prduct Name";

            if (dataGridView2.Columns.Contains("cateName"))
                dataGridView2.Columns["cateName"].HeaderText = "Category";

            if (dataGridView2.Columns.Contains("description"))
                dataGridView2.Columns["description"].HeaderText = "Description";

            if (dataGridView2.Columns.Contains("price"))
                dataGridView2.Columns["price"].HeaderText = "Price";


            dataGridView2.ColumnHeadersHeight = 30;

            LoadCategories();
            dataGridView2.Columns["price"].DefaultCellStyle.Format = "0.0";
        }

        private double price;
        private int productId;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) {
            int index = e.RowIndex;
            if (index >= 0) {
                DataGridViewRow selectedRow = dataGridView2.Rows[index];
                txtProductID.Text = selectedRow.Cells[0].Value.ToString();
                txtProductName.Text = selectedRow.Cells[1].Value.ToString();
                txtDescription.Text = selectedRow.Cells[2].Value.ToString();
                txtPrice.Text = selectedRow.Cells[3].Value.ToString();
                productCategory = selectedRow.Cells[4].Value.ToString();
                SetDefaultCategory(productCategory);
            }
        }
        private void SetDefaultCategory(string categoryName) {
            foreach (string item in CategoryItems.Items) {
                if (item == categoryName) {
                    CategoryItems.SelectedItem = item;
                    break;
                }
            }
        }
        private void LoadCategories() {
            DataTable categories = db.LoadCategoryTable();
            if (categories.Rows.Count > 0) {
                foreach (DataRow row in categories.Rows) {
                    CategoryItems.Items.Add(row["cateName"].ToString());
                }
            }
        }
        private bool isValidInput() {
            if (string.IsNullOrEmpty(txtProductName.Text)) {
                MessageBox.Show("Item name has not been filled in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //if (double.TryParse(txtPrice.Text, out price)) {


            //} else {
            //    MessageBox.Show("Invalid price");
            //    return false;
            //}
            price = double.Parse(txtPrice.Text, CultureInfo.InvariantCulture);
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e) {
            // check if input is valid or not
            if (isValidInput()) {
                string cateName = CategoryItems.SelectedItem.ToString();
                db.addProductWithCate(txtProductName.Text, txtDescription.Text, price, cateName);
                // update 
                CategoryItems.Items.Clear();
                FResAddDelEditMenuItem_Load(sender, e);
                MessageBox.Show("Added successfully");
                // reset to empty
                txtProductID.Text = "";
                txtProductName.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = "";
            }
        }
        private void btnEdit_Click(object sender, EventArgs e) {
            if (isValidInput()) {
                string cateName = CategoryItems.SelectedItem.ToString();
                db.editProduct(txtProductID.Text, txtProductName.Text, cateName, price, txtDescription.Text);
                //menuItemDAO.edit(menuItem);
                // update 
                CategoryItems.Items.Clear();
                FResAddDelEditMenuItem_Load(sender, e);
                MessageBox.Show("edited successfully");
                // reset to empty
                txtProductID.Text = "";
                txtProductName.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = "";
            }
        }
        private void btnDelete_Click(object sender, EventArgs e) {
            db.deleteProduct(txtProductID.Text);

            // update 
            FResAddDelEditMenuItem_Load(sender, e);
            MessageBox.Show("deleted successfully");
            // reset to empty
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";

        }
        private void btnExit_Click(object sender, EventArgs e) {
            this.Hide();
            FResOrder f = new FResOrder();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
