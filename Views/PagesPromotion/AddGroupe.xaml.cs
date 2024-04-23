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
    /// Interaction logic for AddGroupe.xaml
    /// </summary>
    public partial class AddGroupe : Page
    {
        public Promotion Promotion { get; set; }
        public AddGroupe(Promotion promotion)
        {
            Promotion = promotion;
            InitializeComponent();
        }

        public void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                Frame tpCompanionFrame = mainWindow.FindName("FrameTpCompanion") as Frame;
                if (txtNom.Text != "")
                {
                    AdoGroupe adoGroupe = new AdoGroupe();
                    Groupe groupe = new Groupe(txtNom.Text);
                    Promotion.Groupes.Add(groupe);
                    adoGroupe.AddGroupe(groupe, Promotion);
                    App app = (App)Application.Current;
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
