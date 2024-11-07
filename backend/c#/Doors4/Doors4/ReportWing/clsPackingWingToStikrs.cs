using Doors4.clsGenral;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Doors4.ReportWing
{
    public class clsPackingWingToStikrs
    {
        DataTable DT;

        int _OrderId;
        clsOrders _order;
        clsWings _wing;
        clsWingType _TypeWing;
        clsCustomers _customer;
        clsParamCrpStickerPackingWing _parmeter;

        public  clsPackingWingToStikrs( int OrderID)
        {
            
            this._OrderId = OrderID;
            _order = clsOrders.Find(_OrderId);
            _customer = clsCustomers.Find(clsProjects.Find(_order.ProjectID).iDcustomer);
            _parmeter = new clsParamCrpStickerPackingWing();
            this.DT = clsOrders.BakegWing(this._OrderId);
            _Basicinfo();

        }

         void _Basicinfo()
        {
            
           
            _parmeter.CustomerName = _customer.CompanyName;
            _parmeter.OrderNo = _order != null ? _order.OrderNumber.ToString() : "";
            _parmeter.InputDate = _order.DateManual;
            _parmeter.CalculatedDate = _order.DateManual.AddMonths(1);
            _parmeter.TodayDate = DateTime.Now;
            _parmeter.Manager = _order.Marketer;

        }

        class stikinfo
        {
            public string c { get; set; }
            public string th { get; set; }
            public string perAmount { get; set; }

            public stikinfo(string C, string TH, string PerAmount)
            {
                this.c = C;
                this.th = TH;
                this.perAmount = PerAmount;
            }
        }

        string getColorFormika(string id)
        {
            clsFormicaColor colo = clsFormicaColor.Find(clsValidationData.TextToInt(id));
            if (colo != null){

               return colo.ColorName;
            }
            else
            {
                return "";
            }
          
        }  
        
        
        string getColoriron(string id)
        {
            clsColorSide colo = clsColorSide.Find(clsValidationData.TextToInt(id));
            if (colo != null){

               return colo.ColorName;
            }
            else
            {
                return "";
            }
          
        }
        void GetAllFormicaColorDoor()
        {
 

            List<stikinfo> NORF = new List<stikinfo>();
            List<stikinfo> NORA = new List<stikinfo>();
            List<stikinfo> ALPHF = new List<stikinfo>();
            List<stikinfo> ALPHA = new List<stikinfo>();
            List<stikinfo> PVTF = new List<stikinfo>();
            List<stikinfo> PNDLF = new List<stikinfo>();
            List<stikinfo> PNDLA = new List<stikinfo>();
            List<stikinfo> FlashF = new List<stikinfo>();
            List<stikinfo> FlashA = new List<stikinfo>();
            List<stikinfo> AQ60F = new List<stikinfo>();
            List<stikinfo> AQ60A = new List<stikinfo>();
            List<stikinfo> AQ80F = new List<stikinfo>();
            List<stikinfo> AQ80A = new List<stikinfo>();



            foreach (DataRow row in this.DT.Rows)
            {
               
                if ((string)row["TEST1"] == "NOR" && (string)row["TEST2"] == "F" )
                {
                

                    NORF.Add(new stikinfo(getColorFormika((string)row["ColorDoor"]),
                        ((double)row["FormaicaThickness"]).ToString() + "mm", ((int)row["AmountBerColor"]).ToString()));

                  
               
             

                }  
                
                if ((string)row["TEST1"] == "NOR" && (string)row["TEST2"] == "A" )
                {
                

                    NORA.Add(new stikinfo(getColoriron((string)row["ColorDoor"]),
                       "-1", ((int)row["AmountBerColor"]).ToString()));

                  
               
             

                }
                
                if ((string)row["TEST1"] == "ALPH" && (string)row["TEST2"] == "F" )
                {

                  
              
                    ALPHF.Add(new stikinfo(getColorFormika((string)row["ColorDoor"]),
                        ((double)row["FormaicaThickness"]).ToString() + "mm", ((int)row["AmountBerColor"]).ToString()));

                }

                if ((string)row["TEST1"] == "ALPH" && (string)row["TEST2"] == "A")
                {


                    ALPHA.Add(new stikinfo(getColoriron((string)row["ColorDoor"]),
                       "-1", ((int)row["AmountBerColor"]).ToString()));
                }

                if ((string)row["TEST1"] == "PVT" && (string)row["TEST2"] == "F" )
                {



                    PVTF.Add(new stikinfo(getColorFormika((string)row["ColorDoor"]),
                        ((double)row["FormaicaThickness"]).ToString() + "mm", ((int)row["AmountBerColor"]).ToString()));

                }     
                
                if ((string)row["TEST1"] == "PNDL" && (string)row["TEST2"] == "F" )
                {



                    PNDLF.Add(new stikinfo(getColorFormika((string)row["ColorDoor"]),
                        ((double)row["FormaicaThickness"]).ToString() + "mm", ((int)row["AmountBerColor"]).ToString()));

                }

                if ((string)row["TEST1"] == "PNDL" && (string)row["TEST2"] == "A")
                {


                    PNDLA.Add(new stikinfo(getColoriron((string)row["ColorDoor"]),
                       "-1", ((int)row["AmountBerColor"]).ToString()));
                }

                if ((string)row["TEST1"] == "Flash" && (string)row["TEST2"] == "F" )
                {



                    FlashF.Add(new stikinfo(getColorFormika((string)row["ColorDoor"]),
                        ((double)row["FormaicaThickness"]).ToString() + "mm", ((int)row["AmountBerColor"]).ToString()));

                }

                if ((string)row["TEST1"] == "Flash" && (string)row["TEST2"] == "A")
                {


                    FlashA.Add(new stikinfo(getColoriron((string)row["ColorDoor"]),
                       "-1", ((int)row["AmountBerColor"]).ToString()));
                }

                if ((string)row["TEST1"] == "AQ60" && (string)row["TEST2"] == "F" )
                {



                    AQ60F.Add(new stikinfo(getColorFormika((string)row["ColorDoor"]),
                        ((double)row["FormaicaThickness"]).ToString() + "mm", ((int)row["AmountBerColor"]).ToString()));

                }

                if ((string)row["TEST1"] == "AQ60" && (string)row["TEST2"] == "A")
                {


                    AQ60A.Add(new stikinfo(getColoriron((string)row["ColorDoor"]),
                       "-1", ((int)row["AmountBerColor"]).ToString()));
                }


                if ((string)row["TEST1"] == "AQ80" && (string)row["TEST2"] == "F" )
                {



                    AQ80F.Add(new stikinfo(getColorFormika((string)row["ColorDoor"]),
                        ((double)row["FormaicaThickness"]).ToString() +"mm", ((int)row["AmountBerColor"]).ToString()));

                }


                if ((string)row["TEST1"] == "AQ80" && (string)row["TEST2"] == "A")
                {


                    AQ80A.Add(new stikinfo(getColoriron((string)row["ColorDoor"]),
                       "-1", ((int)row["AmountBerColor"]).ToString()));
                }


            }


            FillDataColor(NORF, "NORF");
            FillDataColor(ALPHF, "ALPHF");
            FillDataColor(PVTF, "PVTF");
            FillDataColor(PNDLF, "PNDLF");
            FillDataColor(FlashF, "FlashF");
            FillDataColor(AQ60F, "AQ60F");
            FillDataColor(AQ80F, "AQ80F");
            FillDataColor(NORA, "NORA");
            FillDataColor(ALPHA, "ALPHA");
            FillDataColor(PNDLA, "PNDLA");
            FillDataColor(FlashA, "FlashA");
            FillDataColor(AQ60A, "AQ60A");
            FillDataColor(AQ80A, "AQ80A");

       


        }

        void AmountSum()
        {
            
            _parmeter.Amount = (clsValidationData.TextToInt(_parmeter.SubAmount1) +clsValidationData.TextToInt(_parmeter.SubAmount2) +clsValidationData.TextToInt(_parmeter.SubAmount3) + clsValidationData.TextToInt(_parmeter.SubAmount4) + clsValidationData.TextToInt(_parmeter.SubAmount5)).ToString();
        }
        void _setTypeDoorTStikrs(string typeDoor)
        {
            switch (typeDoor)
            {
                case "NORF":
                    _parmeter.WingType = Application.Current.FindResource("langbtnTest1_Normal").ToString();// "NOR";
                    _parmeter.DoorF = "F";
                    break; 
                
                case "ALPHF":

                    _parmeter.WingType = Application.Current.FindResource("langbtnTest1_Alpha").ToString();//"ALPH";
                    _parmeter.DoorF = "F";
                    break;  
                    
                case "PVTF":

                    _parmeter.WingType = Application.Current.FindResource("langbtnTest1_Pivot").ToString();//"PVT";
                    _parmeter.DoorF = "F";
                    break;  
                
                case "PNDLF":

                    _parmeter.WingType = Application.Current.FindResource("langbtnTest1_Pendl").ToString();//"PNDL";
                    _parmeter.DoorF = "F";
                    break;     
                
                case "FlashF":

                    _parmeter.WingType = Application.Current.FindResource("langbtnTest4_Flash").ToString();//"Flash";
                    _parmeter.DoorF = "F";
                    break;   
                
                case "AQ60F":

                    _parmeter.WingType = Application.Current.FindResource("langrbLevelTypeAQ60").ToString();//"AQ60";
                    _parmeter.DoorF = "F";
                    break;
                
                case "AQ80F":

                    _parmeter.WingType = Application.Current.FindResource("langrbLevelTypeAQ80").ToString();//"AQ80";
                    _parmeter.DoorF = "F";
                    break; 
                
                case "NORA":

                    _parmeter.WingType = Application.Current.FindResource("langbtnTest1_Normal").ToString();// "NOR";
                    _parmeter.DoorF = "A";
                    break;     
                
                case "ALPHA":

                    _parmeter.WingType = Application.Current.FindResource("langbtnTest1_Alpha").ToString();//"ALPH";
                    _parmeter.DoorF = "A";
                    break;   
                
                case "PNDLA":

                    _parmeter.WingType = Application.Current.FindResource("langbtnTest1_Pendl").ToString();// "PNDL";
                    _parmeter.DoorF = "A";
                    break;  
                case "FlashA":

                    _parmeter.WingType = Application.Current.FindResource("langbtnTest4_Flash").ToString();//"Flash";
                    _parmeter.DoorF = "A";
                    break;  
                
                case "AQ60A":

                    _parmeter.WingType = Application.Current.FindResource("langrbLevelTypeAQ60").ToString();//"AQ60";
                    _parmeter.DoorF = "A";
                    break;   
                case "AQ80A":

                    _parmeter.WingType = Application.Current.FindResource("langrbLevelTypeAQ80").ToString();//"AQ80";
                    _parmeter.DoorF = "A";
                    break;
            }
        }

        void FillDataColor(List<stikinfo> rows,string typeDoor)
        {

            if(rows.Count <= 0){
                return;
            }
            _setTypeDoorTStikrs(typeDoor);
            int i = 0 ;
            bool A = false,B=false,C=false,D=false,E=false; 

            foreach (var row in rows)
            {
                i++;

                if (i == 1)
                {

                    _parmeter.c1 = row.c;
                    _parmeter.th1 = row.th;
                    _parmeter.SubAmount1 = row.perAmount;
                    clearDataSt(1);
                   A= true;
                    B = false;
                    C = false;
                    D = false;
                    E = false;

                }
                else if (i == 2)
                {

                    _parmeter.c2 = row.c;
                    _parmeter.th2 = row.th ;
                    _parmeter.SubAmount2 = row.perAmount;
                    clearDataSt(2);
                 A = true;
                    B = true;
                    C = false;
                    D = false;
                    E = false;

                }
                else if (i == 3)
                {

                    _parmeter.c3 = row.c;
                    _parmeter.th3 = row.th ;
                    _parmeter.SubAmount3 = row.perAmount;
                    clearDataSt(3);
                    A = true;
                    B = true;
                    C = true;
                    D = false;
                    E = false;
                }
                else if (i == 4)
                {

                    _parmeter.c4 = row.c;
                    _parmeter.th4 = row.th;
                    _parmeter.SubAmount4 = row.perAmount;
                    clearDataSt(4);
                    A = true;
                    B = true;
                    C = true;
                    D = true;
                    E = false;

                }
                else if (i == 5)
                {
                    _parmeter.c5 = row.c;
                    _parmeter.th5 = row.th;
                    _parmeter.SubAmount5 = row.perAmount;

                  E =  true;
                    i = 0;
                    AmountSum();
                    _print();
                }

            }

            if (A && !B && !C&& !D&& !E)
            {
                AmountSum();
                _print();
            }
            else  if (A && B && !C && !D && !E)
                {
                AmountSum();
                _print();
            } else  if (A && B && C && !D && !E)
                {
                AmountSum();
                _print();
            }
            else  if (A && B && C && D && !E)
                {
                AmountSum();
                _print();
            }


            rows.Clear();

        }

        
        void clearDataSt(int i)
        {
            switch (i)
            {
                case 1:
         
                    _parmeter.c2 = "";
                    _parmeter.th2 = "";
                    _parmeter.SubAmount2 = "";
                    _parmeter.c3 = "";
                    _parmeter.th3 = "";
                    _parmeter.SubAmount3 = "";
                    _parmeter.c4 = "";
                    _parmeter.th4 = "";
                    _parmeter.SubAmount4 = "";
                    _parmeter.c5 = "";
                    _parmeter.th5 = "";
                    _parmeter.SubAmount5 = "";
                    break; 
                case 2:
            
                    _parmeter.c3 = "";
                    _parmeter.th3 = "";
                    _parmeter.SubAmount3 = "";
                    _parmeter.c4 = "";
                    _parmeter.th4 = "";
                    _parmeter.SubAmount4 = "";
                    _parmeter.c5 = "";
                    _parmeter.th5 = "";
                    _parmeter.SubAmount5 = "";
                    break; 
                case 3:
               
                    _parmeter.c4 = "";
                    _parmeter.th4 = "";
                    _parmeter.SubAmount4 = "";
                    _parmeter.c5 = "";
                    _parmeter.th5 = "";
                    _parmeter.SubAmount5 = "";
                    break; 
                case 4:
    
                    _parmeter.c5 = "";
                    _parmeter.th5 = "";
                    _parmeter.SubAmount5 = "";
                    break;
          
            }
   
            
     
        }


        public void Print()
        {
          
            GetAllFormicaColorDoor();
            


        }

        void _print()
        {

            clsCrpStickerPackingWing setPara = new clsCrpStickerPackingWing(_parmeter);

            CrpStickerPackingWing report = setPara.returnReport();

            report.PrintOptions.PrinterName = clsSettings.GetData().StikersPrinterName;//"Microsoft Print to PDF";//change name from setting
            try
            {
                report.PrintToPrinter(1, false, 0, 0);
            }
            catch
            {
                MessageBox.Show("System busy . Pleass try Agen");

            }
        }

    }
}
