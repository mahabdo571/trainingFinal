using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsWingWindows
    {
        enum myMode { addNew = 1, Update = 2 }

        myMode _mode = myMode.addNew;

        public int ID { get; set; }
        public string WindowType { get; set; }
        public string GlassType { get; set; }
        public string TrisType { get; set; }
        public string OpeningDirection { get; set; }
        public int CircleDiameter { get; set; }
        public int CircleLocationFromBottom { get; set; }
        public int WindowHeight { get; set; }
        public int WindowWidth { get; set; }
        public int WindowPositionFromAbove { get; set; }
        public int WindowPositionFromHandle { get; set; }
        public int TrisHeight { get; set; }
        public int TrisWidth { get; set; }
        public int TrisPositionFromHandle { get; set; }
        public int TrisPositionFromAbove { get; set; }
        public int TrisPositionFromBottom { get; set; }
        public int WingID { get; set; }
        public bool WindoInCenter { get; set; }
        public bool TrisInCenter { get; set; }
        public bool AorHole { get; set; }



        private clsWingWindows(int ID_, string WindowType_, string GlassType_, string TrisType_, string OpeningDirection_, int CircleDiameter_, int CircleLocationFromBottom_,
             int WindowHeight_, int WindowWidth_, int WindowPositionFromAbove_, int WindowPositionFromHandle_, int TrisHeight_, int TrisWidth_, int TrisPositionFromHandle_,
             int TrisPositionFromAbove_, int TrisPositionFromBottom_, int WingID_,bool windoInCenter,bool trisInCenter,bool aorHole)
        {
            this.ID = ID_;
            this.WindowType = WindowType_;
            this.GlassType = GlassType_;
            this.TrisType = TrisType_;
            this.OpeningDirection = OpeningDirection_;
            this.CircleDiameter = CircleDiameter_;
            this.CircleLocationFromBottom = CircleLocationFromBottom_;
            this.WindowHeight = WindowHeight_;
            this.WindowWidth = WindowWidth_;
            this.WindowPositionFromAbove = WindowPositionFromAbove_;
            this.WindowPositionFromHandle = WindowPositionFromHandle_;
            this.TrisHeight = TrisHeight_;
            this.TrisWidth = TrisWidth_;
            this.TrisPositionFromHandle = TrisPositionFromHandle_;
            this.TrisPositionFromAbove = TrisPositionFromAbove_;
            this.TrisPositionFromBottom = TrisPositionFromBottom_;
            this.WingID = WingID_;
            this.WindoInCenter = windoInCenter;
            this.TrisInCenter = trisInCenter;
            this.AorHole = aorHole;

            _mode = myMode.Update;
        }

        public clsWingWindows()
        {
            this.ID = -1;
            this.WindowType = "";
            this.GlassType = "";
            this.TrisType = "";
            this.OpeningDirection = "";
            this.CircleDiameter = -1;
            this.CircleLocationFromBottom = -1;
            this.WindowHeight = -1;
            this.WindowWidth = -1;
            this.WindowPositionFromAbove = -1;
            this.WindowPositionFromHandle = -1;
            this.TrisHeight = -1;
            this.TrisWidth = -1;
            this.TrisPositionFromHandle = -1;
            this.TrisPositionFromAbove = -1;
            this.TrisPositionFromBottom = -1;
            this.WingID = -1;
            this.WindoInCenter = false;
            this.TrisInCenter = false;
            this.AorHole = false;
            _mode = myMode.addNew;
        }

        public static clsWingWindows Find(int __ID)
        {
        
            string __WindowType = "";
            string __GlassType = "";
            string __TrisType = "";
            string __OpeningDirection = "";
            int __CircleDiameter = -1;
            int __CircleLocationFromBottom = -1;
            int __WindowHeight = -1;
            int __WindowWidth = -1;
            int __WindowPositionFromAbove = -1;
            int __WindowPositionFromHandle = -1;
            int __TrisHeight = -1;
            int __TrisWidth = -1;
            int __TrisPositionFromHandle = -1;
            int __TrisPositionFromAbove = -1;
            int __TrisPositionFromBottom = -1;
            int __WingID = -1;
            bool __WindoInCenter = false;
            bool __TrisInCenter = false;
            bool __AorHole = false;

            if (claDataAccessWingWindows.GetByID(__ID, ref __WindowType, ref __GlassType, ref __TrisType, ref __OpeningDirection, ref __CircleDiameter,
              ref  __CircleLocationFromBottom ,ref __WindowHeight,ref __WindowWidth,ref __WindowPositionFromAbove,ref __WindowPositionFromHandle,
              ref __TrisHeight,ref __TrisWidth,ref __TrisPositionFromHandle,ref __TrisPositionFromAbove,ref __TrisPositionFromBottom,ref __WingID,ref __WindoInCenter,ref __TrisInCenter
               ,ref __AorHole))
            {
                return new clsWingWindows(__ID, __WindowType, __GlassType, __TrisType, __OpeningDirection, __CircleDiameter,
                     __CircleLocationFromBottom, __WindowHeight, __WindowWidth, __WindowPositionFromAbove, __WindowPositionFromHandle,
                    __TrisHeight, __TrisWidth, __TrisPositionFromHandle, __TrisPositionFromAbove, __TrisPositionFromBottom, __WingID, __WindoInCenter, __TrisInCenter
                    , __AorHole);
            }
            else
            {

                return null;
            }


        }
        public static clsWingWindows FindByWingID(int __WingID)
        {
            int __ID = -1;
            string __WindowType = "";
            string __GlassType = "";
            string __TrisType = "";
            string __OpeningDirection = "";
            int __CircleDiameter = -1;
            int __CircleLocationFromBottom = -1;
            int __WindowHeight = -1;
            int __WindowWidth = -1;
            int __WindowPositionFromAbove = -1;
            int __WindowPositionFromHandle = -1;
            int __TrisHeight = -1;
            int __TrisWidth = -1;
            int __TrisPositionFromHandle = -1;
            int __TrisPositionFromAbove = -1;
            int __TrisPositionFromBottom = -1;
            bool __WindoInCenter = false;
            bool __TrisInCenter = false;
            bool __AorHole = false;


            if (claDataAccessWingWindows.GetByWingID(ref __ID, ref __WindowType, ref __GlassType, ref __TrisType, ref __OpeningDirection, ref __CircleDiameter,
              ref __CircleLocationFromBottom, ref __WindowHeight, ref __WindowWidth, ref __WindowPositionFromAbove, ref __WindowPositionFromHandle,
              ref __TrisHeight, ref __TrisWidth, ref __TrisPositionFromHandle, ref __TrisPositionFromAbove, ref __TrisPositionFromBottom,  __WingID,ref __WindoInCenter,ref __TrisInCenter
                ,ref __AorHole))
            {
                return new clsWingWindows(__ID, __WindowType, __GlassType, __TrisType, __OpeningDirection, __CircleDiameter,
                     __CircleLocationFromBottom, __WindowHeight, __WindowWidth, __WindowPositionFromAbove, __WindowPositionFromHandle,
                    __TrisHeight, __TrisWidth, __TrisPositionFromHandle, __TrisPositionFromAbove, __TrisPositionFromBottom, __WingID, __WindoInCenter, __TrisInCenter,
                    __AorHole);
            }
            else
            {

                return null;
            }


        }
        public void CopyWindoWing(int wingidnew)

        {
            this.ID = claDataAccessWingWindows.Add(this.WindowType, this.GlassType, this.TrisType, this.OpeningDirection, this.CircleDiameter, this.CircleLocationFromBottom, this.WindowHeight, this.WindowWidth,
                 this.WindowPositionFromAbove, this.WindowPositionFromHandle, this.TrisHeight, this.TrisWidth, this.TrisPositionFromHandle, this.TrisPositionFromAbove, this.TrisPositionFromBottom, wingidnew, this.WindoInCenter, this.TrisInCenter,
                 this.AorHole);

        }

            private bool _Add()
        {
            this.ID = claDataAccessWingWindows.Add(this.WindowType, this.GlassType, this.TrisType, this.OpeningDirection, this.CircleDiameter,this.CircleLocationFromBottom,this.WindowHeight,this.WindowWidth,
                this.WindowPositionFromAbove,this.WindowPositionFromHandle,this.TrisHeight,this.TrisWidth,this.TrisPositionFromHandle,this.TrisPositionFromAbove,this.TrisPositionFromBottom,this.WingID, this.WindoInCenter,this.TrisInCenter,
                this.AorHole);

            return (this.ID != -1);
        }

        private bool _Update()
        {

            return claDataAccessWingWindows.Update(this.ID, this.WindowType, this.GlassType, this.TrisType, this.OpeningDirection, this.CircleDiameter, this.CircleLocationFromBottom, this.WindowHeight, this.WindowWidth,
                this.WindowPositionFromAbove, this.WindowPositionFromHandle, this.TrisHeight, this.TrisWidth, this.TrisPositionFromHandle, this.TrisPositionFromAbove, this.TrisPositionFromBottom, this.WingID, this.WindoInCenter,this.TrisInCenter
                ,this.AorHole);


        }

        public bool Save()

        {

            switch (_mode)
            {

                case myMode.addNew:

                    if (_Add())
                    {
                        _mode = myMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case myMode.Update:
                    return _Update();
            }

            return false;

        }


        public static bool Delete(int ID)
        {
            return claDataAccessWingWindows.Delete(ID);
        }

        public static DataTable getAll()
        {
            return claDataAccessWingWindows.GetAll();
        }



        public static bool IsExist(int ID)
        {
            return claDataAccessWingWindows.IsExist(ID);
        }


        public void clear()
        {
         
            this.WindowType = "NoWin";
            this.GlassType = "Clear";
            this.TrisType = "NoTris";
            this.OpeningDirection = "In";
            this.CircleDiameter = 427;
            this.CircleLocationFromBottom = 1500;
            this.WindowHeight = -1;
            this.WindowWidth = -1;
            this.WindowPositionFromAbove = 150;
            this.WindowPositionFromHandle = 150;
            this.TrisHeight = -1;
            this.TrisWidth = -1;
            this.TrisPositionFromHandle = -1;
            this.TrisPositionFromAbove = -1;
            this.TrisPositionFromBottom = 150;
           
            this.WindoInCenter = true;
            this.TrisInCenter = true;
            this.AorHole = false;
            _mode = myMode.Update;
        }


    }
}
