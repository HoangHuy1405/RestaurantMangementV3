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
    public partial class FResPayment : Form {
        Account currentAcc = FResLogin.currentAcc;
        Bill bill = new Bill();
        DBConnection db = new DBConnection();
        DataTable vouchers;

        public FResPayment() {
            InitializeComponent();
        }
        public FResPayment(Bill bill) {
            InitializeComponent();
            this.bill = bill;
            this.vouchers = db.LoadVoucherTable();
            loadVoucherIntoComboBox();
            definingBookedProduct();
            calculateTheTotalPrice();
        }
        private void FResPayment_Load(object sender, EventArgs e) {
            lblBuyerName.Text = currentAcc.FullName;
            definingBookedProduct();
            //calculateTheTotalPrice();
        }
        private void definingBookedProduct() {
            // Clear existing rows and columns
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Define the columns for dataGridView1
            DataGridViewTextBoxColumn columnDishOrDrinkID = new DataGridViewTextBoxColumn();
            columnDishOrDrinkID.HeaderText = "Dish/Drink ID";
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

            dataGridView1.Columns.Add(columnDishOrDrinkID);
            dataGridView1.Columns.Add(columnDishOrDrinkName);
            dataGridView1.Columns.Add(columnDishOrDrinkQuantity);
            dataGridView1.Columns.Add(columnDishOrDrinkTotalPrice);

            dataGridView1.ColumnHeadersHeight = 30;

            // Fill gridview with booked product data from bill
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
        }

        private void btnHome_Click(object sender, EventArgs e) {
            this.Hide();
            FResMain f = new FResMain();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
        private void calculateTheTotalPrice() {
            decimal subTotalPrice = 0;
            decimal totalPrice = 0;
            int numberofitems = 0;

            decimal voucherDiscount = 0;
            if (cbVouchers.SelectedItem != null) {
                string selectedVoucherId = cbVouchers.SelectedItem.ToString();
                DataRow[] foundRows = vouchers.Select($"voucherID = '{selectedVoucherId}'");
                if (foundRows.Length > 0) {
                    // Get the discount value from the found row
                    voucherDiscount = Convert.ToDecimal(foundRows[0]["discount"]);
                    MessageBox.Show($"Discount value for voucher id {selectedVoucherId}: {voucherDiscount}%");
                }
            }
            // Calculate total price of booked dish and drink items
            foreach (DataGridViewRow row in dataGridView1.Rows) {
                decimal price = Convert.ToDecimal(row.Cells["TotalPrice"].Value);
                subTotalPrice += price;
                numberofitems += Convert.ToInt32(row.Cells["Quantity"].Value);
            }

            // Calculate shipping (if applicable)
            decimal shipping = (subTotalPrice / 100) * 10;
            totalPrice = shipping + subTotalPrice;
            totalPrice = totalPrice - totalPrice * voucherDiscount / 100;
            bill.TotalPrice = totalPrice;

            // Update the UI with calculated values
            lblVoucher.Text = voucherDiscount.ToString() + "%";
            lblTotalPrice.Text = totalPrice.ToString();
            lblShippingFee.Text = shipping.ToString();
            lblSubTotalPrice.Text = subTotalPrice.ToString();
            lblNoOfItems.Text = numberofitems.ToString();

        }
        private void FillBill() {
            bill.CustomerName = txtName.Text;
            bill.CustomerEmail = currentAcc.Email;
            if (this.rbtnOnline.Checked) {
                bill.PaymentMethods = "Online";
            } else bill.PaymentMethods = "Cash";
            bill.Note = "Order food";
            bill.CustomerPhone = txtPhone.Text;
            bill.CustomerAddress = txtAddress.Text;
            bill.VoucherId = string.Empty;
            bill.Status = "Pending";
            bill.Date = DateTime.Now;
            bill.AccId = currentAcc.AccId;
        }
        // load every voucher in db to gunaComboBox
        public void loadVoucherIntoComboBox() {
            if (vouchers.Rows.Count > 0) {
                foreach (DataRow dataRow in vouchers.Rows) {
                    cbVouchers.Items.Add(dataRow["voucherID"].ToString());
                }
            }
        }


        private void label2_Click(object sender, EventArgs e) {

        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void btnBuy_Click(object sender, EventArgs e) {
            FillBill();
            if (cbVouchers.SelectedItem != null) {
                bill.VoucherId = cbVouchers.SelectedItem.ToString();
            }
            this.Hide();
            db.CreateBill(bill);
            MessageBox.Show("Done!");
            //FResMain f = new FResMain();
            FResBill f = new FResBill(bill);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        // recalculate the total price
        private void cbVouchers_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void cbVouchers_SelectedValueChanged(object sender, EventArgs e) {
            //cbVouchers.Items.Clear();
            calculateTheTotalPrice();
            FResPayment_Load(sender, e);
        }

        private void btnEditVoucher_Click(object sender, EventArgs e) {
            if (FResLogin.isAdmin) {
                this.Hide();
                FResAddEditDelVouchers f = new FResAddEditDelVouchers();
                f.Closed += (s, args) => this.Close();
                f.Show();
            } else {
                MessageBox.Show("Admin access requirement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
