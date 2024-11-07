
using Door3;
using Doors4.clsGenral;
using Microsoft.Win32;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace Doors4
{
    /// <summary>
    /// Interaction logic for wpfLodingDB.xaml
    /// </summary>
    public partial class wpfLodingDB : Window
    {
        DispatcherTimer dt;
        int i = 0;
    
        static string __PathRegMachin = @"HKEY_CURRENT_USER\Software\SharabanyDoorOrder";
        static string __IpServer_RegName = "IpServer";


        public  wpfLodingDB()
        {
            InitializeComponent();
    
          
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SharabanyDoorOrder", "keyF", "!@#QWEasdZXC5679", RegistryValueKind.String);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\SharabanyDoorOrder", "keyE", "!@#QWEasdZXC5679", RegistryValueKind.String);
          
          
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\SharabanyDoorOrder", "keyF", "!@#QWEasdZXC5679", RegistryValueKind.String);
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\SharabanyDoorOrder", "keyE", "!@#QWEasdZXC5679", RegistryValueKind.String);

              
             


            

            
           
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            clsGlobal.DefultFrameLocal = clsFrameDefault.getAll();
           
            if (string.IsNullOrEmpty(Registry.GetValue(__PathRegMachin, __IpServer_RegName,null)as string))
            {
                new wpfSetting(2).Show();
                this.Close();
                return;

            }
                dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(10);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        int j;
      
        private void Dt_Tick(object sender, EventArgs e)
        {
            i++;
            j++;
            if(j  > 300)
            {
                btnclose.Visibility = Visibility.Visible;

            }
            else
            {
                btnclose.Visibility = Visibility.Hidden;
            }
            bar.Value = i;


            if (i == 100)
            {
                popTextBoxTF.PlacementTarget = (this);

                if (string.IsNullOrEmpty((Registry.GetValue(__PathRegMachin, __IpServer_RegName, null) as string)) || clsSettings.CheckConnection() == false)
                {
                    i = 0;

                    popTextBoxTF.IsOpen = true;


                }
                else
                {
                    popTextBoxTF.IsOpen = false;

                    new MainWindow().Show();
                    this.Close();
                }
            }
        }

        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void  Window_Loaded(object sender, RoutedEventArgs e)
        {
            clsGlobal.DefultKantLocal = await clsKantWingDefault.GetAllAsync();
        }
    }
}
