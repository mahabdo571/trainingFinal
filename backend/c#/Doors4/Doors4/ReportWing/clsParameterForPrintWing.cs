using Doors4.Projects;
using Doors4.Report;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Doors4.ReportWing
{
    public class clsParameterForPrintWing
    {
        clsSetParameterToReportWing _Pprint;

        static string _imagePath = clsSettings.GetData().ImagePath;
        public clsParameterForPrintWing(clsSetParameterToReportWing p)
        {
            _Pprint = p;
        }
        public CrpWing returnReport()
        {
            var newCulture = CultureInfo.CreateSpecificCulture("us");//for lang report

            Thread.CurrentThread.CurrentUICulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;
            CrpWing CRreport =  new CrpWing();
            //img

            _checkIfEmptyImage("R_imgDoorFinal", _Pprint.R_imgDoorwood, CRreport);
            _checkIfEmptyImage("R_imgKant", _Pprint.R_imgKant, CRreport);
            _checkIfEmptyImage("R_imgWindo", _Pprint.R_imgWindo, CRreport);
            _checkIfEmptyImage("R_imgTris", _Pprint.R_imgTris, CRreport);
            _checkIfEmptyImage("R_imgWindwosCenterLine", _Pprint.R_imgWindwosCenterLine, CRreport);
            _checkIfEmptyImage("R_TrisLines", _Pprint.R_TrisLines, CRreport);
            _checkIfEmptyImage("imagPolSide", _Pprint.R_imagPolSide, CRreport);
            _checkIfEmptyImage("R_ImagLock", _Pprint.R_ImagLock, CRreport);
            _checkIfEmptyImage("imagTrisProfile", _Pprint.R_imagTrisProfile, CRreport);
            _checkIfEmptyImage("PicProfileTrisNormal", _Pprint.PicProfileTrisNormal, CRreport);
            _checkIfEmptyImage("WingEmptyMainImg", _Pprint.WingEmptyMainImg, CRreport);


            _checkIfEmptyImage("R_UpDoorOpen", _Pprint.R_UpDoorOpen, CRreport);
            _checkIfEmptyImage("R_picLittleHandleRU", _Pprint.R_picLittleHandleRU, CRreport);
            _checkIfEmptyImage("R_picLittleHandleRD", _Pprint.R_picLittleHandleRD, CRreport);
            _checkIfEmptyImage("R_picLittleHandleLU", _Pprint.R_picLittleHandleLU, CRreport);
            _checkIfEmptyImage("R_picLittleHandleLD", _Pprint.R_picLittleHandleLD, CRreport);
            _checkIfEmptyImage("DDside", _Pprint.DDside, CRreport);


            //txt
            _checkIfEmptytext("Double2", _Pprint.Double2, CRreport);
            _checkIfEmptytext("Double1", _Pprint.Double1, CRreport);
            _checkIfEmptytext("PapeClassification", _Pprint.PapeClassification, CRreport);
          

            _checkIfEmptytext("DimeterWindo", _Pprint.DimeterWindo, CRreport);
            _checkIfEmptytext("HiddenOiNormal", _Pprint.HiddenOiNormal, CRreport);
            _checkIfEmptytext("HiddenOijaloi", _Pprint.HiddenOijaloi, CRreport);
            _checkIfEmptytext("DoorAmount", _Pprint.R_DoorAmount, CRreport);
            _checkIfEmptytext("R_picLittleSupport", _Pprint.R_picLittleSupportDN, CRreport);
            _checkIfEmptytext("R_picLittleSupport2", _Pprint.R_picLittleSupportUP, CRreport);

            _checkIfEmptytext("T2", _Pprint.R_TrisHight, CRreport);
            _checkIfEmptytext("TypeTris", System.IO.Path.GetFileNameWithoutExtension(_Pprint.R_TrisLines), CRreport);
            _checkIfEmptytext("TrisType", _Pprint.R_TrisType, CRreport);
            _checkIfEmptytext("TypeWindo", System.IO.Path.GetFileNameWithoutExtension(_Pprint.R_imgWindwosCenterLine), CRreport);
            _checkIfEmptytext("T1", _Pprint.R_TrisWidth1, CRreport);
            _checkIfEmptytext("TT1", _Pprint.R_TrisWidth1, CRreport);
            _checkIfEmptytext("T4", _Pprint.R_TrisPositionFromHandle, CRreport);
            _checkIfEmptytext("T3", _Pprint.R_TrisPositionFromBottom, CRreport);
            _checkIfEmptytext("TrisComment", _Pprint.R_TrisComment, CRreport);
            _checkIfEmptytext("WindowWidth1", _Pprint.R_WindowWidth1, CRreport);
            _checkIfEmptytext("WindowWidth2", _Pprint.R_WindowWidth1, CRreport);
            _checkIfEmptytext("WindowHight", _Pprint.R_WindowHight1, CRreport);
            _checkIfEmptytext("WindowPos1", _Pprint.R_WindowUpPosition, CRreport);
            _checkIfEmptytext("WindowPos2", _Pprint.R_WindowPosFromHand, CRreport);
            _checkIfEmptytext("WindowComment", _Pprint.R_WindowComment, CRreport);
            _checkIfEmptytext("WindowTypecheck", _Pprint.R_WindowTypecheck, CRreport);
            _checkIfEmptytext("WindowCircleHight", _Pprint.R_WindowCircleHight, CRreport);
            _checkIfEmptytext("WindoINcenter", _Pprint.R_WindoINcenter, CRreport);
            _checkIfEmptytext("TrisINcenter", _Pprint.R_TrisINcenter, CRreport);

            _checkIfEmptytext("FinalWidth", _Pprint.R_DoorFinalWidth, CRreport);
            _checkIfEmptytext("FinalHight", _Pprint.R_DoorFinalHight, CRreport);
            _checkIfEmptytext("MetalWidth", _Pprint.R_MetalWidth, CRreport);
            _checkIfEmptytext("MetalHight", _Pprint.R_MetalHight, CRreport);
            _checkIfEmptytext("WoodHight", _Pprint.R_DoorWoodHight, CRreport);
            _checkIfEmptytext("WoodWidth", _Pprint.R_DoorWoodWidth, CRreport);
            _checkIfEmptytext("woodPlazWidth", woodPlazWidthA(_Pprint.R_woodPletzWidth), CRreport);
            _checkIfEmptytext("WoodPlatzWidth2", _Pprint.R_woodPletzWidth, CRreport);
            _checkIfEmptytext("AorHole", _Pprint.AorHole, CRreport);
            _checkIfEmptytext("PoleHight", _Pprint.R_PoleHight1, CRreport);
            _checkIfEmptytext("R_Test1", _Pprint.R_Test1, CRreport);
            _checkIfEmptytext("R_Test3", _Pprint.R_Test3, CRreport);

            //Hinges
            _checkIfEmptytext("R_HingH1", _Pprint.R_HingH1, CRreport);
            _checkIfEmptytext("R_HingH2", _Pprint.R_HingH2, CRreport);
            _checkIfEmptytext("R_HingH3", _Pprint.R_HingH3, CRreport);
            _checkIfEmptytext("R_HingH4", _Pprint.R_HingH4, CRreport);
            _checkIfEmptytext("R_HingH5", _Pprint.R_HingH5, CRreport);
            _checkIfEmptytext("R_HingH6", _Pprint.R_HingH6, CRreport);
            _checkIfEmptytext("R_HingH7", _Pprint.R_HingH7, CRreport);
            _checkIfEmptytext("R_HingType", _Pprint.R_HingType, CRreport);

            _checkIfEmptytext("R_HingAmount", _Pprint.R_HingAmount, CRreport);

            _checkIfEmptytext("R_HingUpperMidHin", _Pprint.R_HingUpperMidHin, CRreport);
            _checkIfEmptytext("R_HingHingeSize", _Pprint.R_HingHingeSize, CRreport);
            _checkIfEmptytext("R_HingHeightToBottomHinge", _Pprint.R_HingHeightToBottomHinge, CRreport);
            _checkIfEmptytext("AlphaPoleParam", _Pprint.R_AlphaPoleParam, CRreport);

            //------end hinge


            //picec wood 
            _checkIfEmptytext("SupportHinge1Pos", _Pprint.R_SupportHinge1Pos, CRreport);
            _checkIfEmptytext("SupportHinge1Hight", _Pprint.R_SupportHinge1Hight, CRreport);
            _checkIfEmptytext("SupportHinge1Width", _Pprint.R_SupportHinge1Width, CRreport);
            _checkIfEmptytext("woodSpeacilCasesHingeUP", _Pprint.R_woodSpeacilCasesHingeUP, CRreport);

            _checkIfEmptytext("SupportHinge2Hight", _Pprint.R_SupportHinge2Hight, CRreport);
            _checkIfEmptytext("SUpportHinge2Width", _Pprint.R_SUpportHinge2Width, CRreport);
            _checkIfEmptytext("SupportHinge2Pos", _Pprint.R_SupportHinge2Pos, CRreport);
            _checkIfEmptytext("R_woodSpeacilCasesHingeDN", _Pprint.R_woodSpeacilCasesHingeDN, CRreport);


            _checkIfEmptytext("SupportLockRightPos", _Pprint.R_SupportLockRightPos, CRreport);
            _checkIfEmptytext("SuppoerLockRightWidth", _Pprint.R_SuppoerLockRightWidth, CRreport);
            _checkIfEmptytext("SupportLockRightHight", _Pprint.R_SupportLockRightHight, CRreport);
            _checkIfEmptytext("R_woodBehalaLock", _Pprint.R_woodBehalaLock, CRreport);


            _checkIfEmptytext("SupportLockPos", _Pprint.R_SupportLockPos, CRreport);
            _checkIfEmptytext("SupportLockHight", _Pprint.R_SupportLockHight, CRreport);
            _checkIfEmptytext("SUpportLockWidth", _Pprint.R_SUpportLockWidth, CRreport);
            _checkIfEmptytext("R_woodLockBasic", _Pprint.R_woodLockBasic, CRreport);

            _checkIfEmptytext("R_woodUpeerLock", _Pprint.R_woodUpeerLock, CRreport);

            //lock
            _checkIfEmptytext("R_LockActive", _Pprint.R_LockActive, CRreport);
            _checkIfEmptytext("LockHight1", _Pprint.R_LockMeasure, CRreport);
            _checkIfEmptytext("LockHight2", _Pprint.R_UpperLockMeasure, CRreport);
            _checkIfEmptytext("R_UpeerLockActive", _Pprint.R_UpeerLockActive, CRreport);


            _checkIfEmptytext("Atmer", atmerTrans(_Pprint.R_AtmerIsActive), CRreport);
            _checkIfEmptytext("R_makhzerShemen", _Pprint.R_makhzerShemen, CRreport);
            _checkIfEmptytext("R_outmakhzerShemenGaloi", _Pprint.R_outmakhzerShemenGaloi, CRreport);

            _checkIfEmptytext("HandleCommentstk", _Pprint.R_HandleComment, CRreport);
            _checkIfEmptytext("SkatchName3", _Pprint.R_Scatch3Text, CRreport);
            _checkIfEmptytext("WoodLowerPlatzHight", _Pprint.R_WoodLowerPlatzHight, CRreport);
            _checkIfEmptytext("FactoryComments", _Pprint.R_FactoryComments, CRreport);
            _checkIfEmptytext("HandicapPosition", _Pprint.R_HandicapPosition, CRreport);
            _checkIfEmptytext("R_SupportHelpless", _Pprint.R_SupportHelpless, CRreport);
            _checkIfEmptytext("StainlessSize2", _Pprint.R_StainlessSize2, CRreport);
            _checkIfEmptytext("StainlessSize1", _Pprint.R_StainlessSize1, CRreport);
            _checkIfEmptytext("StainlessLine", NORSTAtYPE(_Pprint.R_StainlessLine), CRreport);
            _checkIfEmptytext("R_Direction", _Pprint.R_Direction, CRreport);




            //stikrs
            _checkIfEmptytext("R_ProjectName", _Pprint.R_ProjectName, CRreport);
            _checkIfEmptytext("R_customer", _Pprint.R_customer, CRreport);
            _checkIfEmptytext("R_OrderNo", _Pprint.R_OrderNo, CRreport);
            _checkIfEmptytext("R_ID", _Pprint.R_ID, CRreport);
            _checkIfEmptytext("R_Directionstik", Direction(_Pprint.R_Direction) , CRreport);
            _checkIfEmptytext("R_DoorIdentification", _Pprint.R_DoorIdentification, CRreport);
            _checkIfEmptytext("R_WingType", _Pprint.R_WingType, CRreport);
            _checkIfEmptytext("R_Comments", _Pprint.R_Comments, CRreport);
            _checkIfEmptytext("R_Location", _Pprint.R_Location, CRreport);
            _checkIfEmptytext("R_Colorwing", _Pprint.R_Colorwing, CRreport);
            _checkIfEmptytext("R_MesorSofet", FinalSize(), CRreport);
            _checkIfEmptytext("R_MeterialWidth", _Pprint.R_MeterialWidth, CRreport);
            _checkIfEmptytext("R_WingDeptSize", _Pprint.R_WingDeptSize, CRreport);
            _checkIfEmptytext("R_Date11", _Pprint.R_Date11, CRreport);
            _checkIfEmptytext("R_Injection", _Pprint.R_Injection, CRreport);
            _checkIfEmptytext("R_MesorPlatez", MesorPlatez(), CRreport);
            _checkIfEmptytext("R_MesorMetal", MesorMetal(), CRreport);
            _checkIfEmptytext("DDWidthFormica2", _Pprint.DDWidthFormica2 , CRreport);



            string MesorPlatez()
            {
                if (chechtxt(_Pprint.R_PletzWidth) || chechtxt(_Pprint.R_PletzHight))
                {
                    return "Hidd";
                }
                else
                {
                    return _Pprint.R_PletzWidth + "X" + _Pprint.R_PletzHight;
                }
            }

            string MesorMetal()
            {
                if (_Pprint.R_Test2 == "A")
                {
                    return "Hidd";
                }
                else if (chechtxt(_Pprint.R_MetalWidth) || chechtxt(_Pprint.R_MetalHight))
                {
                    return "Hidd";
                }
                else
                {
                    return _Pprint.R_MetalWidth + "X" + _Pprint.R_MetalHight;
                }
            }

            bool chechtxt(string Text)
            {
                if (Text == "Empty" || string.IsNullOrEmpty(Text) || Text == "-1" || Text == "0")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            //     kaant
            _checkIfEmptytext("BUK1", _Pprint. BUK1 , CRreport);
            _checkIfEmptytext("BUK2", _Pprint. BUK2 , CRreport);
            _checkIfEmptytext("BUK3", _Pprint. BUK3 , CRreport);
            _checkIfEmptytext("BUK4", _Pprint. BUK4 , CRreport);
            _checkIfEmptytext("BUK5", _Pprint. BUK5 , CRreport);
            _checkIfEmptytext("BUK6", _Pprint. BUK6 , CRreport);
            _checkIfEmptytext("BUK7", _Pprint. BUK7 , CRreport);
            _checkIfEmptytext("BUK8", _Pprint. BUK8 , CRreport);
            _checkIfEmptytext("BUK9", _Pprint. BUK9 , CRreport);
            _checkIfEmptytext("BUK10", _Pprint.BUK10, CRreport);
            _checkIfEmptytext("BUK11", _Pprint.BUK11, CRreport);
            _checkIfEmptytext("BUK12", _Pprint.BUK12, CRreport);
            _checkIfEmptytext("BUK13", _Pprint.BUK13, CRreport);
            _checkIfEmptytext("BUK14", _Pprint.BUK14, CRreport);
            _checkIfEmptytext("BUK15", _Pprint.BUK15, CRreport);
          
            //if (_Pprint.R_Test2 == "F")
            //{
            //    _checkIfEmptytext("Woodbuk2", _Pprint.R_Woodbuk2, CRreport);
            //}
            //else
            //{
            //    _checkIfEmptytext("Woodbuk2", "Hidd", CRreport);
            //}
          
            //if (_Pprint.R_Test2 == "A")
            //{
            
            //    _checkIfEmptytext("WoodBukA", _Pprint.R_Woodbuk2, CRreport);
            //}
            //else
            //{
            //    _checkIfEmptytext("WoodBukA", _Pprint.R_WoodBukA, CRreport);
            //}


      
            
            _checkIfEmptytext("SkatchName2", "מידת עצים", CRreport);
            _checkIfEmptytext("SkatchName1", "מידה סופית", CRreport);
          //  _checkIfEmptytext("WoodBuk1A", woodPlazWidthA(_Pprint.R_WoodBuk1), CRreport);


            _checkIfEmptytext("HandleComment", HandleComment(_Pprint.R_HandleComment), CRreport);



            return  CRreport;
        }


        string FinalSize()
        {
            if (!string.IsNullOrEmpty(_Pprint.R_DoorFinalHight))
                return _Pprint.R_DoorFinalWidth + " X " + _Pprint.R_DoorFinalHight;
            else
                return "Hidd";
        }


        string Direction(string txt)
        {
            if (txt == "Right_A")
            {
                return Application.Current.FindResource("lang_btnDirectionRight_AWing").ToString();

            }
            else if (txt == "Right_K")
            {
             
                return Application.Current.FindResource("lang_btnDirectionRight_KWing").ToString();

            }
            else if (txt == "Left_A")
            {
                return Application.Current.FindResource("lang_btnDirectionLeft_AWing").ToString();
           
            }
            else if (txt == "Left_K")
            {
            
                return Application.Current.FindResource("lang_btnDirectionLeft_KWing").ToString();
            }
            else if (txt == "Left")
            {
                return Application.Current.FindResource("lang_btnDirectionLWing").ToString();
            }
            else if (txt == "Right")
            {
                return Application.Current.FindResource("lang_btnDirectionRWing").ToString();
            }
            else
            {
                return "";
            }

        }

        string woodPlazWidthA(string txt)
        {
            if (string.IsNullOrEmpty(_Pprint.R_Test2) || _Pprint.R_Test2 =="F")
            {
                return "Hidd";
            }
            else { 
                return txt; 
            }
              
        }
        string NORSTAtYPE(string TXT)
        {

            switch (TXT)
            {
                case "NoBand":
                    return "-1";
                case "Norsta2Side":
                    return Application.Current.FindResource("Report_lang_Norsta2Side").ToString();

                case "NorstaPullSide":
                    return Application.Current.FindResource("Report_lang_NorstaPullSide").ToString();


                case "NorstaPushSide":
                    return Application.Current.FindResource("Report_lang_NorstaPushSide").ToString();

                default:
                    return "-1";


            }

        }

        string HandleComment(string txt)
        {
            string ImagLock = System.IO.Path.GetFileNameWithoutExtension(_Pprint.R_ImagLock);

            if (ImagLock != "WingLock1")
            {
                return txt + " " + locknametype( System.IO.Path.GetFileNameWithoutExtension(_Pprint.R_ImagLock));

            }
            else if (txt == "-1" || txt == "שהרבני 60" || txt == "פאניק")
            {
                return "Hidd";

            }
            else
            {
                return txt;
            }

        }

        string locknametype(string txt)
        {
            switch (txt)
            {
                case "WingLock2":
                    return Application.Current.FindResource("Report_lang_WingLock2").ToString();

                case "WingLock3":
                    return Application.Current.FindResource("Report_lang_WingLock3").ToString();

                case "WingLock4":
                    return Application.Current.FindResource("Report_lang_WingLock4").ToString();

                case "WingLock5":
                    return Application.Current.FindResource("Report_lang_WingLock5").ToString();

                case "WingLock6":
                    return Application.Current.FindResource("Report_lang_WingLock6").ToString();

                case "WingLock7":
                    return Application.Current.FindResource("Report_lang_WingLock7").ToString();

                case "WingLock8":
                    return Application.Current.FindResource("Report_lang_WingLock8").ToString();

                default:
                    return "";


            }

        }
        string atmerTrans(string txt)
        {
            return txt == "False" ? "False" : Application.Current.FindResource("lang_cbAtmerWing").ToString();
        }



        void _checkIfEmptyImage(string ParameterInReport, string ImagePath, CrpWing Report)
        {

            try
            {

                if (System.IO.Path.GetFileNameWithoutExtension(ImagePath) != "Empty" || string.IsNullOrEmpty(ImagePath))
                {


                    Report.SetParameterValue(ParameterInReport, _imagePath + $@"WingBMP\{System.IO.Path.GetFileNameWithoutExtension(ImagePath)}.bmp");

                }
                else
                {


                    Report.SetParameterValue(ParameterInReport, "Hidd");
                }
            }

            catch (Exception ex)
            {
                

                clsSettings.SetEventLogMsg(ex.Message , "CLS_clsParameterForPrintWing__FUNCTION_NAME__checkIfEmptyImage", EventLogEntryType.Error);

            }

        }

        void _checkIfEmptytext(string ParameterInReport, string Text, CrpWing Report)
        {


            if (string.IsNullOrEmpty(Text) || Text == "-1")
            {
                Report.SetParameterValue(ParameterInReport, "Hidd");


            }
            else
            {
                Report.SetParameterValue(ParameterInReport, Text);
            }
        }

    }
}
