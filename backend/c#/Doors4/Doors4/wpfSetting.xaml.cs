
using CrystalDecisions.Shared.Json;
using Door3;
using Doors4.clsGenral;
using Doors4.Projects;
using Microsoft.Win32;
using Newtonsoft.Json;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Doors4
{
    /// <summary>
    /// Interaction logic for wpfSetting.xaml
    /// </summary>
    public partial class wpfSetting : Window
    {
        enum Mode { add = 0,update=1}
        clsSettings ss;
        string KEY = "";
        static string _PathRegUSER = @"HKEY_CURRENT_USER\Software\SharabanyDoorOrder";
        static string __IpServer_RegName = "IpServer";
        static string ___DataBaseName_RegName = "DataBaseName";
        static string ___IUserDatabase_RegName = "IUserDatabase";
        static string ___PasswordDataBase_RegName = "PasswordDataBase";
        static string ___ModeDataBase_RegName = "ModeDataBase";
     
        static string _ImagePath_RegName = "ImagePath";
        static string _DocumentsPath_RegName = "DocumentsPath";
        static string _MainPrinterName_RegName = "MainPrinterName";
        static string _StikersPrinterName_RegName = "StikersPrinterName";
        static string _txtScanRotate_RegName = "ScanRotate";
        static string ___KeyE = "KeyE";
        Mode _modeColorSide = Mode.add;
        Mode _modeColorFormica = Mode.add;
        clsColorSide colors;
        clsFormicaColor Fcolors;
        int _mode = -1;
        public wpfSetting(int mode)
        {
            InitializeComponent();
            KEY = Registry.GetValue(_PathRegUSER, ___KeyE, null) as string;
          
            _modeColorSide = Mode.add;
            _modeColorFormica = Mode.add;

            SetLang(Doors4.Properties.Settings.Default.lang);
            if(Doors4.Properties.Settings.Default.lang == "HE")
            {
                this.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                this.FlowDirection = FlowDirection.LeftToRight;
            }
            _mode = mode;
      

            if (clsSettings.CheckConnection())
            {
                popTextBoxTF.IsOpen = false;


                ss = clsSettings.GetData();
            }
            else
            {
                popTextBoxTF.IsOpen = true;
                return;
            }

           
            
      
        }

        public static void SetLang(string lang)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            try
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                ResourceDictionary resdict = new ResourceDictionary()
                {
                    Source = new Uri($"Language/{lang}.xaml", UriKind.Relative)
                };
                Application.Current.Resources.MergedDictionaries.Add(resdict);


            }catch{
                MessageBox.Show("langoug error");
            }

            Doors4.Properties.Settings.Default.lang = lang;
            Doors4.Properties.Settings.Default.Save();
        }

        void _saveGenral()
        {


            try
            {
                Registry.SetValue(_PathRegUSER, _DocumentsPath_RegName, txtDocumentsPath.Text, RegistryValueKind.String);
                Registry.SetValue(_PathRegUSER, _ImagePath_RegName, txtImagePath.Text, RegistryValueKind.String);
                Registry.SetValue(_PathRegUSER, _MainPrinterName_RegName, txtMainPrinterName.Text, RegistryValueKind.String);
                Registry.SetValue(_PathRegUSER, _StikersPrinterName_RegName, txtStikersPrinterName.Text, RegistryValueKind.String);
                Registry.SetValue(_PathRegUSER, _txtScanRotate_RegName, txtScanRotate.Text, RegistryValueKind.String);


            }
            catch(Exception ex)
            {
                clsSettings.SetEventLogMsg(ex.Message, "CLS_wpfSetting__FUNCTION_NAME__saveGenral", System.Diagnostics.EventLogEntryType.Error);
                MessageBox.Show("error");
            }
        }

        void _saveDataBase()
        {
            if (txtpasssave.Password == "123456781")
            {

                string modedb = cbDBmodedb.SelectedItem.ToString();
      
                try
                {
                    Registry.SetValue(_PathRegUSER, __IpServer_RegName, clsSettings.Encrypt(txtIPserver.Password, KEY), RegistryValueKind.String);
                    Registry.SetValue(_PathRegUSER, ___DataBaseName_RegName, clsSettings.Encrypt(txtDBName.Password, KEY), RegistryValueKind.String);
                    Registry.SetValue(_PathRegUSER, ___IUserDatabase_RegName, clsSettings.Encrypt(txtUserDB.Password, KEY), RegistryValueKind.String);
                    Registry.SetValue(_PathRegUSER, ___PasswordDataBase_RegName, clsSettings.Encrypt(txtpassDB.Password, KEY), RegistryValueKind.String);
                    Registry.SetValue(_PathRegUSER, ___ModeDataBase_RegName, modedb, RegistryValueKind.String);
                    MessageBox.Show("Database is Updateed");
                }
                catch
                (Exception ex)
                {
                    clsSettings.SetEventLogMsg(ex.Message, "CLS_wpfSetting__FUNCTION_NAME___saveDataBase", System.Diagnostics.EventLogEntryType.Error);
                    MessageBox.Show("error");
                }

            
            }
            else
            {
                MessageBox.Show("password to save a change Wrong");
            }
        }
        void _saveAmountPrint()
        {
      
            if (ss != null)
            {
                ss.StickerAmountPerDoor_Frame = Convert.ToByte(txtStickerAmountPerDoor_Frame.Text);
                ss.StickerAmountPerDoor_A = Convert.ToByte(txtStickerAmountPerDoor_A.Text);
                ss.StickerAmountPerDoor_F = Convert.ToByte(txtStickerAmountPerDoor_F.Text);
                ss.StickerAmountPerDoor_Alpha = Convert.ToByte(txtStickerAmountPerDoor_Alpha.Text);
                ss.StickerAmountPerDoor_Windo = Convert.ToByte(txtStickerAmountPerDoor_Windo.Text);
                ss.StickerAmountPerDoor_Tris = Convert.ToByte(txtStickerAmountPerDoor_Tris.Text);
                ss.PaperAmountPerDoor_A = Convert.ToByte(txtPaperAmountPerDoor_A.Text);
                ss.PaperAmountPerDoor_F = Convert.ToByte(txtPaperAmountPerDoor_F.Text);
                ss.PaperAmountPerDoor_Frame = Convert.ToByte(txtPaperAmountPerDoor_Frame.Text);
                ss.PaperAmountPerDoor_Alpha = Convert.ToByte(txtPaperAmountPerDoor_Alpha.Text);
                ss.PaperAmountPerDoor_Windo = Convert.ToByte(txtPaperAmountPerDoor_Windo.Text);
                ss.PaperAmountPerDoor_Tris = Convert.ToByte(txtPaperAmountPerDoor_Tris.Text);
                if (!ss.Save())
                {
                    MessageBox.Show("Error in save");
                }

            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {


            switch (TCSett.SelectedIndex)
            {
                case 0:
                    _saveGenral();

                    break; 
                case 1:
                    _saveDataBase();
                    break;
                case 2:
                    _saveDataColorSide();
                    break;  
                case 3:
                    _saveAmountPrint();
                    break; 
                
                case 4:
                   _DefultFrame();
                    break; 
                
                case 5:
                    _saveDataFormicaColor();
                    break;
            }
          
      
         
            
       
        }

      

        void _DefultFrame()
        {




            clsGlobal.DefultFrameLocal = clsFrameDefault.getAll();

     

        }

        void _saveDataColorSide()
        {
            if(_modeColorSide == Mode.add)
            {
                if (!string.IsNullOrEmpty(txtcoloName.Text))
                {
                    colors = new clsColorSide();
             
                    colors.ColorName = txtcoloName.Text;


                    if (colors.Save())
                    {
                        dgvlistColor.ItemsSource = clsColorSide.getAllSortByID().DefaultView;
                        txtcoloName.Text = "";


                    }
                }

            }else if (_modeColorSide == Mode.update)
            {
                if (colors != null)
                {
                    if (!string.IsNullOrEmpty(txtcoloName.Text))
                    {

                        colors.ColorName = txtcoloName.Text;


                        if (colors.Save())
                        {
                            dgvlistColor.ItemsSource = clsColorSide.getAllSortByID().DefaultView;
                            txtcoloName.Text = "";
                            _modeColorSide = Mode.add;

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }


        } 
        
        void _saveDataFormicaColor()
        {
            if(_modeColorFormica == Mode.add)
            {
                if (!string.IsNullOrEmpty(txtcoloNameFormica.Text))
                {
                    Fcolors = new clsFormicaColor();
                    Fcolors.ColorName = txtcoloNameFormica.Text;


                    if (Fcolors.Save())
                    {
                        if (clsFormicaColor.getAllSortByID() != null)
                        {
                            dgvlistColorFormica.ItemsSource = clsFormicaColor.getAllSortByID().DefaultView;
                            txtcoloNameFormica.Text = "";
                        }

                    }
                }
            }else if (_modeColorFormica == Mode.update)
            {
                if (Fcolors != null)
                {
                    if (!string.IsNullOrEmpty(txtcoloNameFormica.Text))
                    {

                        Fcolors.ColorName = txtcoloNameFormica.Text;


                        if (Fcolors.Save())
                        {
                            if (clsFormicaColor.getAllSortByID() != null)
                            {
                                dgvlistColorFormica.ItemsSource = clsFormicaColor.getAllSortByID().DefaultView;
                                txtcoloNameFormica.Text = "";
                                _modeColorFormica = Mode.add;
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }


        }

        private void wpfSettingScreen_Loaded(object sender, RoutedEventArgs e)
        {
            cbDBmodedb.Items.Add("LOCAL");
            cbDBmodedb.Items.Add("USER");

         
            if(clsGlobal.DefultFrameLocal != null)
            {
                dgvDefultFramelist.ItemsSource = clsGlobal.DefultFrameLocal.DefaultView;
            } 
            
            if(clsGlobal.DefultKantLocal != null)
            {
                dgvlistKant.ItemsSource = clsGlobal.DefultKantLocal.DefaultView;
            }

           DataTable dt = clsColorSide.getAllSortByID();
            if (dt != null) {
                dgvlistColor.ItemsSource = dt.DefaultView;
            }   
            
            DataTable dtF = clsFormicaColor.getAllSortByID();
            if (dtF != null) {
              
                    dgvlistColorFormica.ItemsSource = dtF.DefaultView;
               
            }
            cbListLang.Items.Add(FindResource("lang_SelectLanguage").ToString());
            cbListLang.Items.Add(FindResource("lang_English").ToString());
            cbListLang.Items.Add(FindResource("lang_Hebrew").ToString());
            cbListLang.Items.Add(FindResource("lang_Arabic").ToString());

            if(Properties.Settings.Default.lang == "EN")
            {
                cbListLang.SelectedIndex = 1;
            }
            else if(Properties.Settings.Default.lang == "HE")
            {
                cbListLang.SelectedIndex = 2;
            }   else if(Properties.Settings.Default.lang == "AR")
            {
                cbListLang.SelectedIndex = 3;
            }
            else
            {
                cbListLang.SelectedIndex = 0;
            }

        

            popTextBoxTF.PlacementTarget = ((wpfSetting)sender);
          
        
            try
            {
    
                if (!string.IsNullOrEmpty(Registry.GetValue(_PathRegUSER, __IpServer_RegName, null) as string))
                {
                    txtIPserver.Password = clsSettings.Decrypt(Registry.GetValue(_PathRegUSER, __IpServer_RegName, null) as string, KEY);
                    txtDBName.Password = clsSettings.Decrypt(Registry.GetValue(_PathRegUSER, ___DataBaseName_RegName, null) as string, KEY);
                    txtUserDB.Password = clsSettings.Decrypt(Registry.GetValue(_PathRegUSER, ___IUserDatabase_RegName, null) as string, KEY);
                    txtpassDB.Password = clsSettings.Decrypt(Registry.GetValue(_PathRegUSER, ___PasswordDataBase_RegName, null) as string, KEY);
                    cbDBmodedb.SelectedItem = Registry.GetValue(_PathRegUSER, ___ModeDataBase_RegName, null) as string;
          
                }


             
          
       
            if (!string.IsNullOrEmpty(Registry.GetValue(_PathRegUSER, _ImagePath_RegName, null) as string))
            {


                    txtScanRotate.Text =  Registry.GetValue(_PathRegUSER, _txtScanRotate_RegName, null) as string;

                    txtDocumentsPath.Text = Registry.GetValue(_PathRegUSER, _DocumentsPath_RegName, null) as string;
                txtImagePath.Text = Registry.GetValue(_PathRegUSER, _ImagePath_RegName, null) as string;
               txtMainPrinterName.Text = Registry.GetValue(_PathRegUSER, _MainPrinterName_RegName, null) as string;
                txtStikersPrinterName.Text = Registry.GetValue(_PathRegUSER, _StikersPrinterName_RegName, null) as string;
                    if (ss != null)
                    {
                        txtStickerAmountPerDoor_Frame.Text = ss.StickerAmountPerDoor_Frame.ToString();
                        txtStickerAmountPerDoor_A.Text = ss.StickerAmountPerDoor_A.ToString();
                        txtStickerAmountPerDoor_F.Text = ss.StickerAmountPerDoor_F.ToString();
                        txtStickerAmountPerDoor_Alpha.Text = ss.StickerAmountPerDoor_Alpha.ToString();
                        txtStickerAmountPerDoor_Windo.Text = ss.StickerAmountPerDoor_Windo.ToString();
                        txtStickerAmountPerDoor_Tris.Text = ss.StickerAmountPerDoor_Tris.ToString();
                        txtPaperAmountPerDoor_A.Text = ss.PaperAmountPerDoor_A.ToString();
                        txtPaperAmountPerDoor_F.Text = ss.PaperAmountPerDoor_F.ToString();
                        txtPaperAmountPerDoor_Alpha.Text = ss.PaperAmountPerDoor_Alpha.ToString();
                        txtPaperAmountPerDoor_Frame.Text = ss.PaperAmountPerDoor_Frame.ToString();
                        txtPaperAmountPerDoor_Windo.Text = ss.PaperAmountPerDoor_Windo.ToString();
                        txtPaperAmountPerDoor_Tris.Text = ss.PaperAmountPerDoor_Tris.ToString();

                    }
            }

            }
            catch
                 (Exception ex)
            {
                clsSettings.SetEventLogMsg(ex.Message, "CLS_wpfSetting__FUNCTION_NAME__wpfSettingScreen_Loaded", System.Diagnostics.EventLogEntryType.Error);

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == 1)
            {
                this.Close();
            }else if(_mode == 2){
             
                if (string.IsNullOrEmpty(Registry.GetValue(_PathRegUSER, __IpServer_RegName,null)as string))
                {
                    new wpfLodingDB().Show();
                    this.Close();
                }
                else
                {
                    Close();
                }
            }
            
            
        }

        private void cbListLang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ComboBox)sender).SelectedIndex)
            {
                case 1:
                    SetLang("EN");
                 
                    break;
                case 2:
                    SetLang("HE");
                    break;
                          case 3:
                    SetLang("AR");
                    break;

                default:
                    break;
            }
        }

        private void editDF_Click(object sender, RoutedEventArgs e)
        {
            DFEditValue DFE = new DFEditValue((int)((DataRowView)dgvDefultFramelist.SelectedItem).Row.ItemArray[0]);
            DFE.ShowDialog();
            clsGlobal.DefultFrameLocal = clsFrameDefault.getAll();
            dgvDefultFramelist.ItemsSource = clsGlobal.DefultFrameLocal.DefaultView;
        }


        private void DataGridCel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DFEditValue DFE = new DFEditValue((int)((DataRowView)dgvDefultFramelist.SelectedItem).Row.ItemArray[0]);
            DFE.ShowDialog();
            clsGlobal.DefultFrameLocal = clsFrameDefault.getAll();
            dgvDefultFramelist.ItemsSource = clsGlobal.DefultFrameLocal.DefaultView;

        }

        private void DeleteColorSide_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are You Shuer ? delete this coloer .","Sharabany Delete",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (clsColorSide.Delete((int)((DataRowView)dgvlistColor.SelectedItem).Row.ItemArray[0]))
                {
                    dgvlistColor.ItemsSource = clsColorSide.getAllSortByID().DefaultView;
                }
                else
                {
                    MessageBox.Show("You cannot delete a color associated with one of the doors. Please untie it first and then delete the color", "sharabany info", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
           
        }

        private void EditColorSide_Click(object sender, RoutedEventArgs e)
        {
            txtcoloName.Text = (string)((DataRowView)dgvlistColor.SelectedItem).Row.ItemArray[1];
            _modeColorSide = Mode.update;
            colors = clsColorSide.Find((int)((DataRowView)dgvlistColor.SelectedItem).Row.ItemArray[0]);
       
        }

        private void DeleteColorFormica_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are You Shuer ? delete this coloer .", "Sharabany Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (clsFormicaColor.Delete((int)((DataRowView)dgvlistColorFormica.SelectedItem).Row.ItemArray[0]))
                {

                    try { dgvlistColorFormica.ItemsSource = clsFormicaColor.getAllSortByID().DefaultView; } catch { }

                    if (clsFormicaColor.getAllSortByID() != null)
                    {
                        if (clsFormicaColor.getAllSortByID() != null)
                        {
                            dgvlistColorFormica.ItemsSource = clsFormicaColor.getAllSortByID().DefaultView;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("You cannot delete a color associated with one of the doors. Please untie it first and then delete the color", "sharabany info", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

        }

        private void EditColorFormica_Click(object sender, RoutedEventArgs e)
        {
            txtcoloNameFormica.Text = (string)((DataRowView)dgvlistColorFormica.SelectedItem).Row.ItemArray[1];
            _modeColorFormica = Mode.update;
            Fcolors = clsFormicaColor.Find((int)((DataRowView)dgvlistColorFormica.SelectedItem).Row.ItemArray[0]);

        }

        private async void EditKant_Click(object sender, RoutedEventArgs e)
        {
            DefultKantWingValue DFE = new DefultKantWingValue((int)((DataRowView)dgvlistKant.SelectedItem).Row.ItemArray[0]);
            DFE.ShowDialog();
            clsGlobal.DefultKantLocal =await clsKantWingDefault.GetAllAsync();
            dgvlistKant.ItemsSource = clsGlobal.DefultKantLocal.DefaultView;
        }


        private void dgvlistKant_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditKant_Click(null, null);

        }
    }
}
