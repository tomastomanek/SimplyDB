﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data;
using System.Data.SqlClient;

namespace SimplyDB
{
    /// <summary>
    /// Class to control table person
    /// </summary>
    public class PersonTable
    {
        public static string SQL_INSERT = "INSERT INTO Person VALUES (@firstName, @lastName, @city, @age)";

        /// <summary>
        /// Insert person to database
        /// </summary>
        /// <param name="person">Person to insert</param>
        /// <returns>count of inserted rows</returns>
        public int Insert(Person person)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommmand(SQL_INSERT);
            PrepareCommand(command, person);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /// <summary>
        /// Prepare sql command
        /// </summary>
        /// <param name="command">sql command</param>
        /// <param name="person">person</param>
        public void PrepareCommand (SqlCommand command, Person person)
        {
            command.Parameters.Add(new SqlParameter("@idPerson", SqlDbType.Int));
            command.Parameters["@idPerson"].Value = person.IdPerson;

            command.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar, person.FirstName.Length));
            command.Parameters["@firstName"].Value = person.FirstName;

            command.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar, person.LastName.Length));
            command.Parameters["@lastName"].Value = person.LastName;

            command.Parameters.Add(new SqlParameter("@city", SqlDbType.VarChar, person.City.Length));
            command.Parameters["@city"].Value = person.City;

            command.Parameters.Add(new SqlParameter("@age", SqlDbType.Int));
            command.Parameters["@age"].Value = person.Age;

        }
    }
}
