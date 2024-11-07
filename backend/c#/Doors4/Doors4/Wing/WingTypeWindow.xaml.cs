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
    /// Interaction logic for WingTypeWindow.xaml
    /// </summary>
    public partial class WingTypeWindow : Window
    {
        int _wingID;
        int _wingTypeID;
        enum myMode { addnew=1,update=2}

        myMode _mode = myMode.addnew;

        clsWingType _wingType;
        clsWingType _wingTypeTemp;
        clsWings winngtemp;
        Brush _primerColer = (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF"));
        public WingTypeWindow(int WingID , int WingTypeID)
        {
            InitializeComponent();
            wpfSetting.SetLang(Properties.Settings.Default.lang);
            _wingID = WingID;
            _wingTypeID = WingTypeID;
            winngtemp = clsWings.Find(_wingID);
            if (_wingTypeID == -1)
            {
                _mode = myMode.addnew;
                UPDATEUI();
            }
            else
            {
                _mode = myMode.update;
                UPDATEUI();
            }
            if (winngtemp.DoubleDoor)
            {
                btnZaza.IsEnabled = false;
                btnTest1_Pivot.IsEnabled = false;
            }
            else
            {
                btnZaza.IsEnabled = true;
                btnTest1_Pivot.IsEnabled = true;
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            if (_wingType != null)
            {
                _wingType.Save();
             
                if (winngtemp != null) {
                    clsWingType tempwingtype = clsWingType.FindByWingID(winngtemp.DDWingID);
                    if(tempwingtype != null)
                    {
                        tempwingtype.TEST1 = _wingType.TEST1;
                        tempwingtype.TEST2 = _wingType.TEST2;
                        tempwingtype.TEST3 = _wingType.TEST3;
                        tempwingtype.TEST4 = _wingType.TEST4;
                        tempwingtype.Save();
                    }

                }
            } 
            this.Close();
        }

        void UPDATEUI()
        {
            _Save();
            _checkTest3Input();
            _checkTest2Input();
      
            _checkTest1Input();
            if (_wingType != null)
            {
                NameType.Content = _wingType.TEST1 + _wingType.TEST2 + _wingType.TEST3 + _wingType.TEST4;
            }
        }

        void _AddNew()
        {
            _wingType = new clsWingType();
            _wingType.WingID = _wingID;

            if(_wingType.Save() )
            {
                _wingID = _wingType.WingID;
                _wingTypeID = _wingType.ID;
                _mode = myMode.update;
                UPDATEUI();
            }


        }


        void _Update()
        {
            _wingType = clsWingType.Find(_wingTypeID);
           
        }
        private void _Save()
        {

            switch(_mode)
            {

                case myMode.addnew:
                    _AddNew();
                    break; 
                case myMode.update:
                    _Update();
                    break; 
            }

        }



        void _checkTest3Input()
        {
            if (_wingType != null)
            {
                switch (_wingType.TEST3)
                {
                    case "0":
                        btnTest3_Samoe.Background = Brushes.GreenYellow;

                        btnTest3_jaloe3.Background = _primerColer;
                        btnTest3_Medic.Background = _primerColer;
                        btnTest3_jaloe4.Background = _primerColer;

                        break;
                    case "3":
                        btnTest3_Samoe.Background = _primerColer;
                        btnTest3_jaloe3.Background = Brushes.GreenYellow;

                        btnTest3_Medic.Background = _primerColer;
                        btnTest3_jaloe4.Background = _primerColer;


                        break;
                    case "4":
                        btnTest3_Samoe.Background = _primerColer;
                        btnTest3_jaloe3.Background = _primerColer;
                        btnTest3_Medic.Background = _primerColer;
                        btnTest3_jaloe4.Background = Brushes.GreenYellow;



                        break;
                    case "Medic":
                        btnTest3_Samoe.Background = _primerColer;
                        btnTest3_jaloe3.Background = _primerColer;
                        btnTest3_Medic.Background = Brushes.GreenYellow;

                        btnTest3_jaloe4.Background = _primerColer;
      
                        break;

                    default:
                        btnTest3_Samoe.Background = _primerColer;
                        btnTest3_jaloe3.Background = _primerColer;
                        btnTest3_Medic.Background = _primerColer;

                        btnTest3_jaloe4.Background = _primerColer;
                        break;


                }
            }
        }

        void _checkTest2Input()
        {
            if (_wingType != null)
            {
                switch (_wingType.TEST2)
                {
                    case "A":
                        btnTest2_A.Background = Brushes.GreenYellow;
                        btnTest2_F.Background = _primerColer;

                        btnTest3_Samoe.IsEnabled = false;
                        btnTest3_jaloe3.IsEnabled = false;
                        btnTest3_Medic.IsEnabled = false;
                        btnTest3_jaloe4.IsEnabled = false;

                        break;
                    case "F":
                        btnTest2_A.Background = _primerColer;
                        btnTest2_F.Background = Brushes.GreenYellow;

                        btnTest3_Samoe.IsEnabled = true;
                        btnTest3_jaloe3.IsEnabled = true;
                        btnTest3_Medic.IsEnabled = true;
                        btnTest3_jaloe4.IsEnabled = true;

                        break;
                    default:
                        btnTest2_A.Background = _primerColer;
                        btnTest2_F.Background = _primerColer;

                        btnTest3_Samoe.IsEnabled = true;
                        btnTest3_jaloe3.IsEnabled = true;
                        btnTest3_Medic.IsEnabled = true;
                        btnTest3_jaloe4.IsEnabled = true;
                        break;


                }
            }
        }


        void _checkTest1Input()
        {
            if (_wingType != null)
            {
                switch (_wingType.TEST1)
                {
                    case "NOR":

                        btnTest1_Normal.Background = Brushes.GreenYellow;
                        btnTest1_Alpha.Background = _primerColer;
                        btnTest1_Pendl.Background = _primerColer;
                        btnTest1_Pivot.Background = _primerColer;
                        btnTest4_acustic80.Background = _primerColer;
                        btnTest4_acustic60.Background = _primerColer;
                        btnTest4_Flash.Background = _primerColer;
                        btnZaza.Background = _primerColer;
                        btnTest2_A.IsEnabled = true;
                        btnTest2_F.IsEnabled = true;
                        if (_wingType.TEST2 == "F")
                        {
                            btnTest3_Medic.IsEnabled = true;
                        }
                        else
                        {
                            btnTest3_Medic.IsEnabled = false;
                        }
                    
                        break;
                    case "ALPH":

                        btnTest1_Normal.Background = _primerColer;
                        btnTest1_Alpha.Background = Brushes.GreenYellow; 
                        btnTest1_Pendl.Background = _primerColer;
                        btnTest1_Pivot.Background = _primerColer;
                        btnTest4_acustic80.Background = _primerColer;
                        btnTest4_acustic60.Background = _primerColer;
                        btnTest4_Flash.Background = _primerColer;
                        btnZaza.Background = _primerColer;
                        btnTest2_A.IsEnabled = true;
                        btnTest2_F.IsEnabled = true;
                        btnTest3_Medic.IsEnabled = false;
                    

                        break;

                    case "PVT":
                        btnTest1_Normal.Background = _primerColer;
                        btnTest1_Alpha.Background = _primerColer;
                        btnTest1_Pendl.Background = _primerColer;
                        btnTest1_Pivot.Background = Brushes.GreenYellow;
                        btnTest4_acustic80.Background = _primerColer;
                        btnTest4_acustic60.Background = _primerColer;
                        btnTest4_Flash.Background = _primerColer;
                        btnZaza.Background = _primerColer;
                        btnTest2_A.IsEnabled = false;
                        btnTest2_F.IsEnabled = true;
                        btnTest3_Medic.IsEnabled = true;
                      
                        break;
                    case "PNDL":
                        btnTest1_Normal.Background = _primerColer;
                        btnTest1_Alpha.Background = _primerColer;
                        btnTest1_Pendl.Background = Brushes.GreenYellow;
                        btnTest1_Pivot.Background = _primerColer;
                        btnTest4_acustic80.Background = _primerColer;
                        btnTest4_acustic60.Background = _primerColer;
                        btnTest4_Flash.Background = _primerColer;
                        btnZaza.Background = _primerColer;
                        btnTest2_A.IsEnabled = true;
                        btnTest2_F.IsEnabled = true;
                        btnTest3_Medic.IsEnabled = true;
                
                        break;
                    case "Flash":
                        btnTest1_Normal.Background = _primerColer;
                        btnTest1_Alpha.Background = _primerColer;
                        btnTest1_Pendl.Background = _primerColer;
                        btnTest1_Pivot.Background = _primerColer;
                        btnTest4_acustic80.Background = _primerColer;
                        btnTest4_acustic60.Background = _primerColer;
                        btnTest4_Flash.Background = Brushes.GreenYellow;
                        btnZaza.Background = _primerColer;
                        btnTest2_A.IsEnabled = true;
                        btnTest2_F.IsEnabled = true;
                        btnTest3_Medic.IsEnabled = false;
                        break;
                    case "AQ60":
                        btnTest1_Normal.Background = _primerColer;
                        btnTest1_Alpha.Background = _primerColer;
                        btnTest1_Pendl.Background = _primerColer;
                        btnTest1_Pivot.Background = _primerColer;
                        btnTest4_acustic80.Background = _primerColer;
                        btnTest4_acustic60.Background = Brushes.GreenYellow;
                        btnTest4_Flash.Background = _primerColer;
                        btnZaza.Background = _primerColer;
                        btnTest2_A.IsEnabled = true;
                        btnTest2_F.IsEnabled = true;
                        btnTest3_Medic.IsEnabled = false;
                        break;
                    case "AQ80":
                        btnTest1_Normal.Background = _primerColer;
                        btnTest1_Alpha.Background = _primerColer;
                        btnTest1_Pendl.Background = _primerColer;
                        btnTest1_Pivot.Background = _primerColer;
                        btnTest4_acustic80.Background = Brushes.GreenYellow;
                        btnTest4_acustic60.Background = _primerColer;
                        btnTest4_Flash.Background = _primerColer;
                        btnZaza.Background = _primerColer;
                        btnTest2_A.IsEnabled = true;
                        btnTest2_F.IsEnabled = true;
                        btnTest3_Medic.IsEnabled = false;
                        break;
                    case "ZAZA":
                        btnTest1_Normal.Background = _primerColer;
                        btnTest1_Alpha.Background = _primerColer;
                        btnTest1_Pendl.Background = _primerColer;
                        btnTest1_Pivot.Background = _primerColer;
                        btnTest4_acustic80.Background = _primerColer;
                        btnTest4_acustic60.Background = _primerColer;
                        btnTest4_Flash.Background = _primerColer;
                        btnZaza.Background = Brushes.GreenYellow;
                        btnTest2_A.IsEnabled = true;
                        btnTest2_F.IsEnabled = true;
                        btnTest3_Medic.IsEnabled = false;
                        break;
                    default:
                        btnTest1_Normal.Background = _primerColer;
                        btnTest1_Alpha.Background = _primerColer;
                        btnTest1_Pendl.Background = _primerColer;
                        btnTest1_Pivot.Background = _primerColer;
                        btnTest4_acustic80.Background = _primerColer;
                        btnTest4_acustic60.Background = _primerColer;
                        btnTest4_Flash.Background = _primerColer;
                        btnZaza.Background = _primerColer;
                        btnTest2_A.IsEnabled = true;
                        btnTest2_F.IsEnabled = true;
                        btnTest3_Medic.IsEnabled = true;
                        break;

                }


            }
        }


        private void btnSaveDB(object sender, RoutedEventArgs e)
        {
            if (_wingType == null)
            {
                return;
            }
                Button btncheck = sender  as Button;
     
            switch (btncheck.Name)
            {
                case "btnTest1_Normal":
                    _wingType.TEST1 = "NOR";
                    _wingType.TEST2 = "";
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    break;   
                case "btnTest1_Alpha":
                    _wingType.TEST1 = "ALPH";
                    _wingType.TEST2 = "";
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    break; 
                case "btnTest1_Pivot":
                    _wingType.TEST1 = "PVT";
                    _wingType.TEST2 = "";
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    break;  
                case "btnTest1_Pendl":
                    _wingType.TEST1 = "PNDL";
                    _wingType.TEST2 = "";
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    break;
                case "btnTest4_Flash":
                    _wingType.TEST1 = "Flash";
                    _wingType.TEST2 = "";
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    break;
                case "btnTest4_acustic60":
                    _wingType.TEST1 = "AQ60";
                    _wingType.TEST2 = "";
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    break;
                case "btnTest4_acustic80":
                    _wingType.TEST1 = "AQ80";
                    _wingType.TEST2 = "";
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    break; 
                
                case "btnZaza":
                    _wingType.TEST1 = "ZAZA";
                    _wingType.TEST2 = "";
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    break;
                case "btnTest2_F":
                    _wingType.TEST2 = "F";
                  
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    break;  
                case "btnTest2_A":
                    _wingType.TEST2 = "A";
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    break;  
                
                case "btnTest3_Samoe":
                    _wingType.TEST3 = "0";
                   
                    _wingType.TEST4 = "";
                    break;                      
                case "btnTest3_jaloe3":
                    _wingType.TEST3 = "3";
                    _wingType.TEST4 = "";
                    break;                                      
                case "btnTest3_Medic":
                    _wingType.TEST3 = "Medic";
                    _wingType.TEST4 = "";
                    break;
                case "btnTest3_jaloe4":
                    _wingType.TEST3 = "4";
                    _wingType.TEST4 = "";
                    break;

       
                default:
                    _wingType.TEST1 = "";
                    _wingType.TEST2 = "";
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    break;
                        

            }

            if (_wingType.Save())
            {
                UPDATEUI(); 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                _wingTypeTemp = clsWingType.FindByWingID(_wingID);
                btnback.Visibility = Visibility.Visible;
            if (_wingType != null && _wingTypeTemp != null)
            {
                if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

                {
                    _wingType.TEST1 = "";
                    _wingType.TEST2 = "";
                    _wingType.TEST3 = "";
                    _wingType.TEST4 = "";
                    NameType.Content = "";
                    if (_wingType.Save())
                    {
                        UPDATEUI();
                     
                    }




                    _wingType.Clear();
                    _wingType.Save();


                    btnTest1_Normal.Background = _primerColer;
                    btnTest1_Alpha.Background = _primerColer;
                    btnTest1_Pendl.Background = _primerColer;
                    btnTest1_Pivot.Background = _primerColer;

                    btnTest2_A.IsEnabled = true;
                    btnTest2_F.IsEnabled = true;
                    btnTest2_A.Background = _primerColer;
                    btnTest2_F.Background = _primerColer;





                    btnTest3_Samoe.IsEnabled = true;
                    btnTest3_jaloe3.IsEnabled = true;
                    btnTest3_Medic.IsEnabled = true;
                    btnTest3_jaloe4.IsEnabled = true;
                    btnTest3_Samoe.Background = _primerColer;
                    btnTest3_jaloe3.Background = _primerColer;
                    btnTest3_Medic.Background = _primerColer;
                    btnTest3_jaloe4.Background = _primerColer;

                    btnTest4_Flash.IsEnabled = true;
                    btnTest4_acustic60.IsEnabled = true;
                    btnTest4_acustic80.IsEnabled = true;
                    btnTest4_Flash.Background = _primerColer;
                    btnTest4_acustic60.Background = _primerColer;
                    btnTest4_acustic80.Background = _primerColer;

                }
            }
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

            {
                if (_wingType != null && _wingTypeTemp != null)
                {
                    _wingType = _wingTypeTemp;
                    if (_wingType.Save())
                    {
                        UPDATEUI();
                        btnback.Visibility = Visibility.Hidden;
                      
                    }
                }
            }
            }
    }
}
