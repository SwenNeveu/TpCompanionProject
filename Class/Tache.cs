using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompanionProject.Class
{
    public class Tache
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int Ordre { get; set; }
        public Tp Tp { get; set; }
        public Tache(string nom, string description, int ordre, Tp tp)
        {
            Nom = nom;
            Description = description;
            Ordre = ordre;
            Tp = tp;
        }
    }
}
