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
    /// Interaction logic for ViewEleve.xaml
    /// </summary>
    public partial class ViewEleve : Page
    {
        public Promotion Promotion { get; set; }
        public Groupe ?Groupe { get; set; }
        public ViewEleve(Promotion promotion)
        {
            
            Promotion = promotion;
            DataContext = this;


            InitializeComponent();
            GridEleve.ItemsSource = Promotion.Eleves;
            Promotion = promotion;
        }
        public ViewEleve(Promotion promo, Groupe groupe)
        {
            Promotion = promo;
            Groupe = groupe;
            DataContext = this;
            InitializeComponent();
            GridEleve.ItemsSource = Groupe.Eleves;
        }
        public void SupprButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                Eleve eleve = (Eleve)button.DataContext;
                AdoEleve adoEleve = new AdoEleve();
                adoEleve.DeleteEleve(eleve);
                Promotion.Eleves.Remove(eleve);
                GridEleve.Items.Refresh();
            }
            catch (Exception ex)
            {
                //faire les alertes
            }
        }
        public void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Eleve eleve = (Eleve)button.DataContext;
            EditEleve editEleve = new EditEleve(eleve, Promotion);
            NavigationService.Navigate(editEleve);
        }

        public void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Groupe != null)
            {
                AddEleve addEleve = new AddEleve(Promotion, Groupe);
                NavigationService.Navigate(addEleve);

            }
            else
            {
                AddEleve addEleve = new AddEleve(Promotion);
                NavigationService.Navigate(addEleve);
            }
            
        }   
    }
}
