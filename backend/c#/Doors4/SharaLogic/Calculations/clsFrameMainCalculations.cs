using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;



namespace SharaLogic.Calculations
{
    public class clsFrameMainCalculations
    {

        public clsOutCalcu OUT;
        public clsInCalcu IN;

        FrameDefault _FD;
        PrisaCalc _PC;
        FrameGfXcalc GFX;
        HingeCalc _HCU;
        LockCalc _LKC;
        clsUpperPartCalc _UPcalc;
        clsFrameMesurementsClac _CFMC;
        clsPrisaBoxSizeCalc _CPBSC;
        clsFrames _frame;
        clsHingesFrames _hinge;
        clsFrameLockType _lock;
        clsFrameType _typeframe;
        double _FrameCalcThicknesA;
        double _FrameCalcThicknesB;
        int frameID;
     

        public clsFrameMainCalculations(int frameID_)
        {
            this.IN = new clsInCalcu();
            this.OUT = new clsOutCalcu();
            _FD = new FrameDefault(frameID_);
            _PC = new PrisaCalc();
            GFX = new FrameGfXcalc();
            _HCU = new HingeCalc();
            _LKC = new LockCalc();
            _UPcalc = new clsUpperPartCalc();
            _CFMC = new clsFrameMesurementsClac();
            _CPBSC = new clsPrisaBoxSizeCalc();
            frameID = frameID_;
            _frame = clsFrames.Find(frameID);
            if (_frame != null)
            {
                _typeframe = clsFrameType.FindByFrameID(frameID);



                if (_typeframe != null)
                {
                    this.IN.InDirection = _frame.Direction;
                    this.IN.InFrameTypeTest1 = _typeframe.AgroupOfDoorFrames;
                    this.IN.InFrameTypeTest2 = _typeframe.TypeOfDoorFrame;
                    this.IN.InFrameTypeTest3 = _typeframe.LevelType;
                    this.IN.InFrameTypeTest4 = _typeframe.WallType;
                    this.IN.InFrameTypeName = _frame.FrameType;
                    this.IN.InFrameWidth = _frame.Width;
                    this.IN.InFrameHight = _frame.Height;
                    this.IN.InFrameHightUnderFloor = _frame.FrameUnderFloor;
                    this.IN.InHingeAmount = clsHingesFrames.FindByFrameID(_frame.ID) == null ? 0 : clsHingesFrames.FindByFrameID(_frame.ID).HingeAmount;



                }
            }
        }

        void _PrisaBoxSizeCalc()
        {


            int.TryParse(_FrameWidth(), out int result_FrameWidth);
            _CPBSC.inOwidth = result_FrameWidth;
            int.TryParse(_FrameHight(), out int result_FrameHight);
            _CPBSC.inOheight = result_FrameHight;
            _CPBSC.inOFrameType = this.IN.InFrameTypeName;
            int.TryParse(_FramePlatzWidth(), out int result_FramePlatzWidth);
            _CPBSC.inOplzWidth = result_FramePlatzWidth;
            _CPBSC.inOBottomSize = this.IN.inBottomPartSize;

            
            this.OUT.OutPrisaHight_Nitzav = _CPBSC.outNtsav1() <= 0 ? "Empty" : _CPBSC.outNtsav1().ToString();
            this.OUT.outPrisaHightHead = _CPBSC.outhead1()<=0 ? "Empty" : _CPBSC.outhead1().ToString();
            this.OUT.outPrisaHight3 = _CPBSC.outkitum1() <= 0 ? "Empty" : _CPBSC.outkitum1().ToString();




        }

        void UpperPart()
        {
            _UPcalc.inDisplayBottomPart1 = this.IN.inDisplayBottomPart1;
            _UPcalc.inDisplayBottomPart2 = this.IN.inDisplayBottomPart2;
            _UPcalc.inBottomPartSize = this.IN.inBottomPartSize;
            _UPcalc.inUpperPartSize = this.IN.inUpperPartSize;
            _UPcalc.inUpperPartType = this.IN.inUpperPartType;
            _UPcalc.exeute();


            if (_UPcalc.outBottomPartTestDisplay == "")
            {

                this.OUT.outBottomPartTestDisplay = "Empty";
            }
            else
            {
                this.OUT.outBottomPartTestDisplay = _UPcalc.outBottomPartTestDisplay;
            }
            this.OUT.outUpperPartType = _UPcalc.outUpperPartType;

            if (_UPcalc.outUpperPartSize <= 0)
            {
                this.OUT.outUpperPartSize = "Empty";
            }
            else
            {
                this.OUT.outUpperPartSize = _UPcalc.outUpperPartSize.ToString();
            }
        }

