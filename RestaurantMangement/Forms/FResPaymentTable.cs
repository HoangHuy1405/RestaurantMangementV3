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
        string quantity = string.Empty;
        public FResPaymentTable() {
            InitializeComponent();
        }
        public FResPaymentTable(Bill bill, Table table, Booking booking, string quantity) {
            InitializeComponent();
            this.bill = bill;
            this.bookedTable = table;
            this.booking = booking;
            this.quantity = quantity;
        }

        private void FResPaymentTable_Load(object sender, EventArgs e) {
            txtName.Text = bill.CustomerName;
            txtTableID.Text = bill.BookedTableID;
            txtRoomID.Text = bookedTable.RoomID;
            txtBeginTime.Text = booking.TimeBegin.ToString();
            txtEndTime.Text = booking.TimeEnd.ToString();
            txtRoomType.Text = Code.DAO.RoomDAO.instance().getroomType(bookedTable.RoomID);
            txtPricePerTable.Text = Code.DAO.RoomDAO.instance().getpricePerTable(bookedTable.RoomID).ToString();
            txtQuantity.Text = quantity;
            txtPrice.Text = bill.TotalPrice.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            string billID = Code.DAO.BillDAO.instance().CreateBill(bill);
            this.Hide();
            FResBill frm = new FResBill(bill);
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Hide();
            FResBookingTable frm = new FResBookingTable();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e) {

        }
    }
}
