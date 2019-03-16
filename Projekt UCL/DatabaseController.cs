using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Projekt_UCL
{
    public class DatabaseController
    {
        private static DatabaseController databaseController;

        public static DatabaseController Instance
        {
            get
            {
                if (databaseController == null)
                {
                    databaseController = new DatabaseController();
                }
                return databaseController;
            }
        }


        private static string connectionString =
       "Server = ealSQL1.eal.local; Database = A_DB08_2018; User Id = A_STUDENT08; Password = A_OPENDB08;";

        public void InsertPerson(string Fornavn, string Køn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand AddPerson = new SqlCommand("InsertPersonInfo", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    AddPerson.Parameters.Add(new SqlParameter("@Fornavn", Fornavn));
                    AddPerson.Parameters.Add(new SqlParameter("@Køn", Køn));


                    AddPerson.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Ups: " + e.Message);
                }

            }
        }

        public void GetPerson(OpretPerson opretPerson)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand GetPerson = new SqlCommand("GetPerson", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    SqlDataReader reader = GetPerson.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string PersonName = reader["Fornavn"].ToString();

                            opretPerson.listViewTB.Items.Add(new Person
                            {
                                Fornavn = reader["Fornavn"].ToString(),
                                Køn = reader["Køn"].ToString()
                            });
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Ups: " + e.Message);
                }
            }
        }

        public void DeletePerson(string Name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand DeletePerson = new SqlCommand("DeletePerson", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    DeletePerson.Parameters.Add(new SqlParameter("@Fornavn", Name));
                    DeletePerson.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Ups: " + e.Message);
                }
            }
        }

    }
}
