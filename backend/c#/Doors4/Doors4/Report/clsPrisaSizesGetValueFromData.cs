using Doors4.clsGenral;
using Doors4.ReportWing;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace Doors4.Report
{

    public class tempH
    {
               public string  RPT2 {get;}
               public string  RPM2 {get;}
               public string  RPA2 {get;}
               public string  RPS2 {get;}
               public string RPR2 { get; set; }

        public tempH(string rPT2, string rPM2, string rPA2, string rPS2, string rPR2)
        {
            RPT2 = rPT2;
            RPM2 = rPM2;
            RPA2 = rPA2;
            RPS2 = rPS2;
            RPR2 = rPR2;
        }
    }
    public class clsPrisaSizesGetValueFromData
    {
        int _OrderID;
        clsParameterStickerPrisaFrame _parmeter;
        clsOrders _order;
        clsCustomers _customer;
        int RIGHT ;
        int LEFT ;
        List<tempH> tempListH;
        public clsPrisaSizesGetValueFromData(int OrderID)
        {
            _OrderID = OrderID;
            _order = clsOrders.Find(_OrderID);
            if (_order != null)
            {
                _customer = clsCustomers.Find(clsProjects.Find(_order.ProjectID).iDcustomer);
            }
            _parmeter = new clsParameterStickerPrisaFrame();
            RIGHT = 0;
            LEFT = 0;
            _Basicinfo();

        }
        void _Basicinfo()
        {
 
            if (_customer == null || _order == null) return;

            _parmeter.CustomerName = _customer.CompanyName;
            _parmeter.OrderNo = _order != null ? _order.OrderNumber.ToString() : "";



        }

        void AmountLR(string typeframe)
        {
            var dtRL = clsPrisaSize.GetAmountRLPrisaSizes(_OrderID, typeframe);
            DataRowCollection AmountRL ;
            if (dtRL == null) return;


            AmountRL = dtRL.Rows;
            
            if (AmountRL != null && AmountRL[0]["Direction"].ToString() == "RIGHT")
            {
                RIGHT = (int)AmountRL[0]["Amount"];
                try
                {
                    LEFT = (int)AmountRL[1]["Amount"];
                }
                catch
                {
                    LEFT = 0;
                }
            }
            else
            {
                try
                {
                    RIGHT = (int)AmountRL[1]["Amount"];
                }
                catch
                {
                    RIGHT = 0;
                }
                LEFT = (int)AmountRL[0]["Amount"]; 
            }



        }

        

        void FillParameterToReport(string typeframe)
        {

            DataTable dtW = clsPrisaSize.GruopPrisaSizesWidth(_OrderID, typeframe);

            DataTable dtH = clsPrisaSize.GruopPrisaSizesHeight(_OrderID, typeframe);
       

            if (dtH == null || dtW == null) return;

            AmountLR(typeframe);

            _parmeter.tName = typeframe;
            _parmeter.RAmount = RIGHT.ToString();
            _parmeter.LAmount = LEFT.ToString();

            Heighttable(dtH);
            widthtable(dtW);
            _print();

        }


        void Heighttable(DataTable dtH)
        {

            int i = 0;

            bool line1 = false, line2 = false, line3 = false, line4 = false,
             line1w = false, line2w = false, line3w = false, line4w = false;



            foreach (DataRow row in dtH.Rows)
            {
                i++;
                if(i > 4)
                {
                    tempListH.Add(new tempH("netsav", row["MaterialType"].ToString() + " " + row["IronThickness"].ToString(), ((int)row["Amount"] * 2).ToString(), row["Height"].ToString(), row["PRT1"].ToString()));
                } 

                if (i == 1)
                {

                    _parmeter.RPT1 = "netsav";
                    _parmeter.RPM1 = row["MaterialType"].ToString() + " " + row["IronThickness"].ToString();
                    _parmeter.RPA1 = ((int)row["Amount"] * 2).ToString();
                    _parmeter.RPS1 = row["Height"].ToString();
                    _parmeter.RPR1 = row["PRT1"].ToString();



                    _parmeter.RPT2 = "";
                    _parmeter.RPM2 = "";
                    _parmeter.RPA2 = "";
                    _parmeter.RPS2 = "";
                    _parmeter.RPR2 = "";

                    _parmeter.RPT3 = "";
                    _parmeter.RPM3 = "";
                    _parmeter.RPA3 = "";
                    _parmeter.RPS3 = "";
                    _parmeter.RPR3 = "";

                    _parmeter.RPT4 = "";
                    _parmeter.RPM4 = "";
                    _parmeter.RPA4 = "";
                    _parmeter.RPS4 = "";
                    _parmeter.RPR4 = "";

                }
                else if (i == 2)
                {
                    // netsv line 1
                    _parmeter.RPT2 = "netsav";
                    _parmeter.RPM2 = row["MaterialType"].ToString() + " " + row["IronThickness"].ToString();
                    _parmeter.RPA2 = ((int)row["Amount"] * 2).ToString();
                    _parmeter.RPS2 = row["Height"].ToString();
                    _parmeter.RPR2 = row["PRT1"].ToString();


                    _parmeter.RPT3 = "";
                    _parmeter.RPM3 = "";
                    _parmeter.RPA3 = "";
                    _parmeter.RPS3 = "";
                    _parmeter.RPR3 = "";

                    _parmeter.RPT4 = "";
                    _parmeter.RPM4 = "";
                    _parmeter.RPA4 = "";
                    _parmeter.RPS4 = "";
                    _parmeter.RPR4 = "";


                }
                else if (i == 3)
                {
                    // netsv line 1
                    _parmeter.RPT3 = "netsav";
                    _parmeter.RPM3 = row["MaterialType"].ToString() + " " + row["IronThickness"].ToString();
                    _parmeter.RPA3 = ((int)row["Amount"] * 2).ToString();
                    _parmeter.RPS3 = row["Height"].ToString();
                    _parmeter.RPR3 = row["PRT1"].ToString();



                    _parmeter.RPT4 = "";
                    _parmeter.RPM4 = "";
                    _parmeter.RPA4 = "";
                    _parmeter.RPS4 = "";
                    _parmeter.RPR4 = "";


                }
                else if (i == 4)
                {
                    // netsv line 1
                    _parmeter.RPT4 = "netsav";
                    _parmeter.RPM4 = row["MaterialType"].ToString() + " " + row["IronThickness"].ToString();
                    _parmeter.RPA4 = ((int)row["Amount"] * 2).ToString();
                    _parmeter.RPS4 = row["Height"].ToString();
                    _parmeter.RPR4 = row["PRT1"].ToString();



                   // i = 0;



                    _parmeter.RAmount = "";
                    _parmeter.LAmount = "";





                }

            }
        }
        void widthtable(DataTable dtW)
        {
           
            int ii = 0;

            foreach (DataRow rowW in dtW.Rows)

            {


                ii++;
                if (ii == 1)
                {


                    _parmeter.LPT1 = "head";
                    _parmeter.LPM1 = rowW["MaterialType"].ToString() + " " + rowW["IronThickness"].ToString();
                    _parmeter.LPA1 = rowW["Amount"].ToString();
                    _parmeter.LPS1 = rowW["Width"].ToString();
                    _parmeter.LPR1 = rowW["PRT2"].ToString();

                    _parmeter.LPT2 = "";
                    _parmeter.LPM2 = "";
                    _parmeter.LPA2 = "";
                    _parmeter.LPS2 = "";
                    _parmeter.LPR2 = "";

                    _parmeter.LPT3 = "";
                    _parmeter.LPM3 = "";
                    _parmeter.LPA3 = "";
                    _parmeter.LPS3 = "";
                    _parmeter.LPR3 = "";

                    _parmeter.LPT4 = "";
                    _parmeter.LPM4 = "";
                    _parmeter.LPA4 = "";
                    _parmeter.LPS4 = "";
                    _parmeter.LPR4 = "";



                }
                else if (ii == 2)
                {

                    _parmeter.LPT2 = "head";
                    _parmeter.LPM2 = rowW["MaterialType"].ToString() + " " + rowW["IronThickness"].ToString();
                    _parmeter.LPA2 = rowW["Amount"].ToString();
                    _parmeter.LPS2 = rowW["Width"].ToString();
                    _parmeter.LPR2 = rowW["PRT2"].ToString();



                    _parmeter.LPT3 = "";
                    _parmeter.LPM3 = "";
                    _parmeter.LPA3 = "";
                    _parmeter.LPS3 = "";
                    _parmeter.LPR3 = "";

                    _parmeter.LPT4 = "";
                    _parmeter.LPM4 = "";
                    _parmeter.LPA4 = "";
                    _parmeter.LPS4 = "";
                    _parmeter.LPR4 = "";

                }
                else if (ii == 3)
                {


                    _parmeter.LPT3 = "head";
                    _parmeter.LPM3 = rowW["MaterialType"].ToString() + " " + rowW["IronThickness"].ToString();
                    _parmeter.LPA3 = rowW["Amount"].ToString();
                    _parmeter.LPS3 = rowW["Width"].ToString();
                    _parmeter.LPR3 = rowW["PRT2"].ToString();


                    _parmeter.LPT4 = "";
                    _parmeter.LPM4 = "";
                    _parmeter.LPA4 = "";
                    _parmeter.LPS4 = "";
                    _parmeter.LPR4 = "";


                }
                else if (ii == 4)
                {

                    _parmeter.LPT4 = "head";
                    _parmeter.LPM4 = rowW["MaterialType"].ToString() + " " + rowW["IronThickness"].ToString();
                    _parmeter.LPA4 = rowW["Amount"].ToString();
                    _parmeter.LPS4 = rowW["Width"].ToString();
                    _parmeter.LPR4 = rowW["PRT2"].ToString();

                    ii = 0;


                    _parmeter.RAmount = "";
                    _parmeter.LAmount = "";




                }

            }
        }

        public void Print()
        {

  
            foreach (string name in clsUtil.TypeNameFrame())
            {
                  FillParameterToReport(name);

            
              
            }
        }


        void _print()
        {
            _parmeter.IDF = this._OrderID;
          

            clsSetParameterStickerPrisaFrame setPara = new clsSetParameterStickerPrisaFrame(_parmeter);

            CrpStickerPrisaFrame report = setPara.returnReport();

           
            report.PrintOptions.PrinterName = "Microsoft Print to PDF";// clsSettings.GetData().StikersPrinterName;//"Microsoft Print to PDF";//change name from setting
            try
            {
                report.PrintToPrinter(1, false, 0, 0);
                report.Refresh();         
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Busy Now!   Please Try Again. \n" + ex.Message);

            }
        }

    }
}
