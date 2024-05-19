using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Model
{
    public class Category
    {
        private string cateID;
        private string cateName;

        public Category() { }
        public Category(string cateID, string cateName)
        {
            this.cateID = cateID;
            this.cateName = cateName;
        }

        public string CateID { get => cateID; set => cateID = value; }
        public string CateName { get => cateName; set => cateName = value; }
    }
}
