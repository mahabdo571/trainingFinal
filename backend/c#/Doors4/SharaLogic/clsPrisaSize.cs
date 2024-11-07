using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsPrisaSize
    {


        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;

        public int ID { get; set; }
        public int FrameID { get; set; }
        public decimal PRT1 { get; set; }
        public decimal PRT2 { get; set; }
        public decimal PRT3 { get; set; }
        public decimal PRT4 { get; set; }








        private clsPrisaSize(int id,int FrameID_, decimal PRT1_, decimal PRT2_, decimal PRT3_, decimal PRT4_)

        {
            this.ID = id;
            this.FrameID = FrameID_;
            this.PRT1 = PRT1_;
            this.PRT2 = PRT2_;
            this.PRT3 = PRT3_;
            this.PRT4 = PRT4_;

            this._Mode = _myMode.Update;
   
        }

        public clsPrisaSize()
        {

            this._Mode = _myMode.Addnew;

            this.ID = -1;
            this.FrameID = -1;
            this.PRT1 = 0;
            this.PRT2 = 0;
            this.PRT3 = 0;
            this.PRT4 = 0;




        }




        public static clsPrisaSize FindByFrameID(int FrameID_)
        {


            int ID_ = -1;
            decimal PRT1_ = 0;
            decimal PRT2_ = 0;
            decimal PRT3_ = 0;
            decimal PRT4_ = 0;




            if (clsPrisaSizeDA.GetByFrameID(FrameID_,ref PRT1_,ref PRT2_,ref PRT3_,ref PRT4_,ref ID_))
            {
                return new clsPrisaSize(ID_ ,FrameID_,  PRT1_,  PRT2_,  PRT3_,  PRT4_);

            }
            else
            {
                return null;
            }

        }



        private bool _AddNewPhone()
        {


            this.ID = clsPrisaSizeDA.Add(this.FrameID,this.PRT1,this.PRT2,this.PRT3,this.PRT4);

            return (this.ID != -1);
        }

        private bool _UpdatePhone()
        {


            return clsPrisaSizeDA.Update(this.ID, this.FrameID, this.PRT1, this.PRT2, this.PRT3, this.PRT4);

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
            return clsPrisaSizeDA.Delete(ID);
        }



 


 



        public static DataTable GruopPrisaSizesHeight(int OrderID, string FrameType)
        {

            return clsPrisaSizeDA.GruopPrisaSizesHeight(OrderID, FrameType);
        
        }  
        public static DataTable GruopPrisaSizesWidth(int OrderID, string FrameType)
        {

            return clsPrisaSizeDA.GruopPrisaSizesWidth(OrderID, FrameType);
        
        }  
        
        public static DataTable GetAmountRLPrisaSizes(int OrderID, string FrameType)
        {

            return clsPrisaSizeDA.GetAmountRLPrisaSizes(OrderID, FrameType);
        
        }

        }
}
