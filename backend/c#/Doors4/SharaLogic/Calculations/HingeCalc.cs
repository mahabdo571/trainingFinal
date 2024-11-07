using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SharaLogic.Calculations
{
    public class HingeCalc
    {
   
         int Hinge1Height = 169;
        public int UpperMiddleHinge { get; set; }
        //output
        public int F1H { get; set; }
        public int F2H { get; set; }
        public int F3H { get; set; }
        public int F4H { get; set; }
        public int F5H { get; set; }
        public int F6H { get; set; }

        //input
        public int FH1H { get; set; }
        public int FH2H { get; set; }
        public int FH3H { get; set; }
        public int FH4H { get; set; }
        public int FH5H { get; set; }
        public int FH6H { get; set; }


        public int HingeAmount { get; set; }

        public int DisplayHingeFrameHight { get; set; }

  

        public void HingesCalc()
        {
    
   
            //top hinge
            if (this.FH1H == -1)
            {
                F1H = Hinge1Height;
            }
            else
            {
                F1H = FH1H;
            }

            //2 hinges
            if (this.HingeAmount == 2)
            {
                F3H = 0;
                F4H = 0;
                F5H = 0;
                F6H = 0;

                if (this.FH2H == -1)
                {
                    F2H = 1744 - (2100 - DisplayHingeFrameHight);
                }
                else
                {
                    F2H = FH2H;
                }

            }
            //3 hinges
            if (this.HingeAmount == 3)
            {
                F4H = 0;
                F5H = 0;
                F6H = 0;
                if (this.FH2H == -1) //2
                {
                    if (DisplayHingeFrameHight >= 2050)
                    {
                        F2H = UpperMiddleHinge;
                    }
                    else if (DisplayHingeFrameHight >= 1850 && UpperMiddleHinge != 519)
                    {
                        F2H = UpperMiddleHinge - (2100 - DisplayHingeFrameHight);
                    }
                    else if (UpperMiddleHinge == 519 && DisplayHingeFrameHight >= 1234)
                    {
                        F2H = 519;
                    }
                    else
                    {
                        F2H = (DisplayHingeFrameHight - 30) / 2 - 50;
                    }
                }
                else
                {
                    F2H = FH2H;
                }

                if (this.FH3H == -1) //3
                {
                    F3H = 1744 - (2100 - DisplayHingeFrameHight);
                }
                else
                {
                    F3H = FH3H;
                }

            }
            //4 hinges
            if (this.HingeAmount == 4)
            {
                F5H = 0;
                F6H = 0;

                if (this.FH2H == -1) //2
                {
                    F2H = UpperMiddleHinge;
                }
                else
                {
                    F2H = FH2H;
                }

                if (this.FH4H == -1) //4
                {
                    F4H = 1744 - (2100 - DisplayHingeFrameHight);
                }
                else
                {
                    F4H = FH4H;
                }

                if (this.FH3H == -1) //3
                {
                    F3H = F4H - (F2H - F1H);
                }
                else
                {
                    F3H = FH3H;
                }

            }
            //5 hinges
            if (this.HingeAmount == 5)
            {
            
                F6H = 0;
                if (this.FH2H == -1) //2
                {
                    F2H = UpperMiddleHinge;
                }
                else
                {
                    F2H = FH2H;
                }
                if (this.FH3H == -1) //3
                {
                    F3H = (DisplayHingeFrameHight - 30) / 2 - 50;
                }
                else
                {
                    F3H = FH3H;
                }
          
                if (this.FH5H == -1) //5
                {
                    F5H = 1744 - (2100 - DisplayHingeFrameHight);
                }
                else
                {
                    F5H = FH5H;
                }

                if (this.FH4H == -1) //4
                {
                    F4H = F5H - (F2H - F1H);
                }
                else
                {
                    F4H = FH4H;
                }
            }
            //6 hinges
            if (this.HingeAmount == 6)
            {
                if (this.FH2H == -1) //2
                {
                    F2H = UpperMiddleHinge;
                }
                else
                {
                    F2H = FH2H;
                }
                if (this.FH3H == -1) //3
                {
                    F3H = F2H + (F2H - F1H);
                }
                else
                {
                    F3H = FH3H;
                }
                if (this.FH6H ==-1) //6
                {
                    F6H = 1744 - (2100 - DisplayHingeFrameHight);
                }
                else
                {
                    F6H = FH6H;
                }
                if (this.FH5H == -1) //5
                {
                    F5H = F6H - (F2H - F1H);
                }
                else
                {
                    F5H = FH5H;
                }
                if (this.FH4H ==-1) //4
                {
                    F4H = F5H - (F6H - F5H);
                }
                else
                {
                    F4H = FH4H;
                }
            }
        }
    }

}
