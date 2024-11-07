using Doors4.clsGenral;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.WingCalc
{
    public class WingItemsDefult
    {
        clsWings _wing;
        clsWingAdvanced _advanced;
        DataRow[] Row;
        clsKantWingManual _KWM;
      
        public int BukA { get; set; } = 0;
        public int BukB { get; set; } = 0;
        public int BukC { get; set; } = 0;
        public int BukD { get; set; } = 0;
        public int BukE { get; set; } = 0;
        public int BukF { get; set; } = 0;
        public int WoodHight { get; set; }
        public int WoodWidth { get; set; }
        public int MetalHight { get; set; }
        public int MetalWidth { get; set; }
        public int MetalWidth2 { get; set; }
        public int FinalHight { get; set; }
        public int FinalWidth { get; set; }



        public int PletzHight { get; set; }
        public int PletzWidth { get; set; }
        public int woodPletzWidth { get; set; }

        public WingItemsDefult(int WingID)
        {
            if (WingID > 0)
            {
                _wing = clsWings.Find(WingID);
                _advanced = clsWingAdvanced.FindByWingID(WingID);
                _KWM = clsKantWingManual.FindByWingID(WingID);
            }
            if (_wing != null)
            {
                getWHdataFromDB();


                this._PlatzCalc();
                this.Metal();
                this.wood();
            }


        }

        void getWHdataFromDB()
        {
            if (_wing.WidthCut > 0 && _wing.HeightCut > 0)
            {
                this.PletzWidth = _wing.WidthCut; //WidthCut = PletzWidth
                this.PletzHight = _wing.HeightCut; //PletzHight = HeightCut
            }
            else
            {

                this.FinalHight = _wing.HeightFinal;
                this.FinalWidth = _wing.WidthFinal;
            }


        }

        void calcuPlatzFinal()
        {
            if (_wing.WingType.TEST1 == "ALPH")
            {
                FinalHight = PletzHight - 14;

                if (_wing.DDAK == "A" && _wing.DoubleDoor)
                {
                    if (_wing.WingType.TEST2 == "A")
                    {
                        FinalWidth = PletzWidth - 207;
                    }
                    else if (_wing.WingType.TEST2 == "F")
                    {
                        FinalWidth = PletzWidth - 158;
                    }
                }
                else if (_wing.DDAK == "K" && _wing.DoubleDoor)
                {
                    if (_wing.WingType.TEST2 == "A")
                    {
                        FinalWidth = PletzWidth - 207;
                    }
                    else if (_wing.WingType.TEST2 == "F")
                    {
                        FinalWidth = PletzWidth - 158;
                    }
                }
                else  //normal - stander
                {
                    FinalWidth = PletzWidth - 86;
                }

            }
            else if (_wing.WingType.TEST2 == "A")
            {
                FinalHight = PletzHight - 12;

                if (_wing.DDAK == "A" && _wing.DoubleDoor)
                {
                    FinalWidth = PletzWidth - 50;
                }
                else if (_wing.DDAK == "K" && _wing.DoubleDoor)
                {
                    FinalWidth = PletzWidth - 50;
                }
                else //normal - stander
                {
                    FinalWidth = PletzWidth - 7;
                }

            }
            else if (_wing.WingType.TEST2 == "F")
            {

                   if (_wing.WingType.TEST1 == "PVT")
                {
                    FinalHight = PletzHight - 29;
                }
                   else
                {
                    FinalHight = PletzHight - 12;
                }
               

                if (_wing.WingType.TEST3 == "Medic")
                {
                    FinalWidth = PletzWidth - 30;
                    if (_wing.DDAK == "A" && _wing.DoubleDoor)
                    {
                        FinalWidth = PletzWidth - 68;
                    }
                    else if (_wing.DDAK == "K" && _wing.DoubleDoor)
                    {
                        FinalWidth = PletzWidth - 68;
                    }
                    else //normal - stander
                    {
                        FinalWidth = PletzWidth - 30;
                    }
                }
                else if (_wing.WingType.TEST1 == "PNDL")
                {

                    FinalHight = PletzHight - 13;
                    FinalWidth = PletzWidth - 0;
                    if (_wing.DDAK == "A" && _wing.DoubleDoor)
                    {
                        FinalWidth = PletzWidth - 58;
                    }
                    else if (_wing.DDAK == "K" && _wing.DoubleDoor)
                    {
                        FinalWidth = PletzWidth - 58;
                    }
                }
                else if (_wing.DDAK == "A" && _wing.DoubleDoor || _wing.DDAK == "K" && _wing.DoubleDoor)
                {
                    if (_wing.DDAK == "A" && _wing.DoubleDoor)
                    {
                        FinalWidth = PletzWidth;
                    }
                    else if (_wing.DDAK == "K" && _wing.DoubleDoor)
                    {
                        FinalWidth = PletzWidth;
                    }
                }
                else //normal - stander
                {
                    if (_wing.DDAK == "A" && _wing.DoubleDoor)
                    {
                        FinalWidth = PletzWidth - 13;
                    }
                    else if (_wing.DDAK == "K" && _wing.DoubleDoor)
                    {
                        FinalWidth = PletzWidth - 13;
                    }
                    else //normal - stander
                    {
                        FinalWidth = PletzWidth - 8;
                    }
                }

            }          
        }



        void _PlatzCalc() //uaav final
        {


            if (_wing.WingType == null || _wing == null)
                return;
            var temp = clsWings.Find(_wing.DDWingID);


            if (_wing.WidthCut > 0 && _wing.HeightCut > 0 && _wing.WidthFinal <= 0 && (_wing.DDAK == "A" || _wing.DDAK == "K") && _wing.DoubleDoor)
            {
                calcuPlatzFinal();

                this.FinalWidth = (this.FinalWidth / 2);

                _wing.WidthFinal = 0;
                temp.WidthFinal = 0;
                _wing.Save();
                temp.Save();

            }
            else
            {

                if (_wing.WidthCut > 0 && _wing.HeightCut > 0 && _wing.WidthFinal > 0 && _wing.DDAK == "A" && _wing.DoubleDoor)
                {
                    calcuPlatzFinal();

                    temp.WidthFinal = ((this.FinalWidth - _wing.WidthFinal) * 1);
                    this.FinalWidth = _wing.WidthFinal;


                }
                else if (_wing.WidthCut > 0 && _wing.HeightCut > 0 && _wing.WidthFinal > 0 && _wing.DDAK == "K" && _wing.DoubleDoor)
                {
                    calcuPlatzFinal();


                    temp.WidthFinal = ((this.FinalWidth - _wing.WidthFinal) * 1);
                    this.FinalWidth = _wing.WidthFinal;


                }

                else if (_wing.WidthCut > 0 && _wing.HeightCut > 0)
                {

                    calcuPlatzFinal();



                }
                if (temp != null)
                {
                    temp.Save();
                }

            }


        }

        int checkDBNUll(string nameCul)
        {
           return Row[0][nameCul] == DBNull.Value || (int)Row[0][nameCul] == 0 ? 0 : (int)Row[0][nameCul];
        }
        void getDefultData(int IDDEf)
        {
            Row = clsGlobal.DefultKantLocal.Select($"ID = {IDDEf}");//Defult value kant

            if (_KWM != null && _KWM.KantA > 0)
            {

                BukA = _KWM.KantA;


            }
            else
            {
                BukA = checkDBNUll("KantA");

            }


            if (_KWM != null && _KWM.KantB > 0)
            {


                BukB = _KWM.KantB;

            }
            else
            {

                BukB = checkDBNUll("KantB");
            }

            if (_KWM != null && _KWM.KantC > 0)
            {


                BukC = _KWM.KantC;

            }
            else
            {

                BukC = checkDBNUll("KantC");
            }


            if (_KWM != null && _KWM.KantD > 0)
            {


                BukD = _KWM.KantD;

            }
            else
            {

                BukD = checkDBNUll("KantD"); // Row[0]["KantD"] == DBNull.Value  || (int)Row[0]["KantD"] ==0 ? -1:(int)Row[0]["KantD"];
            }
            


            if (_KWM != null && _KWM.KantE > 0)
            {


                BukE = _KWM.KantE;

            }
            else
            {

                BukE = checkDBNUll("KantE");
            }   
            
            if (_KWM != null && _KWM.KantF > 0)
            {


                BukF = _KWM.KantF;

            }
            else
            {

                BukF = checkDBNUll("KantF");
            }     
    


        }

 

        //void woodautomaticA()
        //{
        //    if (_wing == null || _wing.WingType == null)
        //        return;


        //    if (_wing.WingType.TEST2 == "A")
        //    {
        //        BukA = 43;
        //        //   BukB = 30;
        //        WoodHight = FinalHight - 2;
        //        WoodWidth = -1;
        //        woodPletzWidth = FinalWidth - BukB * 2;


        //    }
        //    else
        //    {

        //        if (_wing.WingType.TEST3 == "0")
        //        {

        //            BukA = 37;
        //            // BukB = 37;
        //            WoodHight = FinalHight + 6;
        //            WoodWidth = MetalWidth;
        //            woodPletzWidth = WoodWidth - BukA * 2;


        //            //else if (_wing.FormaicaThickness == 2.5)
        //            //{
        //            //    BukA = 40;
        //            //    BukB = 37;
        //            //    WoodHight = FinalHight + 6;
        //            // WoodWidth = MetalWidth;
        //            //    woodPletzWidth = WoodWidth - BukB * 2;
        //            //   
        //            //}

        //        }
        //        else if (_wing.WingType.TEST3 == "Medic")
        //        {

        //            BukA = 37;
        //            //BukB = 37;
        //            WoodHight = FinalHight + 6;
        //            WoodWidth = MetalWidth;
        //            woodPletzWidth = WoodWidth - BukA * 2;



        //        }

        //        else if (_wing.WingType.TEST3 == "3")
        //        {
        //            BukA = 40;
        //            // BukB = 37;
        //            WoodHight = FinalHight + 0;
        //            WoodWidth = FinalWidth;
        //            woodPletzWidth = WoodWidth - BukB * 2;

        //        }


        //        else if (_wing.WingType.TEST3 == "4")
        //        {
        //            BukA = 40;
        //            //  BukB = 37;
        //            WoodHight = FinalHight + 0;
        //            WoodWidth = FinalWidth;
        //            woodPletzWidth = WoodWidth - BukB * 2;

        //        }
        //    }
        //}


        //void woodautomaticB()
        //{
        //    if (_wing == null || _wing.WingType == null)
        //        return;


        //    if (_wing.WingType.TEST2 == "A")
        //    {
        //        //BukA = 43;
        //        BukB = 30;
        //        WoodHight = FinalHight - 2;
        //        WoodWidth = -1;
        //        woodPletzWidth = FinalWidth - BukB * 2;


        //    }
        //    else
        //    {

        //        if (_wing.WingType.TEST3 == "0")
        //        {

        //            //  BukA = 37;
        //            BukB = 37;
        //            WoodHight = FinalHight + 6;
        //            WoodWidth = MetalWidth;
        //            woodPletzWidth = WoodWidth - BukA * 2;


        //            //else if (_wing.FormaicaThickness == 2.5)
        //            //{
        //            //    BukA = 40;
        //            //    BukB = 37;
        //            //    WoodHight = FinalHight + 6;
        //            // WoodWidth = MetalWidth;
        //            //    woodPletzWidth = WoodWidth - BukB * 2 ;
        //            //    
        //            //}

        //        }
        //        else if (_wing.WingType.TEST3 == "Medic")
        //        {

        //            //BukA = 37;
        //            BukB = 37;
        //            WoodHight = FinalHight + 6;
        //            WoodWidth = MetalWidth;
        //            woodPletzWidth = WoodWidth - BukA * 2 - 6;



        //        }

        //        else if (_wing.WingType.TEST3 == "3")
        //        {
        //            //   BukA = 40;
        //            BukB = 37;
        //            WoodHight = FinalHight + 0;
        //            WoodWidth = FinalWidth;
        //            woodPletzWidth = WoodWidth - BukB * 2;

        //        }


        //        else if (_wing.WingType.TEST3 == "4")
        //        {
        //            // BukA = 40;
        //            BukB = 37;
        //            WoodHight = FinalHight + 0;
        //            WoodWidth = FinalWidth;
        //            woodPletzWidth = WoodWidth - BukB * 2;

        //        }
        //    }
        //}

        //void woodautomaticAB()
        //{
        //    if (_wing == null || _wing.WingType == null)
        //        return;


        //    if (_wing.WingType.TEST2 == "A")
        //    {
        //        //BukA = 43;
        //        // BukB = 30;
        //        WoodHight = FinalHight - 2;
        //        WoodWidth = -1;
        //        woodPletzWidth = FinalWidth - BukB * 2;


        //    }
        //    else
        //    {

        //        if (_wing.WingType.TEST3 == "0")
        //        {

        //            //  BukA = 37;
        //            //  BukB = 37;
        //            WoodHight = FinalHight + 6;
        //            WoodWidth = MetalWidth;
        //            woodPletzWidth = WoodWidth - BukA * 2;


        //            //else if (_wing.FormaicaThickness == 2.5)
        //            //{
        //            //    BukA = 40;
        //            //    BukB = 37;
        //            //    WoodHight = FinalHight + 6;
        //            //WoodWidth = MetalWidth;
        //            //    woodPletzWidth = WoodWidth - BukB * 2 ;
        //            //    
        //            //}

        //        }
        //        else if (_wing.WingType.TEST3 == "Medic")
        //        {

        //            //BukA = 37;
        //            //BukB = 37;
        //            WoodHight = FinalHight + 6;
        //            WoodWidth = MetalWidth;
        //            woodPletzWidth = WoodWidth - BukA * 2;



        //        }

        //        else if (_wing.WingType.TEST3 == "3")
        //        {
        //            //   BukA = 40;
        //            //  BukB = 37;
        //            WoodHight = FinalHight + 0;
        //            WoodWidth = FinalWidth;
        //            woodPletzWidth = WoodWidth - BukB * 2;

        //        }


        //        else if (_wing.WingType.TEST3 == "4")
        //        {
        //            // BukA = 40;
        //            //BukB = 37;
        //            WoodHight = FinalHight + 0;
        //            WoodWidth = FinalWidth;
        //            woodPletzWidth = WoodWidth - BukB * 2;

        //        }
        //    }
        //}

        void wood() //need to connect, BukA &Buk B - dispaly to view. ,WoodHight is final Hight for wood Image.
        {

            if (_wing == null || _wing.WingType == null)
                return;


            if (_wing.WingType.TEST2 == "A")
            {


                getDefultData(2);//2 - Type door A



                WoodHight = FinalHight - 2;
                WoodWidth = -1;
                woodPletzWidth = FinalWidth - BukB * 2;


            }
            else
            {

                if (_wing.WingType.TEST3 == "0")
                {

                    if(_wing.DoubleDoor && _wing.DDAK == "A")
                    {
                        getDefultData(6);//6 - dd A f0
                    }
                    else if (_wing.DoubleDoor && _wing.DDAK == "K")
                    {
                        getDefultData(7);//7 - dd K f0
                    }
                    else if(_wing.WingType.TEST1 == "PVT")
                    {
                        getDefultData(10);//10 - pivot f0
                    }
                    else
                    {
                        getDefultData(1);//1 - Type door f0
                    }
                       


                    WoodHight = FinalHight + 6;
                    WoodWidth = MetalWidth;
                    woodPletzWidth = WoodWidth - BukA * 2;


                    //else if (_wing.FormaicaThickness == 2.5)
                    //{
                    //    BukA = 40;
                    //    BukB = 37;
                    //    WoodHight = FinalHight + 6;
                    //  WoodWidth = MetalWidth;
                    //    woodPletzWidth = WoodWidth - BukB * 2;
                    //    
                    //}

                }
                else if (_wing.WingType.TEST3 == "Medic")
                {
                    if (_wing.DoubleDoor && _wing.DDAK == "A")
                    {
                     //   getDefultData(6);//11 - dd A f0
                    }
                    else if (_wing.DoubleDoor && _wing.DDAK == "K")
                    {
                      //  getDefultData(7);//12 - dd K f0
                    }
                    else if (_wing.WingType.TEST1 == "PVT")
                    {
                        getDefultData(10);//10 - pivot f0
                    }
                    else
                    {
                        getDefultData(3);//3 - Type door Medic
                    }

                

                    WoodHight = FinalHight + 6;
                    WoodWidth = MetalWidth;
                    woodPletzWidth =  WoodWidth - BukA * 2;



                }

                else if (_wing.WingType.TEST3 == "3")
                {

                    if (_wing.DoubleDoor && _wing.DDAK == "A")
                    {
                           getDefultData(8);//8 - dd A f3/4
                    }
                    else if (_wing.DoubleDoor && _wing.DDAK == "K")
                    {
                          getDefultData(9);//9 - dd K f3/4
                    }
                    else if (_wing.WingType.TEST1 == "PVT")
                    {
                        getDefultData(10);//10 - pivot f0
                    }
                    else
                    {
                        getDefultData(4);//4 - Type door F3/4
                    }

             

                    WoodHight = FinalHight + 0;
                    WoodWidth = FinalWidth;
                    woodPletzWidth = WoodWidth - BukB * 2;

                }


                else if (_wing.WingType.TEST3 == "4")
                {
                    if (_wing.DoubleDoor && _wing.DDAK == "A")
                    {
                        getDefultData(8);//8 - dd A f3/4
                    }
                    else if (_wing.DoubleDoor && _wing.DDAK == "K")
                    {
                        getDefultData(9);//9 - dd K f3/4
                    }
                    else
                    {
                        getDefultData(5);//4 - Type door F3/4
                    }
                    
                    if (_wing.WingType.TEST1 == "PVT")
                    {
                        getDefultData(10);//10 - pivot f0
                    }
                    else
                    {
                        getDefultData(5);//4 - Type door F3/4
                    }
                
                    WoodHight = FinalHight + 0;
                    WoodWidth = FinalWidth;
                    woodPletzWidth = FinalWidth - BukB * 2;
                }
            }

       
            //if (_advanced != null && _advanced.KantB > 0 && _advanced.KantA > 0)
            //{
            //    BukA = _advanced.KantA;
            //    BukB = _advanced.KantB;
            //    woodautomaticAB();
            //}

            //else if (_advanced != null && _advanced.KantB > 0)
            //{

            //    BukB = _advanced.KantB;
            //    woodautomaticA();

            //}
            //else if (_advanced != null && _advanced.KantA > 0)
            //{

            //    BukA = _advanced.KantA;
            //    woodautomaticB();


            //}
            //else
            //{
            //    woodautomatic();
            //}




        }
        void Metal() //Calculations for metal/Formaika size. Need to connect. 
        {
            if (_wing == null || _wing.WingType == null)
                return;


            if (_wing.WingType.TEST2 == "A")
            {
                MetalHight = FinalHight + 12;
                MetalWidth = FinalWidth + 12;

            }
            else
            {

                if (_wing.WingType.TEST3 == "0")
                {
                    MetalHight = FinalHight + 6;
                    MetalWidth = FinalWidth + 6;
                }
                else if (_wing.WingType.TEST3 == "Medic")
                {
                    MetalHight = FinalHight + 6;
                    MetalWidth = FinalWidth + 6;
                }
                else if (_wing.WingType.TEST3 == "3")
                {
                    MetalHight = FinalHight - 17;
                    if (_wing.DoubleDoor && _wing.DDAK == "A")
                    {
                        MetalWidth2 = FinalWidth - 31; //Difference of 13mm in Doubledoor
                        MetalWidth = FinalWidth - 18; //

                    }
                    else
                    {
                        MetalWidth = FinalWidth - 31;
                    }
                }
                else if (_wing.WingType.TEST3 == "4")
                {
                    MetalHight = FinalHight - 32;
                    if (_wing.DoubleDoor && _wing.DDAK == "A")
                    {
                        MetalWidth2 = FinalWidth - 31; //Difference of 13mm in Doubledoor
                        MetalWidth = FinalWidth - 18;
                    }
                    else
                    {
                        MetalWidth = FinalWidth - 31;
                    }
                }
            }

        }



    }
}
