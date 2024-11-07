using Doors4.Projects;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Doors4.Report
{
    public class clsSetParameterToReport
    {

        clsParameterForPrint _Pprint;

        static string _imagePath = clsSettings.GetData().ImagePath;

        public clsSetParameterToReport(clsParameterForPrint P)
        {
          
            _Pprint = P;
        }

        public CrpFrame returnReport()
        {
            var newCulture = CultureInfo.CreateSpecificCulture("us");//for lang report

            Thread.CurrentThread.CurrentUICulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;




            Report.CrpFrame CRreport = new Report.CrpFrame();
  

            //text 
            _checkIfEmptytext("LightHight", _Pprint.LightHight, CRreport);
            _checkIfEmptytext("SlidingTotalHight", _Pprint.SlidingTotalHight, CRreport);
            _checkIfEmptytext("LightWidth", _Pprint.LightWidth, CRreport);
            _checkIfEmptytext("SlidingTotalWidth", _Pprint.SlidingTotalWidth, CRreport);
            _checkIfEmptytext("PocketWidth", _Pprint.PocketWidth, CRreport);

            _checkIfEmptytext("PapeClassification", _Pprint.PapeClassification, CRreport);
            _checkIfEmptytext("PivotImgHing", _Pprint.PivotImgHing, CRreport);
            _checkIfEmptytext("PivotImgMain", _Pprint.PivotImgMain, CRreport);
            _checkIfEmptytext("slipcanlock", _Pprint.slipcanlock, CRreport);
            _checkIfEmptytext("HingeTypeM", _Pprint.HingeType, CRreport);
            _checkIfEmptytext("HingeConectionM", _Pprint.HingeConection, CRreport);
            _checkIfEmptytext("HiddenOil", _Pprint.HiddenOil, CRreport);
            _checkIfEmptytext("RHS70", _Pprint.RHS70, CRreport);
            _checkIfEmptytext("Mekasherstk", _Pprint.Mekasher, CRreport);
            _checkIfEmptytext("Width", _Pprint.Width, CRreport);
            _checkIfEmptytext("Pwidth", _Pprint.PWidth, CRreport);
            _checkIfEmptytext("Hight", _Pprint.Hight, CRreport);
            _checkIfEmptytext("Lock1", _Pprint.Lock1, CRreport);
            _checkIfEmptytext("Lock2", _Pprint.Lock2, CRreport);
            _checkIfEmptytext("txt_FrameThickness", _Pprint.FrameThickness, CRreport);
            _checkIfEmptytext("txt_WallThickness", _Pprint.WallThickness, CRreport);
            _checkIfEmptytext("txt_FrameHightTop", _Pprint.FrameHightTop, CRreport);
            _checkIfEmptytext("txt_Comments", _Pprint.Comments, CRreport);
            _checkIfEmptytext("CommentStikrs", _Pprint.CommentStikrs, CRreport);
            _checkIfEmptytext("txt_bottomPart", _Pprint.bottomPart, CRreport);
            _checkIfEmptytext("txtbottomPart2", _Pprint.bottomPart, CRreport);
            _checkIfEmptytext("A1", _Pprint.A1, CRreport);
            _checkIfEmptytext("A2", _Pprint.A2, CRreport);
            _checkIfEmptytext("B1", _Pprint.B1, CRreport);
            _checkIfEmptytext("B2", _Pprint.B2, CRreport);
            _checkIfEmptytext("C1", _Pprint.C1, CRreport);
            _checkIfEmptytext("C2", _Pprint.C2, CRreport);
            _checkIfEmptytext("D1", _Pprint.D1, CRreport);
            _checkIfEmptytext("D2", _Pprint.D2, CRreport);
            
            _checkIfEmptytext("E1", _Pprint.E1, CRreport);
            _checkIfEmptytext("E2", _Pprint.E2, CRreport);
            _checkIfEmptytext("F1", _Pprint.F1, CRreport);
            _checkIfEmptytext("F2", _Pprint.F2, CRreport);
            _checkIfEmptytext("G1", _Pprint.G1, CRreport);
            _checkIfEmptytext("G2", _Pprint.G2, CRreport);
            _checkIfEmptytext("FlakhGvs", _Pprint.FlakhGvs, CRreport);
            _checkIfEmptytext("customer1", _Pprint.customer1, CRreport);
            _checkIfEmptytext("IsAlpha", _Pprint.test1, CRreport);
            _checkIfEmptytext("FH1H", _Pprint.FH1H, CRreport);
            _checkIfEmptytext("FH2H", _Pprint.FH2H, CRreport);
            _checkIfEmptytext("FH3H", _Pprint.FH3H, CRreport);
            _checkIfEmptytext("FH4H", _Pprint.FH4H, CRreport);
            _checkIfEmptytext("FH5H", _Pprint.FH5H, CRreport);
            _checkIfEmptytext("FH6H", _Pprint.FH6H, CRreport);
            _checkIfEmptytext("FH7H", _Pprint.FH7H, CRreport);
            _checkIfEmptytext("FrameType1", _Pprint.FrameType1, CRreport);
            _checkIfEmptytext("OrderNo1", _Pprint.OrderNo1, CRreport);
            _checkIfEmptytext("ID1", _Pprint.ID, CRreport);
            _checkIfEmptytext("DoorIdentification1", _Pprint.DoorIdentification1, CRreport);
            _checkIfEmptytext("Metal1", _Pprint.Metal1, CRreport);
            _checkIfEmptytext("MetalWidth1", _Pprint.MetalWidth1, CRreport);
            _checkIfEmptytext("LockType1", _Pprint.LockType1, CRreport);
            _checkIfEmptytext("Direction1", _Pprint.Direction1, CRreport);
            _checkIfEmptytext("Location1", _Pprint.Location1, CRreport);
            _checkIfEmptytext("ProjectName1", _Pprint.ProjectName1, CRreport);
            _checkIfEmptytext("Date111", _Pprint.Date111, CRreport);
            _checkIfEmptytext("PlatzFrameSize11", _Pprint.PlatzFrameSize11, CRreport);
            _checkIfEmptytext("FrameSize11", _Pprint.FrameSize11, CRreport);
            _checkIfEmptytext("Amount", _Pprint.FinalAmount, CRreport);


            _checkIfEmptytext("AA1", _Pprint.AA1, CRreport);
            _checkIfEmptytext("AA2", _Pprint.AA2, CRreport);
            _checkIfEmptytext("BB1", _Pprint.BB1, CRreport);
            _checkIfEmptytext("BB2", _Pprint.BB2, CRreport);
            _checkIfEmptytext("CC1", _Pprint.CC1, CRreport);
            _checkIfEmptytext("CC2", _Pprint.CC2, CRreport);
            _checkIfEmptytext("DD1", _Pprint.DD1, CRreport);
            _checkIfEmptytext("DD2", _Pprint.DD2, CRreport);
            _checkIfEmptytext("EE1", _Pprint.EE1, CRreport);
            _checkIfEmptytext("EE2", _Pprint.EE2, CRreport);
            _checkIfEmptytext("FF1", _Pprint.FF1, CRreport);
            _checkIfEmptytext("FF2", _Pprint.FF2, CRreport);
            _checkIfEmptytext("GG1", _Pprint.GG1, CRreport);
            _checkIfEmptytext("GG2", _Pprint.GG2, CRreport);
            _checkIfEmptytext("txtFrameThickness2", _Pprint.FrameThickness2, CRreport);
            _checkIfEmptytext("txtWallThickness2", _Pprint.WallThickness2, CRreport);


            _checkIfEmptytext("PRS1", _Pprint.PRS1, CRreport);
            _checkIfEmptytext("PRF1", _Pprint.PRF1, CRreport);
            _checkIfEmptytext("PRM1", _Pprint.PRM1, CRreport);
            _checkIfEmptytext("PRA1", _Pprint.PRA1, CRreport);
            _checkIfEmptytext("PRT1", _Pprint.PRT1, CRreport);

            _checkIfEmptytext("PRS2", _Pprint.PRS2, CRreport);

            _checkIfEmptytext("PRS3", _Pprint.PRS3, CRreport);

 
          
            _checkIfEmptytext("PRF4", _Pprint.PRF2, CRreport);
            _checkIfEmptytext("PRM4", _Pprint.PRM2, CRreport);
            _checkIfEmptytext("PRA4", _Pprint.PRA1, CRreport);
            _checkIfEmptytext("PRT4", _Pprint.PRT4, CRreport);

            _checkIfEmptytext("PRF2", _Pprint.PRF2, CRreport);
            _checkIfEmptytext("PRM2", _Pprint.PRM2, CRreport);
            _checkIfEmptytext("PRA2", _Pprint.PRA2, CRreport);
            _checkIfEmptytext("PRT2", _Pprint.PRT2, CRreport);
            _checkIfEmptytext("FramePlatzHight", _Pprint.FramePlatzHight, CRreport);
            _checkIfEmptytext("IsDoubelDoor", _Pprint.IsDoubelDoor, CRreport);
            _checkIfEmptytext("TypeOfHingeText", _Pprint.TypeOfHingeText, CRreport);

            _checkIfEmptytext("PRT3", _Pprint.PRT3, CRreport);
            _checkIfEmptytext("PRA3", _Pprint.PRA3, CRreport);
            _checkIfEmptytext("PRM3", _Pprint.PRM3, CRreport);
            _checkIfEmptytext("PRF3", _Pprint.PRF3, CRreport);
            _checkIfEmptytext("ketum", _Pprint.ketum, CRreport);

            //image
            _checkIfEmptyImage("PimgMain1", _Pprint.imgMain1, CRreport);
            _checkIfEmptyImage("PAmood", _Pprint.PAmood, CRreport);
            _checkIfEmptyImage("Pprisa1", _Pprint.Pprisa1, CRreport);
            _checkIfEmptyImage("Pprisa2", _Pprint.Pprisa2, CRreport);
            _checkIfEmptyImage("PUpeerLock", _Pprint.PUpeerLock, CRreport);
            _checkIfEmptyImage("ImgCut11", _Pprint.ImgCut11, CRreport);
            _checkIfEmptyImage("ImgCut22", _Pprint.ImgCut22, CRreport);
            _checkIfEmptyImage("imgLock1", _Pprint.imgLock1, CRreport);
            _checkIfEmptyImage("ImgUpperPart", _Pprint.ImgUpperPart, CRreport);
            _checkIfEmptyImage("imageHinge", _Pprint.imageHinge, CRreport);
            _checkIfEmptyImage("FrameSlideinMain", _Pprint.FrameSlideinMainimg, CRreport);
            _checkIfEmptyImage("imgFramePocketTopProfile", _Pprint.imgFramePocketTopProfile, CRreport);


            if (_Pprint.FrameType1 == "משקוף הלבשה" || _Pprint.FrameType1 == "משקוף אלפא הלבשה")
            {
                _checkIfEmptytext("halbash_A2", _Pprint.A2, CRreport);
                _checkIfEmptytext("halbash_Aa2", _Pprint.A2, CRreport);
             
            }
            else
            {
                _checkIfEmptytext("halbash_A2", "Empty", CRreport);
                _checkIfEmptytext("halbash_Aa2", "Empty", CRreport);
            }


            return CRreport;
        

        }
     

  


        void _checkIfEmptyImage(string ParameterInReport, string ImagePath, Report.CrpFrame Report)
        {
            if (ParameterInReport == "ImgCut11")
            {

                Report.SetParameterValue(ParameterInReport, _imagePath + $@"FramesBMP\Rotated\R{System.IO.Path.GetFileNameWithoutExtension(ImagePath)}.bmp");
                return;
            }


            if (ParameterInReport == "ImgCut22")
            {
                Report.SetParameterValue(ParameterInReport, _imagePath + $@"FramesBMP\Rotated\{System.IO.Path.GetFileNameWithoutExtension(ImagePath)}.bmp");
                return;
            }

            if (System.IO.Path.GetFileNameWithoutExtension(ImagePath) != "Empty")
            {

                    Report.SetParameterValue(ParameterInReport, _imagePath + $@"FramesBMP\{System.IO.Path.GetFileNameWithoutExtension(ImagePath)}.bmp");
             
            }
            else
            {
             

                Report.SetParameterValue(ParameterInReport, "Hidd");
            }
        }

        void _checkIfEmptytext(string ParameterInReport, string Text, Report.CrpFrame Report)
        {
            

            if (Text == "Empty" || Text == null || string.IsNullOrEmpty(Text))
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
