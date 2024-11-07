using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsColorSide
    {
        enum Mode { Add =0,Update=1};

        Mode _mode = Mode.Add;
        public int ID { get; set; }
        public string ColorName { get; set; }


        clsColorSide (int id, string colorName)
        {

            this.ID = id;
            this.ColorName = colorName;

            this._mode = Mode.Update;

        }

        public clsColorSide()
        {
            this.ID = -1;
            this.ColorName = "";
  

            this._mode = Mode.Add;

        }

        public static clsColorSide Find(int id)
        {
            string colorName = "";



            if(clsDAColorSide.GetColorByID(id,ref colorName))
            {
                return new clsColorSide(id, colorName);
            }
            else
            {
                return null;
            }
        } 
        public static clsColorSide Find(string colorName)
        {
            int id = -1;

  

            if(clsDAColorSide.GetColorByColorName(ref id, colorName))
            {
                return new clsColorSide(id, colorName);
            }
            else
            {
                return null;
            }
        }

        private bool _Add()
        {


            this.ID = clsDAColorSide.Add(this.ColorName);

            return (this.ID != -1);
        }

        private bool _Update()
        {


            return clsDAColorSide.Update(this.ID, this.ColorName);

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
            return clsDAColorSide.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDAColorSide.GetAll();
        }  
        public static DataTable getAllSortByID()
        {
            return clsDAColorSide.getAllSortByID();
        }

        public static bool IsExist(int ID)
        {
            return clsDAColorSide.IsExist(ID);
        }




    }
}
