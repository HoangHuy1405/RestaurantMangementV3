using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code {
    internal class BookedTable {
        string roomid, tableid, roomtye;
        int numberofchair;
        decimal price;
        public BookedTable(string roomid, string tableid, string roomtye, int numberofchair, decimal price) {
            this.roomid = roomid;
            this.tableid = tableid;
            this.roomtye = roomtye;
            this.numberofchair = numberofchair;
            this.price = price;
        }
        public string RoomID { get { return roomid; } }
        public string TableID { get { return tableid; } }
        public string RoomType { get { return roomtye; } }
        public int NumberOfChairs { get { return numberofchair; } }
        public decimal PricePerTable { get { return price; } }
    }
}
