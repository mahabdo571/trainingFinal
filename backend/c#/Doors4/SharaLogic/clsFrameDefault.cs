using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsFrameDefault
    {
        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Dec { get; set; }
        public decimal A1 { get; set; }
        public decimal A2 { get; set; }
        public decimal B1 { get; set; }
        public decimal B2 { get; set; }
        public decimal C1 { get; set; }
        public decimal C2 { get; set; }
        public decimal D1 { get; set; }
        public decimal D2 { get; set; }
        public decimal E1 { get; set; }
        public decimal E2 { get; set; }
        public decimal F1 { get; set; }
        public decimal F2 { get; set; }
        public decimal G1 { get; set; }
        public decimal G2 { get; set; }
        public decimal Bends { get; set; }
        public decimal F1A { get; set; }
        public decimal F1B { get; set; }
        public decimal F2A { get; set; }
        public decimal F2B { get; set; }
        public decimal MG { get; set; }
        public decimal K125 { get; set; }
        public decimal K15 { get; set; }
        public decimal K2 { get; set; }


        private clsFrameDefault(
                 int ID_,
            string Name_,
             string Dec_,
             decimal A1_,
             decimal A2_,
             decimal B1_,
             decimal B2_,
             decimal C1_,
             decimal C2_,
             decimal D1_,
             decimal D2_,
             decimal E1_,
             decimal E2_,
             decimal F1_,
             decimal F2_,
             decimal G1_,
             decimal G2_,
             decimal Bends_,
             decimal F1A_,
             decimal F1B_,
             decimal F2A_,
             decimal F2B_,
             decimal MG_,
             decimal K125_,
             decimal K15_,
             decimal K2_


            )
        {


            this.ID = ID_;
            this.Name = Name_;
            this.Dec = Dec_;
            this.A1 = A1_;
            this.A2 = A2_;
            this.B1 = B1_;
            this.B2 = B2_;
            this.C1 = C1_;
            this.C2 = C2_;
            this.D1 = D1_;
            this.D2 = D2_;
            this.E1 = E1_;
            this.E2 = E2_;
            this.F1 = F1_;
            this.F2 = F2_;
            this.G1 = G1_;
            this.G2 = G2_;
            this.Bends = Bends_;
            this.F1A = F1A_;
            this.F1B = F1B_;
            this.F2A = F2A_;
            this.F2B = F2B_;
            this.MG = MG_;
            this.K125 = K125_;
            this.K15 = K15_;
            this.K2 = K2_;
            _Mode = _myMode.Update;


        }

        public clsFrameDefault()
        {
            this.ID = -1;
            this.Name = "";
            this.Dec = "";
            this.A1 = 0;
            this.A2 = 0;
            this.B1 = 0;
            this.B2 = 0;
            this.C1 = 0;
            this.C2 = 0;
            this.D1 = 0;
            this.D2 = 0;
            this.E1 = 0;
            this.E2 = 0;
            this.F1 = 0;
            this.F2 = 0;
            this.G1 = 0;
            this.G2 = 0;
            this.Bends = 0;
            this.F1A = 0;
            this.F1B = 0;
            this.F2A = 0;
            this.F2B = 0;
            this.MG = 0;
            this.K125 = 0;
            this.K15 = 0;
            this.K2 = 0;

            this._Mode = _myMode.Addnew;
        }

        public static clsFrameDefault Find(int id)
        {



            string Name_ = "";
            string Dec_ = "";
            decimal A1_ = 0;
            decimal A2_ = 0;
            decimal B1_ = 0;
            decimal B2_ = 0;
            decimal C1_ = 0;
            decimal C2_ = 0;
            decimal D1_ = 0;
            decimal D2_ = 0;
            decimal E1_ = 0;
            decimal E2_ = 0;
            decimal F1_ = 0;
            decimal F2_ = 0;
            decimal G1_ = 0;
            decimal G2_ = 0;
            decimal Bends_ = 0;
            decimal F1A_ = 0;
            decimal F1B_ = 0;
            decimal F2A_ = 0;
            decimal F2B_ = 0;
            decimal MG_ = 0;
            decimal K125_ = 0;
            decimal K15_ = 0;
            decimal K2_ = 0;

            if (clsFrameDefaultDataAccess.GetByID(id,

ref Name_,
 ref Dec_,
 ref A1_,
 ref A2_,
 ref B1_,
 ref B2_,
 ref C1_,
 ref C2_,
 ref D1_,
 ref D2_,
 ref E1_,
 ref E2_,
 ref F1_,
 ref F2_,
 ref G1_,
 ref G2_,
 ref Bends_,
 ref F1A_,
 ref F1B_,
 ref F2A_,
 ref F2B_,
 ref MG_,
 ref K125_,
 ref K15_,
 ref K2_


                ))
            {
                return new clsFrameDefault(id,

 Name_,
  Dec_,
  A1_,
  A2_,
  B1_,
  B2_,
  C1_,
  C2_,
  D1_,
  D2_,
  E1_,
  E2_,
  F1_,
  F2_,
  G1_,
  G2_,
  Bends_,
  F1A_,
  F1B_,
  F2A_,
  F2B_,
  MG_,
  K125_,
  K15_,
  K2_

                    );

            }
            else
            {
                return null;
            }

        }



        private bool _AddNew()
        {


            this.ID = clsFrameDefaultDataAccess.Add(
            
            this.Name ,
            this.Dec ,
            this.A1  ,
            this.A2  ,
            this.B1  ,
            this.B2  ,
            this.C1  ,
            this.C2  ,
            this.D1  ,
            this.D2  ,
            this.E1  ,
            this.E2  ,
            this.F1  ,
            this.F2  ,
            this.G1  ,
            this.G2  ,
            this.Bends  ,
            this.F1A  ,
            this.F1B  ,
            this.F2A  ,
            this.F2B  ,
            this.MG  ,
            this.K125  ,
            this.K15  ,
            this.K2  
                
                );

            return (this.ID != -1);
        }

        private bool _Update()
        {


            return clsFrameDefaultDataAccess.Update(this.ID,

            this.Name,
            this.Dec,
            this.A1,
            this.A2,
            this.B1,
            this.B2,
            this.C1,
            this.C2,
            this.D1,
            this.D2,
            this.E1,
            this.E2,
            this.F1,
            this.F2,
            this.G1,
            this.G2,
            this.Bends,
            this.F1A,
            this.F1B,
            this.F2A,
            this.F2B,
            this.MG,
            this.K125,
            this.K15,
            this.K2
                );

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
            return clsFrameDefaultDataAccess.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsFrameDefaultDataAccess.getAll();
        }

        public static bool IsExist(int ID)
        {
            return clsFrameDefaultDataAccess.IsExist(ID);
        }

    }
}
