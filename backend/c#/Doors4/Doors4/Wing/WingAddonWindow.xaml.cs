using SharaLogic;
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



namespace Doors4.Wing
{
    /// <summary>
    /// Interaction logic for WingAddonWindow.xaml
    /// </summary>
    public partial class WingAddonWindow : Window
    {
        int _WingeID;
        int _AddonID;

        enum myMode { add=1,update=2}

        myMode _Mode = myMode.add;

        clsWingAddon _Addon;
        clsWingAddon _AddonTemp;


        public WingAddonWindow(int WingID,int AddonID)
        {
            InitializeComponent();
            wpfSetting.SetLang(Properties.Settings.Default.lang);

            _WingeID = WingID;
            _AddonID = AddonID;
   
            if (_AddonID == -1)
            {
                _Mode = myMode.add;
                UPDATEUI();
            }
            else
            {
                _Mode = myMode.update;
                UPDATEUI();
            }
        }

        void UPDATEUI()
        {
            _save();
            if (_Addon != null)
            {
                _btnChoisNorsta();
                _btnChoisOvert();
                _Filltxt();
                _cbStatus();
            }
        }

        void _save()
        {

            switch (_Mode)
            {
                case myMode.add:
                    _ADD();
                    break;
                case myMode.update:
                    _UPDATE();
                    break;
            }

        }

        void _ADD()
        {

            _Addon = new clsWingAddon();

            _Addon.WingID = _WingeID;
            _Addon.StainlessBand = "NoBand";
            _Addon.Offirt = "NoOffirt";

            if (_Addon.Save())
            {
                _AddonID = _Addon.ID;
                _Mode = myMode.update;
                UPDATEUI();
            }

        }

        void _UPDATE()
        {
            if(_AddonID > 0)
            {
                _Addon = clsWingAddon.Find(_AddonID);

               

            }
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddonScr_Loaded(object sender, RoutedEventArgs e)
        {
            UPDATEUI();
            txtPullHandleWidth.Text = "900";
            _Addon.PullHandleWidth= 900;
            _Addon.Save();

        }

        private void btnSaveDB(object sender, RoutedEventArgs e)
        {
            Button btnSave = sender as Button;

            switch (btnSave.Name)
            {
                case "btnNorstaNo":
                    _Addon.StainlessBand = btnSave.Tag.ToString();
                    break;

                       case "btnNorsta2Side":
                    _Addon.StainlessBand = btnSave.Tag.ToString();
                    break;
                    
                       case "btnNorstaPushSide":
                    _Addon.StainlessBand = btnSave.Tag.ToString();
                    break;
                        
                       case "btnNorstaPullSide":
                    _Addon.StainlessBand = btnSave.Tag.ToString();
                    break; 
                    
                       case "btnOffirtNo":
                    _Addon.Offirt = btnSave.Tag.ToString();
                    break;
                            
                       case "btnOffirt2Side":
                    _Addon.Offirt = btnSave.Tag.ToString();
                    break;    
                    
                       case "btnOffirtPushSide":
                    _Addon.Offirt = btnSave.Tag.ToString();
                    break;     

                       case "btnOffirtPullSide":
                    _Addon.Offirt = btnSave.Tag.ToString();
                    break;
            }

            if (_Addon.Save())
            {
                UPDATEUI();
            }
        }
        int _ValidateInputs(string text)
        {

            if (int.TryParse(text, out int value))
            {
                return value;
            }
            else
            {
                return -1;
            }
        }
            
            float _ValidateInputsf(string text)
        {

            if (float.TryParse(text, out float value))
            {
                return value;
            }
            else
            {
                return -1;
            }

        }

        private void txtSaveDB(object sender, KeyEventArgs e)
        {

            TextBox txtSave = sender as TextBox;

            switch (txtSave.Name)
            {
                case "txtThicknessOffirt":
                    _Addon.ThicknessOffirt = _ValidateInputsf(txtSave.Text);
                    break;  
                case "txtPullHandleHeight":
                    _Addon.PullHandleHeight = _ValidateInputs(txtSave.Text);
                    break;    
                case "txtPullHandleWidth":
                    _Addon.PullHandleWidth = _ValidateInputs(txtSave.Text);
                    break;      
                case "txtPullHandleLocationFromBottom":
                    _Addon.PullHandleLocationFromBottom = _ValidateInputs(txtSave.Text);
                    break;      
                case "txtPullHandleLocationFromabove":
                    _Addon.PullHandleLocationFromabove = _ValidateInputs(txtSave.Text);
                    break;
            }

            if (_Addon.Save())
            {
                UPDATEUI();
            }

        }

        private void cbPullHandle_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_Addon != null)
            {
                _Addon.PullHandle = false;
                if (_Addon.Save())
                {
                    UPDATEUI();
                }
            }
        }

