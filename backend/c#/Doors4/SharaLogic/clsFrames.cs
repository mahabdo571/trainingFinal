using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using ClosedXML.Excel;
using SharaLogic.Calculations;
using DocumentFormat.OpenXml.Office2010.Excel;


namespace SharaLogic
{
    public class clsFrames
    {




        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;

        public int ID { get; set; }
        public int OrderID { get; set; }
        public string FrameType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int WallThickness { get; set; }
        public int FrameThickness { get; set; }
        public float IronThickness { get; set; }
        public DateTime Date { get; set; }
        public string Direction { get; set; }
        public string LockType { get; set; }
        public string MaterialType { get; set; }
        public string Notes { get; set; }
        public int Quantity { get; set; }
       
        public int DoorNumber { get; set; }
        public bool Meksher { get; set; }

        public bool RHS70 { get; set; }
        public  bool DoubleDoor { get; set; }
        public bool FlakhGV { get; set; }
        public string Location { get; set; }
        public string DoorIdentity { get; set; }
        public string FactoryNotes { get; set; }
        public int  FrameUnderFloor { get; set; }
        public bool isHand { get; set; }
        public int tbPrintAmount { get; set; }
        public int tbStickers { get; set; }
        public int tbAmount { get; set; }
        public clsOrders Orders;
        public clsProjects Projects;
        public clsCustomers Customers;
       
        private clsFrames(int id,
              int OrderID, string FrameType, int Width,
            int Height, int WallThickness, float IronThickness, DateTime Date, string Direction,
            string lockType, string MaterialType, string Notes,
            int Quantity, int frameThickness,
             int doorNumber, bool meksher, bool rHS70, bool doubleDoor, bool flakhGV
            , string location, string doorIdentity, string factoryNotes,int frameUnderFloor,
              bool IsHand,  int TbPrintAmount,
              int TbStickers,  int TbAmount
            )

        {
            this.ID = id;
            this.OrderID = OrderID;
            this.FrameType = FrameType;
            this.Width = Width;
            this.Height = Height;
            this.WallThickness = WallThickness;
            this.IronThickness = IronThickness;
            this.Date = DateTime.Now;
            this.Direction = Direction;
            this.LockType = lockType;
            this.MaterialType = MaterialType;
           this.FrameThickness = frameThickness;
            this.Notes = Notes;
            this.Quantity = Quantity;//presa value save
          
            this.DoorNumber = doorNumber;
            this.Meksher = meksher;
            this.RHS70 = rHS70;
            this.DoubleDoor = doubleDoor;
            this.FlakhGV = flakhGV;
            this.Location =location;
            this.DoorIdentity = doorIdentity;
            this.FactoryNotes = factoryNotes;
            this.FrameUnderFloor = frameUnderFloor;
            this._Mode = _myMode.Update;
            this.isHand = IsHand;
            this.tbPrintAmount = TbPrintAmount;
            this.tbAmount = TbAmount;
            this.tbStickers = TbStickers;
            this.Orders = clsOrders.Find(OrderID);
            this.Projects =clsProjects.Find(Orders.ProjectID);
            this.Customers = clsCustomers.Find(Projects.iDcustomer);

        }

        public clsFrames()
        {

            this._Mode = _myMode.Addnew;
            this.ID = -1;
            this.OrderID = -1;
            this.FrameType = "";
            this.Width = 0;
            this.Height = 0;
            this.WallThickness = 0;
            this.IronThickness = 0;
            this.Date = DateTime.Now;
            this.Direction = "";
            this.LockType = "";
            this.MaterialType = "";
            this.FrameThickness = 0;
            this.Notes = "";
            this.Quantity = 0;
  
            this.DoorNumber = 0;
            this.Meksher = false;
            this.RHS70 = false;
            this.DoubleDoor = false;
            this.FlakhGV = false;
            this.Location = "";
            this.DoorIdentity = "";
            this.FactoryNotes = "";
            this.FrameUnderFloor = 0;
            this.isHand = false;
            this.tbPrintAmount = 0;
            this.tbAmount = 0;
            this.tbStickers = 0;
        }




