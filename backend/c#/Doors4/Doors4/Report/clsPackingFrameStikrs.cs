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

namespace Doors4.Report
{
    public class clsPackingFrameStikrs
    {
        DataTable DT;

        int _OrderId;
        clsOrders _order;
        clsCustomers _customer;
        StickerPackingFrameParameter _parmeter;
        List<SortedDataIncomming> setData;
        List<SortedDataIncomming> setData2;
        public clsPackingFrameStikrs(int OrderID)
        {

            this._OrderId = OrderID;
            _order = clsOrders.Find(_OrderId);
            _customer = clsCustomers.Find(clsProjects.Find(_order.ProjectID).iDcustomer);
            _parmeter = new StickerPackingFrameParameter();
            this.DT = clsOrders.pakegFrameStikrs(this._OrderId);
            _Basicinfo();

        }

        void _Basicinfo()
        {


            _parmeter.CustomerName = _customer.CompanyName;
            _parmeter.OrderNo = _order != null ?_order.OrderNumber.ToString():"";
            _parmeter.InputDate = _order.DateManual;
            _parmeter.CalculatedDate = _order.DateManual.AddMonths(1);
            _parmeter.TodayDate = DateTime.Now;
            _parmeter.Manager = _order.Marketer;

        }

        class SortedDataIncomming
        {
        public string AgroupOfDoorFrames { get; set; }
        public string TypeOfDoorFrame { get; set; }
        public string MaterialType { get; set; }
        public int TotalAmount { get; set; }
        public int AmountLeft { get; set; }
        public int AmountRight { get; set; }
        public double IronThickness { get; set; }

            public SortedDataIncomming(string agroupOfDoorFrames, string materialType, int totalAmount, int amountLeft, int amountRight, double ironThickness,string typeOfDoorFrame)
            {
               this.AgroupOfDoorFrames = agroupOfDoorFrames;
               this.TypeOfDoorFrame = typeOfDoorFrame;
               this.MaterialType = materialType;
               this.TotalAmount = totalAmount;
               this.AmountLeft = amountLeft;
               this.AmountRight = amountRight;
               this.IronThickness = ironThickness;
            }
        }



   
        void ArrangingAndCollectingData()
        {
            if (DT == null)
                return;


            setData = new List<SortedDataIncomming>();
            setData2 = new List<SortedDataIncomming>();


            setData =  new List<SortedDataIncomming>();
            setData2 =  new List<SortedDataIncomming>();
        

            foreach (DataRow row in DT.Rows)

            setData =  new List<SortedDataIncomming>();
            setData2 =  new List<SortedDataIncomming>();

            foreach(DataRow row in DT.Rows)

            {

                if ((string)row["Dir"] == "All")
                {
                    setData.Add(new SortedDataIncomming((string)row["AgroupOfDoorFrames"], (string)row["MaterialType"], (int)row["TotalAmount"], 0, 0, (double)row["IronThickness"], (string)row["TypeOfDoorFrame"]));
                }

            }
            int tempR = 0, tempL=0;
            foreach (var row in setData)
            {
                foreach(DataRow rowdb in DT.Rows)
                {
                  
                    if ((string)rowdb["Dir"] == "Right" && (string)rowdb["AgroupOfDoorFrames"] == row.AgroupOfDoorFrames && (string)rowdb["MaterialType"] == row.MaterialType && (double)rowdb["IronThickness"] == row.IronThickness && (string)rowdb["TypeOfDoorFrame"] == row.TypeOfDoorFrame)
                    {
                        tempR = (int)rowdb["TotalAmount"];

                    }else if ((string)rowdb["Dir"]=="Left" && (string)rowdb["AgroupOfDoorFrames"] == row.AgroupOfDoorFrames && (string)rowdb["MaterialType"]==row.MaterialType && (double)rowdb["IronThickness"]==row.IronThickness && (string)rowdb["TypeOfDoorFrame"] == row.TypeOfDoorFrame)
                    {
                        tempL = (int)rowdb["TotalAmount"];
                      
                    }   
                    
            
                }

                setData2.Add(new SortedDataIncomming(row.AgroupOfDoorFrames, row.MaterialType, row.TotalAmount,tempL, tempR,row.IronThickness,row.TypeOfDoorFrame));
                tempL = 0;
                tempR = 0;
            }

        }
    
        
        string getNameType(string name)
        {
            switch (name)
            {
                case "Regular":
return Application.Current.FindResource("langrbAgroupOfDoorFramesNormal").ToString();   
                
                case "Alpha":
return Application.Current.FindResource("langrbAgroupOfDoorFramesAlpha").ToString();

                case "Pivot":
return Application.Current.FindResource("langrbAgroupOfDoorFramesPivot").ToString();
                    
                case "Blind":
return Application.Current.FindResource("langrbAgroupOfDoorFramesAveer").ToString();

                    
                case "Sliding":
return Application.Current.FindResource("langrbAgroupOfDoorFramesZaza").ToString();
                    
                    
                case "Pendel":
return Application.Current.FindResource("langrbAgroupOfDoorFramesBindl").ToString();

                    
                case "SlidingPocket":
return Application.Current.FindResource("langrbAgroupOfDoorFramesPoketZaza").ToString();
                default:
                    return "";


            }
        }  
        
        
        string getNameDoor(string name)
        {
            switch (name)
            {
                case "Standart":
return Application.Current.FindResource("langrbFrameTypeStandart").ToString();   
                
                case "Mishtalev":
return Application.Current.FindResource("langrbFrameTypeMeshtaliv").ToString();

                case "Halbasha":
return Application.Current.FindResource("langrbFrameTypehalbsha").ToString();
                    
                case "Click":
return Application.Current.FindResource("langrbFrameTypeKlik").ToString();

                    
                case "KantTiach":
return Application.Current.FindResource("langrbFrameTypeKantTiach").ToString();
                    
                    
                case "Arusi":
return Application.Current.FindResource("langrbFrameTypeArusi").ToString();


                default:
                    return "";


            }
        }

        string getMetrilType(string name)
        {
            switch (name)
            {
                case "Megolvan":
                    return Application.Current.FindResource("langrbmegolvan").ToString();
                  
                         case "Norsta":
                    return Application.Current.FindResource("langrbnerosta").ToString();
                default:
                    return "";
                  



            }
        }
       

        void setDataToReport()
        {
            foreach(var row in setData2)
            {
                _parmeter.Amount = row.TotalAmount.ToString();
                _parmeter.LAmount = row.AmountLeft.ToString();
                _parmeter.RAmount = row.AmountRight.ToString();
                _parmeter.FrameType = getNameType(row.AgroupOfDoorFrames);
                _parmeter.FrameMeterial = getMetrilType( row.MaterialType )+ " " + row.IronThickness;
                _parmeter.TypeOfDoorFrame = getNameDoor(row.TypeOfDoorFrame);

                _print();


            }
        }


      


        public void Print()
        {

            ArrangingAndCollectingData();

            setDataToReport();

        }

        void _print()
        {

            StickerPackingFrame setPara = new StickerPackingFrame(_parmeter);

            CrpStickerPackingFrame report = setPara.returnReport();

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
