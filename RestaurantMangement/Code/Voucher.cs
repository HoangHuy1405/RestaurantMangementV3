using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code {
    public class Voucher {
        private string voucherName;
        private decimal discount;
        private DateTime exp_date;

        public Voucher() {
        }

        public Voucher(string voucherName, decimal discount, DateTime exp_date) {
            this.voucherName = voucherName;
            this.discount = discount;
            this.exp_date = exp_date;
        }

        public string VoucherName { get => voucherName; set => voucherName = value; }
        public decimal Discount { get => discount; set => discount = value; }
        public DateTime Exp_date { get => exp_date; set => exp_date = value; }
    }
}
