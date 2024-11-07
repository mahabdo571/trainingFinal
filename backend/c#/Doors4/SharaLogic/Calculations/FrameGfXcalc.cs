using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Diagnostics.Eventing.Reader;


namespace SharaLogic.Calculations
{
    public class FrameGfXcalc
    {
       
        public string FrameType { get; set; }
        public string LockType { get; set; }
        public string Test1 { get; set; }
        public string Test4 { get; set; }
        public string UpperPart { get; set; }
        public string Dirction { get; set; }
        public bool GevesFlach { get; set; }
        public bool isDD { get; set; }
        public int HingeAmount { get; set; }

        public bool TopHinge { get;set; }
        
        
        public string img1 = clsImageLibrary.Empty;

        public string img2 = clsImageLibrary.Empty;

        public string img3 = clsImageLibrary.Empty;
        public string img4 = clsImageLibrary.Empty;
        public string img5 = clsImageLibrary.Empty;
        public string img6 = clsImageLibrary.Empty;
        public string img7 = clsImageLibrary.Empty;
        public string img8 = clsImageLibrary.Empty;
        public string img9 = clsImageLibrary.Empty;
        public string img10 = clsImageLibrary.Empty;
        public string img11 = clsImageLibrary.Empty;
        public string img12 = clsImageLibrary.Empty;

        public string imgHA1 = clsImageLibrary.Empty;
        public string imgHA2 = clsImageLibrary.Empty;
        public string imgHA3 = clsImageLibrary.Empty;
        public string imgHA4 = clsImageLibrary.Empty;
        public string imgHA5 = clsImageLibrary.Empty;
        public string imgHA6 = clsImageLibrary.Empty;
        public string imgHA7 = clsImageLibrary.Empty;
         
        public string imgHB1 = clsImageLibrary.Empty;
        public string imgHB2 = clsImageLibrary.Empty;
        public string imgHB3 = clsImageLibrary.Empty;
        public string imgHB4 = clsImageLibrary.Empty;
        public string imgHB5 = clsImageLibrary.Empty;
        public string imgHB6 = clsImageLibrary.Empty;
        public string imgHB7 = clsImageLibrary.Empty;

        public void PrintCalc3()
        {

            //if (frameTypeName == "RegularF1")
            //{
            //    return clsImageLibrary.FrameSideF1;
            //}
            //else if (frameTypeName == "RegularF2")
            //{
            //   return clsImageLibrary.FrameSideF2;
            //}
            //else
            //{
            //    return null;
            //}

          


        }