        void lockCalcOut()
        {


            if (this.IN.InFrameTypeTest1 == "Blind")
            {
                this.OUT.OutFrameLock1 = "Empty";
                this.OUT.OutFrameLock2 = "Empty";
                return;
            }
           
            _lock = clsFrameLockType.FindByFrameID(frameID);

            if(_lock != null && _lock.NoCalcu)
            {
                _LKC.FrameHightDisplay = 2100;
            }
            else
            {
                _LKC.FrameHightDisplay = this.IN.InFrameHight;
            }   
            
            
            if(_lock != null && _lock.SlipCan)
            {
                this.OUT.slipcanlock = "פחית החלקה";
            }
            else
            {
                this.OUT.slipcanlock ="Empty";
            }

        
            _LKC.LockW = this.IN.InLockMeasure;
            _LKC.LockW2 = this.IN.InUpperLockMeasure;
            _LKC.LockX = this.IN.InLockMeasureFloor;
            _LKC.LockX2 = this.IN.InUpperLockMeasureFloor;
            _LKC.lockType = this.IN.InLockType;

            _LKC.LocksCalc();

            if (_LKC.LockHight <= 0)
            {
                this.OUT.OutFrameLock1 = "Empty";
            }
            else
            {
                if (_LKC.lockType == "Electric")
                {
                   
                    this.OUT.OutFrameLock1 = (_LKC.LockHight+17).ToString();
                }
                else
                {
                  
                    this.OUT.OutFrameLock1 = _LKC.LockHight.ToString();
                }
              
            }
            if (_LKC.UpperLockHight <= 0)            {
                this.OUT.OutFrameLock2 = "Empty";
            }
            else
            {
                this.OUT.OutFrameLock2 = _LKC.UpperLockHight.ToString();
            }


        }
        string _Direction()
        {

        if (this.IN.InFrameTypeTest1 == "Blind")
            {
                return "Empty";
            }

                if (this.IN.InDirection == "RIGHT")
            {
                return "ימין";
            }
            else if( this.IN.InDirection == "Left")
            {
                return "שמאל";
            }
            else
            {
                return "Empty";
            }

        }

        void calcHingeIn()
        {

            _HCU.FH1H = IN.Inhinge1;
            _HCU.FH2H = IN.Inhinge2;
            _HCU.FH3H = IN.Inhinge3;
            _HCU.FH4H = IN.Inhinge4;
            _HCU.FH5H = IN.Inhinge5;
            _HCU.FH6H = IN.Inhinge6;
            _HCU.HingeAmount = this.IN.InHingeAmount;
            _hinge = clsHingesFrames.FindByFrameID(frameID);
            if (_hinge != null)
            {
                if (_hinge.NoCalcu)
                {
                    _HCU.DisplayHingeFrameHight = 2100;
                }
                else
                {
                    _HCU.DisplayHingeFrameHight = this.IN.InFrameHight;
                }
            }
     
           

            if (IN.UpperMiddleHinge == true)
            {
                _HCU.UpperMiddleHinge = 519;
            }
            else if (this.IN.InHingeAmount > 3)
            {
                _HCU.UpperMiddleHinge = 519;
            }
            else
            {
                _HCU.UpperMiddleHinge = 956;
            }

            _HCU.HingesCalc();


        }

        void calcHingeOut()
        {
            calcHingeIn();

            OUT.OutFrameHinge1H = _HCU.F1H.ToString();
            OUT.OutFrameHinge2H = _HCU.F2H.ToString();
            OUT.OutFrameHinge3H = _HCU.F3H.ToString();
            OUT.OutFrameHinge4H = _HCU.F4H.ToString();
            OUT.OutFrameHinge5H = _HCU.F5H.ToString();
            OUT.OutFrameHinge6H = _HCU.F6H.ToString();




        }

