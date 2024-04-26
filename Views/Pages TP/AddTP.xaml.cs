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

namespace TpCompanionProject.Views.Pages_TP
{
    /// <summary>
    /// Interaction logic for AddTP.xaml
    /// </summary>
    public partial class AddTP : Page
    {
        public List<Promotion> Promotions { get; set; }
        private Promotion? SelectedPromotion { get; set; }
        private Groupe? SelectedGroup { get; set; }
        public AddTP()
        {
            App app = (App)Application.Current;
            Promotions = app.Promotions;
            DataContext = this;
            InitializeComponent();
        }

        private void PromotionsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                if (PromotionsComboBox.SelectedIndex != -1)
                {
                    // Get the selected promotion
                    Promotion selectedPromotion = (Promotion)PromotionsComboBox.SelectedItem;
                    // Show the GroupsComboBox and populate it with groups of the selected promotion
                    GroupsComboBox.Visibility = Visibility.Visible;
                    GroupsComboBox.ItemsSource = selectedPromotion.Groupes;
                    // set the selected promotion
                    SelectedPromotion = selectedPromotion;
                    // Show the AddTPButton
                    CreateTpButton.Visibility = Visibility.Visible;
                }            
        }

        private void GroupsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupsComboBox.SelectedIndex != -1)
            {
                // Get the selected group
                Groupe selectedGroup = (Groupe)GroupsComboBox.SelectedItem;
                // set the selected group
                SelectedGroup = selectedGroup;
            }
        }

        private void AppTpButton_Click(object sender, RoutedEventArgs e)
        {
            //save the new tp
            if(SelectedPromotion != null)
            {
                // Create a new TP
                Tp tp = new Tp(titleTextBox.Text, (DateTime)startDatePicker.SelectedDate, (DateTime)endDatePicker.SelectedDate, true);
                if (SelectedGroup != null)
                {
                    // Add the TP to the selected group
                    SelectedGroup.Tps.Add(tp);
                    AdoTp adoTp = new AdoTp();
                    adoTp.AddTp(tp, SelectedGroup.Id, SelectedPromotion.Id) ;
                }
                else
                {
                    // Add the TP to the selected promotion
                    SelectedPromotion.Tps.Add(tp);
                    AdoTp adoTp = new AdoTp();
                    adoTp.AddTp(tp, SelectedPromotion.Id);
                }
            }
        }

        private void ClearGroupSelectionButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
