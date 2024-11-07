using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.Calculations
{
    public class clsOutCalcu
    {
        public string PocketWidth { get; set; }
        public string SlidingTotalWidth { get; set; }
        public string LightWidth { get; set; }
        public string SlidingTotalHight { get; set; }
        public string LightHight { get; set; }
        public string imgFramePocketTopProfile { get; set; }
        public string FrameSlideinMainimg { get; set; }
        public string slipcanlock { get; set; }
        public string outIsDoubelDoor { get; set; }
        public string FramePlatzHight { get; set; }
        public string FrameSize { get; set; }
        public string PlatzFrameSize { get; set; }
        public string FlakhGvs { get; set; }
        public string OutFrameWidth { get; set; }
        public string OutFramePlatzWidth { get; set; }
        public string OutFrameMetal_Nitzav { get; set; }
        public string OutFrameMetal_Head { get; set; }
        public string OutFrameMetalWidth_Head { get; set; }
        public string OutFrameMetalWidth_Nitzav { get; set; }
        public string OutFrameAmount_Nitzav { get; set; }
        public string OutFrameAmount_Head { get; set; }
       
        public string OutPrisaHight_Nitzav { get; set; }
        public string OutPriseTest_Nitzav { get; set; }
        public string PRT4 { get; set; }
        public string OutPriseTest_Head { get; set; }
        public string OutFrameThickness { get; set; }
        public string OutFrameThickness2 { get; set; }
        public string OutWallThickness { get; set; }
        public string OutWallThickness2 { get; set; }
        public string OutFrameLock2 { get; set; }
        public string OutFrameLock1 { get; set; }
        public string OutFrameHight { get; set; }
        public string OutFrameHightTop { get; set; }
        public string OutFrameHinge1H { get; set; }
        public string OutFrameHinge2H { get; set; }
        public string OutFrameHinge3H { get; set; }
        public string OutFrameHinge4H { get; set; }
        public string OutFrameHinge5H { get; set; }
        public string OutFrameHinge6H { get; set; }
        public string OutComments { get; set; }
        public string OutDirection { get; set; }
        public string OutbottomPartR { get; set; }
        public string OutbottomPartL { get; set; }

        public string OutRHS { get; set; }
        public string OutFrameTypeNameText4 { get; set; }
        public string OutimgGevesLine1 { get; set; }
        public string OutimgCut1 { get; set; }
        public string OutimgCut2 { get; set; }
        public string OutimgCut11 { get; set; }
        public string OutimgCut22 { get; set; }
        public string OutimgMain1 { get; set; }
        public string OutimgAlphaBox1 { get; set; }
        public string OutimgLock2 { get; set; }
        public string OutimgLock1 { get; set; }
        public string OutimgProfile1 { get; set; }
        public string OutimgProfile2 { get; set; }
        public string OutimgHingeA1 { get; set; }
        public string OutimgHingeA2 { get; set; }
        public string OutimgHingeA3 { get; set; }
        public string OutimgHingeA4 { get; set; }
        public string OutimgHingeA5 { get; set; }
        public string OutimgHingeA6 { get; set; }
        public string OutimgHingeA7 { get; set; }
        public string OutimgHingeB1 { get; set; }
        public string OutimgHingeB2 { get; set; }
        public string OutimgHingeB3 { get; set; }
        public string OutimgHingeB4 { get; set; }
        public string OutimgHingeB5 { get; set; }
        public string OutimgHingeB6 { get; set; }
        public string OutimgHingeB7 { get; set; }
        public string OutimgHingeC1 { get; set; }
        public string OutimgHingeC2 { get; set; }
        public string OutimgHingeC3 { get; set; }
        public string OutimgHingeC4 { get; set; }
        public string OutimgHingeC5 { get; set; }
        public string OutimgHingeC6 { get; set; }
        public string OutimgHingeC7 { get; set; }
        public string OutimgAlphaCut1 { get; set; }


        public string outPresa_A1 { get; set; }
        public string outPresa_A2 { get; set; }
        public string outPresa_B1 { get; set; }
        public string outPresa_B2 { get; set; }
        public string outPresa_C1 { get; set; }
        public string outPresa_C2 { get; set; }
        public string outPresa_D1 { get; set; }
        public string outPresa_D2 { get; set; }
        public string outPresa_E1 { get; set; }
        public string outPresa_E2 { get; set; }
        public string outPresa_F1 { get; set; }
        public string outPresa_F2 { get; set; }
        public string outPresa_G1 { get; set; }
        public string outPresa_G2 { get; set; } 
        public string outPresa_AA1 { get; set; }
        public string outPresa_AA2 { get; set; }
        public string outPresa_BB1 { get; set; }
        public string outPresa_BB2 { get; set; }
        public string outPresa_CC1 { get; set; }
        public string outPresa_CC2 { get; set; }
        public string outPresa_DD1 { get; set; }
        public string outPresa_DD2 { get; set; }
        public string outPresa_EE1 { get; set; }
        public string outPresa_EE2 { get; set; }
        public string outPresa_FF1 { get; set; }
        public string outPresa_FF2 { get; set; }
        public string outPresa_GG1 { get; set; }
        public string outPresa_GG2 { get; set; }
        
        public string PRT3 { get; set; }
        public string PRA3 { get; set; }
        public string PRM3 { get; set; }
        public string PRF3 { get; set; }
        public string ketum { get; set; }
        public string outBottomPartTestDisplay { get; set; }
        public string outUpperPartSize { get; set; }
        public string outUpperPartType { get; set; }
        public string outPrisaHightHead { get; set; }
        public string outPrisaHight3 { get; set; }




        public clsOutCalcu()
        {
            this.OutFrameWidth = "";
            this.OutFramePlatzWidth = "";
            this.OutFrameMetal_Nitzav = "";
            this.OutFrameMetal_Head = "";
            this.OutFrameMetalWidth_Head = "";
            this.OutFrameMetalWidth_Nitzav = "";
            this.OutFrameAmount_Nitzav = "";
            this.OutFrameAmount_Head = "";
 
            this.OutPrisaHight_Nitzav = "";
            this.OutPriseTest_Nitzav = "";
            this.OutPriseTest_Head = "";
            this.OutFrameThickness = "";
            this.OutWallThickness = "";
            this.OutFrameLock2 = "";
            this.OutFrameLock1 = "";
            this.OutFrameHight = "";
            this.OutFrameHightTop = "";
            this.OutFrameHinge1H = "";
            this.OutFrameHinge2H = "";
            this.OutFrameHinge3H = "";
            this.OutFrameHinge4H = "";
            this.OutFrameHinge5H = "";
            this.OutFrameHinge6H = "";
            this.OutComments = "";
            this.OutDirection = "";
            this.OutbottomPartR = "";
            this.OutbottomPartL = "";
          
            this.OutRHS = "";
            this.OutFrameTypeNameText4 = "";
            this.OutimgGevesLine1 = "";
            this.OutimgCut1 = "";
            this.OutimgCut2 = "";
            this.OutimgCut11 = "";
            this.OutimgCut22 = "";
            this.OutimgMain1 = "";
            this.OutimgAlphaBox1 = "";
            this.OutimgLock2 = "";
            this.OutimgLock1 = "";
            this.OutimgProfile1 = "";
            this.OutimgProfile2 = "";
            this.OutimgHingeA1 = "";
            this.OutimgHingeA2 = "";
            this.OutimgHingeA3 = "";
            this.OutimgHingeA4 = "";
            this.OutimgHingeA5 = "";
            this.OutimgHingeA6 = "";
            this.OutimgHingeA7 = "";
            this.OutimgHingeB1 = "";
            this.OutimgHingeB2 = "";
            this.OutimgHingeB3 = "";
            this.OutimgHingeB4 = "";
            this.OutimgHingeB5 = "";
            this.OutimgHingeB6 = "";
            this.OutimgHingeB7 = "";
            this.OutimgHingeC1 = "";
            this.OutimgHingeC2 = "";
            this.OutimgHingeC3 = "";
            this.OutimgHingeC4 = "";
            this.OutimgHingeC5 = "";
            this.OutimgHingeC6 = "";
            this.OutimgHingeC7 = "";
            this.OutimgAlphaCut1 = "";
            this.FramePlatzHight = "";
        }

      

    }
}
