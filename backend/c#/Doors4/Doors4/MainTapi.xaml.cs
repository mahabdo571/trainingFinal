using Door3.Wing;
using Doors4;
using Doors4.ReportWing;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Door3
{
    /// <summary>
    /// Interaction logic for MainTapi.xaml
    /// </summary>
    public partial class MainTapi : Window
    {
        public MainTapi()
        {
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            InitializeComponent();
        }

        private void Open_MainWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void OpenTapiWing(object sender, RoutedEventArgs e)
        {
            TapiWing objTapiWing = new TapiWing(5,9);
            
            objTapiWing.ShowDialog();
        }

        private void btnTapiCoustomer_Click(object sender, RoutedEventArgs e)
        {
            new MainCustomers().Show();
            this.Close();
        }

        private void btnFrameTest_Click(object sender, RoutedEventArgs e)
        {
            new TapiFrame(5, 3).ShowDialog();
    
        }


        private void btnhome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Close();
            objMainWindow.Show();

        }


    }
}
