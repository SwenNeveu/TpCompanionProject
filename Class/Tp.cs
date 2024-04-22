using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompanionProject.Class
{
    public class Tp
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime Dte_Debut { get; set; }
        public DateTime Dte_Fin { get; set; }
        public Boolean IsVisible { get; set; }
        public List<Tache> Taches { get; set; }
        public List<Aide> Aides { get; set; }

        // Constructor of the class Tp
        public Tp(string nom, DateTime dteDebut, DateTime dteFin, Boolean isVisible)
        {
            Nom = nom;
            Dte_Debut = dteDebut;
            Dte_Fin = dteFin;
            IsVisible = isVisible;
            Taches = new List<Tache>();
            Aides = new List<Aide>();
        }

        public Tp(string nom)
        {
            Nom = nom;
            Taches = new List<Tache>();
            Aides = new List<Aide>();
        }

        public void AjouterTache(Tache tache)
        {
            Taches.Add(tache);
        }

        public void SupprimerTache(Tache tache)
        {
            Taches.Remove(tache);
        }

        public override string ToString()
        {
            return Nom;
        }  
        
        //methode pour ajouter une aide
        public void AjouterAide(Aide aide)
        {
            Aides.Add(aide);
        }
        //methode pour supprimer une aide
        public void SupprimerAide(Aide aide)
        {
            Aides.Remove(aide);
        }
    }
}
