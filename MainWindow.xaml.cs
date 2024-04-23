using System.Text;
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

namespace TpCompanionProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void ButtonVoirAide_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ButtonVoirPromo_Click(object sender, RoutedEventArgs e)
        {
            FrameTpCompanion.Navigate(new Views.PagesPromotion.ViewPromotion());
        }

        private void ButtonVoirTps_Click(object sender, RoutedEventArgs e)
        {
            FrameTpCompanion.Navigate(new Views.Pages_TP.ViewTP());

        }
    }
}