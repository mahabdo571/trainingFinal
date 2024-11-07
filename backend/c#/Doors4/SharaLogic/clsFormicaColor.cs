using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsFormicaColor
    {
        enum Mode { Add = 0, Update = 1 };

        Mode _mode = Mode.Add;
        public int ID { get; set; }
        public string ColorName { get; set; }


        clsFormicaColor(int id, string colorName)
        {

            this.ID = id;
            this.ColorName = colorName;

            this._mode = Mode.Update;

        }

        public clsFormicaColor()
        {
            this.ID = 0;
            this.ColorName = "";


            this._mode = Mode.Add;

        }

        public static clsFormicaColor Find(int id)
        {
            string colorName = "";



            if (clsDAColorFormica.GetColorByID(id, ref colorName))
            {
                return new clsFormicaColor(id, colorName);
            }
            else
            {
                return null;
            }
        }
        public static clsFormicaColor Find(string colorName)
        {
            int id = -1;



            if (clsDAColorFormica.GetColorByColorName(ref id, colorName))
            {
                return new clsFormicaColor(id, colorName);
            }
            else
            {
                return null;
            }
        }

        private bool _Add()
        {


            this.ID = clsDAColorFormica.Add(this.ColorName);

            return (this.ID != -1);
        }

        private bool _Update()
        {


            return clsDAColorFormica.Update(this.ID, this.ColorName);

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
            return clsDAColorFormica.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDAColorFormica.GetAll();
        }
        public static DataTable getAllSortByID()
        {
            return clsDAColorFormica.getAllSortByID();
        }

        public static bool IsExist(int ID)
        {
            return clsDAColorFormica.IsExist(ID);
        }

    }
}
