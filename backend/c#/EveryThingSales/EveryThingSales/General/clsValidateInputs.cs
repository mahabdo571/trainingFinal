using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingSales.General
{
    public class clsValidateInputs
    {

        public static Decimal TextToDecimal(string txt)
        {
            if(Decimal.TryParse(txt,out Decimal res))
            {
                return res;
            }
            else
            {
                return -2;
            }
        }  
        
        public static double TextToDouble(string txt)
        {
            if(double.TryParse(txt,out double res))
            {
                return res;
            }
            else
            {
                return -2;
            }
        }  
        
        public static int TextToInt(string txt)
        {
            if(int.TryParse(txt,out int res))
            {
                return res;
            }
            else
            {
                return -2;
            }
        }

    }
}
