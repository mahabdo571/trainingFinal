using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public  class clsFrameLockType
    {

       



        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;

        public int ID { get; set; }
        public string LockType { get; set; }
        public int LockMeasure { get; set; }
        public int LockMeasureFloor { get; set; }
        public int UpperLockMeasure { get; set; }
        public int UpperLockMeasureFloor { get; set; }
        public int FrameHiegth { get; set; }
        public int FrameId { get; set; }
        public bool NoCalcu { get; set; }
        public bool SlipCan { get; set; }





         

        private clsFrameLockType(int id, string lockType, int lockMeasure, int lockMeasureFloor, int upperLockMeasure, int upperLockMeasureFloor,int frameHiegth,int frameId,bool noCalcu,bool slipCan)

        {
            this.ID = id;
            this.LockType = lockType;
            this.LockMeasure = lockMeasure;
            this.LockMeasureFloor = lockMeasureFloor;
            this.UpperLockMeasure = upperLockMeasure;
            this.UpperLockMeasureFloor = upperLockMeasureFloor;
            this.FrameHiegth = frameHiegth;
            this.FrameId = frameId;
            this.NoCalcu = noCalcu;
            this.SlipCan = slipCan;

            this._Mode = _myMode.Update;

        }

        public clsFrameLockType()
        {

            this._Mode = _myMode.Addnew;

            this.ID = -1;
            this.LockType = "";
            this.LockMeasure = -1;
            this.LockMeasureFloor = -1;
            this.UpperLockMeasure = -1;
            this.UpperLockMeasureFloor = -1;
            this.FrameHiegth = -1;
            this.FrameId = -1;
            this.NoCalcu = false;
            this.SlipCan = false;


        }




        public static clsFrameLockType Find(int ID)
        {


           
          string lockType = "";
         int lockMeasure = -1;
         int  lockMeasureFloor = -1;
         int upperLockMeasure = -1;
         int upperLockMeasureFloor = -1;
         int frameHiegth = -1;
         int frameId = -1;
         bool noCalcu = false;
         bool slipCan = false;



            if (clsDataAccessFrameLockType.GetFrameLockTypeByID(ID, ref lockType, ref lockMeasure,
            ref lockMeasureFloor, ref upperLockMeasure, ref upperLockMeasureFloor,ref frameHiegth,ref frameId,ref noCalcu,ref slipCan))
            {
                return new clsFrameLockType(ID, lockType, lockMeasure,
             lockMeasureFloor, upperLockMeasure, upperLockMeasureFloor,frameHiegth,frameId, noCalcu, slipCan);

            }
            else
            {
                return null;
            }

        }

        public static clsFrameLockType FindByFrameID(int FrameID)
        {


            string lockType = "";
            int lockMeasure = -1;
            int lockMeasureFloor = -1;
            int upperLockMeasure = -1;
            int upperLockMeasureFloor = -1;
            int frameHiegth = -1;
            int ID = -1;
            bool noCalcu = false;
            bool slipCan = false;


            if (clsDataAccessFrameLockType.GetByFrameID(ref ID, ref lockType, ref lockMeasure,
            ref lockMeasureFloor, ref upperLockMeasure,ref upperLockMeasureFloor,ref frameHiegth,FrameID,ref noCalcu,ref slipCan))
            {
                return new clsFrameLockType(ID, lockType, lockMeasure,
             lockMeasureFloor, upperLockMeasure, upperLockMeasureFloor, frameHiegth, FrameID, noCalcu, slipCan);

            }
            else
            {
                return null;
            }

        }



        private bool _AddNewPhone()
        {


            this.ID = clsDataAccessFrameLockType.Add(this.LockType, this.LockMeasure, this.LockMeasureFloor, this.UpperLockMeasure, this.UpperLockMeasureFloor,FrameHiegth,FrameId,this.NoCalcu,this.SlipCan);

            return (this.ID != -1);
        }

        public int CopyFrameLockTypeFrames(int frimid)
        {
            this.ID = clsDataAccessFrameLockType.Add(this.LockType, this.LockMeasure, this.LockMeasureFloor, this.UpperLockMeasure, this.UpperLockMeasureFloor, FrameHiegth, frimid,this.NoCalcu,this.SlipCan);


            return this.ID;
        }
        private bool _UpdatePhone()
        {


            return clsDataAccessFrameLockType.Update(this.ID, this.LockType, this.LockMeasure, this.LockMeasureFloor, this.UpperLockMeasure, this.UpperLockMeasureFloor, FrameHiegth, FrameId,this.NoCalcu,this.SlipCan);

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


        public static bool Delete(int ID)
        {
            return clsDataAccessFrameLockType.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessFrameLockType.GetAll();
        }

        public static bool IsExist(int ID)
        {
            return clsDataAccessFrameLockType.IsExist(ID);
        }


        public void clear()
        {

            this._Mode = _myMode.Update;

   
            this.LockType = "Sharabany";
            this.LockMeasure = 970;
            this.LockMeasureFloor = -1;
            this.UpperLockMeasure = -1;
            this.UpperLockMeasureFloor = -1;
            this.FrameHiegth = -1;
            this.NoCalcu = true;
            this.SlipCan = true;
        }





    }
}
