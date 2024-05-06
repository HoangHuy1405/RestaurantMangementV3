using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code {
    public class BookedTable {
        private string roomID, tableID, roomType;
        private decimal pricePerTable;
        private int quantity;
        private DateTime timeBegin, timeEnd;

        public BookedTable() { }

        public BookedTable(string roomID, string tableID, string roomType, decimal pricePerTable, int quantity, DateTime timeBegin, DateTime timeEnd) {
            this.roomID = roomID;
            this.tableID = tableID;
            this.roomType = roomType;
            this.pricePerTable = pricePerTable;
            this.timeBegin = timeBegin;
            this.timeEnd = timeEnd;
            this.quantity = quantity;
        }

        public string RoomID { get => roomID; set => roomID = value; }
        public string TableID { get => tableID; set => tableID = value; }
        public string RoomType { get => roomType; set => roomType = value; }
        public decimal PricePerTable { get => pricePerTable; set => pricePerTable = value; }
        public DateTime TimeBegin { get => timeBegin; set => timeBegin = value; }
        public DateTime TimeEnd { get => timeEnd; set => timeEnd = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
