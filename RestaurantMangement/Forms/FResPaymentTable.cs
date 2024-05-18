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
        DBConnection db = new DBConnection();
        private Bill bill = new Bill();
        private BookedTable bookedTable = new BookedTable();
        public FResPaymentTable() {
            InitializeComponent();
        }
        public FResPaymentTable(Bill bill, BookedTable bookedTable) {
            InitializeComponent();
            this.bill = bill;
            this.bookedTable = bookedTable;
        }

        private void FResPaymentTable_Load(object sender, EventArgs e) {
            txtName.Text = bill.CustomerName;
            txtTableID.Text = bookedTable.TableID;
            txtRoomID.Text = bookedTable.RoomID;
            txtBeginTime.Text = bookedTable.TimeBegin.ToString();
            txtEndTime.Text = bookedTable.TimeEnd.ToString();
            txtRoomType.Text = bookedTable.RoomType;
            txtPricePerTable.Text = bookedTable.PricePerTable.ToString();
            txtQuantity.Text = bookedTable.Quantity.ToString();

            txtPrice.Text = bill.TotalPrice.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            /*db.CreateBill(bill);
            db.InsertDataIntoAccBookTable(bookedTable);
            this.Hide();
            FResBill frm = new FResBill(bill);
            frm.Closed += (s, args) => this.Close();
            frm.Show();*/
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
