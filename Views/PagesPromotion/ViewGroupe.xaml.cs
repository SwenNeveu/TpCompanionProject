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
    /// Interaction logic for ViewGroupe.xaml
    /// </summary>
    public partial class ViewGroupe : Page
    {
        public Promotion Promotion { get; set; }
        public ViewGroupe(Promotion promo)
        {
            Promotion = promo;
            InitializeComponent();
            GridGroupe.ItemsSource = Promotion.Groupes;
        }
        public void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            Frame tpCompanionFrame = mainWindow.FindName("FrameTpCompanion") as Frame;
            tpCompanionFrame.Navigate(new AddGroupe(Promotion));
        }

        public void ButtonVoirEleve_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Groupe groupe = (Groupe)button.DataContext;
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            Frame tpCompanionFrame = mainWindow.FindName("FrameTpCompanion") as Frame;
            tpCompanionFrame.Navigate(new ViewEleve(Promotion, groupe));
        }

        private void ModifButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Groupe groupe = (Groupe)button.DataContext;
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            Frame tpCompanionFrame = mainWindow.FindName("FrameTpCompanion") as Frame;
            tpCompanionFrame.Navigate(new EditGroupe(groupe, Promotion));
        }

        private void SupprButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Groupe groupe = (Groupe)button.DataContext;
            AdoGroupe adoGroupe = new AdoGroupe();
            adoGroupe.DeleteGroupe(groupe);
            Promotion.Groupes.Remove(groupe);
            GridGroupe.Items.Refresh();
        }
    }
}
