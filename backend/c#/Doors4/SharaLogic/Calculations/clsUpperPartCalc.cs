using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.Calculations
{
    public class clsUpperPartCalc
    {


        public string outBottomPartTestDisplay { get; set; }
        public int outUpperPartSize { get; set; }
        public string outUpperPartType { get; set; }

         string _test1;
         string _test2;
       
        public bool inDisplayBottomPart1 { get; set; }
        public bool inDisplayBottomPart2 { get; set; }
         public int inBottomPartSize { get; set; }
        public int inUpperPartSize { get; set; }
        public string inUpperPartType { get; set; }
        
     
        public void exeute()
        {
            KitumClick();
            StainlessClick();

            outUpperPartSize = inUpperPartSize;
            outUpperPartType = inUpperPartType;


        }
         void KitumClick()
        {
            if (inDisplayBottomPart1 == true)
            {
                _test1 = " קיטום ";
            }
            else
            {
                _test1 = "";
            }
            if (inBottomPartSize == -1 )
            {
                outBottomPartTestDisplay = _test1 + _test2;
            }
            else if (inBottomPartSize > 0)
            {
                outBottomPartTestDisplay = inBottomPartSize +  _test1 + _test2;
            }
        }

         void StainlessClick()
        {
            if (inDisplayBottomPart2 == true)
            {
                _test2 = " נירוסטה ";
            }
            else
            {
                _test2 = "";
            }
            if (inBottomPartSize == -1)
            {
                outBottomPartTestDisplay = _test1 + _test2;
            }
            else if (inBottomPartSize > 0)
            {
                outBottomPartTestDisplay = inBottomPartSize + _test1 + _test2;
            }

        }


   

 

    }
}
