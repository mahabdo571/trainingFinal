using Doors4.Projects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doors4.Report
{
    public class StickerPackingFrameParameter
    {
        public string CustomerName { get; set; }
        public string TypeOfDoorFrame { get; set; }
        public string OrderNo { get; set; }
        public string Manager { get; set; }
        public string Amount { get; set; }
        public string FrameType { get; set; }
        public string FrameMeterial { get; set; }
        public string LAmount { get; set; }
        public string RAmount { get; set; }
        public DateTime InputDate { get; set; }
        public DateTime TodayDate { get; set; }
        public DateTime CalculatedDate { get; set; }
    }
    public class StickerPackingFrame
    {
        StickerPackingFrameParameter _Pprint;
        public StickerPackingFrame(StickerPackingFrameParameter P)
        {

            _Pprint = P;
        }

        public CrpStickerPackingFrame returnReport()
        {
            var newCulture = CultureInfo.CreateSpecificCulture("us");//for lang report

            Thread.CurrentThread.CurrentUICulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;




            CrpStickerPackingFrame CRreport = new CrpStickerPackingFrame();

    
            _checkIfEmptytext("CustomerName", _Pprint.CustomerName, CRreport);
            _checkIfEmptytext("OrderNo", _Pprint.OrderNo, CRreport);
            _checkIfEmptytext("Manager", _Pprint.Manager, CRreport);
            _checkIfEmptytext("Amount", _Pprint.Amount, CRreport);
            _checkIfEmptytext("FrameType", "משקוף " + _Pprint.FrameType, CRreport);
            _checkIfEmptytext("FrameMeterial", _Pprint.FrameMeterial, CRreport);
            _checkIfEmptytext("LAmount", _Pprint.LAmount, CRreport);
            _checkIfEmptytext("RAmount", _Pprint.RAmount, CRreport);
            _checkIfEmptytext("TypeOfDoorFrame", _Pprint.TypeOfDoorFrame, CRreport);

            CRreport.SetParameterValue("CalculatedDate", _Pprint.CalculatedDate);
            CRreport.SetParameterValue("TodayDate", _Pprint.TodayDate);
            CRreport.SetParameterValue("InputDate", _Pprint.InputDate);
            return CRreport;


        }



        void _checkIfEmptytext(string ParameterInReport, string Text, CrpStickerPackingFrame Report)
        {


            if (Text == "Empty" || string.IsNullOrEmpty(Text) || Text=="-1"|| Text=="0")
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
