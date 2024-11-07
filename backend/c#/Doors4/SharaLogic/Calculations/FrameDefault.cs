using Doors4.clsGenral;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic.Calculations
{
    public class FrameDefault
    {
        DataRow[] Row;


        public double A1 { get; set; }
        public double A2 { get; set; }
        public double B1 { get; set; }
        public double B2 { get; set; }
        public double C1 { get; set; }
        public double C2 { get; set; }
        public double D1 { get; set; }
        public double D2 { get; set; }
        public double E1 { get; set; }
        public double E2 { get; set; }
        public double F1 { get; set; }
        public double F2 { get; set; }
        public double G1 { get; set; }
        public double G2 { get; set; }

        public double Bends { get; set; }


        public double F1A { get; set; }
        public double F1B { get; set; }
        public double F2B { get; set; }


        public double MG { get; set; }

        public double K125 { get; set; }
        public double K15 { get; set; }
        public double K2 { get; set; }

        clsPrisa prisManoul;

        public FrameDefault(int IdFram)
        {
            prisManoul = clsPrisa.findbyFrameid(IdFram);

        }



        void defultvalue()
        {
            A1 = 0;
            A2 = 0;
            B1 = 0;
            B2 = 0;
            C1 = 0;
            C2 = 0;
            D1 = 0;
            D2 = 0;
            E1 = 0;
            E2 = 0;
            F1 = 0;
            F2 = 0;
            G1 = 0;
            G2 = 0;
            K125 = 0;
            K15 = 0;
            K2 = 0;
            Bends = 0;
            MG = 0;

        }
        public void Magnetic()
        {

            //   MG = 16;

        }

        void MagneticSet(string str)
        {

            if (double.TryParse(str, out double mg))
            {
                if (mg > 0)
                {
                    MG = mg;
                }
                else
                {
                    MG = 0;
                }
            }
        }

        public void BlindANDPivotClick()
        {
            defultvalue();
             
            Row = clsGlobal.DefultFrameLocal.Select("ID =16"); //16-office /// mahmoud 17
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) && double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
                double.TryParse(Row[0]["B1"].ToString(), out double bb1) && double.TryParse(Row[0]["B2"].ToString(), out double bb2) &&
                double.TryParse(Row[0]["C1"].ToString(), out double cc1) && double.TryParse(Row[0]["C2"].ToString(), out double cc2) &&
                 double.TryParse(Row[0]["Bends"].ToString(), out double bBends)
                )
            {
                if (prisManoul != null)
                {
                    if (prisManoul.corner1 > 0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString());
                    }
                    else
                    {
                        A1 = aa1;
                    }

                    if (prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString());
                    }
                    else
                    {
                        A2 = aa2;
                    }

                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString());
                    }
                    else
                    {
                        B1 = bb1;
                    }

                    if (prisManoul.corner4 > 0)
                    {
                        B2 = double.Parse(prisManoul.corner4.ToString());
                    }
                    else
                    {
                        B2 = bb2;
                    }  
                    
                    if (prisManoul.corner5 > 0)
                    {
                        C1 = double.Parse(prisManoul.corner5.ToString());
                    }
                    else
                    {
                        C1 = cc1;
                    }   
                    
                    if (prisManoul.corner6 > 0)
                    {
                        C2 = double.Parse(prisManoul.corner6.ToString());
                    }
                    else
                    {
                        C2 = cc2;
                    }

                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString());
                    }
                    else
                    {
                        Bends = bBends;
                    }

                }
                else
                {
                    A1 = aa1; //30;

                    A2 = aa2;//30;
                    B1 = bb1;//12;
                    B2 = bb2; //12;
                    C1 = cc1; //12;
                    C2 = cc2; //12;
                    Bends = bBends; ;//8;
                }




                MagneticSet(Row[0]["MG"].ToString());


            }
            else
            {
                A1 = 0; //30;
                A2 = 0;//30;
                B1 = 0;//12;
                B2 = 0; //12;
                C1 = 0;
                C2 = 0;

               Bends = 0; ;//8;

                MG = 0;
            }



        }

        public void Blind()
        {
            defultvalue();

            Row = clsGlobal.DefultFrameLocal.Select("ID = 1"); //1-office
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) && double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
                double.TryParse(Row[0]["B1"].ToString(), out double bb1) && double.TryParse(Row[0]["B2"].ToString(), out double bb2) &&
                 double.TryParse(Row[0]["Bends"].ToString(), out double bBends)
                )
            {
                if (prisManoul != null)
                {
                    if (prisManoul.corner1 > 0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString()); 
                    }
                    else
                    {
                        A1 = aa1; 
                    }

                    if (prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString()); 
                    }
                    else
                    {
                        A2 = aa2; 
                    }

                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString()); 
                    }
                    else
                    {
                        B1 = bb1; 
                    }

                    if (prisManoul.corner4 > 0)
                    {
                        B2 = double.Parse(prisManoul.corner4.ToString()); 
                    }
                    else
                    {
                        B2 = bb2; 
                    }    
                    
                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString()); 
                    }
                    else
                    {
                        Bends = bBends; 
                    }

                }
                else
                {
                    A1 = aa1; //30;

                    A2 = aa2;//30;
                    B1 = bb1;//12;
                    B2 = bb2; //12;
                    Bends = bBends; ;//8;
                }




                MagneticSet(Row[0]["MG"].ToString());


            }
            else
            {
                A1 = 0; //30;
                A2 = 0;//30;
                B1 = 0;//12;
                B2 = 0; //12;


                Bends = 0; ;//8;
         
                MG = 0;
            }





        }
        public void Pendel()
        {
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID = 2");  //2- office
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) && double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
                double.TryParse(Row[0]["B1"].ToString(), out double bb1) && double.TryParse(Row[0]["B2"].ToString(), out double bb2) &&
                 double.TryParse(Row[0]["Bends"].ToString(), out double bBends) && double.TryParse(Row[0]["F1"].ToString(), out double ff1) &&
                 double.TryParse(Row[0]["D1"].ToString(), out double dd1) && double.TryParse(Row[0]["D2"].ToString(), out double dd2) 
                 && double.TryParse(Row[0]["C1"].ToString(), out double cc1)

                 )

            {
                if (prisManoul != null)
                {

                    if (prisManoul.corner1 > 0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString());
                    }
                    else
                    {
                        A1 = aa1; 
                    }
                  
                    if (prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString()); 
                    }
                    else
                    {
                        A2 = aa2; 
                    }

                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString()); 
                    }
                    else
                    {
                        B1 = bb1; 
                    }

                    if (prisManoul.corner4 > 0)
                    {
                        B2 = double.Parse(prisManoul.corner4.ToString());
                    }
                    else
                    {
                        B2 = bb2; 
                    }

                    if (prisManoul.corner11 > 0) 
                    {
                        F1 = double.Parse(prisManoul.corner11.ToString()); 
                    }
                    else
                    {
                        F1 = ff1; 
                    }

                    if (prisManoul.corner7 > 0)
                    {
                        D1 = double.Parse(prisManoul.corner7.ToString()); 
                    }
                    else
                    {
                        D1 = dd1; 
                    }


                    if (prisManoul.corner8 > 0)
                    {
                        D2 = double.Parse(prisManoul.corner8.ToString());
                    }
                    else
                    {
                        D2 = dd2;
                    }
                     
                    
                    if (prisManoul.corner5 > 0)
                    {
                        C1 = double.Parse(prisManoul.corner5.ToString());
                    }
                    else
                    {
                        C1 = cc1;
                    }

                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString());
                    }
                    else
                    {
                        Bends = bBends;
                    }

                }
                else
                {
                    A1 = aa1;
                    A2 = aa2;
                    B1 = bb1;
                    B2 = bb2;
                    F1 = ff1;
                    D1 = dd1;
                    D2 = dd2;
                    C1 = cc1;
                    Bends = bBends;
                }



                MagneticSet(Row[0]["MG"].ToString());
            }
            else
            {
                A1 = 0;//30;
                A2 = 0;// 30;
                B1 = 0;// 12;
                B2 = 0;// 12;
                F1 = 0;// 2;
                D1 = 0;// 16;
                D2 = 0;// 16;
                C1 = 0;// 16;
                Bends = 0;//10
                MG = 0;
            }


       


        }


       


        public void RegularStandartF1()
        {
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID = 3"); //3-office
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) && double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
                double.TryParse(Row[0]["B1"].ToString(), out double bb1) && double.TryParse(Row[0]["B2"].ToString(), out double bb2) &&
                 double.TryParse(Row[0]["Bends"].ToString(), out double bBends) && double.TryParse(Row[0]["F1"].ToString(), out double ff1) &&
                 double.TryParse(Row[0]["F1B"].ToString(), out double fF1B) && double.TryParse(Row[0]["K15"].ToString(), out double kK15) && double.TryParse(Row[0]["K125"].ToString(), out double kK125)

                 )

            {
                if (prisManoul != null)
                {

                    if(prisManoul.corner1 > 0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString());
                    }
                    else
                    {
                        A1 = aa1;
                    } 
                    

                    
                    if(prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString());
                    }
                    else
                    {
                        A2 = aa2;
                    }



                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString());
                    }
                    else
                    {
                        B1 = bb1;
                    }


                    if (prisManoul.corner4 > 0)
                    {
                        B2 = double.Parse(prisManoul.corner4.ToString());
                    }
                    else
                    {
                        B2 = bb2;
                    }


                    if (prisManoul.corner11 > 0)
                    {
                        F1 = double.Parse(prisManoul.corner11.ToString());
                    }
                    else
                    {
                        F1 = ff1;
                    }

                    if (prisManoul.corner16 > 0)
                    {
                        F1B = double.Parse(prisManoul.corner16.ToString());
                    }
                    else
                    {
                        F1B = fF1B;
                    }

                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString());
                    }
                    else
                    {
                        Bends = bBends;
                    }   
                    
                    if (prisManoul.magnet > 0)
                    {
                        MG = double.Parse(prisManoul.magnet.ToString());
                    }
                    else
                    {
                        MagneticSet(Row[0]["MG"].ToString());
                    }

                }
                else
                {
                    A1 = aa1;
                    A2 = aa2;
                    B1 = bb1;
                    B2 = bb2;
                    F1 = ff1;
                    F1B = fF1B;

                    Bends = bBends;
                    MagneticSet(Row[0]["MG"].ToString());


                }


                K15 = kK15;
                K125 = kK125;



            }
            else
            {
                A1 = 0;// 30;
                A2 = 0;// 45;
                B1 = 0;// 12;
                B2 = 0;// 12;
                F1 = 0;// 53;
                F1B = 0;// 28;
                Bends = 0;// 10;
                K15 = 0;// 1;
                K125 = 0;//0
            }
       
        }
        public void RegularStandartF2()
        { 
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID = 4"); // 4- office
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) && double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
                double.TryParse(Row[0]["B1"].ToString(), out double bb1) && double.TryParse(Row[0]["B2"].ToString(), out double bb2) &&
                 double.TryParse(Row[0]["Bends"].ToString(), out double bBends) && double.TryParse(Row[0]["F1"].ToString(), out double ff1) &&
                 double.TryParse(Row[0]["F1B"].ToString(), out double fF1B) && double.TryParse(Row[0]["K15"].ToString(), out double kK15 )&&
                 double.TryParse(Row[0]["K125"].ToString(), out double kK125) && double.TryParse(Row[0]["D1"].ToString(), out double dd1) 
                 
                 ) {

                if(prisManoul != null)
                {

                    if(prisManoul.corner1 >0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString());
                    }
                    else
                    {
                        A1 = aa1;
                    }

                    if (prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString());
                    }
                    else
                    {
                        A2 = aa2;
                    }

                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString());
                    }
                    else
                    {
                        B1 = bb1;
                    }

                    if (prisManoul.corner4 > 0)
                    {
                        B2 = double.Parse(prisManoul.corner4.ToString());
                    }
                    else
                    {
                        B2 = bb2;
                    }

                    if (prisManoul.corner11 > 0)
                    {
                        F1= double.Parse(prisManoul.corner11.ToString());
                    }
                    else
                    {
                        F1 = ff1;
                    }

                    if (prisManoul.corner16 > 0)
                    {
                        F1B = double.Parse(prisManoul.corner16.ToString());
                    }
                    else
                    {
                        F1B = fF1B;
                    }

                    if (prisManoul.corner7 > 0)
                    {
                        D1 = double.Parse(prisManoul.corner7.ToString());
                    }
                    else
                    {
                        D1 = dd1;
                    }

                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString());
                    }
                    else
                    {
                        Bends = bBends;
                    }



                }
                else
                {
                    A1 = aa1;// 30;
                    A2 = aa2;// 45; //30
                    B1 = bb1;// 12;
                    B2 = bb2;// 12;
                    F1 = ff1;// 53;
                    F1B = fF1B;// 28;
                    D1 = dd1;// 16;
                    Bends = bBends;
                
                }


              
                K125 = kK125;// 1;
                K15 = kK15;// 2;

                MagneticSet(Row[0]["MG"].ToString());


            }
            else
            {
                A1 = 0;// 30;
                A2 = 0;// 45; //30
                B1 = 0;// 12;
                B2 = 0;// 12;
                F1 = 0;// 53;
                F1B = 0;// 28;
                D1 = 0;// 16;
                Bends = 0;// 14;
                K125 = 0;// 1;
                K15 = 0;// 2;
            }
          
        }
        public void RegularStandarAQ60()
        {
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID = 5"); //5-office 
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) && double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
                double.TryParse(Row[0]["B1"].ToString(), out double bb1) && double.TryParse(Row[0]["B2"].ToString(), out double bb2) &&
                 double.TryParse(Row[0]["Bends"].ToString(), out double bBends) && double.TryParse(Row[0]["F1"].ToString(), out double ff1) &&
                 double.TryParse(Row[0]["F2"].ToString(), out double ff2) && double.TryParse(Row[0]["D2"].ToString(), out double dd2) &&
                 double.TryParse(Row[0]["D1"].ToString(), out double dd1)

                 )
            {

                if (prisManoul != null)
                {
                    if (prisManoul.corner1 > 0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString());
                    }
                    else
                    {
                        A1 = aa1;
                    }

                    if (prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString());
                    }
                    else
                    {
                        A2 = aa2;
                    }

                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString());
                    }
                    else
                    {
                        B1 = bb1;
                    }

                    if (prisManoul.corner4 > 0)
                    {
                        B2 = double.Parse(prisManoul.corner4.ToString());
                    }
                    else
                    {
                        B2 = bb2;
                    }

                    if (prisManoul.corner11 > 0)
                    {
                        F1 = double.Parse(prisManoul.corner11.ToString());
                    }
                    else
                    {
                        F1 = ff1;
                    }

                    if (prisManoul.corner12 > 0)
                    {
                        F2 = double.Parse(prisManoul.corner12.ToString());
                    }
                    else
                    {
                        F2 = ff2;
                    }

                    if (prisManoul.corner7 > 0)
                    {
                        D1 = double.Parse(prisManoul.corner7.ToString());
                    }
                    else
                    {
                        D1 = dd1;
                    }


                    if (prisManoul.corner8 > 0)
                    {
                        D2 = double.Parse(prisManoul.corner8.ToString());
                    }
                    else
                    {
                        D2 = dd2;
                    }
                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString());
                    }
                    else
                    {
                        Bends = bBends;
                    }

                }
                else
                {

                    A1 =aa1;
                    A2 = aa2;
                    B1 = bb1;
                    B2 = bb2;
                    F1 = ff1;
                    F2 = ff2;
                    D1 = dd1;
                    D2 = dd2;
                    Bends = bBends;
                }

           
                MagneticSet(Row[0]["MG"].ToString());
            }
            else
            {
                A1 = 0;// 30;
                A2 = 0;// 59;
                B1 = 0;// 12;
                B2 = 0;// 12;
                F1 = 0;// 44;
                F2 = 0;// 24;
                D1 = 0;// 16;
                D2 = 0;// 21;
                Bends = 00;// 12;
            }
        }
        public void AlphaStandartF1()
        {
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID =12"); // 12- office
        }
        public void AlphaStandartF2()
        {
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID = 13"); // 13- office
        }
        public void RegularKantTiachF1()
        {
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID = 6"); //6 -office
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) && double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
                double.TryParse(Row[0]["B1"].ToString(), out double bb1) && double.TryParse(Row[0]["B2"].ToString(), out double bb2) &&
                 double.TryParse(Row[0]["Bends"].ToString(), out double bBends) && double.TryParse(Row[0]["F1"].ToString(), out double ff1) &&
                 double.TryParse(Row[0]["F1B"].ToString(), out double fF1B) && double.TryParse(Row[0]["C1"].ToString(), out double cc1) &&
                 double.TryParse(Row[0]["C2"].ToString(), out double cc2) && double.TryParse(Row[0]["E1"].ToString(), out double ee1) &&
                 double.TryParse(Row[0]["E2"].ToString(), out double ee2) && double.TryParse(Row[0]["K2"].ToString(), out double kk2)&&
                 double.TryParse(Row[0]["K125"].ToString(), out double kk125) && double.TryParse(Row[0]["K15"].ToString(), out double kk15)
                 )
            {

                if (prisManoul != null)
                {
                    if (prisManoul.corner1 > 0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString());
                    }
                    else
                    {
                        A1 = aa1;
                    }      
                    
                    if (prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString());
                    }
                    else
                    {
                        A2 = aa2;
                    }

                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString());
                    }
                    else
                    {
                        B1 = bb1;
                    }   
                    
                    if (prisManoul.corner4 > 0)
                    {
                        B2 = double.Parse(prisManoul.corner4.ToString());
                    }
                    else
                    {
                        B2 = bb2;
                    }
                      
                    
                    if (prisManoul.corner11 > 0)
                    {
                        F1 = double.Parse(prisManoul.corner11.ToString());
                    }
                    else
                    {
                        F1 = ff1;
                    }    
                  
                    if (prisManoul.corner16 > 0)
                    {
                        F1B = double.Parse(prisManoul.corner16.ToString());
                    }
                    else
                    {
                        F1B = fF1B;
                    }
                       
                    
                    if (prisManoul.corner5 > 0)
                    {
                        C1 = double.Parse(prisManoul.corner5.ToString());
                    }
                    else
                    {
                        C1 = cc1;
                    }  
                    
                    if (prisManoul.corner6 > 0)
                    {
                        C2 = double.Parse(prisManoul.corner6.ToString());
                    }
                    else
                    {
                        C2 = cc2;
                    }
                        
                    if (prisManoul.corner9 > 0)
                    {
                        E1 = double.Parse(prisManoul.corner9.ToString());
                    }
                    else
                    {
                        E1 = ee1;
                    } 
                    
                    if (prisManoul.corner10 > 0)
                    {
                        E2 = double.Parse(prisManoul.corner10.ToString());
                    }
                    else
                    {
                        E2 = ee2;
                    }
                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString());
                    }
                    else
                    {
                        Bends = bBends;
                    }



                }
                else
                {
                    A1 = aa1;
                    A2 = aa2;
                    B1 = bb1;
                    B2 = bb2;
                    F1 = ff1;
                    F1B = fF1B;
                    C1 = cc1;
                    C2 = cc2;
                    E1 = ee1;
                    E2 = ee2;
                    Bends = bBends;
         
                }

                  
                    K2 = kk2; //guess  2
                    K15 = kk15;
                    K125 = kk125;
                MagneticSet(Row[0]["MG"].ToString());

            }
            else
            {
                A1 = 0;// 30;
                A2 = 0;// 45;
                B1 = 0;// 12.5;
                B2 = 0;// 12.5;
                F1 = 0;// 53;
                F1B = 0;// 28;
                C1 = 0;// 12.5;
                C2 = 0;// 12.5;
                E1 = 0;// 12.5;
                E2 = 0; // 12.5;
                Bends = 0;// 18;
                K2 = 0;// 2; //guess  2
                K15 = 0;// 2;
                K125 = 0;// -1;

            }
        }
        public void RegularKantTiachF2()
        {
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID = 7"); //7-office
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) && double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
                double.TryParse(Row[0]["B1"].ToString(), out double bb1) && double.TryParse(Row[0]["B2"].ToString(), out double bb2) &&
                 double.TryParse(Row[0]["Bends"].ToString(), out double bBends) && double.TryParse(Row[0]["F1"].ToString(), out double ff1) &&
                 double.TryParse(Row[0]["F1B"].ToString(), out double fF1B) && double.TryParse(Row[0]["C1"].ToString(), out double cc1) &&
                 double.TryParse(Row[0]["C2"].ToString(), out double cc2) && double.TryParse(Row[0]["E1"].ToString(), out double ee1) &&
                 double.TryParse(Row[0]["E2"].ToString(), out double ee2) && 
                 double.TryParse(Row[0]["D1"].ToString(), out double dd1) && double.TryParse(Row[0]["K15"].ToString(), out double kk15)
                 )
            {

                if (prisManoul != null)
                {
                    if (prisManoul.corner1 > 0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString());
                    }
                    else
                    {
                        A1 = aa1;
                    }   
                    
                    if (prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString());
                    }
                    else
                    {
                        A2 = aa2;
                    }   
                    
                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString());
                    }
                    else
                    {
                        B1 = bb1;
                    } 
                    
                    if (prisManoul.corner4 > 0)
                    {
                        B2 = double.Parse(prisManoul.corner4.ToString());
                    }
                    else
                    {
                        B2 = bb2;
                    }   

                    if (prisManoul.corner11 > 0)
                    {
                        F1 = double.Parse(prisManoul.corner11.ToString());
                    }
                    else
                    {
                        F1 = ff1;
                    }


                    if (prisManoul.corner16 > 0)
                    {
                        F1B = double.Parse(prisManoul.corner16.ToString());
                    }
                    else
                    {
                        F1B = fF1B;
                    }  
                    
                    if (prisManoul.corner7 > 0)
                    {
                        D1 = double.Parse(prisManoul.corner7.ToString());
                    }
                    else
                    {
                        D1 = dd1;
                    }  
                    
                    if (prisManoul.corner5 > 0)
                    {
                        C1 = double.Parse(prisManoul.corner5.ToString());
                    }
                    else
                    {
                        C1 = cc1;
                    } 
                    
                    if (prisManoul.corner6 > 0)
                    {
                        C2 = double.Parse(prisManoul.corner6.ToString());
                    }
                    else
                    {
                        C2 = cc2;
                    }  
                    
                    if (prisManoul.corner9 > 0)
                    {
                        E1 = double.Parse(prisManoul.corner9.ToString());
                    }
                    else
                    {
                        E1 = ee1;
                    } 
                    
                    if (prisManoul.corner10 > 0)
                    {
                        E2 = double.Parse(prisManoul.corner10.ToString());
                    }
                    else
                    {
                        E2 = ee2;
                    }

                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString());
                    }
                    else
                    {
                        Bends = bBends;
                    }


                }
                else
                {
                    A1 = aa1;
                    A2 = aa2;
                    B1 = bb1;
                    B2 = bb2;
                    F1 = ff1;
                    F1B = fF1B;
                    D1 = dd1;
                    C1 = cc1;
                    C2 = cc2;
                    E1 = ee1;
                    E2 = ee2;
                    Bends = bBends;
                  
                }

           
                K15 = kk15;
                MagneticSet(Row[0]["MG"].ToString());
            }
            else
            {
                A1 = 0;// 30;
                A2 = 0;// 30;
                B1 = 0;// 12.5;
                B2 = 0;// 12.5;
                F1 = 0;// 53;
                F1B = 0;// 28;
                D1 = 0;// 16;
                C1 = 0;// 12.5;
                C2 = 0;// 12.5;
                E1 = 0;// 12.5;
                E2 = 0;// 12.5;
                Bends = 0;// 22;
                K15 = 0;// 4;
            }
           
        }
        public void RegularHalbasha()
        {
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID = 8"); // 8- office
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) && double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
                double.TryParse(Row[0]["B1"].ToString(), out double bb1) &&
                 double.TryParse(Row[0]["Bends"].ToString(), out double bBends) && double.TryParse(Row[0]["F1"].ToString(), out double ff1) &&
                 double.TryParse(Row[0]["F1B"].ToString(), out double fF1B) && double.TryParse(Row[0]["E1"].ToString(), out double ee1) &&
                 double.TryParse(Row[0]["K125"].ToString(), out double kk125) && double.TryParse(Row[0]["K15"].ToString(), out double kk15)

                 )
            {

                if (prisManoul != null)
                {
                    if (prisManoul.corner1 > 0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString());
                    }
                    else
                    {
                        A1 = aa1;
                    }   
                    
                    if (prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString());
                    }
                    else
                    {
                        A2 = aa2;
                    }     
                    
                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString());
                    }
                    else
                    {
                        B1 = bb1;
                    }
          

                    if (prisManoul.corner9 > 0)
                    {
                        E1 = double.Parse(prisManoul.corner9.ToString());
                    }
                    else
                    {
                       E1 = ee1;
                    }   
                    
                    if (prisManoul.corner11 > 0)
                    {
                        F1 = double.Parse(prisManoul.corner11.ToString());
                    }
                    else
                    {
                        F1 = ff1;
                    } 
                    
                    if (prisManoul.corner16 > 0)
                    {
                        F1B = double.Parse(prisManoul.corner16.ToString());
                    }
                    else
                    {
                        F1B = fF1B;
                    }
                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString());
                    }
                    else
                    {
                        Bends = bBends;
                    }  
                    
                    if (prisManoul.magnet > 0)
                    {
                        MG = double.Parse(prisManoul.magnet.ToString());
                    }
                    else
                    {
                        MagneticSet(Row[0]["MG"].ToString());
                    }
                }
                else
                {
                    A1 = aa1;// 30;
                    A2 = aa2;// 16;
                    B1 = bb1;// 12;
                                             
                    E1 = ee1;// 12;
                    F1 = ff1;// 53;
                    F1B = fF1B;// 28;
                    Bends = bBends;

                    K125 = kk125;
                    K15 = kk15;
                    MagneticSet(Row[0]["MG"].ToString());

                }

              
            }
            else
            {
                A1 = 0;// 30;
                A2 = 0;// 16;
                B1 = 0;// 12;
                C1 = 0;// 12;
                E1 = 0;// 12;
                F1 = 0;// 53;
                F1B = 0;// 28;
                Bends = 0;// 10;

                K125 = 0;
                K15 = 0;
            }


   

            //"txtA1_corner1" 
            //"txtA2_corner2" 
            //"txtB1_corner3" 
            //"txtB2_corner4" 
            //"txtC1_corner5" 
            //"txtC2_corner6" 
            //"txtD1_corner7" 
            //"txtD2_corner8" 
            //"txtE1_corner9" 
            //"txtE2_corner10"
            //"txtF1_corner11"
            //"txtF2_corner12"
            //"txtG1_corner13"
            //"txtG2_corner14"
            //txtF1A_corner15
            // txtF1B_corner16
        }
        public void RegularArusi()
        {
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID = 9"); // 9- office
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) &&
                double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
              double.TryParse(Row[0]["B1"].ToString(), out double bb1) &&
              double.TryParse(Row[0]["B2"].ToString(), out double bb2) &&             
              double.TryParse(Row[0]["C1"].ToString(), out double cc1) &&             
              double.TryParse(Row[0]["C2"].ToString(), out double cc2) &&             
               double.TryParse(Row[0]["F1"].ToString(), out double ff1) &&
               double.TryParse(Row[0]["F1B"].ToString(), out double fF1B) && 
               double.TryParse(Row[0]["K15"].ToString(), out double kk15) && 
               double.TryParse(Row[0]["Bends"].ToString(), out double bBends) 


               

               )
            {

                if (prisManoul != null)
                {
                    if (prisManoul.corner1 > 0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString());
                    }
                    else
                    {
                        A1 = aa1;
                    } 
                    
                    if (prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString());
                    }
                    else
                    {
                        A2 = aa2;
                    }
                        
                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString());
                    }
                    else
                    {
                        B1 = bb1;
                    }
                           
                    if (prisManoul.corner4 > 0)
                    {
                        B2 = double.Parse(prisManoul.corner4.ToString());
                    }
                    else
                    {
                        B2 = bb2;
                    } 
                    
                    if (prisManoul.corner5 > 0)
                    {
                        C1 = double.Parse(prisManoul.corner5.ToString());
                    }
                    else
                    {
                        C1 = cc1;
                    }
                         
                    if (prisManoul.corner6 > 0)
                    {
                        C2 = double.Parse(prisManoul.corner6.ToString());
                    }
                    else
                    {
                        C2 = cc2;
                    }
                              
                    if (prisManoul.corner11 > 0)
                    {
                        F1 = double.Parse(prisManoul.corner11.ToString());
                    }
                    else
                    {
                        F1 = ff1;
                    }
                                
                    if (prisManoul.corner16 > 0)
                    {
                        F1B = double.Parse(prisManoul.corner16.ToString());
                    }
                    else
                    {
                        F1B = fF1B;
                    }
                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString());
                    }
                    else
                    {
                        Bends = bBends;
                    }     
                    
                    if (prisManoul.magnet > 0)
                    {
                        MG = double.Parse(prisManoul.magnet.ToString());
                    }
                    else
                    {
                        MagneticSet(Row[0]["MG"].ToString());
                    }


                }
                else
                {
                    A1 = aa1;// 30;
                    A2 = aa2;// 45;
                    B1 = bb1;// 15;
                    B2 = bb2;// 15;
                    C1 = cc1;// 15;
                    C2 = cc2;// 15;
                    F1 = ff1;// 53;
                    F1B = fF1B;// 28;
                    Bends = bBends;
                    MagneticSet(Row[0]["MG"].ToString());
                }

             
                K15 = kk15;// 1;
             

            }
            else
            {
                A1 = 0;// 30;
                A2 = 0;// 45;
                B1 = 0;// 15;
                B2 = 0;// 15;
                C1 = 0;// 15;
                C2 = 0;// 15;
                F1 = 0;// 53;
                F1B = 0;// 28;
                Bends = 0;// 14;
                K15 = 0;// 1;
            }
         
        }
        public void Sliding()
        {
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID = 10"); // 10- office
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) &&
    double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
  double.TryParse(Row[0]["B1"].ToString(), out double bb1) &&
  double.TryParse(Row[0]["B2"].ToString(), out double bb2) &&
   double.TryParse(Row[0]["Bends"].ToString(), out double bBends)




   )
            {

                if (prisManoul != null)
                {
                    if (prisManoul.corner1 > 0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString());
                    }
                    else
                    {
                        A1 = aa1;
                    }  
                    
                    if (prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString());
                    }
                    else
                    {
                        A2 = aa2;
                    }   
                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString());
                    }
                    else
                    {
                        B1 = bb1;
                    }  
                    if (prisManoul.corner4 > 0)
                    {
                        B2 = double.Parse(prisManoul.corner4.ToString());
                    }
                    else
                    {
                        B2 = bb2;
                    }
                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString());
                    }
                    else
                    {
                        Bends = bBends;
                    }

                }
                else
                {
                    A1 = 0;// 45;
                    A2 = 0;// 45;
                    B1 = 0;// 15;
                    B2 = 0;// 15;
                    Bends = bBends;

                }

          

                MagneticSet(Row[0]["MG"].ToString());
            }
            else
            {
                A1 = 0;// 45;
                A2 = 0;// 45;
                B1 = 0;// 15;
                B2 = 0;// 15;
                Bends = 0;// 8;
            }
  
        }
        public void RegularClick()
        {
            defultvalue();
            Row = clsGlobal.DefultFrameLocal.Select("ID = 11"); //11- office
            if (double.TryParse(Row[0]["A1"].ToString(), out double aa1) &&
               double.TryParse(Row[0]["A2"].ToString(), out double aa2) &&
             double.TryParse(Row[0]["B1"].ToString(), out double bb1) &&
             double.TryParse(Row[0]["B2"].ToString(), out double bb2) &&
             double.TryParse(Row[0]["C1"].ToString(), out double cc1) &&
             double.TryParse(Row[0]["C2"].ToString(), out double cc2) &&
              double.TryParse(Row[0]["F1"].ToString(), out double ff1) &&
              double.TryParse(Row[0]["F1B"].ToString(), out double fF1B) &&
              double.TryParse(Row[0]["F1A"].ToString(), out double fF1A) &&
               double.TryParse(Row[0]["K125"].ToString(), out double kk125) &&
              double.TryParse(Row[0]["Bends"].ToString(), out double bBends)





              )
            {

                if (prisManoul != null)
                {
                    if (prisManoul.corner1 > 0)
                    {
                        A1 = double.Parse(prisManoul.corner1.ToString());
                    }
                    else
                    {
                        A1 = aa1;
                    }

                    if (prisManoul.corner2 > 0)
                    {
                        A2 = double.Parse(prisManoul.corner2.ToString());
                    }
                    else
                    {
                        A2 = aa2;
                    }

                    if (prisManoul.corner3 > 0)
                    {
                        B1 = double.Parse(prisManoul.corner3.ToString());
                    }
                    else
                    {
                        B1 = bb1;
                    }

                    if (prisManoul.corner4 > 0)
                    {
                        B2 = double.Parse(prisManoul.corner4.ToString());
                    }
                    else
                    {
                        B2 = bb2;
                    }

                    if (prisManoul.corner5 > 0)
                    {
                        C1 = double.Parse(prisManoul.corner5.ToString());
                    }
                    else
                    {
                        C1 = cc1;
                    }

                    if (prisManoul.corner6 > 0)
                    {
                        C2 = double.Parse(prisManoul.corner6.ToString());
                    }
                    else
                    {
                        C2 = cc2;
                    }

                    if (prisManoul.corner11 > 0)
                    {
                        F1 = double.Parse(prisManoul.corner11.ToString());
                    }
                    else
                    {
                        F1 = ff1;
                    }

                    if (prisManoul.corner16 > 0)
                    {
                        F1B = double.Parse(prisManoul.corner16.ToString());
                    }
                    else
                    {
                        F1B = fF1B;
                    }
                    
                    if (prisManoul.corner15 > 0)
                    {
                        F1A = double.Parse(prisManoul.corner15.ToString());
                    }
                    else
                    {
                        F1A = fF1B;
                    }

                    if (prisManoul.corner17 > 0)
                    {
                        Bends = double.Parse(prisManoul.corner17.ToString());
                    }
                    else
                    {
                        Bends = bBends;
                    }   
                    
                    if (prisManoul.magnet > 0)
                    {
                        MG = double.Parse(prisManoul.magnet.ToString());
                    }
                    else
                    {
                        MagneticSet(Row[0]["MG"].ToString());
                    }

                }
                else
                {

                    A1 = aa1;// 40;
                    A2 = aa2;// 55;
                    B1 = bb1;// 13;
                    B2 = bb2;// 13;
                    C1 = cc1;// 13.5;
                    C2 = cc2;// 13.5;
                    F1 = ff1;// 50;
                    F1A = fF1A;// 53;
                    F1B = fF1B;// 28;
                    K125 = kk125; 
                    Bends = bBends;
                    MagneticSet(Row[0]["MG"].ToString());

                }


         
            

            }
            else
            {
                A1 = 0;// 40;
                A2 = 0;// 55;
                B1 = 0;// 13;
                B2 = 0;// 13;
                C1 = 0;// 13.5;
                C2 = 0;// 13.5;
                F1 = 0;// 50;
                F1A = 0;// 53;
                F1B = 0;// 28;
                K125 = 0;
                Bends = 0;// 14;
              
            }

         

        }
    }
}
