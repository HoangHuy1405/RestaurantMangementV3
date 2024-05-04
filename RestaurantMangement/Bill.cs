using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement {
    internal class Bill {
        private int billId;
        private string billStatus;

        public Bill(int billId, string billStatus) {
            this.billId = billId;
            this.billStatus = billStatus;
        }

        public int BillId { get => billId; set => billId = value; }
        public string BillStatus { get => billStatus; set => billStatus = value; }
    }
}
