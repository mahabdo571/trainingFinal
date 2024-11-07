using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsPrisa
    {
        enum Mode { Add = 0, Update = 1 };

        Mode _mode = Mode.Add;

        public int ID { get; set; }
        public decimal magnet { get; set; }
        public decimal corner1 { get; set; }
        public decimal corner2 { get; set; }
        public decimal corner3 { get; set; }
        public decimal corner4 { get; set; }
        public decimal corner5 { get; set; }
        public decimal corner6 { get; set; }
        public decimal corner7 { get; set; }
        public decimal corner8 { get; set; }
        public decimal corner9 { get; set; }
        public decimal corner10 { get; set; }
        public decimal corner11 { get; set; }
        public decimal corner12 { get; set; }
        public decimal corner13 { get; set; }
        public decimal corner14 { get; set; }
        public decimal corner15 { get; set; }
        public decimal corner16 { get; set; }
        public decimal corner17 { get; set; }
        public decimal corner18 { get; set; }
        public decimal corner19 { get; set; }
        public decimal corner20 { get; set; }
        public int FrameID { get; set; }

        private clsPrisa(
               int id,
                 decimal __magnet
               , decimal __corner1
               , decimal __corner2
               , decimal __corner3
               , decimal __corner4
               , decimal __corner5
               , decimal __corner6
               , decimal __corner7
               , decimal __corner8
               , decimal __corner9
               , decimal __corner10
               , decimal __corner11
               , decimal __corner12
               , decimal __corner13
               , decimal __corner14
               , decimal __corner15
               , decimal __corner16
               , decimal __corner17
               , decimal __corner18
               , decimal __corner19
               , decimal __corner20
               , int __FrameID

                )
        {
            this.ID = id;
            this.magnet = __magnet;
            this.corner1 = __corner1;
            this.corner2 = __corner2;
            this.corner3 = __corner3;
            this.corner4 = __corner4;
            this.corner5 = __corner5;
            this.corner6 = __corner6;
            this.corner7 = __corner7;
            this.corner8 = __corner8;
            this.corner9 = __corner9;
            this.corner10 = __corner10;
            this.corner11 = __corner11;
            this.corner12 = __corner12;
            this.corner13 = __corner13;
            this.corner14 = __corner14;
            this.corner15 = __corner15;
            this.corner16 = __corner16;
            this.corner17 = __corner17;
            this.corner18 = __corner18;
            this.corner19 = __corner19;
            this.corner20 = __corner20;
            this.FrameID = __FrameID;
            this._mode = Mode.Update;
        }

        public clsPrisa()
        {
            this.ID = 0;
            this.magnet = 0;
            this.corner1 = 0;
            this.corner2 = 0;
            this.corner3 = 0;
            this.corner4 = 0;
            this.corner5 = 0;
            this.corner6 = 0;
            this.corner7 = 0;
            this.corner8 = 0;
            this.corner9 = 0;
            this.corner10 = 0;
            this.corner11 = 0;
            this.corner12 = 0;
            this.corner13 = 0;
            this.corner14 = 0;
            this.corner15 = 0;
            this.corner16 = 0;
            this.corner17 = 0;
            this.corner18 = 0;
            this.corner19 = 0;
            this.corner20 = 0;
            this.FrameID = 0;
            this._mode = Mode.Add;
        }
        

        public static clsPrisa findbyFrameid(int idframe)
        {
            int id = 0; 
            
            if(clsdataAccessPrisa.GetPrisaByFrameID(ref id, idframe))
            {
                return clsPrisa.Find(id);
            }
            else
            {
                return null;
            }
        }

        public static clsPrisa Find(int id)
        {
           decimal __magnet   =0;
           decimal __corner1  =0;
           decimal __corner2  =0;
           decimal __corner3  =0;
           decimal __corner4  =0;
           decimal __corner5  =0;
           decimal __corner6  =0;
           decimal __corner7  =0;
           decimal __corner8  =0;
           decimal __corner9  =0;
           decimal __corner10 =0;
           decimal __corner11 =0;
           decimal __corner12 =0;
           decimal __corner13 =0;
           decimal __corner14 =0;
           decimal __corner15 =0;
           decimal __corner16 =0;
           decimal __corner17 =0;
           decimal __corner18 =0;
           decimal __corner19 =0;
           decimal __corner20 =0;
            int    __FrameID = 0;

            if(clsdataAccessPrisa.GetPrisaByID(id
               ,ref __magnet
               ,ref __corner1
               ,ref __corner2
               ,ref __corner3
               ,ref __corner4
               ,ref __corner5
               ,ref __corner6
               ,ref __corner7
               ,ref __corner8
               ,ref __corner9
               ,ref __corner10
               ,ref __corner11
               ,ref __corner12
               ,ref __corner13
               ,ref __corner14
               ,ref __corner15
               ,ref __corner16
               ,ref __corner17
               ,ref __corner18
               ,ref __corner19
               ,ref __corner20
               ,ref __FrameID
                ))
            {
                return new clsPrisa(id
                  , __magnet
                  , __corner1
                  , __corner2
                  , __corner3
                  , __corner4
                  , __corner5
                  , __corner6
                  , __corner7
                  , __corner8
                  , __corner9
                  , __corner10
                  , __corner11
                  , __corner12
                  , __corner13
                  , __corner14
                  , __corner15
                  , __corner16
                  , __corner17
                  , __corner18
                  , __corner19
                  , __corner20
                  , __FrameID
                    );
            }
            else
            {
                return null;
            }
        }

        private bool _Add()
        {


            this.ID = clsdataAccessPrisa.Add(
                this.magnet 
               , this.corner1
               , this.corner2
               , this.corner3
               , this.corner4
               , this.corner5
               , this.corner6
               , this.corner7
               , this.corner8
               , this.corner9
               , this.corner10
               , this.corner11
               , this.corner12
               , this.corner13
               , this.corner14
               , this.corner15
               , this.corner16
               , this.corner17
               , this.corner18
               , this.corner19
               , this.corner20
               , this.FrameID
                );

            return (this.ID != -1);
        }

        private bool _Update()
        {


            return clsdataAccessPrisa.Update(this.ID,
                                this.magnet
               , this.corner1
               , this.corner2
               , this.corner3
               , this.corner4
               , this.corner5
               , this.corner6
               , this.corner7
               , this.corner8
               , this.corner9
               , this.corner10
               , this.corner11
               , this.corner12
               , this.corner13
               , this.corner14
               , this.corner15
               , this.corner16
               , this.corner17
               , this.corner18
               , this.corner19
               , this.corner20
               , this.FrameID


                );

        }


        public bool Save()

        {

            switch (_mode)
            {

                case Mode.Add:

                    if (_Add())
                    {
                        _mode = Mode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case Mode.Update:
                    return _Update();
            }

            return false;

        }


        public static bool Delete(int ID)
        {
            return clsdataAccessPrisa.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsdataAccessPrisa.GetAll();
        }

        public static bool IsExist(int ID)
        {
            return clsdataAccessPrisa.IsExist(ID);
        }

        public void clear()
        {
         
            this.magnet = 0;
            this.corner1 = 0;
            this.corner2 = 0;
            this.corner3 = 0;
            this.corner4 = 0;
            this.corner5 = 0;
            this.corner6 = 0;
            this.corner7 = 0;
            this.corner8 = 0;
            this.corner9 = 0;
            this.corner10 = 0;
            this.corner11 = 0;
            this.corner12 = 0;
            this.corner13 = 0;
            this.corner14 = 0;
            this.corner15 = 0;
            this.corner16 = 0;
            this.corner17 = 0;
            this.corner18 = 0;
            this.corner19 = 0;
            this.corner20 = 0;
   
            this._mode = Mode.Update;
        }


    }
}