        void GFXCalc()
        {
            UpperPart();
            GFX.FrameType = this.IN.InFrameTypeName;
            GFX.Dirction = this.IN.InDirection;

            GFX.Test1 = this.IN.InFrameTypeTest1;
            GFX.LockType = this.IN.InLockType;
            GFX.UpperPart = _UPcalc.outUpperPartType;
            GFX.GevesFlach = this.IN.InGevesFlach;
            GFX.Test4 = this.IN.InFrameTypeTest4;
            GFX.TopHinge = this.IN.UpperMiddleHinge;
            GFX.isDD = this.IN.InDoubleDoor;

            GFX.HingeAmount = this.IN.InHingeAmount;

            GFX.PrintCalc1();
            GFX.PrintCalc3();
            GFX.PrintCalc2();
            GFX.PrintCalc4();
        }

        string _ImgMain1()
        {


            GFXCalc();


            return GFX.img2;



        }    
        string _ImgMainSliding()
        {


            GFXCalc();


            return GFX.img11;



        }    
 
string imgFramePocketTopProfile()
        {


            GFXCalc();


            return GFX.img12;



        }

        string _ImgAlphaBox1()
        {
            GFXCalc();


            return GFX.img3;



        }
        string _ImgProfile1()
        {
            GFXCalc();

            return GFX.img1;


        }

        string _ImgProfile2()
        {
            GFXCalc();

            return GFX.img7;



        }

        string _ImgCut1()
        {
            GFXCalc();

            return GFX.img8;



        }

        string _FrameWidth()
        {
            if (this.IN.InFrameWidth <= 0 /*|| _frame.FrameType == "SlidingPocketGV" || _frame.FrameType == "SlidingPocketBT"*/)
            {
                return "Empty";
            }
            else//koko
            {
                _CFMC.inWidth = this.IN.InFrameWidth;
                _CFMC.inHeight = this.IN.InFrameHight;
                _CFMC.inFrameType = this.IN.InFrameTypeName;

                return _CFMC.outWidth().ToString();
            }


        }     
        
        int _FrameWidthint()
        {
            if (this.IN.InFrameWidth <= 0 || _frame.FrameType== "SlidingPocketGV" || _frame.FrameType == "SlidingPocketBT")
            {
                return 0;
            }
            else
            {
                _CFMC.inWidth = this.IN.InFrameWidth;
                _CFMC.inHeight = this.IN.InFrameHight;
                _CFMC.inFrameType = this.IN.InFrameTypeName;

                return _CFMC.outWidth();
            }


        }



        string _FramePlatzWidth()
        {


            _PriseCalc();
            if (this.IN.InFrameWidth <= 0 || (this.IN.InFrameWidth - (_FD.A1 * 2)) <= 0)
            {
                return "Empty";
            }
            else if (_FD.E1 >0 && IN.InFrameTypeTest2 != "Halbasha")
                {
                return (Math.Round(_FrameWidthint() - (_FD.A1 * 2) - ((_FD.E1 * 2) - Math.Ceiling(_PC.MeterialThickness*2)))).ToString();
                 }
            else
            {
                return (Math.Round(_FrameWidthint() - (_FD.A1 * 2))).ToString();
            }

        }



        string _FrameHight()
        {
          
            if (this.IN.InFrameHight <= 0)
            {
                return "Empty";
            }
            else
            {
                _CFMC.inWidth = this.IN.InFrameWidth;
                _CFMC.inHeight = this.IN.InFrameHight;
                _CFMC.inFrameType = this.IN.InFrameTypeName;

                return  (_CFMC.outHeight() + this.IN.InFrameHightUnderFloor).ToString();
            }

        }
        int _FrameHightint()
        {
            if (this.IN.InFrameHight <= 0)
            {
                return 0;
            }
            else
            {
                _CFMC.inWidth = this.IN.InFrameWidth;
                _CFMC.inHeight = this.IN.InFrameHight;
                _CFMC.inFrameType = this.IN.InFrameTypeName;

                return (_CFMC.outHeight() + this.IN.InFrameHightUnderFloor);
            }

        }


