using SharaLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doors4.ReportWing
{
    public class ParameterAlphaStikrs
    {
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public string RAmount { get; set; }
        public string Amount { get; set; }
        public string LAmount { get; set; }
        public string AkphaPoleColor { get; set; }
        public string AkphaPoleColor2 { get; set; }
        public string AkphaPoleColor3 { get; set; }
        public string AkphaPoleColor4 { get; set; }
        public string AkphaPoleColor5 { get; set; }
        public string AkphaPoleColor6 { get; set; }

        public void Clear()
        {
            RAmount = "";
            Amount  = "";
            LAmount = "";
            AkphaPoleColor ="";
            AkphaPoleColor2="";
            AkphaPoleColor3="";
            AkphaPoleColor4="";
            AkphaPoleColor5="";
            AkphaPoleColor6 = "";


        }

                            }
    public class clsSetParameterToReportAlphaWing
    {

        ParameterAlphaStikrs _Pprint;


        public clsSetParameterToReportAlphaWing(ParameterAlphaStikrs p)
        {
            _Pprint = p;
           
        }

        public CrpStickerAlphaWing returnReport()
        {
            var newCulture = CultureInfo.CreateSpecificCulture("us");//for lang report

            Thread.CurrentThread.CurrentUICulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;




            CrpStickerAlphaWing CRreport = new CrpStickerAlphaWing();


            //text
            _checkIfEmptytext("AlphaPoleText", "עמוד אלפא", CRreport);
            _checkIfEmptytext("OrderNo", _Pprint.OrderNo, CRreport);
            _checkIfEmptytext("CustomerName", _Pprint.CustomerName, CRreport);
            _checkIfEmptytext("RAmount", _Pprint.RAmount, CRreport);
            _checkIfEmptytext("Amount", _Pprint.Amount, CRreport);
            _checkIfEmptytext("LAmount", _Pprint.LAmount, CRreport);
            _checkIfEmptytext("AkphaPoleColor", _Pprint.AkphaPoleColor, CRreport);
            _checkIfEmptytext("AkphaPoleColor2", _Pprint.AkphaPoleColor2, CRreport);
            _checkIfEmptytext("AkphaPoleColor3", _Pprint.AkphaPoleColor3, CRreport);
            _checkIfEmptytext("AkphaPoleColor4", _Pprint.AkphaPoleColor4, CRreport);
            _checkIfEmptytext("AkphaPoleColor5", _Pprint.AkphaPoleColor5, CRreport);
            _checkIfEmptytext("AkphaPoleColor6", _Pprint.AkphaPoleColor6, CRreport);

       

            return CRreport;


        }

    
        void _checkIfEmptytext(string ParameterInReport, string Text, CrpStickerAlphaWing Report)
        {


            if (Text == "Empty" || string.IsNullOrEmpty(Text) || Text == "-1" || Text == "0")
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
