using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.DAO
{
    public interface DAOInterface<T>
    {
        public int insert(T t);
        public int update(T t);
        public int delete(T t);
        public T find(T t);
        public List<T> selectAll();
        public T selectByConditon(string condition);

    }
}
