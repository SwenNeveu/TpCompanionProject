using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCompanionProject.Class;
using MySql.Data.MySqlClient;

namespace TpCompanionProject.Ado
{
    internal class AdoEleve
    {
        //get connection to the db
        private Ado ado = new Ado();
        
        //get all the students from a promotion
        public List<Eleve> GetAllEleveByPromo(Promotion promo)
        {
            List<Eleve> Eleves = new List<Eleve>();
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Eleve WHERE fk_id_promo = @fk_id_promo";
            command.Parameters.AddWithValue("fk_id_promo", promo.Id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Eleve Eleve = new Eleve(reader["nom"].ToString(), reader["prenom"].ToString()) ;
                Eleve.Id = (int)reader["id_eleve"];
                Eleves.Add(Eleve);
            }
            ado.CloseConnection(connection);
            return Eleves;
        }

        //get student from a group
        public List<Eleve> GetElevesByGroupe(int fk_id_groupe)
        {
            List<Eleve> Eleves = new List<Eleve>();
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Eleve WHERE fk_id_groupe = @fk_id_groupe";
            command.Parameters.AddWithValue("fk_id_groupe", fk_id_groupe);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Eleve Eleve = new Eleve(reader["nom"].ToString(), reader["prenom"].ToString());
                Eleve.Id = (int)reader["id_eleve"];
                Eleves.Add(Eleve);
            }
            ado.CloseConnection(connection);
            return Eleves;
        }
        //add a student to a promotion
        public void AddEleve(Eleve Eleve, int fk_id_promo)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Eleve (Nom, Prenom, fk_id_promo) VALUES (@nom, @prenom, @fk_id_promo)";
            command.Parameters.AddWithValue("nom", Eleve.Nom);
            command.Parameters.AddWithValue("prenom", Eleve.Prenom);
            command.Parameters.AddWithValue("fk_id_promo", fk_id_promo);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
        //add a student to a group and a prom
        public void AddEleve(Eleve Eleve, int fk_id_groupe, int fk_id_promo)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Eleve (Nom, Prenom, fk_id_groupe, fk_id_promo) VALUES (@nom, @prenom, @fk_id_groupe, @fk_id_promo)";
            command.Parameters.AddWithValue("nom", Eleve.Nom);
            command.Parameters.AddWithValue("prenom", Eleve.Prenom);
            command.Parameters.AddWithValue("fk_id_groupe", fk_id_groupe);
            command.Parameters.AddWithValue("fk_id_promo", fk_id_promo);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
        //delete a student
        public void DeleteEleve(Eleve Eleve) 
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Eleve WHERE id_eleve = @id";
            command.Parameters.AddWithValue("id", Eleve.Id);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
        //update a student

        public void UpdateEleve(Eleve Eleve)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Eleve SET Nom = @nom, Prenom = @prenom WHERE id_eleve = @id";
            command.Parameters.AddWithValue("nom", Eleve.Nom);
            command.Parameters.AddWithValue("prenom", Eleve.Prenom);
            command.Parameters.AddWithValue("id", Eleve.Id);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
    }
}
