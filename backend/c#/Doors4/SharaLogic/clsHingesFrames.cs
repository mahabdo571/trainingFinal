using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsHingesFrames
    {

     
        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;

        public int ID { get; set; }
        public int HingeDimension { get; set; }
        public int Hinge1 { get; set; }
        public int Hinge2 { get; set; }
        public int Hinge3 { get; set; }
        public int Hinge4 { get; set; }
        public int Hinge5 { get; set; }
        public int Hinge6 { get; set; }
        public int HeightToBottomHinge { get; set; }
        public int HingeAmount { get; set; }
        public bool TopMeddleHinge { get; set; }
        public bool NoCalcu { get; set; }
        public string HingeMetal { get; set; }
        public string HingeType { get; set; }
        public string HingeConnection { get; set; }
        public int FrameID { get; set; }







        private clsHingesFrames(int id, int hingeDimension, int h1, int h2, int h3, int h4, int h5,int h6,int heightToBottomHinge,

            int hingeAmount,bool topMeddleHinge,string hingeMetal,string hingeType,string hingeConnection,int frameID, bool noCalcu
)

        {
            this.ID = id;
            this.HingeDimension = hingeDimension;
            this.Hinge1 = h1;
            this.Hinge2 = h2;
            this.Hinge3 = h3;
            this.Hinge4 = h4;
            this.Hinge5 = h5;
            this.Hinge6 = h6;
            this.HeightToBottomHinge = heightToBottomHinge;
            this.HingeAmount = hingeAmount;
            this.TopMeddleHinge = topMeddleHinge;
            this.HingeMetal = hingeMetal;
            this.HingeType = hingeType;
            this.HingeConnection = hingeConnection;
            this.FrameID = frameID;
            this.NoCalcu = noCalcu;



            this._Mode = _myMode.Update;

        }

        public clsHingesFrames()
        {

            this._Mode = _myMode.Addnew;

            this.ID = -1;
            this.HingeDimension = -1;
            this.Hinge1 = -1;
            this.Hinge2 =-1;
            this.Hinge3 = -1;
            this.Hinge4 = -1;
            this.Hinge5 =-1;
            this.Hinge6 = -1;
            this.FrameID = -1;
            this.HeightToBottomHinge = -1;
            this.HingeAmount = -1;
            this.TopMeddleHinge =false;
            this.HingeMetal = "";
            this.HingeType = "";
            this.HingeConnection = "";
            this.NoCalcu =false;
          



        }



        public static clsHingesFrames Find(int id)
        {



            int hingeDimension = -1;
            int h1 = -1;
            int h2 =-1;
            int h3 = -1;
            int h4 = -1;
            int h5 = -1;
            int h6 = -1;
            int frameID = -1;
            int heightToBottomHinge = -1;
            int hingeAmount = -1;
            bool topMeddleHinge = false;
            bool noCalcu = false;
            string  hingeMetal = "";
            string hingeType = "";
            string hingeConnection = "";


            if (clsDataAccessHingesFrames.GetHingesFramesByID(id, ref hingeDimension, ref h1, ref h2, ref h3, ref h4, ref h5,ref h6,ref heightToBottomHinge,
                ref hingeAmount,ref topMeddleHinge,ref hingeMetal,ref hingeType,ref hingeConnection,ref frameID,ref noCalcu))
            {
                return new clsHingesFrames(id, hingeDimension, h1, h2, h3, h4, h5,h6, heightToBottomHinge, hingeAmount,topMeddleHinge, hingeMetal, hingeType, hingeConnection, frameID,noCalcu);

            }
            else
            {
                return null;
            }

        }


        public static clsHingesFrames FindByFrameID(int frameID)
        {



            int hingeDimension = -1;
            int h1 = -1;
            int h2 = -1;
            int h3 = -1;
            int h4 = -1;
            int h5 = -1;
            int h6 = -1;
            int ID = -1;
            int heightToBottomHinge = -1;
            int hingeAmount = -1;
            bool topMeddleHinge = false;
            bool noCalcu = false;
            string hingeMetal = "";
            string hingeType = "";
            string hingeConnection = "";


            if (clsDataAccessHingesFrames.GetByFrameID(ref ID, ref hingeDimension, ref h1, ref h2, ref h3, ref h4, ref h5, ref h6, ref heightToBottomHinge,
                ref hingeAmount, ref topMeddleHinge, ref hingeMetal, ref hingeType, ref hingeConnection,  frameID,ref noCalcu))
            {
                return new clsHingesFrames(ID, hingeDimension, h1, h2, h3, h4, h5, h6, heightToBottomHinge, hingeAmount, topMeddleHinge, hingeMetal, hingeType, hingeConnection, frameID,noCalcu);

            }
            else
            {
                return null;
            }

        }


        private bool _AddNewPhone()
        {


            this.ID = clsDataAccessHingesFrames.Add(this.HingeDimension, this.Hinge1, this.Hinge2, this.Hinge3, this.Hinge4, this.Hinge5,this.Hinge6
                ,this.HeightToBottomHinge,this.HingeAmount,this.TopMeddleHinge,this.HingeMetal,this.HingeType,this.HingeConnection,this.FrameID,this.NoCalcu

                );

            return (this.ID != -1);
        }
        public int CopyHingesFrames(int frimid)
        {

            this.ID = clsDataAccessHingesFrames.Add(this.HingeDimension, this.Hinge1, this.Hinge2, this.Hinge3, this.Hinge4, this.Hinge5, this.Hinge6
                        , this.HeightToBottomHinge, this.HingeAmount, this.TopMeddleHinge, this.HingeMetal, this.HingeType, this.HingeConnection, frimid,this.NoCalcu

                        );

            return this.ID;
        }
        private bool _UpdatePhone()
        {


            return clsDataAccessHingesFrames.Update(this.ID, this.HingeDimension, this.Hinge1, this.Hinge2,
                this.Hinge3, this.Hinge4, this.Hinge5,this.Hinge6
                        , this.HeightToBottomHinge, this.HingeAmount, this.TopMeddleHinge, this.HingeMetal, this.HingeType, this.HingeConnection
                ,this.FrameID,this.NoCalcu
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


        public static bool Delete(int ID)
        {
            return clsDataAccessHingesFrames.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessHingesFrames.GetAll();
        }

        public static bool IsExist(int ID)
        {
            return clsDataAccessHingesFrames.IsExist(ID);
        }

        public void clear()
        {
            this._Mode = _myMode.Update;

          
            this.HingeDimension = -1;
            this.Hinge1 = 169;
            this.Hinge2 = 956;
            this.Hinge3 = 1744;
            this.Hinge4 = -1;
            this.Hinge5 = -1;
            this.Hinge6 = -1;
   
            this.HeightToBottomHinge = -1;
            this.HingeAmount = 3;
            this.TopMeddleHinge = false;
            this.HingeMetal = "";
            this.HingeType = "";
            this.HingeConnection = "";
            this.NoCalcu = true;
        }



    }
}
