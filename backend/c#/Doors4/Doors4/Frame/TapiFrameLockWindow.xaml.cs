
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
using Doors4;
using SharaLogic;
using SharaLogic.Calculations;
namespace Door3
{
    /// <summary>
    /// Interaction logic for TapiFrameLockWindow.xaml
    /// </summary>
    public partial class TapiFrameLockWindow : Window
    {
    
        clsFrameLockType _CFLT;
        clsFrameLockType _CFLTTemp;
        LockCalc LKC;


        int _FrameID;

        public TapiFrameLockWindow(int FrameID, int FrameHiegth)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            LKC = new LockCalc();
            _FrameID = FrameID;
            if (clsFrameLockType.FindByFrameID(FrameID) == null)
            {
                _CFLT = new clsFrameLockType();
                _CFLT.FrameId = FrameID;
                _CFLT.FrameHiegth = FrameHiegth;
                _CFLT.LockType = "Sharabany";
                _CFLT.Save();

                _update();

            }
            else
            {
                _CFLT = clsFrameLockType.FindByFrameID(FrameID);
                _CFLT.FrameHiegth = FrameHiegth;
                _CFLT.Save();
                _update();
            }


        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            _update();
            _CFLT.Save();
            this.Close();
        }

        string translockName(string name)
        {
            try { 
            switch (name)
            {
                case "Sharabany":
                    return FindResource("langNameSharabany").ToString(); 
                case "Electric":
                    return FindResource("langNameElectric").ToString(); 
                case "JordanKafol":
                    return FindResource("langNameJordanKafol").ToString();  
                case "Publock":
                    return FindResource("langNamePublock").ToString();   
                case "NoLock":
                    return FindResource("langNameNoLock").ToString();
            }
        }catch(ResourceReferenceKeyNotFoundException ex)
            {
                clsSettings.SetEventLogMsg(ex.Message, "clsTapiFrameLockWindow_FUNN_translockName", System.Diagnostics.EventLogEntryType.Warning);
            }
            return "";
        }

