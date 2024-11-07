using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SharaLogic.Calculations
{
    public class LockCalc
    {

        public int LockHight { get; set; }
        public int UpperLockHight { get; set; }


        public int FrameHightDisplay { get; set; }
        public int LockW { get; set; } 
        public int LockW2 { get; set; }
        public int LockX { get; set; }
        public int LockX2 { get; set; }
  
        public string lockType { get; set; }    

        public void LocksCalc()

        {

            if (lockType != "NoLock")
            {
                if (LockW == -1) // נעילה רגילה
                {
                    if (LockX == -1)
                    {
                        if (FrameHightDisplay <= 1300)
                        {
                            LockHight = 170;
                        }
                        else
                        {
                            LockHight = 970 - (2100 - FrameHightDisplay);
                        }
                    }
                    else if (LockX != -1)
                    {
                        LockHight = (FrameHightDisplay - 30) - LockX - 42;
                    }
                }
                else if (LockW != -1)
                {
                    LockHight = LockW;
                }
            }
            else
            {
                LockHight = -1;
            }

            



            if (lockType != "NoLock")
            {


                if (lockType == "JordanKafol")
                {
                    if (LockW2 == -1) // נעילה עליונה
                    {

                        if (LockX2 == -1)
                        {
                            UpperLockHight = (FrameHightDisplay - 30) - 1650;
                        }
                        else
                        {
                            UpperLockHight = (FrameHightDisplay - 30) - LockX2 - 50;
                        }



                    }

                    else
                    {
                        UpperLockHight = LockW2;
                    }
                }
                else
                {
                    UpperLockHight = -1;
                }
            }
            else
            {
                UpperLockHight = -1;
            }




        }
    }
}
