using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsFrameType
    {




        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;

        public int ID { get; set; }
        public string AgroupOfDoorFrames { get; set; }
        public string TypeOfDoorFrame { get; set; }
        public string LevelType { get; set; }
        public string WallType { get; set; }

        public int FrameID { get; set; }







        private clsFrameType(int id, string agroupOfDoorFrames, string typeOfDoorFrame, string levelType, string wallType, int frameID)

        {
            this.ID = id;
            this.AgroupOfDoorFrames = agroupOfDoorFrames;
            this.TypeOfDoorFrame = typeOfDoorFrame;
            this.LevelType = levelType;
            this.FrameID = frameID;
            this.WallType = wallType;

            this._Mode = _myMode.Update;

        }

        public clsFrameType()
        {

            this._Mode = _myMode.Addnew;

            this.ID = -1;
            this.AgroupOfDoorFrames = "";
            this.TypeOfDoorFrame = "";
            this.LevelType = "";
            this.FrameID = -1;
            this.WallType = "";


        }




        public static clsFrameType Find(int ID)
        {


            string typeOfDoorFrame = "";
            string levelType = "";
            int frameID = -1;
            string wallType = "";
            string agroupOfDoorFrames = "";

            if (clsDataAccessFrameType.GetFrameTypeByID(ID, ref agroupOfDoorFrames, ref typeOfDoorFrame,
            ref levelType, ref wallType, ref frameID))
            {
                return new clsFrameType(ID,agroupOfDoorFrames , typeOfDoorFrame,
             levelType, wallType, frameID);

            }
            else
            {
                return null;
            }

        }
        
        public static clsFrameType FindByFrameID(int FrameID)
        {


            string typeOfDoorFrame = "";
            string levelType = "";
            int ID = -1;
            string wallType = "";
            string agroupOfDoorFrames = "";

            if (clsDataAccessFrameType.GetByFrameID(ref ID, ref agroupOfDoorFrames, ref typeOfDoorFrame,
            ref levelType, ref wallType, FrameID))
            {
                return new clsFrameType(ID,agroupOfDoorFrames , typeOfDoorFrame,
             levelType, wallType,FrameID);

            }
            else
            {
                return null;
            }

        }



        private bool _AddNewPhone()
        {


            this.ID = clsDataAccessFrameType.Add(this.AgroupOfDoorFrames, this.TypeOfDoorFrame, this.LevelType, this.WallType, this.FrameID);

            return (this.ID != -1);
        }

        private bool _UpdatePhone()
        {


            return clsDataAccessFrameType.Update(this.ID, this.AgroupOfDoorFrames, this.TypeOfDoorFrame, this.LevelType, this.WallType, this.FrameID);

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
        public void CopyTypeFrame(int FrameID)

        {
            this.ID = clsDataAccessFrameType.Add(this.AgroupOfDoorFrames, this.TypeOfDoorFrame, this.LevelType, this.WallType, FrameID);

        }


        public static bool Delete(int ID)
        {
            return clsDataAccessFrameType.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessFrameType.GetAll();
        }

        public static bool IsExist(int ID)
        {
            return clsDataAccessFrameType.IsExist(ID);
        }

        public void clear()
        {
            this._Mode = _myMode.Update;

            this.AgroupOfDoorFrames = "";
            this.TypeOfDoorFrame = "";
            this.LevelType = "";
     
            this.WallType = "";
        }






    }
}
