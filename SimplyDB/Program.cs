using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pers = new Person("Adam", "Mrkvicka", "Piešťany", 30);

            PersonTable persTable = new PersonTable();
            try
            {
                persTable.Insert(pers);
                Console.WriteLine(pers.ToString() + " úspešne vložený");
            }
            catch (Exception e)
            {
                Console.WriteLine("Chyba pri vložení");
            }
            Console.ReadLine();


        }
    }
}
