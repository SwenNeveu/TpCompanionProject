using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCompanionProject.Class
{
    public class Aide
    {
        public int Id { get; set; }
        public DateTime DteDemande { get; set; }
        public string Description { get; set; }
        public Eleve Eleve { get; set; }
        public Aide(string description, Eleve eleve)
        {
            Description = description;
            DteDemande = DateTime.Now;
            Eleve = eleve;
        }
    }
}
