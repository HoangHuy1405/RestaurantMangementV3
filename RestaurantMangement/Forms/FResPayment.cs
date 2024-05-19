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

namespace RestaurantMangement.Forms
{
    public partial class FResPayment : Form {
        Account currentAcc = FResLogin.currentAcc;
        Bill bill = new Bill();
        Order order = new Order();
        DBConnection db = new DBConnection();
        DataTable vouchers;

        public FResPayment() {
            InitializeComponent();
        }
        public FResPayment(Order order) {
            InitializeComponent();
            this.order = order;
            this.vouchers = Code.DAO.VoucherDAO.instance().LoadVoucherTable();
            loadVoucherIntoComboBox();
            definingBookedProduct();
            calculateTheTotalPrice();
        }
        private void FResPayment_Load(object sender, EventArgs e) {
            lblBuyerName.Text = currentAcc.Fullname;
            //calculateTheTotalPrice();
        }
        private void definingBookedProduct() {
            // Clear existing rows and columns
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Define the columns for dataGridView1
            DataGridViewTextBoxColumn columnDishOrDrinkID = new DataGridViewTextBoxColumn();
            columnDishOrDrinkID.HeaderText = "Product ID";
            columnDishOrDrinkID.Name = "ProductID";

            DataGridViewTextBoxColumn columnDishOrDrinkName = new DataGridViewTextBoxColumn();
            columnDishOrDrinkName.HeaderText = "Name";
            columnDishOrDrinkName.Name = "Name";

            DataGridViewTextBoxColumn columnDishOrDrinkQuantity = new DataGridViewTextBoxColumn();
            columnDishOrDrinkQuantity.HeaderText = "Quantity";
            columnDishOrDrinkQuantity.Name = "Quantity";

            DataGridViewTextBoxColumn columnDishOrDrinkPrice = new DataGridViewTextBoxColumn();
            columnDishOrDrinkPrice.HeaderText = "Price";
            columnDishOrDrinkPrice.Name = "Price";

            dataGridView1.Columns.Add(columnDishOrDrinkID);
            dataGridView1.Columns.Add(columnDishOrDrinkName);
            dataGridView1.Columns.Add(columnDishOrDrinkQuantity);
            dataGridView1.Columns.Add(columnDishOrDrinkPrice);

            dataGridView1.ColumnHeadersHeight = 30;

            // Fill gridview with booked product data from bill
            foreach (OrderDetail orderDetail in order.OrderList) {
                // Create a new row for the DataGridView
                DataGridViewRow newRow = new DataGridViewRow();

                // Populate the cells of the new row with data from the BookedDishOrDrink object
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = orderDetail.ProductID });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = orderDetail.ProductName });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = orderDetail.Quantity });
                newRow.Cells.Add(new DataGridViewTextBoxCell { Value = orderDetail.Price });

                // Add the new row to the DataGridView
                dataGridView1.Rows.Add(newRow);
            }
        }

        private void btnHome_Click(object sender, EventArgs e) {
            Code.DAO.OrderDAO.instance().deleteOrder(order.OrderID);
            this.Hide();
            FResMain f = new FResMain();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
        private void calculateTheTotalPrice() {
            decimal subTotalPrice = order.TotalPrice;
            decimal totalPrice = 0;

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

            // Calculate shipping (if applicable)
            decimal shipping = (subTotalPrice / 100) * 10;
            totalPrice = shipping + subTotalPrice;
            totalPrice = totalPrice - totalPrice * voucherDiscount / 100;
            bill.TotalPrice = totalPrice;

            //Update the UI with calculated values
            lblVoucher.Text = voucherDiscount.ToString() + "%";
            lblTotalPrice.Text = totalPrice.ToString();
            lblShippingFee.Text = shipping.ToString();
            lblSubTotalPrice.Text = subTotalPrice.ToString();
        }
        private void FillBill() {
            bill.OrderID = order.OrderID;
            bill.BookedTableID = "";
            bill.AccID = currentAcc.AccID;
            bill.VoucherId = string.Empty;
            bill.Date = DateTime.Now;
            bill.CustomerAddress = txtAddress.Text;
            bill.CustomerName = txtName.Text;
            bill.CustomerEmail = currentAcc.Email;
            bill.CustomerPhone = txtPhone.Text;
            if (this.rbtnOnline.Checked) {
                bill.PaymentMethods = "Online";
            } else bill.PaymentMethods = "Cash";
            bill.Status = "Pending";
            bill.Note = txtNote.Text;
            // bill.TotalPrice is already filled in
            bill.Type = "Order Product";
        }
        // load every voucher in db to gunaComboBox
        public void loadVoucherIntoComboBox() {
            if (vouchers.Rows.Count > 0) {
                foreach (DataRow dataRow in vouchers.Rows) {
                    cbVouchers.Items.Add(dataRow["voucherID"].ToString());
                }

                cbVouchers.Items.Add(string.Empty);
            }

        }

        private void btnBuy_Click(object sender, EventArgs e) {
            FillBill();
            if (cbVouchers.SelectedItem != null) {
                bill.VoucherId = cbVouchers.SelectedItem.ToString();
            }
            this.Hide();
            string billID = Code.DAO.BillDAO.instance().CreateBill(bill);
            bill.BillId = billID;
            MessageBox.Show("Done!");
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

        private void FResPayment_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                //Code.DAO.OrderDAO.instance().deleteOrder(order.OrderID);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) {

        }
    }
}
