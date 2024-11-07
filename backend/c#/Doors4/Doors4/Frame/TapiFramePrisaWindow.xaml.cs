using SharaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for TapiFramePrisaWindow.xaml
    /// </summary>
    public partial class TapiFramePrisaWindow : Window
    {
        enum Mode { add=1,update=2};
        Mode _mode = Mode.add;
        int PrisID;
        int FrameID;
        BitmapImage imagprisa;
        clsPrisa _pris;
        clsPrisa _prisTemp;
        string _FrameName;
        clsFrameType _frameType;
        public TapiFramePrisaWindow(int prisID,int frameID, BitmapImage imgPresa,string FrameName)
        {
            InitializeComponent();

       
            _mode = Mode.update;
            PrisID = prisID;
            FrameID = frameID;
            imagprisa = imgPresa;
            _FrameName = FrameName;
            _frameType = clsFrameType.FindByFrameID(frameID);
            save();


        }

        public TapiFramePrisaWindow(int frameID, BitmapImage imgPresa,string FrameName)
        {
            InitializeComponent();

            _mode = Mode.add;
            FrameID = frameID;
            imagprisa = imgPresa;
            _FrameName = FrameName;
            _frameType = clsFrameType.FindByFrameID(frameID);
            save();

            
        }


        string convertValidationDecimal(decimal number)
        {
            return number <= 0 ? "" : number.ToString();
        }

        void filltext()
        {
       
            if (_pris != null)
            {
         
                txtA1_corner1.Text = convertValidationDecimal(_pris.corner1);
                txtA2_corner2.Text = convertValidationDecimal(_pris.corner2);
                txtB1_corner3.Text = convertValidationDecimal(_pris.corner3);
                txtB2_corner4.Text = convertValidationDecimal(_pris.corner4);
                txtC1_corner5.Text = convertValidationDecimal(_pris.corner5);
                txtC2_corner6.Text = convertValidationDecimal(_pris.corner6);
                txtD1_corner7.Text = convertValidationDecimal(_pris.corner7);
                txtD2_corner8.Text = convertValidationDecimal(_pris.corner8);
                txtE1_corner9.Text = convertValidationDecimal(_pris.corner9);
                txtE2_corner10.Text = convertValidationDecimal(_pris.corner10);
                txtF1_corner11.Text = convertValidationDecimal(_pris.corner11);
                txtF2_corner12.Text = convertValidationDecimal(_pris.corner12);
                txtG1_corner13.Text = convertValidationDecimal(_pris.corner13);
                txtG2_corner14.Text = convertValidationDecimal(_pris.corner14);
                txtF1A_corner15.Text = convertValidationDecimal(_pris.corner15);
                txtF1B_corner16.Text = convertValidationDecimal(_pris.corner16);
                txtBends.Text = convertValidationDecimal(_pris.corner17);
                txtMagnet.Text = convertValidationDecimal(_pris.magnet);

            }
        }
        void updateui()
        {
         
            filltext();

            ShowHideTextBoxesFRomType();
        }
        void _add()
        {
            _pris = new clsPrisa();
            _pris.FrameID = FrameID;

            if (_pris.Save())
            {
                PrisID = _pris.ID;
                _mode = Mode.update;
                _update();
                updateui();
            }
        }

        void _update()
        {
            _pris = clsPrisa.Find(PrisID);
         
            imagPresa.Source = imagprisa;
      
     
            updateui();
        }

        void ShowHideTextBoxesFRomType()
        {

            if (_FrameName == "BlindStandartBT" || _FrameName == "BlindStandartGV")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(51, 350, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(51, 385, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 365, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 400, 0, 0);

                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(132, 195, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(132, 230, 0, 0);

                lblB2.Visibility = Visibility.Visible;
                lblB2.Margin = new Thickness(821, 195, 0, 0);
                txtB2_corner4.Visibility = Visibility.Visible;
                txtB2_corner4.Margin = new Thickness(821, 230, 0, 0);


            }
            else if (_FrameName == "SlidingBT" || _FrameName == "SlidingGV")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(51, 350, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(51, 385, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 365, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 400, 0, 0);

                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(132, 195, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(132, 231, 0, 0);

                lblB2.Visibility = Visibility.Visible;
                lblB2.Margin = new Thickness(821, 195, 0, 0);
                txtB2_corner4.Visibility = Visibility.Visible;
                txtB2_corner4.Margin = new Thickness(821, 231, 0, 0);

            }
            else if (_FrameName == "PivotStandartBT" || _FrameName == "PivotStandartGV")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(51, 350, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(51, 385, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 365, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 400, 0, 0);


                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(132, 195, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(132, 231, 0, 0);

                lblB2.Visibility = Visibility.Visible;
                lblB2.Margin = new Thickness(821, 195, 0, 0);
                txtB2_corner4.Visibility = Visibility.Visible;
                txtB2_corner4.Margin = new Thickness(821, 231, 0, 0);

            }
            else if (_FrameName == "RegularHalbasha" || _FrameName == "AlphaHalbasha")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(51, 320, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(51, 355, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 435, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 470, 0, 0);


                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(132, 195, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(125, 235, 0, 0);

                lblF1.Visibility = Visibility.Visible;
                lblF1.Margin = new Thickness(362, 505, 0, 0);
                txtF1_corner11.Visibility = Visibility.Visible;
                txtF1_corner11.Margin = new Thickness(362, 467, 0, 0);



                lblE1.Visibility = Visibility.Visible;
                lblE1.Margin = new Thickness(820, 360, 0, 0);
                txtE1_corner9.Visibility = Visibility.Visible;
                txtE1_corner9.Margin = new Thickness(820, 395, 0, 0);

                txtMagnet.Visibility = Visibility.Visible;
                lblMagnetSave.Visibility = Visibility.Visible;

                if (_frameType != null && _frameType.AgroupOfDoorFrames == "Alpha")
                {
                    lblF1B.Visibility = Visibility.Visible;
                    txtF1B_corner16.Visibility = Visibility.Visible;
                }

            }
            else if (_FrameName == "RegularArusi")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(51, 340, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(50, 375, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 375, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 410, 0, 0);

                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(110, 255, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(110, 288, 0, 0);

                lblB2.Visibility = Visibility.Visible;
                lblB2.Margin = new Thickness(844, 255, 0, 0);
                txtB2_corner4.Visibility = Visibility.Visible;
                txtB2_corner4.Margin = new Thickness(840, 288, 0, 0);

                lblC1.Visibility = Visibility.Visible;
                lblC1.Margin = new Thickness(200, 265, 0, 0);
                txtC1_corner5.Visibility = Visibility.Visible;
                txtC1_corner5.Margin = new Thickness(200, 300, 0, 0);

                lblC2.Visibility = Visibility.Visible;
                lblC2.Margin = new Thickness(750, 265, 0, 0);
                txtC2_corner6.Visibility = Visibility.Visible;
                txtC2_corner6.Margin = new Thickness(750, 300, 0, 0);

                lblF1.Visibility = Visibility.Visible;
                lblF1.Margin = new Thickness(200, 500, 0, 0);
                txtF1_corner11.Visibility = Visibility.Visible;
                txtF1_corner11.Margin = new Thickness(200, 467, 0, 0);

                txtMagnet.Visibility = Visibility.Visible;
                lblMagnetSave.Visibility = Visibility.Visible;

                if (_frameType != null && _frameType.AgroupOfDoorFrames == "Alpha")
                {
                    lblF1B.Visibility = Visibility.Visible;
                    txtF1B_corner16.Visibility = Visibility.Visible;
                }



            }
            else if (_FrameName == "RegularClick" || _FrameName == "AlphaClick")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(50, 315, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(50, 350, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 355, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 390, 0, 0);

                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(125, 200, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(125, 235, 0, 0);

                lblB2.Visibility = Visibility.Visible;
                lblB2.Margin = new Thickness(810, 200, 0, 0);
                txtB2_corner4.Visibility = Visibility.Visible;
                txtB2_corner4.Margin = new Thickness(810, 235, 0, 0);

                lblC1.Visibility = Visibility.Visible;
                lblC1.Margin = new Thickness(200, 255, 0, 0);
                txtC1_corner5.Visibility = Visibility.Visible;
                txtC1_corner5.Margin = new Thickness(200, 290, 0, 0);

                lblC2.Visibility = Visibility.Visible;
                lblC2.Margin = new Thickness(720, 255, 0, 0);
                txtC2_corner6.Visibility = Visibility.Visible;
                txtC2_corner6.Margin = new Thickness(720, 290, 0, 0);

                lblF1.Visibility = Visibility.Visible;
                lblF1.Margin = new Thickness(200, 500, 0, 0);
                txtF1_corner11.Visibility = Visibility.Visible;
                txtF1_corner11.Margin = new Thickness(200, 467, 0, 0);

                txtMagnet.Visibility = Visibility.Visible;
                lblMagnetSave.Visibility = Visibility.Visible;

                if (_frameType != null && _frameType.AgroupOfDoorFrames == "Alpha")
                {
                    lblF1B.Visibility = Visibility.Visible;
                    txtF1B_corner16.Visibility = Visibility.Visible; 
                    
                    lblF1A.Visibility = Visibility.Visible;
                    txtF1A_corner15.Visibility = Visibility.Visible;
                }


            }
            else if (_FrameName == "PendelStandartBT" || _FrameName == "PendelStandartGV")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(50, 315, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(50, 350, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 315, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 350, 0, 0);

                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(125, 200, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(125, 235, 0, 0);

                lblB2.Visibility = Visibility.Visible;
                lblB2.Margin = new Thickness(815, 200, 0, 0);
                txtB2_corner4.Visibility = Visibility.Visible;
                txtB2_corner4.Margin = new Thickness(815, 235, 0, 0);

    
                

           
                lblD1.Visibility = Visibility.Visible;
                lblD1.Margin = new Thickness(300, 500, 0, 0);
                txtD1_corner7.Visibility = Visibility.Visible;
                txtD1_corner7.Margin = new Thickness(300, 470, 0, 0);

                
                lblD2.Visibility = Visibility.Visible;
                lblD2.Margin = new Thickness(650, 500, 0, 0);
                txtD2_corner8.Visibility = Visibility.Visible;
                txtD2_corner8.Margin = new Thickness(650, 470, 0, 0);  
                
                lblC1.Visibility = Visibility.Visible;
                lblC1.Margin = new Thickness(450, 550, 0, 0);
                txtC1_corner5.Visibility = Visibility.Visible;
                txtC1_corner5.Margin = new Thickness(450, 530, 0, 0);

            


            }
            else if (_FrameName == "RegularStandartF1BT" || _FrameName == "RegularStandartF1GV" || _FrameName == "AlphaStandartF1BT" || _FrameName == "AlphaStandartF1GV")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(50, 315, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(50, 350, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 355, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 390, 0, 0);

                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(125, 200, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(125, 235, 0, 0);

                lblB2.Visibility = Visibility.Visible;
                lblB2.Margin = new Thickness(820, 200, 0, 0);
                txtB2_corner4.Visibility = Visibility.Visible;
                txtB2_corner4.Margin = new Thickness(820, 235, 0, 0);

                lblF1.Visibility = Visibility.Visible;
                lblF1.Margin = new Thickness(200, 495, 0, 0);
                txtF1_corner11.Visibility = Visibility.Visible;
                txtF1_corner11.Margin = new Thickness(200, 460, 0, 0);



                txtMagnet.Visibility = Visibility.Visible;
                lblMagnetSave.Visibility = Visibility.Visible;
              
                if (_frameType != null &&_frameType.AgroupOfDoorFrames == "Alpha")
                {
                    lblF1B.Visibility = Visibility.Visible;
                    txtF1B_corner16.Visibility = Visibility.Visible;
                }

            }
            else if (_FrameName == "RegularStandartF2BT" || _FrameName == "RegularStandartF2GV" || _FrameName == "AlphaStandartF2BT" || _FrameName == "AlphaStandartF1GV")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(50, 315, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(50, 350, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 305, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 340, 0, 0);

                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(125, 200, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(125, 235, 0, 0);

                lblB2.Visibility = Visibility.Visible;
                lblB2.Margin = new Thickness(820, 200, 0, 0);
                txtB2_corner4.Visibility = Visibility.Visible;
                txtB2_corner4.Margin = new Thickness(820, 235, 0, 0);

                lblF1.Visibility = Visibility.Visible;
                lblF1.Margin = new Thickness(200, 495, 0, 0);
                txtF1_corner11.Visibility = Visibility.Visible;
                txtF1_corner11.Margin = new Thickness(200, 460, 0, 0);

                lblD1.Visibility = Visibility.Visible;
                lblD1.Margin = new Thickness(700, 470, 0, 0);
                txtD1_corner7.Visibility = Visibility.Visible;
                txtD1_corner7.Margin = new Thickness(650, 470, 0, 0);

                txtMagnet.Visibility = Visibility.Visible;
                lblMagnetSave.Visibility = Visibility.Visible;
          

                if (_frameType != null && _frameType.AgroupOfDoorFrames == "Alpha")
                {
                    lblF1B.Visibility = Visibility.Visible;
                    txtF1B_corner16.Visibility = Visibility.Visible;
                }

            }
            else if (_FrameName == "RegularKantTiachF1BT" || _FrameName == "RegularKantTiachF1GV" || _FrameName == "AlphaKantTiachF1BT" || _FrameName == "AlphaKantTiachF1GV")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(50, 315, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(50, 350, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 305, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 340, 0, 0);

                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(125, 200, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(125, 235, 0, 0);

                lblB2.Visibility = Visibility.Visible;
                lblB2.Margin = new Thickness(820, 200, 0, 0);
                txtB2_corner4.Visibility = Visibility.Visible;
                txtB2_corner4.Margin = new Thickness(820, 235, 0, 0);

                lblF1.Visibility = Visibility.Visible;
                lblF1.Margin = new Thickness(200, 495, 0, 0);
                txtF1_corner11.Visibility = Visibility.Visible;
                txtF1_corner11.Margin = new Thickness(200, 460, 0, 0);

                lblC1.Visibility = Visibility.Visible;
                lblC1.Margin = new Thickness(250, 290, 0, 0);
                txtC1_corner5.Visibility = Visibility.Visible;
                txtC1_corner5.Margin = new Thickness(200, 290, 0, 0);

                lblC2.Visibility = Visibility.Visible;
                lblC2.Margin = new Thickness(710, 290, 0, 0);
                txtC2_corner6.Visibility = Visibility.Visible;
                txtC2_corner6.Margin = new Thickness(750, 290, 0, 0);

                lblE1.Visibility = Visibility.Visible;
                lblE1.Margin = new Thickness(135, 385, 0, 0);
                txtE1_corner9.Visibility = Visibility.Visible;
                txtE1_corner9.Margin = new Thickness(135, 350, 0, 0);
               
                lblE2.Visibility = Visibility.Visible;
                lblE2.Margin = new Thickness(810, 385, 0, 0);
                txtE2_corner10.Visibility = Visibility.Visible;
                txtE2_corner10.Margin = new Thickness(810, 350, 0, 0);

                txtMagnet.Visibility = Visibility.Visible;
                lblMagnetSave.Visibility = Visibility.Visible;


                if (_frameType != null && _frameType.AgroupOfDoorFrames == "Alpha")
                {
                    lblF1B.Visibility = Visibility.Visible;
                    txtF1B_corner16.Visibility = Visibility.Visible;
                }

            }
            else if (_FrameName == "RegularKantTiachF2BT" || _FrameName == "RegularKantTiachF2GV" || _FrameName == "AlphaKantTiachF2BT" || _FrameName == "AlphaKantTiachF2GV")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(50, 360, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(50, 390, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 360, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 390, 0, 0);

                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(125, 200, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(125, 235, 0, 0);

                lblB2.Visibility = Visibility.Visible;
                lblB2.Margin = new Thickness(820, 200, 0, 0);
                txtB2_corner4.Visibility = Visibility.Visible;
                txtB2_corner4.Margin = new Thickness(820, 235, 0, 0);

                lblF1.Visibility = Visibility.Visible;
                lblF1.Margin = new Thickness(200, 490, 0, 0);
                txtF1_corner11.Visibility = Visibility.Visible;
                txtF1_corner11.Margin = new Thickness(200, 460, 0, 0);

                lblC1.Visibility = Visibility.Visible;
                lblC1.Margin = new Thickness(250, 290, 0, 0);
                txtC1_corner5.Visibility = Visibility.Visible;
                txtC1_corner5.Margin = new Thickness(200, 290, 0, 0);

                lblC2.Visibility = Visibility.Visible;
                lblC2.Margin = new Thickness(715, 290, 0, 0);
                txtC2_corner6.Visibility = Visibility.Visible;
                txtC2_corner6.Margin = new Thickness(750, 290, 0, 0);

                lblD1.Visibility = Visibility.Visible;
                lblD1.Margin = new Thickness(699, 482, 0, 0);
                txtD1_corner7.Visibility = Visibility.Visible;
                txtD1_corner7.Margin = new Thickness(650, 482, 0, 0);

                lblE1.Visibility = Visibility.Visible;
                lblE1.Margin = new Thickness(135, 385, 0, 0);
                txtE1_corner9.Visibility = Visibility.Visible;
                txtE1_corner9.Margin = new Thickness(135, 360, 0, 0);

                lblE2.Visibility = Visibility.Visible;
                lblE2.Margin = new Thickness(810, 385, 0, 0);
                txtE2_corner10.Visibility = Visibility.Visible;
                txtE2_corner10.Margin = new Thickness(810, 360, 0, 0);

                txtMagnet.Visibility = Visibility.Visible;
                lblMagnetSave.Visibility = Visibility.Visible;


                if (_frameType != null && _frameType.AgroupOfDoorFrames == "Alpha")
                {
                    lblF1B.Visibility = Visibility.Visible;
                    txtF1B_corner16.Visibility = Visibility.Visible;
                }


            }else if(_FrameName == "PivotClick" || _FrameName == "BlindClick")
            {
                lblA1.Visibility = Visibility.Visible;
                lblA1.Margin = new Thickness(50, 360, 0, 0);
                txtA1_corner1.Visibility = Visibility.Visible;
                txtA1_corner1.Margin = new Thickness(50, 390, 0, 0);

                lblA2.Visibility = Visibility.Visible;
                lblA2.Margin = new Thickness(900, 360, 0, 0);
                txtA2_corner2.Visibility = Visibility.Visible;
                txtA2_corner2.Margin = new Thickness(900, 390, 0, 0);

                lblB1.Visibility = Visibility.Visible;
                lblB1.Margin = new Thickness(125, 200, 0, 0);
                txtB1_corner3.Visibility = Visibility.Visible;
                txtB1_corner3.Margin = new Thickness(125, 235, 0, 0);

                lblB2.Visibility = Visibility.Visible;
                lblB2.Margin = new Thickness(820, 200, 0, 0);
                txtB2_corner4.Visibility = Visibility.Visible;
                txtB2_corner4.Margin = new Thickness(820, 235, 0, 0);

                lblC1.Visibility = Visibility.Visible;
                lblC1.Margin = new Thickness(250, 290, 0, 0);
                txtC1_corner5.Visibility = Visibility.Visible;
                txtC1_corner5.Margin = new Thickness(200, 290, 0, 0);

                lblC2.Visibility = Visibility.Visible;
                lblC2.Margin = new Thickness(715, 290, 0, 0);
                txtC2_corner6.Visibility = Visibility.Visible;
                txtC2_corner6.Margin = new Thickness(750, 290, 0, 0);

            }
            else if (_FrameName == "RegularStandartAQ60BT" || _FrameName == "RegularStandartAQ60GV" || _FrameName == "AlphaStandartAQ60BT" || _FrameName == "AlphaStandartAQ60GV")
            {
            
            
            }


            }

        void save()
        {
            switch (_mode)
            {
                case Mode.add:
                    _add();                  
                    break;
                case Mode.update:
                    _update();
                    break;

            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     decimal ValidationinputDecemal(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return 0;
            }
            else
            {
                try
                {
                    return Convert.ToDecimal(txt);
                }catch
                {
                    return 0;
                }
            }
        }

     
 

    

        private void corner2Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner2 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();
            
            }
        }

      

        private void corner1Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner1 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();
             
            }
        }

        private void btnbackdb_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _pris = _prisTemp;
                _pris.Save();
                btnbackdb.Visibility = Visibility.Hidden;
                updateui();
            }
            }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            _prisTemp = clsPrisa.findbyFrameid(FrameID);

            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _pris.clear();
                _pris.Save();
                btnbackdb.Visibility = Visibility.Visible;
                updateui();
            }
            }

        private void corner3Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner3 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();

            }
        }

        private void corner9Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner9 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();

            }
        }

        private void corner7Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner7 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();

            }
        }

        private void corner11Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner11 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();

            }
        }
        private void corner12Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner12 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();

            }
        }
        private void corner10Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner10 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();

            }
        }

        private void corner8Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner8 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();

            }
        }

        private void corner4Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner4 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();

            }
        }

        private void corner6Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner6 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();

            }
        }

        private void corner5Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner5 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();
               

            }
        }

        private void corner13Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner13 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();


            }
        }

        private void corner14Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner14 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();


            }
        }       
        
        private void corner15Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner15 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();


            }
        }       
        
        private void corner16Save(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner16 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();


            }
        }  
        
        
        private void BendsSave(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.corner17 = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();


            }
        }        
        private void MagnetSave(object sender, KeyEventArgs e)
        {
            if (_pris != null)
            {
                _pris.magnet = ValidationinputDecemal(((TextBox)sender).Text);
                _pris.Save();


            }
        }

       
    }
}
