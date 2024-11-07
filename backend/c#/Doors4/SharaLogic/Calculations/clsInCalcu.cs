using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.Calculations
{
    public class clsInCalcu
    {

        public double InWallThicknessBox { get; set; }
        public double InFrameThicknessBox { get; set; }
        public int InFrameHight { get; set; }
        public int InFrameWidth { get; set; }
        public int InFrameHightUnderFloor { get; set; }
        public string InDirection { get; set; }
        public string InFrameMetal { get; set; }
        public float InFrameMetalWidth { get; set; }
        public bool InMekasher { get; set; }
        public bool InRHSswitch { get; set; }
        public bool InDoubleDoor { get; set; }
        public bool InGevesFlach { get; set; }
        public string InFrameTypeTest1 { get; set; }
        public string InFrameTypeTest2 { get; set; }
        public string InFrameTypeTest3 { get; set; }
        public string InFrameTypeTest4 { get; set; }
        public string InFrameTypeName { get; set; }
     
        public int InHingeAmount { get; set; }
        public string InLockType { get; set; }
        public int InLockMeasure { get; set; }
        public int InUpperLockMeasure { get; set; }
        public int InLockMeasureFloor { get; set; }
        public int InUpperLockMeasureFloor { get; set; }
        public int Inhinge1 { get; set; }
        public int Inhinge2 { get; set; }
        public int Inhinge3 { get; set; }
        public int Inhinge4 { get; set; }
        public int Inhinge5 { get; set; }
        public int Inhinge6 { get; set; }

        public bool UpperMiddleHinge { get; set; }

        public bool inDisplayBottomPart1 { get;set; }
        public bool inDisplayBottomPart2 { get;set; }
        public int inBottomPartSize { get;set; }
        public int inUpperPartSize { get;set; }
        public string inUpperPartType { get;set; }





        public clsInCalcu()
        {
            this.InWallThicknessBox = 0;
            this.InFrameThicknessBox =0;
            this.InFrameHight = 0;
            this.InFrameWidth = 0;
            this.InFrameHightUnderFloor = 0;
            this.InDirection = "";
            this.InFrameMetal = "";
            this.InFrameMetalWidth =0;
            this.InMekasher = false;
            this.InRHSswitch = false;
            this.InDoubleDoor = false;
            this.InGevesFlach = false;
            this.InFrameTypeTest1 = "";
            this.InFrameTypeTest2 = "";
            this.InFrameTypeTest3 = "";
            this.InFrameTypeTest4 = "";
            this.InLockType = "";
            this.InFrameTypeName = "";
      
            this.InHingeAmount = 3;
        
        }
    }
}