        void _FrameThicknessChange(double ThicknessSubtitutions)
        {



            if (this.IN.InWallThicknessBox != 0 && this.IN.InFrameThicknessBox == 0)
            {
                _FrameCalcThicknesB = this.IN.InWallThicknessBox;
                _FrameCalcThicknesA = (this.IN.InWallThicknessBox + ThicknessSubtitutions);




            }

            else if (this.IN.InFrameThicknessBox != 0 && this.IN.InWallThicknessBox == 0)
            {

                _FrameCalcThicknesA = this.IN.InFrameThicknessBox;

                _FrameCalcThicknesB = (this.IN.InFrameThicknessBox - ThicknessSubtitutions);
            }


        }

        void _PriseCalc()
        {
            _PC.PRT4 = 0;
            _PC.isdd = this.IN.InDoubleDoor;
            _PC.FrameName = this.IN.InFrameTypeName;
            _PC.MeterialThickness = this.IN.InFrameMetalWidth;
            _FrameThicknessChange(_PC.Subtitutions);
            _PC.FrameTestThickness = _FrameCalcThicknesA;
            _PC.FramePrisa(ref _FD);
           
        }

        string _PriseTestNitzav()
        {


            _PriseCalc();
            if (_PC.PR1 <= 0)
            {
                return "Empty";
            }
            else
            {


                return Math.Round(_PC.PR1,1).ToString();
            }
        }   
        
        string PRT4()
        {


            _PriseCalc();
            if (_PC.PRT4 <= 0)
            {
                return "Empty";
            }
            else
            {
                if (!IN.InDoubleDoor)
                {
                    return Math.Round(_PC.PRT4,1).ToString();
                }
                else
                {
                    return "Empty";
                }

         
            }
        }
        string _PriseTestHead() // New calc by Yoav. Calculating The prisa for head.
        {
            _PriseCalc();
            if (_PC.PR2 <= 0)
            {
                return "Empty";
            }
            //else if (_PC.FrameName == "BlindStandartBT" || 
            //    _PC.FrameName == "BlindStandartGV" ||
            //    _PC.FrameName == "SlidingBT" ||
            //    _PC.FrameName == "SlidingGV" ||
            //    _PC.FrameName == "PivotStandartBT" ||
            //    _PC.FrameName == "PivotStandartGV" ||
            //    _PC.FrameName == "PendelStandartBT" ||
            //    _PC.FrameName == "PendelStandartGV" || 
            //    _PC.FrameName == "RegularClick" ||
            //    _PC.FrameName == "AlphaClick")
            //{
            //    return Math.Ceiling(_PC.PR1).ToString();

            //}
            else
            {


                return Math.Round(_PC.PR2,1).ToString();
            }
        }



        string _MetalNitzav()
        {
            if (this.IN.InFrameMetal == "Megolvan")
            {
                
                return "מגולבן";
                
            }
            else if (this.IN.InFrameMetal == "Norsta")
            {
                return "נירוסטה";

            }
            else
            {
                return "Empty";
            }
        }

