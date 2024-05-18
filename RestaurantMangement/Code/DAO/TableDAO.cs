using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace RestaurantMangement.Code.DAO
{
    public class TableDAO : DAOInterface<Table>
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public static TableDAO instance()
        {
            return new TableDAO();
        }

        public int delete(Table table)
        {
            int result = 0;
            try
            {   
                conn.Open();
                string query = "Delete from [Table] " +
                               "where tableID = '" + table.TableID + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return result;
        }

        public Table find(Table t)
        {
            throw new NotImplementedException();
        }

        public int insert(Table table)
        {
            int result = 0;
            try
            {   
                conn.Open();
                string query = "Insert into [Table] " +
                               "(numchairs, roomID) " +
                               "values (" + table.Numchair + ", '" + table.RoomID + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return result;
        }

        public List<Table> selectAll()
        {
            throw new NotImplementedException();
        }

        public Table selectByConditon(string condition)
        {
            throw new NotImplementedException();
        }

        public int update(Table table)
        {
            int result = 0;
            try
            {
                conn.Open();
                string query = "Update [Table] " +
                               "Set "+
                               "numchairs = '" + table.Numchair + "', " +
                               "roomID = '" + table.RoomID + "' " +
                               "where tableID = '" + table.TableID + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return result;
        }

        public DataTable loadTablebyRoom(string roomID)
        {
            DataTable dataTable = new DataTable();

            try
            {
                conn.Open();
                string query = "Select * " +
                               "from [Table] " +
                               "where roomID = '" + roomID + "'";

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

        public int getCurrentTable(string roomID)
        {
            int result = 0;
            try
            {
                conn.Open();
                string query = "Select [Current Table] " +
                               "from (" +


                                    "Select t.roomID, COUNT(t.tableID) [Current Table] " +
                                    "from [Table] t " +
                                    "group by t.roomID) t " +
                               "where roomID = '" + roomID + "'";

                SqlCommand cmd = new SqlCommand(query, conn);
                result = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return result;
        }   
    }
}
