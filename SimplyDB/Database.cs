using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SimplyDB
{
    public class Database
    {
        private SqlConnection Connection;
        private string ConString = "Server=TOM-PC\\SQLEXPRESS;Database=SimplyDB;Trusted_Connection=yes;";

        public Database()
        {
            Connection = new SqlConnection();
        }

        public void Connect ()
        {
            if(Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.ConnectionString = ConString;
                Connection.Open();
            }
        }
        public void Close()
        {
            Connection.Close();
        }

        public int ExecuteNonQuery (SqlCommand command)
        {
            int rowNumber = 0;
            try
            {
                command.Prepare();
                rowNumber = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Close();
            }
            return rowNumber;
        }

        public SqlCommand CreateCommmand(string strCommand)
        {
            SqlCommand command = new SqlCommand(strCommand, Connection);

            return command;
        }
    }
}