        void _FillPresaDetails()
        {
            _PriseCalc();
         

            this.OUT.outPresa_A1 = _FD.A1 <= 0 ? "Empty" : _FD.A1.ToString();
            this.OUT.outPresa_A2 = _FD.A2 <= 0 ? "Empty" : _FD.A2.ToString();
            this.OUT.outPresa_B1 = _FD.B1 <= 0 ? "Empty" : _FD.B1.ToString();
            this.OUT.outPresa_B2 = _FD.B2 <= 0 ? "Empty" : _FD.B2.ToString();
          
            this.OUT.outPresa_C2 = _FD.C2 <= 0 ? "Empty" : _FD.C2.ToString();

           // this.OUT.outPresa_E1 = _FD.E1 <= 0 ? "Empty" : _FD.E1.ToString();
            if (_PC.FrameName == "RegularHalbasha" || _PC.FrameName == "AlphaHalbasha")
            {
                this.OUT.outPresa_E1 = _FD.E1 <= 0 ? "Empty" : _FD.E1.ToString();

            }
            else
            {
                this.OUT.outPresa_E1 = "Empty";
            }

            if (_PC.FrameName == "PendelStandartBT" || _PC.FrameName == "PendelStandartGV")
            {
                this.OUT.outPresa_F1 = "";
                this.OUT.outPresa_G1 = _FD.C1 <= 0 ? "Empty" : _FD.C1.ToString();

            }
            else
            {
                this.OUT.outPresa_F1 = _FD.F1 <= 0 ? "Empty" : _FD.F1.ToString();
                this.OUT.outPresa_C1 = _FD.C1 <= 0 ? "Empty" : _FD.C1.ToString();
                this.OUT.outPresa_G1 = _FD.G1 <= 0 ? "Empty" : _FD.G1.ToString();
            }

       
            this.OUT.outPresa_D2 = _FD.D2 <= 0 ? "Empty" : _FD.D2.ToString();
       
            this.OUT.outPresa_E2 = _FD.E2 <= 0 ? "Empty" : _FD.E2.ToString();
          
            this.OUT.outPresa_F2 = _FD.F2 <= 0 ? "Empty" : _FD.F2.ToString();
        
            this.OUT.outPresa_G2 = _FD.G2 <= 0 ? "Empty" : _FD.G2.ToString();

        }  
        
        
        void _FillPresaDetails2()
        {
            _PriseCalc();
            if (IN.InFrameTypeTest1 == "Alpha" || IN.InFrameTypeTest1 == "Pendel")
            {

                this.OUT.outPresa_AA1 = _FD.A1 <= 0 ? "Empty" : _FD.A1.ToString();//_FD.A1B <= 0 ? "Empty" : _FD.A1B.ToString();
                this.OUT.outPresa_AA2 = _FD.A2 <= 0 ? "Empty" : _FD.A2.ToString();//_FD.A2B <= 0 ? "Empty" : _FD.A2B.ToString();
                this.OUT.outPresa_BB1 = _FD.B1 <= 0 ? "Empty" : _FD.B1.ToString();//_FD.B1B <= 0 ? "Empty" : _FD.B1B.ToString();
                this.OUT.outPresa_BB2 = _FD.B2 <= 0 ? "Empty" : _FD.B2.ToString();//_FD.B2B <= 0 ? "Empty" : _FD.B2B.ToString();

                if ((_PC.FrameName == "PendelStandartBT" || _PC.FrameName == "PendelStandartGV") && IN.InDoubleDoor)
                {
                    this.OUT.outPresa_FF1 = "";
                    this.OUT.outPresa_GG1 = _FD.C1 <= 0 ? "Empty" : _FD.C1.ToString();

                }
                else if((_PC.FrameName == "PendelStandartBT" || _PC.FrameName == "PendelStandartGV") && !IN.InDoubleDoor)
                {
                    
                        this.OUT.outPresa_CC1 = "";
                    this.OUT.outPresa_GG1 = "";
                             this.OUT.outPresa_FF1 = "";

                }
                else
                {

                    this.OUT.outPresa_CC1 = _FD.C1 <= 0 ? "Empty" : _FD.C1.ToString();//_FD.C1B <= 0 ? "Empty" : _FD.C1B.ToString();
                    this.OUT.outPresa_GG1 = _FD.G1 <= 0 ? "Empty" : _FD.G1.ToString();//_FD.G1B <= 0 ? "Empty" : _FD.G1B.ToString();
                    this.OUT.outPresa_FF1 = _FD.F1B <= 0 ? "Empty" : _FD.F1B.ToString();//_FD.F1B <= 0 ? "Empty" : _FD.F1B.ToString();

                }
                this.OUT.outPresa_CC2 = _FD.C2 <= 0 ? "Empty" : _FD.C2.ToString();//_FD.C2B <= 0 ? "Empty" : _FD.C2B.ToString();
                this.OUT.outPresa_DD1 = _FD.D1 <= 0 ? "Empty" : _FD.D1.ToString();//_FD.D1B <= 0 ? "Empty" : _FD.D1B.ToString();
                this.OUT.outPresa_DD2 = _FD.D2 <= 0 ? "Empty" : _FD.D2.ToString();//_FD.D2B <= 0 ? "Empty" : _FD.D2B.ToString();
                this.OUT.outPresa_EE1 = _FD.E1 <= 0 ? "Empty" : _FD.E1.ToString();//_FD.E1B <= 0 ? "Empty" : _FD.E1B.ToString();
                this.OUT.outPresa_EE2 = _FD.E2 <= 0 ? "Empty" : _FD.E2.ToString();//_FD.E2B <= 0 ? "Empty" : _FD.E2B.ToString();
                this.OUT.outPresa_FF2 = _FD.F2 <= 0 ? "Empty" : _FD.F2.ToString();//_FD.F2B <= 0 ? "Empty" : _FD.F2B.ToString();
                this.OUT.outPresa_GG2 = _FD.G2 <= 0 ? "Empty" : _FD.G2.ToString();//_FD.G2B <= 0 ? "Empty" : _FD.G2B.ToString();

                this.OUT.OutWallThickness2 = _FrameCalcThicknesB <= 0 ? "Empty" : _FrameCalcThicknesB.ToString();
                this.OUT.OutFrameThickness2 = _FrameCalcThicknesA <= 0 ? "Empty" : _FrameCalcThicknesA.ToString();
            }
            else
            {

                this.OUT.outPresa_AA1 = "Empty";
                this.OUT.outPresa_AA2 = "Empty";
                this.OUT.outPresa_BB1 = "Empty";
                this.OUT.outPresa_BB2 = "Empty";
                this.OUT.outPresa_CC1 = "Empty";
                this.OUT.outPresa_CC2 = "Empty";
                this.OUT.outPresa_DD1 = "Empty";
                this.OUT.outPresa_DD2 = "Empty";
                this.OUT.outPresa_EE1 = "Empty";
                this.OUT.outPresa_EE2 = "Empty";
                this.OUT.outPresa_FF1 = "Empty";
                this.OUT.outPresa_FF2 = "Empty";
                this.OUT.outPresa_GG1 = "Empty";
                this.OUT.outPresa_GG2 = "Empty";
                this.OUT.OutWallThickness2 = "Empty";
                this.OUT.OutFrameThickness2 = "Empty";

            }
        
        }

