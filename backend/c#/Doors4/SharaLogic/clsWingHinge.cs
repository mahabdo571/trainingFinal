using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsWingHinge
    {
        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;
        public int ID { get; set; }
        public int H1 { get; set; }
        public int H2 { get; set; }
        public int H3 { get; set; }
        public int H4 { get; set; }
        public int H5 { get; set; }
        public int H6 { get; set; }
        public int Amount { get; set; }
        public int Size { get; set; }
        public int HeightToBottomHinge { get; set; }
        public string HingeType { get; set; }
        public bool UpperMid { get; set; }
        public int WingID { get; set; }

        private clsWingHinge(int id,int h1,int h2,int h3,int h4,int h5,int h6 ,int amount ,int size,int htbh,string hingeType,bool uppermid,int wingid)
        {

            this.ID = id;
            this.H1 = h1;
            this.H2 = h2;
            this.H3 = h3;
            this.H4 = h4;
            this.H5 = h5;
            this.H6 = h6;
            this.Amount = amount;
            this.Size = size;
            this.HeightToBottomHinge = htbh;
            this.HingeType = hingeType;
            this.UpperMid = uppermid;
            this.WingID = wingid;

            this._Mode = _myMode.Update;

        }

        public clsWingHinge()
        {
            this.ID = -1;
            this.H1 = -1;
            this.H2 = -1;
            this.H3 = -1;
            this.H4 = -1;
            this.H5 = -1;
            this.H6 = -1;
            this.Amount = -1;
            this.Size = -1;
            this.HeightToBottomHinge = -1;
            this.HingeType = "";
            this.UpperMid = false;
            this.WingID = -1;

            this._Mode = _myMode.Addnew;
        }


        public static clsWingHinge Find(int ID)
        {


     
           int __H1 = -1;
           int __H2 = -1;
           int __H3 = -1;
           int __H4 = -1;
           int __H5 = -1;
           int __H6 = -1;
           int __Amount = -1;
           int __Size = -1;
           int __HeightToBottomHinge = -1;
           string __HingeType = "";
           bool __UpperMid = false;
           int __WingID = -1;

            if (clsDataAccessWingHinge.GetByID(ID,ref __H1,ref __H2,ref __H3,ref __H4,ref __H5,ref __H6,ref __Amount, ref __Size, ref __HeightToBottomHinge,
            ref __HingeType, ref __UpperMid, ref __WingID))
            {
                return new clsWingHinge(ID,  __H1,  __H2,  __H3,  __H4,  __H5,  __H6,  __Amount,  __Size,  __HeightToBottomHinge,
             __HingeType,  __UpperMid,  __WingID);

            }
            else
            {
                return null;
            }

        }


        public static clsWingHinge FindByWingID(int WingID)
        {



            int __H1 = -1;
            int __H2 = -1;
            int __H3 = -1;
            int __H4 = -1;
            int __H5 = -1;
            int __H6 = -1;
            int __Amount = -1;
            int __Size = -1;
            int __HeightToBottomHinge = -1;
            string __HingeType = "";
            bool __UpperMid = false;
            int __ID = -1;

            if (clsDataAccessWingHinge.GetByWingID(ref __ID, ref __H1, ref __H2, ref __H3, ref __H4, ref __H5, ref __H6, ref __Amount, ref __Size, ref __HeightToBottomHinge,
            ref __HingeType, ref __UpperMid,  WingID))
            {
                return new clsWingHinge(__ID, __H1, __H2, __H3, __H4, __H5, __H6, __Amount, __Size, __HeightToBottomHinge,
             __HingeType, __UpperMid, WingID);

            }
            else
            {
                return null;
            }

        }

        public void CopyHingWing(int IDWing)
        {
            this.ID = clsDataAccessWingHinge.Add(this.H1, this.H2, this.H3, this.H4, this.H5, this.H6, this.Amount, this.Size, this.HeightToBottomHinge, this.HingeType, this.UpperMid, IDWing);

        }


        private bool _AddNew()
        {


            this.ID = clsDataAccessWingHinge.Add(this.H1, this.H2, this.H3, this.H4, this.H5, this.H6,this.Amount,this.Size,this.HeightToBottomHinge,this.HingeType,this.UpperMid,this.WingID);

            return (this.ID != -1);
        }

        private bool _Update()
        {


            return clsDataAccessWingHinge.Update(this.ID, this.H1, this.H2, this.H3, this.H4, this.H5, this.H6, this.Amount, this.Size, this.HeightToBottomHinge, this.HingeType, this.UpperMid, this.WingID);

        }


        public bool Save()

        {

            switch (_Mode)
            {

                case _myMode.Addnew:

                    if (_AddNew())
                    {
                        _Mode = _myMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case _myMode.Update:
                    return _Update();
            }

            return false;

        }


        public static bool Delete(int ID)
        {
            return clsDataAccessWingHinge.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessWingHinge.GetAll();
        }

        public static bool IsExist(int ID)
        {
            return clsDataAccessWingHinge.IsExist(ID);
        }

        public void clear()
        {
      
            this.H1 = 165;
            this.H2 = 952;
            this.H3 = 1740;
            this.H4 = -1;
            this.H5 = -1;
            this.H6 = -1;
            this.Amount = 3;
            this.Size = -1;
            this.HeightToBottomHinge = -1;
            this.HingeType = "";
            this.UpperMid = false;
            

            this._Mode = _myMode.Update;

        } 
        
        public void copyfrom(clsWingHinge hing)
        {
      
            this.H1 = hing.H1;
            this.H2 = hing.H2;
            this.H3 = hing.H3;
            this.H4 = hing.H4;
            this.H5 = hing.H5;
            this.H6 = hing.H6;
            this.Amount = hing.Amount;
            this.Size = hing.Size;
            this.HeightToBottomHinge = hing.HeightToBottomHinge;
            this.HingeType = hing.HingeType;
            this.UpperMid = hing.UpperMid;
            

        

        }
    }
}
