using SharaLogic.Calculations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.WingCalc
{
    public class clsMainWingCalc
    {

        public clsOUTWing OUT;

        clsWingGFXcalc GFX;
        clsWingType _WingType;
        clsWings _wing;
        clsWingWindows _windows;
        WingItemsDefult _WingDefult;

        clsWingHinge _Hinge;
        clsWingAdvanced _Advanced;
        clsWingLock _lock;
        clsProjects _project;
        clsOrders _oreder;
        clsCustomers _coustomers;
        clsWingAddon _addonwing;
        int _WingID = -1;
        int FinalHightPol = -1;

        public clsMainWingCalc(int WingID)
        {
            _WingID = WingID;
            OUT = new clsOUTWing();
            GFX = new clsWingGFXcalc(WingID);
            _WingType = clsWingType.FindByWingID(WingID);
            _wing = clsWings.Find(WingID);
            _windows = clsWingWindows.FindByWingID(WingID);
            _Hinge = clsWingHinge.FindByWingID(WingID);
            _WingDefult = new WingItemsDefult(WingID);


            _Advanced = clsWingAdvanced.FindByWingID(WingID);
            _lock = clsWingLock.FindByWingID(WingID);
            if (_wing != null)
            {
                _oreder = clsOrders.Find(_wing.OdrerId);
                _addonwing = clsWingAddon.FindByWingID(WingID);
            }

            if (_oreder != null)
            {
                _project = clsProjects.Find(_oreder.ProjectID);
            }
            if (_project != null)
            {
                _coustomers = clsCustomers.Find(_project.iDcustomer);

            }



        }


        string GFXDOORwood()
        {

            return GFX.DoorWood();

        }

        string AlphaProfile()
        {
            FinalHightPol = _WingDefult.FinalHight;

            if (_wing.Side)
            {
                return "Empty";
            }
            else
            {
                return GFX.AlphaProfile(ref FinalHightPol);
            }

        }

        string Scatch3Text()
        {
            return GFX.Scatch3Text();
        }

        string GFXwindows()
        {

            return GFX.Windows();

        }

        string GFXwindowline()
        {
            return GFX.WindowMessurements();
        }
        string GFXtrisLine()
        {
            return GFX.trisMessurements();
        }
        string GFXTris()
        {

            return GFX.Tris();

        }
        string GFXKantType()
        {

            return GFX.KantType();

        }


        string _FullNameWinge()
        {
            if (_WingType != null)
            {

                return clsCalcNameType.getName(_WingType.TEST1, _WingType.TEST2, _WingType.TEST3, _WingType.TEST4);
            }
            else
            {
                return "";
            }
        }







        string TrisComment()
        {
            string trisComm = "";
            switch (_windows.TrisType)
            {
                case "NoTris":
                    trisComm = "Hidd";
                    return trisComm;

                case "Wood":
                    trisComm += " עץ "; // trans hebron
                    break;
                case "Alminuom":
                    trisComm += " אלומיניום ";// trans hebron
                    break;
                case "Slots":
                    trisComm += " חריצי אוורור ";// trans hebron
                    break;
            }

            switch (_windows.OpeningDirection)
            {
                case "Out":
                    trisComm += " חוץ ";// trans hebron
                    break;
                case "In":
                    trisComm += " פנים ";// trans hebron
                    break;
            }

            switch (_wing.Direction)
            {
                case "Right":
                    trisComm += " ימין ";// trans hebron
                    break;
                case "Left":
                    trisComm += " שמאל ";// trans hebron
                    break;
            }

            return trisComm;
        }

        string WindowTypecheck()
        {

            return _windows.WindowType;

        }

        string _WindoComment()
        {
            string winComm = "";

            switch (_windows.WindowType)
            {
                case "NoWin":
                    winComm += "Hidd";
                    return winComm;
                case "Tsohar":
                    winComm += " צוהר ";
                    break;
                case "Normal":
                    winComm += " רגיל ";
                    break;
                case "Aor":
                    winComm += " Aor";
                    break;
                case "Mtstson":
                    winComm += " מציצן ";
                    break;
                case "Balon":
                    winComm += " בלון ";
                    break;
                case "Star":
                    winComm += " כוכב ";
                    break;
                case "Old":
                    winComm += " עינית הצצה ";
                    break;

            }

            if (_windows.WindowHeight > _windows.WindowWidth)
            {
                winComm += "\n";
            }
            if (_windows.WindowType != "Old")
            {
                switch (_windows.GlassType)
                {
                    case "Milky":
                        winComm += " חלבי ";
                        break;
                    case "Clear":
                        winComm += " שקוף ";
                        break;

                }
            }


            return winComm;
        }
        string IsHiddenEqualsSignForTheMiddle(string type)
        {
            if (type == "Windo")
            {
                return _windows.WindoInCenter ? "No" : "Ishidden";
            }
            else if (type == "Tris")
            {
                return _windows.TrisInCenter ? "No" : "Ishidden";
            }
            else
            {
                return "No";
            }
        }

        void NormalDoor()
        {
            _WingDefult = new WingItemsDefult(_WingID);
            if (_WingDefult != null)
            {
                OUT.Double2 = _WingDefult.FinalHight.ToString();


                OUT.outDoorFinalWidth = _WingDefult.FinalWidth;
                OUT.outDoorFinalHight = _WingDefult.FinalHight;

                FinalHightPol = _WingDefult.FinalHight;

                OUT.outDoorWoodHight = _WingDefult.WoodHight;
                OUT.outDoorWoodWidth = _WingDefult.WoodWidth;


                OUT.outPletzHight = _WingDefult.PletzHight;
                OUT.outPletzWidth = _WingDefult.PletzWidth;

                OUT.outMetalHight = _WingDefult.MetalHight;
                OUT.outMetalWidth = _WingDefult.MetalWidth;

                OUT.outwoodPletzWidth =  _WingDefult.woodPletzWidth;

                //if (_WingType.TEST3 == "3" || _WingType.TEST3 == "4")
                //{
                //    OUT.outWoodBuk1 = _WingDefult.BukA.ToString();
                //    OUT.outWoodbuk2 = "-1";
                //    OUT.outWoodBukA = "15";
                //}

                //else
                //{
                //    OUT.outWoodBuk1 = _WingDefult.BukA.ToString();
                //    OUT.outWoodbuk2 = _WingDefult.BukB.ToString();
                //    OUT.outWoodBukA = "-1";
                //}
                if (_WingType != null && _WingType.TEST1 == "PVT" &&( _WingType.TEST3 == "0"|| _WingType.TEST3 == "Medic"))
                {
                    ClearBuk();
                    OUT.O_BUK1 = _WingDefult.BukA.ToString();

                    OUT.O_BUK3 = _WingDefult.BukB.ToString();

                }
                else if (_WingType != null && _WingType.TEST1 == "PVT" && (_WingType.TEST3 == "3" || _WingType.TEST3 == "4"))
                {
                    ClearBuk();
                    OUT.O_BUK1 = _WingDefult.BukA.ToString();
                    OUT.O_BUK5 = _WingDefult.BukC.ToString();
                    OUT.O_BUK2 = _WingDefult.BukB.ToString();
                }
                else
                {



                    if (_WingType != null && _WingType.TEST2 == "A")
                    {
                        ClearBuk();
                        OUT.O_BUK10 = _WingDefult.BukA.ToString();
                        OUT.O_BUK5 = _WingDefult.BukB.ToString();

                    }
                    else
                    {


                        if (_WingType != null && _WingType.TEST3 == "0")
                        {
                            ClearBuk();
                            OUT.O_BUK1 = _WingDefult.BukA.ToString();
                            OUT.O_BUK3 = _WingDefult.BukB.ToString();


                        }
                        else if (_WingType != null && (_WingType.TEST3 == "3" || _WingType.TEST3 == "4"))
                        {
                            ClearBuk();
                            OUT.O_BUK1 = _WingDefult.BukA.ToString();
                            OUT.O_BUK5 = _WingDefult.BukC.ToString();
                            OUT.O_BUK2 = _WingDefult.BukB.ToString();

                        }
                        else if (_WingType != null && _WingType.TEST3 == "Medic")
                        {
                            ClearBuk();

                            OUT.O_BUK1 = _WingDefult.BukA.ToString();
                            OUT.O_BUK3 = _WingDefult.BukB.ToString();

                            OUT.O_BUK13 = _WingDefult.BukC.ToString();

                        }

                        if (_wing != null && _wing.DoubleDoor && _wing.DDAK == "A" && _WingType != null && _WingType.TEST3 == "0")
                        {
                            ClearBuk();
                            OUT.O_BUK1 = _WingDefult.BukA.ToString();
                            OUT.O_BUK3 = _WingDefult.BukB.ToString();
                            OUT.O_BUK7 = _WingDefult.BukC.ToString();
                            OUT.O_BUK9 = _WingDefult.BukD.ToString();

                        }
                        else if (_wing != null && _wing.DoubleDoor && _wing.DDAK == "K" && _WingType != null && _WingType.TEST3 == "0")
                        {
                            ClearBuk();
                            OUT.O_BUK1 = _WingDefult.BukA.ToString();
                            OUT.O_BUK3 = _WingDefult.BukB.ToString();
                            OUT.O_BUK7 = _WingDefult.BukC.ToString();
                            OUT.O_BUK9 = _WingDefult.BukD.ToString();
                            OUT.outwoodLockBasic = "False";
                        }
                        else if (_wing != null && _wing.DoubleDoor && _wing.DDAK == "A" && _WingType != null && (_WingType.TEST3 == "3" || _WingType.TEST3 == "4"))
                        {
                            ClearBuk();
                            OUT.O_BUK1 = _WingDefult.BukA.ToString();
                            OUT.O_BUK2 = _WingDefult.BukB.ToString();
                            OUT.O_BUK4 = _WingDefult.BukC.ToString();

                            OUT.O_BUK6 = _WingDefult.BukD.ToString();

                            OUT.O_BUK11 = _WingDefult.BukE.ToString();
                            OUT.O_BUK12 = _WingDefult.BukF.ToString();
                            OUT.O_DDWidthFormica2 = (_WingDefult.MetalWidth2 + " X " + _WingDefult.MetalHight).ToString();

                        }
                        else if (_wing != null && _wing.DoubleDoor && _wing.DDAK == "K" && _WingType != null && (_WingType.TEST3 == "3" || _WingType.TEST3 == "4"))
                        {
                            ClearBuk();
                            OUT.O_BUK1 = _WingDefult.BukA.ToString();
                            OUT.O_BUK2 = _WingDefult.BukB.ToString();
                            OUT.O_BUK4 = _WingDefult.BukC.ToString();

                            OUT.O_BUK6 = _WingDefult.BukD.ToString();

                            OUT.O_BUK7 = _WingDefult.BukE.ToString();
                            OUT.O_BUK11 = _WingDefult.BukF.ToString();

                            OUT.outwoodLockBasic = "False";

                        }




                    }
                }
                
    
            }
        }

        void ClearBuk()
        {
            OUT.O_BUK1 = "";
            OUT.O_BUK2 = "";
            OUT.O_BUK3 = "";
            OUT.O_BUK4 = "";
            OUT.O_BUK5 = "";
            OUT.O_BUK6 = "";
            OUT.O_BUK7 = "";
            OUT.O_BUK8 = "";
            OUT.O_BUK9 = "";
            OUT.O_BUK10 = "";
            OUT.O_BUK11 = "";
            OUT.O_BUK12 = "";
            OUT.O_BUK13 = "";
            OUT.O_BUK14 = "";
            OUT.O_BUK15 = "";
        }

        void DoubleDoor()
        {


            NormalDoor();



        }




        void executeCalc()
        {
            if (_wing != null && _wing.DoubleDoor)
            {
                DoubleDoor();


            }
            else
            {
                NormalDoor();
            }

        }

        string CircleLocationv(int CircleLocation)
        {
            if (_windows.WindowType == "NoWin" || _windows.WindowType == "Normal")
            {
                return "Hidd";
            }
            else
            {
                return CircleLocation.ToString();
            }

        }
        void _show2Hinge()
        {
            OUT.outHingH1 = _Hinge.H1.ToString();
            OUT.outHingH7 = _Hinge.H2.ToString();
        }
        void _show3Hinge()
        {
            if (_Hinge.UpperMid)
            {
                OUT.outHingH1 = _Hinge.H1.ToString();
                OUT.outHingH2 = _Hinge.H2.ToString();
                OUT.outHingH7 = _Hinge.H3.ToString();
            }
            else
            {
                OUT.outHingH1 = _Hinge.H1.ToString();
                OUT.outHingH4 = _Hinge.H2.ToString();
                OUT.outHingH7 = _Hinge.H3.ToString();
            }
        }

        void _show4Hinge()
        {
            OUT.outHingH1 = _Hinge.H1.ToString();
            OUT.outHingH2 = _Hinge.H2.ToString();
            OUT.outHingH6 = _Hinge.H3.ToString();
            OUT.outHingH7 = _Hinge.H4.ToString();
        }
        void _show5Hinge()
        {
            OUT.outHingH1 = _Hinge.H1.ToString();
            OUT.outHingH2 = _Hinge.H2.ToString();
            OUT.outHingH4 = _Hinge.H3.ToString();
            OUT.outHingH6 = _Hinge.H4.ToString();
            OUT.outHingH7 = _Hinge.H5.ToString();
        }

        void _show6Hinge()
        {
            OUT.outHingH1 = _Hinge.H1.ToString();
            OUT.outHingH2 = _Hinge.H2.ToString();
            OUT.outHingH3 = _Hinge.H3.ToString();
            OUT.outHingH5 = _Hinge.H4.ToString();
            OUT.outHingH6 = _Hinge.H5.ToString();
            OUT.outHingH7 = _Hinge.H6.ToString();
        }
        void _NOHinge()
        {
            OUT.outHingH1 = "-1";
            OUT.outHingH2 = "-1";
            OUT.outHingH3 = "-1";
            OUT.outHingH4 = "-1";
            OUT.outHingH5 = "-1";
            OUT.outHingH6 = "-1";
            OUT.outHingH7 = "-1";
            OUT.outHingAmount = "-1";
        }

        void ExecuteHinges()
        {


            if (_Hinge != null)
            {
                if (_WingType != null && (_WingType.TEST1 == "ALPH" || _WingType.TEST1 == "Flash" || _WingType.TEST1 == "PVT"))
                {
                    OUT.outHingAmount = "-1";
                    return;
                }

                if (_Hinge.Amount > 0)
                {


                    OUT.outHingAmount = _Hinge.Amount.ToString();



                    OUT.outHingType = _Hinge.HingeType;
                    OUT.outHingUpperMidHin = _Hinge.UpperMid.ToString();
                    OUT.outHingHingeSize = _Hinge.Size.ToString();
                    OUT.outHingHeightToBottomHinge = _Hinge.HeightToBottomHinge.ToString();

                    switch (_Hinge.Amount)
                    {

                        case 2:

                            _show2Hinge();
                            break;
                        case 3:

                            _show3Hinge();
                            break;
                        case 4:

                            _show4Hinge();
                            break;
                        case 5:

                            _show5Hinge();
                            break;
                        case 6:

                            _show6Hinge();
                            break;

                        default:
                            _show3Hinge();

                            break;
                    }

                }
                else
                {
                    _NOHinge();
                }

            }
            else
            {
                _NOHinge();

            }
        }


        void pecesWood()
        {
            if (_Advanced != null)
            {

                OUT.outwoodSpeacilCasesHingeUPLocation = _Advanced.woodSpeacilCasesHingeUPLocation.ToString();
                OUT.outwoodSpeacilCasesHingeUPHeight = _Advanced.woodSpeacilCasesHingeUPHeight.ToString();
                OUT.outwoodSpeacilCasesHingeUPWidth = _Advanced.woodSpeacilCasesHingeUPWidth.ToString();
                OUT.outwoodSpeacilCasesHingeUP = _Advanced.woodSpeacilCasesHingeUP.ToString();

                OUT.outwoodSpeacilCasesHingeDNHeight = _Advanced.woodSpeacilCasesHingeDNHeight.ToString();
                OUT.outwoodSpeacilCasesHingeDNWidth = _Advanced.woodSpeacilCasesHingeDNWidth.ToString();
                OUT.outwoodSpeacilCasesHingeDNLocation = _Advanced.woodSpeacilCasesHingeDNLocation.ToString();
                OUT.outwoodSpeacilCasesHingeDN = _Advanced.woodSpeacilCasesHingeDN.ToString();

                OUT.outwoodBehalaLockLocation = _Advanced.woodBehalaLockLocation.ToString();
                OUT.outwoodBehalaLockHeight = _Advanced.woodBehalaLockHeight.ToString();
                OUT.outwoodBehalaLockWidth = _Advanced.woodBehalaLockWidth.ToString();
                OUT.outwoodBehalaLock = _Advanced.woodBehalaLock.ToString();

                OUT.outwoodLockBasic = _Advanced.woodLockBasic.ToString();
                OUT.outwoodLockBasicHeight = _Advanced.woodLockBasicHeight.ToString();
                OUT.outwoodLockBasicWidth = _Advanced.woodLockBasicWidth.ToString();
                OUT.outwoodLockBasicLocation = _Advanced.woodLockBasicLocation.ToString();

                OUT.outwoodUpeerLock = _Advanced.woodUpeerLock.ToString();


                OUT.outWingDeptSize = _Advanced.ThicknessWing.ToString();




            }


        }

        void Locks(bool statu)
        {
            if (_lock != null)
            {
                if (_Advanced != null)
                {


                    if (_lock.LockType == "bhla")
                    {


                        if (_Advanced.woodBehalaLockManual)
                        {

                            if (statu)
                            {
                                _Advanced.woodBehalaLock = true;
                            }
                            else
                            {
                                _Advanced.woodBehalaLock = false;
                            }



                        }
                        else
                        {
                            _Advanced.woodBehalaLock = true;
                        }


                    }
                    else
                    {

                        if (_Advanced.woodBehalaLockManual)
                        {
                            if (statu)
                            {
                                _Advanced.woodBehalaLock = false;
                            }
                            else
                            {
                                _Advanced.woodBehalaLock = true;
                            }
                        }
                        else
                        {
                            _Advanced.woodBehalaLock = false;
                        }



                    }

                    if (_lock.UpperLock)
                    {
                        _Advanced.woodUpeerLock = true;
                        OUT.outUpeerLockActive = "True";
                    }
                    else
                    {
                        _Advanced.woodUpeerLock = false;
                        OUT.outUpeerLockActive = "False";
                    }



                    if (_lock.LockType == "NoLock")
                    {
                        _Advanced.woodLockBasic = false;

                        OUT.outLockActive = "False";

                    }
                    else
                    {
                        _Advanced.woodLockBasic = true;

                        OUT.outLockActive = "True";

                    }

                    _Advanced.Save();
                }

                if (_lock.LockMeasure > 0 && _lock.LockMeasureFrame <= 0)
                {
                    OUT.outLockMeasure = _lock.LockMeasure.ToString();

                }
                else if (_lock.LockMeasure <= 0 && _lock.LockMeasureFrame > 0)
                {
                    OUT.outLockMeasure = (_lock.LockMeasureFrame + 42).ToString();
                }
                else
                {
                    OUT.outLockMeasure = "";
                }

                if (_lock.UpperLockMeasure > 0 && _lock.UpperLockMeasureFrame <= 0)
                {
                    OUT.outUpperLockMeasure = _lock.UpperLockMeasure.ToString();
                }
                else if (_lock.UpperLockMeasure <= 0 && _lock.UpperLockMeasureFrame > 0)
                {
                    OUT.outUpperLockMeasure = (_lock.UpperLockMeasureFrame + 50).ToString();
                }
                else
                {
                    OUT.outUpperLockMeasure = "";
                }

                OUT.outLockType = _lock.LockType;


                if (_wing.DoubleDoor && _lock.UpperLock)
                {
                    OUT.Double1 = (_lock.LockMeasure - 500).ToString();

                }
                else
              if (_wing.DoubleDoor && _lock.LockType == "Electricity")
                {
                    OUT.Double1 = (_lock.LockMeasure - 42).ToString();
                }
                else
                {
                    OUT.Double1 = (_lock.LockMeasure - 35).ToString();
                }

            }


        }


        void StikrsData()
        {
            if (_project != null)
            {

                OUT.outProjectName = _project.projectName;

            }

            if (_coustomers != null)
            {
                OUT.outcustomer = _coustomers.CompanyName;
            }

            if (_oreder != null)
            {
                OUT.outOrderNo = _oreder.OrderNumber.ToString();
            }

            if (_wing != null)
            {
                OUT.outID = _wing.DoorNumber.ToString();
            }

        }


        void MakhzerShemnStander()
        {


            if (_wing != null && _WingType != null)
            {
                if (_wing.MakhzerShemen && (_WingType.TEST3 == "3" || _WingType.TEST3 == "4" || _WingType.TEST2 == "A"))
                {
                    OUT.outmakhzerShemenGaloi = "TRUE";
                    OUT.outmakhzerShemen = "-1";
                }
                else if (_wing.MakhzerShemen && _WingType.TEST3 == "0")
                {
                    OUT.outmakhzerShemen = "TRUE";
                    OUT.outmakhzerShemenGaloi = "-1";
                }
                else
                {
                    OUT.outmakhzerShemen = "-1";
                    OUT.outmakhzerShemenGaloi = "-1";
                }






            }
            else
            {
                OUT.outmakhzerShemen = "-1";
                OUT.outmakhzerShemenGaloi = "-1";
            }


        }


        string LockTypeName()
        {

            if(_wing != null && _wing.DDAK == "K")
            {
                return "";
            }


            if (_lock != null)
            {
                switch (_lock.LockType)
                {
                    case "NoLock":
                        return "";
                    case "shar60":
                        return "שהרבני 60";
                    case "shar45":
                        return "שהרבני 45";
                    case "Finek":
                        return "פאניק";
                    case "Shlat":
                        return "שלט";
                    case "rol":
                        return "Roll";
                    case "KFV":
                        return "KFV";
                    case "Rock":
                        return "ROCK";
                    case "bhla":
                        return "בהלה";
                    case "lfe":
                        return "לפי דוגמא";
                    case "zaza":
                        return "הזזה";

                    default:
                        return "-1";
                }
            }
            return "";

        }

        string WoodLowerPlatzHight()
        {


            if (_wing != null && _WingType != null)
            {
                if (_WingType.TEST1 == "ALPH" && _wing.Atmer)
                {
                    return "60";

                }
                else if (_WingType.TEST1 == "ALPH")
                {
                    return "60";
                }
                else if (_wing.Atmer)
                {
                    return "60";
                }
                else if (_WingType.TEST2 == "A" || (_WingType.TEST2 == "F" && _WingType.TEST3 == "4"))
                {
                    return "-1";
                }
                else
                {
                    return "60";
                }




            }

            return "-1";

        }

        void ADDon()
        {

            if (_addonwing != null)
            {
                OUT.outHandicapPosition = _addonwing.PullHandleWidth.ToString();
            }
            if (_wing != null)
            {
                OUT.outSupportHelpless = _wing.SupportHelpless.ToString();
            }
        }

        void stanls()
        {
            if (_addonwing != null)
            {
                if (_addonwing.PullHandleLocationFromabove <= 0)
                {
                    OUT.outStainlessSize2 = "-1";
                    OUT.outStainlessSize1 = _addonwing.PullHandleHeight.ToString();
                    OUT.outStainlessLine = _addonwing.StainlessBand;
                }
                else
                {
                    OUT.outStainlessSize2 = _addonwing.PullHandleHeight.ToString();
                    OUT.outStainlessSize1 = _addonwing.PullHandleLocationFromabove.ToString();
                    OUT.outStainlessLine = _addonwing.StainlessBand;
                }

            }
        }

        void exUpDoorOpen()
        {
            string UpDoorOpen = "";
            string picLittleHandleRU = "";
            string picLittleHandleRD = "";
            string picLittleHandleLU = "";
            string picLittleHandleLD = "";
            string picLittleSupportDN = "";
            string picLittleSupportUP = "";


            if (GFX.UpDoorOpen(ref UpDoorOpen, ref picLittleHandleRU, ref picLittleHandleRD, ref picLittleHandleLU
                , ref picLittleHandleLD, ref picLittleSupportDN, ref picLittleSupportUP
                ))
            {

                OUT.outUpDoorOpen = UpDoorOpen;
                OUT.outpicLittleHandleRU = picLittleHandleRU;
                OUT.outpicLittleHandleRD = picLittleHandleRD;
                OUT.outpicLittleHandleLU = picLittleHandleLU;
                OUT.outpicLittleHandleLD = picLittleHandleLD;
                OUT.outpicLittleSupportDN = picLittleSupportDN;
                OUT.outpicLittleSupportUP = picLittleSupportUP;


            }
            else
            {
                OUT.outUpDoorOpen = clsImageLibrary.Empty;
                OUT.outpicLittleHandleRU = clsImageLibrary.Empty;
                OUT.outpicLittleHandleRD = clsImageLibrary.Empty;
                OUT.outpicLittleHandleLU = clsImageLibrary.Empty;
                OUT.outpicLittleHandleLD = clsImageLibrary.Empty;
                OUT.outpicLittleSupportDN = "-1";
                OUT.outpicLittleSupportUP = "-1";
            }
        }

        string ImagLock()
        {
            return GFX.ImagLock();
        }
       
        string Injection()
        {
            clsInjectionPoly inj;
            if (_wing != null)
            {
                _WingDefult = new WingItemsDefult(_WingID);
                if (_WingType.TEST2 == "A") //Injection per second was 332 changed to 320
                    {
                        inj = new clsInjectionPoly(OUT.outDoorFinalWidth, OUT.outDoorFinalHight,
                         Convert.ToInt16(_WingDefult.BukB), Convert.ToInt16(_WingDefult.BukA)
                                  , 320, 40,
                                  false, false, false, false, false
                                  );
                    }
                    else
                    {
                        inj = new clsInjectionPoly(OUT.outDoorFinalWidth, OUT.outDoorFinalHight,
                      Convert.ToInt16(_WingDefult.BukA), Convert.ToInt16(_WingDefult.BukB)
                               , 320, 40,
                               false, false, false, false, false
                               );

                    }


          


                if (inj != null) {
                    return ((float)Math.Round(inj.OutResultPoly(), 2)).ToString();
                }
                else
                {
                    return "-1";
                }
            }
            else
            {
                return "-1";
            }
        }

        string ColoerSide()
        {
            if (int.TryParse(_wing.ColorSide, out int res))
            {
                clsColorSide color = clsColorSide.Find(res);

                if (color != null)
                {
                    return color.ColorName;
                }
                else
                {
                    return "-1";
                }

            }
            else
            {
                return "-1";
            }


        }

        string GFXimagTrisProfile()
        {
            if (_windows != null)
            {
                if (_windows.TrisType != "NoTris" && _WingType.TEST1 == "ALPH")
                {
                    return GFX.imagTrisProfile();
                }
                else
                {
                    return "Empty";
                }

            }
            else
            {
                return "Empty";
            }

        }

        string PicProfileTrisNormal()
        {
            if (_windows != null)
            {
                if (_windows.TrisType != "NoTris" && _WingType.TEST1 != "ALPH")
                {
                    return GFX.imagTrisProfile();
                }
                else
                {
                    return "Empty";
                }

            }
            else
            {
                return "Empty";
            }
        }

        string _HiddenOijaloi()
        {
            if (_addonwing != null && _WingType != null)
            {
                if ((_WingType.TEST3 == "3" || _WingType.TEST3 == "4" || _WingType.TEST2 == "A") && _addonwing.ReturnHidden)
                {
                    OUT.outmakhzerShemenGaloi = "-1";
                    OUT.outmakhzerShemen = "-1";
                    return "true";
                }
                else
                {
                    return "-1";
                }
            }
            else
            {
                return "-1";
            }

        }
        string _HiddenOiNormal()
        {
            if (_addonwing == null || _WingType == null)
            {
                return "-1";
            }

            if (_WingType.TEST3 == "0" && _addonwing.ReturnHidden)
            {
                OUT.outmakhzerShemenGaloi = "-1";
                OUT.outmakhzerShemen = "-1";
                return "true";
            }
            else
            {
                return "-1";
            }

        }

        string DimeterWindo()
        {
            if (_windows != null)
            {
                if (_windows.WindowType == "Tsohar")
                {
                    return _windows.CircleDiameter.ToString();
                }
                else
                {
                    return "-1";
                }

            }
            else
            {
                return "-1";
            }
        }


        string DirectionDoor()
        {
            if(_wing !=null && _wing.DoubleDoor && _wing.Direction == "Right" && _wing.DDAK == "A" )
            {
                return "Right_A";

            }
            else if (_wing != null && _wing.DoubleDoor && _wing.Direction == "Right" && _wing.DDAK == "K")
            {
                return "Right_K";
            } else if (_wing != null && _wing.DoubleDoor && _wing.Direction == "Left" && _wing.DDAK == "A")
            {
                return "Left_A";
            }else if (_wing != null && _wing.DoubleDoor && _wing.Direction == "Left" && _wing.DDAK == "K")
            {
                return "Left_K";
            }else if (_wing != null  && _wing.Direction == "Right")
            {
                return "Right";
            }else if (_wing != null  && _wing.Direction == "Left")
            {
                return "Left";
            }
            else
            {
                return "";
            }


        }
        string GFXWingEmptyMainImg()
        {
            return GFX.GFXWingEmptyMainImg();
        }
        public void EXECUTE()
        {
            if (_wing != null && _WingType != null)
            {
                executeCalc();
                ExecuteHinges();
                if (_Advanced != null)
                {
                    Locks(_Advanced.woodBehalaLock);

                }

                pecesWood();
                StikrsData();
                MakhzerShemnStander();
                ADDon();
                stanls();
                exUpDoorOpen();
                OUT.AtmerIsActive = _wing.Atmer.ToString();
                OUT.outHandleComment = LockTypeName();
                OUT.Scatch3Text = Scatch3Text();
                OUT.IDDoor = _WingID;

                OUT.FullNameWinge = _FullNameWinge();
                OUT.Windoimg = GFXwindows();
                OUT.out_imagTrisProfile = GFXimagTrisProfile();

                OUT.TrisLines = GFXtrisLine();
                OUT.outimgWindwosCenterLine = GFXwindowline();
                OUT.Trisimg = GFXTris();
                // OUT.Lockimg = GFXLock();
                OUT.imgWoodProfilecal = GFXKantType();
                OUT.outimgDoorWood = GFXDOORwood();
                OUT.outimagPolSide = AlphaProfile();
                OUT.PoleHight1 = FinalHightPol;
                OUT.Test1 = _WingType.TEST1;
                OUT.Test3 = _WingType.TEST3;
                OUT.outTest2 = _WingType.TEST2;
                OUT.outWoodLowerPlatzHight = WoodLowerPlatzHight();
                OUT.outAlphaPoleParam = ColoerSide();
                OUT.outFactoryComments = _wing.FactoryNotes;
                OUT.outComments = _wing.Notes;
                OUT.outLocation = _wing.Location;
                OUT.outColorwing = _colorWingeName();
                OUT.outMeterialWidth = _wing.FormaicaThickness.ToString();
                OUT.outDate11 = _wing.UpdateDate.ToString("yyyy-MM-dd");
                OUT.PicProfileTrisNormal = PicProfileTrisNormal();

                if (_wing.DoubleDoor && _WingType.TEST2 == "A")
                {
       
                        OUT.DDside = GFX.imgGfxDDlockSide();
                 
                   
                }
                else
                {
                    OUT.DDside = clsImageLibrary.Empty;
                }

                OUT.outDirection = DirectionDoor(); 
                OUT.outDoorAmount = _wing.tbAmount.ToString();

                OUT.HiddenOijaloi = _HiddenOijaloi();
                OUT.HiddenOiNormal = _HiddenOiNormal();
                OUT.DimeterWindo = DimeterWindo();


                OUT.WingEmptyMainImg = GFXWingEmptyMainImg();

                OUT.outImagLock = ImagLock();

                OUT.outDoorIdentification = _wing.AccID.ToString();
                OUT.outWingType = _FullNameWinge();

                if (_windows != null)
                {
                    OUT.outTrisHight = _windows.TrisHeight;
                    OUT.outTrisWidth1 = _windows.TrisWidth;
                    OUT.outTrisPositionFromHandle = _windows.TrisPositionFromHandle;
                    OUT.outTrisPositionFromBottom = _windows.TrisPositionFromBottom;
                    OUT.outTrisComment = TrisComment();
                    OUT.outWindowWidth1 = _windows.WindowWidth.ToString();
                    OUT.outWindowHight1 = _windows.WindowHeight;
                    OUT.outWindowUpPosition = _windows.WindowPositionFromAbove;
                    OUT.outWindowPosFromHand = _windows.WindowPositionFromHandle;
                    OUT.outWindowComment = _WindoComment();
                    OUT.outWindowTypecheck = WindowTypecheck();
                    OUT.outWindowCircleHight = CircleLocationv(_windows.CircleLocationFromBottom);
                    OUT.outWindoINcenter = IsHiddenEqualsSignForTheMiddle("Windo");
                    OUT.outTrisType = _windows.TrisType;
                    OUT.outTrisINcenter = IsHiddenEqualsSignForTheMiddle("Tris");
                    OUT.AorHole = _windows.AorHole ? "Show" : "Hidd";
                }

                OUT.outInjection = Injection();
            }
        }

        private string _colorWingeName()
        {

            if (_wing != null)
            {
                if (int.TryParse(_wing.ColorDoor, out int res))
                {
                    if (_wing.WingType != null && _wing.WingType.TEST2 == "A")
                    {
                        if (clsColorSide.Find(res) != null)
                        {
                            return clsColorSide.Find(res).ColorName;
                        }
                    }
                    else
                    {
                        if (clsFormicaColor.Find(res) != null)
                        {
                            return clsFormicaColor.Find(res).ColorName;
                        }
                    }
                }
            }

            return "";
        }
    }
}
