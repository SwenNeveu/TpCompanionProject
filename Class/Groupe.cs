using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompanionProject.Class
{
    public class Groupe
    {
        // Properties of the class Groupe
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Tp> Tps { get; set; }
        public List<Eleve> Eleves { get; set; }

        // Constructor of the class Groupe
        public Groupe(string nom)
        {
            Nom = nom;
            Eleves = new List<Eleve>();
            Tps = new List<Tp>();
        }

        // Methods of the class Groupe
        public void AjouterEleve(Eleve Eleve)
        {
            Eleves.Add(Eleve);
        }

        public void SupprimerEleve(Eleve Eleve)
        {
            Eleves.Remove(Eleve);
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
