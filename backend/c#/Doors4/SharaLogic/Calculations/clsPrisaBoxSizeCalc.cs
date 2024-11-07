using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.Calculations
{
    public class clsPrisaBoxSizeCalc
    {
        public int inOwidth {  get; set; }
        public int inOplzWidth {  get; set; }
        public int inOheight { get; set; }

        public int inOBottomSize { get; set; }

        public string inOFrameType { get; set; }
        public int inFrameHightUnderFloor { get; set; }


        public int outNtsav1()
        {
        
            return inOheight - inOBottomSize + inFrameHightUnderFloor;
        }
        public int outhead1()
        {
            int answer = 0;

           if(inOFrameType == "RegularStandartF1BT" ||
              inOFrameType == "RegularStandartF2BT" ||
              inOFrameType == "AlphaStandartF1BT" ||
              inOFrameType == "AlphaStandartF2BT")
            {
                answer = inOplzWidth;
            }
           else if( inOFrameType == "PivotStandartBT" ||
                    inOFrameType == "PivotStandartGV" ||
                    inOFrameType == "PivotClick")
            {
                answer = inOwidth;
            }               
            else
            {
                answer = inOwidth +0;
            }
            return answer;
        }
        public int outkitum1() {
            
            return inOBottomSize; 
        
        
        }



        

    }
}
