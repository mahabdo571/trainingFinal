using everythingDA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingLO
{
    public class clsOrder
    {

        enum MODE { ADD = 1, UPDATE = 2 };

        MODE _mode = MODE.ADD;

        public int OrderID { get; set; }

        public DateTime DateCreated { get; set; }


        public clsOrder()
        {
            this._mode = MODE.ADD;
            this.OrderID = -1;

            this.DateCreated = DateTime.Now;
    
        }


        private clsOrder(int pOrderID, DateTime pDateCreated)
        {
            this._mode = MODE.UPDATE;
            this.OrderID = pOrderID;

            this.DateCreated = pDateCreated;

        }

        public static clsOrder Find(int pOrderID)
        {


            DateTime pDateCreated = DateTime.Now;


            if (clsOrderDA.GetByID(pOrderID,ref pDateCreated))
            {
                return new clsOrder(pOrderID, pDateCreated);
            }
            else
            {
                return null;
            }


        }

        bool AddNewItem()
        {

            this.OrderID = clsOrderDA.AddNew(this.DateCreated);

            return (this.OrderID != -1);

        }
        bool UpdateItem()
        {
            return clsOrderDA.Update(this.OrderID,this.DateCreated);
        }

        public bool Save()
        {
            switch (_mode)
            {
                case MODE.ADD:
                    if (AddNewItem())
                    {
                        _mode = MODE.UPDATE;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case MODE.UPDATE:
                    return UpdateItem();
            }

            return false;
        }

        public static bool DeleteItem(int pOrderID)
        {
            return clsOrderDA.DELETE(pOrderID);
        }

        public static DataTable GetAllItems()
        {
            return clsOrderDA.GetAll();
        }


    }
}
