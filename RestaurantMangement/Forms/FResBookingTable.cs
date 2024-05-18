using Microsoft.VisualBasic;
using RestaurantMangement.Code;
using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMangement.Forms
{
    public partial class FResBookingTable : Form
    {
        DBConnection db = new DBConnection();
        Account currentAcc = FResLogin.currentAcc;
        bool isAdmin = FResLogin.isAdmin;
        Bill bill = new Bill();
        BookedTable bookedTable = new BookedTable();
        decimal totalprice = 0;
        public FResBookingTable()
        {
            InitializeComponent();
        }
        private void FBookingTable_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            FResMain frm = new FResMain();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        private void btnChooseTable_Click(object sender, EventArgs e)
        {
            this.Hide();
            FChooseTable frm = new FChooseTable();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }
        private void fillBill()
        {
            /*bill.CustomerName = txtName.Text;
            bill.CustomerEmail = currentAcc.Email;
            bill.PaymentMethods = "Online";
            bill.Note = txtNote.Text;
            bill.CustomerPhone = txtPhoneNumber.Text;
            bill.CustomerAddress = "So 1 Vo Van Ngan";
            bill.VoucherId = string.Empty;
            bill.Status = "Pending";
            bill.Date = DateTime.Now;
            bill.AccId = currentAcc.AccId;*/
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            string tableID = checkAvailableTable();
            if (string.IsNullOrEmpty(tableID))
            {
                MessageBox.Show("Out of table in that time");
                return;
            }
            else MessageBox.Show(tableID);

            // fill booked Table information
            bookedTable = db.loadBookedTableFromTableID(tableID);
            // fill the rest of bookedTable
            DateTime beginTime = calculateDateTime(dtBookingDate.Value.Date, cbBeginHour.SelectedItem, cbBeginMinutes.SelectedItem);
            DateTime endTime = calculateDateTime(dtBookingDate.Value.Date, cbEndHour.SelectedItem, cbEndMinutes.SelectedItem);
            bookedTable.TimeBegin = beginTime;
            bookedTable.TimeEnd = endTime;
            bookedTable.Quantity = (int)NumQuantity.Value;

            // fill bill information
            fillBill();
            bill.TotalPrice = (int)NumQuantity.Value * bookedTable.PricePerTable;

            // move to new form
            this.Hide();
            FResPaymentTable frm = new FResPaymentTable(bill, bookedTable);
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }
        private string checkAvailableTable()
        {
            DateTime beginTime = calculateDateTime(dtBookingDate.Value.Date, cbBeginHour.SelectedItem, cbBeginMinutes.SelectedItem);
            DateTime endTime = calculateDateTime(dtBookingDate.Value.Date, cbEndHour.SelectedItem, cbEndMinutes.SelectedItem);


            if (beginTime >= endTime)
            {
                MessageBox.Show("Invalid Time");
                return "";
            }

            string beginTimeFormatted = beginTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endTimeFormatted = endTime.ToString("yyyy-MM-dd HH:mm:ss");

            string roomType = cbRoomType.SelectedItem.ToString();
            string tableID = db.CheckTableAvailability(beginTimeFormatted, endTimeFormatted, roomType);

            return tableID;
        }
        private DateTime calculateDateTime(DateTime date, object hour, object minutes)
        {
            // Get the selected date from dtBookingDate
            DateTime selectedDate = date;

            // Get the selected hour and minute from cbbHour and cbbMinutes
            int selectedHour = Convert.ToInt32(hour);
            int selectedMinute = Convert.ToInt32(minutes);

            // Create a new DateTime object combining the date, hour, and minute
            DateTime calculatedDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, selectedHour, selectedMinute, 0);

            return calculatedDateTime;
        }

        private void cbBeginMinutes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if(FResLogin.isAdmin) {
                this.Hide();
                FResAddTable frm = new FResAddTable();
                frm.Closed += (s, args) => this.Close();
                frm.Show();
            } else {
                MessageBox.Show("Admin access requirement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOrderMore_Click(object sender, EventArgs e) {

        }
    }
}
