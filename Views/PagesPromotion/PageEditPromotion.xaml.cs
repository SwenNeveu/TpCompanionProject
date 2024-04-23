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
    /// Interaction logic for PageEditPromotion.xaml
    /// </summary>
    public partial class PageEditPromotion : Page
    {
        public Promotion promo { get; set; }
        public PageEditPromotion(Promotion promo)
        {
            InitializeComponent();
            PromoNom.Text = promo.Nom;
            this.promo = promo; 
        }


        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PromoNom.Text != promo.Nom)
                {
                    promo.Nom = PromoNom.Text;
                    AdoPromo adoPromo = new AdoPromo();
                    adoPromo.UpdatePromo(promo);
                    //go back to the previous page
                    NavigationService.GoBack();

                }
                else
                {
                    MessageBox.Show("Action was not successful!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Action was not successful!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
