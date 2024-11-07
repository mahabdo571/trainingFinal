using SharaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Interaction logic for WingAdvancedWindow.xaml
    /// </summary>
    public partial class WingAdvancedWindow : Window
    {
        int _WingID;
        int _AdvanceID;

        clsWingAdvanced _Advaced;
        clsWingAdvanced _AdvacedTemp;
        enum MyMode { Add=1,Update=2}
        MyMode _mode = MyMode.Add;

        clsWings _wing;


        public WingAdvancedWindow(int WingID,int AdvanceAD)
        {
            InitializeComponent();
            wpfSetting.SetLang(Properties.Settings.Default.lang);
            _wing = clsWings.Find(WingID);
            _WingID = WingID;
            _AdvanceID = AdvanceAD;

            if(_AdvanceID == -1)
            {
                _mode = MyMode.Add;
                UPDATEUI();
            }
            else
            {
                _mode = MyMode.Update;
                UPDATEUI();
            }

        }

       void UPDATEUI()
        {
            _Save();
            if (_Advaced != null)
            {
                _Filltxt();
                _FillCb();
            }
        }

        void _Save()
        {
            switch (_mode)
            {
                case MyMode.Add:
                    _add();
                    break;
                case MyMode.Update:
                    _update();
                    break;
            }
        }

        void _add()
        {
            _Advaced = new clsWingAdvanced();
            _Advaced.WingID = _WingID;

            if (_Advaced.Save())
            {
                _AdvanceID = _Advaced.ID;
                _mode = MyMode.Update;
                UPDATEUI();
            }
        }

        void _update()
        {
            if(_AdvanceID > 0)
            {
                
                _Advaced = clsWingAdvanced.Find(_AdvanceID);

            }

        }
        string _getFromDBconverToEmpty(int num)
        {
            if (_Advaced != null)
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
        void _Filltxt()
        {
            if (_Advaced != null)
            {
                txtThicknessWing.Text = _getFromDBconverToEmpty(_Advaced.ThicknessWing);
                txtWingShorteningFromAbove.Text = _getFromDBconverToEmpty(_Advaced.WingShorteningFromAbove);
                txtWingShorteningFromBottom.Text = _getFromDBconverToEmpty(_Advaced.WingShorteningFromBottom);
            
                txtwoodLockBasicLocation.Text = _getFromDBconverToEmpty(_Advaced.woodLockBasicLocation);
                txtwoodLockBasicWidth.Text = _getFromDBconverToEmpty(_Advaced.woodLockBasicWidth);
                txtwoodLockBasicHeight.Text = _getFromDBconverToEmpty(_Advaced.woodLockBasicHeight);
                txtwoodBehalaLockLocation.Text = _getFromDBconverToEmpty(_Advaced.woodBehalaLockLocation);
                txtwoodBehalaLockWidth.Text = _getFromDBconverToEmpty(_Advaced.woodBehalaLockWidth);
                txtwoodBehalaLockHeight.Text = _getFromDBconverToEmpty(_Advaced.woodBehalaLockHeight);
                txtwoodSpeacilCasesHingeUPLocation.Text = _getFromDBconverToEmpty(_Advaced.woodSpeacilCasesHingeUPLocation);
                txtwoodSpeacilCasesHingeUPWidth.Text = _getFromDBconverToEmpty(_Advaced.woodSpeacilCasesHingeUPWidth);
                txtwoodSpeacilCasesHingeUPHeight.Text = _getFromDBconverToEmpty(_Advaced.woodSpeacilCasesHingeUPHeight);
                txtwoodSpeacilCasesHingeDNLocation.Text = _getFromDBconverToEmpty(_Advaced.woodSpeacilCasesHingeDNLocation);
                txtwoodSpeacilCasesHingeDNWidth.Text = _getFromDBconverToEmpty(_Advaced.woodSpeacilCasesHingeDNWidth);
                txtwoodSpeacilCasesHingeDNHeight.Text = _getFromDBconverToEmpty(_Advaced.woodSpeacilCasesHingeDNHeight);
                txtKantA.Text = _getFromDBconverToEmpty(_Advaced.KantA);
                txtKantB.Text = _getFromDBconverToEmpty(_Advaced.KantB);
                

            }
            }

        void _FillCb()
        {
            if (_Advaced != null)
            {
              
      
                    cbCylinder.IsChecked = _Advaced.Cylinder;
          
                    cbHandleHoles.IsChecked = _Advaced.HandleHoles;
                    cbHolesCylinder.IsChecked = _Advaced.HolesCylinder;
                    cbPullHandle.IsChecked = _Advaced.PullHandle;
                    cbPullSideLever.IsChecked = _Advaced.PullSideLever;
                    cbPushHandle.IsChecked = _Advaced.PushHandle;
                    cbPushSideLever.IsChecked = _Advaced.PushSideLever;
                    cbwoodLockBasic.IsChecked = _Advaced.woodLockBasic;
                cbwoodBehalaLock.IsChecked = _Advaced.woodBehalaLock;
                cbwoodUpeerLock.IsChecked = _Advaced.woodUpeerLock;
                cbwoodSpeacilCasesHingeUP.IsChecked = _Advaced.woodSpeacilCasesHingeUP;
                cbwoodSpeacilCasesHingeDN.IsChecked = _Advaced.woodSpeacilCasesHingeDN;
                    
                

            }
            }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
       
              if(_Advaced != null)
            {
                _Advaced.Save();
            }
            
              if(_wing != null)
            {
                clsWingAdvanced temp = clsWingAdvanced.FindByWingID(_wing.DDWingID);
                if(temp != null)
                {
                    temp.ThicknessWing = _Advaced.ThicknessWing;
                    temp.Save();

                }
            }
            Close();
        }

        private void cbSaveDB(object sender, RoutedEventArgs e)
        {
            CheckBox cbs = sender as CheckBox;
            if (_Advaced != null)
            {
         

                switch (cbs.Name)
                {
              
                    case "cbPushSideLever":
                        _Advaced.PushSideLever = true;
                        _Advaced.PushHandle = false;
                        break;  
                    case "cbPushHandle":
                        _Advaced.PushSideLever = false;
                        _Advaced.PushHandle = true;
                        break;  
                    case "cbPullSideLever":
                        _Advaced.PullSideLever = true;
                        _Advaced.PullHandle = false;
                        break;  
                    case "cbPullHandle":
                        _Advaced.PullSideLever = false;
                        _Advaced.PullHandle = true;
                        break;  
                    
                    case "cbHandleHoles":
                        _Advaced.HandleHoles = true;
                        break;       
                 
                    case "cbCylinder":
                        _Advaced.Cylinder = true;
                        break;
                    
                    case "cbHolesCylinder":
                        _Advaced.HolesCylinder = true;
                        break;
                    case "cbwoodLockBasic":
                        _Advaced.woodLockBasic = true;
                        break;
                    case "cbwoodBehalaLock":
                        _Advaced.woodBehalaLock = true;
                        _Advaced.woodBehalaLockManual = true;

                        break;  
                    case "cbwoodUpeerLock":
                        _Advaced.woodUpeerLock = true;
                        break;    
                    case "cbwoodSpeacilCasesHingeUP":
                        _Advaced.woodSpeacilCasesHingeUP = true;
                        break;    
                    case "cbwoodSpeacilCasesHingeDN":
                        _Advaced.woodSpeacilCasesHingeDN = true;
                        break;

                }

                if (_Advaced.Save())
                {
                    UPDATEUI();
                }

            }

        }

        private void UcbSaveDB(object sender, RoutedEventArgs e)
        {
            CheckBox ucbs = sender as CheckBox;
            if (_Advaced != null)
            {


                switch (ucbs.Name)
                {
              
                    case "cbPushSideLever":
                        _Advaced.PushSideLever = false;
                        break;
                    case "cbPushHandle":
                        _Advaced.PushHandle = false;
                        break;
                    case "cbPullSideLever":
                        _Advaced.PullSideLever = false;
                        break;
                    case "cbPullHandle":
                        _Advaced.PullHandle = false;
                        break;

                    case "cbHandleHoles":
                        _Advaced.HandleHoles = false;
                        break;
           
                    case "cbCylinder":
                        _Advaced.Cylinder = false;
                        break;

                    case "cbHolesCylinder":
                        _Advaced.HolesCylinder = false;
                        break;   
                    case "cbwoodLockBasic":
                        _Advaced.woodLockBasic = false;
                        break;    
                    case "cbwoodBehalaLock":
                        _Advaced.woodBehalaLock = false;
                        break; 
                    case "cbwoodUpeerLock":
                        _Advaced.woodUpeerLock = false;
                        break; 
                    case "cbwoodSpeacilCasesHingeUP":
                        _Advaced.woodSpeacilCasesHingeUP = false;
                        break;
                    case "cbwoodSpeacilCasesHingeDN":
                        _Advaced.woodSpeacilCasesHingeDN = false;
                        break;
                }
                if (_Advaced.Save())
                {
                    UPDATEUI();
                }

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
        private void txtSaveDB(object sender, KeyEventArgs e)
        {
            if (_Advaced != null)
            {
                TextBox txts = sender as TextBox;

                switch (txts.Name)
                {
                    case "txtWingShorteningFromBottom":
                        _Advaced.WingShorteningFromBottom = _ValidateInputs(txts.Text);
                        break;    
                    case "txtWingShorteningFromAbove":
                        _Advaced.WingShorteningFromAbove = _ValidateInputs(txts.Text);
                        break; 
                    case "txtThicknessWing":
                        _Advaced.ThicknessWing = _ValidateInputs(txts.Text);
                        _Advaced.CalcKant();
                        break;  
                    case "txtwoodLockBasicLocation":
                        _Advaced.woodLockBasicLocation = _ValidateInputs(txts.Text);
                        break; 
                    case "txtwoodLockBasicWidth":
                        _Advaced.woodLockBasicWidth = _ValidateInputs(txts.Text);
                        break; 
                    case "txtwoodLockBasicHeight":
                        _Advaced.woodLockBasicHeight = _ValidateInputs(txts.Text);
                        break;    
                    case "txtwoodBehalaLockLocation":
                        _Advaced.woodBehalaLockLocation = _ValidateInputs(txts.Text);
                        break;   
                    case "txtwoodBehalaLockWidth":
                        _Advaced.woodBehalaLockWidth = _ValidateInputs(txts.Text);
                        break;  
                    case "txtwoodBehalaLockHeight":
                        _Advaced.woodBehalaLockHeight = _ValidateInputs(txts.Text);
                        break;
                
                    case "txtwoodSpeacilCasesHingeUPLocation":
                        _Advaced.woodSpeacilCasesHingeUPLocation = _ValidateInputs(txts.Text);
                        break;   
                    case "txtwoodSpeacilCasesHingeUPWidth":
                        _Advaced.woodSpeacilCasesHingeUPWidth = _ValidateInputs(txts.Text);
                        break;   
                    case "txtwoodSpeacilCasesHingeUPHeight":
                        _Advaced.woodSpeacilCasesHingeUPHeight = _ValidateInputs(txts.Text);
                        break;  
                    case "txtwoodSpeacilCasesHingeDNLocation":
                        _Advaced.woodSpeacilCasesHingeDNLocation = _ValidateInputs(txts.Text);
                        break;  
                    case "txtwoodSpeacilCasesHingeDNWidth":
                        _Advaced.woodSpeacilCasesHingeDNWidth = _ValidateInputs(txts.Text);
                        break;
                     case "txtwoodSpeacilCasesHingeDNHeight":
                        _Advaced.woodSpeacilCasesHingeDNHeight = _ValidateInputs(txts.Text);
                        break; 
                    
                    case "txtKantA":
                        
                        _Advaced.KantA = _ValidateInputs(txts.Text);
                        break;   
                    case "txtKantB":
                        _Advaced.KantB = _ValidateInputs(txts.Text);
                        break;
              
                }

                if (_Advaced.Save())
                {
                    UPDATEUI();
                }

            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UPDATEUI();
        }

        private void txtThicknessWing_TextChanged(object sender, TextChangedEventArgs e)
        {
     

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            _AdvacedTemp = clsWingAdvanced.FindByWingID(_WingID);

            if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

            { 
            if(_Advaced != null)
                {
                    _Advaced.clear();
                    _Advaced.Save();
                    UPDATEUI();
                    btnBack.Visibility = Visibility.Visible;
                }
            }
            }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

            {
                if (_AdvacedTemp != null)
                {
                    _Advaced = _AdvacedTemp;
                    _Advaced.Save();
                    UPDATEUI();
                    btnBack.Visibility = Visibility.Hidden;
                }
            }
            }
    }
}
 