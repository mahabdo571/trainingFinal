using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doors4.ReportWing
{
    public class clsParamCrpStickerPackingWing
    {

        public string WingType { get; set; }
        public string c1 { get; set; }
        public string c2 { get; set; }
        public string c3 { get; set; }
        public string c4 { get; set; }
        public string c5 { get; set; }
        public string th1 { get; set; }
        public string th2 { get; set; }
        public string th3 { get; set; }
        public string th4 { get; set; }
        public string th5 { get; set; }
        public string SubAmount1 { get; set; }
        public string SubAmount2 { get; set; }
        public string SubAmount3 { get; set; }
        public string SubAmount4 { get; set; }
        public string SubAmount5 { get; set; }
        public string Amount { get; set; }
        public string DoorF { get; set; }
        public string Manager { get; set; }
        public string CustomerName { get; set; }
        public string OrderNo { get; set; }
        public DateTime InputDate { get; set; }
        public DateTime TodayDate { get; set; }
        public DateTime CalculatedDate { get; set; }
      
    }
    public class clsCrpStickerPackingWing
    {

        clsParamCrpStickerPackingWing _Pprint;

        public clsCrpStickerPackingWing(clsParamCrpStickerPackingWing p)
        {
            _Pprint = p;
        }


        public CrpStickerPackingWing returnReport()
        {

            var newCulture = CultureInfo.CreateSpecificCulture("us");//for lang report

            Thread.CurrentThread.CurrentUICulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;
            CrpStickerPackingWing CRreport = new CrpStickerPackingWing();


            _checkIfEmptytext("c1", _Pprint.c1, CRreport);
            _checkIfEmptytext("c2", _Pprint.c2, CRreport);
            _checkIfEmptytext("c3", _Pprint.c3, CRreport);
            _checkIfEmptytext("c4", _Pprint.c4, CRreport);
            _checkIfEmptytext("c5", _Pprint.c5, CRreport);
            _checkIfEmptytext("th1", _Pprint.th1, CRreport);
            _checkIfEmptytext("th2", _Pprint.th2, CRreport);
            _checkIfEmptytext("th3", _Pprint.th3, CRreport);
            _checkIfEmptytext("th4", _Pprint.th4, CRreport);
            _checkIfEmptytext("th5", _Pprint.th5, CRreport);
            _checkIfEmptytext("SubAmount1", _Pprint.SubAmount1+"X", CRreport);
            _checkIfEmptytext("SubAmount2", _Pprint.SubAmount2+"X", CRreport);
            _checkIfEmptytext("SubAmount3", _Pprint.SubAmount3+"X", CRreport);
            _checkIfEmptytext("SubAmount4", _Pprint.SubAmount4+"X", CRreport);
            _checkIfEmptytext("SubAmount5", _Pprint.SubAmount5 + "X", CRreport);
            _checkIfEmptytext("OrderNo", _Pprint.OrderNo, CRreport);
            _checkIfEmptytext("CustomerName", _Pprint.CustomerName, CRreport);
            _checkIfEmptytext("DoorF", _Pprint.DoorF, CRreport);
            _checkIfEmptytext("WingType", _Pprint.WingType, CRreport);
            _checkIfEmptytext("Manager", _Pprint.Manager, CRreport);
            _checkIfEmptytext("Amount", _Pprint.Amount, CRreport);
            CRreport.SetParameterValue("CalculatedDate", _Pprint.CalculatedDate);
            CRreport.SetParameterValue("InputDate", _Pprint.InputDate);
            CRreport.SetParameterValue("TodayDate", _Pprint.TodayDate);
            return CRreport;
        }

        void _checkIfEmptytext(string ParameterInReport, string Text, CrpStickerPackingWing Report)
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
