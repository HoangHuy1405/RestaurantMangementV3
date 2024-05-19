using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Model
{
    public class OrderDetail
    {
        private string odID;
        private int quantity;
        private string productID;
        private string productName;
        private decimal price;
        private string orderID;

        public OrderDetail(string productID, string productName, int quantity, decimal price) {
            this.productID = productID;
            this.productName = productName;
            this.quantity = quantity;
            this.price = price;
        }
        public OrderDetail(string odID, int quantity, string productID, string productName, decimal price, string orderID) {
            this.odID = odID;
            this.quantity = quantity;
            this.productID = productID;
            this.productName = productName;
            this.price = price;
            this.orderID = orderID;
        }

        public string OdID { get => odID; set => odID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public decimal Price { get => price; set => price = value; }
        public string OrderID { get => orderID; set => orderID = value; }
    }
}