        public void PrintCalc1()
        {
        

            //geves
            if(GevesFlach == true)
            {
                img10 = clsImageLibrary.GevesLine;
            }
            else
            {
                img10 = clsImageLibrary.Empty;
            }


            //profile
            if (UpperPart == "זיגוג")
            {
                img1 = clsImageLibrary.FrameSideF1UpperBase;
                img7 = clsImageLibrary.FrameSideF1UpperZigug;
            }
            else if (UpperPart == "תריס")
            {
                img1 = clsImageLibrary.FrameSideF1UpperBase;
                img7 = clsImageLibrary.FrameSideF1UpperRefafaR;
            }
            else if (UpperPart == "קבוע")
            {
                img1 = clsImageLibrary.FrameSideF1UpperBase;
                img7 = clsImageLibrary.FrameSideF1UpperSolid;
            }
            else
            {
                img7 = clsImageLibrary.Empty;

                if (FrameType == "RegularStandartF1BT" || FrameType == "RegularStandartF1GV" || FrameType == "AlphaStandartF1BT" || FrameType == "AlphaStandartF1GV")
                {
                    img1 = clsImageLibrary.FrameSideF1;
                }
                else if (FrameType == "RegularStandartF2BT" || FrameType == "RegularStandartF2GV" || FrameType == "AlphaStandartF2BT" || FrameType == "AlphaStandartF2GV")
                {
                    img1 = clsImageLibrary.FrameSideF2;
                }
                else if (FrameType == "BlindStandartBT" || FrameType == "BlindStandartGV")
                {
                    img1 = clsImageLibrary.FrameSideBlind;
                }
                else if (FrameType == "PendelStandartBT" || FrameType == "PendelStandartGV")
                {
                    img1 = clsImageLibrary.FrameSidePendel;
                }
                else if (FrameType == "RegularArusi")
                {
                    img1 = clsImageLibrary.FrameSideArusi;
                }
                else if (FrameType == "RegularClick" || FrameType == "AlphaClick")
                {
                    img1 = clsImageLibrary.FrameSideClick;
                }
                else if (FrameType == "RegularHalbasha" || FrameType == "AlphaHalbasha")
                {
                    img1 = clsImageLibrary.FrameSideAlbasha;
                }
                else if (FrameType == "RegularKantTiachF1BT" || FrameType == "RegularKantTiachF1GV" || FrameType == "AlphaKantTiachF1BT" || FrameType == "AlphaKantTiachF1GV")
                {
                    img1 = clsImageLibrary.FrameSideF1KT;
                }
                else if (FrameType == "RegularKantTiachF2BT" || FrameType == "RegularKantTiachF2GV" || FrameType == "AlphaKantTiachF2BT" || FrameType == "AlphaKantTiachF2GV")
                {
                    img1 = clsImageLibrary.FrameSideF2KT;
                } else if (FrameType == "PivotStandartBT" || FrameType == "PivotKantTiachBT" || FrameType == "PivotStandartGV" || FrameType == "PivotKantTiachGV" )
                {
                    img1 = clsImageLibrary.FrameSidePivot;

                }else if(FrameType == "PivotClick")
                {
                    img1 = clsImageLibrary.FrameSidePivotClick;

                }else if(FrameType == "BlindClick")
                {
                    img1 = clsImageLibrary.FrameSideBlindClick;
                }
                else
                {
                    img1 = clsImageLibrary.Empty;
                }
            }
         
            //main photo
            if (FrameType == "BlindStandartBT" || FrameType == "PivotStandartBT" || FrameType == "PivotStandartGV" || FrameType == "RegularStandartF1BT" ||  FrameType == "RegularStandartF2BT" || FrameType == "AlphaStandartF1BT" || FrameType == "AlphaStandartF2BT")
            {
                img2 = clsImageLibrary.FrameGIRG;
                img11 = clsImageLibrary.Empty;
                img12 = clsImageLibrary.Empty;
                //img2 = clsImageLibrary.FrameSTR1; //Old straight photo, ronen dont want
            }
            else if (FrameType == "PendelStandartBT" || FrameType == "PendelStandartGV")
            {

                img2 = clsImageLibrary.FrameGIRG;

            }
            else if(FrameType == "BlindStandartGV" || FrameType == "RegularStandartF1GV" || FrameType == "RegularStandartF2GV" || FrameType == "AlphaStandartF1GV" || FrameType == "AlphaStandartF2GV")
            {
                img2 = clsImageLibrary.FrameGIRG;
                img11 = clsImageLibrary.Empty;
                img12 = clsImageLibrary.Empty;
            }
            else if(FrameType == "RegularKantTiachF1BT" || FrameType == "PivotKantTiachBT" || FrameType == "PivotKantTiachGV" ||  FrameType == "RegularKantTiachF2BT" || FrameType == "RegularKantTiachF1GV" || FrameType == "RegularKantTiachF2GV" || FrameType == "AlphaKantTiachF1BT" || FrameType == "AlphaKantTiachF2BT" || FrameType == "AlphaKantTiachF1GV" || FrameType == "AlphaKantTiachF2GV")
            {
                img2 = clsImageLibrary.FrameKT;
                img11 = clsImageLibrary.Empty;
                img12 = clsImageLibrary.Empty;
            }
            else if(FrameType == "RegularHalbasha" || FrameType == "AlphaHalbasha" || FrameType == "BlindHalbasha")
            {
                img2 = clsImageLibrary.FrameGIRG;
                img11 = clsImageLibrary.Empty;
                img12 = clsImageLibrary.Empty;
            }     
            else if(FrameType == "RegularMishtalev" || FrameType == "RegularClick" || FrameType == "PivotClick" || FrameType == "AlphaClick" || FrameType == "BlindClick")
            {
                img2 = clsImageLibrary.FrameMishtalev;
                img11 = clsImageLibrary.Empty;
                img12 = clsImageLibrary.Empty;
            }
            else if (FrameType == "RegularArusi")
            {
                img2 = clsImageLibrary.FrameKT;
                img11 = clsImageLibrary.Empty;
                img12 = clsImageLibrary.Empty;
            }
            else if (FrameType == "SlidingBT" || FrameType == "SlidingGV")
            {
                img11 = clsImageLibrary.FrameSliding;
                img2 = clsImageLibrary.Empty;


                if (Dirction == "Left")
                {
                    img12 = clsImageLibrary.FrameSlidingTopProfileLeft;
                }
                else if (Dirction == "RIGHT")
                {
                    img12 = clsImageLibrary.FrameSlidingTopProfileRight;
                }
                else
                {
                    img12 = clsImageLibrary.Empty;
                }
             
               

            }  else if (FrameType == "SlidingPocketBT")
            {
                img11 = clsImageLibrary.FramePocketBeton;
                img12 = clsImageLibrary.FramePocketBetonTopProfile;
                img2 = clsImageLibrary.Empty;
            } 
            else if (FrameType == "SlidingPocketGV")
            {
                img11 = clsImageLibrary.FramePocketGeves;
                img12 = clsImageLibrary.FramePocketGevesTopProfile;
                img2 = clsImageLibrary.Empty;
            }  
           
            else
            {
                img2 = clsImageLibrary.Empty;
                img2 = clsImageLibrary.Empty;
            }

            //Alpha box
            if (Test1 == "Alpha")
            {
                img3 = clsImageLibrary.BlackBox;
                img4 = clsImageLibrary.FrameHoleA2;
            }
            else
            {
                img3 = clsImageLibrary.Empty;
                img4 = clsImageLibrary.Empty;
            }

            //Lock
            if(LockType == "Sharabany")
            {
                img5 = clsImageLibrary.FrameLock1;
                img6 = clsImageLibrary.Empty;
            }
            else if(LockType == "Electric")
            {
                img5 = clsImageLibrary.FrameLock3;
                img6 = clsImageLibrary.Empty;
            }
            else if (LockType == "JordanKafol")
            {
                img5 = clsImageLibrary.FrameLock1;
                img6 = clsImageLibrary.FrameTopLock1;
            }
            else if (LockType == "Publock")
            {
                img5 = clsImageLibrary.FrameLock2 ;
                img6 = clsImageLibrary.Empty;
            }
            else
            {
                img5 = clsImageLibrary.Empty;
                img6 = clsImageLibrary.Empty;
            }

       

        }
        public void PrintCalc2()
        {
            


            //עיוור
            if (FrameType == "BlindStandartBT" || FrameType == "BlindStandartGV" || FrameType == "SlidingBT" || FrameType == "SlidingGV" || FrameType == "PivotStandartBT" || FrameType == "PivotStandartGV")
            {
                img8 = clsImageLibrary.FrameCutBlind;
                img9 = clsImageLibrary.Empty;
            }
            else if (FrameType == "RegularHalbasha" || FrameType == "AlphaHalbasha")
            {
                img8 = clsImageLibrary.FrameCutAlbasha;
                img9 = clsImageLibrary.Empty;
                if (FrameType == "AlphaHalbasha")
                {//koko
                    img9 = clsImageLibrary.FrameCutAlbasha;
                }
                 

            }
            else if (FrameType == "RegularArusi")
            {
                img8 = clsImageLibrary.FrameCutArusi;
                img9 = clsImageLibrary.Empty;
            }
            else if(FrameType == "RegularClick" || FrameType == "AlphaClick")
            {
                img8 = clsImageLibrary.FrameCutClick;
                img9 = clsImageLibrary.Empty;
                if (FrameType == "AlphaClick")
                {//koko
                    img9 = clsImageLibrary.FrameCutAlphaClick;
                }
                
            }
            else if (FrameType == "PendelStandartBT" || FrameType == "PendelStandartGV")
            {
                img8 = clsImageLibrary.FrameCutPendel;

                if (isDD)
                {
                    img9 = clsImageLibrary.FrameCutPendel;
                }else
                {
                    img9 = clsImageLibrary.FrameCutBlind;
                }
        
            }
            else if (FrameType == "RegularStandartF1BT" || FrameType == "RegularStandartF1GV" || FrameType == "AlphaStandartF1BT" || FrameType == "AlphaStandartF1GV")
            {
                img8 = clsImageLibrary.FrameCutF1;
                img9 = clsImageLibrary.Empty;
                if (FrameType == "AlphaStandartF1BT" || FrameType == "AlphaStandartF1GV")
                {
                    img9 = clsImageLibrary.FrameCutAlphaF1;
                }
            }
            else if (FrameType == "RegularStandartF2BT" || FrameType == "RegularStandartF2GV" || FrameType == "AlphaStandartF2BT" || FrameType == "AlphaStandartF2GV")
            {
                img8 = clsImageLibrary.FrameCutF2;
                img9 = clsImageLibrary.Empty;
                if (FrameType == "AlphaStandartF2BT" || FrameType == "AlphaStandartF2GV")
                {
                    img9 = clsImageLibrary.FrameCutAlphaF2;
                }
            }
            else if (FrameType == "RegularKantTiachF1BT" || FrameType == "RegularKantTiachF1GV" || FrameType == "AlphaKantTiachF1BT" || FrameType == "AlphaKantTiachF1GV")
            {
                img8 = clsImageLibrary.FrameCutF1KT;
                img9 = clsImageLibrary.Empty;
                if (FrameType == "AlphaKantTiachF1BT" || FrameType == "AlphaKantTiachF1GV")
                {
                    img9 = clsImageLibrary.FrameCutAlphaF1KT;
                }
            }
            else if (FrameType == "RegularKantTiachF2BT" || FrameType == "RegularKantTiachF2GV" || FrameType == "AlphaKantTiachF2BT" || FrameType == "AlphaKantTiachF2GV")
            {
                img8 = clsImageLibrary.FrameCutF2KT;
                img9 = clsImageLibrary.Empty;
                if (FrameType == "AlphaKantTiachF2BT" || FrameType == "AlphaKantTiachF2GV")
                {
                    img9 = clsImageLibrary.FrameCutAlphaF2KT;
                }
            }

            else if (FrameType == "PivotClick" ||FrameType == "BlindClick")
            {
                img8 = clsImageLibrary.FrameCutBlindClick;
                img9 = clsImageLibrary.Empty;
            }
            else
            {
                img8 = clsImageLibrary.Empty;
                img9 = clsImageLibrary.Empty;
            }
                    
        }
        public void PrintCalc4() //Hinge GFX calc
        {
            if (Test1 == "Regular" || Test1 == "Pendel")
            {
                imgHA1 = clsImageLibrary.Hinge;
                imgHA7 = clsImageLibrary.Hinge;
                if (HingeAmount == 2)
                {
                    imgHA1 = clsImageLibrary.Hinge;
                    imgHA7 = clsImageLibrary.Hinge;

                    imgHA2 = clsImageLibrary.Empty;
                    imgHA3 = clsImageLibrary.Empty;
                    imgHA4 = clsImageLibrary.Empty;
                    imgHA5 = clsImageLibrary.Empty;
                    imgHA6 = clsImageLibrary.Empty;
                }
                else if(HingeAmount == 3)
                {
                    if(TopHinge ==true)
                    {
                        imgHA1 = clsImageLibrary.Hinge;
                        imgHA2 = clsImageLibrary.Hinge;
                        imgHA7 = clsImageLibrary.Hinge;

                        imgHA4 = clsImageLibrary.Empty;
                        imgHA3 = clsImageLibrary.Empty;
                        imgHA5 = clsImageLibrary.Empty;
                        imgHA6 = clsImageLibrary.Empty;
                    }
                    else
                    {
                        imgHA1 = clsImageLibrary.Hinge;
                        imgHA4 = clsImageLibrary.Hinge;
                        imgHA7 = clsImageLibrary.Hinge;

                        imgHA2 = clsImageLibrary.Empty;
                        imgHA3 = clsImageLibrary.Empty;
                        imgHA5 = clsImageLibrary.Empty;
                        imgHA6 = clsImageLibrary.Empty;
                    }
                
                }
                else if (HingeAmount == 4)
                {
                    imgHA1 = clsImageLibrary.Hinge;
                    imgHA3 = clsImageLibrary.Hinge;
                    imgHA5 = clsImageLibrary.Hinge;
                    imgHA7 = clsImageLibrary.Hinge;

                    imgHA2 = clsImageLibrary.Empty;                   
                    imgHA4 = clsImageLibrary.Empty;                   
                    imgHA6 = clsImageLibrary.Empty;
                }
                else if (HingeAmount == 5)
                {
                    imgHA1 = clsImageLibrary.Hinge;
                    imgHA2 = clsImageLibrary.Hinge;
                    imgHA4 = clsImageLibrary.Hinge;
                    imgHA5 = clsImageLibrary.Empty;
                    imgHA7 = clsImageLibrary.Hinge;
    
                    imgHA3 = clsImageLibrary.Empty;                   
                    imgHA6 = clsImageLibrary.Hinge;
                }
                else if (HingeAmount == 6)
                {
                    imgHA1 = clsImageLibrary.Hinge;                
                    imgHA2 = clsImageLibrary.Hinge;
                    imgHA3 = clsImageLibrary.Hinge;
                    imgHA4 = clsImageLibrary.Hinge;
                    imgHA5 = clsImageLibrary.Hinge;
                    imgHA6 = clsImageLibrary.Hinge;
                    imgHA7 = clsImageLibrary.Hinge;
                }

            }
            else
            {
                imgHA1 = clsImageLibrary.Empty;
                imgHA2 = clsImageLibrary.Empty;
                imgHA3 = clsImageLibrary.Empty;
                imgHA4 = clsImageLibrary.Empty;
                imgHA5 = clsImageLibrary.Empty;
                imgHA6 = clsImageLibrary.Empty;
                imgHA7 = clsImageLibrary.Empty;

                imgHB1 = clsImageLibrary.Empty;
                imgHB2 = clsImageLibrary.Empty;
                imgHB3 = clsImageLibrary.Empty;
                imgHB4 = clsImageLibrary.Empty;
                imgHB5 = clsImageLibrary.Empty;
                imgHB6 = clsImageLibrary.Empty;
                imgHB7 = clsImageLibrary.Empty;
               
            }
        }
    }
}
