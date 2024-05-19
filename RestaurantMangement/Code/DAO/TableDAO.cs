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
    public class TableDAO
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

        public Table getTableFromQuery(string query)
        {
            Table table = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string tableID = reader.GetString(0);
                        int numchairs = reader.GetInt32(1);
                        string roomID = reader.GetString(2);

                        table = new Table(tableID, numchairs, roomID);
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
            return table;
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

        public string CheckTableAvailability(string timeBegin, string timeEnd, string roomType)
        {
            string tableID = null;
            string sqlQuery = @"SELECT t.tableID
                            FROM [Table] t
                            JOIN Room r ON t.roomID = r.roomID
                            WHERE r.type = @RoomType
                            AND t.tableID NOT IN
                            (
                                SELECT tableID
                                FROM Booking
                                WHERE NOT
                                (
                                    timeEnd <= @TimeBegin
                                    OR timeBegin >= @TimeEnd
                                )
                            )";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@TimeBegin", timeBegin);
                cmd.Parameters.AddWithValue("@TimeEnd", timeEnd);
                cmd.Parameters.AddWithValue("@RoomType", roomType);

                tableID = (string)cmd.ExecuteScalar();

            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return tableID;
        }

        public Table getTableInformation(string tableID)
        {
            Table table = null;

            try
            {
                conn.Open();
                string query = "Select * " +
                               "from [Table] " +
                               "where tableID = '" + tableID + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        int numchairs = reader.GetInt32(1);
                        string roomID = reader.GetString(2);

                        table = new Table(tableID, numchairs, roomID);
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
            return table;
        }

    }
}
