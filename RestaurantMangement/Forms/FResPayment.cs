﻿using RestaurantMangement.Code;
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

        public FResPayment() {
            InitializeComponent();
        }
        public FResPayment(Bill bill) {
            InitializeComponent();
            this.bill = bill;
        }
        private void FResPayment_Load(object sender, EventArgs e) {
            lblBuyerName.Text = currentAcc.FullName;
            definingBookedProduct();
            FillOtherInfo();
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
        private void FillOtherInfo() {
            decimal totalprice = 0;
            int numberofitems = 0;
            // Calculate total price of booked dish and drink items
            foreach (DataGridViewRow row in dataGridView1.Rows) {
                decimal price = Convert.ToDecimal(row.Cells["TotalPrice"].Value);
                totalprice += price;
                numberofitems += Convert.ToInt32(row.Cells["Quantity"].Value);
            }

            // Calculate shipping (if applicable)
            decimal shipping = (totalprice / 100) * 10;
            bill.totalPrice = totalprice;
            // Update the UI with calculated values
            lblTotalPrice.Text = (totalprice + shipping).ToString();
            lblShippingFee.Text = shipping.ToString();
            lblSubTotalPrice.Text = totalprice.ToString();
            lblNoOfItems.Text = numberofitems.ToString();

        }
        private void FillBill() {
            bill.customerName = txtName.Text;
            bill.customerEmail = string.Empty;
            if (this.rbtnOnline.Checked) {
                bill.paymentMethods = "Online";
            } else bill.paymentMethods = "Cash";
            bill.note = string.Empty;
            bill.customerPhone = txtPhone.Text;
            bill.customerAddress = txtAddress.Text;
            bill.voucherId = string.Empty;
            bill.status = "Pending";
            bill.date = DateTime.Now;
            bill.accId = currentAcc.AccId;
        }



        private void label2_Click(object sender, EventArgs e) {

        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void btnBuy_Click(object sender, EventArgs e) {
            FillBill();
            this.Hide();
            db.CreateBill(bill);
            MessageBox.Show("Done!");
            FResMain f = new FResMain();
            //FBill fBT = new FBill(billID);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}