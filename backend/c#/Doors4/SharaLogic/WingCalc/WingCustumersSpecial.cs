using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.WingCalc
{
    public class WingCustumersSpecial
    {
        public int HingeSize { get; set; }
        public int Lock1 { get; set; }
        public int Hinge1 { get; set; }
        public int Hinge2 { get; set; }
        public int Hinge3 { get; set; }
        public int H1 { get; set; }
        public int H2 { get; set; }
        public int WingDept { get; set; }
        public string LockType { get; set; }
        public string HingeName { get; set; }
        public int Hinge1SupportHight { get; set; }
        public int Hinge1SupportWidth { get; set; }
        public int Hinge1SupportPos { get; set; }
        public int Hinge2SupportHight { get; set; }
        public int Hinge2SupportWidth { get; set; }
        public int Hinge2SupportPos { get; set; }
        public int Hinge3SupportHight { get; set; }
        public int Hinge3SupportWidth { get; set; }
        public int Hinge3SupportPos { get; set; }
        public int HingeAmount { get; set; }
        public bool Flash { get; set; }
        public string Metal2Width { get; set; }
        public string Metla2Hight { get; set; }

        void MyDesk()
        {
            int Hinge1Defult = 160;
            int Hinge2Defult = 680;
            int Hinge3Defult = 278;

            HingeSize = 76;

            LockType = "KFV";
            HingeName = "76";

            // Lock1 = WingHight - WingLock;

            //if (WingHingeInput1 > 0)
            //{
            //    Hinge1 = WingGineInput1;
            //}
            //else
            //{
            //    Hinge1 = Hinge1Defult;
            //}
            //if (WingHingeInput2 > 0)
            //{
            //    Hinge2 = WingGineInput2 + Hinge1;
            //}
            //else
            //{
            //    Hinge2 = Hinge2Defult + Hinge1;
            //}
            //if (WingHingeInput3 > 0)
            //{
            //    Hinge3 = WingHight - WingGineInput3;
            //}
            //else
            //{
            //    Hinge3 = WingHight - Hinge3Defult;
            //}

        }
        void IAmit()
        {
            int Hinge1Defult = 210;
            int Hinge2Defult = 300;
            int Hinge3Defult = 290;

            WingDept = 40;
            HingeSize = 120;

            LockType = "ROCK";
            HingeName = "120";

            //  lock1 = WingHight - WingLock;


            //if (WingHingeInput1 > 0)
            //{
            //    Hinge1 = WingGineInput1 - (HingeSize / 2);
            //}
            //else
            //{
            //    Hinge1 = Hinge1Defult - (HingeSize / 2);
            //}
            //if (WingHingeInput2 > 0)
            //{
            //    Hinge2 = WingGineInput2 + Hinge1;
            //}
            //else
            //{
            //    Hinge2 = Hinge2Defult + Hinge1;
            //}
            //if (WingHingeInput3 > 0)
            //{
            //    Hinge3 = WingHight - (WingGineInput3 + (HingeSize / 2));
            //}
            //else
            //{
            //    Hinge3 = WingHight - (Hinge3Defult + (HingeSize / 2));
            //}
        }
        void Carmel()
        {
            int Hinge1Defult = 200;
            int Hinge2Defult = 1050;
            int Hinge3Defult = 200;


            WingDept = 50;
            HingeSize = 102;

            LockType = "ByExample";
            HingeName = "4x3.5";


            //  Lock1 = wingPlatzHight - WingLockSize;

            //if (WingHingeInput1 > 0)
            //{
            //    Hinge1 = WingGineInput1 - (HingeSize / 2);
            //}
            //else
            //{
            //    Hinge1 = Hinge1Defult - (HingeSize / 2);
            //}

            //if (WingHingeInput2 > 0)
            //{
            //    Hinge2 =  WingHight - (WingGineInput2 + (HingeSize / 2));
            //}
            //else
            //{
            //    Hinge2 = Hinge2Defult - (WingGineInput2 + (HingeSize / 2));
            //}
            //if (WingHingeInput3 > 0)
            //{
            //    Hinge3 = WingHight - (WingGineInput3 + (HingeSize / 2));
            //}
            //else
            //{
            //    Hinge3 = Hinge3Defult - (WingGineInput3 + (HingeSize / 2));
            //}

        }
        void EcoSpace()
        {
            int Hinge1Defult = 200;
            int Hinge2Defult = 200;
            int Hinge3Defult = 195;
            int ExtraHingeSupport = 20;
            int HingeSizeWidth = 40;

            // HingeSize = ??;

            LockType = "45";
            HingeName = "Special";


            //  Lock1 = wingPlatzHight - WingLockSize;

            //if (WingHingeInput1 > 0)  // First hinge
            //{
            //    Hinge1 = WingGineInput1 - (HingeSize / 2);
            //}
            //else
            //{
            //    Hinge1 = Hinge1Defult - (HingeSize / 2);
            //}

            //if (HingeAmount == 3)  // Second hinge
            //{
            //    if(WingHingeInput2 > 0)
            //    {
            //        Hinge2 = (WingGineInput2 + Hinge1);
            //    }
            //    else
            //    {
            //        Hinge2 = (Hinge2Defult + Hinge1);
            //    }
            //}
            //else
            //{
            //    if (WingHingeInput2 > 0)
            //    {
            //        Hinge2 = Winghight - (HingeSize / 2 + WingGineInput2)
            //    }
            //    else
            //    {
            //        Hinge2 = Winghight - (HingeSize / 2 + Hinge3Defult)
            //    }

            //}

            //if (HingeAmount == 3) // third hinge
            //{
            //    if (WingHingeInput3 > 0)
            //    {
            //        Hinge3 = Winghight - (HingeSize / 2 + WingGineInput3)
            //      }
            //    else
            //    {
            //        Hinge3 = Winghight - (HingeSize / 2 + Hinge3Defult)
            //    }
            //}

            // Support calc

            //    if (HingeAmount == 3)
            //    {
            //        Hinge1SupportPos = Hinge1 - ExtraHingeSupport;
            //        Hinge1SupportWidth = HingeSizeWidth + 10;
            //        Hinge1SupportHight = HingeSize + (Hinge1 + Hinge2) + (ExtraHingeSupport * 2);
            //    }
            //    else
            //    {
            //        Hinge1SupportPos = Hinge1 - ExtraHingeSupport;
            //        Hinge1SupportWidth = HingeSizeWidth + 10;
            //        Hinge1SupportHight = HingeSize + (ExtraHingeSupport * 2);
            //    }

            //    Hinge3SupportWidth = HingeSizeWidth + 10;
            //    Hinge3SupportHight = HingeSize + (ExtraHingeSupport * 2);
            //    Hinge3SupportPos = Winghight - (Hinge3 - ExtraHingeSupport) - Hinge3SupportHight;
          }
       }
    }

