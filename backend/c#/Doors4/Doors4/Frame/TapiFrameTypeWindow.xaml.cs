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
using System.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace Door3
{
    /// <summary>
    /// Interaction logic for TapiFrameTypeWindow.xaml
    /// </summary>

    public partial class TapiFrameTypeWindow : Window
    {
        //public delegate void BackDataEvent(int IDframeType);

        //public event BackDataEvent BackData;


       

        public static string Test1 = "";
        public static string Test2 = "";
        public static string Test3 = "";
        public static string Test4 = "";

        public static string Test5 = Test1 + Test2 + Test3 + Test4;
        clsFrameType _frameType;
        clsFrameType _frameTypeTemp;

        int IdFrame;
        public TapiFrameTypeWindow(int idFrame)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);

            IdFrame = idFrame;
            if (clsFrameType.FindByFrameID(idFrame) == null)
            {
               
                _frameType = new clsFrameType();
                _frameType.FrameID = idFrame;
                _frameType.Save();

            }
            else
            {
                _frameType = clsFrameType.FindByFrameID(idFrame);
                
            }






        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void ResetFrameType(object sender, RoutedEventArgs e)
        {
            _frameTypeTemp = clsFrameType.FindByFrameID(IdFrame);

            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (_frameType != null)
                {
                    _frameType.clear();
                    _frameType.Save();
                    _loadData();
                    btnbackdata.Visibility = Visibility.Visible;
                }

            }
                Test1 = "";
            Test2 = "";
            Test3 = "";
            Test4 = "";
            rbFrameTypeStandart.IsEnabled = false;
            rbFrameTypeMeshtaliv.IsEnabled = false;
            rbFrameTypehalbsha.IsEnabled = false;
            rbFrameTypeKlik.IsEnabled = false;
            rbFrameTypeKantTiach.IsEnabled = false;
            rbFrameTypeArusi.IsEnabled = false;
            rbLevelTypeF1.IsEnabled = false;
            rbLevelTypeF2.IsEnabled = false;
            rbLevelTypeAQ60.IsEnabled = false;
            rbLevelTypeAQ80.IsEnabled = false;
            rbWallTypeBT1.IsEnabled = false;
            rbWallTypeGV1.IsEnabled = false;

            rbAgroupOfDoorFramesNormal.IsChecked = false;
            rbAgroupOfDoorFramesAlpha.IsChecked = false;
            rbAgroupOfDoorFramesPivot.IsChecked = false;
            rbAgroupOfDoorFramesAveer.IsChecked = false;
            rbAgroupOfDoorFramesZaza.IsChecked = false;
            rbAgroupOfDoorFramesBindl.IsChecked = false;
            rbAgroupOfDoorFramesPoketZaza.IsChecked = false;

            rbFrameTypeStandart.IsChecked = false;
            rbFrameTypeArusi.IsChecked = false;
            rbFrameTypehalbsha.IsChecked = false;
            rbFrameTypeKantTiach.IsChecked = false;
            rbFrameTypeKlik.IsChecked = false;
            rbFrameTypeMeshtaliv.IsChecked = false;

            rbLevelTypeF2.IsChecked = false;
            rbLevelTypeF1.IsChecked = false;
            rbLevelTypeAQ60.IsChecked = false;
            rbLevelTypeAQ80.IsChecked = false;

            rbWallTypeBT1.IsChecked = false;
            rbWallTypeGV1.IsChecked = false;

            _frameType.AgroupOfDoorFrames = ""; //test 1
            _frameType.WallType = ""; //test4
            _frameType.LevelType = ""; //test 3
            _frameType.TypeOfDoorFrame = ""; //test 2
            _frameType.Save();
            _loadData();


        }

        private void LoadedWindow(object sender, RoutedEventArgs e)
        {
            _loadData();
            if (_frameType.AgroupOfDoorFrames == "")
            {
                Test1 = "";
                Test2 = "";
                Test3 = "";
                Test4 = "";
                rbFrameTypeStandart.IsEnabled = false;
                rbFrameTypeMeshtaliv.IsEnabled = false;
                rbFrameTypehalbsha.IsEnabled = false;
                rbFrameTypeKlik.IsEnabled = false;
                rbFrameTypeKantTiach.IsEnabled = false;
                rbFrameTypeArusi.IsEnabled = false;
                rbLevelTypeF1.IsEnabled = false;
                rbLevelTypeF2.IsEnabled = false;
                rbLevelTypeAQ60.IsEnabled = false;
                rbLevelTypeAQ80.IsEnabled = false;
                rbWallTypeBT1.IsEnabled = false;
                rbWallTypeGV1.IsEnabled = false;

                rbAgroupOfDoorFramesNormal.IsChecked = false;
                rbAgroupOfDoorFramesAlpha.IsChecked = false;
                rbAgroupOfDoorFramesPivot.IsChecked = false;
                rbAgroupOfDoorFramesAveer.IsChecked = false;
                rbAgroupOfDoorFramesZaza.IsChecked = false;
                rbAgroupOfDoorFramesBindl.IsChecked = false;
                rbAgroupOfDoorFramesPoketZaza.IsChecked = false;

                rbFrameTypeStandart.IsChecked = false;
                rbFrameTypeArusi.IsChecked = false;
                rbFrameTypehalbsha.IsChecked = false;
                rbFrameTypeKantTiach.IsChecked = false;
                rbFrameTypeKlik.IsChecked = false;
                rbFrameTypeMeshtaliv.IsChecked = false;

                rbLevelTypeF2.IsChecked = false;
                rbLevelTypeF1.IsChecked = false;
                rbLevelTypeAQ60.IsChecked = false;
                rbLevelTypeAQ80.IsChecked = false;

                rbWallTypeBT1.IsChecked = false;
                rbWallTypeGV1.IsChecked = false;

                _frameType.AgroupOfDoorFrames = ""; //test 1
                _frameType.WallType = ""; //test4
                _frameType.LevelType = ""; //test 3
                _frameType.TypeOfDoorFrame = ""; //test 2
                _frameType.Save();
                _loadData();


            }
        }
        void _loadData()
        {
            _loadDataAgroupOfDoorFrames(); //test1 db   
            _LoadDatarbFrameType(); ////test2 db  
            _LoadDataLevelType();////test3 db  
            _loadDataWallType();////test4 db  

            Test5 = _frameType.AgroupOfDoorFrames + _frameType.TypeOfDoorFrame + _frameType.LevelType + _frameType.WallType;
            FrameTypeNameText4.Content = Test5;
        }
        void _loadDataAgroupOfDoorFrames()
        {
            if (_frameType != null)
            {
                if (_frameType.AgroupOfDoorFrames == "Regular")
                {
                    rbAgroupOfDoorFramesNormal.IsChecked = false;
                    rbAgroupOfDoorFramesNormal.FontWeight = FontWeights.Bold;
                    rbAgroupOfDoorFramesNormal.Background = Brushes.GreenYellow;
                }
                else
                {
             
                    rbAgroupOfDoorFramesNormal.FontWeight = FontWeights.Normal;
                    rbAgroupOfDoorFramesNormal.Background = (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }

                if (_frameType.AgroupOfDoorFrames == "Alpha")
                {
                    rbAgroupOfDoorFramesAlpha.IsChecked = false;
                    rbAgroupOfDoorFramesAlpha.FontWeight = FontWeights.Bold;
                    rbAgroupOfDoorFramesAlpha.Background = Brushes.GreenYellow;
                    rbFrameTypeMeshtaliv.IsEnabled = false;
                    rbFrameTypeArusi.IsEnabled = false;
                }
                else
                {
                    rbAgroupOfDoorFramesAlpha.FontWeight = FontWeights.Normal;
                    rbAgroupOfDoorFramesAlpha.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }

                if (_frameType.AgroupOfDoorFrames == "Pivot")
                {
                    rbAgroupOfDoorFramesPivot.IsChecked = false;
                    rbAgroupOfDoorFramesPivot.FontWeight = FontWeights.Bold;
                    rbAgroupOfDoorFramesPivot.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbAgroupOfDoorFramesPivot.FontWeight = FontWeights.Normal;
                    rbAgroupOfDoorFramesPivot.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }

                if (_frameType.AgroupOfDoorFrames == "Blind")
                {
                    rbAgroupOfDoorFramesAveer.IsChecked = false;
                    rbAgroupOfDoorFramesAveer.FontWeight = FontWeights.Bold;
                    rbAgroupOfDoorFramesAveer.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbAgroupOfDoorFramesAveer.FontWeight = FontWeights.Normal;
                    rbAgroupOfDoorFramesAveer.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }

                if (_frameType.AgroupOfDoorFrames == "Sliding")
                {
                    rbAgroupOfDoorFramesZaza.IsChecked = false;
                    rbAgroupOfDoorFramesZaza.FontWeight = FontWeights.Bold;
                    rbAgroupOfDoorFramesZaza.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbAgroupOfDoorFramesZaza.FontWeight = FontWeights.Normal;
                    rbAgroupOfDoorFramesZaza.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }
                if (_frameType.AgroupOfDoorFrames == "Pendel")
                {
                    rbAgroupOfDoorFramesBindl.IsChecked = false;
                    rbAgroupOfDoorFramesBindl.FontWeight = FontWeights.Bold;
                    rbAgroupOfDoorFramesBindl.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbAgroupOfDoorFramesBindl.FontWeight = FontWeights.Normal;
                    rbAgroupOfDoorFramesBindl.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }

                if (_frameType.AgroupOfDoorFrames == "SlidingPocket")
                {
                    rbAgroupOfDoorFramesPoketZaza.IsChecked = false;
                    rbAgroupOfDoorFramesPoketZaza.FontWeight = FontWeights.Bold;
                    rbAgroupOfDoorFramesPoketZaza.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbAgroupOfDoorFramesPoketZaza.FontWeight = FontWeights.Normal;
                    rbAgroupOfDoorFramesPoketZaza.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }

            }
        }

        private void rbAgroupOfDoorFramesNormal_Checked(object sender, RoutedEventArgs e)
        {
            
            Test2 = "";
            Test3 = "";
            Test4 = "";
            Test1 = "Regular";

            _frameType.TypeOfDoorFrame = "";
            _frameType.WallType = "";
            _frameType.LevelType = "";

            _frameType.AgroupOfDoorFrames = "Regular";

         

            _frameType.Save();
            _loadData();

            rbFrameTypeStandart.IsEnabled = true;
            rbFrameTypeMeshtaliv.IsEnabled = true;
            rbFrameTypehalbsha.IsEnabled = true;
            rbFrameTypeKlik.IsEnabled = true;
            rbFrameTypeKantTiach.IsEnabled = true;
            rbFrameTypeArusi.IsEnabled = true;
            rbLevelTypeF1.IsEnabled = true;
            rbLevelTypeF2.IsEnabled = true;
            rbLevelTypeAQ60.IsEnabled = true;
            rbLevelTypeAQ80.IsEnabled = true;
            rbWallTypeBT1.IsEnabled = true;
            rbWallTypeGV1.IsEnabled = true;

           


        }

        private void rbAgroupOfDoorFramesAlpha_Checked(object sender, RoutedEventArgs e)
        {
           
            Test2 = "";
            Test3 = "";
            Test4 = "";
            Test1 = "Alpha";
            _frameType.TypeOfDoorFrame = "";
            _frameType.WallType = "";
            _frameType.LevelType = "";
            _frameType.AgroupOfDoorFrames = "Alpha";
            _frameType.Save();
            _loadData();


            rbFrameTypeMeshtaliv.IsEnabled = false;
            rbFrameTypeArusi.IsEnabled = false;
            rbFrameTypeStandart.IsEnabled = true;
            rbFrameTypehalbsha.IsEnabled = true;
            rbFrameTypeKantTiach.IsEnabled = true;
            rbLevelTypeF1.IsEnabled = true;
            rbLevelTypeF2.IsEnabled = true;
            rbLevelTypeAQ60.IsEnabled = true;
            rbLevelTypeAQ80.IsEnabled = true;
            rbFrameTypeKlik.IsEnabled = true;


        }

        private void rbAgroupOfDoorFramesPivot_Checked(object sender, RoutedEventArgs e)
        {
          
            Test2 = "";
            Test3 = "";
            Test4 = "";
            Test1 = "Pivot";
            _frameType.TypeOfDoorFrame = "";
            _frameType.WallType = "";
            _frameType.LevelType = "";
            _frameType.AgroupOfDoorFrames = "Pivot";
            _frameType.Save();
            _loadData();


            rbFrameTypeMeshtaliv.IsEnabled = false;
            rbFrameTypehalbsha.IsEnabled = false;
            rbLevelTypeF1.IsEnabled = false;
            rbLevelTypeF2.IsEnabled = false;
            rbLevelTypeAQ60.IsEnabled = false;
            rbLevelTypeAQ80.IsEnabled = false;
            rbFrameTypeStandart.IsEnabled = true;
            rbFrameTypeKlik.IsEnabled = true;
            rbFrameTypeKantTiach.IsEnabled = true;
            rbWallTypeBT1.IsEnabled = true;
            rbWallTypeGV1.IsEnabled = true;
        }

        private void rbAgroupOfDoorFramesAveer_Checked(object sender, RoutedEventArgs e)
        {
            
            Test2 = "";
            Test3 = "";
            Test4 = "";
            Test1 = "Blind";
            _frameType.TypeOfDoorFrame = "";
            _frameType.WallType = "";
            _frameType.LevelType = "";
            _frameType.AgroupOfDoorFrames = "Blind";
            _frameType.Save();
            _loadData();


            rbFrameTypeMeshtaliv.IsEnabled = false;
            rbFrameTypehalbsha.IsEnabled = true;
            rbLevelTypeF1.IsEnabled = false;
            rbLevelTypeF2.IsEnabled = false;
            rbLevelTypeAQ60.IsEnabled = false;
            rbLevelTypeAQ80.IsEnabled = false;
            rbFrameTypeStandart.IsEnabled = true;
            rbFrameTypeKlik.IsEnabled = true;
            rbFrameTypeKantTiach.IsEnabled = false;
            rbWallTypeBT1.IsEnabled = true;
            rbWallTypeGV1.IsEnabled = true;
            rbFrameTypeArusi.IsEnabled = false;





        }

        private void rbAgroupOfDoorFramesZaza_Checked(object sender, RoutedEventArgs e)
        {
           
            Test2 = "";
            Test3 = "";
            Test4 = "";
            Test1 = "Sliding";
            _frameType.TypeOfDoorFrame = "";
            _frameType.WallType = "";
            _frameType.LevelType = "";
            _frameType.AgroupOfDoorFrames = "Sliding";
            _frameType.Save();
            _loadData();

            rbFrameTypeMeshtaliv.IsEnabled = false;
            rbFrameTypehalbsha.IsEnabled = false;
            rbLevelTypeF1.IsEnabled = false;
            rbLevelTypeF2.IsEnabled = false;
            rbLevelTypeAQ60.IsEnabled = false;
            rbLevelTypeAQ80.IsEnabled = false;
            rbFrameTypeStandart.IsEnabled = false;
            rbFrameTypeKlik.IsEnabled = false;
            rbFrameTypeKantTiach.IsEnabled = false;
            rbWallTypeBT1.IsEnabled = true;
            rbWallTypeGV1.IsEnabled = true;
            rbFrameTypeArusi.IsEnabled = false;
        }

        private void rbAgroupOfDoorFramesBindl_Checked(object sender, RoutedEventArgs e)
        {
            Test2 = "";
            Test3 = "";
            Test4 = "";
            Test1 = "Pendel";
            _frameType.TypeOfDoorFrame = "";
            _frameType.WallType = "";
            _frameType.LevelType = "";
            _frameType.AgroupOfDoorFrames = "Pendel";
            _frameType.Save();
            _loadData();

            rbFrameTypeMeshtaliv.IsEnabled = false;
            rbFrameTypehalbsha.IsEnabled = false;
            rbLevelTypeF1.IsEnabled = false;
            rbLevelTypeF2.IsEnabled = false;
            rbLevelTypeAQ60.IsEnabled = false;
            rbLevelTypeAQ80.IsEnabled = false;
            rbFrameTypeStandart.IsEnabled = true;
            rbFrameTypeKlik.IsEnabled = true;
            rbFrameTypeKantTiach.IsEnabled = true;
            rbWallTypeBT1.IsEnabled = true;
            rbWallTypeGV1.IsEnabled = true;
            rbFrameTypeArusi.IsEnabled = false;



        }

        private void rbAgroupOfDoorFramesPoketZaza_Checked(object sender, RoutedEventArgs e)
        {
            
            Test2 = "";
            Test3 = "";
            Test4 = "";
            Test1 = "SlidingPocket";
            _frameType.TypeOfDoorFrame = "";
            _frameType.WallType = "";
            _frameType.LevelType = "";
            _frameType.AgroupOfDoorFrames = "SlidingPocket";
            _frameType.Save();
            _loadData();


            rbFrameTypeMeshtaliv.IsEnabled = false;
            rbFrameTypehalbsha.IsEnabled = false;
            rbLevelTypeF1.IsEnabled = false;
            rbLevelTypeF2.IsEnabled = false;
            rbLevelTypeAQ60.IsEnabled = false;
            rbLevelTypeAQ80.IsEnabled = false;
            rbFrameTypeStandart.IsEnabled = false;
            rbFrameTypeKlik.IsEnabled = false;
            rbFrameTypeKantTiach.IsEnabled = false;
            rbWallTypeBT1.IsEnabled = true;
            rbWallTypeGV1.IsEnabled = true;
            rbFrameTypeArusi.IsEnabled = false;
        }

        void _LoadDatarbFrameType()
        {

            if (_frameType != null)
            {
                if (_frameType.TypeOfDoorFrame == "Standart")
                {
                    rbFrameTypeStandart.IsChecked = false;
                    rbFrameTypeStandart.FontWeight = FontWeights.Bold;
                    rbFrameTypeStandart.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbFrameTypeStandart.FontWeight = FontWeights.Normal;
                    rbFrameTypeStandart.Background = (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF"));
                }
                if (_frameType.TypeOfDoorFrame == "Mishtalev")
                {
                    rbFrameTypeMeshtaliv.IsChecked = false;
                    rbFrameTypeMeshtaliv.FontWeight = FontWeights.Bold;
                    rbFrameTypeMeshtaliv.Background = Brushes.GreenYellow;
                    rbWallTypeBT1.IsEnabled = false;
                    rbWallTypeGV1.IsEnabled = false;
                    rbLevelTypeAQ60.IsEnabled = false;
                    rbLevelTypeAQ80.IsEnabled = false;
                    rbLevelTypeF1.IsEnabled = false;
                    rbLevelTypeF2.IsEnabled = false;
                }
                else
                {
                    rbFrameTypeMeshtaliv.FontWeight = FontWeights.Normal;
                    rbFrameTypeMeshtaliv.Background = (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF"));
                }

                if (_frameType.TypeOfDoorFrame == "Halbasha")
                {
                    rbFrameTypehalbsha.IsChecked = false;
                    rbFrameTypehalbsha.FontWeight = FontWeights.Bold;
                    rbFrameTypehalbsha.Background = Brushes.GreenYellow;
                    rbWallTypeBT1.IsEnabled = false;
                    rbWallTypeGV1.IsEnabled = false;
                    rbLevelTypeAQ60.IsEnabled = false;
                    rbLevelTypeAQ80.IsEnabled = false;
                    rbLevelTypeF1.IsEnabled = false;
                    rbLevelTypeF2.IsEnabled = false;
                }
                else
                {
                    rbFrameTypehalbsha.FontWeight = FontWeights.Normal;
                    rbFrameTypehalbsha.Background = (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF"));
                }

                if (_frameType.TypeOfDoorFrame == "Click")
                {
                    rbFrameTypeKlik.IsChecked = false;
                    rbFrameTypeKlik.FontWeight = FontWeights.Bold;
                    rbFrameTypeKlik.Background = Brushes.GreenYellow;
                    rbWallTypeBT1.IsEnabled = false;
                    rbWallTypeGV1.IsEnabled = false;
                    rbLevelTypeAQ60.IsEnabled = false;
                    rbLevelTypeAQ80.IsEnabled = false;
                    rbLevelTypeF1.IsEnabled = false;
                    rbLevelTypeF2.IsEnabled = false;
                }
                else
                {
                    rbFrameTypeKlik.FontWeight = FontWeights.Normal;
                    rbFrameTypeKlik.Background = (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF"));
                }

                if (_frameType.TypeOfDoorFrame == "KantTiach")
                {
                    rbFrameTypeKantTiach.IsChecked = false;
                    rbFrameTypeKantTiach.FontWeight = FontWeights.Bold;
                    rbFrameTypeKantTiach.Background = Brushes.GreenYellow;
                    rbWallTypeBT1.IsEnabled = true;
                    rbWallTypeGV1.IsEnabled = true;

                    if (Test1 == "Regular" || _frameType.AgroupOfDoorFrames == "Regular"
                                || Test1 == "Alpha" || _frameType.AgroupOfDoorFrames == "Alpha"


                        
                        
                        
                        
                        )
            {
                rbLevelTypeF1.IsEnabled = true;
                rbLevelTypeF2.IsEnabled = true;
                rbLevelTypeAQ60.IsEnabled = true;
                rbLevelTypeAQ80.IsEnabled = true;
            }
                }
                else
                {
                    rbFrameTypeKantTiach.FontWeight = FontWeights.Normal;
                    rbFrameTypeKantTiach.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }

                if (_frameType.TypeOfDoorFrame == "Arusi")
                {
                    rbFrameTypeArusi.IsChecked = false;
                    rbFrameTypeArusi.FontWeight = FontWeights.Bold;
                    rbFrameTypeArusi.Background = Brushes.GreenYellow;

                    rbWallTypeBT1.IsEnabled = false;
                    rbWallTypeGV1.IsEnabled = false;
                    rbLevelTypeAQ60.IsEnabled = false;
                    rbLevelTypeAQ80.IsEnabled = false;
                    rbLevelTypeF1.IsEnabled = false;
                    rbLevelTypeF2.IsEnabled = false;
                }
                else
                {
                    rbFrameTypeArusi.FontWeight = FontWeights.Normal;
                    rbFrameTypeArusi.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }

            }
        }

        private void rbFrameTypeStandart_Checked(object sender, RoutedEventArgs e)
        {
            Test2 = "Standart";
            _frameType.TypeOfDoorFrame = "Standart";
            _frameType.Save();
            _loadData();

            rbWallTypeBT1.IsEnabled = true;
            rbWallTypeGV1.IsEnabled = true;

            if (Test1 == "Regular" || _frameType.AgroupOfDoorFrames == "Regular" ||
            Test1 == "Alpha" || _frameType.AgroupOfDoorFrames == "Alpha"


                )
            {
                rbLevelTypeF1.IsEnabled = true;
                rbLevelTypeF2.IsEnabled = true;
                rbLevelTypeAQ60.IsEnabled = true;
                rbLevelTypeAQ80.IsEnabled = true;
            }

        }

        private void rbFrameTypeMeshtaliv_Checked(object sender, RoutedEventArgs e)
        {


            Test2 = "Mishtalev";


            _frameType.TypeOfDoorFrame = "Mishtalev";
            _frameType.WallType = "";
            _frameType.LevelType = "";
            _frameType.Save();
            _loadData();

            rbWallTypeBT1.IsEnabled = false;
            rbWallTypeGV1.IsEnabled = false;
            rbLevelTypeAQ60.IsEnabled = false;
            rbLevelTypeAQ80.IsEnabled = false;
            rbLevelTypeF1.IsEnabled = false;
            rbLevelTypeF2.IsEnabled = false;
        }

        private void rbFrameTypehalbsha_Checked(object sender, RoutedEventArgs e)
        {
            Test2 = "Halbasha";
            _frameType.TypeOfDoorFrame = "Halbasha";
            _frameType.WallType = "";
            _frameType.LevelType = "";
            _frameType.Save();
            _loadData();

            rbWallTypeBT1.IsEnabled = false;
            rbWallTypeGV1.IsEnabled = false;
            rbLevelTypeAQ60.IsEnabled = false;
            rbLevelTypeAQ80.IsEnabled = false;
            rbLevelTypeF1.IsEnabled = false;
            rbLevelTypeF2.IsEnabled = false;
        }

        private void rbFrameTypeKlik_Checked(object sender, RoutedEventArgs e)
        {
            Test2 = "Click";
            _frameType.WallType = "";
            _frameType.LevelType = "";
            _frameType.TypeOfDoorFrame = "Click";
            _frameType.Save();
            _loadData();


            rbWallTypeBT1.IsEnabled = false;
            rbWallTypeGV1.IsEnabled = false;
            rbLevelTypeAQ60.IsEnabled = false;
            rbLevelTypeAQ80.IsEnabled = false;
            rbLevelTypeF1.IsEnabled = false;
            rbLevelTypeF2.IsEnabled = false;
        }

        private void rbFrameTypeKantTiach_Checked(object sender, RoutedEventArgs e)
        {
            Test2 = "KantTiach";
            _frameType.TypeOfDoorFrame = "KantTiach";
            _frameType.Save();
            _loadData();

            rbWallTypeBT1.IsEnabled = true;
            rbWallTypeGV1.IsEnabled = true;

            if (Test1 == "Regular" || _frameType.AgroupOfDoorFrames == "Regular")
            {
                rbLevelTypeF1.IsEnabled = true;
                rbLevelTypeF2.IsEnabled = true;
                rbLevelTypeAQ60.IsEnabled = true;
                rbLevelTypeAQ80.IsEnabled = true;
            }

        }

        private void rbFrameTypeArusi_Checked(object sender, RoutedEventArgs e)
        {
            Test2 = "Arusi";
            _frameType.WallType = "";
            _frameType.LevelType = "";
            _frameType.TypeOfDoorFrame = "Arusi";
            _frameType.Save();
            _loadData();

            rbWallTypeBT1.IsEnabled = false;
            rbWallTypeGV1.IsEnabled = false;
            rbLevelTypeAQ60.IsEnabled = false;
            rbLevelTypeAQ80.IsEnabled = false;
            rbLevelTypeF1.IsEnabled = false;
            rbLevelTypeF2.IsEnabled = false;
        }

        private void btF1_Checked(object sender, RoutedEventArgs e)
        {
            Test3 = "F1";
            _frameType.LevelType = "F1";
            _frameType.Save();
            _loadData();

        }

        private void btF2_Checked(object sender, RoutedEventArgs e)
        {
            Test3 = "F2";


            _frameType.LevelType = "F2";
            _frameType.Save();
            _loadData();


        }

        private void btAQ1_Checked(object sender, RoutedEventArgs e)
        {
            Test3 = "AQ60";
            _frameType.LevelType = "AQ60";
            _frameType.Save();
            _loadData();
        }

        private void btAQ80_Checked(object sender, RoutedEventArgs e)
        {
            Test3 = "AQ80";
            _frameType.LevelType = "AQ80";
            _frameType.Save();
            _loadData();


        }

        void _LoadDataLevelType()
        {
            if (_frameType != null)
            {
                if (_frameType.LevelType == "F1")
                {
                    rbLevelTypeF1.IsChecked = false;
                    rbLevelTypeF1.FontWeight = FontWeights.Bold;
                    rbLevelTypeF1.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbLevelTypeF1.FontWeight = FontWeights.Normal;
                    rbLevelTypeF1.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }

                if (_frameType.LevelType == "F2")
                {
                    rbLevelTypeF2.IsChecked = false;
                    rbLevelTypeF2.FontWeight = FontWeights.Bold;
                    rbLevelTypeF2.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbLevelTypeF2.FontWeight = FontWeights.Normal;
                    rbLevelTypeF2.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }
                if (_frameType.LevelType == "AQ60")
                {
                    rbLevelTypeAQ60.IsChecked = false;
                    rbLevelTypeAQ60.FontWeight = FontWeights.Bold;
                    rbLevelTypeAQ60.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbLevelTypeAQ60.FontWeight = FontWeights.Normal;
                    rbLevelTypeAQ60.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }
                if (_frameType.LevelType == "AQ80")
                {
                    rbLevelTypeAQ80.IsChecked = false;
                    rbLevelTypeAQ80.FontWeight = FontWeights.Bold;
                    rbLevelTypeAQ80.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbLevelTypeAQ80.FontWeight = FontWeights.Normal;
                    rbLevelTypeAQ80.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }
            }
        }

        void _loadDataWallType()
        {
            if (_frameType != null)
            {
                if (_frameType.WallType == "BT")
                {
                    rbWallTypeBT1.IsChecked = false;
                    rbWallTypeBT1.FontWeight = FontWeights.Bold;
                    rbWallTypeBT1.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbWallTypeBT1.FontWeight = FontWeights.Normal;
                    rbWallTypeBT1.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }
                if (_frameType.WallType == "GV")
                {
                    rbWallTypeGV1.IsChecked = false;
                    rbWallTypeGV1.FontWeight = FontWeights.Bold;
                    rbWallTypeGV1.Background = Brushes.GreenYellow;
                }
                else
                {
                    rbWallTypeGV1.FontWeight = FontWeights.Normal;
                    rbWallTypeGV1.Background =  (Brush)(new BrushConverter().ConvertFrom("#FF76EFFF")); 
                }
            }
        }

        private void rbWallTypeBT1_Checked(object sender, RoutedEventArgs e)
        {
            Test4 = "BT";

            _frameType.WallType = "BT";
            _frameType.Save();
            _loadData();
        }

        private void rbWallTypeGV1_Checked(object sender, RoutedEventArgs e)
        {
            Test4 = "GV";

            _frameType.WallType = "GV";
            _frameType.Save();
            _loadData();
        }

        private void btnbackdata_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            { 
            
                if(_frameTypeTemp != null)
                {
                    _frameType = _frameTypeTemp;
                    _frameType.Save();
                    _loadData();
                    btnbackdata.Visibility = Visibility.Hidden;
                }
            
            }
            }
    }
}