        void _update()
        {
            if (_CFLT != null)
            {
                DisplyHight.Content = _CFLT.FrameHiegth;
                cbSlipCan.IsChecked = _CFLT.SlipCan;


                switch (_CFLT.LockType)
                {
                    case "Sharabany": // שהרבני
                        btnJorden.IsEnabled = false;
                        btnHshmal.IsEnabled = true;
                        btnBt5ne.IsEnabled = true;
                        btnPublock.IsEnabled = true;
                        btnNoLock.IsEnabled = true;
                        DisplyLockType.Content = translockName(_CFLT.LockType);
                        break;
                    case "Electric": //חשמלי
                        btnJorden.IsEnabled = true;
                        btnHshmal.IsEnabled = false;
                        btnBt5ne.IsEnabled = true;
                        btnPublock.IsEnabled = true;
                        btnNoLock.IsEnabled = true;
                        DisplyLockType.Content = translockName(_CFLT.LockType);
                        break;
                    case "JordanKafol": //ירדני כפול
                        btnJorden.IsEnabled = true;
                        btnHshmal.IsEnabled = true;
                        btnBt5ne.IsEnabled = false;
                        btnPublock.IsEnabled = true;
                        btnNoLock.IsEnabled = true;
                        DisplyLockType.Content = translockName(_CFLT.LockType);
                        break;
                    case "Publock": //פבלוק
                        btnJorden.IsEnabled = true;
                        btnHshmal.IsEnabled = true;
                        btnBt5ne.IsEnabled = true;
                        btnPublock.IsEnabled = false;
                        btnNoLock.IsEnabled = true;
                        DisplyLockType.Content = translockName(_CFLT.LockType);
                        break;
                    case "NoLock": //ללא נעילה
                        btnJorden.IsEnabled = true;
                        btnHshmal.IsEnabled = true;
                        btnBt5ne.IsEnabled = true;
                        btnPublock.IsEnabled = true;
                        btnNoLock.IsEnabled = false;
                        DisplyLockType.Content = translockName(_CFLT.LockType);
                        break;
                    default:
                        btnJorden.IsEnabled = true;
                        btnHshmal.IsEnabled = true;
                        btnBt5ne.IsEnabled = true;
                        btnPublock.IsEnabled = true;
                        btnNoLock.IsEnabled = true;
                        DisplyLockType.Content = "";
                        break;
                }


                Lock_Input_box.Text = _CFLT.LockMeasure.ToString();
                if(Lock_Input_box.Text=="0" || Lock_Input_box.Text == "-1")
                {
                    Lock_Input_box.Text = "";
                }

                FloorHandle_Input_box.Text = _CFLT.LockMeasureFloor.ToString();
                if (FloorHandle_Input_box.Text == "0" || FloorHandle_Input_box.Text == "-1")
                {
                    FloorHandle_Input_box.Text = "";
                }

                UpperLock_Input_box.Text = _CFLT.UpperLockMeasure.ToString();
                if (UpperLock_Input_box.Text == "0" || UpperLock_Input_box.Text == "-1")
                {
                    UpperLock_Input_box.Text = "";
                }

                FloorUpperLock_Input_box.Text = _CFLT.UpperLockMeasureFloor.ToString();
                if (FloorUpperLock_Input_box.Text == "0" || FloorUpperLock_Input_box.Text == "-1")
                {
                    FloorUpperLock_Input_box.Text = "";
                }
                if (_CFLT.NoCalcu)
                {
                    LKC.FrameHightDisplay = 2100;
                }
                else
                {
                    LKC.FrameHightDisplay = _CFLT.FrameHiegth;
                }
            

                LKC.LockW = _CFLT.LockMeasure;
                LKC.LockW2 =  _CFLT.UpperLockMeasure;
               
                LKC.LockX = _CFLT.LockMeasureFloor;
                LKC.LockX2 = _CFLT.UpperLockMeasureFloor;
                LKC.lockType = _CFLT.LockType;

                LKC.LocksCalc();

                if(_CFLT.LockType == "Electric")
                {
                    txtLockHight.Content = LKC.LockHight + 17;
                }
                else
                {
                    txtLockHight.Content = LKC.LockHight;
                }

                txtUpperLockHight.Content = LKC.UpperLockHight;
             
                txtUpperLockFloorHight.Content = LKC.LockX2;
                txtHandleHight.Content = LKC.LockX;

                cbNocalcu.IsChecked = _CFLT.NoCalcu;
                cbNocalcu.Content = _CFLT.NoCalcu ? "No Calcu" : "Calcu";





            }
           
        }

        void _checkEnbledbox()
        {
            if(Lock_Input_box.Text != "" )
            {
                Lock_Input_box.IsEnabled = true;
                FloorHandle_Input_box.IsEnabled = false;
            }
            else if(FloorHandle_Input_box.Text != "")
            {
                Lock_Input_box.IsEnabled = false;
                FloorHandle_Input_box.IsEnabled = true;
            }
            else
            {
                Lock_Input_box.IsEnabled = true;
                FloorHandle_Input_box.IsEnabled = true;
            }

            if (UpperLock_Input_box.Text != "" )
            {
                UpperLock_Input_box.IsEnabled =true;
                FloorUpperLock_Input_box.IsEnabled = false;

            }
            else if(FloorUpperLock_Input_box.Text != "" )
            {
                UpperLock_Input_box.IsEnabled = false;
                FloorUpperLock_Input_box.IsEnabled = true;
            }
            else
            {
                UpperLock_Input_box.IsEnabled = true;
                FloorUpperLock_Input_box.IsEnabled = true;
            }

        }

        private void LockTypeJorden(object sender, RoutedEventArgs e)
        {
         
         
            _CFLT.LockType = "Sharabany";
            _CFLT.Save();
            DisplyLockType.Content = _CFLT.LockType;
            _update();
        }

        private void LockTypeElectric(object sender, RoutedEventArgs e)
        {
         
            _CFLT.LockType = "Electric";
            _CFLT.Save();

            DisplyLockType.Content = _CFLT.LockType;

           _update();
        }

