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
        public string billId;
        public DateTime date;
        public string customerAddress;
        public string customerName;
        public string customerEmail;
        public string customerPhone;
        public string paymentMethods;
        public string note;
        public string billStatus;
        public string status;
        public decimal totalPrice;
        public string accId;
        public string voucherId;

        public List<BookedProduct> bookedProducts = new List<BookedProduct>();

        public Bill() { }

        public Bill(string billId, string billStatus)
        {
            this.billId = billId;
            this.billStatus = billStatus;
        }
    }
}
