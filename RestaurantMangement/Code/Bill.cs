using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code
{
    internal class Bill
    {
        private string billId;
        private string billStatus;

        public Bill(string billId, string billStatus)
        {
            this.billId = billId;
            this.billStatus = billStatus;
        }

        public string BillId { get => billId; set => billId = value; }
        public string BillStatus { get => billStatus; set => billStatus = value; }
    }
}
