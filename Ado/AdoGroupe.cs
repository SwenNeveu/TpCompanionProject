using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TpCompanionProject.Class;

namespace TpCompanionProject.Ado
{
    internal class AdoGroupe
    {
        // get connection to the db
        private Ado ado = new Ado();
        // get the group of a promotion
        public List<Groupe> GetGroupesByPromoId(Promotion promo)
        {
            List<Groupe> Groupes = new List<Groupe>();
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Groupe WHERE fk_id_promo = @id";
            command.Parameters.AddWithValue("id", promo.Id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Groupe Groupe = new Groupe(reader["Nom"].ToString());
                Groupe.Id = (int)reader["id_groupe"];
                Groupes.Add(Groupe);
            }
            ado.CloseConnection(connection);
            return Groupes;
        }
        //update a group
        public void UpdateGroupe(Groupe Groupe)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Groupe SET Nom = @nom WHERE id_groupe = @id";
            command.Parameters.AddWithValue("nom", Groupe.Nom);
            command.Parameters.AddWithValue("id", Groupe.Id);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }

        // add a group
        public void AddGroupe(Groupe Groupe, Promotion promo)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Groupe (Nom, fk_id_promo) VALUES (@nom, @fk_id_promo)";
            command.Parameters.AddWithValue("nom", Groupe.Nom);
            command.Parameters.AddWithValue("fk_id_promo", promo.Id);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
        // delete a group
        public void DeleteGroupe(Groupe Groupe)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Groupe WHERE id_groupe = @id";
            command.Parameters.AddWithValue("id", Groupe.Id);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
    }
}
