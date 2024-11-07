using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SharaLogic.Calculations
{
    public class FrameNameCalc
    {
       // FrameDefault FD;// = new FrameDefault();

        public static string   FrameNameSys(string FrameTypeNameEN)
        {

            // FD = new FrameDefault();

            
            //Frame Name System
            //Standart
            if (FrameTypeNameEN == "RegularStandartF1BT") // Calculated
            {
                return "משקוף בטון פלס 1";               
            }
            if (FrameTypeNameEN == "RegularStandartF2BT") // Calculated
            {
                return "משקוף בטון 2 פלסים";
            }
            if (FrameTypeNameEN == "RegularStandartF1GV") // Calculated
            {
                return "משקוף גבס פלס 1";
            }
            if (FrameTypeNameEN == "RegularStandartF2GV") // Calculated
            {
                return "משקוף גבס 2 פלסים";
            }
            if (FrameTypeNameEN == "RegularStandartAQ60BT") // Calculated
            {
                return "משקוף בטון אקוסטי60";
            }
            if (FrameTypeNameEN == "RegularStandartAQ80BT")
            {
                return "משקוף בטון אקוסטי80";
            }
            if (FrameTypeNameEN == "RegularStandartAQ60GV") // Calculated
            {
                return "משקוף גבס אקוסטי60";
            }
            if (FrameTypeNameEN == "RegularStandartAQ80GV")
            {
                return "משקוף גבס אקוסטי80";
            }

            //Klink "Click"
            if (FrameTypeNameEN == "RegularClick") // Calculated
            {
                return "משקוף קליק";
            }
            //Mishtalev
            if (FrameTypeNameEN == "RegularMishtalev")
            {
                return "משקוף משתלב";
            }
            //Halbasha
            if (FrameTypeNameEN == "RegularHalbasha") // Calculated
            {
                return "משקוף הלבשה";
            }
            //Kant tiach
            if (FrameTypeNameEN == "RegularKantTiachF1BT") // Calculated
            {
                return "משקוף קנט טיח בטון פלס 1";
            }
            if (FrameTypeNameEN == "RegularKantTiachF2BT") // Calculated
            {
                return "משקוף קנט טיח בטון 2 פלסים";
            }
            if (FrameTypeNameEN == "RegularKantTiachF1GV") // Calculated
            {
                return "משקוף קנט טיח גבס פלס 1";
            }
            if (FrameTypeNameEN == "RegularKantTiachF2GV") // Calculated
            {
                return "משקוף קנט טיח גבס 2 פלסים";
            }
            //Arusi "Hcovek panelim"
            if (FrameTypeNameEN == "RegularArusi") // Calculated
            {
                return "משקוף חובק פנלים";
            }

            //Alpha משקוף אלפא
            if (FrameTypeNameEN == "AlphaStandartF1BT") // Calculated
            {
                return "משקוף אלפא בטון פלס 1";
            }
            if (FrameTypeNameEN == "AlphaStandartF2BT") // Calculated
            {
                return "משקוף אלפא בטון 2 פלסים";
            }
            if (FrameTypeNameEN == "AlphaStandartF1GV") // Calculated
            {
                return "משקוף אלפא גבס פלס 1";
            }
            if (FrameTypeNameEN == "AlphaStandartF2GV") // Calculated
            {
                return "משקוף אלפא גבס 2 פלסים";
            }
            if (FrameTypeNameEN == "AlphaStandartAQ60BT") // Calculated
            {
                return "משקוף אלפא בטון אקוסטי60";
            }
            if (FrameTypeNameEN == "AlphaStandartAQ80BT")
            {
                return "משקוף אלפא בטון אקוסטי80";
            }
            if (FrameTypeNameEN == "AlphaStandartAQ60GV") // Calculated
            {
                return "משקוף אלפא גבס אקוסטי60";
            }
            if (FrameTypeNameEN == "AlphaStandartAQ80GV")
            {
                return "משקוף אלפא גבס אקוסטי80";
            }
            //Klnk "Click"
            if (FrameTypeNameEN == "AlphaClick") // Calculated
            {
                return "משקוף אלפא קליק";
            }
            //Halbasha
            if (FrameTypeNameEN == "AlphaHalbasha") // Calculated
            {
                return "משקוף אלפא הלבשה";
            }
            //KaTt tiach
            if (FrameTypeNameEN == "AlphaKantTiachF1BT") // Calculated
            {
                return "משקוף אלפא קנט טיח בטון פלס 1";
            }
            if (FrameTypeNameEN == "AlphaKantTiachF2BT") // Calculated
            {
                return "משקוף אלפא קנט טיח בטון 2 פלסים";
            }
            if (FrameTypeNameEN == "AlphaKantTiachF1GV") // Calculated
            {
                return "משקוף אלפא קנט טיח גבס פלס 1";
            }
            if (FrameTypeNameEN == "AlphaKantTiachF2GV") // Calculated
            {
                return "משקוף אלפא קנט טיח גבס 2 פלסים";
            }
            //Pivot משקוף פיבוט
            if (FrameTypeNameEN == "PivotStandartBT") // Calculated
            {
                return "משקוף פיבוט בטון";
            }
            if (FrameTypeNameEN == "PivotStandartGV") // Calculated
            {
                return "משקוף פיבוט גבס";
            }
            if (FrameTypeNameEN == "PivotClick")
            {
                return "משקוף פיבוט קליק";
            }
            //Blind משקוף עיוור
            if (FrameTypeNameEN == "BlindStandartBT") // Calculated
            {
                return "משקוף עיוור בטון";
            }
            if (FrameTypeNameEN == "BlindStandartGV") // Calculated
            {
                return "משקוף עיוור גבס";
            }
            if (FrameTypeNameEN == "BlindHalbasha")
            {
                return "משקוף עיוור הלבשה";
            }
            //Pendel משקוף פנדל
            if (FrameTypeNameEN == "PendelStandartBT") // Calculated
            {
                return "משקוף פנדל בטון";
            }
            if (FrameTypeNameEN == "PendelStandartGV") // Calculated
            {
                return "משקוף פנדל גבס";
            }
            if (FrameTypeNameEN == "PendelKantTiachBT")
            {
                return "משקוף פנדל קנט טיח בטון";
            }
            if (FrameTypeNameEN == "PendelKantTiachGV")
            {
                return "משקוף פנדל קנט טיח גבס";
            }
            if (FrameTypeNameEN == "PendelClick")
            {
                return "משקוף פנדל קליק";
            }
            //Sliding הזזה
            if (FrameTypeNameEN == "SlidingBT") // Calculated
            {
                return "משקוף הזזה בטון";
            }
            if (FrameTypeNameEN == "SlidingGV") // Calculated
            {
                return "משקוף הזזה גבס";
            }
            if (FrameTypeNameEN == "SlidingPocketBT") //-No Calculation needed so far
            {
                return "משקוף הזזה-כיס בטון";
            }
            if (FrameTypeNameEN == "SlidingPocketGV") //-No Calculation needed so far
            {
                return "משקוף הזזה-כיס גבס";
            }
            //End Frame Name system---------------------------------------------------------
            return "";
        }
    }
}
