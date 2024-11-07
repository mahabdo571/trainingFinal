using Doors4.Report;
using Doors4.Wing;
using SharaLogic;
using SharaLogic.WingCalc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Doors4.ReportWing
{
    public class clsListOrderWing
    {
        DataSet ds ;
        DataTable DT ;
        DataTable DTMod ;
        int _orderid;
        clsOrders _order;
        clsWings _wing;
        clsWingType WingType;
        clsCustomers _costoumer;
        clsTrisListInOrder _TrisWindoPrint;
        clsPackingWingToStikrs _PackingWingToStikrs;
        public clsListOrderWing(DataTable dt,int orderid)
        {
            ds = new DataSet();
            this.DT = dt;
            _orderid = orderid;
            _order = clsOrders.Find(orderid);
            _TrisWindoPrint = new clsTrisListInOrder(DT, _orderid);
            _PackingWingToStikrs = new clsPackingWingToStikrs(_orderid);
            _costoumer = clsCustomers.Find(clsProjects.Find(_order.ProjectID).iDcustomer);
           
            try
            {

                ds.Tables.Add(changeDatainDataTable());

              //  ds.WriteXmlSchema(@"C:\Users\All Users\sharabanyDoors\ListAllWing.xml");

            }
            catch
            {
                
            }


        }

        DataTable changeDatainDataTable()
        {
            DTMod = new DataTable();

            DTMod.Columns.Add("DoorNumber", typeof(string));
            DTMod.Columns.Add("OdrerId", typeof(int));
            DTMod.Columns.Add("DoorType", typeof(string));
            DTMod.Columns.Add("WingDD", typeof(string));
            DTMod.Columns.Add("HeightFinal", typeof(int));
            DTMod.Columns.Add("WidthFinal", typeof(int));
            DTMod.Columns.Add("tbAmount", typeof(int));
            DTMod.Columns.Add("ColorDoor", typeof(string));
            DTMod.Columns.Add("UpdateDate", typeof(DateTime));

          


            foreach (DataRow row in DT.Rows)
            {

                WingType =  clsWingType.FindByWingID((int)row["ID"]);
                _wing = clsWings.Find((int)row["ID"]);
                WingItemsDefult itemdef = new WingItemsDefult((int)row["ID"]);
                if (WingType != null && itemdef != null)
                {
                    if (WingType.TEST2 != "A")
                    {
                        if (_wing != null && _wing.DoubleDoor && _wing.DDAK == "A" && (WingType.TEST3 == "3" || WingType.TEST3 == "4"))
                        {
                            DTMod.Rows.Add(row["DoorNumber"], orederNumber((int)row["OdrerId"]), clsCalcNameType.getName(WingType.TEST1, WingType.TEST2, WingType.TEST3, WingType.TEST4)
                  , ddTypeName((bool)row["DoubleDoor"], row["DDAK"].ToString()), itemdef.MetalHight, itemdef.MetalWidth2, AmountCheck((int)row["tbAmount"]), getColorName(row["ColorDoor"] as string), row["UpdateDate"]
                   );         
                            
                            DTMod.Rows.Add(row["DoorNumber"], orederNumber((int)row["OdrerId"]), clsCalcNameType.getName(WingType.TEST1, WingType.TEST2, WingType.TEST3, WingType.TEST4)
                  , ddTypeName((bool)row["DoubleDoor"], row["DDAK"].ToString()), itemdef.MetalHight, itemdef.MetalWidth, AmountCheck((int)row["tbAmount"]), getColorName(row["ColorDoor"] as string), row["UpdateDate"]
                   );
                        }
                        else
                        {
                            DTMod.Rows.Add(row["DoorNumber"], orederNumber((int)row["OdrerId"]), clsCalcNameType.getName(WingType.TEST1, WingType.TEST2, WingType.TEST3, WingType.TEST4)
                           , ddTypeName((bool)row["DoubleDoor"], row["DDAK"].ToString()), itemdef.MetalHight, itemdef.MetalWidth, AmountCheck((int)row["tbAmount"]), getColorName(row["ColorDoor"] as string), row["UpdateDate"]
                            );
                        }
                    }
                }
  
            }
            return DTMod;
        }

        int AmountCheck(int amount)
        {
            if(_wing !=null &&_wing.DoubleDoor && _wing.DDAK=="A" &&( WingType.TEST3=="3" || WingType.TEST3 == "4"))
            {
                return amount;
            }
            else
            {
                return amount * 2;
            }
        }

        string getColorName(string id)
        {
            if (int.TryParse(id, out int res))
            {
                clsFormicaColor color = clsFormicaColor.Find(res);
                if (color != null)
                {
                    return color.ColorName;
                }
            }
            return "";
        
        }
        string ddTypeName(bool statu,string AK)
        {
            string ddType;
            if (statu)
            {
                if (AK == "A")
                {
                    ddType = "נפתחת";
                }
                else
                {
                    ddType = "קבועה";
                }
            }
            else
            {
                ddType = "";
            }

            return ddType;
        }

        int orederNumber(int id)
        {

            return clsOrders.Find(id) != null ? clsOrders.Find(id).OrderNumber: 0;


        }

        void printStikrs()
        {




            foreach (DataRow row in DT.Rows)
            {
          

                clsWingType i = clsWingType.FindByWingID((int)row["ID"]);
                if (i != null)
                {
                    if (i.TEST2 == "F")
                    {


                        clsUpdateSetdataAfterCalc ff = new clsUpdateSetdataAfterCalc((int)row["ID"]);

                        if (int.TryParse(row["tbAmount"].ToString(), out int result))
                        {
                         
                
                   clsPrintDirect.PrintWingStikrs(ff.data(), result);
         

                        }


                    }
                }

            }

           
        }

 




        public void Print()
        {

            crAllWingInOrder prreport = new crAllWingInOrder();
          
            prreport.SetDataSource(ds);
            if (_costoumer != null)
            {
             //   prreport.SetParameterValue("WingDD", "DD");
                prreport.SetParameterValue("coustomerName", _costoumer.CompanyName);
            }
            prreport.PrintOptions.PrinterName = clsSettings.GetData().MainPrinterName;//"Microsoft Print to PDF";//change name from setting
            prreport.PrintToPrinter(1, false, 0, 0);


       
            if (this.DT.Select("DoorType LIKE '%ALPH%'").Length > 0)
            {
                AlphaStikrsParameter();
            }

            printStikrs();

            _TrisWindoPrint.Print();//windo and tris stikrs 


        }

        public void PrintStikrsFormaica()
        {
            printStikrs();
        }     
        public void PrintPeperFormaica()
        {
            crAllWingInOrder prreport = new crAllWingInOrder();

            prreport.SetDataSource(ds);
            if (_costoumer != null)
            {
                prreport.SetParameterValue("WingDD", "DD");
                prreport.SetParameterValue("coustomerName", _costoumer.CompanyName);
            }
            prreport.PrintOptions.PrinterName = clsSettings.GetData().MainPrinterName;//"Microsoft Print to PDF";//change name from setting
            prreport.PrintToPrinter(1, false, 0, 0);

        }
        public void PrintColorSide()
        {
            if (this.DT.Select("DoorType LIKE '%ALPH%'").Length > 0)
            {
                AlphaStikrsParameter();
            }
        }
        void AlphaStikrsParameter()
        {
            ParameterAlphaStikrs parmeter = new ParameterAlphaStikrs();
            DataTable colorlist = clsColorSide.getAll();
  

            parmeter.OrderNo = _order.OrderNumber.ToString();
            parmeter.CustomerName = _costoumer.CompanyName.ToString();
            
           
          int amount =   0;
          int amountL =   0;
          int amountR =   0;

        

            foreach (DataRow ite in colorlist.Rows)
            {
                string item = ite["ID"].ToString();


                int i = 0;

                DataRow[] uI = this.DT.Select("DoorType LIKE '%ALPH%' and ColorSide ='" + item.ToString() + "'");

                foreach (var am in uI)
                {
                    i += int.Parse((am["tbAmount"].ToString()));
                }  
                
                

                DataRow[] UserAmount = this.DT.Select("DoorType LIKE '%ALPH%' and ColorSide ='" + item.ToString() + "'");

                foreach (var am in UserAmount)
                {
                    amount += int.Parse((am["tbAmount"].ToString()));
                }
                      
                DataRow[] UseramountL = this.DT.Select("DoorType LIKE '%ALPH%' and Direction = 'Left' and ColorSide ='" + item.ToString() + "'");

                foreach (var am in UseramountL)
                {
                    amountL += int.Parse((am["tbAmount"].ToString()));
                }

                              
                DataRow[] UseramountR = this.DT.Select("DoorType LIKE '%ALPH%' and Direction = 'Right' and ColorSide ='" + item.ToString() + "'");

                foreach (var am in UseramountR)
                {
                    amountR += int.Parse((am["tbAmount"].ToString()));
                }


                //int i = this.DT.Select("DoorType LIKE '%ALPH%' and ColorSide ='" + item.ToString() + "'").Length ;
              
                //amount += this.DT.Select("DoorType LIKE '%ALPH%' and ColorSide ='" + item.ToString() + "'").Length;
                //amountL += this.DT.Select("DoorType LIKE '%ALPH%' and Direction = 'Left' and ColorSide ='" + item.ToString() + "'").Length;
                //amountR += this.DT.Select("DoorType LIKE '%ALPH%' and Direction = 'Right' and ColorSide ='" + item.ToString() + "'").Length;

               

                if (string.IsNullOrEmpty(parmeter.AkphaPoleColor))
                {
                  
                    if (i <= 0)
                    {
                        parmeter.AkphaPoleColor = "";
                    }
                    else
                    {



               

                


                        parmeter.AkphaPoleColor = i.ToString();
                        parmeter.AkphaPoleColor += " : " + ite["ColorName"].ToString();
                        parmeter.Amount = amount.ToString();
                        parmeter.LAmount = amountL.ToString();
                        parmeter.RAmount = amountR.ToString();
                    }

                   
                }
                else if (string.IsNullOrEmpty(parmeter.AkphaPoleColor2))
                {
                    if (i <= 0)
                    {
                        parmeter.AkphaPoleColor2 = "";
                    }
                    else
                    {
                        parmeter.AkphaPoleColor2 = i.ToString();
                        parmeter.AkphaPoleColor2 += " : " + ite["ColorName"].ToString();
                        parmeter.Amount = amount.ToString();
                        parmeter.LAmount = amountL.ToString();
                        parmeter.RAmount = amountR.ToString();
                    }
                     
                }  
                else if (string.IsNullOrEmpty(parmeter.AkphaPoleColor3))
                {
                    if (i <= 0)
                    {
                        parmeter.AkphaPoleColor3 = "";
                    }
                    else
                    {
                        parmeter.AkphaPoleColor3 = i.ToString();
                        parmeter.AkphaPoleColor3 += " : " + ite["ColorName"].ToString();
                        parmeter.Amount = amount.ToString();
                        parmeter.LAmount = amountL.ToString();
                        parmeter.RAmount = amountR.ToString();
                    }
                }   
                else if (string.IsNullOrEmpty(parmeter.AkphaPoleColor4))
                {
                    if (i <= 0)
                    {
                        parmeter.AkphaPoleColor4 = "";
                    }
                    else
                    {
                        parmeter.AkphaPoleColor4 = i.ToString();
                        parmeter.AkphaPoleColor4 += " : " + ite["ColorName"].ToString();
                        parmeter.Amount = amount.ToString();
                        parmeter.LAmount = amountL.ToString();
                        parmeter.RAmount = amountR.ToString();
                    }
                }
                    else if (string.IsNullOrEmpty(parmeter.AkphaPoleColor5))
                {
                    if (i <= 0)
                    {
                        parmeter.AkphaPoleColor5 = "";
                    }
                    else
                    {
                        parmeter.AkphaPoleColor5 = i.ToString();
                        parmeter.AkphaPoleColor5 += " : " + ite["ColorName"].ToString();
                        parmeter.Amount = amount.ToString();
                        parmeter.LAmount = amountL.ToString();
                        parmeter.RAmount = amountR.ToString();
                    }
                }
                       
                else if (string.IsNullOrEmpty(parmeter.AkphaPoleColor6))
                {
                    if (i <= 0)
                    {
                        parmeter.AkphaPoleColor6 = "";
                    }
                    else
                    {
                        parmeter.AkphaPoleColor6 = i.ToString();
                        parmeter.AkphaPoleColor6 += " : " + ite["ColorName"].ToString();
                        parmeter.Amount = amount.ToString();
                        parmeter.LAmount = amountL.ToString();
                        parmeter.RAmount = amountR.ToString();
                        
                        PrintAlphaStikrs(parmeter);
                        amount = 0;
                        amountL = 0;
                        amountR = 0;
                        parmeter.Clear();


                    }
                }


      
            }




           PrintAlphaStikrs(parmeter);
            parmeter.Clear();



        }

        void PrintAlphaStikrs(ParameterAlphaStikrs parmeter)
        {


            clsSetParameterToReportAlphaWing setPara = new clsSetParameterToReportAlphaWing(parmeter);

            CrpStickerAlphaWing report =  setPara.returnReport();

            report.PrintOptions.PrinterName = clsSettings.GetData().StikersPrinterName;//"Microsoft Print to PDF";//change name from setting
            report.PrintToPrinter(1, false, 0, 0);

        }

      public  void PrintTrisList()
        {

            _TrisWindoPrint.PrintTris();
        }  
        public  void PrintWindoList()
        {

            _TrisWindoPrint.PrintWindo();
        }
            
        
        public  void StickerPackingWing()
        {
            _PackingWingToStikrs.Print();


        }

    }
}
