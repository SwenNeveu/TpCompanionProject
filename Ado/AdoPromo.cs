using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TpCompanionProject.Class;

namespace TpCompanionProject.Ado
{
    internal class AdoPromo
    {
        //get connection to the db
        private Ado ado = new Ado();
        //get all the promotions
        public List<Promotion> GetAllPromo()
        {

            List<Promotion> Promotions = new List<Promotion>();
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM promotion";

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Promotion Promotion = new Promotion(reader["nom"].ToString());
                Promotion.Id = (int)reader["id_promo"];
                Promotions.Add(Promotion);
            }
            ado.CloseConnection(connection);
            return Promotions;
        }

        

        //add a promotion
        public void AddPromo(Promotion Promotion)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Promotion (Nom) VALUES (@nom)";
            command.Parameters.AddWithValue("nom", Promotion.Nom);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
        //update a promotion
        public void UpdatePromo(Promotion Promotion)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Promotion SET Nom = @nom WHERE id_promo = @id";
            command.Parameters.AddWithValue("nom", Promotion.Nom);
            command.Parameters.AddWithValue("id", Promotion.Id);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
        //delete a promotion
        public void DeletePromo(Promotion Promotion)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Promotion WHERE id_promo = @id";
            command.Parameters.AddWithValue("id", Promotion.Id);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }

        
    }
}
