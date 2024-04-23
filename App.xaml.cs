using Mysqlx.Expr;
using System.Configuration;
using System.Data;
using System.Windows;
using TpCompanionProject.Ado;
using TpCompanionProject.Class;

namespace TpCompanionProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public List<Promotion>? Promotions { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AdoPromo adoPromo = new AdoPromo();
            AdoEleve adoEleve = new AdoEleve();
            AdoGroupe adoGroupe = new AdoGroupe();
            AdoTp adoTp = new AdoTp();
            AdoTache adoTache = new AdoTache();
            AdoAide adoAide = new AdoAide();
            Promotions = adoPromo.GetAllPromo();
            foreach (Promotion promo in Promotions)
            {
                promo.Groupes = adoGroupe.GetGroupesByPromoId(promo);
                promo.Eleves = adoEleve.GetAllEleveByPromo(promo);
                foreach (Eleve eleve in promo.Eleves)
                {
                    eleve.Taches = adoTache.GetTachesByEleve(eleve);
                    eleve.Aides = adoAide.GetAidesByEleveId(eleve);
                }
                promo.Tps = adoTp.GetTpsByPromo(promo.Id);
                foreach (Tp tp in promo.Tps)
                {
                    tp.Taches = adoTache.GetTachesByTp(tp);
                    tp.Aides = adoAide.GetAidesByTpId(tp);
                }

                foreach (Groupe groupe in promo.Groupes)
                {
                    groupe.Tps = adoTp.GetTpsByGroupe(groupe.Id, promo.Id);
                    foreach (Tp tp in groupe.Tps)
                    {
                        tp.Taches = adoTache.GetTachesByTp(tp);
                        tp.Aides = adoAide.GetAidesByTpId(tp);
                    }
                    groupe.Eleves = adoEleve.GetElevesByGroupe(groupe.Id);

                    foreach (Eleve eleve in groupe.Eleves)
                    {
                        eleve.Aides = adoAide.GetAidesByEleveId(eleve);
                        eleve.Taches = adoTache.GetTachesByEleve(eleve);

                    }
                }
            }
        }
        public void Refresh()
        {
            AdoPromo adoPromo = new AdoPromo();
            AdoEleve adoEleve = new AdoEleve();
            AdoGroupe adoGroupe = new AdoGroupe();
            AdoTp adoTp = new AdoTp();
            AdoTache adoTache = new AdoTache();
            AdoAide adoAide = new AdoAide();
            Promotions = adoPromo.GetAllPromo();
            foreach (Promotion promo in Promotions)
            {
                promo.Groupes = adoGroupe.GetGroupesByPromoId(promo);
                promo.Eleves = adoEleve.GetAllEleveByPromo(promo);
                foreach (Eleve eleve in promo.Eleves)
                {
                    eleve.Taches = adoTache.GetTachesByEleve(eleve);
                    eleve.Aides = adoAide.GetAidesByEleveId(eleve);
                }
                promo.Tps = adoTp.GetTpsByPromo(promo.Id);
                foreach (Tp tp in promo.Tps)
                {
                    tp.Taches = adoTache.GetTachesByTp(tp);
                    tp.Aides = adoAide.GetAidesByTpId(tp);
                }

                foreach (Groupe groupe in promo.Groupes)
                {
                    groupe.Tps = adoTp.GetTpsByGroupe(groupe.Id, promo.Id);
                    foreach (Tp tp in groupe.Tps)
                    {
                        tp.Taches = adoTache.GetTachesByTp(tp);
                        tp.Aides = adoAide.GetAidesByTpId(tp);
                    }
                    groupe.Eleves = adoEleve.GetElevesByGroupe(groupe.Id);

                    foreach (Eleve eleve in groupe.Eleves)
                    {
                        eleve.Aides = adoAide.GetAidesByEleveId(eleve);
                        eleve.Taches = adoTache.GetTachesByEleve(eleve);

                    }
                }
            }
        }
    }

}
