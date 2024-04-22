using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace TpCompanionProject.Ado
{
    public class Ado
    {
        private string connectionString = "SERVER=localhost; DATABASE=tpcompanion; UID=swen; PASSWORD=pwd";

        // Connection to the db
        public MySqlConnection OpenConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine("Error opening database connection: " + ex.Message);
                return null; // Or throw the exception if you want to propagate it
            }
        }

        public void CloseConnection(MySqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
}
