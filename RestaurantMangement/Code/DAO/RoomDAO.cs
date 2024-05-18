using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Collections;

namespace RestaurantMangement.Code.DAO
{
    public class RoomDAO : DAOInterface<Room>
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public static RoomDAO instance()
        {
            return new RoomDAO();
        }
        public int delete(Room t)
        {
            throw new NotImplementedException();
        }

        public Room find(Room t)
        {
            throw new NotImplementedException();
        }

        public int insert(Room t)
        {
            throw new NotImplementedException();
        }

        public List<Room> selectAll()
        {
            throw new NotImplementedException();
        }

        public Room selectByConditon(string query)
        {
            Room room = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string roomID = reader.GetString(0);
                        string type = reader.GetString(1);
                        decimal pricePerTable = reader.GetDecimal(2);
                        int maxTable = reader.GetInt32(3);

                        room = new Room(roomID, type, pricePerTable, maxTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return room;

        }

        public int update(Room t)
        {
            throw new NotImplementedException();
        }

        public DataTable loadRoom()
        {
            DataTable dataTable = new DataTable();

            try
            {
                conn.Open();
                string query = "Select r.roomID, r.type, r.pricePerTable, t.[Current Table], r.maxTable " +
                               "from " +
                                    "(Select t.roomID, COUNT(t.tableID) [Current Table] " +
                                    "from [Table] t " +
                                    "group by t.roomID) t " +
                               "right join " +
                                    "(Select * " +
                                    "from Room r) r " +
                               "on t.roomID = r.roomID";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dataTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return dataTable;
        }

        public DataTable getAllRoomID() 
        {
            DataTable table = new DataTable();

            try
            {
                conn.Open();
                string query = "Select roomID " +
                               "from Room";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                
                adapter.Fill(table);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }

            return table;
        }
    }
}
