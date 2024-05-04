using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code {
    public class BookedProduct {
        string productId, productName;
        int quantity;
        decimal totalprice = 0, normalPrice = 0;

        public BookedProduct() {
        }

        public BookedProduct(string productId, string productName, int quantity, decimal normalPrice) {
            this.productId = productId;
            this.productName = productName;
            this.quantity = quantity;
            this.normalPrice = normalPrice;
            this.totalprice = normalPrice* quantity;
        }

        public string ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal Totalprice { get => totalprice; set => totalprice = value; }
        public decimal NormalPrice { get => normalPrice; set => normalPrice = value; }
    }
}