        string _ImgAlphaCut1()
        {
            GFXCalc();

            return GFX.img4;
        }
        string _ImgLock1()
        {
            GFXCalc();

            return GFX.img5;
        }

        string _ImgLock2()
        {
            GFXCalc();

            return GFX.img6;
        }

        string _ImgCut2()
        {
            GFXCalc();

            return GFX.img9;
        }

        string _FrameHightTop()
        {

            return "Empty";
        }

        string _imgGevesLine1()
        {
            GFXCalc();

            return GFX.img10;
        }

        string _imgHingeA(int x)
        {
            GFXCalc();

            switch (x)
            {
                case 1:
                    return GFX.imgHA1;
                case 2:
                    return GFX.imgHA2;
                case 3:
                    return GFX.imgHA3;

                case 4:
                    return GFX.imgHA4;
                case 5:
                    return GFX.imgHA5;
                case 6:
                    return GFX.imgHA6;
                case 7:
                    return GFX.imgHA7;


                default:
                    return "Empty";
            }
        }


        string _imgCut22()
        {
            GFXCalc();
            if (this.IN.InFrameTypeTest1 == "Alpha"  || this.IN.InFrameTypeTest1 == "Pendel")
            {
                return GFX.img9;
            }
            else
            {

                return GFX.img8;

            }
        }

        string _imgCut11()
        {
            GFXCalc();

            return GFX.img8;


        }
        //string _FramePlatzHight()
        //{
        //    _PriseCalc();
        //    if (this.IN.InFrameHight <= 0 || (this.IN.InFrameHight - _FD.A1) <= 0)
        //    {
        //        return "Empty";
        //    }
        //    else
        //    {
        //        return (this.IN.InFrameHight + this.IN.InFrameHightUnderFloor - _FD.A1 ).ToString();
        //    }
        //}    
        
        
        string _FramePlatzHight()
        {
            _PriseCalc();
            if (this.IN.InFrameHight <= 0 || (this.IN.InFrameHight - _FD.A1) <= 0)
            {
                return "Empty";
            }
            else if (_FD.E1 >0 && IN.InFrameTypeTest2 != "Halbasha")
            {
                return (Math.Round(_FrameHightint() - _FD.A1 - (_FD.E1 - _PC.MeterialThickness))).ToString();
            }
            else
            {
                
                return (Math.Round(_FrameHightint() - _FD.A1)).ToString();
            }
        }

