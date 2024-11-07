using SharaLogic.Calculations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.WingCalc
{
    public class clsWingGFXcalc
    {
        clsWings _wing;
        clsWingWindows _windows;
        clsWingLock _lock;
        clsWingHinge _Hings;
        clsWingAdvanced _Advavn;
        clsWingAddon _addon;

        public clsWingGFXcalc(int WingID)
        {
            _wing = clsWings.Find(WingID);
            if (_wing == null)
                return;



            _windows = clsWingWindows.FindByWingID(WingID);
            _lock = clsWingLock.FindByWingID(WingID);
            _Hings = clsWingHinge.FindByWingID(WingID);
            _Advavn = clsWingAdvanced.FindByWingID(WingID);
            _addon = clsWingAddon.FindByWingID(WingID);
            // _DoubleDoorType = 



        }

        public string GFXWingEmptyMainImg()
        {
            if((_wing != null && _wing.DoubleDoor)|| (_wing != null && _wing.WingType != null && _wing.WingType.TEST1 == "Flash"))
            {
                return clsImageLibrary.WingEmptyDD;

            }
            else
            {
              
                return clsImageLibrary.WingEmpty;
            }
        }

        public string imgGfxDDlockSide()
        {
           
            if (_wing != null && _wing.DDAK == "K")
            {
                clsWingLock templock = clsWingLock.FindByWingID(_wing.DDWingID);
                if (_wing != null && _wing.DoubleDoor && templock.UpperLock && templock.UpperLockMeasure > 0)
                {
                    return clsImageLibrary.DoubleDoorPole2;

                }
                else if (_wing != null && _wing.DoubleDoor && templock.LockType == "Electricity")
                {
                    return clsImageLibrary.DoubleDoorPole3;
                }
                else
                {
                    return clsImageLibrary.DoubleDoorPole1;
                }

            }
            else
            {
                return clsImageLibrary.Empty;
                //if (_wing != null && _wing.DoubleDoor && _lock.UpperLock && _lock.UpperLockMeasure > 0)
                //{
                //    return clsImageLibrary.DoubleDoorPole2;

                //}
                //else if (_wing != null && _wing.DoubleDoor && _lock.LockType == "Electricity")
                //{
                //    return clsImageLibrary.DoubleDoorPole3;
                //}
                //else
                //{
                //    return clsImageLibrary.DoubleDoorPole1;
                //}
            }
        }

        public string imagTrisProfile()
        {
            if (_wing != null && _windows != null)
            {
                if ((_wing.Direction == "Right" && _windows.OpeningDirection == "In") || (_wing.Direction == "Left" && _windows.OpeningDirection == "Out"))
                {
                    return clsImageLibrary.TrisSide2;
                }
                else
                {
                    return clsImageLibrary.TrisSide1;
                }

            }
            else
            {
                return clsImageLibrary.Empty;
            }

        }
        public string ImagLock()
        {
            if (_lock != null && _lock.LockType == "Electricity")
            {
                return clsImageLibrary.Empty;
            }

            if(_wing != null && _wing.DDAK == "K")
            {
                return clsImageLibrary.Empty;
            }

            if (_Advavn != null)
            {
                if (_Advavn.Cylinder && _Advavn.HolesCylinder && (_Advavn.PullSideLever || _Advavn.PushSideLever) && _Advavn.HandleHoles)
                {

                    return clsImageLibrary.WingLock1;

                }
                else if (_Advavn.Cylinder && _Advavn.HolesCylinder && (_Advavn.PullSideLever || _Advavn.PushSideLever) && (!_Advavn.HandleHoles))
                {

                    return clsImageLibrary.WingLock2;

                }
                else if (_Advavn.Cylinder && (!_Advavn.HolesCylinder) && (_Advavn.PullSideLever || _Advavn.PushSideLever) && _Advavn.HandleHoles)
                {

                    return clsImageLibrary.WingLock3;

                }
                else if (_Advavn.Cylinder && _Advavn.HolesCylinder && (!(_Advavn.PullSideLever || _Advavn.PushSideLever)) && (!_Advavn.HandleHoles))
                {

                    return clsImageLibrary.WingLock4;

                }
                else if ((!_Advavn.Cylinder) && (!_Advavn.HolesCylinder) && (_Advavn.PullSideLever || _Advavn.PushSideLever) && _Advavn.HandleHoles)
                {

                    return clsImageLibrary.WingLock5;

                }
                else if ((!_Advavn.Cylinder) && (!_Advavn.HolesCylinder) && (_Advavn.PullSideLever || _Advavn.PushSideLever) && (!_Advavn.HandleHoles))
                {

                    return clsImageLibrary.WingLock6;

                }
                else if (_Advavn.Cylinder && (!_Advavn.HolesCylinder) && (!(_Advavn.PullSideLever || _Advavn.PushSideLever)) && (!_Advavn.HandleHoles))
                {

                    return clsImageLibrary.WingLock7;

                }
                else if (_Advavn.Cylinder && (!_Advavn.HolesCylinder) && (_Advavn.PullSideLever || _Advavn.PushSideLever) && (!_Advavn.HandleHoles))
                {

                    return clsImageLibrary.WingLock8;

                }
                 
                else
                {
                    return clsImageLibrary.Empty;
                }

            }
            else
            {
                return clsImageLibrary.Empty;
            }
        }


        public bool UpDoorOpen(ref string UpDoorOpen, ref string picLittleHandleRU, ref string picLittleHandleRD, ref string picLittleHandleLU
                , ref string picLittleHandleLD, ref string picLittleSupportDN, ref string picLittleSupportUP)
        {
            if (_addon != null && _Advavn != null)
            {
                if ((_addon.Offirt == "NoOffirt" || _addon.Offirt == "Offirt2Side") && (_Advavn.PushSideLever && _Advavn.PullSideLever))
                {
                    UpDoorOpen = clsImageLibrary.Empty;
                    picLittleHandleRU = clsImageLibrary.Empty;
                    picLittleHandleRD = clsImageLibrary.Empty;
                    picLittleHandleLU = clsImageLibrary.Empty;
                    picLittleHandleLD = clsImageLibrary.Empty;
                    picLittleSupportUP = "-1";
                    picLittleSupportDN = "-1";
                    return false;
                }
            }


            if (_addon != null)
            {
                if (_addon.Offirt == "OffirtPullSide")
                {
                    picLittleSupportUP = "True";
                    picLittleSupportDN = "-1";
                }
                else if (_addon.Offirt == "OffirtPushSide")
                {
                    picLittleSupportUP = "-1";
                    picLittleSupportDN = "True";
                }
                else
                {

                    picLittleSupportUP = "-1";
                    picLittleSupportDN = "-1";
                }


            }
            else
            {

                picLittleSupportUP = "-1";
                picLittleSupportDN = "-1";
            }

            if (_wing != null && _Advavn != null)
            {

       
                if (_wing.Direction == "Right")
                {
                      UpDoorOpen = clsImageLibrary.UpDoorOpenRight;
                    
                    
                    if (_Advavn.PushSideLever)
                    {
                        picLittleHandleLD = clsImageLibrary.UpDoorHandleLeftD;

                    
                    }
                    else if (_Advavn.PushHandle)
                    {
                        picLittleHandleLD = clsImageLibrary.UpDoorHandlePush;

                    }
                    else
                    {
                        picLittleHandleLD = clsImageLibrary.Empty;

                      
                    }
                    



                    if (_Advavn.PullSideLever)
                    {
                        picLittleHandleLU = clsImageLibrary.UpDoorHandleLeftU;
                    }
                    else if (_Advavn.PullHandle)
                    {

                        picLittleHandleLU = clsImageLibrary.UpDoorHandlePush;
                    }
                    else
                    {
                        picLittleHandleLU = clsImageLibrary.Empty;
                    }

                    picLittleHandleRU = clsImageLibrary.Empty;
                    picLittleHandleRD = clsImageLibrary.Empty;
           
                }
                else if (_wing.Direction == "Left")
                {
                    UpDoorOpen = clsImageLibrary.UpDoorOpenLeft;

                    if (_Advavn.PushSideLever)
                    {
                        picLittleHandleRD = clsImageLibrary.UpDoorHandleRightD;

                    }
                    else if (_Advavn.PushHandle)
                    {
                        picLittleHandleRD = clsImageLibrary.UpDoorHandlePush;

                
                    }
                    else
                    {
                        picLittleHandleRD = clsImageLibrary.Empty;


               
                    }




                    if (_Advavn.PullSideLever)
                    {

                        picLittleHandleRU = clsImageLibrary.UpDoorHandleRightU;
                    }
                    else if (_Advavn.PullHandle)
                    {
                        picLittleHandleRU = clsImageLibrary.UpDoorHandlePush;
                    }
                    else
                    {
                        picLittleHandleRU = clsImageLibrary.Empty;
                    }



                    picLittleHandleLU = clsImageLibrary.Empty;
                    picLittleHandleLD = clsImageLibrary.Empty;
                }
                else
                {
                    UpDoorOpen = clsImageLibrary.Empty;
                    picLittleHandleRU = clsImageLibrary.Empty;
                    picLittleHandleRD = clsImageLibrary.Empty;
                    picLittleHandleLU = clsImageLibrary.Empty;
                    picLittleHandleLD = clsImageLibrary.Empty;
                }

                return true;
            }
            else
            {
                return false;
            }



        }






        public string Scatch3Text()
        {
            if (_wing == null || _wing.WingType == null)
                return "";

            if (_wing.WingType.TEST2 == "A")
            {
                return "מידת פח";
            }
            else if (_wing.WingType.TEST2 == "F")
            {
                return "מידת פורמייקה";
            }
            else
            {
                return "";
            }
        }
        public string DoorWood()
        {
            if (_wing != null && _wing.WingType != null)
            {
                if (_wing.WingType.TEST1 == "Flash")
                {
                    return clsImageLibrary.WingWood4;
                }
                else if (_wing.WingType.TEST2 == "A")
                {
                    return clsImageLibrary.WingWood3;
                }
                else if (_wing.WingType.TEST3 == "3")
                {
                    return clsImageLibrary.WingWood2;
                }
                else if (_wing.WingType.TEST3 == "4")
                {
                    return clsImageLibrary.WingWood5;
                }
                else if (_wing.WingType.TEST3 == "0")
                {
                    return clsImageLibrary.WingWood1;
                }
                else if (_wing.WingType.TEST3 == "Medic")
                {
                    return clsImageLibrary.WingWood1;
                }

                else
                {
                    return clsImageLibrary.Empty;
                }

            }
            else
            {
                return clsImageLibrary.Empty;
            }
        }

        //<<<<<<< HEAD
        public string DoubleDoorPole()
        {
            //if (_doubledoor != null)
            //{
            //    switch (DoubleDoorLockType)

            //    {
            //        case "Regular":
            //            return clsImageLibrary.DoubleDoorPole1;
            //        case "Electric":
            //            return clsImageLibrary.DoubleDoorPole3;
            //        case "Double":
            //            return clsImageLibrary.DoubleDoorPole2;

            //    }
            //    return clsImageLibrary.Empty;
            //}
            //else
            //{
            //    return clsImageLibrary.Empty;
            //}
            return "";
        }
        //=======
        //public string DoubleDoorPole()
        //{
        //    if (_DoubleDoorType != null)
        //    {
        //        switch (DoubleDoorLockType)

        //        {
        //            case "Regular":
        //                return clsImageLibrary.DoubleDoorPole1;
        //            case "Electric":
        //                return clsImageLibrary.DoubleDoorPole3;
        //            case "Double":
        //                return clsImageLibrary.DoubleDoorPole2;

        //        }
        //        return clsImageLibrary.Empty;
        //    }
        //    else
        //    {
        //        return clsImageLibrary.Empty;
        //    }
        //}

        //>>>>>>> main
        public string KantType()
        {
            if (_wing != null && _wing.WingType != null)
            {
                if (!_wing.DoubleDoor)
                {
                    if (_wing.WingType.TEST1 == "PVT")
                    {
                        if (_wing.WingType.TEST3 == "3" || _wing.WingType.TEST3 == "4")
                        {
                            return clsImageLibrary.WingKantVisiblePivot;
                        }
                        else if(_wing.WingType.TEST3 == "Medic")
                        {
                            return clsImageLibrary.WingKantMedicPivotNew;

                        }
                        else
                        {
                            return clsImageLibrary.WingKantHiddenPivot;
                        }
                    }
                    else if (_wing.WingType.TEST1 == "Flash")
                    {
                        return clsImageLibrary.WingKantVisibleDouble2;
                    }

                    else if (_wing.WingType.TEST2 == "A")
                    {
                        return clsImageLibrary.WingKantA;
                    }

                    else if (_wing.WingType.TEST3 == "0")
                    {
                        return clsImageLibrary.WingKantHidden;
                    }
                    else if (_wing.WingType.TEST3 == "3" || _wing.WingType.TEST3 == "4")
                    {
                        return clsImageLibrary.WingKantVisible;
                    }
                    else if (_wing.WingType.TEST3 == "Medic")
                    {
                        return clsImageLibrary.WingKantMedic;
                    }

                    else
                    {
                        return clsImageLibrary.Empty;
                    }
                }
                else
                {

                    if(_wing.DDAK == "A" && (_wing.WingType.TEST3 == "3" || _wing.WingType.TEST3 == "4") && _wing.WingType.TEST2 == "F")
                    {
                        return clsImageLibrary.WingKantVisibleDouble2;
                    }else if (_wing.DDAK == "K" && (_wing.WingType.TEST3 == "3" || _wing.WingType.TEST3 == "4") && _wing.WingType.TEST2 == "F")
                    {
                        return clsImageLibrary.WingKantVisibleDouble1;
                    }
                    else if (_wing.DDAK == "A" && _wing.WingType.TEST3 == "0"  && _wing.WingType.TEST2 == "F")
                    {
                        return clsImageLibrary.WingKantHiddenDouble2;
                    }
                    else if (_wing.DDAK == "K" && _wing.WingType.TEST3 == "0" && _wing.WingType.TEST2 == "F")
                    {
                        return clsImageLibrary.WingKantHiddenDouble1;
                    }
                    else if (_wing.DDAK == "A" && _wing.WingType.TEST3 == "Medic" && _wing.WingType.TEST2 == "F")
                    {
                        return clsImageLibrary.WingKantMedicDouble1New;

                    }  else if (_wing.DDAK == "K" && _wing.WingType.TEST3 == "Medic" && _wing.WingType.TEST2 == "F")
                    {
                        return clsImageLibrary.WingKantMedicDouble2New;
                    }
                    else if ((_wing.DDAK == "K" ||_wing.DDAK == "A")  && _wing.WingType.TEST2 == "A")
                    {
                        return clsImageLibrary.WingKantA;
                    }
                    else
                    {
                        return clsImageLibrary.Empty;
                    }


                }
                
            }
            else
            {
                return clsImageLibrary.Empty;
            }
        }



        string _NormalWindowSize()
        {
            if (_windows == null)
                return "";

            if (_windows.WindowHeight > _windows.WindowWidth * 2)
            {
                return clsImageLibrary.WingWindow2;
            }
            else if (_windows.WindowHeight < _windows.WindowWidth / 2)
            {
                return clsImageLibrary.WingWindow3;
            }
            else if (_windows.WindowHeight > 1 && _windows.WindowWidth > 1)
            {
                return clsImageLibrary.WingWindow1;
            }
            else
            {
                return clsImageLibrary.WingWindow1;
            }

        }

        public string Windows()
        {
            if (_windows != null)
            {
                switch (_windows.WindowType)
                {
                    case "NoWin":
                        return clsImageLibrary.Empty;
                    case "Normal":
                        return _NormalWindowSize();
                    case "Tsohar":
                        return clsImageLibrary.WingWindowHatch;
                    case "Balon":
                        return clsImageLibrary.WingWindowBaloon;
                    //case "Star":
                    //    return clsImageLibrary.WingWindowStar;
                    case "Old":
                        return clsImageLibrary.WingWindowLens;

                    default:
                        return clsImageLibrary.Empty;
                }
            }
            else
            {
                return clsImageLibrary.Empty;
            }
        }
        public string WindowMessurements()
        {
            if (_windows == null)
                return clsImageLibrary.Empty;


            if (_windows.WindowType == "Normal")
            {
                if (_windows.WindowHeight > _windows.WindowWidth * 2)
                {
                    if (_windows.WindoInCenter)
                        return clsImageLibrary.WindowTallSizeMid;
                    else
                        return clsImageLibrary.WindowTallSize;
                }
                else if (_windows.WindowHeight < _windows.WindowWidth / 2)
                {
                    if (_windows.WindoInCenter)
                        return clsImageLibrary.WindowWideSizeMid;
                    else
                        return clsImageLibrary.WindowWideSize;
                }
                else if (_windows.WindowHeight > 1 && _windows.WindowWidth > 1)
                {
                    if (_windows.WindoInCenter)
                        return clsImageLibrary.WindowSquareSizeMid;
                    else
                        return clsImageLibrary.WindowSquareSize;
                }
                else
                {
                    return clsImageLibrary.Empty;
                }

            }
            else
            {
                return clsImageLibrary.Empty;
            }

        }

        public string trisMessurements()
        {

            if (_windows == null)
                return clsImageLibrary.Empty;


            if (_windows.TrisType == "Wood" || _windows.TrisType == "Alminuom")
            {
                if (_windows.TrisHeight > _windows.TrisWidth * 2)
                {
                    if (_windows.TrisInCenter)
                        return clsImageLibrary.TrisTallSizeMid;
                    else
                        return clsImageLibrary.TrisTallSize;
                }
                else if (_windows.TrisHeight < _windows.TrisWidth / 2)
                {

                    if (_windows.TrisInCenter)
                        return clsImageLibrary.TrisWideSizeMid;
                    else
                        return clsImageLibrary.TrisWideSize;

                }
                else if (_windows.TrisHeight > 1 && _windows.TrisWidth > 1)
                {
                    if (_windows.TrisInCenter)
                        return clsImageLibrary.TrisSquareSizeMid;
                    else
                        return clsImageLibrary.TrisSquareSize;
                }
                else
                {
                    return clsImageLibrary.Empty;
                }
            }
            else if (_windows.TrisType == "Slots")
            {
                return clsImageLibrary.TrisSlotSize;

            }
            else
            {
                return clsImageLibrary.Empty;
            }
        }

        string _TrisSize()
        {
            if (_windows == null)
                return clsImageLibrary.WingTris1;


            if (_windows.TrisHeight > _windows.TrisWidth * 2)
            {
                return clsImageLibrary.WingTris2;
            }
            else if (_windows.TrisHeight < _windows.TrisWidth / 2)
            {
                return clsImageLibrary.WingTris3;
            }
            else if (_windows.TrisHeight > 1 && _windows.TrisWidth > 1)
            {
                return clsImageLibrary.WingTris1;
            }
            else
            {
                return clsImageLibrary.WingTris1;
            }

        }

        public string Tris()
        {
            if (_windows != null)
            {
                switch (_windows.TrisType)
                {
                    case "NoTris":
                        return clsImageLibrary.Empty;
                    case "Wood":
                        return _TrisSize();
                    case "Alminuom":
                        return _TrisSize();
                    case "Slots":
                        return clsImageLibrary.WingTris5;
                    default:
                        return clsImageLibrary.Empty;

                }
            }
            else
            {
                return clsImageLibrary.Empty;
            }
        }

        public string AlphaProfile(ref int HigthProfile)
        {
            if (_wing == null || _wing.WingType == null)
                return "";

            if (_wing.WingType.TEST1 == "ALPH")
            {
                HigthProfile -= 2;
                return clsImageLibrary.AlphaPole;
            }
            else if (_wing.WingType.TEST1 == "PVT")
            {

                return clsImageLibrary.WingProfile2;
            }
            else if (_wing.WingType.TEST1 == "Flash")
            {
                return clsImageLibrary.WingProfile3;
            }
            else if (_wing.WingType.TEST1 == "Sliding")
            {
                return clsImageLibrary.WingProfile4;
            }

            else if (_Hings != null && _Hings.HingeType == "4X3.5")
            {
                return clsImageLibrary.WingProfile1;
            }
            else if (_Hings != null && _Hings.HingeType == "4X4")
            {
                return clsImageLibrary.WingProfile1;
            }
            else
            {
                if (_windows != null)
                {
                    if (_windows.TrisType == "NoTris")
                    {
                        return clsImageLibrary.Empty;
                    }
                    else
                    {
                        return clsImageLibrary.WingProfile1;
                    }
                }
                else
                {
                    return clsImageLibrary.Empty;
                }

            }

            //else
            //{
            //    return clsImageLibrary.Empty;
            //}
        }







    }
}