        private void cbPullHandle_Checked(object sender, RoutedEventArgs e)
        {
            if (_Addon != null)
            {
                _Addon.PullHandle = true;
                if (_Addon.Save())
                {
                    UPDATEUI();
                }
            }
        }

        private void cbReturnHidden_Checked(object sender, RoutedEventArgs e)
        {
            if (_Addon != null)
            {
                _Addon.ReturnHidden = true;
                if (_Addon.Save())
                {
                    UPDATEUI();
                }
            }
        }

        private void cbReturnHidden_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_Addon != null)
            {
                _Addon.ReturnHidden = false;
                if (_Addon.Save())
                {
                    UPDATEUI();
                }
            }
        }

        void _btnChoisNorsta()
        {
            switch (_Addon.StainlessBand)
            {
                case "NoBand":
                    _choisbtnNorsta(btnNorstaNo, true);
                    break; 
                
                case "Norsta2Side":
                    _choisbtnNorsta(btnNorsta2Side, true);
                    break;    
                
                case "NorstaPushSide":
                    _choisbtnNorsta(btnNorstaPushSide, true);
                    break;      
                case "NorstaPullSide":
                    _choisbtnNorsta(btnNorstaPullSide, true);
                    break;
            }
        }
        void _choisbtnNorsta(Button btn, bool isChois)
        {
            btnNorstaNo.IsEnabled = true;
            btnNorsta2Side.IsEnabled = true;
            btnNorstaPushSide.IsEnabled = true;
            btnNorstaPullSide.IsEnabled = true;



            btn.IsEnabled = isChois ? false : true;


        }

        void _btnChoisOvert()
        {
            switch (_Addon.Offirt)
            {
                case "NoOffirt":
                    _choisbtnOvert(btnOffirtNo, true);
                    break;

                case "Offirt2Side":
                    _choisbtnOvert(btnOffirt2Side, true);
                    break;

                case "OffirtPushSide":
                    _choisbtnOvert(btnOffirtPushSide, true);
                    break;
                case "OffirtPullSide":
                    _choisbtnOvert(btnOffirtPullSide, true);
                    break;
            }
        }

   
        void _choisbtnOvert(Button btn, bool isChois)
        {
            btnOffirtNo.IsEnabled = true;
            btnOffirt2Side.IsEnabled = true;
            btnOffirtPushSide.IsEnabled = true;
            btnOffirtPullSide.IsEnabled = true;



            btn.IsEnabled = isChois ? false : true;


        }

        void _Filltxt()
        {
            txtThicknessOffirt.Text = _getFromDBconverToEmpty(_Addon.ThicknessOffirt);
            txtPullHandleHeight.Text = _getFromDBconverToEmpty(_Addon.PullHandleHeight);
            txtPullHandleLocationFromabove.Text = _getFromDBconverToEmpty(_Addon.PullHandleLocationFromabove);
            txtPullHandleLocationFromBottom.Text = _getFromDBconverToEmpty(_Addon.PullHandleLocationFromBottom);
            txtPullHandleWidth.Text = _getFromDBconverToEmpty(_Addon.PullHandleWidth);


        }
        string _getFromDBconverToEmpty(int num)
        {
            if (_Addon != null)
            {

                if (num <= 0)
                {
                    return "";
                }
                else
                {
                    return num.ToString();
                }

            }
            return "";
        }  
        
        string _getFromDBconverToEmpty(float num)
        {
            if (_Addon != null)
            {

                if (num <= 0f)
                {
                    return "";
                }
                else
                {
                    return num.ToString();
                }

            }
            return "";
        }


        void _cbStatus()
        {
            if (_Addon.PullHandle)
            {
                cbPullHandle.IsChecked = true;
            }
            else
            {
                cbPullHandle.IsChecked = false;
            }

            if (_Addon.ReturnHidden)
            {
                cbReturnHidden.IsChecked = true;
            }
            else
            {
                cbReturnHidden.IsChecked = false;
            }
        }

        private void txtPullHandleWidth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {


            if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

            { 
            if(_AddonTemp != null)
                {
                    _Addon = _AddonTemp;
                    _Addon.Save();
                    UPDATEUI();
                    btnback.Visibility = Visibility.Hidden;
                }
            
            }
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _AddonTemp = clsWingAddon.FindByWingID(_WingeID);

            if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

            { 

                if(_Addon != null)
                {
                    _Addon.clear();
                    _Addon.Save();
                    UPDATEUI();
                    btnback.Visibility = Visibility.Visible;

                }
            
            
            }
            }
    }
}
