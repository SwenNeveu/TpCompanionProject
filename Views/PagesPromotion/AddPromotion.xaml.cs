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
    /// Interaction logic for AddPromotion.xaml
    /// </summary>
    public partial class AddPromotion : Page
    {
        public AddPromotion()
        {
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
                    AdoPromo adoPromo = new AdoPromo();
                    Promotion promotion = new Promotion(txtNom.Text);
                    adoPromo.AddPromo(promotion);
                    
                    App app = (App)Application.Current;
                    app.Refresh();

                    tpCompanionFrame.Navigate(new ViewPromotion());
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
