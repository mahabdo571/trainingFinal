using Doors4;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Door3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            popTextBoxTF.PlacementTarget = (this);
          
            if (clsSettings.CheckConnection())
            {
                popTextBoxTF.IsOpen = false;
              

            }
            else
            {
                popTextBoxTF.IsOpen = true;
                return;
            }
        }

     

        private void OpenMainCustomers(object sender, RoutedEventArgs e)
        {
   
        }

        private void OpenMainTapi(object sender, RoutedEventArgs e)
        {
           new MainTapi().Show();
            this.Close();
         
          
         

        }

        private void ExitMainWindow(object sender, RoutedEventArgs e)
        {
           //if( MessageBox.Show("תמשיך לעבוד","תמשיך לעבוד",MessageBoxButton.YesNoCancel,MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
           // {

           //     MessageBox.Show("יופי. יש עוד הרבה הזמנות לעשות");


           // }
           // else
           // {
           //     MessageBox.Show("המילה *לא* אינה קיימת במערכת");
           // }
           //     ;
            
            Close();
               
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            new wpfSetting(1).Show();
      
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblVirtion.Content = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new wpfGlobalSearch().Show();
            this.Close();
        }
    }
}
