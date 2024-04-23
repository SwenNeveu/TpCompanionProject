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
    /// Interaction logic for EditPromotion.xaml
    /// </summary>
    public partial class EditPromotion : Page
    {
        
        public Promotion Promo { get; set; }    
        public EditPromotion(Promotion promotion)
        {
            Promo = promotion;
            
            InitializeComponent();
            PromoNom.Text = Promo.Nom;
        }
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                Frame tpCompanionFrame = mainWindow.FindName("FrameTpCompanion") as Frame;
                if (PromoNom.Text != Promo.Nom)
                {
                    Promo.Nom = PromoNom.Text;
                    AdoPromo adoPromo = new AdoPromo();
                    adoPromo.UpdatePromo(Promo);
                    tpCompanionFrame.Navigate(new ViewPromotion());
                    //faire les alertes +
                }
                else
                {
                    tpCompanionFrame.Navigate(new ViewPromotion());
                }
            }
            catch (Exception ex)
            {
                //faire les alertes
            }
        }
    }
}
