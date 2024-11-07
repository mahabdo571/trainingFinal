using SharaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Doors4.Wing
{
    /// <summary>
    /// Interaction logic for WingLockWindow.xaml
    /// </summary>
    public partial class WingLockWindow : Window
    {
        enum Mymode { Add = 1, Update = 2 };
        Mymode _mode = Mymode.Add;

        int _WingID;
        int _LockID;

        clsWingLock _wingLock;
        clsWingLock _wingLockTemp;
        clsWingAdvanced _Advanced;
      

        public WingLockWindow(int WingID,int LockID)
        {
            InitializeComponent();
            wpfSetting.SetLang(Properties.Settings.Default.lang);
            _LockID = LockID;
            _WingID = WingID;

            if (_LockID == -1)
            {
                _mode = Mymode.Add;
                UPDATEUI();
            }
            else
            {
                _mode = Mymode.Update;
                UPDATEUI();
            }

        }
        void _Save()
        {
            switch (_mode)
            {
                case Mymode.Add:
                    _ADD();
                    break;
                case Mymode.Update:
                    _UPDATE();
                    break;
            }
        }
        void UPDATEUI()
        {
            _Save();
            _FillData();

        }

        void _ADD()
        {
            _wingLock = new clsWingLock();

            _wingLock.WingID = _WingID;

            if (_wingLock.Save())
            {
                _LockID = _wingLock.ID;
                _mode = Mymode.Update;
                UPDATEUI();
            }

        }

        void _UPDATE()
        {
            if(_LockID > 0)
            {
                _wingLock = clsWingLock.Find(_LockID);
                _Advanced = clsWingAdvanced.FindByWingID(_WingID);
            }
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            UPDATEUI();

            Close();
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
        string _getFromDBconverToEmpty(int num)
        {
            if (_wingLock != null)
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

        void _choisbtn(Button btn,bool isChois)
        {
            btnNoLock.IsEnabled = true;
            btnFinek.IsEnabled = true;
            btnshar60.IsEnabled = true;
            btnshar45.IsEnabled = true;
            btnbhla.IsEnabled = true;
            btnrol.IsEnabled = true;
            btnKFV.IsEnabled = true;
            btnRock.IsEnabled = true;
            btnShlat.IsEnabled = true;
            btnlfe.IsEnabled = true;
            btnzaza.IsEnabled = true;

            btn.IsEnabled = isChois?false:true;


        }
        void _btnChois()
        {

            switch (_wingLock.LockType)
            {
                case "NoLock":
                    _choisbtn(btnNoLock, true);
                  
                    break;  
                case "Finek":
                    _choisbtn(btnFinek, true);
                 
                    break;
                case "shar60":
                    _choisbtn(btnshar60, true);
             
                    break;   
                case "shar45":
                     _choisbtn(btnshar45, true);
                    break;   
                case "bhla":
                     _choisbtn(btnbhla, true);
                    break; 
                
                case "rol":
                     _choisbtn(btnrol, true);
                    break;     
                case "KFV":
                     _choisbtn(btnKFV, true);
                    break; 
                
                case "Rock":
                     _choisbtn(btnRock, true);
                    break;     
                    
                case "Shlat":
                     _choisbtn(btnShlat, true);
                    break;
                       
                case "lfe":
                     _choisbtn(btnlfe, true);
                    break;                     
                case "zaza":
                     _choisbtn(btnzaza, true);
                    break;   
                
                case "Electricity":
                     _choisbtn(btnelectricity, true);
                    break;
          
            }

        }

        void _FillData()
        {
            if(_wingLock != null)
            {

                txtLockMeasure.Text = _getFromDBconverToEmpty(_wingLock.LockMeasure);
                txtLockMeasureFrame.Text = _getFromDBconverToEmpty(_wingLock.LockMeasureFrame);
                txtUpperLockMeasure.Text = _getFromDBconverToEmpty(_wingLock.UpperLockMeasure);
                txtUpperLockMeasureFrame.Text = _getFromDBconverToEmpty(_wingLock.UpperLockMeasureFrame);
                txtLockMeasure.IsEnabled = true;
                txtLockMeasureFrame.IsEnabled = true;
                txtUpperLockMeasure.IsEnabled = true;
                txtUpperLockMeasureFrame.IsEnabled = true; 
                lblLocl.Visibility = Visibility.Hidden;
                lblpletzLocl.Visibility = Visibility.Hidden;
                lblUpperLocl.Visibility = Visibility.Hidden;
                lblpletzUpperLocl.Visibility = Visibility.Hidden;

                if (!string.IsNullOrEmpty(txtLockMeasure.Text) || !(_wingLock.LockMeasure <= 0))
                {
                    txtLockMeasure.IsEnabled = true;
                    txtLockMeasureFrame.IsEnabled = false;
                    lblLocl.Visibility = Visibility.Hidden;
                    lblpletzLocl.Visibility = Visibility.Visible;
                    lblpletzLocl.Content = (_wingLock.LockMeasure - 42);
                }


                if (!string.IsNullOrEmpty(txtLockMeasureFrame.Text) ||!( _wingLock.LockMeasureFrame <= 0) )
                {            
                    txtLockMeasure.IsEnabled = false;
                    txtLockMeasureFrame.IsEnabled = true;
                    lblLocl.Content = (_wingLock.LockMeasureFrame + 42);
 
                    lblLocl.Visibility = Visibility.Visible;
                    lblpletzLocl.Visibility = Visibility.Hidden;
                }



                if (!string.IsNullOrEmpty(txtUpperLockMeasure.Text) || !(_wingLock.UpperLockMeasure <= 0))
                {
                    txtUpperLockMeasure.IsEnabled = true;
                    txtUpperLockMeasureFrame.IsEnabled = false;
                    lblUpperLocl.Visibility = Visibility.Hidden;
                    lblpletzUpperLocl.Visibility = Visibility.Visible;
                    lblpletzUpperLocl.Content = (_wingLock.UpperLockMeasure - 50);
                }


                if (!string.IsNullOrEmpty(txtUpperLockMeasureFrame.Text) || !(_wingLock.UpperLockMeasureFrame <= 0))
                {
                    txtUpperLockMeasure.IsEnabled = false;
                    txtUpperLockMeasureFrame.IsEnabled = true;
                    lblUpperLocl.Content = (_wingLock.UpperLockMeasureFrame + 50);

                    lblUpperLocl.Visibility = Visibility.Visible;
                    lblpletzUpperLocl.Visibility = Visibility.Hidden;
                }






                if (_wingLock.UpperLock)
                {
                    cbUpperLock.IsChecked = true;
                }
                else
                {
                    cbUpperLock.IsChecked = false;
                }


                //if(clsWings.Find(_WingID) != null && clsWings.Find(_WingID).DoubleDoor && clsWings.Find(_WingID).DDAK=="K" && !_wingLock.UpperLock && clsWings.Find(_WingID).WingType != null && clsWings.Find(_WingID).WingType.TEST2 == "A")
                //{
                //    btnelectricity.Visibility = Visibility.Visible;
                //}
                //else
                //{
                //    btnelectricity.Visibility = Visibility.Hidden;
                //}
                _btnChois();



            }

        }

        private void savetodb(object sender, KeyEventArgs e)
        {
            TextBox txtMes = sender as TextBox;

            switch (txtMes.Name)
            {
                case "txtLockMeasure":
                    _wingLock.LockMeasure = _ValidateInputs(txtMes.Text);
                    break;      
                case "txtLockMeasureFrame":
                    _wingLock.LockMeasureFrame = _ValidateInputs(txtMes.Text);
                    break;
                          
                case "txtUpperLockMeasure":
                    _wingLock.UpperLockMeasure = _ValidateInputs(txtMes.Text);
                    break;       
                
                case "txtUpperLockMeasureFrame":
                    _wingLock.UpperLockMeasureFrame = _ValidateInputs(txtMes.Text);
                    break;

            }

            if (_wingLock.Save())
            {
                UPDATEUI();
            }

        }

        private void cbUpperLock_Checked(object sender, RoutedEventArgs e)
        {
            _wingLock.UpperLock = true;
            if (_wingLock.Save())
            {
                UPDATEUI();
            }

        }

        private void cbUpperLock_Unchecked(object sender, RoutedEventArgs e)
        {
            _wingLock.UpperLock = false;
            if (_wingLock.Save())
            {
                UPDATEUI();
            }
        }

        private void btnSavetoDB(object sender, RoutedEventArgs e)
        {

            Button btnType = sender as Button;

            switch (btnType.Name)
            {
                case "btnNoLock":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(false, false);
                    break;   
                case "btnFinek":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(true, true);
                    break; 
                
                case "btnshar60":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(true, true);
                    break;     
                case "btnshar45":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(true, true);
                    break;  
                
                case "btnbhla":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(true, true);

                    break;     
                
                case "btnrol":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(true, true);
                    break;    
                
                case "btnKFV":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(true, true);
                    break;  
                
                case "btnRock":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(true, true);
                    break;  
                
                case "btnShlat":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(false, false);
                    break;   
                case "btnlfe":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(true, true);
                    break;          
                
                case "btnzaza":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(true, true);
                    break;   
                
                case "btnelectricity":
                    _wingLock.LockType = btnType.Tag.ToString();
                    holsLock(true, true);
                    break;
            }

            if (_wingLock.Save())
            {
                if (_Advanced != null)
                {
                  
                    _Advanced.woodBehalaLockManual = false;
                    _Advanced.Save();
                }
                UPDATEUI();
            }

        }

        void holsLock(bool HandleHoles,bool HolesCylinder)
        {
            if (_Advanced != null)
            {

                _Advanced.HandleHoles = HandleHoles;
                _Advanced.HolesCylinder = HolesCylinder;

                _Advanced.Save();
            }
        }

        private void btnBackdb_Click(object sender, RoutedEventArgs e)
        {
         
            if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

            {
                if(_wingLockTemp != null)
                {
                    _wingLock = _wingLockTemp;
                    _wingLock.Save();
                    if (_wingLock.LockType == "Shlat")
                    {
                        holsLock(false, false);
                    }
                    else
                    {
                        holsLock(true, true);
                    }
                    UPDATEUI();
                    btnBackdb.Visibility = Visibility.Hidden;
               
                }
            }
            }

        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
            _wingLockTemp = clsWingLock.FindByWingID(_WingID);

            if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

            {
                if (_wingLock != null)
                {
                    _wingLock.clear();
                    _wingLock.Save();
                    UPDATEUI();
                    btnBackdb.Visibility = Visibility.Visible;
                    holsLock(true, true);
                }
            }
        }
    }
}
