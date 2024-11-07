using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsOrders
    {



        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;

        public int ID { get; set; }

        public DateTime Date { get; set; }
        public DateTime DateManual { get; set; }
        public int ProjectID { get; set; }
        public string Marketer { get; set; }
        public int OrderNumber { get; set; }






        private clsOrders(int id, DateTime date, int projectID, string marketer, int orderNumber,DateTime dateManual)

        {
            this.ID = id;
            this.Date = date;
            this.ProjectID = projectID;
            this.Marketer = marketer;
            this.DateManual = dateManual;

            this._Mode = _myMode.Update;
            OrderNumber = orderNumber;
        }

        public clsOrders()
        {

            this._Mode = _myMode.Addnew;

            this.ID = -1;
            this.ProjectID = -1;
            this.Marketer = "";
            this.Date = DateTime.Now;
            this.OrderNumber = -1;
            this.DateManual = DateTime.Now;



        }




        public static clsOrders Find(int Id)
        {


            DateTime dt = DateTime.Now;
            DateTime dateManual = DateTime.Now;
            int projid = -1;
            string markter = "";
            int orderNumber = -1;




            if (clsDataAccessOrders.GetOtherContactsByID(Id, ref dt, ref projid, ref markter,ref orderNumber,ref dateManual))
            {
                return new clsOrders(Id, dt, projid, markter,orderNumber, dateManual);

            }
            else
            {
                return null;
            }

        }



        private bool _AddNewPhone()
        {


            this.ID = clsDataAccessOrders.Add(this.Date, this.ProjectID, this.Marketer,this.OrderNumber,this.DateManual);

            return (this.ID != -1);
        }

        private bool _UpdatePhone()
        {


            return clsDataAccessOrders.Update(this.ID, this.Date, this.ProjectID, this.Marketer,this.OrderNumber,this.DateManual);

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
            return clsDataAccessOrders.Delete(ID);
        }


        public static DataTable getAllFromProject(int projectID)
        {
            return clsDataAccessOrders.getAllFromProject(projectID);
        }
             public static DataTable Search(string search,int projectID)
        {
            return clsDataAccessOrders.Search(search,projectID);
        }    
        
        public static  DataTable BakegWing(int OrderID)
        {
            return  clsDataAccessOrders.BakegWing(OrderID);
        }      
        
        public static  DataTable pakegFrameStikrs(int OrderID)
        {
            return  clsDataAccessOrders.pakegFrameStikrs(OrderID);
        }


        public static bool IsExist(int ID)
        {
            return clsDataAccessOrders.IsExist(ID);
        }




    }
}
