
using Doors4;
using SharaLogic;
using SharaLogic.Calculations;
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
using System.Windows.Shapes;

namespace Door3
{
    /// <summary>
    /// Interaction logic for TapiFrameBottomPartWindow.xaml
    /// </summary>
    public partial class TapiFrameBottomPartWindow : Window
    {

        clsFrameUpperPart _UpperPartDB;
        clsFrameUpperPart _UpperPartDBTemp;
        clsUpperPartCalc _UpperPartCalc;
        int _FrameID;
        public TapiFrameBottomPartWindow(int FrameID)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            _UpperPartCalc = new clsUpperPartCalc();
            _FrameID = FrameID;
            if (clsFrameUpperPart.FindByFrameID(FrameID) == null)
            {
                _UpperPartDB = new clsFrameUpperPart();

                _UpperPartDB.FrameID = FrameID;

                _UpperPartDB.Save();

                _Update();

            }else
            {
                _UpperPartDB = clsFrameUpperPart.FindByFrameID(FrameID);

                _Update();


            }
     
        }
        void _checkboxStatus()
        {

            if (_UpperPartDB.Kitum)
            {
                KitumSwitch.IsChecked = true;
            }
            else
            {
                KitumSwitch.IsChecked = false;
            }

            if (_UpperPartDB.Nerousta)
            {
                StainlessSwitch.IsChecked = true;
            }
            else
            {
                StainlessSwitch.IsChecked = false;
            }
        }

        void _btnCheckStatus()
        {
            switch (_UpperPartDB.upperPartType)
            {
                case "ללא":
                    btnNoupperPart.IsEnabled = false;
                    btnGlassUpperPart.IsEnabled = true;
                    btnGratesUpperPart.IsEnabled = true;
                    btnSolidUpperPart.IsEnabled = true;

                    break; 
                
                case "זיגוג":
                    btnNoupperPart.IsEnabled = true;
                    btnGlassUpperPart.IsEnabled = false;
                    btnGratesUpperPart.IsEnabled = true;
                    btnSolidUpperPart.IsEnabled = true;

                    break;   
                
                case "תריס":
                    btnNoupperPart.IsEnabled = true;
                    btnGlassUpperPart.IsEnabled = true;
                    btnGratesUpperPart.IsEnabled = false;
                    btnSolidUpperPart.IsEnabled = true;

                    break; 
                
                case "קבוע":
                    btnNoupperPart.IsEnabled = true;
                    btnGlassUpperPart.IsEnabled = true;
                    btnGratesUpperPart.IsEnabled = true;
                    btnSolidUpperPart.IsEnabled = false;

                    break;

                    default:
                    btnNoupperPart.IsEnabled = true;
                    btnGlassUpperPart.IsEnabled = true;
                    btnGratesUpperPart.IsEnabled = true;
                    btnSolidUpperPart.IsEnabled = true;


                    break;
            }
        }

        void _calcInput()
        {
            _UpperPartCalc.inDisplayBottomPart1 = _UpperPartDB.Kitum;
            _UpperPartCalc.inDisplayBottomPart2 = _UpperPartDB.Nerousta;
            _UpperPartCalc.inBottomPartSize = _UpperPartDB.BottomSize;
            _UpperPartCalc.inUpperPartSize = _UpperPartDB.upperPartSize;
            _UpperPartCalc.inUpperPartType = _UpperPartDB.upperPartType;

            _UpperPartCalc.exeute();
        }
        void _Update()
        {
            if (_UpperPartDB != null)
            {
                BottomPartBox.Text = _UpperPartDB.BottomSize.ToString();
                UpperPartBoxSize.Text = _UpperPartDB.upperPartSize.ToString();

                _checkboxStatus();

                _btnCheckStatus();


                UpperPartDisplayTest.Content = _UpperPartDB.upperPartType;


                _calcInput();
                BottomPartTestDisplay.Content = _UpperPartCalc.outBottomPartTestDisplay;
            }

        }

