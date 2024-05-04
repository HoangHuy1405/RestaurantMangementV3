using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code
{
    public class Bill
    {
        private string billId;
        private string billStatus;
        private string customerName;
        private string customerEmail;
        private string customerPhone;
        private string paymentMethods;
        private string note;
        private string status;
        private string totalPrice;

        public List<BookedProduct> bookedProducts = new List<BookedProduct>();

        public Bill() { }

        public Bill(string billId, string billStatus)
        {
            this.billId = billId;
            this.billStatus = billStatus;
        }

        public string BillId { get => billId; set => billId = value; }
        public string BillStatus { get => billStatus; set => billStatus = value; }
    }
}
