
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.Calculations
{
    public static class clsImageLibrary
    {




        static string imgpath = clsSettings.GetData().ImagePath;
        //Extra
        static StringBuilder sbAppend = new StringBuilder();
        static string AppendPath(string img)
        {
            string returnTXT;
            sbAppend.Append(imgpath);
            returnTXT = sbAppend.Append(img) .ToString();
            sbAppend.Clear();

            return returnTXT;


        }

        public static string Empty = AppendPath(@"Extra\Empty.gif");
       

        //Frame
        public static string BlackBox = AppendPath(@"Frame\BlackBox.gif");
        
      
        public static string FrameSideBlindClick = AppendPath(@"Frame\FrameSideBlindClick.gif");
        public static string FrameSidePivotClick = AppendPath(@"Frame\FrameSidePivotClick.gif");
        public static string FrameCutAlphaClick = AppendPath(@"Frame\FrameCutAlphaClick.gif");
        public static string FramePocketGevesTopProfile = AppendPath(@"Frame\FramePocketGevesTopProfile.gif");
        public static string FramePocketBetonTopProfile = AppendPath(@"Frame\FramePocketBetonTopProfile.gif");
        public static string FrameSlidingTopProfileRight = AppendPath(@"Frame\FrameSlidingTopProfileRight.gif");
        public static string FrameSlidingTopProfileLeft = AppendPath(@"Frame\FrameSlidingTopProfileLeft.gif");
        public static string FrameSlidingTopProfile = AppendPath(@"Frame\FrameSlidingTopProfile.gif");
        public static string FramePocketGeves = AppendPath(@"Frame\FramePocketGeves.gif");
        public static string FramePocketBeton = AppendPath(@"Frame\FramePocketBeton.gif");
        public static string FrameSliding = AppendPath(@"Frame\FrameSliding.gif");
        public static string FrameSidePivot = AppendPath(@"Frame\FrameSidePivot.gif");
        public static string HingeType1 = AppendPath(@"Frame\HingeType1.gif");
        public static string HingeType2 = AppendPath(@"Frame\HingeType2.gif");
        public static string GevesLine = AppendPath(@"Frame\GevesLine.gif");
        public static string FrameSideF1 = AppendPath(@"Frame\FrameSideF1.gif");
        public static string FrameSideF2 = AppendPath(@"Frame\FrameSideF2.gif");
        public static string FrameSideF1UpperBase = AppendPath(@"Frame\FrameSideF1UpperBase.gif");
        public static string FrameSideF1UpperZigug = AppendPath(@"Frame\FrameSideF1UpperZigug.gif");
        public static string FrameSideF1UpperRefafaR = AppendPath(@"Frame\FrameSideF1UpperRefafaR.gif");
        public static string FrameSideF1UpperSolid = AppendPath(@"Frame\FrameSideF1UpperSolid.gif");
        public static string FrameSideBlind = AppendPath(@"Frame\FrameSideBlind.gif");
        public static string FrameSidePendel = AppendPath(@"Frame\FrameSidePendel.gif");
        public static string FrameSideArusi = AppendPath(@"Frame\FrameSideArusi.gif");
        public static string FrameSideClick = AppendPath(@"Frame\FrameSideClick.gif");
        public static string FrameSideAlbasha = AppendPath(@"Frame\FrameSideAlbasha.gif");
        public static string FrameSideF1KT = AppendPath(@"Frame\FrameSideF1KT.gif");
        public static string FrameSideF2KT = AppendPath(@"Frame\FrameSideF2KT.gif");
        public static string FrameSTR1 = AppendPath(@"Frame\FrameSTR1.gif");
        public static string FrameGIRG = AppendPath(@"Frame\FrameGIRG.gif");
        public static string FrameKT = AppendPath(@"Frame\FrameKT.gif");
        public static string FrameMishtalev = AppendPath(@"Frame\FrameMishtalev.gif");
        public static string FrameHoleA2 = AppendPath(@"Frame\FrameHoleA2.gif");
        public static string FrameLock1 = AppendPath(@"Frame\FrameLock1.gif");
        public static string FrameLock3 = AppendPath(@"Frame\FrameLock3.gif");
        public static string FrameTopLock1 = AppendPath(@"Frame\FrameTopLock1.gif");
        public static string FrameLock2 = AppendPath(@"Frame\FrameLock2.gif");
        public static string FrameCutBlind = AppendPath(@"Frame\FrameCutBlind.gif");
        public static string FrameCutAlbasha = AppendPath(@"Frame\FrameCutAlbasha.gif");
        public static string FrameCutArusi = AppendPath(@"Frame\FrameCutArusi.gif");
        public static string FrameCutClick = AppendPath(@"Frame\FrameCutClick.gif");
        public static string FrameCutPendel = AppendPath(@"Frame\FrameCutPendel.gif");
        public static string FrameCutF1 = AppendPath(@"Frame\FrameCutF1.gif");
        public static string FrameCutAlphaF1 = AppendPath(@"Frame\FrameCutAlphaF1.gif");
        public static string FrameCutF2 = AppendPath(@"Frame\FrameCutF2.gif");
        public static string FrameCutAlphaF2 = AppendPath(@"Frame\FrameCutAlphaF2.gif");
        public static string FrameCutF1KT = AppendPath(@"Frame\FrameCutF1KT.gif");
        public static string FrameCutAlphaF1KT = AppendPath(@"Frame\FrameCutAlphaF1KT.gif");
        public static string FrameCutF2KT = AppendPath(@"Frame\FrameCutF2KT.gif");
        public static string FrameCutAlphaF2KT = AppendPath(@"Frame\FrameCutAlphaF2KT.gif");
        public static string Hinge = AppendPath(@"Frame\Hinge.gif");
        public static string FrameCutBlindClick = AppendPath(@"Frame\FrameCutBlindClick.gif"); 

        //Wing
        public static string WingKantMedicPivotNew = AppendPath(@"Wing\WingKantMedicPivotNew.gif");
        public static string WingKantHiddenPivot = AppendPath(@"Wing\WingKantHiddenPivot.gif");
        public static string WingEmptyDD = AppendPath(@"Wing\WingEmptyDD.gif");
        public static string WingWood4 = AppendPath(@"Wing\WingWood4.gif");
        public static string WingWood3 = AppendPath(@"Wing\WingWood3.gif");
        public static string WingWood2 = AppendPath(@"Wing\WingWood2.gif");
        public static string WingWood1 = AppendPath(@"Wing\WingWood1.gif");
        public static string WingWood5 = AppendPath(@"Wing\WingWood5.gif");
        public static string WingWindowViewPort = AppendPath(@"Wing\WingWindowViewPort.gif");
        public static string WingWindowHatch = AppendPath(@"Wing\WingWindowHatch.gif");
        public static string WingWindowBaloon = AppendPath(@"Wing\WingWindowBaloon.gif");
        public static string WingWindowLens = AppendPath(@"Wing\WingWindowLens.gif");     
        public static string WingWindow3 = AppendPath(@"Wing\WingWindow3.gif");
        public static string WingWindow2 = AppendPath(@"Wing\WingWindow2.gif");
        public static string WingWindow1 = AppendPath(@"Wing\WingWindow1.gif");

        public static string TrisSquareSize = AppendPath(@"Wing\TrisSquareSize.gif");
        public static string TrisTallSize = AppendPath(@"Wing\TrisTallSize.gif");
        public static string TrisWideSize = AppendPath(@"Wing\TrisWideSize.gif");

        public static string TrisSquareSizeMid = AppendPath(@"Wing\TrisSquareSizeMid.gif");
        public static string TrisTallSizeMid = AppendPath(@"Wing\TrisTallSizeMid.gif");
        public static string TrisWideSizeMid = AppendPath(@"Wing\TrisWideSizeMid.gif");
       
        public static string TrisSlotSize = AppendPath(@"Wing\TrisSlotSize.gif");

        public static string WindowSquareSize = AppendPath(@"Wing\WindowSquareSize.gif");
        public static string WindowTallSize = AppendPath(@"Wing\WindowTallSize.gif");
        public static string WindowWideSize = AppendPath(@"Wing\WindowWideSize.gif");

        public static string WindowSquareSizeMid = AppendPath(@"Wing\WindowSquareSizeMid.gif");
        public static string WindowTallSizeMid = AppendPath(@"Wing\WindowTallSizeMid.gif");
        public static string WindowWideSizeMid = AppendPath(@"Wing\WindowWideSizeMid.gif");
       
        public static string WingWindowMtstson = AppendPath(@"Wing\WingWindowViewPort.gif");

        public static string WingTris5 = AppendPath(@"Wing\WingTris5.gif");
        public static string WingTris4 = AppendPath(@"Wing\WingTris4.gif");
        public static string WingTris3 = AppendPath(@"Wing\WingTris3.gif");
        public static string WingTris2 = AppendPath(@"Wing\WingTris2.gif");
        public static string WingTris1 = AppendPath(@"Wing\WingTris1.gif");
        public static string WingLock8 = AppendPath(@"Wing\WingLock8.gif");
        public static string WingLock7 = AppendPath(@"Wing\WingLock7.gif");
        public static string WingLock6 = AppendPath(@"Wing\WingLock6.gif");
        public static string WingLock5 = AppendPath(@"Wing\WingLock5.gif");
        public static string WingLock4 = AppendPath(@"Wing\WingLock4.gif");
        public static string WingLock3 = AppendPath(@"Wing\WingLock3.gif");
        public static string WingLock2 = AppendPath(@"Wing\WingLock2.gif");
        public static string WingLock1 = AppendPath(@"Wing\WingLock1.gif");
        public static string WingKantVisiblePivot = AppendPath(@"Wing\WingKantVisiblePivot.gif");
        public static string WingKantVisibleDouble2 = AppendPath(@"Wing\WingKantVisibleDouble2.gif");
        public static string WingKantVisibleDouble1 = AppendPath(@"Wing\WingKantVisibleDouble1.gif");
        public static string WingKantVisible = AppendPath(@"Wing\WingKantVisible.gif");
        public static string WingKantMedic = AppendPath(@"Wing\WingKantMedic.gif");
        public static string WingKantHiddenDouble2 = AppendPath(@"Wing\WingKantHiddenDouble2.gif");
        public static string WingKantHiddenDouble1 = AppendPath(@"Wing\WingKantHiddenDouble1.gif");
        public static string WingKantMedicDouble2New = AppendPath(@"Wing\WingKantMedicDouble2New.gif");
        public static string WingKantMedicDouble1New = AppendPath(@"Wing\WingKantMedicDouble1New.gif");
        public static string WingKantHidden = AppendPath(@"Wing\WingKantHidden.gif");
        public static string WingKantA = AppendPath(@"Wing\WingKantA.gif");
        public static string WingEmpty = AppendPath(@"Wing\WingEmpty.gif");
        public static string UpperSupport = AppendPath(@"Wing\UpperSupport.gif");
        public static string TrisSide2 = AppendPath(@"Wing\TrisSide2.gif");
        public static string TrisSide1 = AppendPath(@"Wing\TrisSide1.gif");
        public static string SideSupport = AppendPath(@"Wing\SideSupport.gif");
        public static string Hinge3 = AppendPath(@"Wing\Hinge3.gif");
        public static string Hinge2 = AppendPath(@"Wing\Hinge2.gif");
        public static string Hinge1 = AppendPath(@"Wing\Hinge1.gif");
        public static string HingeWing = AppendPath(@"Wing\HingeWing.gif");
        public static string DoubleDoorPole3 = AppendPath(@"Wing\DoubleDoorPole3.gif");
        public static string DoubleDoorPole2 = AppendPath(@"Wing\DoubleDoorPole2.gif");
        public static string DoubleDoorPole1 = AppendPath(@"Wing\DoubleDoorPole1.gif");
        public static string AlphaTop = AppendPath(@"Wing\AlphaTop.gif");
        public static string AlphaPole = AppendPath(@"Wing\AlphaPole.gif");
        public static string WingProfile1 = AppendPath(@"Wing\WingProfile1.gif");
        public static string WingProfile2 = AppendPath(@"Wing\WingProfile2.gif");
        public static string WingProfile3 = AppendPath(@"Wing\WingProfile3.gif");
        public static string WingProfile4 = AppendPath(@"Wing\WingProfile4.gif");
        //advanced
        public static string UpDoorHandleLeftD = AppendPath(@"Wing\UpDoorHandleLeftD.gif");
        public static string UpDoorHandleLeftU = AppendPath(@"Wing\UpDoorHandleLeftU.gif");
        public static string UpDoorHandlePush = AppendPath(@"Wing\UpDoorHandlePush.gif");
        public static string UpDoorHandleRightD = AppendPath(@"Wing\UpDoorHandleRightD.gif");
        public static string UpDoorHandleRightU = AppendPath(@"Wing\UpDoorHandleRightU.gif");
        public static string UpDoorOpenLeft = AppendPath(@"Wing\UpDoorOpenLeft.gif");
        public static string UpDoorOpenRight = AppendPath(@"Wing\UpDoorOpenRight.gif");
        public static string UpDoorSupport = AppendPath(@"Wing\UpDoorSupport.gif");


    }
}
