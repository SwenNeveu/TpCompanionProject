using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpCompanionProject.Class;

namespace TpCompanionProject.Ado
{
    internal class AdoTp
    {
        //get the connection to the db
        private Ado ado = new Ado();
        
        //get the tps for a promotion
        public List<Tp> GetTpsByPromo(int fk_id_promo)
        {
            List<Tp> Tps = new List<Tp>();
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tp WHERE fk_id_promo = @fk_id_promo AND fk_id_groupe IS NULL";
            command.Parameters.AddWithValue("fk_id_promo", fk_id_promo);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Tp Tp = new Tp(reader["Nom"].ToString(), (DateTime)reader["Dte_Debut"], (DateTime)reader["dte_Fin"], (bool)reader["is_visible"]) ;
                Tp.Id = (int)reader["id_tp"];
                Tps.Add(Tp);
            }
            ado.CloseConnection(connection);
            return Tps;
        }
        //get the tps for a group in a promotion
        public List<Tp> GetTpsByGroupe(int fk_id_groupe, int fk_id_promo)
        {
            List<Tp> Tps = new List<Tp>();
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tp WHERE fk_id_groupe = @fk_id_groupe AND fk_id_promo = @fk_id_promo";
            command.Parameters.AddWithValue("fk_id_groupe", fk_id_groupe);
            command.Parameters.AddWithValue("fk_id_promo", fk_id_promo);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Tp Tp = new Tp(reader["Nom"].ToString(), (DateTime)reader["Dte_Debut"], (DateTime)reader["dte_Fin"], (Boolean)reader["is_visible"]);
                Tp.Id = (int)reader["Id_tp"];
                Tps.Add(Tp);
            }
            ado.CloseConnection(connection);
            return Tps;
        }
        //insert a tp
        public void AddTp(Tp Tp, int fk_id_promo)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Tp (Nom, Dte_Debut, Dte_Fin, is_visible, fk_id_promo) VALUES (@nom, @dte_debut, @dte_fin, @is_visible, @fk_id_promo)";
            command.Parameters.AddWithValue("nom", Tp.Nom);
            command.Parameters.AddWithValue("dte_debut", Tp.Dte_Debut);
            command.Parameters.AddWithValue("dte_fin", Tp.Dte_Fin);
            command.Parameters.AddWithValue("is_visible", Tp.IsVisible);
            command.Parameters.AddWithValue("fk_id_promo", fk_id_promo);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
        //insert a tp for a groupe
        public void AddTp(Tp Tp, int fk_id_groupe, int fk_id_promo)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Tp (Nom, Dte_Debut, Dte_Fin, is_visible, fk_id_groupe, fk_id_promo) VALUES (@nom, @dte_debut, @dte_fin, @is_visible, @fk_id_groupe, @fk_id_promo)";
            command.Parameters.AddWithValue("nom", Tp.Nom);
            command.Parameters.AddWithValue("dte_debut", Tp.Dte_Debut);
            command.Parameters.AddWithValue("dte_fin", Tp.Dte_Fin);
            command.Parameters.AddWithValue("is_visible", Tp.IsVisible);
            command.Parameters.AddWithValue("fk_id_groupe", fk_id_groupe);
            command.Parameters.AddWithValue("fk_id_promo", fk_id_promo);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
        //update a tp
        public void UpdateTp(Tp Tp)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Tp SET Nom = @nom, Dte_Debut = @dte_debut, Dte_Fin = @dte_fin, is_visible = @is_visible WHERE id_tp = @id";
            command.Parameters.AddWithValue("nom", Tp.Nom);
            command.Parameters.AddWithValue("dte_debut", Tp.Dte_Debut);
            command.Parameters.AddWithValue("dte_fin", Tp.Dte_Fin);
            command.Parameters.AddWithValue("is_visible", Tp.IsVisible);
            command.Parameters.AddWithValue("id", Tp.Id);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
        //delete a tp
        public void DeleteTp(Tp Tp)
        {
            MySqlConnection connection = ado.OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Tp WHERE id_tp = @id";
            command.Parameters.AddWithValue("id", Tp.Id);
            command.ExecuteNonQuery();
            ado.CloseConnection(connection);
        }
       
    }
}
