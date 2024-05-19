using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Model
{
    public class Booking
    {
        private string bookID;
        private decimal totalPrice;
        private string accID;
        private DateTime timeBegin;
        private DateTime timeEnd;
        private string tableID;


        public Booking() { }
        public Booking(decimal totalPrice, string accID, DateTime timeBegin, DateTime timeEnd, string tableID)
        {
            this.totalPrice = totalPrice;
            this.accID = accID;
            this.timeBegin = timeBegin;
            this.timeEnd = timeEnd;
            this.tableID = tableID;
        }

        public Booking(string bookID, decimal totalPrice, string accID, DateTime timeBegin, DateTime timeEnd, string tableID)
        {
            this.bookID = bookID;
            this.totalPrice = totalPrice;
            this.accID = accID;
            this.timeBegin = timeBegin;
            this.timeEnd = timeEnd;
            this.tableID = tableID;
        }

        public string BookID { get => bookID; set => bookID = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string AccID { get => accID; set => accID = value; }
        public DateTime TimeBegin { get => timeBegin; set => timeBegin = value; }
        public DateTime TimeEnd { get => timeEnd; set => timeEnd = value; }
        public string TableID { get => tableID; set => tableID = value; }
    }
}
