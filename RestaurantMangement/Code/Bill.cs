using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code
{
    public class Bill
    {
        private string billId;
        private DateTime date;
        private string customerAddress;
        private string customerName;
        private string customerEmail;
        private string customerPhone;
        private string paymentMethods;
        private string note;
        private string billStatus;
        private string status;
        private decimal totalPrice;
        private string accId;
        private string voucherId;

        public List<BookedProduct> bookedProducts = new List<BookedProduct>();

        public Bill() { }

        public Bill(string billId, string billStatus)
        {
            this.billId = billId;
            this.billStatus = billStatus;
        }
        public string BillId { get => billId; set => billId = value; }
        public DateTime Date { get => date; set => date = value; }
        public string CustomerAddress { get => customerAddress; set => customerAddress = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string CustomerEmail { get => customerEmail; set => customerEmail = value; }
        public string CustomerPhone { get => customerPhone; set => customerPhone = value; }
        public string PaymentMethods { get => paymentMethods; set => paymentMethods = value; }
        public string Note { get => note; set => note = value; }
        public string BillStatus { get => billStatus; set => billStatus = value; }
        public string Status { get => status; set => status = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string AccId { get => accId; set => accId = value; }
        public string VoucherId { get => voucherId; set => voucherId = value; }
    }
}
