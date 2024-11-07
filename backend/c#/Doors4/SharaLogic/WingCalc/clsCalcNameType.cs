using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SharaLogic.WingCalc
{
    public class clsCalcNameType
    {

        static string Test1(string t)
        {
            switch (t)
            {
                case "NOR":
                    
                    return  "רגיל";
                case "ALPH":
                    return "אלפא";
                case "PVT":
                    return "פיבוט";
                case "PNDL":
                    return "פנדל";
                case "Flash":
                    return "פלאש";
                case "AQ60":
                    return "אקוסטי-60";

                case "AQ80":
                    return "אקוסטי-80";
                case "ZAZA":
                    return "הזזה";
                default:
                    return "";
            }
        }      
        
        static string Test2(string t)
        {
            switch (t)
            {
                case "F":
                    return "פורמייקה";
                case "A":
                    return "שטופטקאנט";
  
                default:
                    return "";
            }
        }      
        
        static string Test3(string t)
        {
            switch (t)
            {
                case "0":
                    return "סמוי";
                case "3":
                    return "גלוי 3";    
                
                case "Medic":
                    return "מדיק";    
                case "4":
                    return "גלוי 4";
  
                default:
                    return "";
            }
        }      
        static string Test4(string t)
        {
  
                    return "";
            
        }
        public static string getName(string t1,string t2,string t3 ,string t4)
        {

            return Test1(t1) +" "+ Test2(t2) + " " + Test3(t3) + " " + Test4(t4);

        }
    }
}
