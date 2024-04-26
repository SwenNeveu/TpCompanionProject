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
using TpCompanionProject.Views.PagesPromotion;

namespace TpCompanionProject.Views.Pages_TP
{
    /// <summary>
    /// Interaction logic for EditTP.xaml
    /// </summary>
    public partial class EditTP : Page
    {
        public Tp Tp { get; set; }
        public EditTP(Tp tp)
        {
            Tp = tp;
           
            InitializeComponent();
            titleTextBox.Text = Tp.Nom;
            startDatePicker.SelectedDate = Tp.Dte_Debut;
            endDatePicker.SelectedDate = Tp.Dte_Fin;
        }

        private void EditTpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                Frame tpCompanionFrame = mainWindow.FindName("FrameTpCompanion") as Frame;
                if (Tp.Nom != titleTextBox.Text || Tp.Dte_Debut != startDatePicker.SelectedDate || Tp.Dte_Fin != endDatePicker.SelectedDate)
                {
                    Tp.Nom = titleTextBox.Text;
                    Tp.Dte_Debut = (DateTime)startDatePicker.SelectedDate;
                    Tp.Dte_Fin = (DateTime)endDatePicker.SelectedDate;
                    AdoTp adoTp = new AdoTp();
                    adoTp.UpdateTp(Tp);
                    tpCompanionFrame.Navigate(new ViewTP());
                    //faire les alertes +
                }
                else
                {
                    tpCompanionFrame.Navigate(new ViewTP());
                }
            }
            catch (Exception ex)
            {
                //faire les alertes
            }
        }
    }
}
