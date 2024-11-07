using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsFrameUpperPart
    {



        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;

        public int ID { get; set; }
        public bool Kitum { get; set; }
        public bool Nerousta { get; set; }
        public int BottomSize { get; set; }
        public string upperPartType { get; set; }
        public int upperPartSize { get; set; }
        public int FrameID { get; set; }







        private clsFrameUpperPart(int id, bool kitum, bool nerousta, int bottomSize, 
            string UpperPartType, int UpperPartSize, int frameID)

        {
            this.ID = id;
            this.Kitum = kitum;
            this.Nerousta = nerousta;
            this.BottomSize = bottomSize;
            this.upperPartType = UpperPartType;
            this.upperPartSize = UpperPartSize;
           
            this.FrameID = frameID;

            this._Mode = _myMode.Update;

        }

        public clsFrameUpperPart()
        {

            this._Mode = _myMode.Addnew;

            this.ID = -1;
            this.Kitum = false;
            this.Nerousta = false;
            this.BottomSize = 0;
            this.upperPartSize = 0;
            this.upperPartType = "";
           
            this.FrameID = -1;


        }




        public static clsFrameUpperPart Find(int ID)
        {



            bool kitum = false;
            bool nerousta = false;
            int bottomSize = 0;
            int UpperPartSize = 0;
            string UpperPartType = "";
          
            int frameID = -1;



            if (clsDataAccessFrameUpperPart.GetFrameUpperPartByID(ID, ref kitum, ref nerousta,
            ref bottomSize, ref UpperPartType, ref UpperPartSize, ref frameID))
            {
                return new clsFrameUpperPart(ID,kitum,nerousta,bottomSize,UpperPartType,UpperPartSize,frameID);

            }
            else
            {
                return null;
            }

        }

        public static clsFrameUpperPart FindByFrameID(int frameID)
        {


            bool kitum = false;
            bool nerousta = false;
            int bottomSize = 0;
            int UpperPartSize = 0;
            string UpperPartType = "";

            int ID = -1;



            if (clsDataAccessFrameUpperPart.GetByFrameID(ref ID, ref kitum, ref nerousta,
            ref bottomSize, ref UpperPartType, ref UpperPartSize,  frameID))
            {
                return new clsFrameUpperPart(ID, kitum, nerousta, bottomSize, UpperPartType, UpperPartSize, frameID);

            }
            else
            {
                return null;
            }

        }



        private bool _AddNewPhone()
        {


            this.ID = clsDataAccessFrameUpperPart.Add(this.Kitum, this.Nerousta, this.BottomSize, this.upperPartType, this.upperPartSize, this.FrameID);

            return (this.ID != -1);
        }
        public int CopyFrameUpperPartFrames(int framId)
        {
            this.ID = clsDataAccessFrameUpperPart.Add(this.Kitum, this.Nerousta, this.BottomSize, this.upperPartType, this.upperPartSize, framId);

            return this.ID;
        }
        private bool _UpdatePhone()
        {


            return clsDataAccessFrameUpperPart.Update(this.ID, this.Kitum, this.Nerousta, this.BottomSize, this.upperPartType, this.upperPartSize, this.FrameID);

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
            return clsDataAccessFrameUpperPart.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessFrameUpperPart.GetAll();
        }

        public static bool IsExist(int ID)
        {
            return clsDataAccessFrameUpperPart.IsExist(ID);
        }

        public void clear()
        {
            this._Mode = _myMode.Update;

           
            this.Kitum = false;
            this.Nerousta = false;
            this.BottomSize = 0;
            this.upperPartSize = 0;
            this.upperPartType = "";

         
        }





    }
}