        string _FrameSize()
        {

            _PriseCalc();
            if (_frame.FrameType == "SlidingPocketGV" || _frame.FrameType == "SlidingPocketBT")
            {
                return "Empty";
            } 

            if (this.IN.InFrameHight <= 0 || this.IN.InFrameWidth <= 0)
            {
                return "Empty";
            }
            else
            {
                return _FrameWidth() + " X " + _FrameHight();
            }
        }
        string _PlatzFrameSize()
        {

            //wig X hig
            if (_frame.FrameType == "SlidingPocketGV" || _frame.FrameType == "SlidingPocketBT")
            {
                return "Empty";
            }

                if (_FramePlatzWidth() == "Empty" || _FramePlatzHight() =="Empty")
            {
                return "Empty";
            }
            else
            {
                return _FramePlatzWidth() + " X " + _FramePlatzHight();
            }

        }

        void executezaza()
        {
            if (_frame.FrameType == "SlidingPocketGV" || _frame.FrameType == "SlidingPocketBT")
            {

                this.OUT.PocketWidth = _CFMC.PocketWidth().ToString();
                this.OUT.SlidingTotalWidth = _CFMC.SlidingTotalWidth().ToString();
                this.OUT.LightWidth = _CFMC.LightWidth().ToString();
                this.OUT.SlidingTotalHight = (_CFMC.SlidingTotalHight() + this.IN.InFrameHightUnderFloor).ToString();
                this.OUT.LightHight = (_CFMC.LightHight() + this.IN.InFrameHightUnderFloor).ToString();
         
            }
            else if(_frame.FrameType == "SlidingBT" || _frame.FrameType == "SlidingGV")
            {
                this.OUT.PocketWidth = "Empty";
                this.OUT.SlidingTotalWidth = "Empty";
                this.OUT.LightWidth = "Empty";
                this.OUT.SlidingTotalHight = _FrameHight();
                this.OUT.LightHight = _FramePlatzHight();

            }
            else
            {
                this.OUT.PocketWidth = "Empty";
                this.OUT.SlidingTotalWidth = "Empty";
                this.OUT.LightWidth = "Empty";
                this.OUT.SlidingTotalHight = "Empty";
                this.OUT.LightHight = "Empty";
            }

        }   

        public void ExecutePrisa(int id)
        {
            _FD = new FrameDefault(id);
        }

        void KetumCal()
        {

            clsFrameUpperPart part = clsFrameUpperPart.FindByFrameID(frameID);

            if (part != null && _frame != null)
            {
                if (part.Kitum)
                {
                    this.OUT.ketum = "כיתום";
                }
                else
                {
                    this.OUT.ketum = "ניצב";
                }

                if (part.Nerousta)
                {
                    this.OUT.PRF3 = "נירוסטה";
                }
                else
                {
                    this.OUT.PRF3 = _MetalNitzav();

                }


                this.OUT.PRM3 = _frame.IronThickness.ToString();

                this.OUT.PRA3 = (_frame.tbAmount * 2).ToString();
                //if ((this.IN.InFrameTypeName == "PendelStandartBT" || this.IN.InFrameTypeName == "PendelStandartGV") && _frame.DoubleDoor)
                //{
                //    this.OUT.PRA3 = (_frame.tbAmount * 2).ToString();

                //}
                //else if (this.IN.InFrameTypeName == "PendelStandartBT" || this.IN.InFrameTypeName == "PendelStandartGV")
                //{
                //    this.OUT.PRA3 = _frame.tbAmount.ToString();
                //}
                //else
                //{

                //    this.OUT.PRA3 = (_frame.tbAmount * 2).ToString();
                //}



                if (part.Kitum)
                {
                    FrameDefault _FDBlid = new FrameDefault(frameID);
                    PrisaCalc _blind = new PrisaCalc();
                    _blind.PRT4 = 0;
                    _blind.isdd = this.IN.InDoubleDoor;
                    _blind.FrameName = "BlindStandartBT";
                    _blind.MeterialThickness = this.IN.InFrameMetalWidth;
                    _blind.FrameTestThickness = _FrameCalcThicknesA;
                    _blind.FramePrisa(ref _FDBlid);

                    if (_blind.PR1 <= 0)
                    {
                        this.OUT.PRT3 = "Empty";
                    }
                    else
                    {


                        this.OUT.PRT3 = Math.Round(_blind.PR1,1).ToString();
                    }

                }
                else
                {
                    this.OUT.PRT3 = _PriseTestNitzav();
                }

            }
       
          
        }

