using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDB
{
    /// <summary>
    /// Class represent data entity Person
    /// </summary>
    public class Person
    {
        public int IdPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="firstName">first name</param>
        /// <param name="lastName">last name</param>
        /// <param name="city">city</param>
        /// <param name="age">age</param>
        public Person(string firstName, string lastName, string city, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.City = city;
            this.Age = age;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
