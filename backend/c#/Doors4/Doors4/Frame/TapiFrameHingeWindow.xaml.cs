using Doors4;
using SharaLogic;
using SharaLogic.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Door3
{
    /// <summary>
    /// Interaction logic for TapiFrameHingeWindow.xaml
    /// </summary>
    public partial class TapiFrameHingeWindow : Window
    {




        HingeCalc FHC;
        // FrameMainCalc FMC;

        enum myMode { addnew = 1, update = 2 }

        myMode _mode = myMode.addnew;

        clsHingesFrames _Hframe;
        clsHingesFrames _HframeTemp;

        int _IDhingeFrame;
        int _FrameId;

        public int UMGH { get; set; }
        int DisplayHightInHinge;
        public int HingeAmount { get; set; }


        public TapiFrameHingeWindow(int idHingeFrame,int FrameId , int Height)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            if (Doors4.Properties.Settings.Default.lang == "HE")
            {
              
                this.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
         
                this.FlowDirection = FlowDirection.LeftToRight;
            }
            FHC = new HingeCalc();

            DisplayHightInHinge = Height;
            _FrameId = FrameId;

            if (idHingeFrame == -1)
            {
                _mode = myMode.addnew;
                _LoadData();

            }
            else
            {
                _IDhingeFrame = idHingeFrame;
                _Hframe = clsHingesFrames.Find(_IDhingeFrame);
                _mode = myMode.update;
                _LoadData();
            }


        }



        void _addNew()
        {

            _Hframe = new clsHingesFrames();
            _Hframe.HingeAmount = 3; //defult value
            _Hframe.FrameID = _FrameId;
            if (_Hframe.Save())
            {
       
                _mode = myMode.update;
                _IDhingeFrame = _Hframe.ID;

                _LoadData();
            }


        }

        void FillInput()
        {
            if (_Hframe.HingeType == "4X4")
            {
                btnHingeType4x4.IsEnabled = false;
                btnHingeType4x35.IsEnabled = true;
            }
            else if (_Hframe.HingeType == "4X3.5")
            {
                btnHingeType4x4.IsEnabled = true;
                btnHingeType4x35.IsEnabled = false;
            }
            else
            {
                btnHingeType4x4.IsEnabled = true;
                btnHingeType4x35.IsEnabled = true;
            }

            if (_Hframe.HingeMetal == "Megolvan")
            {
                btnHingeMetalM.IsEnabled = false;
                btnHingeMetalN.IsEnabled = true;


            }
            else if (_Hframe.HingeMetal == "Norsta")
            {
                btnHingeMetalM.IsEnabled = true;
                btnHingeMetalN.IsEnabled = false;
            }
            else
            {
                btnHingeMetalM.IsEnabled = true;
                btnHingeMetalN.IsEnabled = true;
            }

            if (_Hframe.HingeConnection == "Soldering")
            {
                btnHingeConnectionSoldering.IsEnabled = false;
                btnHingeConnectionHole.IsEnabled = true;

            }
            else if (_Hframe.HingeConnection == "Hole")
            {
                btnHingeConnectionSoldering.IsEnabled = true;
                btnHingeConnectionHole.IsEnabled = false;
            }
            else
            {
                btnHingeConnectionSoldering.IsEnabled = true;
                btnHingeConnectionHole.IsEnabled = true;

            }

          
                cbNoCalc.IsChecked = _Hframe.NoCalcu;

            cbNoCalc.Content = _Hframe.NoCalcu ? "No Calcu" : "Calcu";
            
            
        }

        void _update()
        {

     
            if (_Hframe != null)
            {
           
                calcHing();
             
                NumHinges.Text = _Hframe.HingeAmount.ToString();
                UpperMidHin.IsChecked = _Hframe.TopMeddleHinge;
                txtHingeSize.Text = _Hframe.HingeDimension.ToString();
                

                txtHeightToBottomHinge.Text = _Hframe.HeightToBottomHinge.ToString();
                FrameHight1disp.Content = DisplayHightInHinge.ToString();

                FrameHinge1Height.Text = (_Hframe.Hinge1 != -1) ? _Hframe.Hinge1.ToString() : "";
                FrameHinge2Height.Text = (_Hframe.Hinge2 != -1) ? _Hframe.Hinge2.ToString() : "";
                FrameHinge3Height.Text = (_Hframe.Hinge3 != -1) ? _Hframe.Hinge3.ToString() : "";
                FrameHinge4Height.Text = (_Hframe.Hinge4 != -1) ? _Hframe.Hinge4.ToString() : "";
                FrameHinge5Height.Text = (_Hframe.Hinge5 != -1) ? _Hframe.Hinge5.ToString() : "";
                FrameHinge6Height.Text = (_Hframe.Hinge6 != -1) ? _Hframe.Hinge6.ToString() : "";

                _Hframe.FrameID = _FrameId;

                FillInput();



            }


        }



        void _LoadData()
        {
            switch (_mode)
            {
                case myMode.addnew:
                    _addNew();
                    return;
                case myMode.update:
                    _update();
                    return;
            }
        }



        public void UpperMidHG(object sender, RoutedEventArgs e)
        {

        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {


            _LoadData();
            this.Close();
        }



        private void HingeSizeInput(object sender, TextChangedEventArgs e)
        {
            // FMC.HingeSize = txtHingeSize.Text;temp
        }

        private void NumHinges_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtHingeSize_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.HingeDimension = int.TryParse(txtHingeSize.Text, out int result) ? result : 0;
                _Hframe.Save();
                _LoadData();
            }
        }








        private void txtHeightToBottomHinge_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.HeightToBottomHinge = int.TryParse(txtHeightToBottomHinge.Text, out int result) ? result : 0;
                _Hframe.Save();
                _LoadData();

            }
        }

        private void UpperMidHin_Checked(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.TopMeddleHinge = true;
                _Hframe.Save();
                _LoadData();

            }
        }

        private void UpperMidHin_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.TopMeddleHinge = false;
                _Hframe.Save();
                _LoadData();

            }
        }

        private void btnHingeMetalM_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.HingeMetal = "Megolvan";
                _Hframe.Save();
                btnHingeMetalM.IsEnabled = false;
                btnHingeMetalN.IsEnabled = true;
                _LoadData();


            }
        }

        private void btnHingeMetalN_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.HingeMetal = "Norsta";
                _Hframe.Save();
                btnHingeMetalM.IsEnabled = true;
                btnHingeMetalN.IsEnabled = false;

                _LoadData();


            }
        }

        private void btnHingeType4x4_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.HingeType = "4X4";
                _Hframe.Save();
                btnHingeType4x4.IsEnabled = false;
                btnHingeType4x35.IsEnabled = true;

                _LoadData();


            }
        }

        private void btnHingeType4x35_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.HingeType = "4X3.5";
                _Hframe.Save();
                btnHingeType4x4.IsEnabled = true;
                btnHingeType4x35.IsEnabled = false;

                _LoadData();


            }
        }

        private void btnHingeConnectionSoldering_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.HingeConnection = "Soldering";
                _Hframe.Save();
                btnHingeConnectionSoldering.IsEnabled = false;
                btnHingeConnectionHole.IsEnabled = true;

                _LoadData();


            }
        }

        private void btnHingeConnectionHole_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.HingeConnection = "Hole";
                _Hframe.Save();
                btnHingeConnectionSoldering.IsEnabled = true;
                btnHingeConnectionHole.IsEnabled = false;

                _LoadData();


            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _LoadData();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            CloseWindow(null, null);
        }

        void calcHing()
        {


            if (UpperMidHin.IsChecked == true)
            {
                FHC.UpperMiddleHinge = 519;
            }
            else if (_Hframe.HingeAmount > 3)
            {
                FHC.UpperMiddleHinge = 519;
            }
            else
            {
                FHC.UpperMiddleHinge = 956;
            }


            if (_Hframe.NoCalcu)
            {
                FHC.DisplayHingeFrameHight =2100 ;
            }
            else
            {
                FHC.DisplayHingeFrameHight = DisplayHightInHinge;
            }
            FHC.HingeAmount = int.TryParse(NumHinges.Text, out int num) ? num : 3;


            _checkHingestatu();


            FHC.HingesCalc();


            txtHinge1.Content = FHC.F1H;
            txtHinge2.Content = FHC.F2H;
            txtHinge3.Content = FHC.F3H;
            txtHinge4.Content = FHC.F4H;
            txtHinge5.Content = FHC.F5H;
            txtHinge6.Content = FHC.F6H;




        }

        void _checkHingestatu()
        {
            if (_Hframe != null)
            {


                if (FrameHinge1Height.Text == "")
                {
                    FHC.FH1H = -1;
                }
                else
                {
                    FHC.FH1H = _Hframe.Hinge1;
                }

                if (FrameHinge2Height.Text == "")
                {
                    FHC.FH2H = -1;
                }
                else
                {
                    FHC.FH2H = _Hframe.Hinge2;
                }

                if (FrameHinge3Height.Text == "")
                {
                    FHC.FH3H = -1;
                }
                else
                {
                    FHC.FH3H = _Hframe.Hinge3;
                }

                if (FrameHinge4Height.Text == "")
                {
                    FHC.FH4H = -1;
                }
                else
                {
                    FHC.FH4H = _Hframe.Hinge4;
                }

                if (FrameHinge5Height.Text == "")
                {
                    FHC.FH5H = -1;
                }
                else
                {
                    FHC.FH5H = _Hframe.Hinge5;
                }

                if (FrameHinge6Height.Text == "")
                {
                    FHC.FH6H = -1;
                }
                else
                {
                    FHC.FH6H = _Hframe.Hinge6;
                }
            }


        }


        private void NumHinges_KeyUp(object sender, KeyEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.HingeAmount = int.TryParse(NumHinges.Text, out int result) ? result : -1;
                _Hframe.Save();

                _LoadData();
            }
        }

        private void FrameHinge1Height_KeyUp(object sender, KeyEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.Hinge1 = int.TryParse(FrameHinge1Height.Text, out int result) ? result : -1;
                _Hframe.Save();
                _LoadData();
            }
        }

        private void FrameHinge2Height_KeyUp(object sender, KeyEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.Hinge2 = int.TryParse(FrameHinge2Height.Text, out int result) ? result : -1;
                _Hframe.Save();
                _LoadData();
            }
        }

        private void FrameHinge3Height_KeyUp(object sender, KeyEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.Hinge3 = int.TryParse(FrameHinge3Height.Text, out int result) ? result : -1;
                _Hframe.Save();
                _LoadData();
            }
        }

        private void FrameHinge4Height_KeyUp(object sender, KeyEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.Hinge4 = int.TryParse(FrameHinge4Height.Text, out int result) ? result : -1;
                _Hframe.Save();
                _LoadData();
            }
        }

        private void FrameHinge5Height_KeyUp(object sender, KeyEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.Hinge5 = int.TryParse(FrameHinge5Height.Text, out int result) ? result : -1;
                _Hframe.Save();
                _LoadData();
            }
        }

        private void FrameHinge6Height_KeyUp(object sender, KeyEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.Hinge6 = int.TryParse(FrameHinge6Height.Text, out int result) ? result : -1;
                _Hframe.Save();
                _LoadData();


            }
        }

        private void cbNoCalc_Checked(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.NoCalcu = true;
                _Hframe.Save();
                _LoadData();


            }
        }

        private void cbNoCalc_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_mode == myMode.update)
            {
                _Hframe.NoCalcu = false;
                _Hframe.Save();
                _LoadData();


            }
        }

        private void btnbackdata_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (_Hframe != null)
                {
                    _Hframe = _HframeTemp;
                    _Hframe.Save();
                    btnbackdata.Visibility = Visibility.Visible;
                    _LoadData();
                }
            }
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _HframeTemp = clsHingesFrames.FindByFrameID(_FrameId);
            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            { 
                if(_Hframe != null)
                {
                    _Hframe.clear();
                    _Hframe.Save();
                    btnbackdata.Visibility = Visibility.Visible;
                    _LoadData();
                }
            
            }
            }
    }
}
