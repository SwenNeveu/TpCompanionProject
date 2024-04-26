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
using TpCompanionProject.Class;
using TpCompanionProject.Ado;

namespace TpCompanionProject.Views.PagesPromotion
{
    /// <summary>
    /// Interaction logic for EditGroupe.xaml
    /// </summary>
    public partial class EditGroupe : Page
    {
        public Promotion Promotion { get; set; }
        public Groupe Groupe { get; set; }
        public EditGroupe(Groupe groupe, Promotion promotion)
        {

            Groupe = groupe;
            InitializeComponent();
            Promotion = promotion;
            GroupeNom.Text = Groupe.Nom;
        }
        public void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                Frame tpCompanionFrame = mainWindow.FindName("FrameTpCompanion") as Frame;
                if (GroupeNom.Text != "")
                {
                    Groupe.Nom = GroupeNom.Text;
                    App app = (App)Application.Current;
                    AdoGroupe adoGroupe = new AdoGroupe();
                    adoGroupe.UpdateGroupe(Groupe);
                    int id = Promotion.Id;
                    app.Refresh();
                    Promotion promotion = app.Promotions.Find(p => p.Id == id);
                    tpCompanionFrame.Navigate(new ViewGroupe(promotion));
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
