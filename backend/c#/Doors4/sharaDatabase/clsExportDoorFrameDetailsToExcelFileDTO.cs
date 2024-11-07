using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsExportDoorFrameDetailsToExcelFileDTO
    {


        private string _HingeMetal = "";
        public string HingeMetal { get { return _HingeMetal; } set { _HingeMetal = value.Equals("Norsta") ? "נירוסטה" : "מגולבן"; } }
        public bool RHS70 { get; set; }
        public bool DoubleDoor { get; set; }
        public bool HiddenOil { get; set; }
        public int WallThickness { get; set; }
        public int ID { get; set; }
        public int LockMeasureFloor { get; set; }
        public int UpperLockMeasureFloor { get; set; }
        public int upperPartSize { get; set; }
        public string upperPartType { get; set; }
        public int BottomSize { get; set; }
  
        public bool Meksher { get; set; }
        public int FrameUnderFloor { get; set; }
        private string _HingeConnection = "";
        public string HingeConnection { get { return _HingeConnection; } set { _HingeConnection = value.Equals("Soldering") ? "מרותך" : "מוברג"; } }


        public string HingeType { get; set; }
        public int Hinge6 { get; set; }
        public int Hinge5 { get; set; }
        public int Hinge4 { get; set; }
        public int Hinge3 { get; set; }
        public int Hinge2 { get; set; }
        public int Hinge1 { get; set; }
        public int HingeAmount { get; set; }
        public int UpperLockMeasure { get; set; }
        public int LockMeasure { get; set; }
        public string LockTypeEN { get; set; }

        private string _LockType = "";
        public string LockType { get { return _LockType; } set {

                LockTypeEN =value;
                _LockType = _FunLockType(value); 
            
            } }

        private string _FunLockType(string value)
        {
            switch (value)
            {
                case "Sharabany":
                    return "שהרבני";
                case "JordanKafol":
                    return "ירדני כפול";
                case "Electric":
                    return "חשמלי";
                case "Publock":
                    return "פבלוק";
                case "NoLock":
                    return "ללא נעילה";
                default:
                    return "N/A";
            }


        }

        public int Quantity { get; set; }

        private string _Direction = "";
        public string Direction { get { return _Direction; } set { _Direction = value == "RIGHT" ? "ימין" : "שמאל"; } }
        public int FrameThickness { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float IronThickness { get; set; }
        private string _MaterialType = "";
        public string MaterialType
        {
            get { return _MaterialType; }
            set
            {
                _MaterialType = value == "Norsta" ? "נירוסטה" : "מגולבן";
            }
        }
        public DateTime Date { get; set; }
        public int OrderNumber { get; set; }
        public int DoorNumber { get; set; }
        public string DoorIdentity { get; set; }
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string FrameType { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public string FactoryNotes { get; set; }


        private string _bottomPartType = "";
        private bool _Kitum = false;
        public bool Kitum {private get { return _Kitum; } set{ 
                _Kitum = value;
                BottomPartType = _FUNbottomParttype();
            
            } }
        private bool _Nerousta = false;
        public bool Nerousta { get { return _Nerousta; } set {
                _Nerousta = value;

                BottomPartType = _FUNbottomParttype();

            } }
       
        
        public string BottomPartType
        {
            get { return _bottomPartType; }
            private set { _bottomPartType = value; }
        }


        private string _FUNbottomParttype()
        {
            string str = "";
            str += (Nerousta ? " נירוסטה " : "");
            str += (Kitum ? " כיתום " : "");
            str = (Kitum || Nerousta ? str : "N/A");
            return str;
        }
        // כיתום נירוסטה


    }
}
