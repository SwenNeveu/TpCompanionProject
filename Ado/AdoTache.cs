using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCompanionProject.Class;
using MySql.Data.MySqlClient;

namespace TpCompanionProject.Ado
{
    internal class AdoTache
    {
        //get connection to the db
        private Ado ado = new Ado();
        
        //get taches for a tp
        public List<Tache> GetTachesByTp(Tp tp)
        {
            List<Tache> Taches = new List<Tache>();
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tache WHERE fk_id_tp = @id";
            command.Parameters.AddWithValue("id", tp.Id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Tache Tache = new Tache(reader["nom"].ToString() ,reader["description"].ToString(), (int)reader["ordre"], tp);
                Tache.Id = (int)reader["id_tache"];
                Taches.Add(Tache);
            }
            ado.CloseConnection(connection);
            return Taches;
        }
        //add tache
        public void AddTache(Tache tache, int idTp)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Tache (Nom, Description, Ordre, fk_id_tp) VALUES (@nom, @description, @ordre, @fk_id_tp)";
            command.Parameters.AddWithValue("nom", tache.Nom);
            command.Parameters.AddWithValue("description", tache.Description);
            command.Parameters.AddWithValue("ordre", tache.Ordre);
            command.Parameters.AddWithValue("fk_id_tp", idTp);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }

        //get tache dictionnary for an eleve
        public Dictionary<Tache, string> GetTachesByEleve(Eleve eleve)
        {
            Dictionary<Tache, string> Taches = new Dictionary<Tache, string>();
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM tache JOIN eleve_tache ON Tache.id_tache = Eleve_Tache.fk_id_tache WHERE fk_id_eleve = @id";
            command.Parameters.AddWithValue("id", eleve.Id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Tache Tache = new Tache(reader["nom"].ToString(), reader["description"].ToString(), (int)reader["ordre"], new Tp(reader["fk_id_tp"].ToString()));
                Tache.Id = (int)reader["id_tache"];
                Taches.Add(Tache, (string)reader["etat"]);
            }
            ado.CloseConnection(connection);
            return Taches;
        }
        

    }
}
