using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Model
{
    public class Order
    {
        private string orderID;
        private DateTime date;
        private decimal totalPrice;
        private string accID;

        private List<OrderDetail> orderList = new List<OrderDetail>();

        public Order() { }

        public Order(string orderID, DateTime date, decimal totalPrice, string note, string accID)
        {
            this.orderID = orderID;
            this.date = date;
            this.totalPrice = totalPrice;
            this.accID = accID;
        }

        public string OrderID { get => orderID; set => orderID = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string AccID { get => accID; set => accID = value; }
        public List<OrderDetail> OrderList { get => orderList; set => orderList = value; }
    }
}
