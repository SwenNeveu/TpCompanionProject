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
            InitializeComponent();
            App app = (App)Application.Current;
            Promotions = app.Promotions;
            DataContext = this;
        }

        public void ViewTaches_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Promotion promo = (Promotion)button.DataContext;
            //ViewTaches viewTaches = new ViewTaches(promo);
            //NavigationService.Navigate(viewTaches);
        }

        public void Modifier_Click(object sender, RoutedEventArgs e)
        {

        }
        public void Supprimer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
