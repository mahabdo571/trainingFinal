using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doors4.ReportWing
{
    public class clsParmeterTrisStikrs
    {
        public string Amount { get; set; }
        public string ItemName { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Hight1 { get; set; }
        public string Hight2 { get; set; }
        public string Hight3 { get; set; }
        public string Width1 { get; set; }
        public string Width2 { get; set; }
        public string Width3 { get; set; }
        public string Amount1 { get; set; }
        public string Amount2 { get; set; }
        public string Amount3 { get; set; }
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }

    }

    public class clsTrisStikrsAndParmiter
    {
        clsParmeterTrisStikrs _Para;

        public clsTrisStikrsAndParmiter(clsParmeterTrisStikrs P)
        {
            this._Para = P;
        }

        public CrpStickerWindowTris returnReport()
        {
            var newCulture = CultureInfo.CreateSpecificCulture("us");//for lang report

            Thread.CurrentThread.CurrentUICulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;




            CrpStickerWindowTris CRreport = new CrpStickerWindowTris();


            //text
          
            _checkIfEmptytext("OrderNo", _Para.OrderNo, CRreport);
            _checkIfEmptytext("Amount", _Para.Amount, CRreport);
            _checkIfEmptytext("ItemName", _Para.ItemName, CRreport);
            _checkIfEmptytext("Type1", _Para.Type1, CRreport);
            _checkIfEmptytext("Type2", _Para.Type2, CRreport);
            _checkIfEmptytext("Type3", _Para.Type3, CRreport);
            _checkIfEmptytext("Hight1", _Para.Hight1, CRreport);
            _checkIfEmptytext("Hight2", _Para.Hight2, CRreport);
            _checkIfEmptytext("Hight3", _Para.Hight3, CRreport);
            _checkIfEmptytext("Width1", _Para.Width1, CRreport);
            _checkIfEmptytext("Width2", _Para.Width2, CRreport);
            _checkIfEmptytext("Width3", _Para.Width3, CRreport);
            _checkIfEmptytext("Amount1", _Para.Amount1, CRreport);
            _checkIfEmptytext("Amount2", _Para.Amount2, CRreport);
            _checkIfEmptytext("Amount3", _Para.Amount3, CRreport);
            _checkIfEmptytext("CustomerName", _Para.CustomerName, CRreport);




            return CRreport;


        }

        void _checkIfEmptytext(string ParameterInReport, string Text, CrpStickerWindowTris Report)
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
