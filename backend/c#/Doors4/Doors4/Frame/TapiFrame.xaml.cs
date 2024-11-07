using CrystalDecisions.CrystalReports.Engine;

using Doors4;
using Doors4.clsGenral;
using Doors4.Projects;
using Doors4.Properties;
using Doors4.Report;
using SharaLogic;
using SharaLogic.Calculations;
using SharaLogic.WingCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Collections.Specialized.BitVector32;
namespace Door3
{

    /// <summary>
    /// Interaction logic for TapiFrame.xaml
    /// </summary>
    /// 

    public partial class TapiFrame : Window
    {

        Thread thView;




        public int UnderfloorHightDisp { get; set; }
        public string UpperPart { get; set; }

        public string Mekasher = "";
        public string Girong { get; set; }




        int _IDorder;
        int _IDFrame;

        clsOrders _order;
        clsCustomers _customer;
        clsProjects _project;
        clsFrames _frame;
        clsFrames _frameTemp;
        clsFrameType _TypeFrame;
        clsPrisaSize CPS;
        clsHingesFrames _HingeFrame;
        clsFrameLockType _CFLT;
        clsFrameUpperPart _CUPDB;
        clsPrisa _presa;
        clsFrameAdvanced _advanced;
        enum MyMode { AddNew = 1, Update = 2 }

        MyMode _mode = MyMode.AddNew;


        clsFrameMainCalculations MainCalc;

        public TapiFrame(int OrderId, int idFrame)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);