        public void EXECUTE()
        {
            _frame = clsFrames.Find(frameID);
            if (_frame != null)
            {
                this.IN.InFrameWidth = _frame.Width;
                this.IN.InFrameHight = _frame.Height;
            }
            this.OUT.OutDirection = _Direction();
            this.OUT.OutimgMain1 = _ImgMain1();
            this.OUT.OutimgProfile1 = _ImgProfile1();
            this.OUT.OutimgProfile2 = _ImgProfile2();
            this.OUT.OutimgCut1 = _ImgCut1();
            this.OUT.OutimgCut2 = _ImgCut2();
            this.OUT.OutFrameWidth = _FrameWidth();
            this.OUT.OutFramePlatzWidth = _FramePlatzWidth();
            this.OUT.OutFrameHight = _FrameHight();
            this.OUT.OutPriseTest_Nitzav = _PriseTestNitzav();
            this.OUT.PRT4 = PRT4();
            this.OUT.OutPriseTest_Head = _PriseTestHead();

            this.OUT.OutFrameMetalWidth_Nitzav = this.IN.InFrameMetalWidth <= 0 ?"Empty" : this.IN.InFrameMetalWidth.ToString();
            this.OUT.OutFrameMetal_Nitzav = _MetalNitzav();


            this.OUT.OutWallThickness = _FrameCalcThicknesB <= 0 ? "Empty" : _FrameCalcThicknesB.ToString();
            this.OUT.OutFrameThickness = _FrameCalcThicknesA <= 0 ? "Empty" : _FrameCalcThicknesA.ToString();
            this.OUT.OutFrameTypeNameText4 = FrameNameCalc.FrameNameSys(this.IN.InFrameTypeName);
            this.OUT.OutimgAlphaBox1 = _ImgAlphaBox1();
            this.OUT.OutimgAlphaCut1 = _ImgAlphaCut1();
            this.OUT.OutimgLock1 = _ImgLock1();
            this.OUT.OutimgLock2 = _ImgLock2();
            this.OUT.OutimgGevesLine1 = _imgGevesLine1();
            this.OUT.OutimgHingeA1 = _imgHingeA(1);
            this.OUT.OutimgHingeA2 = _imgHingeA(2);
            this.OUT.OutimgHingeA3 = _imgHingeA(3);
            this.OUT.OutimgHingeA4 = _imgHingeA(4);
            this.OUT.OutimgHingeA5 = _imgHingeA(5);
            this.OUT.OutimgHingeA6 = _imgHingeA(6);
            this.OUT.OutimgHingeA7 = _imgHingeA(7);
            this.OUT.OutimgCut22 = _imgCut22();
            this.OUT.OutimgCut11 = _imgCut11();
            this.OUT.FlakhGvs = this.IN.InGevesFlach?"true":"Empty";
            this.OUT.PlatzFrameSize = _PlatzFrameSize() ;
            this.OUT.OutFrameHightTop = _FrameHightTop();
            this.OUT.FrameSize = _FrameSize();
            this.OUT.FramePlatzHight = _FramePlatzHight();
            this.OUT.FrameSlideinMainimg = _ImgMainSliding();
            this.OUT.imgFramePocketTopProfile = imgFramePocketTopProfile();

            //     this.OUT.outIsDoubelDoor = null
            executezaza();
            calcHingeOut();
            lockCalcOut();
            _FillPresaDetails();
            _PrisaBoxSizeCalc();
            UpperPart();
            _FillPresaDetails2();

            KetumCal();
        }





    }
}
