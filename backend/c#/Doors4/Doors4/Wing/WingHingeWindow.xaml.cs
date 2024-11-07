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
    /// Interaction logic for WingHingeWindow.xaml
    /// </summary>
    public partial class WingHingeWindow : Window
    {
        int _wingID;
        int _HingeID;
        enum Mymode { Add=1,Update=2};
        Mymode _mode = Mymode.Add;

        clsWingHinge _hinge;
        clsWingHinge _hingeTemp;

        clsWings _Wing;

        public WingHingeWindow(int HingeID,int WingID)
        {

            InitializeComponent();
            wpfSetting.SetLang(Properties.Settings.Default.lang);
            _wingID = WingID;
            _HingeID = HingeID;
            _Wing = clsWings.Find(_wingID);
            if (_HingeID == -1)
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

       void UPDATEUI()
        {
            _save();
            _filltxt();

        }
        string _getFromDBconverToEmpty(int num)
        {
            if (_hinge != null)
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
        void _filltxt()
        {
            if(_hinge != null)
            {
                NumHinges.Text = _getFromDBconverToEmpty(_hinge.Amount);
                txtHeightToBottomHinge.Text =_getFromDBconverToEmpty(_hinge.HeightToBottomHinge);
                txtHingeSize.Text =          _getFromDBconverToEmpty(_hinge.Size);
                FrameHinge1Height.Text =     _getFromDBconverToEmpty(_hinge.H1);
                FrameHinge2Height.Text =     _getFromDBconverToEmpty(_hinge.H2);
                FrameHinge3Height.Text =     _getFromDBconverToEmpty(_hinge.H3);
                FrameHinge4Height.Text =     _getFromDBconverToEmpty(_hinge.H4);
                FrameHinge5Height.Text =     _getFromDBconverToEmpty(_hinge.H5);
                FrameHinge6Height.Text = _getFromDBconverToEmpty(_hinge.H6);

                if(_hinge.HingeType == "4X4")
                {
                    btnHingeType4x4.IsEnabled = false;
                    btnHingeType4x35.IsEnabled = true;
                }
                else if (_hinge.HingeType == "4X3.5")
                {
                    btnHingeType4x4.IsEnabled = true;
                    btnHingeType4x35.IsEnabled = false;

                }
                else
                {
                    btnHingeType4x4.IsEnabled = true;
                    btnHingeType4x35.IsEnabled = true;
                }

                if (_hinge.UpperMid)
                {
                    UpperMidHin.IsChecked = true;
                }
                else
                {
                    UpperMidHin.IsChecked = false;
                }
            }
       
        }

        void _addNew()
        {
            _hinge = new clsWingHinge();
            _hinge.WingID = _wingID;
            _hinge.H1 = 165;
            _hinge.H2 = 952;
            _hinge.H3 = 1740;
            _hinge.Amount = 3;

            if (_hinge.Save())
            {
                _HingeID = _hinge.ID;
                _mode = Mymode.Update;
                UPDATEUI();
            }

        }   
        
        void _update()
        {
            if(_HingeID > -1)
            {

                _hinge = clsWingHinge.Find(_HingeID);

 
            }
        }

        void _save()
        {
            switch (_mode)
            {
                case Mymode.Add:
                    _addNew();
                    break;
                case Mymode.Update:
                    _update();
                    break;
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            UPDATEUI();

            if(_Wing != null)
            {
                clsWingHinge temp = clsWingHinge.FindByWingID(_Wing.DDWingID);
                if(temp != null)
                {
                    temp.copyfrom(_hinge);
                    temp.Save();
                }
            }
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

        private void saveToDB(object sender, KeyEventArgs e)
        {
            TextBox text = sender as TextBox;

            switch (text.Name)
            {

                case "NumHinges":
                    _hinge.Amount = _ValidateInputs(text.Text);
                    break;

                case "txtHeightToBottomHinge":
                    _hinge.HeightToBottomHinge = _ValidateInputs(text.Text);
                    break;
           
                case "txtHingeSize":
                    _hinge.Size = _ValidateInputs(text.Text);
                    break;     
                    
                case "FrameHinge1Height":
                    _hinge.H1 = _ValidateInputs(text.Text);
                    break;
                                 
                case "FrameHinge2Height":
                    _hinge.H2 = _ValidateInputs(text.Text);
                    break;                               
        
                case "FrameHinge3Height":
                    _hinge.H3 = _ValidateInputs(text.Text);
                    break;

                case "FrameHinge4Height":
                    _hinge.H4 = _ValidateInputs(text.Text);
                    break;
              
                case "FrameHinge5Height":
                    _hinge.H5 = _ValidateInputs(text.Text);
                    break;   
                    
                case "FrameHinge6Height":
                    _hinge.H6 = _ValidateInputs(text.Text);
                    break;

            }

            if (_hinge.Save())
            {
                UPDATEUI();
            }
          
        }

        private void btntype(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btnHingeType4x4":
                    _hinge.HingeType = "4X4";
                    break; 
                
                case "btnHingeType4x35":
                    _hinge.HingeType = "4X3.5";
                    break;
            }

            if (_hinge.Save())
            {
                UPDATEUI();
            }
        }

        private void UpperMidHin_Checked(object sender, RoutedEventArgs e)
        {
            _hinge.H2 = 515;
            _hinge.UpperMid = true;

            if (_hinge.Save())
            {
                UPDATEUI();
            }

        }

        private void UpperMidHin_Unchecked(object sender, RoutedEventArgs e)
        {
            _hinge.H2 = 952;
            _hinge.UpperMid = false;

            if (_hinge.Save())
            {
                UPDATEUI();
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (_hinge != null)
            {
                _hingeTemp = clsWingHinge.FindByWingID(_wingID);
               

                if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

                {
                    btnback.Visibility = Visibility.Visible;
                    _hinge.clear();
                    _hinge.Save();
                    UPDATEUI();
                }
            }
            }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            if (_hingeTemp != null)
            {
             


                if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

                {
                    btnback.Visibility = Visibility.Hidden;
                    _hinge = _hingeTemp;
                    _hinge.Save();
                    UPDATEUI();
                }
            }
        }
    }
}
