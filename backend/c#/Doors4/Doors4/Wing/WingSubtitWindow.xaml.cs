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
    /// Interaction logic for WingSubtitWindow.xaml
    /// </summary>
    public partial class WingSubtitWindow : Window
    {
        int _WindowID;
        int _WingID;
        enum Mymode { Add = 1, Update = 2 };
        Mymode _mode = Mymode.Add;

        clsWingWindows _Windo;
        clsWingWindows _WindoTemp;

        public WingSubtitWindow(int WingID,int WindowID)
        {
            InitializeComponent();
            wpfSetting.SetLang(Properties.Settings.Default.lang);
            _WingID = WingID;
            _WindowID = WindowID;

            if(_WindowID == -1)
            {
                _mode = Mymode.Add;
                _Save();
                UPDATEUI();
            }
            else
            {
                _mode = Mymode.Update;
                _Save();
                UPDATEUI();

            }
        }

        void UPDATEUI()
        {
          
            if (_Windo != null)
            {
                _btnChoisWindoType();
                btnChoisGlassType();
                btnChoisTrisType();
                btnChoisOpeningDirection();
                _FillData();
                cbInCenterAction();
                cbTrisInCenterAction();
            }
        }
        void cbInCenterAction()
        {
            
            if (_Windo.WindoInCenter)
            {
                cbwindoInCenter.IsChecked = true;
                if (_Windo.WindowType == "Normal")
                {
                    txtWindowPositionFromAbove.IsEnabled = true;
                    txtWindowPositionFromHandle.IsEnabled = false;

                }
                else
                {
                    txtWindowPositionFromAbove.IsEnabled = false;
                    txtWindowPositionFromHandle.IsEnabled = false;
                }
            }
            else
            {
                cbwindoInCenter.IsChecked = false;
                if (_Windo.WindowType == "Normal")
                {

                    txtWindowPositionFromAbove.IsEnabled = true;
                    txtWindowPositionFromHandle.IsEnabled = true;

                }
                else
                {
                    txtWindowPositionFromAbove.IsEnabled = true;
                    txtWindowPositionFromHandle.IsEnabled = false;
                }
            }
        } 
        
        void cbTrisInCenterAction()
        {
            
       
                txtTrisPositionFromHandle.IsEnabled = _Windo.TrisInCenter;
       

           
                cbAorHole.IsChecked = _Windo.AorHole;
            
        }

        void _Save()
        {
            switch (_mode)
            {
                case Mymode.Add:
                    _ADD();
                    break;
                case Mymode.Update:
                    _Update();
                    break;
            }
        }
        void _ADD()
        {

            _Windo = new clsWingWindows();
            _Windo.WingID = _WingID;
            _Windo.WindowType = "NoWin";
            _Windo.TrisType = "NoTris";
            _Windo.GlassType = "Clear";
            _Windo.OpeningDirection = "In";
            _Windo.CircleDiameter = 427;
            _Windo.WindoInCenter = false;
            _Windo.CircleLocationFromBottom = 1500;
            _Windo.TrisPositionFromBottom = 150;
            _Windo.TrisInCenter = true;
           
            if (_Windo.Save())
            {
                _mode = Mymode.Update;
                _WindowID = _Windo.ID;
                UPDATEUI();
            }

        }

        void _Update()
        {
            if(_WindowID > 0)
            {
                _Windo = clsWingWindows.Find(_WindowID);

            }
        }


        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void _choisbtnWindoType(Button btn, bool isChois)
        {
            btnWinTypeNoWin.IsEnabled = true;
            btnWinTypeNormal.IsEnabled = true;
            btnWinTypeTsohar.IsEnabled = true;
            
            btnWinTypeMtstson.IsEnabled = true;
            btnWinTypeOld.IsEnabled = true;
            btnWinTypeBalon.IsEnabled = true;
            btnWinTypeStar.IsEnabled = true;

     
           

            btn.IsEnabled = isChois ? false : true;


        }
        void _btnChoisWindoType()
        {

            switch (_Windo.WindowType)
            {
                case "NoWin":
                    _choisbtnWindoType(btnWinTypeNoWin, true);
                  
                    break;     
                case "Normal":
                    _choisbtnWindoType(btnWinTypeNormal, true);
                    break;  
                case "Tsohar":
                    _choisbtnWindoType(btnWinTypeTsohar, true);
                 
                    break;     
                 
                case "Mtstson":
                    _choisbtnWindoType(btnWinTypeMtstson, true);
                    //_Windo.CircleLocationFromBottom = 1600;
                    //_Windo.WindoInCenter = false;
                    break;   
                case "Old":
                    _choisbtnWindoType(btnWinTypeOld, true);
                    break;     
                case "Balon":
                    _choisbtnWindoType(btnWinTypeBalon, true);
           
                    break;   
                case "Star":
                    _choisbtnWindoType(btnWinTypeStar, true);
              
                    break;
       


            }

        }
        void _choisbtnGlassType(Button btn, bool isChois)
        {
            btnGlassTypeClear.IsEnabled = true;
            btnGlassTypeMilky.IsEnabled = true;


            btn.IsEnabled = isChois ? false : true;

        }

            void btnChoisGlassType()
        {
            switch (_Windo.GlassType)
            {
                case "Clear":
                    _choisbtnGlassType(btnGlassTypeClear, true);
                    break;
                case "Milky":
                    _choisbtnGlassType(btnGlassTypeMilky, true);
                    break;
            }
        }   
        
        void _choisbtnTrisType(Button btn, bool isChois)
        {
            btnTrisTypeNoTris.IsEnabled = true;
            btnTrisTypeWood.IsEnabled = true;
            btnTrisTypeAlminuom.IsEnabled = true;
            btnTrisTypeSlots.IsEnabled = true;


            btn.IsEnabled = isChois ? false : true;

        }

            void btnChoisTrisType()
        {
            switch (_Windo.TrisType)
            {
                case "NoTris":
                    _choisbtnTrisType(btnTrisTypeNoTris, true);

                    break;
                case "Wood":
                    _choisbtnTrisType(btnTrisTypeWood, true);
                    break;  
                case "Alminuom":
                    _choisbtnTrisType(btnTrisTypeAlminuom, true);
                    break;       
                case "Slots":
                    _choisbtnTrisType(btnTrisTypeSlots, true);
                    break;
            }
        }

        void _choisbtnOpeningDirection(Button btn, bool isChois)
        {
            btnOpeningDirectionIn.IsEnabled = true;
            btnOpeningDirectionOut.IsEnabled = true;


            btn.IsEnabled = isChois ? false : true;

        }

        void btnChoisOpeningDirection()
        {
            switch (_Windo.OpeningDirection)
            {
                case "In":
                    _choisbtnOpeningDirection(btnOpeningDirectionIn, true);
                    break;
                case "Out":
                    _choisbtnOpeningDirection(btnOpeningDirectionOut, true);
                    break;
            }
        }

        private void btnSaveDB(object sender, RoutedEventArgs e)
        {
            Button btnTypes = sender as Button;

            switch (btnTypes.Name)
            {
                case "btnWinTypeNoWin":
                    _Windo.WindowType = btnTypes.Tag.ToString();
                    _Windo.CircleLocationFromBottom = 0;
                    _Windo.WindowPositionFromAbove = 0;
                    _Windo.WindowPositionFromHandle = 0;
                    _Windo.WindoInCenter = false;

                    break;   
                
                case "btnWinTypeNormal":
                    _Windo.WindowType = btnTypes.Tag.ToString();
                    _Windo.CircleLocationFromBottom = 0;
                    _Windo.WindowPositionFromAbove = 150;
                    _Windo.WindowPositionFromHandle = 150;
                    break;   
                    
                case "btnWinTypeTsohar":
                    _Windo.WindowType = btnTypes.Tag.ToString();
                    _Windo.CircleLocationFromBottom = 1500;
                    _Windo.WindowPositionFromAbove = 0;
                    _Windo.WindowPositionFromHandle = 0;
                    _Windo.WindoInCenter = true;
                    break;
                    
           
                           
                case "btnWinTypeMtstson":
                    _Windo.WindowType = btnTypes.Tag.ToString();
                    _Windo.WindowPositionFromHandle = 0;
                    _Windo.CircleLocationFromBottom = 1600;
                    _Windo.WindowPositionFromAbove = 0;

                    _Windo.WindoInCenter = false;

                   
                    break;
               
                case "btnWinTypeOld":
                    _Windo.WindowType = btnTypes.Tag.ToString();
                    _Windo.CircleLocationFromBottom = 1600;
                    _Windo.WindowPositionFromAbove = 0;
                    _Windo.WindowPositionFromHandle = 0;
                    _Windo.WindoInCenter = true;
                    break;
                    
                case "btnWinTypeBalon":
                    _Windo.WindowType = btnTypes.Tag.ToString();
                    _Windo.CircleLocationFromBottom = 1500;
                    _Windo.WindowPositionFromAbove = 0;
                    _Windo.WindowPositionFromHandle = 0;
                    _Windo.WindoInCenter = true;
                    break;
                     
                case "btnWinTypeStar":
                    _Windo.WindowType = btnTypes.Tag.ToString();
                    _Windo.CircleLocationFromBottom = 1600;
                    _Windo.WindowPositionFromAbove = 0;
                    _Windo.WindowPositionFromHandle = 0;
                    _Windo.WindoInCenter = true;
                    break;
                            
                case "btnGlassTypeClear":
                    _Windo.GlassType = btnTypes.Tag.ToString();
                    break;
                                     
                case "btnGlassTypeMilky":
                    _Windo.GlassType = btnTypes.Tag.ToString();
                    break;
                              
                case "btnTrisTypeNoTris":
                    _Windo.TrisType = btnTypes.Tag.ToString();
                    _Windo.TrisPositionFromBottom  =0;
                    _Windo.TrisPositionFromAbove  =0;
                    _Windo.TrisPositionFromHandle  =0;
                    cbTrisInCenter.IsChecked = false;
                    break;
//                    if  {?TypeTris} = "TrisSquareSize"  or {?TypeTris} = "TrisTallSize"  then
//false
//else
//                        true
                case "btnTrisTypeWood":
                    _Windo.TrisType = btnTypes.Tag.ToString();
                    _Windo.TrisPositionFromBottom = 150;
                    _Windo.TrisPositionFromAbove = 0;
                    _Windo.TrisPositionFromHandle = 0;
                    cbTrisInCenter.IsChecked = true;
                    break;                         
                case "btnTrisTypeAlminuom":
                    _Windo.TrisType = btnTypes.Tag.ToString();
                    _Windo.TrisPositionFromBottom = 150;
                    _Windo.TrisPositionFromAbove = 0;
                    _Windo.TrisPositionFromHandle = 0;
                    cbTrisInCenter.IsChecked = true;
                    break;   
                case "btnTrisTypeSlots":
                    _Windo.TrisType = btnTypes.Tag.ToString();
                    _Windo.TrisPositionFromBottom = 150;
                    _Windo.TrisPositionFromAbove = 0;
                    _Windo.TrisPositionFromHandle = 0;
                    cbTrisInCenter.IsChecked = true;
                    break;    
                case "btnOpeningDirectionIn":
                    _Windo.OpeningDirection = btnTypes.Tag.ToString();
                    break;    
                case "btnOpeningDirectionOut":
                    _Windo.OpeningDirection = btnTypes.Tag.ToString();
                    break;

            }

            if (_Windo.Save())
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
                return 0;
            }

        }
        string _getFromDBconverToEmpty(int num)
        {
            if (_Windo != null)
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
        private void txtSaveDB(object sender, KeyEventArgs e)
        {

            TextBox txtSave = sender as TextBox;

            switch (txtSave.Name)
            {

                case "txtCircleDiameter":
                    _Windo.CircleDiameter = _ValidateInputs(txtSave.Text);
                    break;
                    
                case "txtCircleLocationFromBottom":
                    _Windo.CircleLocationFromBottom = _ValidateInputs(txtSave.Text);
                    break;
                             
                case "txtWindowHeight":
                    _Windo.WindowHeight = _ValidateInputs(txtSave.Text);
                    break;
                           
                case "txtWindowWidth":
                    _Windo.WindowWidth = _ValidateInputs(txtSave.Text);
                    break;            
                case "txtWindowPositionFromAbove":
                    _Windo.WindowPositionFromAbove = _ValidateInputs(txtSave.Text);
                    break; 
                case "txtWindowPositionFromHandle":
                    _Windo.WindowPositionFromHandle = _ValidateInputs(txtSave.Text);
                    if (_ValidateInputs(txtSave.Text) < 1)
                    {
                        cbwindoInCenter.IsChecked = true;
                    }
                    else
                    {
                        cbwindoInCenter.IsChecked = false;
                    }
                    break;

                case "txtTrisHeight":
                    _Windo.TrisHeight = _ValidateInputs(txtSave.Text);
                    break;     
                
                case "txtTrisWidth":
                    _Windo.TrisWidth = _ValidateInputs(txtSave.Text);
                    break;
                    
                case "txtTrisPositionFromHandle":
                    _Windo.TrisPositionFromHandle = _ValidateInputs(txtSave.Text);
                    if (_ValidateInputs(txtSave.Text) < 1)
                    {
                        cbTrisInCenter.IsChecked = true;
                    }
                    else
                    {
                        cbTrisInCenter.IsChecked = false;
                    }
                    break;
                          
                case "txtTrisPositionFromAbove":
                    _Windo.TrisPositionFromAbove = _ValidateInputs(txtSave.Text);
                    break;
                              
                case "txtTrisPositionFromBottom":
                    _Windo.TrisPositionFromBottom = _ValidateInputs(txtSave.Text);
                    break;

            }

            if (_Windo.Save())
            {
                UPDATEUI();
            }

        }

        private void windos_Loaded(object sender, RoutedEventArgs e)
        {
            UPDATEUI();
        }

        void _FillData()
        {
            if(_Windo != null)
            {

                txtCircleDiameter.Text = _getFromDBconverToEmpty(_Windo.CircleDiameter);
                txtCircleLocationFromBottom.Text = _getFromDBconverToEmpty(_Windo.CircleLocationFromBottom);
                txtWindowHeight.Text = _getFromDBconverToEmpty(_Windo.WindowHeight);
                txtWindowWidth.Text = _getFromDBconverToEmpty(_Windo.WindowWidth);
                txtWindowPositionFromAbove.Text = _getFromDBconverToEmpty(_Windo.WindowPositionFromAbove);
                txtWindowPositionFromHandle.Text = _getFromDBconverToEmpty(_Windo.WindowPositionFromHandle);
                txtTrisHeight.Text = _getFromDBconverToEmpty(_Windo.TrisHeight);
                txtTrisWidth.Text = _getFromDBconverToEmpty(_Windo.TrisWidth);
                txtTrisPositionFromHandle.Text = _getFromDBconverToEmpty(_Windo.TrisPositionFromHandle);
                txtTrisPositionFromAbove.Text = _getFromDBconverToEmpty(_Windo.TrisPositionFromAbove);
                txtTrisPositionFromBottom.Text = _getFromDBconverToEmpty(_Windo.TrisPositionFromBottom);
               
                
        


                cbTrisInCenter.IsChecked = _Windo.TrisInCenter;

            }
        }

        private void cbwindoInCenter_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void cbwindoInCenter_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_Windo != null)
            {
                _Windo.WindoInCenter = false;
                _Windo.Save();
                UPDATEUI();
            }
        }

        private void cbwindoInCenter_Checked(object sender, RoutedEventArgs e)
        {
            if (_Windo != null)
            {
                _Windo.WindoInCenter = true;
                _Windo.Save();
                UPDATEUI();
            }
        }

        private void cbTrisInCenter_Checked(object sender, RoutedEventArgs e)
        {
            if (_Windo != null)
            {
                _Windo.TrisInCenter = true;
                _Windo.Save();
                UPDATEUI();
            }
            
        }

        private void cbTrisInCenter_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_Windo != null)
            {
                _Windo.TrisInCenter = false;
                _Windo.Save();
                UPDATEUI();
            }

        }

        private void cbAorHole_Checked(object sender, RoutedEventArgs e)
        {
            if (_Windo != null)
            {
                _Windo.AorHole = true;
                _Windo.Save();
                UPDATEUI();
            }
        }

        private void cbAorHole_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_Windo != null)
            {
                _Windo.AorHole = false;
                _Windo.Save();
                UPDATEUI();
            }
        }

        private void btnRest_Click(object sender, RoutedEventArgs e)
        {

            _WindoTemp = clsWingWindows.FindByWingID(_WingID);
            if (_Windo != null)
            {

                if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

                {
                    _Windo.clear();
                    _Windo.Save();
                    btnBack.Visibility = Visibility.Visible;
                    UPDATEUI();
                }

            }
            }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

            {
                if(_WindoTemp != null)
                {
                    _Windo = _WindoTemp;
                    _WindoTemp.Save();
                    btnBack.Visibility = Visibility.Hidden;
                    UPDATEUI();
                }

            }
        }
    }
}
