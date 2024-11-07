using Doors4;
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

namespace Door3
{
    /// <summary>
    /// Interaction logic for TapiFrameAdvancedWindow.xaml
    /// </summary>
    public partial class TapiFrameAdvancedWindow : Window
    {

        enum Mode { Add=1,Update=2}

        Mode _mode = Mode.Add;

        int _FrameID;
        int _AdvancedID;

        clsFrameAdvanced _advanced;
        clsFrameAdvanced _advancedTemp;

        public TapiFrameAdvancedWindow(int FrameID)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            _mode = Mode.Add;
            _FrameID = FrameID;
            Save();
        }
              
        public TapiFrameAdvancedWindow(int FrameID,int AdvancedID)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            _mode = Mode.Update;
            _FrameID = FrameID;
            _AdvancedID = AdvancedID;
            Save();
        }



        void Save()
        {

            switch (_mode)
            {
                case Mode.Add:
                    _AddNew();
                    break;

                case Mode.Update:
                    _UpdateCurrent();
                    break;
            }

        }

        void _AddNew()
        {
            _advanced = new clsFrameAdvanced();

            _advanced.FrameID = _FrameID;

            if (_advanced.Save())
            {
                _AdvancedID = _advanced.ID;
                _mode = Mode.Update;
                UPDATEUI();
            }
        }

        void _UpdateCurrent()
        {
            _advanced = clsFrameAdvanced.Find(_AdvancedID);
            UPDATEUI();
        }


        void UPDATEUI()
        {
            FillAll();

        }

        void FillAll()
        {
            if (_advanced != null)
            {
                txtFromA.Text = _advanced.FromAbove.ToString();
                txtFromB.Text = _advanced.FromBottom.ToString();
                cbHiddenOil.IsChecked = _advanced.HiddenOil;
                cbMenualeFrameSize.IsChecked = _advanced.ManualSize;
            }
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbHiddenOil_Checked(object sender, RoutedEventArgs e)
        {
            if(_advanced != null)
            {

                _advanced.HiddenOil = true;

                if (_advanced.Save())
                {
                    UPDATEUI();
                }

            }
        }

        private void cbHiddenOil_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_advanced != null)
            {

                _advanced.HiddenOil = false;

                if (_advanced.Save())
                {
                    UPDATEUI();
                }

            }
        }

        private void cbMenualeFrameSize_Checked(object sender, RoutedEventArgs e)
        {
            if (_advanced != null)
            {

                _advanced.ManualSize = true;

                if (_advanced.Save())
                {
                    UPDATEUI();
                }

            }
        }

        private void cbMenualeFrameSize_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_advanced != null)
            {

                _advanced.ManualSize = false;

                if (_advanced.Save())
                {
                    UPDATEUI();
                }

            }
        }

        private void txtFromA_KeyUp(object sender, KeyEventArgs e)
        {
            if (_advanced != null)
            {

                _advanced.FromAbove =int.Parse( txtFromA.Text);

                if (_advanced.Save())
                {
                    UPDATEUI();
                }

            }
        }

        private void txtFromB_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void txtFromB_KeyUp(object sender, KeyEventArgs e)
        {
            if (_advanced != null)
            {

                _advanced.FromBottom = int.Parse(txtFromB.Text);

                if (_advanced.Save())
                {
                    UPDATEUI();
                }

            }
        }

        private void btBackdata_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _advanced = _advancedTemp;
                _advanced.Save();
                btBackdata.Visibility = Visibility.Hidden;
                UPDATEUI();
                UPDATEUI();
            }
            }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            _advancedTemp = clsFrameAdvanced.FindByFrameID(_FrameID);
            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _advanced.clear();
                _advanced.Save();
                btBackdata.Visibility = Visibility.Visible;
                UPDATEUI();
            }
            }
    }
}
