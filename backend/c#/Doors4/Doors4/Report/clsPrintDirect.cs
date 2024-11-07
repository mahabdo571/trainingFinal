using Doors4.Projects;
using Doors4.ReportWing;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Doors4.Report
{
    public class clsPrintDirect
    {
        
        public static void  PrintFrame(clsParameterForPrint P,byte Amountpaper,int amountStikars)
        {





            PrintFrameNiar(P, Amountpaper);

            CrpStikarsFrame crpStikarsFrame = new clsSetParameterToStikarsReport(P).returnReport();

         

            crpStikarsFrame.PrintOptions.PrinterName = clsSettings.GetData().StikersPrinterName;
            crpStikarsFrame.PrintToPrinter(amountStikars, false, 0, 0); 



        }
           
        public static void  PrintFrameNiar(clsParameterForPrint P,byte Amountpaper)
        {






            P.PapeClassification = "העתק";
            CrpFrame  CRreport =new clsSetParameterToReport(P).returnReport();
            CRreport.PrintOptions.PrinterName = clsSettings.GetData().MainPrinterName;
            CRreport.PrintToPrinter(1, false, 0, 0);
        
            P.PapeClassification = "";
            CRreport =new clsSetParameterToReport(P).returnReport();
            CRreport.PrintOptions.PrinterName = clsSettings.GetData().MainPrinterName;    
            CRreport.PrintToPrinter((Amountpaper -1), false, 0, 0);




        }


     


        public static void PrintWing(clsSetParameterToReportWing P, byte AmountPeaper,int AmountStikrs)
        {

       
            PrintWingNiar(P,AmountPeaper);
            PrintWingStikrs(P, AmountStikrs);

        }

        static void _PaperPr(clsSetParameterToReportWing P, int AmountPeaper)
        {

             
            CrpWing CRreport = new clsParameterForPrintWing(P).returnReport();
            CRreport.PrintOptions.PrinterName = clsSettings.GetData().MainPrinterName;
            CRreport.PrintToPrinter(AmountPeaper, false, 0, 0);
        }


        public static void PrintWingNiar(clsSetParameterToReportWing P, byte AmountPeaper)
        {
            int x = 0;
      
            

            clsWingType TypeWing = clsWingType.FindByWingID(P.IDDoor);
            clsWingWindows WindoWing = clsWingWindows.FindByWingID(P.IDDoor);
            clsWings Wing = clsWings.Find(P.IDDoor);

            x++;
            P.PapeClassification = "העתק";

            _PaperPr(P, 1);



            if (TypeWing != null && TypeWing.TEST1 == "ALPH")
            {
                x++;
                P.PapeClassification = "עמוד";

                _PaperPr(P, 1);

            }

            if (TypeWing != null && TypeWing.TEST3 == "Medic")
            {
                x +=2;

                P.PapeClassification = "נירוסטה";

                _PaperPr(P, 1);

            }

            if (WindoWing != null && WindoWing.TrisType == "Wood")
            {
                x++;
                P.PapeClassification = "תריס";

                _PaperPr(P, 1);

            }  
            
            if (WindoWing != null && WindoWing.WindowType != "NoWin" && WindoWing.WindowType == "Normal")
            {
                x++;
                P.PapeClassification = "חלון";

                _PaperPr(P, 1);

            } 
            
            if (TypeWing != null && TypeWing.TEST2  == "A")
            {
                x +=3;
                P.PapeClassification = "פחים";
                _PaperPr(P, 1);
                P.PapeClassification = "עצים";
                _PaperPr(P, 1);
                P.PapeClassification = "אריזה";
                _PaperPr(P, 1);

                if(Wing !=null && Wing.DDAK == "K")
                {
                    x++;
                    P.PapeClassification = "עמוד קבוע";
                    _PaperPr(P, 1);
                }

            }



            P.PapeClassification = "";
            int mod =Math.Abs((AmountPeaper - x));

            if(mod > 0)
            {
                _PaperPr(P, mod);
            }
          



        }

        public static void PrintWingStikrs(clsSetParameterToReportWing P, int Amount)
        {
             
            CrpStikarsWing Crpstikarswing = new clsSetParameterToStikarsReportWing(P).returnReport();
            Crpstikarswing.PrintOptions.PrinterName = clsSettings.GetData().StikersPrinterName;
            Crpstikarswing.PrintToPrinter(Amount , false, 0, 0);

        }

    }
}
