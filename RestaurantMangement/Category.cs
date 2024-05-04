using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement {
    internal class Category {
        private int cateID;
        private string cateName;

        public Category() { }
        public Category(int cateID, string cateName) {
            this.cateID = cateID;
            this.cateName = cateName;
        }
        public Category(string cateName) {
            this.cateName=cateName;
        }

        public int CateID { get => cateID; set => cateID = value; }
        public string CateName { get => cateName; set => cateName = value; }
    }
}
