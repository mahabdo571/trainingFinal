using Doors4.ReportWing;
using SharaLogic;
using SharaLogic.Calculations;
using SharaLogic.WingCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Doors4.Wing
{
    /// <summary>
    /// Interaction logic for ucView.xaml
    /// </summary>
    public partial class ucView : UserControl
    {
        public event Action<clsSetParameterToReportWing> OnCalculationComplete;



        protected virtual void CalculationComplete(clsSetParameterToReportWing ClsOUTWing)
        {
            Action<clsSetParameterToReportWing> hand = OnCalculationComplete; ;
            if (hand != null)
            {
                hand(ClsOUTWing);
            }
        }



        clsMainWingCalc _MainCalc;
        int _WingeID;
        public ucView()
        {
            InitializeComponent();
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

        public void LoadUC(int WingeID)
        {
            _WingeID = WingeID;
            _MainCalc = new clsMainWingCalc(_WingeID);


            _MainCalc.EXECUTE();




            if (OnCalculationComplete != null)
            {
                CalculationComplete(_FillParameterToReport());
            }


        }


        public void UPDATEUIReport(int WingeID)
        {
            _WingeID = WingeID;
            _MainCalc = new clsMainWingCalc(_WingeID);
            _MainCalc.EXECUTE();
            crvPrintWingv.ViewerCore.Zoom(75);
            crvPrintWingv.ViewerCore.ReportSource = new clsParameterForPrintWing(_FillParameterToReport()).returnReport();

            if (OnCalculationComplete != null)
            {
                CalculationComplete(_FillParameterToReport());
            }

        }






        clsSetParameterToReportWing _FillParameterToReport()
        {

            clsSetParameterToReportWing p = new clsSetParameterToReportWing();

            p.R_imgDoorwood = _MainCalc.OUT.outimgDoorWood;
            p.R_imgKant = _MainCalc.OUT.imgWoodProfilecal;

            p.R_imgWindo = _MainCalc.OUT.Windoimg;
            p.R_imgTris = _MainCalc.OUT.Trisimg;


            p.R_TrisLines = _MainCalc.OUT.TrisLines;
            p.R_imgWindwosCenterLine = _MainCalc.OUT.outimgWindwosCenterLine;


            p.R_DoorFinalWidth = _MainCalc.OUT.outDoorFinalWidth.ToString();
            p.R_DoorFinalHight = _MainCalc.OUT.outDoorFinalHight.ToString();



            p.R_DoorWoodHight = _MainCalc.OUT.outDoorWoodHight.ToString();
            p.R_DoorWoodWidth = _MainCalc.OUT.outDoorWoodWidth.ToString();

            p.R_TrisHight = _MainCalc.OUT.outTrisHight.ToString();
            p.R_TrisWidth1 = _MainCalc.OUT.outTrisWidth1.ToString();
            p.R_TrisPositionFromHandle = _MainCalc.OUT.outTrisPositionFromHandle.ToString();
            p.R_TrisPositionFromBottom = _MainCalc.OUT.outTrisPositionFromBottom.ToString();
            p.R_TrisComment = _MainCalc.OUT.outTrisComment;
            p.R_WindowWidth1 = _MainCalc.OUT.outWindowWidth1;
            p.R_WindowHight1 = _MainCalc.OUT.outWindowHight1.ToString();
            p.R_WindowUpPosition = _MainCalc.OUT.outWindowUpPosition.ToString();
            p.R_WindowPosFromHand = _MainCalc.OUT.outWindowPosFromHand.ToString();
            p.R_WindowComment = _MainCalc.OUT.outWindowComment.ToString();
            p.R_WindowTypecheck = _MainCalc.OUT.outWindowTypecheck.ToString();
            p.R_WindowCircleHight = _MainCalc.OUT.outWindowCircleHight;
            p.R_WindoINcenter = _MainCalc.OUT.outWindoINcenter.ToString();
            p.R_TrisType = _MainCalc.OUT.outTrisType.ToString();
            p.R_TrisINcenter = _MainCalc.OUT.outTrisINcenter.ToString();

            p.R_PletzHight = _MainCalc.OUT.outPletzHight.ToString();
            p.R_PletzWidth = _MainCalc.OUT.outPletzWidth.ToString();
            p.R_MetalHight = _MainCalc.OUT.outMetalHight.ToString();
            p.R_MetalWidth = _MainCalc.OUT.outMetalWidth.ToString();
            p.R_woodPletzWidth = _MainCalc.OUT.outwoodPletzWidth.ToString();
            p.AorHole = _MainCalc.OUT.AorHole;
            p.R_imagPolSide = _MainCalc.OUT.outimagPolSide;
            p.R_PoleHight1 = _MainCalc.OUT.PoleHight1.ToString();
            p.R_Test1 = _MainCalc.OUT.Test1;
            p.R_Test3 = _MainCalc.OUT.Test3;

            p.R_HingH1 = _MainCalc.OUT.outHingH1;
            p.R_HingH2 = _MainCalc.OUT.outHingH2;
            p.R_HingH3 = _MainCalc.OUT.outHingH3;
            p.R_HingH4 = _MainCalc.OUT.outHingH4;
            p.R_HingH5 = _MainCalc.OUT.outHingH5;
            p.R_HingH6 = _MainCalc.OUT.outHingH6;
            p.R_HingH7 = _MainCalc.OUT.outHingH7;
            p.R_HingType = _MainCalc.OUT.outHingType;
            p.R_HingAmount = _MainCalc.OUT.outHingAmount;
            p.R_HingUpperMidHin = _MainCalc.OUT.outHingUpperMidHin;
            p.R_HingHingeSize = _MainCalc.OUT.outHingHingeSize;
            p.R_HingHeightToBottomHinge = _MainCalc.OUT.outHingHeightToBottomHinge;
            //peces wood
            p.R_SupportHinge1Pos = _MainCalc.OUT.outwoodSpeacilCasesHingeUPLocation;
            p.R_SupportHinge1Hight = _MainCalc.OUT.outwoodSpeacilCasesHingeUPHeight;
            p.R_SupportHinge1Width = _MainCalc.OUT.outwoodSpeacilCasesHingeUPWidth;
            p.R_woodSpeacilCasesHingeUP = _MainCalc.OUT.outwoodSpeacilCasesHingeUP;

            p.R_SupportHinge2Hight = _MainCalc.OUT.outwoodSpeacilCasesHingeDNHeight;
            p.R_SUpportHinge2Width = _MainCalc.OUT.outwoodSpeacilCasesHingeDNWidth;
            p.R_SupportHinge2Pos = _MainCalc.OUT.outwoodSpeacilCasesHingeDNLocation;
            p.R_woodSpeacilCasesHingeDN = _MainCalc.OUT.outwoodSpeacilCasesHingeDN;

            p.R_SupportLockRightPos = _MainCalc.OUT.outwoodBehalaLockLocation;
            p.R_SuppoerLockRightWidth = _MainCalc.OUT.outwoodBehalaLockWidth;
            p.R_SupportLockRightHight = _MainCalc.OUT.outwoodBehalaLockHeight;
            p.R_woodBehalaLock = _MainCalc.OUT.outwoodBehalaLock;

            p.R_SUpportLockWidth = _MainCalc.OUT.outwoodLockBasicWidth;
            p.R_SupportLockHight = _MainCalc.OUT.outwoodLockBasicHeight;
            p.R_SupportLockPos = _MainCalc.OUT.outwoodLockBasicLocation;
            p.R_woodLockBasic = _MainCalc.OUT.outwoodLockBasic;

            p.R_woodUpeerLock = _MainCalc.OUT.outwoodUpeerLock;
            p.R_LockActive = _MainCalc.OUT.outLockActive;
            p.R_LockMeasure = _MainCalc.OUT.outLockMeasure;
            p.R_LockType = _MainCalc.OUT.outLockType;
            p.R_UpperLockMeasure = _MainCalc.OUT.outUpperLockMeasure;
            p.R_UpeerLockActive = _MainCalc.OUT.outUpeerLockActive;
            p.R_AtmerIsActive = _MainCalc.OUT.AtmerIsActive;
            p.R_makhzerShemen = _MainCalc.OUT.outmakhzerShemen;
            p.R_outmakhzerShemenGaloi = _MainCalc.OUT.outmakhzerShemenGaloi;
            p.R_HandleComment = _MainCalc.OUT.outHandleComment;
            p.R_Scatch3Text = _MainCalc.OUT.Scatch3Text;
            p.R_Lockimg = _MainCalc.OUT.Lockimg;
            p.R_WoodLowerPlatzHight = _MainCalc.OUT.outWoodLowerPlatzHight;
            p.R_AlphaPoleParam = _MainCalc.OUT.outAlphaPoleParam;
            p.R_FactoryComments = _MainCalc.OUT.outFactoryComments;
            p.R_HandicapPosition = _MainCalc.OUT.outHandicapPosition;
            p.R_SupportHelpless = _MainCalc.OUT.outSupportHelpless;
            p.R_StainlessSize2 = _MainCalc.OUT.outStainlessSize2;
            p.R_StainlessSize1 = _MainCalc.OUT.outStainlessSize1;
            p.R_StainlessLine = _MainCalc.OUT.outStainlessLine;

            p.R_UpDoorOpen = _MainCalc.OUT.outUpDoorOpen;
            p.R_picLittleSupportUP = _MainCalc.OUT.outpicLittleSupportUP;
            p.R_picLittleSupportDN = _MainCalc.OUT.outpicLittleSupportDN;
            p.R_picLittleHandleLD = _MainCalc.OUT.outpicLittleHandleLD;
            p.R_picLittleHandleLU = _MainCalc.OUT.outpicLittleHandleLU;
            p.R_picLittleHandleRD = _MainCalc.OUT.outpicLittleHandleRD;
            p.R_picLittleHandleRU = _MainCalc.OUT.outpicLittleHandleRU;
            p.R_ImagLock = _MainCalc.OUT.outImagLock;
            p.R_WoodBukA = _MainCalc.OUT.outWoodBukA;
            p.R_Woodbuk2 = _MainCalc.OUT.outWoodbuk2;
            p.R_WoodBuk1 = _MainCalc.OUT.outWoodBuk1;
            p.R_Test2 = _MainCalc.OUT.outTest2;
            p.R_DoorAmount = _MainCalc.OUT.outDoorAmount;
            p.R_imagTrisProfile = _MainCalc.OUT.out_imagTrisProfile;
            p.HiddenOijaloi = _MainCalc.OUT.HiddenOijaloi;
            p.HiddenOiNormal = _MainCalc.OUT.HiddenOiNormal;
            p.DimeterWindo = _MainCalc.OUT.DimeterWindo;
            p.PicProfileTrisNormal = _MainCalc.OUT.PicProfileTrisNormal;
            p.Double1 = _MainCalc.OUT.Double2;
            p.Double2 = _MainCalc.OUT.Double1;
            p.DDside = _MainCalc.OUT.DDside;
            p.IDDoor = _MainCalc.OUT.IDDoor;
            p.BUK1 = _MainCalc.OUT.O_BUK1 ;
            p.BUK2 = _MainCalc.OUT.O_BUK2 ;
            p.BUK3 = _MainCalc.OUT.O_BUK3 ;
            p.BUK4 = _MainCalc.OUT.O_BUK4 ;
            p.BUK5 = _MainCalc.OUT.O_BUK5 ;
            p.BUK6 = _MainCalc.OUT.O_BUK6 ;
            p.BUK7 = _MainCalc.OUT.O_BUK7 ;
            p.BUK8 = _MainCalc.OUT.O_BUK8 ;
            p.BUK9 = _MainCalc.OUT.O_BUK9 ;
            p.BUK10 =_MainCalc.OUT.O_BUK10;
            p.BUK11 =_MainCalc.OUT.O_BUK11;
            p.BUK12 =_MainCalc.OUT.O_BUK12;
            p.BUK13= _MainCalc.OUT.O_BUK13;
            p.BUK14 =_MainCalc.OUT.O_BUK14;
            p.BUK15 = _MainCalc.OUT.O_BUK15;
            p.DDWidthFormica2 = _MainCalc.OUT.O_DDWidthFormica2;
            p.WingEmptyMainImg = _MainCalc.OUT.WingEmptyMainImg;



            //stikrs

            p.R_ProjectName = _MainCalc.OUT.outProjectName;
            p.R_customer = _MainCalc.OUT.outcustomer;
            p.R_OrderNo = _MainCalc.OUT.outOrderNo;
            p.R_ID = _MainCalc.OUT.outID;
            p.R_DoorIdentification = _MainCalc.OUT.outDoorIdentification;

            p.R_Direction = _MainCalc.OUT.outDirection;
            p.R_WingType = _MainCalc.OUT.outWingType;
            p.R_Comments = _MainCalc.OUT.outComments;
            p.R_Location = _MainCalc.OUT.outLocation;
            p.R_Colorwing = _MainCalc.OUT.outColorwing;
            p.R_MeterialWidth = _MainCalc.OUT.outMeterialWidth;
            p.R_WingDeptSize = _MainCalc.OUT.outWingDeptSize;
            p.R_Date11 = _MainCalc.OUT.outDate11;
            p.R_Injection = _MainCalc.OUT.outInjection;


            return p;
        }


    }
}
