using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Model
{
    public class Room
    {
        private string roomID;
        private string type;

        public Room(string roomID, string type)
        {
            this.roomID = roomID;
            this.type = type;
        }

        public string RoomID { get => roomID; set => roomID = value; }
        public string Type { get => type; set => type = value; }
    }
}
