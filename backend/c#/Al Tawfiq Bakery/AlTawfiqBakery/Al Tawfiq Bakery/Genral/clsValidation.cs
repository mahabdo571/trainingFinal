using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Tawfiq_Bakery.Genral
{
    public  class clsValidation
    {
        public static decimal StringToDecimal(string  str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            

            if(decimal.TryParse(str, out decimal result))
                return result;
            

            return 0;
        }  
        
        
        public static int StringToInt(string  str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            else
            {

                if (int.TryParse(str, out int result))
                {
                    return result;

                }
                else
                {
                    return 22;
                }
            }
           
        }
    }
}
