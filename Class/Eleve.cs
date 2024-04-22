using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompanionProject.Class
{
    public class Eleve
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        //Dictionnaire des taches avec leurs etat
        public Dictionary<Tache, string> Taches { get; set; }
        public List<Aide> Aides { get; set; }


        public Eleve(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
            Taches = new Dictionary<Tache, string>();
            Aides = new List<Aide>();
        }
    }
}
