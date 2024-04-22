using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompanionProject.Class
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Groupe> Groupes { get; set; }
        public List<Eleve> Eleves { get; set; }
        public List<Tp> Tps { get; set; }

        public Promotion(string nom)
        {
            Nom = nom;
            Groupes = new List<Groupe>();
            Eleves = new List<Eleve>();
            Tps = new List<Tp>();
        }
        //methode pour ajouter un groupe
        public void AjouterGroupe(Groupe groupe)
        {
            Groupes.Add(groupe);
        }
        //methode pour supprimer un groupe
        public void SupprimerGroupe(Groupe groupe)
        {
            Groupes.Remove(groupe);
        }
        //methode pour ajouter un eleve
        public void AjouterEleve(Eleve eleve)
        {
            Eleves.Add(eleve);
        }
        //methode pour supprimer un eleve
        public void SupprimerEleve(Eleve eleve)
        {
            Eleves.Remove(eleve);
        }
        //methode pour ajouter un tp
        public void AjouterTp(Tp tp)
        {
            Tps.Add(tp);
        }
        //methode pour supprimer un tp
        public void SupprimerTp(Tp tp)
        {
            Tps.Remove(tp);
        }
        
        public override string ToString()
        {
            return Nom;
        }
    }
}
