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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestaurantMangement.Forms
{
    public partial class FResBookingTable : Form {
        public FResBookingTable() {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e) {
            this.Hide();
            FResMain frm = new FResMain();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        private void btnBook_Click(object sender, EventArgs e) {
            string tableID = checkAvailableTable();
            if (string.IsNullOrEmpty(tableID)) {
                MessageBox.Show("Out of table in that time");
                return;
            } else MessageBox.Show(tableID);

            string accID = FResLogin.currentAcc.AccID;

            // get booked Table information
            Table bookedTable = Code.DAO.TableDAO.instance().getTableInformation(tableID);
            decimal pricePerTable = Code.DAO.RoomDAO.instance().getpricePerTable(bookedTable.RoomID);
            
            // fill the rest of bookedTable
            DateTime timeBegin = calculateDateTime(dtBookingDate.Value.Date, cbBeginHour.SelectedItem, cbBeginMinutes.SelectedItem);
            DateTime timeEnd = calculateDateTime(dtBookingDate.Value.Date, cbEndHour.SelectedItem, cbEndMinutes.SelectedItem);

            decimal totalPrice = (int)NumQuantity.Value * pricePerTable;
            Booking booking = new Booking(totalPrice,accID,timeBegin,timeEnd,tableID);

            string bookingID = Code.DAO.BookingDAO.instance().insert(booking);

            // fill bill information

            string accId = FResLogin.currentAcc.AccID;
            string voucherId = string.Empty;
            DateTime date = DateTime.Now;
            string customerAddress = "So 1 Vo Van Ngan";
            string customerName = txtName.Text;
            string customerEmail = txtEmail.Text;
            string customerPhone = txtPhoneNumber.Text;
            string paymentMethods = "Online";
            string status = "Pending";
            string note = txtNote.Text;
            string type = "Booking";

            Bill bill = new Bill(string.Empty,bookingID,voucherId,accId,date,customerAddress,customerName,customerEmail,customerPhone,paymentMethods,status,totalPrice,type,note);
            
            // move to new form
            this.Hide();
            FResPaymentTable frm = new FResPaymentTable(bill, bookedTable, booking, NumQuantity.Value.ToString());
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        private string checkAvailableTable() {
            DateTime beginTime = calculateDateTime(dtBookingDate.Value.Date, cbBeginHour.SelectedItem, cbBeginMinutes.SelectedItem);
            DateTime endTime = calculateDateTime(dtBookingDate.Value.Date, cbEndHour.SelectedItem, cbEndMinutes.SelectedItem);

            if (beginTime >= endTime) {
                MessageBox.Show("Invalid Time");
                return null;
            }

            string beginTimeFormatted = beginTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endTimeFormatted = endTime.ToString("yyyy-MM-dd HH:mm:ss");

            string roomType = cbRoomType.SelectedItem.ToString();
            string tableID = Code.DAO.TableDAO.instance().CheckTableAvailability(beginTimeFormatted, endTimeFormatted, roomType);

            return tableID;
        }

        private DateTime calculateDateTime(DateTime date, object hour, object minutes) {
            // Get the selected date from dtBookingDate
            DateTime selectedDate = date;

            // Get the selected hour and minute from cbbHour and cbbMinutes
            int selectedHour = Convert.ToInt32(hour);
            int selectedMinute = Convert.ToInt32(minutes);

            // Create a new DateTime object combining the date, hour, and minute
            DateTime calculatedDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, selectedHour, selectedMinute, 0);

            return calculatedDateTime;
        }

        private void btnAddTable_Click(object sender, EventArgs e) {
            if (FResLogin.isAdmin) {
                this.Hide();
                FResAddTable frm = new FResAddTable();
                frm.Closed += (s, args) => this.Close();
                frm.Show();
            } else {
                MessageBox.Show("Admin access requirement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
