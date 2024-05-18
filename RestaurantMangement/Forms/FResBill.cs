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
    public partial class FResBill : Form {
        Account currentAcc = FResLogin.currentAcc;
        Bill bill = new Bill();
        DBConnection db = new DBConnection();

        public FResBill() {
            InitializeComponent();
        }
        public FResBill(Bill bill) {
            InitializeComponent();
            this.bill = bill;
            Initilize();
        }
        private void FBill_Load(object sender, EventArgs e) {

        }
        private void Initilize() {
            //lblBIllID.Text = db.getBillIdBasedOnDate(currentAcc.AccId, bill.date);
            lblStatusFill.Text = bill.Status;
            lblNameFill.Text = bill.CustomerName;
            lblEmailFill.Text = bill.CustomerEmail;
            lblPhoneFill.Text = bill.CustomerPhone;
            lblAddressFill.Text = bill.CustomerAddress;
            lblDateFill.Text = bill.Date.ToString("yyyy-MM-dd HH:mm");
            lblPaymentFill.Text = bill.PaymentMethods;
            lblTotalPriceFill.Text = bill.TotalPrice.ToString();
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

            /* testing1
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

            */
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

        private void lblBIllID_Click(object sender, EventArgs e) {

        }
    }
}
