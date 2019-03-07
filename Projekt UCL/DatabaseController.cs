using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Projekt_UCL
{
    class DatabaseController
    {
        private static string connectionString =
       "Server = ealSQL1.eal.local; Database = A_DB08_2018; User Id = A_STUDENT08; Password = A_OPENDB08;";

        public void InsertPerson(Person person)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd1 = new SqlCommand("InsertPersonInfo", conn);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add(new SqlParameter("@Fornavn", person.Fornavn));
                    cmd1.Parameters.Add(new SqlParameter("@Køn", person.Køn));
                    

                    cmd1.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Hovsa: " + e.Message);
                }
                
            }
        }

    }
}
