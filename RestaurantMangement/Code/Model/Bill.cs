using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Model
{
    public class Bill
    {
        private string billId;
        private string orderID;
        private string bookedTableID;
        private string voucherId;
        private string accID;
        private DateTime date;
        private string customerAddress;
        private string customerName;
        private string customerEmail;
        private string customerPhone;
        private string paymentMethods;
        private string status;
        private decimal totalPrice;
        private string type;
        private string note;
        

        public Bill() { }

        public Bill(string billId, string orderID, string bookedTableID, DateTime date, string customerAddress, string customerName, string customerEmail, string customerPhone, string paymentMethods, string status, decimal totalPrice, string type, string voucherId)
        {
            this.billId = billId;
            this.orderID = orderID;
            this.bookedTableID = bookedTableID;
            this.date = date;
            this.customerAddress = customerAddress;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.customerPhone = customerPhone;
            this.paymentMethods = paymentMethods;
            this.status = status;
            this.totalPrice = totalPrice;
            this.type = type;
            this.voucherId = voucherId;
        }

        public string BillId { get => billId; set => billId = value; }
        public string OrderID { get => orderID; set => orderID = value; }
        public string BookedTableID { get => bookedTableID; set => bookedTableID = value; }
        public DateTime Date { get => date; set => date = value; }
        public string CustomerAddress { get => customerAddress; set => customerAddress = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string CustomerEmail { get => customerEmail; set => customerEmail = value; }
        public string CustomerPhone { get => customerPhone; set => customerPhone = value; }
        public string PaymentMethods { get => paymentMethods; set => paymentMethods = value; }
        public string Status { get => status; set => status = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Type { get => type; set => type = value; }
        public string VoucherId { get => voucherId; set => voucherId = value; }
        public string AccID { get => accID; set => accID = value; }
        public string Note { get => note; set => note = value; }
    }
}