        private void NoUpperPart(object sender, RoutedEventArgs e)
        {
            if (_UpperPartDB != null)
            {

                _UpperPartDB.upperPartType = "ללא";

                if (_UpperPartDB.Save())
                {
                    KitumSwitch.IsChecked = false;
                    StainlessSwitch.IsChecked = false;
                    _UpperPartDB.BottomSize = 0;
                    _UpperPartDB.upperPartSize = 0;
                    BottomPartBox.Text = "";
                    UpperPartBoxSize.Text = "";

                    if (_UpperPartDB.Save())
                    {

                        _Update();
                    }
                  
                }
            }
           
         
        }

        private void GlassUpperPart(object sender, RoutedEventArgs e)
        {
            if (_UpperPartDB != null)
            {

                _UpperPartDB.upperPartType = "זיגוג";

                if (_UpperPartDB.Save())
                {

                    _Update();
                }
            }

     
        }

        private void GratesUpperPart(object sender, RoutedEventArgs e)
        {

            if (_UpperPartDB != null)
            {

                _UpperPartDB.upperPartType = "תריס";

                if (_UpperPartDB.Save())
                {

                    _Update();
                }
            }
            
        }

        private void SolidUpperPart(object sender, RoutedEventArgs e)
        {
            if (_UpperPartDB != null)
            {

                _UpperPartDB.upperPartType = "קבוע";

                if (_UpperPartDB.Save())
                {

                    _Update();
                }
            }

            
        }


        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            _Update();
            this.Close();
        }

        private void KitumSwitch_Checked(object sender, RoutedEventArgs e)
        {
            if (_UpperPartDB != null)
            {
                
                _UpperPartDB.Kitum = true;
                if (_UpperPartDB.Save())
                {
                    _Update();
                }
            }
        }

        private void BottomPartBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(_UpperPartDB != null)
            {
                int.TryParse(BottomPartBox.Text, out int res);
         
                _UpperPartDB.BottomSize = res;
                if (_UpperPartDB.Save())
                {
                    _Update();
                }
            }
           
        }

        private void KitumSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_UpperPartDB != null)
            {

                _UpperPartDB.Kitum = false;
                if (_UpperPartDB.Save())
                {
                    _Update();
                }
            }
        }

        private void UpperPartBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (_UpperPartDB != null)
            {
                int.TryParse(UpperPartBoxSize.Text, out int res);
       
                _UpperPartDB.upperPartSize = res;
                if (_UpperPartDB.Save())
                {
                    _Update();
                }
            }
        }

        private void StainlessSwitch_Checked(object sender, RoutedEventArgs e)
        {
            if (_UpperPartDB != null)
            {

                _UpperPartDB.Nerousta = true;
                if (_UpperPartDB.Save())
                {
                    _Update();
                }
            }
        }

        private void StainlessSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_UpperPartDB != null)
            {

                _UpperPartDB.Nerousta = false;
                if (_UpperPartDB.Save())
                {
                    _Update();
                }
            }
        }

        private void BottomPartBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(BottomPartBox.Text == "0")
            {
                BottomPartBox.Text = "";
            }
        }

        private void UpperPartBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UpperPartBoxSize.Text == "0")
            {
                UpperPartBoxSize.Text = "";
            }
        }

      

        private void btnbackdata_Click(object sender, RoutedEventArgs e)
        {
        
                if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _UpperPartDB = _UpperPartDBTemp;
                    _UpperPartDB.Save();
                    btnbackdata.Visibility = Visibility.Hidden;
                    _Update();

                
            }
            }

        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
            _UpperPartDBTemp = clsFrameUpperPart.FindByFrameID(_FrameID);

            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _UpperPartDB.clear();
                _UpperPartDB.Save();
                btnbackdata.Visibility = Visibility.Visible;
                _Update();

            }
            }
    }
}
