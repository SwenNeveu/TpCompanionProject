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
using TpCompanionProject;
using TpCompanionProject.Ado;
using TpCompanionProject.Class;

namespace TpCompanionProject.Views.PagesPromotion
{
    /// <summary>
    /// Interaction logic for ViewPromotion.xaml
    /// </summary>
    public partial class ViewPromotion : Page
    {
        public List<Promotion> ?Promotions { get; set; }
        public ViewPromotion()
        {
            InitializeComponent();
            App app = (App)Application.Current;
            Promotions = app.Promotions;
            DataContext = this;
            GridPromotion.ItemsSource = Promotions;
        }
        public void ButtonVoirEleve_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Promotion promo = (Promotion)button.DataContext;
            ViewEleve viewEleve = new ViewEleve(promo);
            NavigationService.Navigate(viewEleve);
           
        }
        public void ButtonEditPromo_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Promotion promo = (Promotion)button.DataContext;
            EditPromotion editPromotion = new EditPromotion(promo);
            NavigationService.Navigate(editPromotion);
        }

        private void SupprButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                Promotion promo = (Promotion)button.DataContext;
                AdoPromo adoPromo = new AdoPromo();
                adoPromo.DeletePromo(promo);
                Promotions.Remove(promo);
                GridPromotion.Items.Refresh();
                //faire les alertes +
            }
            catch (Exception ex)
            {
                //faire les alertes
            }
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPromotion());
        }

        private void VoirGroupeButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Promotion promo = (Promotion)button.DataContext;
            ViewGroupe viewGroupe = new ViewGroupe(promo);
            NavigationService.Navigate(viewGroupe);
        }
    }
}