        public static  clsFrames Find(int id)
        {


           

                int OrderID = -1;
            string frameType = "";
            int Width = 0;
            int Height = 0;
            int WallThickness = 0;
            float ironThickness = 0f;
            DateTime date = DateTime.Now;
            string direction = "";
            string lockType = "";
            string materialType = "";         
            string notes = "";
            int quantity = 0;
         
            int frameThickness = 0;
            int doorNumber = 0;
            bool meksher = false;
            bool rHS70 = false;
            bool doubleDoor = false;
            bool flakhGV = false;
            string location = "";
            string doorIdentity = "";
            string factoryNotes = "";
            int frameUnderFloor = 0;
            bool IsHand = false;
            int TbPrintAmount =0;
            int TbStickers = 0;
            int TbAmount = 0;


             if ( clsDataAccessFrames.GetFrameByID(id, ref OrderID, ref frameType, ref Width, ref Height
            , ref WallThickness, ref ironThickness, ref date, ref direction, ref lockType, ref materialType
            , ref notes, ref quantity, ref frameThickness, ref doorNumber, ref meksher, ref rHS70
            , ref doubleDoor, ref flakhGV, ref location, ref doorIdentity, ref factoryNotes, ref frameUnderFloor,
                ref IsHand, ref TbPrintAmount,
          ref TbStickers, ref TbAmount
            ))
                {

                    return new clsFrames(id, OrderID, frameType, Width,
                     Height, WallThickness, ironThickness, date, direction, lockType, materialType
                    , notes, quantity, frameThickness, doorNumber, meksher, rHS70
                    , doubleDoor, flakhGV, location, doorIdentity, factoryNotes, frameUnderFloor,
                           IsHand, TbPrintAmount,
                   TbStickers, TbAmount
                        );

                }

           
                clsDataAccessSettings.SetEventLogMsg("Find Null", "CLS_clsFrames__FUNCTION__Find", System.Diagnostics.EventLogEntryType.Warning);

                return null;
         

        }



        private bool _AddNewPhone()
        {
     

                this.ID = clsDataAccessFrames.Add(

               this.OrderID,this.FrameType,this.Width,this.Height,this.WallThickness,IronThickness
               ,this.Date,this.Direction,this.LockType,this.MaterialType,this.Notes,
               this.Quantity,this.FrameThickness,this.DoorNumber,this.Meksher,this.RHS70
               ,this.DoubleDoor,this.FlakhGV,this.Location,this.DoorIdentity, this.FactoryNotes,this.FrameUnderFloor
              ,this.isHand,this.tbPrintAmount,this.tbStickers,this.tbAmount
               );

            if (AddDefultHing() && AddDefultLock())
            {
                return (this.ID != -1);
            }
            else
            {
                return false;
            }

        }

        bool AddDefultHing()
        {
            clsHingesFrames hing = new clsHingesFrames();
            hing.FrameID = this.ID;
            hing.HingeAmount = 3;
            hing.HeightToBottomHinge = this.Height;
            hing.HingeType = "4X4";
            hing.HingeMetal = "Megolvan";
            hing.HingeConnection = "Soldering";
            hing.NoCalcu = true;

            return hing.Save();

        }

        bool AddDefultLock()
        {
            clsFrameLockType lockframe = new clsFrameLockType();
            lockframe.FrameId = this.ID;
            lockframe.FrameHiegth = this.Height;
            lockframe.LockType = "Sharabany";
            lockframe.NoCalcu = true;

            return lockframe.Save();
        }

        private  bool _UpdatePhone()
        {
            if(this.ID != -1)
            {
                Orders.Date = DateTime.Now;
                Projects.DateOfUpdate = DateTime.Now;
                Customers.UpdateDate = DateTime.Now;
                Orders.Save();
                Projects.Save();
                Customers.Save();
            }

            return  clsDataAccessFrames.Update(this.ID,
               this.OrderID, this.FrameType, this.Width, this.Height, this.WallThickness, IronThickness
               , this.Date, this.Direction, this.LockType, this.MaterialType, this.Notes,
               this.Quantity, this.FrameThickness, this.DoorNumber, this.Meksher, this.RHS70
               , this.DoubleDoor, this.FlakhGV, this.Location, this.DoorIdentity, this.FactoryNotes,this.FrameUnderFloor
               , this.isHand, this.tbPrintAmount, this.tbStickers, this.tbAmount
               );

        }


        public bool Save()

