using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsFrameAdvanced
    {
        enum Mode { Add = 0, Update = 1 };

        Mode _mode = Mode.Add;
        public int ID { get; set; }
        public int FrameID { get; set; }
        public int FromAbove { get; set; }
        public int FromBottom { get; set; }
        public bool HiddenOil { get; set; }
        public bool ManualSize { get; set; }

        clsFrameAdvanced(int id, int _FrameID,int _FromAbove,int _FromBottom,bool _HiddenOil,bool _ManualSize)
        {

            this.ID = id;
            this.FrameID = _FrameID;
            this.FromAbove = _FromAbove;
            this.FromBottom = _FromBottom;
            this.HiddenOil = _HiddenOil;
            this.ManualSize = _ManualSize;

            this._mode = Mode.Update;

        }

        public clsFrameAdvanced()
        {
            this.ID = -1;
            this.FrameID = -1;
            this.FromAbove = 0;
            this.FromBottom = 0;
            this.HiddenOil = false;
            this.ManualSize = false;
            this._mode = Mode.Add;

        }

        public static clsFrameAdvanced Find(int id)
        {
            int _FrameID = -1;

            int _FromAbove = -1;
            int _FromBottom = -1;
            bool _HiddenOil = false;
            bool  _ManualSize = false;


            if (clsDataAccessFrameAdvanced.GetByID(id, ref _FrameID,ref _FromAbove,ref _FromBottom,ref _HiddenOil,ref _ManualSize))
            {
                return new clsFrameAdvanced(id, _FrameID,  _FromAbove,  _FromBottom,  _HiddenOil,  _ManualSize);
            }
            else
            {
                return null;
            }
        }

        public static clsFrameAdvanced FindByFrameID(int idframe)
        {
            int id = 0;

            if (clsDataAccessFrameAdvanced.GetByFrameID(ref id, idframe))
            {
                return clsFrameAdvanced.Find(id);
            }
            else
            {
                return null;
            }
        }


        private bool _Add()
        {


            this.ID = clsDataAccessFrameAdvanced.Add(this.FrameID,this.FromAbove,this.FromBottom,this.HiddenOil,this.ManualSize);

            return (this.ID != -1);
        }
        public int copy(int frameid)
        {


            this.ID = clsDataAccessFrameAdvanced.Add(frameid, this.FromAbove, this.FromBottom, this.HiddenOil, this.ManualSize);

            return this.ID;
        }
        private bool _Update()
        {


            return clsDataAccessFrameAdvanced.Update(this.ID, this.FrameID, this.FromAbove, this.FromBottom, this.HiddenOil, this.ManualSize);

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
            return clsDataAccessFrameAdvanced.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessFrameAdvanced.GetAll();
        }

        public static bool IsExist(int ID)
        {
            return clsDataAccessFrameAdvanced.IsExist(ID);
        }

        public void clear()
        {
   

            this.FromAbove = 0;
            this.FromBottom = 0;
            this.HiddenOil = false;
            this.ManualSize = false;
            this._mode = Mode.Update;
        }



    }
}