        private void LockTypeDouble(object sender, RoutedEventArgs e)
        {
   
            _CFLT.LockType = "JordanKafol";
            _CFLT.Save();
            DisplyLockType.Content = _CFLT.LockType;
            _update();
        }

        private void LockTypePublock(object sender, RoutedEventArgs e)
        {
          
         
            _CFLT.LockType = "Publock";
            _CFLT.Save();
            DisplyLockType.Content = _CFLT.LockType;
            _update();
        }

        private void LockTypeNone(object sender, RoutedEventArgs e)
        {
         
            _CFLT.LockType = "NoLock";
            _CFLT.Save();
            DisplyLockType.Content = _CFLT.LockType;
            _update();
        }





        private void Lock_Input_box_KeyUp(object sender, KeyEventArgs e)
        {
            int.TryParse(Lock_Input_box.Text, out int res);

         if(Lock_Input_box.Text == "")
            {
                _CFLT.LockMeasure = -1;
            }
            else
            {
                _CFLT.LockMeasure = res;

            }

            _CFLT.Save();
                _update();
           
            
        }

        private void FloorHandle_Input_box_KeyUp(object sender, KeyEventArgs e)
        {

            int.TryParse(FloorHandle_Input_box.Text, out int res);

            if (FloorHandle_Input_box.Text == "")
            {
                _CFLT.LockMeasureFloor = -1;

            }
            else
            {
                _CFLT.LockMeasureFloor = res;

            }
            _CFLT.Save();
            _update();
          

        }

        private void UpperLock_Input_box_KeyUp(object sender, KeyEventArgs e)
        {
            int.TryParse(UpperLock_Input_box.Text, out int res);
  
            if(UpperLock_Input_box.Text == "")
            {
                _CFLT.UpperLockMeasure =-1;
            }
            else
            {
                _CFLT.UpperLockMeasure = res;

            }

            _CFLT.Save();
                _update();
                
            
        }

        private void FloorUpperLock_Input_box_KeyUp(object sender, KeyEventArgs e)
        {
            int.TryParse(FloorUpperLock_Input_box.Text, out int res);
          
         if(FloorUpperLock_Input_box.Text == "")
            {
                _CFLT.UpperLockMeasureFloor = -1;
            }
            else
            {
                _CFLT.UpperLockMeasureFloor = res;
            }
              
                _CFLT.Save();
                _update();
             
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
       

            _update();
        }

        private void FloorHandle_Input_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            _checkEnbledbox();
        }

        private void Lock_Input_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            _checkEnbledbox();
        }

        private void FloorUpperLock_Input_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            _checkEnbledbox();
        }

        private void UpperLock_Input_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            _checkEnbledbox();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
      

        }

        private void cbNocalcu_Checked(object sender, RoutedEventArgs e)
        {
            if (_CFLT != null)
            {
                _CFLT.NoCalcu = true;
                _CFLT.Save();

                _update();
            }
        }

        private void cbNocalcu_Unchecked(object sender, RoutedEventArgs e)
        {
            _CFLT.NoCalcu = false;
            _CFLT.Save();

            _update();
        }

        private void btnreset_Click(object sender, RoutedEventArgs e)
        {
            _CFLTTemp = clsFrameLockType.FindByFrameID(_FrameID);

            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            { 
            if(_CFLT != null)
                {
                    _CFLT.clear();
                    _CFLT.Save();
                    btnbackdata.Visibility = Visibility.Visible; 
                    _update();
                    _checkEnbledbox();
                }
            }
            }

        private void btnbackdata_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (_CFLTTemp != null)
                {
                    _CFLT = _CFLTTemp;
                    _CFLT.Save();
                    btnbackdata.Visibility = Visibility.Hidden;
                    _update();
                    _checkEnbledbox();
                }
            }
            }

        private void cbSlipCan_Checked(object sender, RoutedEventArgs e)
        {
            if (_CFLT != null)
            {
                _CFLT.SlipCan = true;
                _CFLT.Save();

                _update();
            }
           
        }

        private void cbSlipCan_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_CFLT != null)
            {
                _CFLT.SlipCan = false;
                _CFLT.Save();

                _update();
            }
        }
    }
}
