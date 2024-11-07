using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsWingLock
    {
        enum myMode { addNew = 1, Update = 2 }

        myMode _mode = myMode.addNew;

        public int ID { get; set; } 
         public  string LockType{ get; set; } 
         public  bool UpperLock{ get; set; } 
         public  int LockMeasure{ get; set; } 
         public  int UpperLockMeasure{ get; set; } 
         public  int LockMeasureFrame{ get; set; } 
         public  int UpperLockMeasureFrame{ get; set; } 
         public int WingID{ get; set; }

        private clsWingLock(int iD, string lockType, bool upperLock, int lockMeasure, int upperLockMeasure, int lockMeasureFrame, int upperLockMeasureFrame, int wingID)
        {
            this.ID = iD;
            this.LockType = lockType;
            this.UpperLock = upperLock;
            this.LockMeasure = lockMeasure;
            this.UpperLockMeasure = upperLockMeasure;
            this.LockMeasureFrame = lockMeasureFrame;
            this.UpperLockMeasureFrame = upperLockMeasureFrame;
            this.WingID = wingID;

            _mode = myMode.Update;
        }

        public clsWingLock()
        {
            this.ID = -1;
            this.LockType = "";
            this.UpperLock = false;
            this.LockMeasure = -1;
            this.UpperLockMeasure = -1;
            this.LockMeasureFrame = -1;
            this.UpperLockMeasureFrame = -1;
            this.WingID = -1;

            _mode = myMode.addNew;
        }

        public static clsWingLock Find(int __ID)
        {
           string __LockType = "";
           bool __UpperLock = false;
           int __LockMeasure = -1;
           int __UpperLockMeasure = -1;
           int __LockMeasureFrame = -1;
           int __UpperLockMeasureFrame = -1;
           int __WingID = -1;

            if (clsDataAccessWingLock.GetByID(__ID, ref __LockType, ref __UpperLock, ref __LockMeasure, ref __UpperLockMeasure, ref __LockMeasureFrame,ref __UpperLockMeasureFrame,ref __WingID))
            {
                return new clsWingLock(__ID,  __LockType,  __UpperLock,  __LockMeasure,  __UpperLockMeasure,  __LockMeasureFrame,  __UpperLockMeasureFrame,  __WingID);
            }
            else
            {

                return null;
            }


        }
        public static clsWingLock FindByWingID(int wingid)
        {
            string __LockType = "";
            bool __UpperLock = false;
            int __LockMeasure = -1;
            int __UpperLockMeasure = -1;
            int __LockMeasureFrame = -1;
            int __UpperLockMeasureFrame = -1;
            int __ID = -1;

            if (clsDataAccessWingLock.GetByWingID(ref __ID, ref __LockType, ref __UpperLock, ref __LockMeasure, ref __UpperLockMeasure, ref __LockMeasureFrame, ref __UpperLockMeasureFrame, wingid))
            {
                return new clsWingLock(__ID, __LockType, __UpperLock, __LockMeasure, __UpperLockMeasure, __LockMeasureFrame, __UpperLockMeasureFrame, wingid);
            }
            else
            {

                return null;
            }

        }
        public void CopyLockWing(int IDWing)
        {
            this.ID = clsDataAccessWingLock.Add(this.LockType, this.UpperLock, this.LockMeasure, this.UpperLockMeasure, this.LockMeasureFrame, this.UpperLockMeasureFrame, IDWing);

        }
        private bool _Add()
        {
            this.ID = clsDataAccessWingLock.Add(this.LockType, this.UpperLock,this.LockMeasure, this.UpperLockMeasure, this.LockMeasureFrame,this.UpperLockMeasureFrame,this.WingID);

            return (this.ID != -1);
        }

        private bool _Update()
        {

            return clsDataAccessWingLock.Update(this.ID, this.LockType, this.UpperLock, this.LockMeasure, this.UpperLockMeasure, this.LockMeasureFrame, this.UpperLockMeasureFrame, this.WingID);


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
            return clsDataAccessWingLock.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessWingLock.GetAll();
        }



        public static bool IsExist(int ID)
        {
            return clsDataAccessWingLock.IsExist(ID);
        }

        public void clear()
        {
          
            this.LockType = "shar60";
            this.UpperLock = false;
            this.LockMeasure =1012;
            this.UpperLockMeasure = -1;
            this.LockMeasureFrame = -1;
            this.UpperLockMeasureFrame = -1;
   

            _mode = myMode.Update;
        }

    }
}
