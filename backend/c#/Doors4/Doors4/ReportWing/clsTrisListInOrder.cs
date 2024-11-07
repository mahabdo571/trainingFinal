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
    public class clsTrisListInOrder
    {
        DataTable DT;

        int _OrderId;
        clsOrders _order;
        clsWings _wing;
        clsWingWindows _windo;
        clsCustomers _customer;
        clsParmeterTrisStikrs _parmeter;

        public clsTrisListInOrder(DataTable dt, int OrderID)
        {
            this.DT = dt;
            this._OrderId = OrderID;
            _order = clsOrders.Find(_OrderId);
            _customer = clsCustomers.Find(clsProjects.Find(_order.ProjectID).iDcustomer);
            _parmeter = new clsParmeterTrisStikrs();



        }

        

        void GetAllDoorWithTris()
        {
            _parmeter.CustomerName = _customer.CompanyName;
            _parmeter.OrderNo = _order.OrderNumber.ToString();
            _parmeter.ItemName = Application.Current.FindResource("Lang_Tris").ToString();
            int i = 0;
            bool x = false, y = false, z = false;

            foreach (DataRow row in DT.Rows)
            {
                _windo = clsWingWindows.FindByWingID((int)row["ID"]);

                if (_windo != null && _windo.TrisType == "Wood")
                {
                    i++;
                    if (i == 1)
                    {
                        _parmeter.Amount1 = row["tbAmount"].ToString();
                        _parmeter.Type1 = TrisType(_windo.TrisType);
                        _parmeter.Hight1 = _windo.TrisHeight.ToString();
                        _parmeter.Width1 = _windo.TrisWidth.ToString();

                        _parmeter.Amount2 ="";
                        _parmeter.Type2 = "";
                        _parmeter.Hight2 = "";
                        _parmeter.Width2 = "";

                        _parmeter.Amount3  = "";
                        _parmeter.Type3 = "";
                        _parmeter.Hight3 = "";
                        _parmeter.Width3 = "";


                        x = true;
                        y = false;
                        z = false;

                    }
                    else if (i == 2)
                    {

                        _parmeter.Amount2 = row["tbAmount"].ToString();
                        _parmeter.Type2 = TrisType(_windo.TrisType);
                        _parmeter.Hight2 = _windo.TrisHeight.ToString();
                        _parmeter.Width2 = _windo.TrisWidth.ToString();
              

                        _parmeter.Amount3 = "";
                        _parmeter.Type3 = "";
                        _parmeter.Hight3 = "";
                        _parmeter.Width3 = "";
                        x = true;
                        y = true;
                        z = false;
                    }
                    else if (i == 3)
                    {
                        _parmeter.Amount3 = row["tbAmount"].ToString();
                        _parmeter.Type3 = TrisType(_windo.TrisType);
                        _parmeter.Hight3 = _windo.TrisHeight.ToString();
                        _parmeter.Width3 = _windo.TrisWidth.ToString();


                        x = true;
                        y = true;
                        z = true;

                        _print();
                        i = 0;

                    }




                }
            }

            if (x && !y && !z)
            {
                _print();
            }else if (x && y && !z)
            {
                _print();
            }


        } 
        
        void GetAllDoorWithWindo()
        {
            _parmeter.CustomerName = _customer.CompanyName;
            _parmeter.OrderNo = _order.OrderNumber.ToString();
            _parmeter.ItemName = Application.Current.FindResource("Lang_Windos").ToString();  
            int i = 0;
            bool x = false, y = false, z = false;

            foreach (DataRow row in DT.Rows)
            {
                _windo = clsWingWindows.FindByWingID((int)row["ID"]);

                if (_windo != null && _windo.WindowType == "Normal" )
                {
                    i++;
                    if (i == 1)
                    {
                        _parmeter.Amount1 = row["tbAmount"].ToString();
                        _parmeter.Type1  = GlassType(_windo.GlassType);
                        _parmeter.Hight1 = _windo.WindowHeight.ToString();
                        _parmeter.Width1 = _windo.WindowWidth.ToString();

                        _parmeter.Amount2 ="";
                        _parmeter.Type2 = "";
                        _parmeter.Hight2 = "";
                        _parmeter.Width2 = "";

                        _parmeter.Amount3  = "";
                        _parmeter.Type3 = "";
                        _parmeter.Hight3 = "";
                        _parmeter.Width3 = "";


                        x = true;
                        y = false;
                        z = false;

                    }
                    else if (i == 2)
                    {

                        _parmeter.Amount2 = row["tbAmount"].ToString();
                        _parmeter.Type2  = GlassType(_windo.GlassType);
                        _parmeter.Hight2 = _windo.WindowHeight.ToString();
                        _parmeter.Width2 = _windo.WindowWidth.ToString();


                        _parmeter.Amount3 = "";
                        _parmeter.Type3 = "";
                        _parmeter.Hight3 = "";
                        _parmeter.Width3 = "";
                        x = true;
                        y = true;
                        z = false;
                    }
                    else if (i == 3)
                    {
                        _parmeter.Amount3 = row["tbAmount"].ToString();
                        _parmeter.Type3 = GlassType(_windo.GlassType);
                        _parmeter.Hight3 =_windo.WindowHeight.ToString();
                        _parmeter.Width3 = _windo.WindowWidth.ToString();


                        x = true;
                        y = true;
                        z = true;

                        _print();
                        i = 0;

                    }




                }
            }

            if (x && !y && !z)
            {
                _print();
            }else if (x && y && !z)
            {
                _print();
            }


        }


        string GlassType(string txt)
        {
            switch (txt)
            {
                case "Clear":
                    return Application.Current.FindResource("langbtnGlassTypeClear").ToString();

                case "Milky":
                    return Application.Current.FindResource("langbtnGlassTypeMilky").ToString();
            }

            return "";
        }  
        
        string TrisType(string txt)
        {
            switch (txt)
            {
                case "Wood":
                    return Application.Current.FindResource("langbtnTrisTypeWood").ToString();

                case "Alminuom":
                    return Application.Current.FindResource("langbtnTrisTypeAlminuom").ToString(); 
                
                case "Slots":
                    return Application.Current.FindResource("langbtnTrisTypeSlots").ToString();
            }

            return "";
        }


        void _print()
        {
            _parmeter.Amount = (clsValidationData.TextToInt(_parmeter.Amount3) + clsValidationData.TextToInt(_parmeter.Amount2) + clsValidationData.TextToInt(_parmeter.Amount1)).ToString();

            clsTrisStikrsAndParmiter setPara = new clsTrisStikrsAndParmiter(_parmeter);

            CrpStickerWindowTris report = setPara.returnReport();

            report.PrintOptions.PrinterName = clsSettings.GetData().StikersPrinterName;//"Microsoft Print to PDF";//change name from setting
            report.PrintToPrinter(1, false, 0, 0);
        }

        public void PrintTris()
        {


            GetAllDoorWithTris();
         


        } 
        
        public void PrintWindo()
        {


     
            GetAllDoorWithWindo();


        }  
        
        public void Print()
        {


            GetAllDoorWithTris();
            GetAllDoorWithWindo();


        }

    }
}
