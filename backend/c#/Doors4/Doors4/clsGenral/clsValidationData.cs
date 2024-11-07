using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doors4.clsGenral
{
    public class clsValidationData
    {
       public static decimal TextToDecimal(string txt)

        {
            if (string.IsNullOrEmpty(txt))
            {
                return 0;

            }
            else
            {
                if (decimal.TryParse(txt, out decimal Result))
                {
                    return Result;
                }
                else
                {
                    return 0;
                }
            }
        }      
        
        public static int TextToInt(string txt)

        {
            if (string.IsNullOrEmpty(txt))
            {
                return 0;

            }
            else
            {
                if (int.TryParse(txt, out int Result))
                {
                    return Result;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
