using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.Calculations
{
    public class PrisaCalc 
    {
  
      
 
        public double PR1 { get; set; }//out
        public double PR2 { get; set; }
        public double PR3 { get; set; }
        public double PRT4 { get; set; }
        public string FrameName { get; set; }
        public double FrameTestThickness { get; set; }
        public double MeterialThickness { get; set; }
        public double Subtitutions { get; set; }//out
        public bool isdd { get; set; }//out


        public void FramePrisa(ref FrameDefault  FD)
        {


            //עיוור
            if (FrameName == "BlindStandartBT" || FrameName == "BlindStandartGV")
            {
                FD.Blind();
                PR1 =  (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2) - (FD.Bends * MeterialThickness);
                PR2 = (PR1);
                Subtitutions = FD.B1 + FD.B2;
            }
            //הזזה
            if (FrameName == "SlidingBT" || FrameName == "SlidingGV") 
            {
                FD.Sliding();
                PR1 = (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2) - (FD.Bends * MeterialThickness);
                PR2 = (PR1);
                Subtitutions = FD.B1 + FD.B2;
            }
            //פיבוט
            if (FrameName == "PivotStandartBT" || FrameName == "PivotStandartGV") 
            {
                FD.Blind();
                PR1 = (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2) - (FD.Bends * MeterialThickness);
                PR2 = (PR1);
                Subtitutions = FD.B1 + FD.B2;
            } 
            
            if (FrameName == "PivotClick" || FrameName == "BlindClick") 
            {
                FD.BlindANDPivotClick();
                PR1 = (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.C1 + FD.C2) - (FD.Bends * MeterialThickness);
                PR2 = (PR1);
                Subtitutions = FD.B1 + FD.B2;

            }
            // הלבשה
            if (FrameName == "RegularHalbasha" || FrameName == "AlphaHalbasha")
            {
                if (MeterialThickness == 1.25)
                {
                    FD.RegularHalbasha();
                    FD.Magnetic();
                    PR1 = (FD.K125 + FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.C1 + FD.F1 + FD.E1) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1); // was -2, ronen wanted parity with head and nitzav
                    Subtitutions = FD.B1; //was also +FD.E1
                }
                else if (MeterialThickness == 1.5)
                {
                    FD.RegularHalbasha();
                    FD.Magnetic();
                    PR1 = (FD.K15 + FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.C1 + FD.F1 + FD.E1) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1); // was -2, ronen wanted parity with head and nitzav
                    Subtitutions = FD.B1; //was also +FD.E1
                }
            }
            // חובק פנלים/ארוסי
            if (FrameName == "RegularArusi") 
            {
                if(MeterialThickness == 1.25)
                {
                    FD.RegularArusi();
                    FD.Magnetic();
                    PR1 = (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.F1 + FD.C1 + FD.C2) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1 - 2);
                    Subtitutions = FD.B1 + FD.B2;
                }
                else
                {
                    FD.RegularArusi();
                    FD.Magnetic();
                    PR1 = FD.K15+(FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.F1 + FD.C1 + FD.C2) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1 - 2);
                    Subtitutions = FD.B1 + FD.B2;
                }
             
            }
            // קליק
            if (FrameName == "RegularClick" || FrameName ==  "AlphaClick") 
            {
                FD.RegularClick();
                FD.Magnetic();
                PR1 = (FD.K125 + FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2+ FD.F1 + FD.C1 + FD.C2) - (FD.Bends * MeterialThickness) - FD.MG;
                PR2 = (PR1);
                Subtitutions = FD.B1 + FD.B2;
            }
            // פנדל
            if (FrameName == "PendelStandartBT" || FrameName == "PendelStandartGV") 
            {
            
                if (!isdd)
                {
                    FD.Blind();
                    PRT4 = (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2) - (FD.Bends * MeterialThickness);
                    PR2 = (PRT4);
                    Subtitutions = FD.B1 + FD.B2;

                    FD.Pendel();
                    PR1 = (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.F1 + FD.D1 + FD.D2) - (FD.Bends * MeterialThickness);
                    PR2 = (PR1 - 2);
                    Subtitutions = FD.B1 + FD.B2;

                }
                else
                {
                    FD.Pendel();
                    PR1 = (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.F1 + FD.D1 + FD.D2) - (FD.Bends * MeterialThickness);
                    PR2 = (PR1 - 2);
                    Subtitutions = FD.B1 + FD.B2;
                    PRT4 = PR1;
                }
               
            }
            //רגיל פלס 1
            if (FrameName == "RegularStandartF1BT" || FrameName == "RegularStandartF1GV" || FrameName == "AlphaStandartF1BT" || FrameName == "AlphaStandartF1GV")
            {
                if(MeterialThickness == 1.25)
                {
                    FD.RegularStandartF1();
                    FD.Magnetic();
                    PR1 = (FD.K125 + FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.F1) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1 ); // was -2
                    Subtitutions = FD.B1 + FD.B2;
                }
                else
                {
                    FD.RegularStandartF1();
                    FD.Magnetic();
                    PR1 = (FD.K15-(0.5)) + (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.F1) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1 ); //was -0.5
                    Subtitutions = FD.B1 + FD.B2;
                }
                
            }
            // רגיל 2 פלסים
            if (FrameName == "RegularStandartF2BT" || FrameName == "RegularStandartF2GV" || FrameName == "AlphaStandartF2BT" || FrameName == "AlphaStandartF2GV")
            {
                if(MeterialThickness == 1.25)
                {
                    FD.RegularStandartF2();
                    FD.Magnetic();
                    PR1 = FD.K125 + (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.F1 + FD.D1) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1 - 2);
                    Subtitutions = FD.B1 + FD.B2;
                }
                else
                {
                    FD.RegularStandartF2();
                    FD.Magnetic();
                    PR1 = FD.K15 + (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.F1 + FD.D1) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1 - 2);
                    Subtitutions = FD.B1 + FD.B2;
                }
                
            }
            // רגיל קנט טיח פלס 1
            if (FrameName == "RegularKantTiachF1BT" || FrameName == "RegularKantTiachF1GV" || FrameName == "AlphaKantTiachF1BT" || FrameName == "AlphaKantTiachF1GV") 
            {
                if(MeterialThickness == 1.25)
                {
                    FD.RegularKantTiachF1();
                    FD.Magnetic();
                    PR1 = FD.K125 + (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.F1 + FD.C1 + FD.C2 + FD.E1 + FD.E2) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1);
                    Subtitutions = FD.B1 + FD.B2;
                }
                else if (MeterialThickness == 2)
                {
                    FD.RegularKantTiachF1();
                    FD.Magnetic();
                    PR1 = FD.K2 + (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.F1 + FD.C1 + FD.C2 + FD.E1 + FD.E2) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1); //was -2
                    Subtitutions = FD.B1 + FD.B2;
                }
                else
                {
                    FD.RegularKantTiachF1();
                    FD.Magnetic();
                    PR1 = FD.K15 + (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.F1 + FD.C1 + FD.C2 + FD.E1 + FD.E2) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1); // was -2
                    Subtitutions = FD.B1 + FD.B2;
                }
            }
           
            // רגיל קנט טיח 2 פלסים
            if (FrameName == "RegularKantTiachF2BT" || FrameName == "RegularKantTiachF2GV" || FrameName == "AlphaKantTiachF2BT" || FrameName == "AlphaKantTiachF2GV") 
            {
                if(MeterialThickness == 1.25)
                {
                    FD.RegularKantTiachF2();
                    FD.Magnetic();
                    PR1 = (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.D1 + FD.F1 + FD.C1 + FD.C2 + FD.E1 + FD.E2) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1 - 2);
                    Subtitutions = FD.B1 + FD.B2;
                }
                else
                {
                    FD.RegularKantTiachF2();
                    FD.Magnetic();
                    PR1 = FD.K15 + (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.D1 + FD.F1 + FD.C1 + FD.C2 + FD.E1 + FD.E2) - (FD.Bends * MeterialThickness) - FD.MG;
                    PR2 = (PR1 - 2);
                    Subtitutions = FD.B1 + FD.B2;
                }
             
            }
            //רגיל אקוסטי 60
            if (FrameName == "RegularStandartAQ60BT" || FrameName == "RegularStandartAQ60GV" || FrameName == "AlphaStandartAQ60BT" || FrameName == "AlphaStandartAQ60GV") 
            {
                FD.RegularStandarAQ60();
                FD.Magnetic();
                PR1 = (FrameTestThickness + FD.A1 + FD.A2 + FD.B1 + FD.B2 + FD.D1 + FD.D2+ FD.F1 + FD.F2) - (FD.Bends * MeterialThickness) - FD.MG - FD.MG;
                PR2 = (PR1 - 2);
                Subtitutions = FD.B1 + FD.B2;
            }
  
        }
    }
}
