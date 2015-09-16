using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SimplyDB
{
    /// <summary>
    /// Class represent database connection
    /// </summary>
    public class Database
    {
        private SqlConnection Connection;
        private string ConString = "Server=TOM-PC\\SQLEXPRESS;Database=SimplyDB;Trusted_Connection=yes;";

        /// <summary>
        /// Nonparametric constructor
        /// </summary>
        public Database()
        {
            Connection = new SqlConnection();
        }

        /// <summary>
        /// Create connection
        /// </summary>
        public void Connect ()
        {
            if(Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.ConnectionString = ConString;
                Connection.Open();
            }
        }

        /// <summary>
        /// Close connection
        /// </summary>
        public void Close()
        {
            Connection.Close();
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="command">Sql command</param>
        /// <returns>count of affected rows</returns>
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

        /// <summary>
        /// Create sql command from string
        /// </summary>
        /// <param name="strCommand">string represent sql command</param>
        /// <returns>command</returns>
        public SqlCommand CreateCommmand(string strCommand)
        {
            SqlCommand command = new SqlCommand(strCommand, Connection);

            return command;
        }
    }
}