        {

            switch (_Mode)
            {

                case _myMode.Addnew:

                    if (_AddNewPhone())
                    {
                        _Mode = _myMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case _myMode.Update:
                    return _UpdatePhone();
            }

            return false;

        }

        public int CopyFrame()
        {
             

            clsFrameType typeFrametemp = clsFrameType.FindByFrameID(this.ID);
            clsHingesFrames HingesFramestemp = clsHingesFrames.FindByFrameID(this.ID);
            clsFrameLockType FrameLockTypetemp = clsFrameLockType.FindByFrameID(this.ID);
            clsFrameUpperPart FrameUpperPartTemp = clsFrameUpperPart.FindByFrameID(this.ID);
            clsFrameAdvanced clsFrameAdvancedTemp = clsFrameAdvanced.FindByFrameID(this.ID);
            

            this.ID = clsDataAccessFrames.Add(

      this.OrderID, this.FrameType, this.Width, this.Height, this.WallThickness, this.IronThickness
      , this.Date, this.Direction, this.LockType, this.MaterialType, this.Notes,
      this.Quantity, this.FrameThickness, 0, this.Meksher, this.RHS70
      , this.DoubleDoor, this.FlakhGV, this.Location, this.DoorIdentity, this.FactoryNotes, this.FrameUnderFloor
     , this.isHand, this.tbPrintAmount, this.tbStickers, this.tbAmount
      );

            if(typeFrametemp != null) { typeFrametemp.CopyTypeFrame(this.ID);  }
            if(HingesFramestemp != null) { HingesFramestemp.CopyHingesFrames(this.ID);  }
            if(FrameLockTypetemp != null) { FrameLockTypetemp.CopyFrameLockTypeFrames(this.ID);  }
            if(FrameUpperPartTemp != null) { FrameUpperPartTemp.CopyFrameUpperPartFrames(this.ID);  }
            if(clsFrameAdvancedTemp != null) { clsFrameAdvancedTemp.copy(this.ID);  }




            return this.ID;

        }
        public static bool Delete(int ID)
        {
            return clsDataAccessFrames.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessFrames.GetAll();
        }
        public static DataTable getFrameFromOrderID(int OrderID)
        {
            return clsDataAccessFrames.getFrameForOrderID(OrderID);
        }

        public static DataTable Search(string s, int OrderID)
        {
            return clsDataAccessFrames.Search(s,  OrderID);

        }


        public static bool IsExist(int ID)
        {
            return clsDataAccessFrames.IsExist(ID);
        }

        public static bool FindByOrderframeNumber(string doornumber, int order)
        {
            return clsDataAccessFrames.FindByOrderframeNumber(doornumber, order);
        }

        public void clear()
        {
            this._Mode = _myMode.Update;


            this.FrameType = "";
            this.Width = 0;
            this.Height = 0;
            this.WallThickness = 0;
            this.IronThickness = 0;
            this.Date = DateTime.Now;
            this.Direction = "";
            this.LockType = "";
            this.MaterialType = "";
            this.FrameThickness = 0;
            this.Notes = "";
            this.Quantity = 0;

           // this.DoorNumber = 0;
            this.Meksher = false;
            this.RHS70 = false;
            this.DoubleDoor = false;
            this.FlakhGV = false;
            this.Location = "";
            this.DoorIdentity = "";
            this.FactoryNotes = "";
            this.FrameUnderFloor = 0;
            this.isHand = false;
            this.tbPrintAmount = 0;
            this.tbAmount = 0;
            this.tbStickers = 0;
        }


        public static async Task BLL_ExportDoorFrameDetailsToExcelFile(int orderId)
        {
            try
            {
                List<clsExportDoorFrameDetailsToExcelFileDTO> data = await clsDataAccessFrames.DAL_ExportDoorFrameDetailsToExcelFile(orderId);
                if (data == null)
                {
                    throw new Exception("No Data");

                }

                ExportDataToExcel(data);

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
      
        }

        private static void ExportDataToExcel(List<clsExportDoorFrameDetailsToExcelFileDTO> data)
        {
            int orderNumber = -1;

            using (var workbook = new XLWorkbook())
            {
          
                var worksheet = workbook.Worksheets.Add("Data");

             
                worksheet.Cell(1, 1).Value = "Order Number";
                worksheet.Cell(1, 2).Value = "Frame Number";
                worksheet.Cell(1, 3).Value = "Frame Identity";
                worksheet.Cell(1, 4).Value = "Customer Name";
                worksheet.Cell(1, 5).Value = "Project Name";
                worksheet.Cell(1, 6).Value = "Frame Type";
                worksheet.Cell(1, 7).Value = "Frame Location";
                worksheet.Cell(1, 8).Value = "Comments";
                worksheet.Cell(1, 9).Value = "Factory Comments";
                worksheet.Cell(1, 10).Value = "Print Date";
                worksheet.Cell(1, 11).Value = "Meterial";
                worksheet.Cell(1, 12).Value = "Meterial Width";
                worksheet.Cell(1, 13).Value = "Frame Hight";
                worksheet.Cell(1, 14).Value = "Frame Width";
                worksheet.Cell(1, 15).Value = "Frame Thickness";
                worksheet.Cell(1, 16).Value = "Direction";
                worksheet.Cell(1, 17).Value = "Amount";
                worksheet.Cell(1, 18).Value = "Lock Type";
                worksheet.Cell(1, 19).Value = "Lock 1 Size";
                worksheet.Cell(1, 20).Value = "Lock 2 Size";
                worksheet.Cell(1, 21).Value = "Hinge Amount";
                worksheet.Cell(1, 22).Value = "Hinge 1 Size";
                worksheet.Cell(1, 23).Value = "Hinge 2 Size";
                worksheet.Cell(1, 24).Value = "Hinge 3 Size";
                worksheet.Cell(1, 25).Value = "Hinge 4 Size";
                worksheet.Cell(1, 26).Value = "Hinge 5 Size";
                worksheet.Cell(1, 27).Value = "Hinge 6 Size";
                worksheet.Cell(1, 28).Value = "Hinge Type";
                worksheet.Cell(1, 29).Value = "Hinge Connection";
                worksheet.Cell(1, 30).Value = "Hinge Meterial";
                worksheet.Cell(1, 31).Value = "Hight Under Floor";
                worksheet.Cell(1, 32).Value = "Mekasher+100";
                worksheet.Cell(1, 33).Value = "Bottom Part Type";
                worksheet.Cell(1, 34).Value = "Bottom Part Size";
                worksheet.Cell(1, 34).Value = "Bottom Part Size";
                worksheet.Cell(1, 35).Value = "Top Part Type";
                worksheet.Cell(1, 36).Value = "Top Part Size";
                worksheet.Cell(1, 37).Value = "Hidden Oil Returner";
                worksheet.Cell(1, 38).Value = "Double Door";
                worksheet.Cell(1, 39).Value = "RHS-70";

           
                worksheet.Range("A1:AM1").Style.Font.Bold = true;

                orderNumber = data[0].OrderNumber;
               
                for (int i = 0; i < data.Count; i++)
                {

                 var MainCalc = _inFillDataToExect(data[i].ID, data[i]);

                    worksheet.Cell(i + 2, 1).Value = data[i].OrderNumber;
                    worksheet.Cell(i + 2, 2).Value = data[i].DoorNumber;
                    worksheet.Cell(i + 2, 3).Value = data[i].DoorIdentity;
                    worksheet.Cell(i + 2, 4).Value = data[i].CompanyName;
                    worksheet.Cell(i + 2, 5).Value = data[i].ProjectName;
                    worksheet.Cell(i + 2, 6).Value =FrameNameCalc.FrameNameSys(data[i].FrameType);
                    worksheet.Cell(i + 2, 7).Value = data[i].Location;
                    worksheet.Cell(i + 2, 8).Value = data[i].Notes;
                    worksheet.Cell(i + 2, 9).Value = data[i].FactoryNotes;
                    worksheet.Cell(i + 2, 10).Value = data[i].Date;
                    worksheet.Cell(i + 2, 11).Value = data[i].MaterialType;
                    worksheet.Cell(i + 2, 12).Value = data[i].IronThickness;
                    worksheet.Cell(i + 2, 13).Value = data[i].Height;
                    worksheet.Cell(i + 2, 14).Value = data[i].Width;
                    worksheet.Cell(i + 2, 15).Value = data[i].FrameThickness == 0 ? MainCalc.OUT.OutFrameThickness.Equals("Empty")?"0": MainCalc.OUT.OutFrameThickness : data[i].FrameThickness.ToString();//;
                    worksheet.Cell(i + 2, 16).Value = data[i].Direction;
                    worksheet.Cell(i + 2, 17).Value = data[i].Quantity;
                    worksheet.Cell(i + 2, 18).Value = data[i].LockType;
                    worksheet.Cell(i + 2, 19).Value = MainCalc.OUT.OutFrameLock1.Equals("Empty") ? "0" : MainCalc.OUT.OutFrameLock1;
                    worksheet.Cell(i + 2, 20).Value = MainCalc.OUT.OutFrameLock2.Equals("Empty") ? "0" : MainCalc.OUT.OutFrameLock2;
                    worksheet.Cell(i + 2, 21).Value = data[i].HingeAmount;
                    worksheet.Cell(i + 2, 22).Value = MainCalc.OUT.OutFrameHinge1H;
                    worksheet.Cell(i + 2, 23).Value = MainCalc.OUT.OutFrameHinge2H;
                    worksheet.Cell(i + 2, 24).Value = MainCalc.OUT.OutFrameHinge3H;
                    worksheet.Cell(i + 2, 25).Value = MainCalc.OUT.OutFrameHinge4H;
                    worksheet.Cell(i + 2, 26).Value = MainCalc.OUT.OutFrameHinge5H;
                    worksheet.Cell(i + 2, 27).Value = MainCalc.OUT.OutFrameHinge6H;
                    worksheet.Cell(i + 2, 28).Value = data[i].HingeType;
                    worksheet.Cell(i + 2, 29).Value = data[i].HingeConnection;
                    worksheet.Cell(i + 2, 30).Value = data[i].HingeMetal;
                    worksheet.Cell(i + 2, 31).Value = data[i].FrameUnderFloor;
                    worksheet.Cell(i + 2, 32).Value = data[i].Meksher;
                    worksheet.Cell(i + 2, 33).Value = data[i].BottomPartType;
                    worksheet.Cell(i + 2, 34).Value = data[i].BottomSize;
                    worksheet.Cell(i + 2, 35).Value = data[i].upperPartType;
                    worksheet.Cell(i + 2, 36).Value = data[i].upperPartSize;
                    worksheet.Cell(i + 2, 37).Value = data[i].HiddenOil;
                    worksheet.Cell(i + 2, 38).Value = data[i].DoubleDoor;
                    worksheet.Cell(i + 2, 39).Value = data[i].RHS70;
                }

               
                workbook.SaveAs($"{clsSettings.GetData().DocumentsPath}\\FrameExcel\\{DateTime.Now.ToString("dd_MM_yyyy")}\\Frames_{orderNumber}.xlsx");


            }

           
        }

        private static clsFrameMainCalculations _inFillDataToExect(int id, clsExportDoorFrameDetailsToExcelFileDTO data)
        {
           
         var MainCalc = new clsFrameMainCalculations(id);

            MainCalc.IN.InFrameWidth = data.Width;
            MainCalc.IN.InFrameHight = data.Height;
            MainCalc.IN.Inhinge1 = data.Hinge1;
            MainCalc.IN.Inhinge2 = data.Hinge2;
            MainCalc.IN.Inhinge3 = data.Hinge3;
            MainCalc.IN.Inhinge4 = data.Hinge4;
            MainCalc.IN.Inhinge5 = data.Hinge5;
            MainCalc.IN.Inhinge6 = data.Hinge6;
            MainCalc.IN.InLockType =  data.LockTypeEN;
            MainCalc.IN.InHingeAmount = data.HingeAmount;
     
          
            MainCalc.IN.InLockMeasure = data.LockMeasure;
            MainCalc.IN.InUpperLockMeasure = data.UpperLockMeasure;
            MainCalc.IN.InLockMeasureFloor = data.LockMeasureFloor;
            MainCalc.IN.InUpperLockMeasureFloor = data.UpperLockMeasureFloor;
            MainCalc.IN.InFrameHightUnderFloor = data.FrameUnderFloor;
            MainCalc.IN.InFrameThicknessBox = data.FrameThickness;
            MainCalc.IN.InWallThicknessBox = data.WallThickness;
          
         

            MainCalc.EXECUTE();
           

            return MainCalc;
        }
    }
}
