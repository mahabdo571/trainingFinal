using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doors4.Report
{
    public class clsParameterStickerPrisaFrame
    {

        public string CustomerName { get; set; }
        public string OrderNo { get; set; }
        public string LAmount { get; set; }
        public string RAmount { get; set; }

        public string RPT1 { get; set; }
        public string RPT2 { get; set; }
        public string RPT3 { get; set; }
        public string RPT4 { get; set; }
      
        public string RPM1 { get; set; }
        public string RPM2 { get; set; }
        public string RPM3 { get; set; }
        public string RPM4 { get; set; }
      
        public string RPA1 { get; set; }
        public string RPA2 { get; set; }
        public string RPA3 { get; set; }
        public string RPA4 { get; set; }
     
        public string RPS1 { get; set; }
        public string RPS2 { get; set; }
        public string RPS3 { get; set; }
        public string RPS4 { get; set; }
     
        public string RPR1 { get; set; }
        public string RPR2 { get; set; }
        public string RPR3 { get; set; }
        public string RPR4 { get; set; }
      
        public string LPT1 { get; set; }
        public string LPT2 { get; set; }
        public string LPT3 { get; set; }
        public string LPT4 { get; set; }
      
        public string LPM1 { get; set; }
        public string LPM2 { get; set; }
        public string LPM3 { get; set; }
        public string LPM4 { get; set; }
       
        public string LPA1 { get; set; }
        public string LPA2 { get; set; }
        public string LPA3 { get; set; }
        public string LPA4 { get; set; }
      
        public string LPS1 { get; set; }
        public string LPS2 { get; set; }
        public string LPS3 { get; set; }
        public string LPS4 { get; set; }
       
        public string LPR1 { get; set; }
        public string LPR2 { get; set; }
        public string LPR3 { get; set; }
        public string LPR4 { get; set; }
        public string tName { get; set; }
        public int IDF { get; set; }
      


    }
    public class clsSetParameterStickerPrisaFrame
    {

        clsParameterStickerPrisaFrame _p;
       public clsSetParameterStickerPrisaFrame(clsParameterStickerPrisaFrame p)
        {
            _p = p;
        }

        public CrpStickerPrisaFrame returnReport()
        {
            var newCulture = CultureInfo.CreateSpecificCulture("us");//for lang report

            Thread.CurrentThread.CurrentUICulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;




            CrpStickerPrisaFrame CRreport = new CrpStickerPrisaFrame();




            _checkIfEmptytext("CustomerName", _p.CustomerName, CRreport);
            _checkIfEmptytext("OrderNo", _p.OrderNo, CRreport);
            _checkIfEmptytext("LAmount", _p.LAmount, CRreport);
            _checkIfEmptytext("RAmount", _p.RAmount, CRreport);
        
            _checkIfEmptytext("RPT1", _p.RPT1, CRreport);
            _checkIfEmptytext("RPT2", _p.RPT2, CRreport);
            _checkIfEmptytext("RPT3", _p.RPT3, CRreport);
            _checkIfEmptytext("RPT4", _p.RPT4, CRreport);
           
            _checkIfEmptytext("RPM1", _p.RPM1, CRreport);
            _checkIfEmptytext("RPM2", _p.RPM2, CRreport);
            _checkIfEmptytext("RPM3", _p.RPM3, CRreport);
            _checkIfEmptytext("RPM4", _p.RPM4, CRreport);
       
            _checkIfEmptytext("RPA1", _p.RPA1, CRreport);
            _checkIfEmptytext("RPA2", _p.RPA2, CRreport);
            _checkIfEmptytext("RPA3", _p.RPA3, CRreport);
            _checkIfEmptytext("RPA4", _p.RPA4, CRreport);
          
            _checkIfEmptytext("RPS1", _p.RPS1, CRreport);
            _checkIfEmptytext("RPS2", _p.RPS2, CRreport);
            _checkIfEmptytext("RPS3", _p.RPS3, CRreport);
            _checkIfEmptytext("RPS4", _p.RPS4, CRreport);
      
            _checkIfEmptytext("RPR1", _p.RPR1, CRreport);
            _checkIfEmptytext("RPR2", _p.RPR2, CRreport);
            _checkIfEmptytext("RPR3", _p.RPR3, CRreport);
            _checkIfEmptytext("RPR4", _p.RPR4, CRreport); 
            
            _checkIfEmptytext("LPT1", _p.LPT1, CRreport);
            _checkIfEmptytext("LPT2", _p.LPT2, CRreport);
            _checkIfEmptytext("LPT3", _p.LPT3, CRreport);
            _checkIfEmptytext("LPT4", _p.LPT4, CRreport);
            
            _checkIfEmptytext("LPM1", _p.LPM1, CRreport);
            _checkIfEmptytext("LPM2", _p.LPM2, CRreport);
            _checkIfEmptytext("LPM3", _p.LPM3, CRreport);
            _checkIfEmptytext("LPM4", _p.LPM4, CRreport);
           
            _checkIfEmptytext("LPA1", _p.LPA1, CRreport);
            _checkIfEmptytext("LPA2", _p.LPA2, CRreport);
            _checkIfEmptytext("LPA3", _p.LPA3, CRreport);
            _checkIfEmptytext("LPA4", _p.LPA4, CRreport);
          
            _checkIfEmptytext("LPS1", _p.LPS1, CRreport);
            _checkIfEmptytext("LPS2", _p.LPS2, CRreport);
            _checkIfEmptytext("LPS3", _p.LPS3, CRreport);
            _checkIfEmptytext("LPS4", _p.LPS4, CRreport);
           
            _checkIfEmptytext("LPR1", _p.LPR1, CRreport);
            _checkIfEmptytext("LPR2", _p.LPR2, CRreport);
            _checkIfEmptytext("LPR3", _p.LPR3, CRreport);
            _checkIfEmptytext("LPR4", _p.LPR4, CRreport);
           
           


            return CRreport;


        }





     

        void _checkIfEmptytext(string ParameterInReport, string Text, CrpStickerPrisaFrame Report)
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
