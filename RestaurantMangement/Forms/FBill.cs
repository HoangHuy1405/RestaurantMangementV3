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
    public partial class FBill : Form {

        Bill bill = new Bill();
        DBConnection db = new DBConnection();

        public FBill() {
            InitializeComponent();
        }
        public FBill(Bill bill) {
            InitializeComponent();
            this.bill = bill;
            Initilize();
        }
        private void FBill_Load(object sender, EventArgs e) {

        }
        private void Initilize() {
            lblStatusFill.Text = bill.status;
            lblNameFill.Text = bill.customerName;
            lblEmailFill.Text = bill.customerEmail;
            lblPhoneFill.Text = bill.customerPhone;
            lblAddressFill.Text = bill.customerAddress;
            lblDateFill.Text = bill.date.ToString("yyyy-MM-dd HH:mm");
            lblPaymentFill.Text = bill.paymentMethods;
            lblTotalPriceFill.Text = bill.totalPrice.ToString();
            //Fill for table cart
            DefiningBookedDishAndDrink();
        }
        private void DefiningBookedDishAndDrink() {
            // Clear existing rows and columns
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Define the columns for gvFood
            DataGridViewTextBoxColumn columnDishOrDrinkID = new DataGridViewTextBoxColumn();
            columnDishOrDrinkID.HeaderText = "Product ID";
            columnDishOrDrinkID.Name = "DishOrDrinkID";

            DataGridViewTextBoxColumn columnDishOrDrinkName = new DataGridViewTextBoxColumn();
            columnDishOrDrinkName.HeaderText = "Name";
            columnDishOrDrinkName.Name = "Name";

            DataGridViewTextBoxColumn columnDishOrDrinkQuantity = new DataGridViewTextBoxColumn();
            columnDishOrDrinkQuantity.HeaderText = "Quantity";
            columnDishOrDrinkQuantity.Name = "Quantity";

            DataGridViewTextBoxColumn columnDishOrDrinkTotalPrice = new DataGridViewTextBoxColumn();
            columnDishOrDrinkTotalPrice.HeaderText = "Total Price";
            columnDishOrDrinkTotalPrice.Name = "TotalPrice";

            // Add the columns to gvFood
            dataGridView1.Columns.Add(columnDishOrDrinkID);
            dataGridView1.Columns.Add(columnDishOrDrinkName);
            dataGridView1.Columns.Add(columnDishOrDrinkQuantity);
            dataGridView1.Columns.Add(columnDishOrDrinkTotalPrice);

            // Fill gvFood with booked dish and drink data
            foreach (BookedProduct bookedProduct in bill.bookedProducts) {
                // Create a new row for the DataGridView
                DataGridViewRow newRow = new DataGridViewRow();

                // Populate the cells of the new row with data from the BookedDishOrDrink object
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = bookedProduct.ProductId });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = bookedProduct.ProductName });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = bookedProduct.Quantity });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = bookedProduct.Totalprice });

                // Add the new row to the DataGridView
                dataGridView1.Rows.Add(newRow);
            }

            dataGridView1.ColumnHeadersHeight = 30;
        }

        private void lblTotalPriceFill_Click(object sender, EventArgs e) {

        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            FBill_Load(sender, e);
        }

        private void btnHome_Click(object sender, EventArgs e) {
            this.Hide();
            FResMain f = new FResMain();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
