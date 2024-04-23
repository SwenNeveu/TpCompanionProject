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
    /// Interaction logic for EditEleve.xaml
    /// </summary>
    public partial class EditEleve : Page
    {
        public Eleve Eleve { get; set; }
        public Promotion Promotion { get; set; }
        public Groupe ?Groupe { get; set; }
        public EditEleve(Eleve eleve, Promotion promo)
        {
            Eleve = eleve;
            Promotion = promo;
            InitializeComponent();
            txtNom.Text = Eleve.Nom;
            txtPrenom.Text = Eleve.Prenom;

        }
        public EditEleve(Eleve eleve, Promotion promo, Groupe groupe)
        {
            Eleve = eleve;
            Promotion = promo;
            Groupe = groupe;
            InitializeComponent();
            txtNom.Text = Eleve.Nom;
            txtPrenom.Text = Eleve.Prenom;

        }


        public void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                Frame tpCompanionFrame = mainWindow.FindName("FrameTpCompanion") as Frame;
                if (txtNom.Text != Eleve.Nom || txtPrenom.Text != Eleve.Prenom)
                {
                    Eleve.Nom = txtNom.Text;
                    Eleve.Prenom = txtPrenom.Text;
                    AdoEleve adoEleve = new AdoEleve();
                    adoEleve.UpdateEleve(Eleve);
                    tpCompanionFrame.Navigate(new ViewEleve(Promotion));
                    //faire les alertes +
                }
                else
                {
                    tpCompanionFrame.Navigate(new ViewEleve(Promotion));
                }
            }
            catch (Exception ex)
            {
                //faire les alertes
            }
        }
    }
}
