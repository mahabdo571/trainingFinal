using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SharaLogic
{
    public class clsWingType
    {
        enum myMode { addNew = 1, Update = 2 }

        myMode _mode = myMode.addNew;

        public int ID { get; set; }
        public string TEST1 { get; set; }
        public string TEST2 { get; set; }
        public string TEST3 { get; set; }
        public string TEST4 { get; set; }
        public int WingID { get; set; }

        private clsWingType(int id, string Test1, string Test2, string Test3, string Test4, int wingid)
        {
            this.ID = id;
            this.TEST1 = Test1;
            this.TEST2 = Test2;
            this.TEST3 = Test3;
            this.TEST4 = Test4;
            this.WingID = wingid;

            _mode = myMode.Update;
        }

        public clsWingType()
        {
            this.ID = -1;
            this.TEST1 = "";
            this.TEST2 = "";
            this.TEST3 = "";
            this.TEST4 = "";
            this.WingID = -1;

            _mode = myMode.addNew;
        }

        public static clsWingType Find(int ID)
        {
            string test1 = "";
            string test2 = "";
            string test3 = "";
            string test4 = "";
            int wingID = -1;

            if (clsDataAccessWingType.GetByID(ID, ref test1, ref test2, ref test3, ref test4, ref wingID))
            {
                return new clsWingType(ID, test1, test2, test3, test4, wingID);
            }
            else
            {

                return null;
            }


        }  
        

        public static clsWingType FindByWingID(int wingid)
        {
            string test1 = "";
            string test2 = "";
            string test3 = "";
            string test4 = "";
            int ID = -1;

            if (clsDataAccessWingType.GetByWingID(ref ID, ref test1, ref test2, ref test3, ref test4,  wingid))
            {
                return new clsWingType(ID, test1, test2, test3, test4, wingid);
            }
            else
            {

                return null;
            }


        }

        private bool _Add()
        {
            this.ID = clsDataAccessWingType.Add(this.TEST1, this.TEST2, this.TEST3, this.TEST4, this.WingID);

            return (this.ID != -1);
        } 
        
        private bool _Update()
        {

         return  clsDataAccessWingType.Update(this.ID,this.TEST1, this.TEST2, this.TEST3, this.TEST4, this.WingID);

       
        }

        public bool Save()

        {

            switch (_mode)
            {

                case myMode.addNew:

                    if (_Add())
                    {
                        _mode = myMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case myMode.Update:
                    return _Update();
            }

            return false;

        }

        public void CopyTypeWing(int wingidnew)

        {
            this.ID = clsDataAccessWingType.Add(this.TEST1, this.TEST2, this.TEST3, this.TEST4, wingidnew);
         
        }


        public static bool Delete(int ID)
        {
            return clsDataAccessWingType.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessWingType.GetAll();
        }

    

        public static bool IsExist(int ID)
        {
            return clsDataAccessWingType.IsExist(ID);
        }

        public void Clear()
        {
            this.TEST1 = "";
            this.TEST2 = "";
            this.TEST3 = "";
            this.TEST4 = "";
          

            _mode = myMode.Update;
        }

    }
}
