using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TpCompanionProject.Ado;
using TpCompanionProject.Class;

namespace TpCompanionProject.Views.PagesPromotion
{
    /// <summary>
    /// Interaction logic for AddEleve.xaml
    /// </summary>
    public partial class AddEleve : Page
    {
        public Groupe ?Groupe { get; set; }
        public Promotion Promotion { get; set; }
        public AddEleve(Promotion promo, Groupe groupe)
        {
            Promotion = promo;
            Groupe = groupe;
            InitializeComponent();
        }
        public AddEleve(Promotion promo)
        {
            Promotion = promo;
            InitializeComponent();
        }
        public void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                Frame tpCompanionFrame = mainWindow.FindName("FrameTpCompanion") as Frame;
                if (txtNom.Text != "" && txtPrenom.Text != "")
                {
                    AdoEleve adoEleve = new AdoEleve();
                    Eleve eleve = new Eleve(txtNom.Text, txtPrenom.Text);
                    Promotion.Eleves.Add(eleve);    
                    if (Groupe != null)
                    {
                        Groupe.Eleves.Add(eleve);
                        adoEleve.AddEleve(eleve, Groupe.Id, Promotion.Id);
                    }
                    else
                    {
                        adoEleve.AddEleve(eleve, Promotion.Id);
                    }
                     
                    App app = (App)Application.Current;
                    int id = Promotion.Id;
                    app.Refresh();
                    Promotion = app.Promotions.Where(p => p.Id == id).First();
                    tpCompanionFrame.Navigate(new ViewEleve(Promotion));
                    //faire les alertes +
                }
                else
                {
                    //faire les alertes
                }
            }
            catch (Exception ex)
            {
                //faire les alertes
            }
        }
    }
}
