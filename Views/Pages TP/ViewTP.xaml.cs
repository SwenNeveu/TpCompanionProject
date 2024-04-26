using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using TpCompanionProject.Views.PagesPromotion;

namespace TpCompanionProject.Views.Pages_TP
{
    /// <summary>
    /// Interaction logic for ViewTP.xaml
    /// </summary>
    public partial class ViewTP : Page
    {
        public List<Promotion>? Promotions { get; set; }
        public ViewTP()
        {
            
            App app = (App)Application.Current;
            app.Refresh();
            Promotions = app.Promotions;
            DataContext = this;
            InitializeComponent();
        }
        private void PromotionsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PromotionsComboBox.SelectedIndex != -1)
            {
                // Get the selected promotion
                var selectedPromotion = (Promotion)PromotionsComboBox.SelectedItem;

                // Populate the DataGrid with tasks of the selected promotion
                TPsDataGrid.ItemsSource = selectedPromotion.Tps;

                // Show the GroupsComboBox and populate it with groups of the selected promotion
                GroupsComboBox.Visibility = Visibility.Visible;
                GroupsComboBox.ItemsSource = selectedPromotion.Groupes;
            }
        }

        private void GroupsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupsComboBox.SelectedIndex != -1)
            {
                // Get the selected group
                var selectedGroup = (Groupe)GroupsComboBox.SelectedItem;

                // Update the DataGrid to display tasks for the selected group
                TPsDataGrid.ItemsSource = selectedGroup.Tps;
                ClearGroupSelectionButton.Visibility = Visibility.Visible;
            }
        }

        private void ClearGroupSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the selection of the GroupsComboBox
            GroupsComboBox.SelectedIndex = -1;

            // Hide the ClearGroupSelectionButton
            ClearGroupSelectionButton.Visibility = Visibility.Collapsed;

            // Get the selected promotion
            var selectedPromotion = (Promotion)PromotionsComboBox.SelectedItem;

            // Populate the DataGrid with tasks of the selected promotion
            TPsDataGrid.ItemsSource = selectedPromotion.Tps;
        }


        public void ViewTaches_Click(object sender, RoutedEventArgs e)
        {
            //Button button = (Button)sender;
            //Promotion promo = (Promotion)button.DataContext;
            //ViewTaches viewTaches = new ViewTaches(promo);
            //NavigationService.Navigate(viewTaches);
        }

        public void Modifier_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Tp tp = (Tp)button.DataContext;
            NavigationService.Navigate(new EditTP(tp));
        }
        public void Supprimer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTpButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTP());
        }
    }
}
