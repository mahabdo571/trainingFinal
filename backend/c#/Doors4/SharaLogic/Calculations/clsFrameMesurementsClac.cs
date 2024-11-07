using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.Calculations
{
    public class clsFrameMesurementsClac
    {
        public int inWidth {get;set;} 
        public int inHeight { get;set;}
        public string inFrameType { get;set;}

        public bool   cbMenualeFrameSize = false;


       public int outHeight()
        {

        

          

            if (inFrameType == "RegularClick" || inFrameType == "AlphaClick" || inFrameType == "PivotClick")
            {
                int answer = +25;
                return inHeight + answer;
            }
            else if(inFrameType == "RegularHalbasha" || inFrameType == "AlphaHalbasha" || inFrameType == "BlindHalbasha")
            {
                int answer = +23; //was+27
                return inHeight + answer;
            }          
            else if (inFrameType == "RegularKantTiachF1BT" || inFrameType == "RegularKantTiachF2BT" || inFrameType == "RegularKantTiachF1GV" ||
               inFrameType == "RegularKantTiachF2GV" || inFrameType == "AlphaKantTiachF1BT" || inFrameType == "AlphaKantTiachF2BT" ||
               inFrameType == "AlphaKantTiachF1GV" || inFrameType == "AlphaKantTiachF2GV") 
            {
                int answer = +11; //was-11
                return inHeight + answer;
            }
            else if (inFrameType == "SlidingPocketBT" || inFrameType == "SlidingPocketGV")
            {
                return 0;
            }
            else
            {
                return inHeight;
            }
            
        }

        public int outWidth()
        {
            if (inFrameType == "RegularClick" || inFrameType == "AlphaClick" || inFrameType == "PivotClick")
            {
                int answer = +50;
                return inWidth + answer;
            }
            else if (inFrameType == "RegularHalbasha" || inFrameType == "AlphaHalbasha" || inFrameType == "BlindHalbasha")
            {
                int answer = +51; //was+55
                return inWidth + answer;
            }
            else if (inFrameType == "RegularKantTiachF1BT" || inFrameType == "RegularKantTiachF2BT" || inFrameType == "RegularKantTiachF1GV" ||
               inFrameType == "RegularKantTiachF2GV" || inFrameType == "AlphaKantTiachF1BT" || inFrameType == "AlphaKantTiachF2BT" ||
               inFrameType == "AlphaKantTiachF1GV" || inFrameType == "AlphaKantTiachF2GV")
            {
                int answer = +22; //was +21
                return inWidth + answer;
            }
            else if (inFrameType == "SlidingPocketBT" || inFrameType == "SlidingPocketGV")
            {
                return inWidth;
            }
            else
            {
                return inWidth;
            }

        }

        //Following script only works for Sliding pocket frame type, needs to connect and check.
        public int PocketWidth()
        {
            int Differ = inWidth - 1000;
            int answer =  910 + Differ;
            return answer;

        }
        public int LightWidth()
        {       
            int Differ = inWidth - 1000;
            int answer = 860 + Differ;
            return answer;

        }
        public int SlidingTotalWidth()
        {
            int Differ = inWidth - 1000;
            int answer = 1910 + Differ;
            return answer;

        }
        public int SlidingTotalHight()
        {
            int Differ = inHeight - 2150;
            int answer = 2150 + Differ;
            return answer;

        }
        public int LightHight()
        {
           
            int Differ = inHeight - 2150;
            int answer = 2060 + Differ;
            return answer;

        }
        public int SlidingWingWidth()
        {
            int Differ = inWidth - 1000;
            int answer = 995 + Differ;
            return answer;
        }
        public int SlidingWingHight()
        {
            int Differ = inHeight - 2150;
            int answer = 2078 + Differ;
            return answer;
        }
        public int SlidingPocketLock()
        {
            int differ = 920; //this is input sliding pocket lock. defult 920
            int answer = inHeight - differ;
            return answer;

        }

    }
}
