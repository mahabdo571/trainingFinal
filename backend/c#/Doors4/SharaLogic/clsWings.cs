using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace SharaLogic
{
    public class clsWings
    {
        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;


        public clsOrders Orders;
        public clsProjects Projects;
        public clsCustomers Customers;
        public int ID { get; set; }
        public int OdrerId { get; set; }
        public string DoorNumber { get; set; }
        public DateTime DateAdded { get; set; }
        public string DoorType { get; set; }
        public string Direction { get; set; }
        public string LockType { get; set; }
        public string Location { get; set; }
        public string FactoryNotes { get; set; }
        public string Notes { get; set; }
        public int tbPrintAmount { get; set; }
        public int tbStickers { get; set; }
        public int tbAmount { get; set; }
        public string AccID { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ColorDoor { get; set; }
        public string ColorSide { get; set; }
        public float FormaicaThickness { get; set; }
        public int WidthFinal { get; set; }
        public int HeightFinal { get; set; }
        public int WidthCut { get; set; }
        public int HeightCut { get; set; }
        public int WidthPlatz { get; set; }
        public int HeightPlatz { get; set; }
        public bool DoubleDoor { get; set; }
        public bool SupportHelpless { get; set; }
        public bool MakhzerShemen { get; set; }
        public bool Atmer { get; set; }
        public bool Side { get; set; }
        public clsWingType WingType { get; set; }
      public   int DDWingID { get; set; }
          public   string DDAK { get; set; }
        private clsWings(
            int id,
   int oOdrerId,
   string doorNumber,
   DateTime dateAdded,
   string dDoorType,
   string direction,
   string lockType,
   string lLocation,
   string factoryNotes,
   string notes,
   int TbPrintAmount,
   int TbStickers,
   int TbAmount,
   string accID,
   DateTime updateDate,
   string colorDoor,
   string colorSide,
   float formaicaThickness,
   int widthFinal,
   int heightFinal,
   int widthCut,
   int heightCut,
   bool doubleDoor,
   bool supportHelpless,
   bool makhzerShemen,
   bool atmer,
   bool side,
   int ddWingID,
   string ddAK

            )
        {



            this.ID = id;
            this.OdrerId = oOdrerId;
            this.DoorNumber = doorNumber;
            this.DateAdded = dateAdded;
            this.DoorType = dDoorType;
       
               this.Direction = direction;
            
            this.LockType = lockType;
            this.Location = lLocation;
            this.FactoryNotes = factoryNotes;
            this.Notes = notes;
            this.tbPrintAmount = TbPrintAmount;
            this.tbStickers = TbStickers;
            this.tbAmount = TbAmount;
            this.AccID = accID;
            this.UpdateDate = DateTime.Now;
            this.ColorDoor = colorDoor;
            this.ColorSide = colorSide;
            this.FormaicaThickness = formaicaThickness;
            this.WidthFinal = widthFinal;
            this.HeightFinal = heightFinal;
            this.WidthCut = widthCut;
            this.HeightCut = heightCut;
            this.DoubleDoor = doubleDoor;
            this.SupportHelpless = supportHelpless;
            this.MakhzerShemen = makhzerShemen;
            this.Atmer = atmer;
            this.Side = side;
            this.DDWingID = ddWingID;
            this.DDAK = ddAK;
            this.Orders = clsOrders.Find(OdrerId);
            this.Projects = clsProjects.Find(Orders.ProjectID);
            this.Customers = clsCustomers.Find(Projects.iDcustomer);
            this.WingType = clsWingType.FindByWingID(id);
            this._Mode = _myMode.Update;
        }

        public clsWings()
        {
            this.ID = -1;
            this.OdrerId = -1;
            this.DoorNumber = "";
            this.DateAdded = DateTime.Now;
            this.DoorType = "";
            this.Direction = "";
            this.LockType = "";
            this.Location = "";
            this.FactoryNotes = "";
            this.Notes = "";
            this.tbPrintAmount = 0;
            this.tbStickers =0;
            this.tbAmount = 0;
            this.AccID = "";
            this.UpdateDate = DateTime.Now;
            this.ColorDoor = "";
            this.ColorSide = "";
            this.FormaicaThickness = -1f;
            this.WidthFinal = -1;
            this.HeightFinal = -1;
            this.WidthCut = -1;
            this.HeightCut = -1;
            this.DoubleDoor = false;
            this.SupportHelpless = false;
            this.MakhzerShemen = false;
            this.Atmer = false;
            this.Side = false;
            this.DDWingID = -1;
            this.DDAK = "N";
          
            this._Mode = _myMode.Addnew;

        }

        public  static clsWings Find(int ID)
        {




            int infun_OdrerId = -1;
            string infun_DoorNumber ="";
            DateTime infun_DateAdded = DateTime.Now;
            string infun_DoorType = "";
            string infun_Direction = "";
            string infun_LockType = "";
            string infun_Location = "";
            string infun_FactoryNotes = "";
            string infun_Notes = "";
            int infun_tbPrintAmount =0;
            int infun_tbStickers = 0;
            int infun_tbAmount = 0;
            string infun_AccID ="";
            DateTime infun_UpdateDate = DateTime.Now;
            string infun_ColorDoor = "";
            string infun_ColorSide = "";
            float infun_FormaicaThickness = -1f;
            int infun_WidthFinal = -1;
            int infun_HeightFinal = -1;
            int infun_WidthCut = -1;
            int infun_HeightCut = -1;
            bool infun_DoubleDoor = false;
            bool infun_SupportHelpless = false;
            bool infun_MakhzerShemen = false;
            bool infun_Atmer = false;
            bool infun_Side = false;
            int ddWingID = -1;
            string ddAK = "";

            if ( clsDataAccessWing.GetByID(ID,

 ref infun_OdrerId,
 ref infun_DoorNumber,
 ref infun_DateAdded,
            ref infun_DoorType,
 ref infun_Direction,
 ref infun_LockType,
 ref infun_Location,
 ref infun_FactoryNotes,
 ref infun_Notes,
 ref infun_tbPrintAmount,
 ref infun_tbStickers,
 ref infun_tbAmount,
 ref infun_AccID,
 ref infun_UpdateDate,
            ref infun_ColorDoor,
 ref infun_ColorSide,
 ref infun_FormaicaThickness,
            ref infun_WidthFinal,
 ref infun_HeightFinal,
 ref infun_WidthCut,
 ref infun_HeightCut,
 ref infun_DoubleDoor,
 ref infun_SupportHelpless,
 ref infun_MakhzerShemen,
 ref infun_Atmer,
 ref infun_Side,ref ddWingID,ref ddAK


                ))
            {
                return  new clsWings(ID,

    infun_OdrerId,
    infun_DoorNumber,
    infun_DateAdded,
                infun_DoorType,
    infun_Direction,
    infun_LockType,
    infun_Location,
    infun_FactoryNotes,
    infun_Notes,
   infun_tbPrintAmount,
    infun_tbStickers,
    infun_tbAmount,
    infun_AccID,
    infun_UpdateDate,
                infun_ColorDoor,
    infun_ColorSide,
    infun_FormaicaThickness,
                infun_WidthFinal,
    infun_HeightFinal,
    infun_WidthCut,
    infun_HeightCut,
    infun_DoubleDoor,
    infun_SupportHelpless,
    infun_MakhzerShemen,
    infun_Atmer,
    infun_Side,  ddWingID,  ddAK
                    );

            }
            else
            {
                return null;
            }

        }


        private bool _Add()
        {
  


            this.ID = clsDataAccessWing.Add(
                         
            this.OdrerId,
            this.DoorNumber,
            this.DateAdded ,
            this.DoorType  ,
            this.Direction  ,
            this.LockType  ,
            this.Location  ,
            this.FactoryNotes  ,
            this.Notes  ,
            this.tbPrintAmount  ,
            this.tbStickers  ,
            this.tbAmount  ,
            this.AccID  ,
            this.UpdateDate ,
            this.ColorDoor  ,
            this.ColorSide  ,
            this.FormaicaThickness ,
            this.WidthFinal  ,
            this.HeightFinal  ,
            this.WidthCut  ,
            this.HeightCut  ,
            this.DoubleDoor  ,
            this.SupportHelpless  ,
            this.MakhzerShemen  ,
            this.Atmer  ,
            this.Side  ,this.DDWingID,this.DDAK

                );
       
            return (this.ID != -1);
        }

        private   bool  _Update()
        {


            if (this.ID != -1)
            {
                Orders.Date = DateTime.Now;
                Projects.DateOfUpdate = DateTime.Now;
                Customers.UpdateDate = DateTime.Now;
                Orders.Save();
                Projects.Save();
                Customers.Save();
            }
            return  clsDataAccessWing.Update(this.ID,



            this.OdrerId,
            this.DoorNumber,
            this.DateAdded,
            this.DoorType,
            this.Direction,
            this.LockType,
            this.Location,
            this.FactoryNotes,
            this.Notes,
            this.tbPrintAmount,
            this.tbStickers,
            this.tbAmount,
            this.AccID,
            this.UpdateDate,
            this.ColorDoor,
            this.ColorSide,
            this.FormaicaThickness,
            this.WidthFinal,
            this.HeightFinal,
            this.WidthCut,
            this.HeightCut,
            this.DoubleDoor,
            this.SupportHelpless,
            this.MakhzerShemen,
            this.Atmer,
            this.Side,this.DDWingID,this.DDAK
                );

        }

        public  bool  Save()

        {

            switch (_Mode)
            {

                case _myMode.Addnew:

                    if (_Add())
                    {
                        _Mode = _myMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case _myMode.Update:
                    return  _Update();
            }

            return false;

        }

        public int CopyWing()

        {

            clsWingType tempType;
            clsWingWindows tempWindos;
            clsWingHinge tempHing;
            clsWingLock tempLock;
            clsWingAddon Tempaddon;
            clsWingAdvanced TempAdva;


            tempType = clsWingType.FindByWingID(this.ID);
            tempWindos = clsWingWindows.FindByWingID(this.ID);
            tempHing = clsWingHinge.FindByWingID(this.ID);
            tempLock = clsWingLock.FindByWingID(this.ID);
            Tempaddon = clsWingAddon.FindByWingID(this.ID);
            TempAdva = clsWingAdvanced.FindByWingID(this.ID);

            this.ID = clsDataAccessWing.Add(

            this.OdrerId,
            "",
            this.DateAdded,
            this.DoorType,
            this.Direction,
            this.LockType,
            this.Location,
            this.FactoryNotes,
            this.Notes,
            this.tbPrintAmount,
            this.tbStickers,
            this.tbAmount,
            this.AccID,
            this.UpdateDate,
            this.ColorDoor,
            this.ColorSide,
            this.FormaicaThickness,
            this.WidthFinal,
            this.HeightFinal,
            this.WidthCut,
            this.HeightCut,
            this.DoubleDoor,
            this.SupportHelpless,
            this.MakhzerShemen,
            this.Atmer,
            this.Side,this.DDWingID,this.DDAK


                );

            if(tempType != null) { tempType.CopyTypeWing(this.ID); }
            if (tempWindos != null) { tempWindos.CopyWindoWing(this.ID); }
            if (tempHing != null) { tempHing.CopyHingWing(this.ID); }
            if (tempLock != null) { tempLock.CopyLockWing(this.ID); }
            if (Tempaddon != null) { Tempaddon.copyAddonWing(this.ID); }
            if (TempAdva != null) { TempAdva.copyAdvdonWing(this.ID); }
           

            return this.ID;

         


        }

        public static bool Delete(int ID)
        {
            return  clsDataAccessWing.Delete(ID);
        }

        public static DataTable getAll()
        {
            return   clsDataAccessWing.GetAll();
        } 
        
        public static DataTable getbyOrderID(int OdrerId)
        {
            return clsDataAccessWing.getbyOrderID(OdrerId);
        }

        public static bool IsExist(int ID)
        {
            return clsDataAccessWing.IsExist(ID);
        }  
        
        public static bool IsExistNumberDoor(int orderID,string numberDoor)
        {
            return clsDataAccessWing.IsExistNumberDoor(orderID, numberDoor);
        }

        public void clear()
        {
            
      
           // this.DoorNumber = "";
        
            this.DoorType = "";
            this.Direction = "";
            this.LockType = "";
            this.Location = "";
            this.FactoryNotes = "";
            this.Notes = "";
            this.tbPrintAmount = 0;
            this.tbStickers = 0;
            this.tbAmount = 0;
            this.AccID = "";
            this.UpdateDate = DateTime.Now;
            this.ColorDoor = "";
            this.ColorSide = "";
            this.FormaicaThickness = -1f;
            this.WidthFinal = -1;
            this.HeightFinal = -1;
            this.WidthCut = -1;
            this.HeightCut = -1;
            this.DoubleDoor = false;
            this.SupportHelpless = false;
            this.MakhzerShemen = false;
            this.Atmer = false;
            this.Side = false;
            this.DDWingID = -1;
            this.DDAK = "N";
            this._Mode = _myMode.Update;
        }

        public clsWings DDCopyWing()

        {

            clsWingType tempType;
            clsWingWindows tempWindos;
            clsWingHinge tempHing;
            clsWingLock tempLock;
            clsWingAddon Tempaddon;
            clsWingAdvanced TempAdva;


            tempType = clsWingType.FindByWingID(this.ID);
            tempWindos = clsWingWindows.FindByWingID(this.ID);
            tempHing = clsWingHinge.FindByWingID(this.ID);
            tempLock = clsWingLock.FindByWingID(this.ID);
            Tempaddon = clsWingAddon.FindByWingID(this.ID);
            TempAdva = clsWingAdvanced.FindByWingID(this.ID);

           int id =  clsDataAccessWing.Add(

            this.OdrerId,
            (this.DoorNumber+"K"),
            this.DateAdded,
            this.DoorType,
           ( this.Direction == "Left" ? "Right" : "Left"),
            this.LockType,
            this.Location,
            this.FactoryNotes,
            this.Notes,
            this.tbPrintAmount,
            this.tbStickers,
            this.tbAmount,
            this.AccID,
            this.UpdateDate,
            this.ColorDoor,
            this.ColorSide,
            this.FormaicaThickness,
            this.WidthFinal,
            this.HeightFinal,
            this.WidthCut,
            this.HeightCut,
            this.DoubleDoor,
            this.SupportHelpless,
            this.MakhzerShemen,
            this.Atmer,
            this.Side, 
            this.ID,
            "K"


                );

            if (tempType != null) { tempType.CopyTypeWing(id); }
            if (tempWindos != null) { tempWindos.CopyWindoWing(id); }
            if (tempHing != null) { tempHing.CopyHingWing(id); }
            if (tempLock != null) { tempLock.CopyLockWing(id); }
            if (Tempaddon != null) { Tempaddon.copyAddonWing(id); }
            if (TempAdva != null) { TempAdva.copyAdvdonWing(id); }


            return Find(id);




        }


    }
}
