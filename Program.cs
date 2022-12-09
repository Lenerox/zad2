// See https://aka.ms/new-console-template for more information
//Karolu to żyje!!
using System.Data.SqlClient;
using System.Data;
//Console.WriteLine("Hello, World!");

namespace ConnectingToSQLServer

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");

            string connString = "Server= localhost; Database= master; Integrated Security=SSPI;"; //Database 

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
           
            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            ReadOrderData(connString);
/*
            try
            {
                SqlCommand odczyt = new SqlCommand("SELECT * FROM [Categories].[dbo].[Categories_1]");
                //Console.WriteLine(odczyt.ToString());
                SqlDataReader
                //SqlDataAdapter
                Console.WriteLine(conn.GetSchema());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            */
            Console.Read();
            conn.Close();
        }
    private static void ReadOrderData(string connectionString)
    {
        string queryString = "SELECT OrderID, CustomerID, OrderDate FROM dbo.Orders;";//kolumny z bazy danych

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            // Call Close when done reading.
            reader.Close();
        }
    }

    private static void ReadSingleRow(IDataRecord dataRecord)
    {
        Console.WriteLine(String.Format("{0}, {1}, {2} ", dataRecord[0], dataRecord[1], dataRecord[2]));
    }
    }
}
