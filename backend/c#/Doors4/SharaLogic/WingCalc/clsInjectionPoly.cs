using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.WingCalc
{
    public class clsInjectionPoly
    {

        public float inWidth { get; set; }
        public float inHigth { get; set; }
        public float inKantA { get; set; }
        public float inKantB { get; set; }
        public float inInjectionGramsPerSecond { get; set; }
        public float inInjectionKUB { get; set; }
        public bool IsAlpha { get; set; }
        public bool IsAtmer { get; set; }
        public bool IsLock { get; set; }
        public bool IsDoubleLock { get; set; }
        public bool IsOilReturner { get; set; }
        public int LockHight { get; set; }
        public int LockWidth { get; set; }
        public int OilHeight { get; set; }
        public int OilWidth { get; set; }

        public clsInjectionPoly(float InWidth, float InHigth, float InKantA, float InKantB, float InInjectionGramsPerSecond,
            float InInjectionKUB, bool isAlpha, bool isAtmer, bool isLock, bool isDoubleLock, bool isOilReturner
            )
        {

            this.inWidth = InWidth;
            this.inHigth = InHigth;
            this.inKantA = InKantA;
            this.inKantB = InKantB;
            this.inInjectionGramsPerSecond = InInjectionGramsPerSecond;
            this.inInjectionKUB = InInjectionKUB;
            this.IsAlpha = isAlpha;
            this.IsAtmer = isAtmer;
            this.IsLock = isLock;
            this.IsDoubleLock = isDoubleLock;
            this.IsOilReturner = isOilReturner;


        }


        float FinalResult()
        {
      
     
            return (inKantB / 100 * (inHigth / 100 - inKantA / 100 * 2)) * (inWidth / 100 - (inKantA / 100 * 2) - Subtitutions() / 100) * inInjectionKUB / inInjectionGramsPerSecond;
        }



        public float OutResultPoly()
        {

            return FinalResult();
        }

        public int Subtitutions()
        {
            int sub1 = Lock1Support();
            int sub2 = Lock2Support();
            int sub3 = OilSupport();
            int sub4 = BehalaSupport();
            int sub5 = Hinge1Support();
            int sub6 = Hinge2Support();
            int sub7 = AtmerSupport(); 

            return sub1 + sub2 + sub3 + sub4 + sub5 + sub6 + sub7;
     
        }
        public int Lock1Support()
        {
            LockHight = 65;
            LockWidth = 370;

            return 0;
        }
        public int Lock2Support()
        {
           // LockHight = 65;
           // LockWidth = 370;
            return 0;
        }
        public int OilSupport()
        {
            OilHeight = 105;
            OilWidth = 230;
            return 0;
        }
      public int BehalaSupport()
        {
           // LockHight = 65;
           // LockWidth = 370;
            return 0;
        }
        public int Hinge1Support()
        {
            return 0;
        }
        public int Hinge2Support()
        {
            return 0;
        }
        public int AtmerSupport()
        {
           // float Alpha = 30 * inWidth - (inKantA * 2); // alpha without atmer
          //  float AlphaAtmer = 60 * inWidth - (inKantA * 2); //Alpha with atmer
            return 0;
        }


    }
}