            if (idFrame == -1)
            {

                _mode = MyMode.AddNew;
                this._IDorder = OrderId;

                _order = clsOrders.Find(OrderId);
                if (_order == null)
                {
                    MessageBox.Show("Erorr");
                    this.Close();
                    return;


                }
                _project = clsProjects.Find(_order.ProjectID);
                _customer = clsCustomers.Find(_project.iDcustomer);

                UpdateUI();
            }
            else
            {

                _mode = MyMode.Update;
                this._IDFrame = idFrame;
                this._IDorder = OrderId;

                _frame = clsFrames.Find(idFrame);
                _TypeFrame = clsFrameType.FindByFrameID(idFrame);

                if (_TypeFrame != null)
                {


                    MainCalc = new clsFrameMainCalculations(this._IDFrame);
                    MainCalc.EXECUTE();



                }



            }





        }


        void PrisaSizeUpdateAndAdd()
        {
            CPS = clsPrisaSize.FindByFrameID(this._IDFrame);
            if (CPS == null)
            {

                CPS = new clsPrisaSize();
                CPS.FrameID = this._IDFrame;
                CPS.Save();


            }


        }
        string translockName(string name)
        {
            try
            {
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
            }
            catch (ResourceReferenceKeyNotFoundException ex)
            {
                clsSettings.SetEventLogMsg(ex.Message, "clsTapiFrame_FUNN_translockName", System.Diagnostics.EventLogEntryType.Warning);
            }
            return "";
        }
        void UpdateUI()
        {

            _checkMode();//first

            UpdateUIinput();



            UpdateUIOutput();

            _frame.Save();
            if (_frame.tbStickers <= 0)
            {
                tbStickers.Tag = "stikrs : " + (clsSettings.CalcAmountPrintStikrsFrame((byte)_frame.tbStickers) * _frame.tbAmount);
            }
            else
            {
                tbStickers.Tag = "stikrs : " + (clsSettings.CalcAmountPrintStikrsFrame((byte)_frame.tbStickers));
            }
            if (_frame.tbPrintAmount <= 0)
            {
                tbPrintAmount.Tag = "print : " + clsSettings.CalcAmountPrintPaperFrame((byte)_frame.tbPrintAmount);
            }
            else
            {
                tbPrintAmount.Tag = "print : " + clsSettings.CalcAmountPrintPaperFrame((byte)_frame.tbPrintAmount);
            }









        }

        BitmapImage imagePath(string uri)
        {
            if (uri != "")
            {
                try
                {
                    return new BitmapImage(new Uri(uri));
                }
                catch
                {
                    return new BitmapImage(new Uri(clsImageLibrary.Empty));
                }
            }
            else
            {
                return new BitmapImage(new Uri(clsImageLibrary.Empty));
            }
        }

        void _FillPresaDetails()
        {

            txtPresaA1.Content = MainCalc.OUT.outPresa_A1;
            txtPresaA2.Content = MainCalc.OUT.outPresa_A2;
            txtPresaB1.Content = MainCalc.OUT.outPresa_B1;
            txtPresaB2.Content = MainCalc.OUT.outPresa_B2;
            txtPresaC1.Content = MainCalc.OUT.outPresa_C1;
            txtPresaC2.Content = MainCalc.OUT.outPresa_C2;
            txtPresaD1.Content = MainCalc.OUT.outPresa_D1;
            txtPresaF1.Content = MainCalc.OUT.outPresa_F1;
            txtPresaG1.Content = MainCalc.OUT.outPresa_G1;
            txtPresaG2.Content = MainCalc.OUT.outPresa_G2;




        }

        void hideshowKetum()
        {
            if (MainCalc.OUT.outPrisaHight3 == "Empty")
            {
                PriseTest3.Visibility = Visibility.Hidden;
                txt_PrisaHight3.Visibility = Visibility.Hidden;
                txt_FrameHeadAmount3.Visibility = Visibility.Hidden;
                txt_FrameMetalWidth3.Visibility = Visibility.Hidden;
                txt_FrameMetal3.Visibility = Visibility.Hidden;
                txt_head3.Visibility = Visibility.Hidden;
            }
            else
            {
                PriseTest3.Visibility = Visibility.Hidden;
                txt_PrisaHight3.Visibility = Visibility.Hidden;
                txt_FrameHeadAmount3.Visibility = Visibility.Hidden;
                txt_FrameMetalWidth3.Visibility = Visibility.Hidden;
                txt_FrameMetal3.Visibility = Visibility.Hidden;
                txt_head3.Visibility = Visibility.Hidden;
            }
        }

        void UpdateUIOutput()
        {
            //just view in screen view 
            if (_frame != null && _TypeFrame != null)
            {
                upperPartLine();
                txt_FrameNitzavAmount.Content = _frame.tbAmount * 2;
                txt_FrameHeadAmount.Content = _frame.tbAmount;
                //koko
                txt_FrameWidth.Content = MainCalc.OUT.OutFrameWidth;
                txt_FrameDir.Content = MainCalc.OUT.OutDirection;
                txt_FramePlatzWidth.Content = MainCalc.OUT.OutFramePlatzWidth;
                txt_FrameHight.Content = MainCalc.OUT.OutFrameHight;
                PriseTest.Content = MainCalc.OUT.OutPriseTest_Nitzav;
                PriseTest2.Content = MainCalc.OUT.OutPriseTest_Head;
                txt_PrisaHight.Content = MainCalc.OUT.OutPrisaHight_Nitzav;
                txt_PrisaHightHead.Content = MainCalc.OUT.outPrisaHightHead;
                txt_PrisaHight3.Content = MainCalc.OUT.outPrisaHight3;
                txt_FrameMetalWidth.Content = MainCalc.OUT.OutFrameMetalWidth_Nitzav;
                txt_FrameMetalWidth2.Content = MainCalc.OUT.OutFrameMetalWidth_Nitzav;
                txt_FrameMetal.Content = MainCalc.OUT.OutFrameMetal_Nitzav;
                txt_FrameMetal2.Content = MainCalc.OUT.OutFrameMetal_Nitzav;
                txt_FrameHightTop.Content = MainCalc.OUT.outUpperPartSize;

                txt_WallThickness.Content = MainCalc.OUT.OutWallThickness;
                txt_FrameThickness.Content = MainCalc.OUT.OutFrameThickness;
                FrameTypeNameText4.Content = MainCalc.OUT.OutFrameTypeNameText4;
                txt_FrameLock1.Content = MainCalc.OUT.OutFrameLock1;// LKC.LockHight;
                txt_FrameLock2.Content = MainCalc.OUT.OutFrameLock2;//LKC.UpperLockHight;
                txt_bottomPart.Content = MainCalc.OUT.outBottomPartTestDisplay;
                txt_bottomPart_Copy.Content = MainCalc.OUT.outBottomPartTestDisplay;
                //   FramePlatzHight.Content = MainCalc.OUT.FramePlatzHight;
                txt_UpperPart.Content = FindResource("langUpeerPart") + MainCalc.OUT.outUpperPartType;
                _fillHinge();

                _FillPresaDetails();


                hideshowKetum();


                imgMain1.Source = imagePath(MainCalc.OUT.OutimgMain1);
                imgProfile1.Source = imagePath(MainCalc.OUT.OutimgProfile1);
                imgProfile2.Source = imagePath(MainCalc.OUT.OutimgProfile2);
                imgCut1.Source = imagePath(MainCalc.OUT.OutimgCut1);
                imgAlphaBox1.Source = imagePath(MainCalc.OUT.OutimgAlphaBox1);
                imgAlphaCut1.Source = imagePath(MainCalc.OUT.OutimgAlphaCut1);
                imgLock1.Source = imagePath(MainCalc.OUT.OutimgLock1);
                imgLock2.Source = imagePath(MainCalc.OUT.OutimgLock2);
                imgCut2.Source = imagePath(MainCalc.OUT.OutimgCut2);
                imgGevesLine1.Source = imagePath(MainCalc.OUT.OutimgGevesLine1);
                imgCut22.Source = imagePath(MainCalc.OUT.OutimgCut22);
                imgCut11.Source = imagePath(MainCalc.OUT.OutimgCut11);









            }

        }

        void _show2Hinge()
        {

            FrameHinge1H.Content = MainCalc.OUT.OutFrameHinge1H;
            imgHingeA1.Source = imagePath(MainCalc.OUT.OutimgHingeA1);
            imgHingeC1.Source = imagePath(MainCalc.OUT.OutimgHingeA1);

            FrameHinge7H.Content = MainCalc.OUT.OutFrameHinge2H;
            imgHingeA7.Source = imagePath(MainCalc.OUT.OutimgHingeA7);
            imgHingeC7.Source = imagePath(MainCalc.OUT.OutimgHingeA7);




            FrameHinge7H.Visibility = Visibility.Hidden;
            imgHingeA7.Visibility = Visibility.Hidden;
            imgHingeC7.Visibility = Visibility.Hidden;

            FrameHinge1H.Visibility = Visibility.Hidden;
            imgHingeA1.Visibility = Visibility.Hidden;
            imgHingeC1.Visibility = Visibility.Hidden;


            FrameHinge2H.Visibility = Visibility.Hidden;
            FrameHinge2H.Content = "Empty";
            imgHingeA2.Visibility = Visibility.Hidden;
            imgHingeC2.Visibility = Visibility.Hidden;

            FrameHinge3H.Visibility = Visibility.Hidden;
            FrameHinge3H.Content = "Empty";
            imgHingeA3.Visibility = Visibility.Hidden;
            imgHingeC3.Visibility = Visibility.Hidden;

            FrameHinge4H.Visibility = Visibility.Hidden;
            FrameHinge4H.Content = "Empty";
            imgHingeA4.Visibility = Visibility.Hidden;
            imgHingeC4.Visibility = Visibility.Hidden;

            FrameHinge5H.Visibility = Visibility.Hidden;
            FrameHinge5H.Content = "Empty";
            imgHingeA5.Visibility = Visibility.Hidden;
            imgHingeC5.Visibility = Visibility.Hidden;

            FrameHinge6H.Visibility = Visibility.Hidden;
            FrameHinge6H.Content = "Empty";
            imgHingeA6.Visibility = Visibility.Hidden;
            imgHingeC6.Visibility = Visibility.Hidden;


            lh2.Visibility = Visibility.Hidden;
            lh22.Visibility = Visibility.Hidden;
            lh23.Visibility = Visibility.Hidden;
            rech2.Visibility = Visibility.Hidden;
            rech22.Visibility = Visibility.Hidden;


            lh3.Visibility = Visibility.Hidden;
            lh31.Visibility = Visibility.Hidden;
            lh32.Visibility = Visibility.Hidden;
            rech3.Visibility = Visibility.Hidden;
            rech32.Visibility = Visibility.Hidden;


            lh41.Visibility = Visibility.Hidden;
            lh42.Visibility = Visibility.Hidden;
            lh43.Visibility = Visibility.Hidden;
            rech41.Visibility = Visibility.Hidden;
            rech42.Visibility = Visibility.Hidden;


            lh51.Visibility = Visibility.Hidden;
            lh52.Visibility = Visibility.Hidden;
            lh53.Visibility = Visibility.Hidden;
            rech51.Visibility = Visibility.Hidden;
            rech52.Visibility = Visibility.Hidden;


            lh61.Visibility = Visibility.Hidden;
            lh62.Visibility = Visibility.Hidden;
            lh63.Visibility = Visibility.Hidden;
            rech61.Visibility = Visibility.Hidden;
            rech62.Visibility = Visibility.Hidden;



        }


        void _show3Hinge()
        {

            FrameHinge1H.Content = MainCalc.OUT.OutFrameHinge1H;
            imgHingeA1.Source = imagePath(MainCalc.OUT.OutimgHingeA1);
            imgHingeC1.Source = imagePath(MainCalc.OUT.OutimgHingeA1);

            FrameHinge7H.Content = MainCalc.OUT.OutFrameHinge3H;
            imgHingeA7.Source = imagePath(MainCalc.OUT.OutimgHingeA7);
            imgHingeC7.Source = imagePath(MainCalc.OUT.OutimgHingeA7);



            FrameHinge7H.Visibility = Visibility.Hidden;
            imgHingeA7.Visibility = Visibility.Hidden;
            imgHingeC7.Visibility = Visibility.Hidden;

            FrameHinge1H.Visibility = Visibility.Hidden;
            imgHingeA1.Visibility = Visibility.Hidden;
            imgHingeC1.Visibility = Visibility.Hidden;



            if (_HingeFrame.TopMeddleHinge == true)
            {
                FrameHinge2H.Content = MainCalc.OUT.OutFrameHinge2H;

                imgHingeA2.Source = imagePath(MainCalc.OUT.OutimgHingeA2);
                imgHingeC2.Source = imagePath(MainCalc.OUT.OutimgHingeA2);

                FrameHinge2H.Visibility = Visibility.Hidden;

                imgHingeA2.Visibility = Visibility.Hidden;
                imgHingeC2.Visibility = Visibility.Hidden;

                FrameHinge4H.Visibility = Visibility.Hidden;
                FrameHinge4H.Content = "Empty";
                imgHingeA4.Visibility = Visibility.Hidden;
                imgHingeC4.Visibility = Visibility.Hidden;

                lh2.Visibility = Visibility.Hidden;
                lh22.Visibility = Visibility.Hidden;
                lh23.Visibility = Visibility.Hidden;
                rech2.Visibility = Visibility.Hidden;
                rech22.Visibility = Visibility.Hidden;

                lh41.Visibility = Visibility.Hidden;
                lh42.Visibility = Visibility.Hidden;
                lh43.Visibility = Visibility.Hidden;
                rech41.Visibility = Visibility.Hidden;
                rech42.Visibility = Visibility.Hidden;
            }
            else
            {
                FrameHinge4H.Content = MainCalc.OUT.OutFrameHinge2H;
                imgHingeA4.Source = imagePath(MainCalc.OUT.OutimgHingeA4);
                imgHingeC4.Source = imagePath(MainCalc.OUT.OutimgHingeA4);

                FrameHinge2H.Visibility = Visibility.Hidden;
                FrameHinge2H.Content = "Empty";
                imgHingeA2.Visibility = Visibility.Hidden;
                imgHingeC2.Visibility = Visibility.Hidden;

                FrameHinge4H.Visibility = Visibility.Hidden;

                imgHingeA4.Visibility = Visibility.Hidden;
                imgHingeC4.Visibility = Visibility.Hidden;

                lh2.Visibility = Visibility.Hidden;
                lh22.Visibility = Visibility.Hidden;
                lh23.Visibility = Visibility.Hidden;
                rech2.Visibility = Visibility.Hidden;
                rech22.Visibility = Visibility.Hidden;

                lh41.Visibility = Visibility.Hidden;
                lh42.Visibility = Visibility.Hidden;
                lh43.Visibility = Visibility.Hidden;
                rech41.Visibility = Visibility.Hidden;
                rech42.Visibility = Visibility.Hidden;

            }





            FrameHinge3H.Visibility = Visibility.Hidden;
            FrameHinge3H.Content = "Empty";
            imgHingeA3.Visibility = Visibility.Hidden;
            imgHingeC3.Visibility = Visibility.Hidden;



            FrameHinge5H.Visibility = Visibility.Hidden;
            FrameHinge5H.Content = "Empty";
            imgHingeA5.Visibility = Visibility.Hidden;
            imgHingeC5.Visibility = Visibility.Hidden;

            FrameHinge6H.Visibility = Visibility.Hidden;
            FrameHinge6H.Content = "Empty";
            imgHingeA6.Visibility = Visibility.Hidden;
            imgHingeC6.Visibility = Visibility.Hidden;




            lh3.Visibility = Visibility.Hidden;
            lh31.Visibility = Visibility.Hidden;
            lh32.Visibility = Visibility.Hidden;
            rech3.Visibility = Visibility.Hidden;
            rech32.Visibility = Visibility.Hidden;




            lh51.Visibility = Visibility.Hidden;
            lh52.Visibility = Visibility.Hidden;
            lh53.Visibility = Visibility.Hidden;
            rech51.Visibility = Visibility.Hidden;
            rech52.Visibility = Visibility.Hidden;


            lh61.Visibility = Visibility.Hidden;
            lh62.Visibility = Visibility.Hidden;
            lh63.Visibility = Visibility.Hidden;
            rech61.Visibility = Visibility.Hidden;
            rech62.Visibility = Visibility.Hidden;



        }

        void _show4Hinge()
        {

            FrameHinge1H.Content = MainCalc.OUT.OutFrameHinge1H;
            imgHingeA1.Source = imagePath(MainCalc.OUT.OutimgHingeA1);
            imgHingeC1.Source = imagePath(MainCalc.OUT.OutimgHingeA1);

            FrameHinge3H.Content = MainCalc.OUT.OutFrameHinge2H;
            imgHingeA3.Source = imagePath(MainCalc.OUT.OutimgHingeA3);
            imgHingeC3.Source = imagePath(MainCalc.OUT.OutimgHingeA3);

            FrameHinge5H.Content = MainCalc.OUT.OutFrameHinge3H;
            imgHingeA5.Source = imagePath(MainCalc.OUT.OutimgHingeA5);
            imgHingeC5.Source = imagePath(MainCalc.OUT.OutimgHingeA5);

            FrameHinge7H.Content = MainCalc.OUT.OutFrameHinge4H;
            imgHingeA7.Source = imagePath(MainCalc.OUT.OutimgHingeA7);
            imgHingeC7.Source = imagePath(MainCalc.OUT.OutimgHingeA7);



            FrameHinge7H.Visibility = Visibility.Hidden;
            imgHingeA7.Visibility = Visibility.Hidden;
            imgHingeC7.Visibility = Visibility.Hidden;

            FrameHinge1H.Visibility = Visibility.Hidden;
            imgHingeA1.Visibility = Visibility.Hidden;
            imgHingeC1.Visibility = Visibility.Hidden;


            FrameHinge2H.Visibility = Visibility.Hidden;
            FrameHinge2H.Content = "Empty";
            imgHingeA2.Visibility = Visibility.Hidden;
            imgHingeC2.Visibility = Visibility.Hidden;

            FrameHinge3H.Visibility = Visibility.Hidden;
            imgHingeA3.Visibility = Visibility.Hidden;
            imgHingeC3.Visibility = Visibility.Hidden;

            FrameHinge4H.Visibility = Visibility.Hidden;
            FrameHinge4H.Content = "Empty";

            imgHingeA4.Visibility = Visibility.Hidden;
            imgHingeC4.Visibility = Visibility.Hidden;

            FrameHinge5H.Visibility = Visibility.Hidden;
            imgHingeA5.Visibility = Visibility.Hidden;
            imgHingeC5.Visibility = Visibility.Hidden;

            FrameHinge6H.Visibility = Visibility.Hidden;
            FrameHinge6H.Content = "Empty";
            imgHingeA6.Visibility = Visibility.Hidden;
            imgHingeC6.Visibility = Visibility.Hidden;


            lh2.Visibility = Visibility.Hidden;
            lh22.Visibility = Visibility.Hidden;
            lh23.Visibility = Visibility.Hidden;
            rech2.Visibility = Visibility.Hidden;
            rech22.Visibility = Visibility.Hidden;


            lh3.Visibility = Visibility.Hidden;
            lh31.Visibility = Visibility.Hidden;
            lh32.Visibility = Visibility.Hidden;
            rech3.Visibility = Visibility.Hidden;
            rech32.Visibility = Visibility.Hidden;


            lh41.Visibility = Visibility.Hidden;
            lh42.Visibility = Visibility.Hidden;
            lh43.Visibility = Visibility.Hidden;
            rech41.Visibility = Visibility.Hidden;
            rech42.Visibility = Visibility.Hidden;


            lh51.Visibility = Visibility.Hidden;
            lh52.Visibility = Visibility.Hidden;
            lh53.Visibility = Visibility.Hidden;
            rech51.Visibility = Visibility.Hidden;
            rech52.Visibility = Visibility.Hidden;


            lh61.Visibility = Visibility.Hidden;
            lh62.Visibility = Visibility.Hidden;
            lh63.Visibility = Visibility.Hidden;
            rech61.Visibility = Visibility.Hidden;
            rech62.Visibility = Visibility.Hidden;



        }

        void _show5Hinge()
        {

            FrameHinge1H.Content = MainCalc.OUT.OutFrameHinge1H;
            imgHingeA1.Source = imagePath(MainCalc.OUT.OutimgHingeA1);
            imgHingeC1.Source = imagePath(MainCalc.OUT.OutimgHingeA1);

            FrameHinge2H.Content = MainCalc.OUT.OutFrameHinge2H;
            imgHingeA2.Source = imagePath(MainCalc.OUT.OutimgHingeA2);
            imgHingeC2.Source = imagePath(MainCalc.OUT.OutimgHingeA2);

            FrameHinge4H.Content = MainCalc.OUT.OutFrameHinge3H;
            imgHingeA4.Source = imagePath(MainCalc.OUT.OutimgHingeA4);
            imgHingeC4.Source = imagePath(MainCalc.OUT.OutimgHingeA4);

            FrameHinge6H.Content = MainCalc.OUT.OutFrameHinge4H;
            imgHingeA6.Source = imagePath(MainCalc.OUT.OutimgHingeA6);
            imgHingeC6.Source = imagePath(MainCalc.OUT.OutimgHingeA6);

            FrameHinge7H.Content = MainCalc.OUT.OutFrameHinge5H;
            imgHingeA7.Source = imagePath(MainCalc.OUT.OutimgHingeA7);
            imgHingeC7.Source = imagePath(MainCalc.OUT.OutimgHingeA7);



            FrameHinge7H.Visibility = Visibility.Hidden;
            imgHingeA7.Visibility = Visibility.Hidden;
            imgHingeC7.Visibility = Visibility.Hidden;

            FrameHinge1H.Visibility = Visibility.Hidden;
            imgHingeA1.Visibility = Visibility.Hidden;
            imgHingeC1.Visibility = Visibility.Hidden;


            FrameHinge2H.Visibility = Visibility.Hidden;
            imgHingeA2.Visibility = Visibility.Hidden;
            imgHingeC2.Visibility = Visibility.Hidden;

            FrameHinge3H.Visibility = Visibility.Hidden;
            FrameHinge3H.Content = "Empty";
            imgHingeA3.Visibility = Visibility.Hidden;
            imgHingeC3.Visibility = Visibility.Hidden;

            FrameHinge4H.Visibility = Visibility.Hidden;
            imgHingeA4.Visibility = Visibility.Hidden;
            imgHingeC4.Visibility = Visibility.Hidden;

            FrameHinge5H.Visibility = Visibility.Hidden;
            FrameHinge5H.Content = "Empty";
            imgHingeA5.Visibility = Visibility.Hidden;
            imgHingeC5.Visibility = Visibility.Hidden;

            FrameHinge6H.Visibility = Visibility.Hidden;
            imgHingeA6.Visibility = Visibility.Hidden;
            imgHingeC6.Visibility = Visibility.Hidden;


            lh2.Visibility = Visibility.Hidden;
            lh22.Visibility = Visibility.Hidden;
            lh23.Visibility = Visibility.Hidden;
            rech2.Visibility = Visibility.Hidden;
            rech22.Visibility = Visibility.Hidden;


            lh3.Visibility = Visibility.Hidden;
            lh31.Visibility = Visibility.Hidden;
            lh32.Visibility = Visibility.Hidden;
            rech3.Visibility = Visibility.Hidden;
            rech32.Visibility = Visibility.Hidden;


            lh41.Visibility = Visibility.Hidden;
            lh42.Visibility = Visibility.Hidden;
            lh43.Visibility = Visibility.Hidden;
            rech41.Visibility = Visibility.Hidden;
            rech42.Visibility = Visibility.Hidden;


            lh51.Visibility = Visibility.Hidden;
            lh52.Visibility = Visibility.Hidden;
            lh53.Visibility = Visibility.Hidden;
            rech51.Visibility = Visibility.Hidden;
            rech52.Visibility = Visibility.Hidden;


            lh61.Visibility = Visibility.Hidden;
            lh62.Visibility = Visibility.Hidden;
            lh63.Visibility = Visibility.Hidden;
            rech61.Visibility = Visibility.Hidden;
            rech62.Visibility = Visibility.Hidden;



        }

        void _show6Hinge()
        {

            FrameHinge1H.Content = MainCalc.OUT.OutFrameHinge1H;
            imgHingeA1.Source = imagePath(MainCalc.OUT.OutimgHingeA1);
            imgHingeC1.Source = imagePath(MainCalc.OUT.OutimgHingeA1);

            FrameHinge2H.Content = MainCalc.OUT.OutFrameHinge2H;
            imgHingeA2.Source = imagePath(MainCalc.OUT.OutimgHingeA2);
            imgHingeC2.Source = imagePath(MainCalc.OUT.OutimgHingeA2);

            FrameHinge3H.Content = MainCalc.OUT.OutFrameHinge3H;
            imgHingeA3.Source = imagePath(MainCalc.OUT.OutimgHingeA3);
            imgHingeC3.Source = imagePath(MainCalc.OUT.OutimgHingeA3);

            FrameHinge5H.Content = MainCalc.OUT.OutFrameHinge4H;
            imgHingeA5.Source = imagePath(MainCalc.OUT.OutimgHingeA5);
            imgHingeC5.Source = imagePath(MainCalc.OUT.OutimgHingeA5);

            FrameHinge6H.Content = MainCalc.OUT.OutFrameHinge5H;
            imgHingeA6.Source = imagePath(MainCalc.OUT.OutimgHingeA6);
            imgHingeC6.Source = imagePath(MainCalc.OUT.OutimgHingeA6);

            FrameHinge7H.Content = MainCalc.OUT.OutFrameHinge6H;
            imgHingeA7.Source = imagePath(MainCalc.OUT.OutimgHingeA7);
            imgHingeC7.Source = imagePath(MainCalc.OUT.OutimgHingeA7);



            FrameHinge7H.Visibility = Visibility.Hidden;
            imgHingeA7.Visibility = Visibility.Hidden;
            imgHingeC7.Visibility = Visibility.Hidden;

            FrameHinge1H.Visibility = Visibility.Hidden;
            imgHingeA1.Visibility = Visibility.Hidden;
            imgHingeC1.Visibility = Visibility.Hidden;


            FrameHinge2H.Visibility = Visibility.Hidden;
            imgHingeA2.Visibility = Visibility.Hidden;
            imgHingeC2.Visibility = Visibility.Hidden;

            FrameHinge3H.Visibility = Visibility.Hidden;
            imgHingeA3.Visibility = Visibility.Hidden;
            imgHingeC3.Visibility = Visibility.Hidden;

            FrameHinge4H.Visibility = Visibility.Hidden;
            FrameHinge4H.Content = "Empty";
            imgHingeA4.Visibility = Visibility.Hidden;
            imgHingeC4.Visibility = Visibility.Hidden;

            FrameHinge5H.Visibility = Visibility.Hidden;
            imgHingeA5.Visibility = Visibility.Hidden;
            imgHingeC5.Visibility = Visibility.Hidden;

            FrameHinge6H.Visibility = Visibility.Hidden;
            imgHingeA6.Visibility = Visibility.Hidden;
            imgHingeC6.Visibility = Visibility.Hidden;


            lh2.Visibility = Visibility.Hidden;
            lh22.Visibility = Visibility.Hidden;
            lh23.Visibility = Visibility.Hidden;
            rech2.Visibility = Visibility.Hidden;
            rech22.Visibility = Visibility.Hidden;


            lh3.Visibility = Visibility.Hidden;
            lh31.Visibility = Visibility.Hidden;
            lh32.Visibility = Visibility.Hidden;
            rech3.Visibility = Visibility.Hidden;
            rech32.Visibility = Visibility.Hidden;


            lh41.Visibility = Visibility.Hidden;
            lh42.Visibility = Visibility.Hidden;
            lh43.Visibility = Visibility.Hidden;
            rech41.Visibility = Visibility.Hidden;
            rech42.Visibility = Visibility.Hidden;


            lh51.Visibility = Visibility.Hidden;
            lh52.Visibility = Visibility.Hidden;
            lh53.Visibility = Visibility.Hidden;
            rech51.Visibility = Visibility.Hidden;
            rech52.Visibility = Visibility.Hidden;


            lh61.Visibility = Visibility.Hidden;
            lh62.Visibility = Visibility.Hidden;
            lh63.Visibility = Visibility.Hidden;
            rech61.Visibility = Visibility.Hidden;
            rech62.Visibility = Visibility.Hidden;



        }
        void _NOHinge()
        {


            FrameHinge7H.Visibility = Visibility.Hidden;
            imgHingeA7.Visibility = Visibility.Hidden;
            imgHingeC7.Visibility = Visibility.Hidden;
            FrameHinge7H.Content = "Empty";

            FrameHinge1H.Visibility = Visibility.Hidden;
            FrameHinge1H.Content = "Empty";
            imgHingeA1.Visibility = Visibility.Hidden;
            imgHingeC1.Visibility = Visibility.Hidden;


            FrameHinge2H.Visibility = Visibility.Hidden;
            FrameHinge2H.Content = "Empty";
            imgHingeA2.Visibility = Visibility.Hidden;
            imgHingeC2.Visibility = Visibility.Hidden;

            FrameHinge3H.Visibility = Visibility.Hidden;
            FrameHinge3H.Content = "Empty";
            imgHingeA3.Visibility = Visibility.Hidden;
            imgHingeC3.Visibility = Visibility.Hidden;

            FrameHinge4H.Visibility = Visibility.Hidden;
            FrameHinge4H.Content = "Empty";
            imgHingeA4.Visibility = Visibility.Hidden;
            imgHingeC4.Visibility = Visibility.Hidden;

            FrameHinge5H.Visibility = Visibility.Hidden;
            FrameHinge5H.Content = "Empty";
            imgHingeA5.Visibility = Visibility.Hidden;
            imgHingeC5.Visibility = Visibility.Hidden;

            FrameHinge6H.Visibility = Visibility.Hidden;
            FrameHinge6H.Content = "Empty";
            imgHingeA6.Visibility = Visibility.Hidden;
            imgHingeC6.Visibility = Visibility.Hidden;

            lh1.Visibility = Visibility.Hidden;
            lh12.Visibility = Visibility.Hidden;
            lh13.Visibility = Visibility.Hidden;
            lh14.Visibility = Visibility.Hidden;
            lh15.Visibility = Visibility.Hidden;

            lh7.Visibility = Visibility.Hidden;
            lh72.Visibility = Visibility.Hidden;
            lh73.Visibility = Visibility.Hidden;
            lh74.Visibility = Visibility.Hidden;
            lh75.Visibility = Visibility.Hidden;


            lh2.Visibility = Visibility.Hidden;
            lh22.Visibility = Visibility.Hidden;
            lh23.Visibility = Visibility.Hidden;
            rech2.Visibility = Visibility.Hidden;
            rech22.Visibility = Visibility.Hidden;


            lh3.Visibility = Visibility.Hidden;
            lh31.Visibility = Visibility.Hidden;
            lh32.Visibility = Visibility.Hidden;
            rech3.Visibility = Visibility.Hidden;
            rech32.Visibility = Visibility.Hidden;


            lh41.Visibility = Visibility.Hidden;
            lh42.Visibility = Visibility.Hidden;
            lh43.Visibility = Visibility.Hidden;
            rech41.Visibility = Visibility.Hidden;
            rech42.Visibility = Visibility.Hidden;


            lh51.Visibility = Visibility.Hidden;
            lh52.Visibility = Visibility.Hidden;
            lh53.Visibility = Visibility.Hidden;
            rech51.Visibility = Visibility.Hidden;
            rech52.Visibility = Visibility.Hidden;


            lh61.Visibility = Visibility.Hidden;
            lh62.Visibility = Visibility.Hidden;
            lh63.Visibility = Visibility.Hidden;
            rech61.Visibility = Visibility.Hidden;
            rech62.Visibility = Visibility.Hidden;


        }
        void _fillHinge()
        {
            if (_TypeFrame.AgroupOfDoorFrames == "Regular" || _TypeFrame.AgroupOfDoorFrames == "Pendel")
            {
                if (_HingeFrame != null)
                {


                    lh1.Visibility = Visibility.Hidden;
                    lh12.Visibility = Visibility.Hidden;
                    lh13.Visibility = Visibility.Hidden;
                    lh14.Visibility = Visibility.Hidden;
                    lh15.Visibility = Visibility.Hidden;

                    lh7.Visibility = Visibility.Hidden;
                    lh72.Visibility = Visibility.Hidden;
                    lh73.Visibility = Visibility.Hidden;
                    lh74.Visibility = Visibility.Hidden;
                    lh75.Visibility = Visibility.Hidden;

                    MainCalc.IN.Inhinge1 = _HingeFrame.Hinge1;
                    MainCalc.IN.Inhinge2 = _HingeFrame.Hinge2;
                    MainCalc.IN.Inhinge3 = _HingeFrame.Hinge3;
                    MainCalc.IN.Inhinge4 = _HingeFrame.Hinge4;
                    MainCalc.IN.Inhinge5 = _HingeFrame.Hinge5;
                    MainCalc.IN.Inhinge6 = _HingeFrame.Hinge6;
                    MainCalc.IN.UpperMiddleHinge = _HingeFrame.TopMeddleHinge;






                    switch (_HingeFrame.HingeAmount)
                    {

                        case 2:

                            _show2Hinge();
                            break;
                        case 3:

                            _show3Hinge();
                            break;
                        case 4:

                            _show4Hinge();
                            break;
                        case 5:

                            _show5Hinge();
                            break;
                        case 6:

                            _show6Hinge();
                            break;

                        default:
                            _show3Hinge();

                            break;
                    }



                }
            }
            else
            {
                _NOHinge();
            }
        }

        void upperPartLine()
        {
            if (_CUPDB != null)
            {
                if (_CUPDB.upperPartType == "ללא")
                {
                    upl1.Visibility = Visibility.Hidden;
                    upl2.Visibility = Visibility.Hidden;
                    upl3.Visibility = Visibility.Hidden;
                    upl4.Visibility = Visibility.Hidden;

                    bplr4.Visibility = Visibility.Hidden;
                    bplr3.Visibility = Visibility.Hidden;
                    bplr2.Visibility = Visibility.Hidden;
                    bplr1.Visibility = Visibility.Hidden;

                    bpll1.Visibility = Visibility.Hidden;
                    bpll2.Visibility = Visibility.Hidden;
                    bpll3.Visibility = Visibility.Hidden;
                    bpll4.Visibility = Visibility.Hidden;
                    txt_UpperPart.Visibility = Visibility.Hidden;
                    txt_FrameHightTop.Visibility = Visibility.Hidden;
                    txt_bottomPart.Visibility = Visibility.Hidden;
                    txt_bottomPart_Copy.Visibility = Visibility.Hidden;
                    imgProfile2.Visibility = Visibility.Hidden;

                }
                else
                {
                    upl1.Visibility = Visibility.Hidden;
                    upl2.Visibility = Visibility.Hidden;
                    upl3.Visibility = Visibility.Hidden;
                    upl4.Visibility = Visibility.Hidden;

                    bplr4.Visibility = Visibility.Hidden;
                    bplr3.Visibility = Visibility.Hidden;
                    bplr2.Visibility = Visibility.Hidden;
                    bplr1.Visibility = Visibility.Hidden;

                    bpll1.Visibility = Visibility.Hidden;
                    bpll2.Visibility = Visibility.Hidden;
                    bpll3.Visibility = Visibility.Hidden;
                    bpll4.Visibility = Visibility.Hidden;
                    txt_UpperPart.Visibility = Visibility.Hidden;
                    txt_FrameHightTop.Visibility = Visibility.Hidden;
                    txt_bottomPart.Visibility = Visibility.Hidden;
                    txt_bottomPart_Copy.Visibility = Visibility.Hidden;
                    imgProfile2.Visibility = Visibility.Hidden;
                }
            }

        }

        void UpdateUIinput()
        {

            if (_frame != null)
            {


                if (_frame.Direction == "RIGHT")
                {
                    rbRigth.IsChecked = true;
                    rbRigth.FontWeight = FontWeights.Bold;
                }
                else
                {
                    rbRigth.FontWeight = FontWeights.Normal;
                }

                if (_frame.Direction == "Left")
                {
                    rbleft.IsChecked = true;
                    rbleft.FontWeight = FontWeights.Bold;
                }
                else
                {
                    rbleft.FontWeight = FontWeights.Normal;
                }


                TextBoxFrameWidth.Text = _frame.Width.ToString();
                TextBoxFrameHight.Text = _frame.Height.ToString();
                txtNote.Text = _frame.FactoryNotes;
                txtOrderNumber.Text = _order.OrderNumber.ToString();
                txtCustomerName.Content = _customer.CompanyName;
                lblProjectName.Content = _project.projectName;
                txtFrameNumber.Text = _frame.DoorNumber.ToString();
                txtLocation.Text = _frame.Location;
                box_CommentFactory.Text = _frame.Notes;
                txtDoorIdentity.Text = _frame.DoorIdentity;

                txt_Comments.Text = _frame.Notes;
                TextBoxFrameHightUnderFloor.Text = _frame.FrameUnderFloor <= 0 ? "" : _frame.FrameUnderFloor.ToString();
                tbPrintAmount.Text = _frame.tbPrintAmount <= 0 ? "" : _frame.tbPrintAmount.ToString();
                tbStickers.Text = _frame.tbStickers <= 0 ? "" : _frame.tbStickers.ToString();
                tbAmount.Text = _frame.tbAmount <= 0 ? "" : _frame.tbAmount.ToString();



                if (_frame.FrameThickness > 0)
                {
                    FrameThicknessBox.Text = _frame.FrameThickness.ToString();
                    MainCalc.IN.InFrameThicknessBox = _frame.FrameThickness;
                    FrameThicknessBox.IsEnabled = true;
                    WallThicknessBox.IsEnabled = false;
                }
                else if (_frame.WallThickness > 0)
                {
                    WallThicknessBox.Text = _frame.WallThickness.ToString();
                    MainCalc.IN.InWallThicknessBox = _frame.WallThickness;
                    WallThicknessBox.IsEnabled = true;
                    FrameThicknessBox.IsEnabled = false;
                }
                else
                {
                    FrameThicknessBox.IsEnabled = true;
                    WallThicknessBox.IsEnabled = true;
                }





                if (_frame.MaterialType == "Norsta")
                {
                    rbnerosta.IsChecked = true;
                    rbnerosta.FontWeight = FontWeights.Bold;

                }
                else
                {
                    rbnerosta.FontWeight = FontWeights.Normal;
                }

                if (_frame.MaterialType == "Megolvan")
                {
                    rbmegolvan.IsChecked = true;
                    rbmegolvan.FontWeight = FontWeights.Bold;
                }
                else
                {
                    rbmegolvan.FontWeight = FontWeights.Normal;
                }


                if (_frame.IronThickness == 1.5f)
                {
                    rbThiknssIron1_5.IsChecked = true;
                    rbThiknssIron1_5.FontWeight = FontWeights.Bold;
                }
                else
                {
                    rbThiknssIron1_5.FontWeight = FontWeights.Normal;
                }


                if (_frame.IronThickness == 1.25f)
                {
                    rbThiknssIron1_25.IsChecked = true;
                    rbThiknssIron1_25.FontWeight = FontWeights.Bold;
                }
                else
                {
                    rbThiknssIron1_25.FontWeight = FontWeights.Normal;
                }


                if (_frame.IronThickness == 2f)
                {
                    rbThiknssIron2.IsChecked = true;
                    rbThiknssIron2.FontWeight = FontWeights.Bold;
                }
                else
                {
                    rbThiknssIron2.FontWeight = FontWeights.Normal;
                }


                if (_frame.Meksher == true)
                {
                    CheckBoxMekasher.IsChecked = true;
                    Mekasher = FindResource("langMekasher100").ToString();
                    CheckBoxMekasher.Content = Mekasher;

                    CheckBoxMekasher.FontWeight = FontWeights.Bold;
                }
                else
                {
                    CheckBoxMekasher.IsChecked = false;
                    Mekasher = FindResource("langMekashertahton").ToString();
                    CheckBoxMekasher.Content = Mekasher;
                    CheckBoxMekasher.FontWeight = FontWeights.Normal;
                }

                if (_frame.RHS70 == true)
                {
                    RHSswitch.IsChecked = true;
                    txt_RHS.Content = FindResource("langRHS-70").ToString();
                    RHSswitch.FontWeight = FontWeights.Bold;
                }
                else
                {
                    RHSswitch.IsChecked = false;
                    txt_RHS.Content = "0";
                    RHSswitch.FontWeight = FontWeights.Normal;
                }

                if (_frame.DoubleDoor == true)
                {
                    CheckBoxDoubleDoor.IsChecked = true;
                    CheckBoxDoubleDoor.Content = FindResource("langTwo-winged");
                    CheckBoxDoubleDoor.FontWeight = FontWeights.Bold;
                }
                else
                {
                    CheckBoxDoubleDoor.IsChecked = false;
                    CheckBoxDoubleDoor.Content = FindResource("langone-winged").ToString();
                    CheckBoxDoubleDoor.FontWeight = FontWeights.Normal;
                }



                if (_CFLT != null)
                {
                    MainCalc.IN.InLockType = _CFLT.LockType;

                    MainCalc.IN.InLockMeasure = _CFLT.LockMeasure;
                    MainCalc.IN.InUpperLockMeasure = _CFLT.UpperLockMeasure;
                    MainCalc.IN.InLockMeasureFloor = _CFLT.LockMeasureFloor;
                    MainCalc.IN.InUpperLockMeasureFloor = _CFLT.UpperLockMeasureFloor;
                }
                else
                {
                    MainCalc.IN.InLockType = "NoLock";

                    MainCalc.IN.InLockMeasure = -1;
                    MainCalc.IN.InUpperLockMeasure = -1;
                    MainCalc.IN.InLockMeasureFloor = -1;
                    MainCalc.IN.InUpperLockMeasureFloor = -1;
                }

                if (_CUPDB != null)
                {

                    MainCalc.IN.inDisplayBottomPart1 = _CUPDB.Kitum;
                    MainCalc.IN.inDisplayBottomPart2 = _CUPDB.Nerousta;
                    MainCalc.IN.inBottomPartSize = _CUPDB.BottomSize;
                    MainCalc.IN.inUpperPartType = _CUPDB.upperPartType;
                    MainCalc.IN.inUpperPartSize = _CUPDB.upperPartSize;


                }
                else
                {
                    MainCalc.IN.inDisplayBottomPart1 = false;
                    MainCalc.IN.inDisplayBottomPart2 = false;
                    MainCalc.IN.inBottomPartSize = 0;
                    MainCalc.IN.inUpperPartType = "ללא";
                    MainCalc.IN.inUpperPartSize = -1;

                }

                _TapiFrameCalc1();

            }







        }

        void _TapiFrameCalc1()
        {
            if (_TypeFrame != null)
            {


                if (_TypeFrame.WallType == "GV" && _frame.isHand == false)
                {


                    _frame.FlakhGV = true;
                    _frame.Save();

                }

                if (_TypeFrame.WallType == "BT" && _frame.isHand == false)
                {


                    _frame.FlakhGV = false;
                    _frame.Save();
                }


                flkh_gvs();


                if (_TypeFrame.AgroupOfDoorFrames == "Regular" || _TypeFrame.AgroupOfDoorFrames == "Pendel")
                {
                    HingesOpenWindow.IsEnabled = true;

                }
                else
                {
                    HingesOpenWindow.IsEnabled = false;
                }


                if (_TypeFrame.AgroupOfDoorFrames == "Blind")
                {
                    LockOpenWindow.IsEnabled = false;
                    rbRigth.IsEnabled = false;
                    rbleft.IsEnabled = false;
                }
                else
                {
                    LockOpenWindow.IsEnabled = true;
                }

                if (_TypeFrame.AgroupOfDoorFrames == "Pendel" || _TypeFrame.AgroupOfDoorFrames == "Blind")
                {
                    rbRigth.IsEnabled = false;
                    rbleft.IsEnabled = false;
                    rbleft.FontWeight = FontWeights.Normal;
                    rbRigth.FontWeight = FontWeights.Normal;
                }
                else
                {
                    rbRigth.IsEnabled = true;
                    rbleft.IsEnabled = true;
                }


                if (_TypeFrame.WallType != "BT")
                {
                    this.Mekasher = FindResource("langMekasher100").ToString();
                    this.Girong = FindResource("langGirong").ToString();

                }
                else if (_TypeFrame.WallType == "BT")
                {
                    this.Mekasher = FindResource("langMekashertahton").ToString();
                    this.Girong = FindResource("langStraight").ToString();
                }

                if (_TypeFrame.TypeOfDoorFrame == "Click" && _frame.isHand == false)
                {

                    rbThiknssIron1_25.IsChecked = true;
                }
                else if (_TypeFrame.AgroupOfDoorFrames == "Alpha" && _frame.isHand == false)
                {

                    rbThiknssIron1_5.IsChecked = true;
                }
                else if (_TypeFrame.AgroupOfDoorFrames != "Alpha" && _frame.isHand == false)
                {
                    rbThiknssIron1_25.IsChecked = true;
                }







            }
        }

        void flkh_gvs()
        {
            if (_frame.FlakhGV == true)
            {

                checkGevesFlach.IsChecked = true;


                MainCalc.IN.InGevesFlach = _frame.FlakhGV;
                checkGevesFlach.FontWeight = FontWeights.Bold;
            }
            else if (_frame.FlakhGV == false)
            {

                checkGevesFlach.IsChecked = false;


                MainCalc.IN.InGevesFlach = _frame.FlakhGV;
                checkGevesFlach.FontWeight = FontWeights.Normal;
            }
            else
            {
                checkGevesFlach.IsChecked = null;
            }
        }

        void _EnbEditBox(bool statu)
        {
            HingesOpenWindow.IsEnabled = statu;
            LockOpenWindow.IsEnabled = statu;
            btnPrisa.IsEnabled = statu;
            btnHalak.IsEnabled = statu;
            btnAdv.IsEnabled = statu;
            rbmegolvan.IsEnabled = statu;
            rbnerosta.IsEnabled = statu;
            rbThiknssIron1_25.IsEnabled = statu;
            rbThiknssIron1_5.IsEnabled = statu;
            TextBoxFrameWidth.IsEnabled = statu;
            TextBoxFrameHight.IsEnabled = statu;
            FrameThicknessBox.IsEnabled = statu;
            WallThicknessBox.IsEnabled = statu;
            rbRigth.IsEnabled = statu;
            rbleft.IsEnabled = statu;
            CheckBoxMekasher.IsEnabled = statu;
            RHSswitch.IsEnabled = statu;
            CheckBoxDoubleDoor.IsEnabled = statu;
            checkGevesFlach.IsEnabled = statu;
            btnPrintDirct.IsEnabled = statu;
            btnStikar.IsEnabled = statu;
            btnAmount.IsEnabled = statu;
            btnCopyNewFrame.IsEnabled = statu;
            btnView.IsEnabled = statu;
            tbPrintAmount.IsEnabled = statu;
            tbStickers.IsEnabled = statu;
            tbAmount.IsEnabled = statu;
            TextBoxFrameHightUnderFloor.IsEnabled = statu;
        }

        private void FrameHingeClick(object sender, RoutedEventArgs e)
        {


            TapiFrameHingeWindow TFH1 = new TapiFrameHingeWindow((_HingeFrame == null ? -1 : _HingeFrame.ID), _frame.ID, _frame.Height);


            TFH1.ShowDialog();
            _checkMode();
            if (_HingeFrame != null && MainCalc != null)
            {
                _HingeFrame = clsHingesFrames.FindByFrameID(_frame.ID);

                MainCalc.IN.InHingeAmount = _HingeFrame.HingeAmount;
                _fillHinge();

                MainCalc.EXECUTE();

                UpdateUI();
            }


            btnView_Click(null, null);
        }




        private void FrameLockClick(object sender, RoutedEventArgs e)
        {
            if (_frame == null)
            {
                return;
            }


            TapiFrameLockWindow wind3 = new TapiFrameLockWindow(_frame.ID, _frame.Height);

            wind3.ShowDialog();
            _checkMode();

            if (_CFLT != null && MainCalc != null)
            {
                _CFLT = clsFrameLockType.FindByFrameID(_frame.ID);



                MainCalc.IN.InLockType = _CFLT.LockType;

                MainCalc.IN.InLockMeasure = _CFLT.LockMeasure;
                MainCalc.IN.InUpperLockMeasure = _CFLT.UpperLockMeasure;
                MainCalc.IN.InLockMeasureFloor = _CFLT.LockMeasureFloor;
                MainCalc.IN.InUpperLockMeasureFloor = _CFLT.UpperLockMeasureFloor;



                MainCalc.EXECUTE();
                UpdateUI();
                btnView_Click(null, null);
            }


        }
        private void FramePrisaClick(object sender, RoutedEventArgs e)
        {
            if (_presa == null)
            {
                TapiFramePrisaWindow wind4 = new TapiFramePrisaWindow(_frame.ID, imagePath(MainCalc.OUT.OutimgCut1), MainCalc.IN.InFrameTypeName);
                wind4.ShowDialog();
            }
            else
            {
                TapiFramePrisaWindow wind4 = new TapiFramePrisaWindow(_presa.ID, _frame.ID, imagePath(MainCalc.OUT.OutimgCut1), MainCalc.IN.InFrameTypeName);
                wind4.ShowDialog();
            }



            if (MainCalc != null)
            {
                MainCalc.ExecutePrisa(_IDFrame);
                MainCalc.EXECUTE();

                UpdateUI();
            }
            btnView_Click(null, null);

        }
        private void FrameBottomPartClick(object sender, RoutedEventArgs e)
        {
            if (_frame != null && MainCalc != null)
            {
                TapiFrameBottomPartWindow wind5 = new TapiFrameBottomPartWindow(_frame.ID);
                wind5.ShowDialog();
                _CUPDB = clsFrameUpperPart.FindByFrameID(_frame.ID);
                MainCalc.IN.inDisplayBottomPart1 = _CUPDB.Kitum;
                MainCalc.IN.inDisplayBottomPart2 = _CUPDB.Nerousta;
                MainCalc.IN.inBottomPartSize = _CUPDB.BottomSize;
                MainCalc.IN.inUpperPartType = _CUPDB.upperPartType;
                MainCalc.IN.inUpperPartSize = _CUPDB.upperPartSize;
                upperPartLine();

                MainCalc.EXECUTE();
                UpdateUI();
            }
            btnView_Click(null, null);
        }
        private void FrameAdvancedClick(object sender, RoutedEventArgs e)
        {
            if (_advanced == null)
            {
                TapiFrameAdvancedWindow wind6 = new TapiFrameAdvancedWindow(_IDFrame);
                wind6.ShowDialog();
            }
            else
            {
                TapiFrameAdvancedWindow wind6 = new TapiFrameAdvancedWindow(_IDFrame, _advanced.ID);
                wind6.ShowDialog();
            }

            if (MainCalc != null)
            {

                MainCalc.EXECUTE();
                UpdateUI();
            }

            btnView_Click(null, null);

        }


        void _AddNewMode()
        {




            _frame = new clsFrames();

            _frame.OrderID = this._IDorder;
            _frame.Date = DateTime.Now;
            _frame.tbAmount = 1;

            if (_frame.Save())
            {

                _mode = MyMode.Update;
                this._IDFrame = _frame.ID;
                _HingeFrame = clsHingesFrames.FindByFrameID(_frame.ID);
                _order = clsOrders.Find(this._IDorder);
                MainCalc = new clsFrameMainCalculations(_frame.ID);

                _checkMode();


            }

        }

        void _updateMode()
        {



            PrisaSizeUpdateAndAdd();
            _frame = clsFrames.Find(this._IDFrame);
            _TypeFrame = clsFrameType.FindByFrameID(this._IDFrame);
            _order = clsOrders.Find(this._IDorder);
            _project = clsProjects.Find(_order.ProjectID);
            _customer = clsCustomers.Find(_project.iDcustomer);
            _HingeFrame = clsHingesFrames.FindByFrameID(_frame.ID);

            _CFLT = clsFrameLockType.FindByFrameID(_frame.ID);
            _CUPDB = clsFrameUpperPart.FindByFrameID(_frame.ID);
            _presa = clsPrisa.findbyFrameid(this._IDFrame);
            _advanced = clsFrameAdvanced.FindByFrameID(this._IDFrame);

        }

        void _checkMode()
        {

            switch (_mode)
            {
                case MyMode.AddNew:
                    _AddNewMode();
                    return;

                case MyMode.Update:
                    _updateMode();
                    return;


            }



        }
        void savePrisaSizeToDb()
        {
            if (CPS != null)
            {
                if (MainCalc != null)
                {
                    CPS.PRT1 = clsValidationData.TextToDecimal(MainCalc.OUT.OutPriseTest_Nitzav);
                    CPS.PRT2 = clsValidationData.TextToDecimal(MainCalc.OUT.OutPriseTest_Head);
                    CPS.PRT3 = clsValidationData.TextToDecimal(MainCalc.OUT.PRT3);
                    CPS.PRT4 = clsValidationData.TextToDecimal(MainCalc.OUT.PRT4);

                    CPS.Save();
                }
                else
                {
                    MessageBox.Show("err");
                }
            }
            else
            {
                MessageBox.Show("errror");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainCalc != null)
                MainCalc.EXECUTE();

            this.Close();

        }


        private void FramePrint(object sender, RoutedEventArgs e)
        {

            if (_frame != null)
            {
                _frame.Save();

                MainCalc.EXECUTE();
                UpdateUI();
                savePrisaSizeToDb();
                int stNum;
                stNum = clsSettings.CalcAmountPrintStikrsFrame((byte)_frame.tbStickers);

                if (string.IsNullOrEmpty(tbStickers.Text) || _frame.tbStickers <= 0)
                {
                    stNum *= _frame.tbAmount;
                }
                else
                {
                    if (int.TryParse(tbStickers.Text, out int resx))
                    {
                        stNum = resx;
                    }
                }

                clsPrintDirect.PrintFrame(fillDataToPrint(), clsSettings.CalcAmountPrintPaperFrame((byte)_frame.tbPrintAmount), stNum);

            }

            btnView_Click(null, null);

        }




        private void checkGevesFlach_Checked(object sender, RoutedEventArgs e)
        {
            if (_frame != null)
            {

                _frame.isHand = true;
                _frame.FlakhGV = true;


                _frame.Save();
                MainCalc.EXECUTE();
                UpdateUI();

            }

            //  btnView_Click(null, null);
        }

        private void CheckBoxDoubleDoor_Checked(object sender, RoutedEventArgs e)
        {


            if (_mode == MyMode.Update)
            {
                if (_frame != null && MainCalc != null)
                {

                    _frame.DoubleDoor = true;



                    if (_frame.Save())
                    {

                        MainCalc.IN.InDoubleDoor = _frame.DoubleDoor;
                        MainCalc.EXECUTE();
                        UpdateUI();
                    }

                }
            }

            //  btnView_Click(null, null);
        }

        private void RHSswitch_Checked(object sender, RoutedEventArgs e)
        {



            if (_mode == MyMode.Update)
            {
                if (_frame != null && MainCalc != null)
                {
                    _frame.RHS70 = true;



                    if (_frame.Save())
                    {

                        MainCalc.IN.InRHSswitch = _frame.RHS70;
                        MainCalc.EXECUTE();
                        UpdateUI();
                    }

                }
            }

            //  btnView_Click(null, null);
        }

        private void CheckBoxMekasher_Checked(object sender, RoutedEventArgs e)
        {



            if (_mode == MyMode.Update)
            {
                if (_frame != null)
                {
                    _frame.Meksher = true;
                    _frame.FrameUnderFloor = 0;
                    TextBoxFrameHightUnderFloor.Text = "0";

                    if (_frame.Save())
                    {

                        MainCalc.IN.InMekasher = _frame.Meksher;
                        TextBoxFrameHightUnderFloor.IsEnabled = false;
                        TextBoxFrameHightUnderFloor_KeyUp(null, null);
                        MainCalc.EXECUTE();

                        UpdateUI();
                    }
                }
            }

            //  btnView_Click(null, null);

        }

        private void FrameTypeClick(object sender, RoutedEventArgs e)
        {
            TapiFrameTypeWindow wind1 = new TapiFrameTypeWindow(_IDFrame);
            wind1.ShowDialog();
            _checkMode();
            if (_frame != null && MainCalc != null && _TypeFrame != null)
            {
                _TypeFrame = clsFrameType.FindByFrameID(_frame.ID);
                MainCalc.IN.InFrameTypeTest1 = _TypeFrame.AgroupOfDoorFrames;
                MainCalc.IN.InFrameTypeTest2 = _TypeFrame.TypeOfDoorFrame;
                MainCalc.IN.InFrameTypeTest3 = _TypeFrame.LevelType;
                MainCalc.IN.InFrameTypeTest4 = _TypeFrame.WallType;
                MainCalc.IN.InGevesFlach = _frame.FlakhGV;
                MainCalc.IN.InFrameTypeName = _TypeFrame.AgroupOfDoorFrames + _TypeFrame.TypeOfDoorFrame + _TypeFrame.LevelType + _TypeFrame.WallType;
                _frame.FrameType = MainCalc.IN.InFrameTypeName;
                _frame.isHand = false;


                if (_TypeFrame.WallType == "BT")
                {
                    _frame.Meksher = false;
                    _frame.FrameUnderFloor = 50;

                }
                else

                {
                    _frame.Meksher = true;
                    _frame.FrameUnderFloor = 0;
                }
                _frame.Save();
                MainCalc.EXECUTE();
                UpdateUI();




                if (_frame.FrameType == "")
                {
                    _EnbEditBox(false);
                }
                else
                {
                    _EnbEditBox(true);
                    MainCalc.EXECUTE();
                    UpdateUI();
                }

                rbmegolvan.IsEnabled = true;
                if (_mode == MyMode.Update)
                {
                    _frame.MaterialType = "Megolvan";

                    if (_frame.Save())
                    {
                        MainCalc.IN.InFrameMetal = _frame.MaterialType;
                        MainCalc.EXECUTE();
                        UpdateUI();

                    }
                }

                TextBoxFrameHightUnderFloor_KeyUp(null, null);
            }


            btnView_Click(null, null);
        }

        private void wpfTapiFrameScreen_Loaded(object sender, RoutedEventArgs e)
        {



            if (_mode == MyMode.Update)
            {
                if (MainCalc == null)
                {
                    return;
                }
                MainCalc.EXECUTE();
                UpdateUI();


                if (_frame != null)
                {
                    if (_frame.FrameType == "")
                    {
                        _EnbEditBox(false);
                    }
                    else
                    {
                        _EnbEditBox(true);
                    }
                }
            }
            else
            {
                _EnbEditBox(false);
            }





            if (txtFrameNumber.Text == "0")
            {
                txtFrameNumber.Text = "";
            }

        }





        int _ValidateInputs(string txt)
        {

            if (int.TryParse(txt, out int result))
            {

                return result;
            }
            else
            {

                return 0;
            }
        }



        private void rbRigth_Checked(object sender, RoutedEventArgs e)
        {
            if (rbRigth.IsChecked == true)
            {

                if (_mode == MyMode.Update)
                {

                    _frame.Direction = rbRigth.Tag.ToString();

                    if (_frame.Save())
                    {
                        if (MainCalc != null)
                        {
                            MainCalc.IN.InDirection = _frame.Direction;
                            MainCalc.EXECUTE();
                        }
                        UpdateUI();

                    }

                }


            }
            //   btnView_Click(null, null);

        }

        private void rbleft_Checked(object sender, RoutedEventArgs e)
        {
            if (MainCalc == null && _frame == null)
            {
                return;
            }


            if (rbleft.IsChecked == true)
            {

                if (_mode == MyMode.Update)
                {

                    _frame.Direction = rbleft.Tag.ToString();

                    if (_frame.Save())
                    {
                        if (MainCalc != null)
                        {
                            MainCalc.IN.InDirection = _frame.Direction;
                            MainCalc.EXECUTE();
                        }
                        UpdateUI();

                    }

                }


            }
            //  btnView_Click(null, null);

        }

        private void rbmegolvan_Checked(object sender, RoutedEventArgs e)
        {

            if (rbmegolvan.IsChecked == true)
            {



                if (_mode == MyMode.Update)
                {
                    _frame.MaterialType = "Megolvan";

                    if (_frame.Save())
                    {
                        MainCalc.IN.InFrameMetal = _frame.MaterialType;
                        MainCalc.EXECUTE();
                        UpdateUI();

                    }
                }
            }

        }

        private void rbnerosta_Checked(object sender, RoutedEventArgs e)
        {
            if (rbnerosta.IsChecked == true)
            {

                if (_mode == MyMode.Update)
                {
                    _frame.MaterialType = "Norsta";

                    if (_frame.Save())
                    {
                        MainCalc.IN.InFrameMetal = _frame.MaterialType;
                        MainCalc.EXECUTE();
                        UpdateUI();
                    }
                }
            }
        }

        private void rbThiknssIron1_5_Checked(object sender, RoutedEventArgs e)
        {
            _frame.isHand = true;
            _frame.Save();
            if (rbThiknssIron1_5.IsChecked == true)
            {


                if (_mode == MyMode.Update)
                {
                    _frame.IronThickness = 1.5f;

                    if (_frame.Save())
                    {
                        MainCalc.IN.InFrameMetalWidth = _frame.IronThickness;
                        MainCalc.EXECUTE();
                        UpdateUI();
                    }
                }
            }
        }

        private void rbThiknssIron1_25_Checked(object sender, RoutedEventArgs e)
        {
            _frame.isHand = true;
            _frame.Save();
            if (rbThiknssIron1_25.IsChecked == true)
            {


                if (_mode == MyMode.Update)
                {
                    _frame.IronThickness = 1.25f;

                    if (_frame.Save())
                    {
                        MainCalc.IN.InFrameMetalWidth = _frame.IronThickness;
                        MainCalc.EXECUTE();
                        UpdateUI();
                    }
                }
            }
        }

        private void CheckBoxMekasher_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_mode == MyMode.Update)
            {
                if (_frame != null)
                {
                    _frame.Meksher = false;
                    if (_TypeFrame.WallType == "BT")
                    {
                        _frame.FrameUnderFloor = 50;
                        TextBoxFrameHightUnderFloor.Text = "50";
                    }
                    if (_frame.Save())
                    {
                        TextBoxFrameHightUnderFloor.IsEnabled = true;
                        MainCalc.IN.InMekasher = _frame.Meksher;
                        TextBoxFrameHightUnderFloor_KeyUp(null, null);
                        MainCalc.EXECUTE();

                        UpdateUI();
                    }

                }
            }
            //    btnView_Click(null, null);
        }

        private void RHSswitch_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_mode == MyMode.Update)
            {
                if (_frame != null && MainCalc != null)
                {
                    _frame.RHS70 = false;



                    if (_frame.Save())
                    {

                        MainCalc.IN.InRHSswitch = _frame.RHS70;
                        MainCalc.EXECUTE();
                        UpdateUI();
                    }
                }

            }
            //   btnView_Click(null, null);

        }

        private void CheckBoxDoubleDoor_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_mode == MyMode.Update)
            {

                if (_frame != null && MainCalc != null)
                {

                    _frame.DoubleDoor = false;



                    if (_frame.Save())
                    {

                        MainCalc.IN.InDoubleDoor = _frame.DoubleDoor;
                        MainCalc.EXECUTE();
                        UpdateUI();
                    }

                }
            }


            //   btnView_Click(null, null);
        }









        clsParameterForPrint fillDataToPrint()
        {
            if (_frame != null)
            {
                clsParameterForPrint PrintPage = new clsParameterForPrint();
                PrintPage.Width = MainCalc.OUT.OutFrameWidth;
                PrintPage.imgMain1 = imagePath(MainCalc.OUT.OutimgMain1).ToString();
                PrintPage.PWidth = MainCalc.OUT.OutFramePlatzWidth.ToString();
                PrintPage.Hight = MainCalc.OUT.OutFrameHight.ToString();
                PrintPage.Lock1 = MainCalc.OUT.OutFrameLock1;
                PrintPage.Lock2 = MainCalc.OUT.OutFrameLock2;
                
                PrintPage.FrameThickness = MainCalc.OUT.OutFrameThickness.ToString();
                PrintPage.WallThickness = MainCalc.OUT.OutWallThickness.ToString();
                PrintPage.FrameHightTop = MainCalc.OUT.outUpperPartSize;
                PrintPage.Comments = _frame.Notes == "" ? "Empty" : _frame.Notes;
                PrintPage.CommentStikrs = _frame.FactoryNotes == "" ? "Empty" : _frame.FactoryNotes;
                PrintPage.RHS70 = _frame.RHS70.ToString();
                PrintPage.bottomPart = MainCalc.OUT.outBottomPartTestDisplay;
                PrintPage.A1 = MainCalc.OUT.outPresa_A1;
                PrintPage.A2 = MainCalc.OUT.outPresa_A2;
                PrintPage.B1 = MainCalc.OUT.outPresa_B1;
                PrintPage.B2 = MainCalc.OUT.outPresa_B2;
                PrintPage.F1 = MainCalc.OUT.outPresa_F1;
                PrintPage.F2 = MainCalc.OUT.outPresa_F2;
                PrintPage.G1 = MainCalc.OUT.outPresa_G1;
                PrintPage.G2 = MainCalc.OUT.outPresa_G2;
                PrintPage.C1 = MainCalc.OUT.outPresa_C1;
                PrintPage.C2 = MainCalc.OUT.outPresa_C2;
                PrintPage.D1 = MainCalc.OUT.outPresa_D1;
                PrintPage.D2 = MainCalc.OUT.outPresa_D2;
                PrintPage.E1 = MainCalc.OUT.outPresa_E1;
                PrintPage.E2 = MainCalc.OUT.outPresa_E2;
                PrintPage.FlakhGvs = MainCalc.OUT.FlakhGvs;
                PrintPage.PAmood = imagePath(MainCalc.OUT.OutimgProfile1).ToString();
                PrintPage.Pprisa1 = imagePath(MainCalc.OUT.OutimgCut1).ToString();
                PrintPage.Pprisa2 = imagePath(MainCalc.OUT.OutimgCut2).ToString();
                PrintPage.PUpeerLock = imagePath(MainCalc.OUT.OutimgLock2).ToString();
                PrintPage.ImgCut11 = imagePath(MainCalc.OUT.OutimgCut11).ToString();
                PrintPage.ImgCut22 = imagePath(MainCalc.OUT.OutimgCut22).ToString();
                PrintPage.FH1H = this.FrameHinge1H.Content.ToString();
                PrintPage.FH2H = this.FrameHinge2H.Content.ToString();
                PrintPage.FH3H = this.FrameHinge3H.Content.ToString();
                PrintPage.FH4H = this.FrameHinge4H.Content.ToString();
                PrintPage.FH5H = this.FrameHinge5H.Content.ToString();
                PrintPage.FH6H = this.FrameHinge6H.Content.ToString();
                PrintPage.FH7H = this.FrameHinge7H.Content.ToString();
                PrintPage.customer1 = _customer.CompanyName;
                PrintPage.test1 = MainCalc.IN.InFrameTypeTest1 == "Alpha" ? "Empty" : "Alpha"; //chck is alpha
                PrintPage.FrameType1 = MainCalc.OUT.OutFrameTypeNameText4;
                PrintPage.OrderNo1 = _order.OrderNumber <= 0 ? "Empty" : _order.OrderNumber.ToString();
                PrintPage.ID = _frame.DoorNumber <= 0 ? "Empty" : _frame.DoorNumber.ToString();
                PrintPage.DoorIdentification1 = _frame.DoorIdentity == "" ? "Empty" : _frame.DoorIdentity;
                PrintPage.Metal1 = MainCalc.OUT.OutFrameMetal_Nitzav;
                PrintPage.MetalWidth1 = MainCalc.OUT.OutFrameMetalWidth_Nitzav;
                PrintPage.LockType1 = translockName(MainCalc.IN.InLockType);

                PrintPage.Direction1 = MainCalc.OUT.OutDirection;
                PrintPage.Location1 = _frame.Location;
                PrintPage.ProjectName1 = _project.projectName;
                PrintPage.Date111 = _frame.Date.ToString("yyyy-MM-dd");
                PrintPage.PlatzFrameSize11 = MainCalc.OUT.PlatzFrameSize;
                PrintPage.FrameSize11 = MainCalc.OUT.FrameSize;
                PrintPage.imgLock1 = imagePath(MainCalc.OUT.OutimgLock1).ToString();
                PrintPage.ImgUpperPart = imagePath(MainCalc.OUT.OutimgProfile2).ToString();
                PrintPage.PRS1 = MainCalc.OUT.OutPrisaHight_Nitzav;
                PrintPage.PRS2 = MainCalc.OUT.outPrisaHightHead;
                PrintPage.PRS3 = MainCalc.OUT.outPrisaHight3;

                PrintPage.AA1 = MainCalc.OUT.outPresa_AA1;
                PrintPage.AA2 = MainCalc.OUT.outPresa_AA2;
                PrintPage.BB1 = MainCalc.OUT.outPresa_BB1;
                PrintPage.BB2 = MainCalc.OUT.outPresa_BB2;
                PrintPage.CC1 = MainCalc.OUT.outPresa_CC1;
                PrintPage.CC2 = MainCalc.OUT.outPresa_CC2;
                PrintPage.DD1 = MainCalc.OUT.outPresa_DD1;
                PrintPage.DD2 = MainCalc.OUT.outPresa_DD2;
                PrintPage.EE1 = MainCalc.OUT.outPresa_EE1;
                PrintPage.EE2 = MainCalc.OUT.outPresa_EE2;
                PrintPage.FF1 = MainCalc.OUT.outPresa_FF1;
                PrintPage.FF2 = MainCalc.OUT.outPresa_FF2;
                PrintPage.GG1 = MainCalc.OUT.outPresa_GG1;
                PrintPage.GG2 = MainCalc.OUT.outPresa_GG2;

                PrintPage.PRT3 = MainCalc.OUT.PRT3;
                PrintPage.PRA3 = MainCalc.OUT.PRA3;
                PrintPage.PRM3 = MainCalc.OUT.PRM3;
                PrintPage.PRF3 = MainCalc.OUT.PRF3;
                PrintPage.ketum = MainCalc.OUT.ketum;


                PrintPage.WallThickness2 = MainCalc.OUT.OutWallThickness2;
                PrintPage.FrameThickness2 = MainCalc.OUT.OutFrameThickness2;
                PrintPage.PRF1 = MainCalc.OUT.OutFrameMetal_Nitzav;
                PrintPage.PRM1 = MainCalc.OUT.OutFrameMetalWidth_Nitzav;


                if ((MainCalc.IN.InFrameTypeName == "PendelStandartBT" || MainCalc.IN.InFrameTypeName == "PendelStandartGV") && _frame.DoubleDoor)
                {
                    PrintPage.PRA1 = (_frame.tbAmount * 2).ToString();

                }
                else if (MainCalc.IN.InFrameTypeName == "PendelStandartBT" || MainCalc.IN.InFrameTypeName == "PendelStandartGV")
                {
                    PrintPage.PRA1 = _frame.tbAmount.ToString();
                }
                else
                {
                    PrintPage.PRA1 = (_frame.tbAmount * 2).ToString();

                }


                PrintPage.PRT1 = MainCalc.OUT.OutPriseTest_Nitzav;
                PrintPage.PRT4 = MainCalc.OUT.PRT4;
                PrintPage.FinalAmount = _frame.tbAmount.ToString();
                PrintPage.PRF2 = MainCalc.OUT.OutFrameMetal_Nitzav;
                PrintPage.PRM2 = MainCalc.OUT.OutFrameMetalWidth_Nitzav;
                PrintPage.PRA2 = _frame.tbAmount.ToString();
                PrintPage.PRT2 = MainCalc.OUT.OutPriseTest_Head;
                PrintPage.FramePlatzHight = MainCalc.OUT.FramePlatzHight;
                PrintPage.IsDoubelDoor = _frame.DoubleDoor.ToString(); // MainCalc.OUT.outIsDoubelDoor;
                PrintPage.Mekasher = CheckBoxMekasher.Content.ToString(); // MainCalc.OUT.outIsDoubelDoor;
                PrintPage.slipcanlock = MainCalc.OUT.slipcanlock;
                PrintPage.HiddenOil = _HiddenOil();
                PrintPage.HingeConection = HingeConection();
                PrintPage.HingeType = HingeType();
                PrintPage.TypeOfHingeText = TypeOfHingeText();
                PrintPage.imageHinge = imageHinge();
                PrintPage.PivotImgHing = PivotImgHing();
                PrintPage.PivotImgMain = PivotImgHing();
                PrintPage.imgFramePocketTopProfile = MainCalc.OUT.imgFramePocketTopProfile;
                PrintPage.FrameSlideinMainimg = MainCalc.OUT.FrameSlideinMainimg;
                PrintPage.PocketWidth = MainCalc.OUT.PocketWidth;
                PrintPage.SlidingTotalWidth = MainCalc.OUT.SlidingTotalWidth;
                PrintPage.LightWidth = MainCalc.OUT.LightWidth;
                PrintPage.SlidingTotalHight = MainCalc.OUT.SlidingTotalHight;
                PrintPage.LightHight = MainCalc.OUT.LightHight;

                return PrintPage;
            }
            return null;
        }

        string PivotImgHing()
        {
            if (_frame != null && (_frame.FrameType == "PivotStandartBT" || _frame.FrameType == "PivotKantTiachBT" || _frame.FrameType == "PivotStandartGV"
                || _frame.FrameType == "PivotKantTiachGV" || _frame.FrameType == "PivotClick"
                ))
            {
                return "True";

            }
            else
            {
                return "Empty";
            }

        }


        string HingeType()
        {
            if (_HingeFrame != null && (_TypeFrame.AgroupOfDoorFrames == "Regular" || _TypeFrame.AgroupOfDoorFrames == "Pendel"))
            {
                return _HingeFrame.HingeType;


            }
            else
            {
                return "Empty";
            }
        }
        string HingeConection()
        {
            if (_HingeFrame != null && (_TypeFrame.AgroupOfDoorFrames == "Regular" || _TypeFrame.AgroupOfDoorFrames == "Pendel"))
            {
                if (_HingeFrame.HingeConnection == "Hole")
                {
                    return "מוברג";
                }
                else if (_HingeFrame.HingeConnection == "Soldering")
                {
                    return "מרותך";
                }
                else
                {
                    return "Empty";
                }
            }
            else
            {
                return "Empty";
            }


        }
        string imageHinge()
        {
            if (_HingeFrame != null && (_TypeFrame.AgroupOfDoorFrames == "Regular" || _TypeFrame.AgroupOfDoorFrames == "Pendel"))
            {
                if (_HingeFrame.HingeType == "4X4" && _HingeFrame.HingeConnection == "Soldering" && _HingeFrame.HingeMetal == "Megolvan")
                {
                    return "Empty";
                }

                if (_HingeFrame.HingeType == "4X3.5")
                {
                    return clsImageLibrary.HingeType1;
                }
                else
                {
                    return clsImageLibrary.HingeType2;
                }


            }
            else
            {
                return "Empty";
            }


        }
        string TypeOfHingeText()
        {
            string hing = "ציר";
            if (_HingeFrame != null && (_TypeFrame.AgroupOfDoorFrames == "Regular" || _TypeFrame.AgroupOfDoorFrames == "Pendel"))
            {

                if (_HingeFrame.HingeConnection == "Soldering" && _HingeFrame.HingeMetal == "Megolvan" && _HingeFrame.HingeType == "4X4")
                {
                    return "Empty";
                }
                else if (_HingeFrame.HingeConnection == "Hole")
                {
                    hing += " מוברג ";
                }
                else if (_HingeFrame.HingeConnection == "Soldering")
                {
                    hing += "";
                }
                else
                {

                    if (_HingeFrame.HingeConnection == "Hole")
                    {
                        hing += " מוברג ";
                    }
                    else if (_HingeFrame.HingeConnection == "Soldering")
                    {
                        hing += "";
                    }
                    else
                    {
                        return "Empty";
                    }
                }

                if (_HingeFrame.HingeMetal == "Megolvan")
                {
                    hing += "";
                }
                else if (_HingeFrame.HingeMetal == "Norsta")
                {
                    hing += " נירוסטה ";
                }
                else
                {
                    hing += "";
                }
                if (_HingeFrame.HingeType == "4X4")
                {
                    hing += "";
                }
                else if (_HingeFrame.HingeType != "4X4")
                {
                    hing += " 3.5*4 ";
                }
                return hing;
            }
            else
            {
                return "Empty";
            }


        }

        string _HiddenOil()
        {
            if (_advanced != null)
            {


                if (_advanced.HiddenOil)
                {
                    return "run";

                }
                else
                {
                    return "";
                }
            }

            return "";
        }


        private void btnView_Click(object sender, RoutedEventArgs e)
        {

            if (_frame != null && MainCalc != null)
            {
                _frame.Save();


                MainCalc.EXECUTE();
                UpdateUI();
                savePrisaSizeToDb();
                crvPrintFrameshow.ViewerCore.Zoom(75);
                crvPrintFrameshow.ViewerCore.ReportSource = new clsSetParameterToReport(fillDataToPrint()).returnReport();


                //new WpfPrintView(fillDataToPrint()).ShowDialog();
            }
        }

        private void TextBoxFrameWidth_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBoxFrameWidth_KeyUp(null, null);
        }





















        private void WallThicknessBox_KeyUp(object sender, KeyEventArgs e)
        {

            if (_mode == MyMode.Update)
            {

                _frame.WallThickness = _ValidateInputs(WallThicknessBox.Text);


                if (_frame.Save())
                {

                    MainCalc.IN.InWallThicknessBox = _frame.WallThickness;

                    MainCalc.EXECUTE();
                    UpdateUI();


                }


            }
        }

        private void WallThicknessBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FrameThicknessBox.Text != "")
            {
                WallThicknessBox.IsEnabled = false;
                FrameThicknessBox.IsEnabled = true;
            }
            else if (WallThicknessBox.Text != "")
            {
                WallThicknessBox.IsEnabled = true;
                FrameThicknessBox.IsEnabled = false;
            }
            else
            {
                WallThicknessBox.IsEnabled = true;
                FrameThicknessBox.IsEnabled = true;
            }
        }

        private void FrameThicknessBox_KeyUp(object sender, KeyEventArgs e)
        {

            if (_mode == MyMode.Update)
            {

                _frame.FrameThickness = _ValidateInputs(FrameThicknessBox.Text);

                if (_frame.Save())
                {
                    if (MainCalc != null)
                    {
                        MainCalc.IN.InFrameThicknessBox = _frame.FrameThickness;

                        MainCalc.EXECUTE();
                        UpdateUI();
                    }
                }

            }

        }

        private void FrameThicknessBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (FrameThicknessBox.Text != "")
            {
                WallThicknessBox.IsEnabled = false;
                FrameThicknessBox.IsEnabled = true;
            }
            else if (WallThicknessBox.Text != "")
            {
                WallThicknessBox.IsEnabled = true;
                FrameThicknessBox.IsEnabled = false;
            }
            else
            {
                WallThicknessBox.IsEnabled = true;
                FrameThicknessBox.IsEnabled = true;
            }
        }

        private void TextBoxFrameHight_KeyUp(object sender, KeyEventArgs e)
        {

            if (_mode == MyMode.Update)
            {

                _frame.Height = _ValidateInputs(TextBoxFrameHight.Text);

                if (_frame.Save())
                {
                    MainCalc.IN.InFrameHight = _frame.Height;
                    MainCalc.EXECUTE();
                    UpdateUI();

                }




            }
        }

        private void TextBoxFrameWidth_KeyUp(object sender, KeyEventArgs e)
        {

            if (_mode == MyMode.Update)
            {

                _frame.Width = _ValidateInputs(TextBoxFrameWidth.Text);

                if (_frame.Save())
                {
                    MainCalc.IN.InFrameWidth = _frame.Width;
                    MainCalc.EXECUTE();
                    UpdateUI();
                }


            }
        }

        private void TextBoxFrameHightUnderFloor_KeyUp(object sender, KeyEventArgs e)
        {


            if (_mode == MyMode.Update && _frame != null)
            {
                int.TryParse(TextBoxFrameHightUnderFloor.Text, out int r);
                _frame.FrameUnderFloor = r;


                if (_frame.Save())
                {

                    if (MainCalc != null)
                    {
                        MainCalc.IN.InFrameHightUnderFloor = _frame.FrameUnderFloor;
                        MainCalc.EXECUTE();
                        UpdateUI();
                    }
                }

            }


        }

        private void txtLocation_KeyUp(object sender, KeyEventArgs e)
        {


            if (_mode == MyMode.Update)
            {

                _frame.Location = txtLocation.Text;



                if (_frame.Save())
                {

                    //MainCalc.EXECUTE();
                    //UpdateUI();
                }
            }

        }

        private void txtNote_KeyUp(object sender, KeyEventArgs e)
        {

            if (_mode == MyMode.Update)
            {

                _frame.FactoryNotes = txtNote.Text;



                if (_frame.Save())
                {


                    //MainCalc.EXECUTE();
                    //UpdateUI();
                }

            }

        }

        private void box_CommentFactory_KeyUp(object sender, KeyEventArgs e)
        {

            if (_mode == MyMode.Update)
            {

                _frame.Notes = box_CommentFactory.Text;



                if (_frame.Save())
                {


                    //MainCalc.EXECUTE();
                    //UpdateUI();
                }

            }

        }

        private void txtFrameNumber_KeyUp(object sender, KeyEventArgs e)
        {



            if (clsFrames.FindByOrderframeNumber(txtFrameNumber.Text, this._IDorder))
            {
                popNumberDoorCopy.IsOpen = true;

                popNumberDoorCopy.PlacementTarget = txtFrameNumber;

                txtFrameNumber.Background = Brushes.Red;


            }
            else
            {
                popNumberDoorCopy.IsOpen = false;
                txtFrameNumber.Background = Brushes.White;
            }






        }

        private void txtDoorIdentity_KeyUp(object sender, KeyEventArgs e)
        {

            if (_mode == MyMode.Update)
            {

                _frame.DoorIdentity = txtDoorIdentity.Text;



                if (_frame.Save())
                {
                    //MainCalc.EXECUTE();
                    //UpdateUI();
                }

            }

        }

        private void checkGevesFlach_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_frame != null)
            {
                _frame.isHand = true;
                _frame.FlakhGV = false;


                _frame.Save();
                UpdateUI();
            }

            // btnView_Click(null, null);
        }

        private void checkGevesFlach_MouseLeave(object sender, MouseEventArgs e)
        {
            if (MainCalc != null)
            {
                MainCalc.EXECUTE();
                UpdateUI();
            }
        }

        private void tbPrintAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (_mode == MyMode.Update)
            {

                _frame.tbPrintAmount = _ValidateInputs(tbPrintAmount.Text);
                _frame.Save();

            }
            UpdateUI();
        }

        private void tbPrintAmount_MouseLeave(object sender, MouseEventArgs e)
        {
            tbPrintAmount_KeyUp(null, null);

        }

        private void tbStickers_KeyUp(object sender, KeyEventArgs e)
        {
            if (_mode == MyMode.Update)
            {

                _frame.tbStickers = _ValidateInputs(tbStickers.Text);
                _frame.Save();

            }

            UpdateUI();

        }

        private void tbStickers_MouseLeave(object sender, MouseEventArgs e)
        {
            tbStickers_KeyUp(null, null);
        }

        private void tbAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (_mode == MyMode.Update)
            {



                _frame.tbAmount = _ValidateInputs(tbAmount.Text);
                _frame.Save();
                UpdateUI();
            }
        }


        private void btnCopyNewFrame_Click(object sender, RoutedEventArgs e)
        {


            if (_frame != null)
            {
                _frame.Save();
                MainCalc.EXECUTE();
                UpdateUI();
                savePrisaSizeToDb();
                this._IDFrame = _frame.CopyFrame();

                _frame = clsFrames.Find(this._IDFrame);
                _TypeFrame = clsFrameType.FindByFrameID(this._IDFrame);
                MainCalc = new clsFrameMainCalculations(this._IDFrame);
                MainCalc.IN.InFrameMetalWidth = _frame.IronThickness;
                MainCalc.IN.InFrameMetal = _frame.MaterialType;
                MainCalc.EXECUTE();

                UpdateUI();

                popNumberDoorCopy.IsOpen = true;
                popNumberDoorCopy.PlacementTarget = txtFrameNumber;
                txtFrameNumber.Text = "";
                txtFrameNumber.Background = Brushes.Red;
                txtFrameNumber.Focus();
            }



        }

        private void btnStikar_Click(object sender, RoutedEventArgs e)
        {
            MainCalc.EXECUTE();

            UpdateUI();
            savePrisaSizeToDb();
            if (_frame != null)
            {
                CrpStikarsFrame crpStikarsFrame = new CrpStikarsFrame();
                crpStikarsFrame = new clsSetParameterToStikarsReport(fillDataToPrint()).returnReport();
                crpStikarsFrame.PrintOptions.PrinterName = clsSettings.GetData().StikersPrinterName;

                int numstk;

                numstk = clsSettings.CalcAmountPrintStikrsFrame((byte)_frame.tbStickers);

                if (string.IsNullOrEmpty(tbStickers.Text) || _frame.tbStickers <= 0)
                {
                    numstk *= _frame.tbAmount;
                }
                else
                {

                    if (int.TryParse(tbStickers.Text, out int res))
                    {
                        numstk = res;
                    }

                }
                crpStikarsFrame.PrintToPrinter(numstk, false, 0, 0);

            }


            btnView_Click(null, null);
        }

        private void btnAmount_Click(object sender, RoutedEventArgs e)
        {


            UpdateUI();
            if (_frame != null)
            {
                _frame.Save();

                MainCalc.EXECUTE();
                UpdateUI();
                savePrisaSizeToDb();

                clsPrintDirect.PrintFrameNiar(fillDataToPrint(), clsSettings.CalcAmountPrintPaperFrame((byte)_frame.tbPrintAmount));

            }

        }
        void PTIpopUpMsgStatus(object sender, bool st)
        {


            switch (((TextBox)sender).Name)
            {
                case "TextBoxFrameWidth":
                    popTextBoxTF.IsOpen = st;
                    break;
                case "TextBoxFrameHight":
                    popTextBoxTF.IsOpen = st;
                    break;
                case "TextBoxFrameHightUnderFloor":
                    popTextBoxTF.IsOpen = st;
                    break;
                case "FrameThicknessBox":
                    popTextBoxTF.IsOpen = st;
                    break;
                case "WallThicknessBox":
                    popTextBoxTF.IsOpen = st;
                    break;
                case "txtFrameNumber":
                    popTextBoxTF.IsOpen = st;
                    break;
                case "tbPrintAmount":
                    popTextBoxTF.IsOpen = st;
                    break;
                case "tbStickers":
                    popTextBoxTF.IsOpen = st;
                    break;
                case "tbAmount":
                    popTextBoxTF.IsOpen = st;
                    break;

                default:
                    popTextBoxTF.IsOpen = false;
                    break;
            }


        }

        private void PTIpopUpMsg(object sender, TextCompositionEventArgs e)
        {
            popTextBoxTF.IsOpen = false;
            popTextBoxTF.PlacementTarget = null;
            popTextBoxTF.PlacementTarget = ((TextBox)sender);

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Handled)
            {
                PTIpopUpMsgStatus(sender, true);
            }
            else
            {
                PTIpopUpMsgStatus(sender, false);
            }
        }

        private void box_CommentFactory_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (_IDFrame == 3)
            {
                new MainTapi().Show();

            }
            else
            {
                if (_frame != null && (_frame.DoorNumber == 0 || _TypeFrame == null
                   || _frame.Height == 0 || _frame.Width == 0)
                    )
                {
                    if (MessageBox.Show("Be careful\r\nYou will lose the entered data!!!", "warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {



                        if (_CUPDB != null)
                        {
                            clsFrameUpperPart.Delete(_CUPDB.ID);
                        }
                        if (_CFLT != null)
                        {
                            clsFrameLockType.Delete(_CFLT.ID);
                        }

                        if (_TypeFrame != null)
                        {
                            clsFrameType.Delete(_TypeFrame.ID);
                        }

                        if (_HingeFrame != null)
                        {
                            clsHingesFrames.Delete(_HingeFrame.ID);
                        }
                        if (_frame != null)
                        {
                            clsFrames.Delete(_frame.ID);
                        }
                    }
                    else
                    {
                        return;
                    }
                }



                new wpfOrderPage(this._IDorder).Show();

            }


        }



        private void rbThiknssIron2_Checked(object sender, RoutedEventArgs e)
        {
            _frame.isHand = true;
            _frame.Save();
            if (rbThiknssIron2.IsChecked == true)
            {


                if (_mode == MyMode.Update)
                {
                    _frame.IronThickness = 2f;

                    if (_frame.Save())
                    {
                        MainCalc.IN.InFrameMetalWidth = _frame.IronThickness;
                        MainCalc.EXECUTE();
                        UpdateUI();
                    }
                }
            }
        }



        private void txtFrameNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!clsFrames.FindByOrderframeNumber(txtFrameNumber.Text, this._IDorder))
            {
                if (_mode == MyMode.Update)
                {
                    _frame.DoorNumber = _ValidateInputs(txtFrameNumber.Text);
                    if (_frame.Save())
                    {

                        MainCalc.EXECUTE();
                        UpdateUI();
                    }
                }


            }
            else
            {
                popNumberDoorCopy.PlacementTarget = txtFrameNumber;
                popNumberDoorCopy.IsOpen = true;
                txtFrameNumber.Background = Brushes.Red;

            }



        }


        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
            MainCalc.EXECUTE();
            savePrisaSizeToDb();

            _frameTemp = clsFrames.Find(_IDFrame);

            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (_frame != null)
                {
                    _frame.clear();
                    _frame.Save();
                    MainCalc.EXECUTE();
                    UpdateUI();
                    WallThicknessBox.Text = "";
                    FrameThicknessBox.Text = "";
                    btnView_Click(null, null);
                    btnBackDB.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnBackDB_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (_frameTemp != null)
                {
                    _frame = _frameTemp;
                    _frame.Save();
                    MainCalc.EXECUTE();
                    UpdateUI();
                    btnView_Click(null, null);
                    btnBackDB.Visibility = Visibility.Hidden;
                }
            }
        }



        private void Window_Closed(object sender, CancelEventArgs e)
        {
            if (MainCalc != null)
            {

                MainCalc.EXECUTE();
                savePrisaSizeToDb();
            }
            //if (_IDFrame == 3)
            //{
            //    new MainTapi().Show();

            //    this.Close();

            //}
            //else
            //{
            if (_frame != null && _frame.DoorNumber == 0 || _TypeFrame == null
               || _frame.Height == 0 || _frame.Width == 0
                )
            {
                if (MessageBox.Show("Be careful\r\nYou will lose the entered data!!!", "warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {



                    if (_CUPDB != null)
                    {
                        clsFrameUpperPart.Delete(_CUPDB.ID);
                    }
                    if (_CFLT != null)
                    {
                        clsFrameLockType.Delete(_CFLT.ID);
                    }

                    if (_TypeFrame != null)
                    {
                        clsFrameType.Delete(_TypeFrame.ID);
                    }

                    if (_HingeFrame != null)
                    {
                        clsHingesFrames.Delete(_HingeFrame.ID);
                    }
                    if (_frame != null)
                    {
                        clsFrames.Delete(_frame.ID);
                    }
                }
                else
                {
                    return;
                }
            }





            //}
        }
    }
}
