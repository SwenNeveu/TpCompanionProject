using Google.Protobuf.WellKnownTypes;
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

namespace TpCompanionProject.Views
{
    /// <summary>
    /// Interaction logic for PageAide.xaml
    /// </summary>
    public partial class PageAide : Page
    {
        public List<Promotion> Promotions { get; set;}
        public PageAide()
        {
            InitializeComponent();
            App app = (App)Application.Current;
            Promotions = app.Promotions;
            DataContext = this;

            GridPromotion.ItemsSource = Promotions;    
            

        }
    }
}
