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
    public partial class FResPaymentTable : Form {
        private Bill bill = new Bill();
        private Table bookedTable = new Table();
        private Booking booking = new Booking();
        public FResPaymentTable() {
            InitializeComponent();
        }
        public FResPaymentTable(Bill bill, Table table, Booking booking) {
            InitializeComponent();
            this.bill = bill;
            this.bookedTable = table;
            this.booking = booking;
        }

        private void FResPaymentTable_Load(object sender, EventArgs e) {
            txtName.Text = bill.CustomerName;
            txtTableID.Text = bill.BookedTableID;
            txtRoomID.Text = bookedTable.RoomID;
            txtBeginTime.Text = booking.TimeBegin.ToString();
            txtEndTime.Text = booking.TimeEnd.ToString();
            txtRoomType.Text = Code.DAO.RoomDAO.instance().getroomType(bookedTable.RoomID);
            txtPricePerTable.Text = Code.DAO.RoomDAO.instance().getpricePerTable(bookedTable.RoomID).ToString();
            txtPrice.Text = bill.TotalPrice.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            decimal balance = Code.DAO.AccountDAO.instance().getAccountBalance();
            if (balance >= bill.TotalPrice) {
                MessageBox.Show("Success!");
                string billID = Code.DAO.BillDAO.instance().CreateBill(bill);
                Code.DAO.AccountDAO.instance().updateAccountBalance(bill.TotalPrice);
                FResLogin.currentAcc.Balance = Code.DAO.AccountDAO.instance().getAccountBalance();
                bill.BillId = billID;
                this.Hide();
                FResBill frm = new FResBill(bill);
                frm.Closed += (s, args) => this.Close();
                frm.Show();
            } else {
                MessageBox.Show("Invalid! Your account balance: " + FResLogin.currentAcc.Balance);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Hide();
            FResBookingTable frm = new FResBookingTable();
            Code.DAO.BookingDAO.instance().deleteBooking(bill.BookedTableID);
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e) {

        }
    }
}
