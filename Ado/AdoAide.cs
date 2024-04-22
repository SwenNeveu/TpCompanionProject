using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCompanionProject.Class;
using MySql.Data.MySqlClient;
using System.Windows.Controls.Primitives;

namespace TpCompanionProject.Ado
{
    internal class AdoAide
    {
        //get connection to the db
        private Ado ado = new Ado();
        //get aides for a tp
        public List<Aide> GetAidesByTpId(Tp tp)
        {
            List<Aide> Aides = new List<Aide>();
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM aide INNER JOIN eleve ON aide.fk_id_eleve = eleve.id_eleve WHERE fk_id_tp = @id";
            command.Parameters.AddWithValue("id", tp.Id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Aide Aide = new Aide(reader["Description"].ToString(), new Eleve(reader["nom"].ToString(), reader["prenom"].ToString()));
                Aide.Id = (int)reader["Id_aide"];
                Aide.DteDemande = (DateTime)reader["Dte_Demande"];
                Aides.Add(Aide);
            }
            ado.CloseConnection(connection);
            return Aides;
        }
        //get aide for an eleve
        public List<Aide> GetAidesByEleveId(Eleve eleve)
        {
            List<Aide> Aides = new List<Aide>();
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM aide INNER JOIN eleve ON aide.fk_id_eleve = eleve.id_eleve WHERE eleve.id_eleve = @id";
            command.Parameters.AddWithValue("id", eleve.Id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Aide Aide = new Aide(reader["Description"].ToString(), eleve);
                Aide.Id = (int)reader["Id_eleve"];
                Aide.DteDemande = (DateTime)reader["Dte_Demande"];
                Aides.Add(Aide);
            }
            ado.CloseConnection(connection);
            return Aides;
        }

        //add aide
        public void AddAide(Aide aide, int idTp)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Aide (Description, Dte_Demande, fk_id_eleve, fk_id_tp) VALUES (@description, @dteDemande, @fk_id_eleve, @fk_id_tp)";
            command.Parameters.AddWithValue("description", aide.Description);
            command.Parameters.AddWithValue("dte_Demande", aide.DteDemande);
            command.Parameters.AddWithValue("fk_id_eleve", aide.Eleve.Id);
            command.Parameters.AddWithValue("fk_id_tp", idTp);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }

        //delete aide
        public void DeleteAide(Aide aide)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Aide WHERE Id = @id";
            command.Parameters.AddWithValue("id", aide.Id);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
        


    }
}
