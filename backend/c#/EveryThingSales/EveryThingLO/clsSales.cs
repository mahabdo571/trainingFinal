using everythingDA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingLO
{
    public class clsSales
    {
        enum MODE { ADD = 1, UPDATE = 2 };

        MODE _mode = MODE.ADD;

        public int SalesID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Amount { get; set; }

        public Decimal PSellingPrice  { get;set;}
        public double PDiscountPercentage { get;set;}



        public clsSales()
        {
            this._mode = MODE.ADD;
            this.SalesID = -1;

            this.ProductID =-1;
            this.OrderID = -1;
            this.Amount = 0;
            this.PSellingPrice = 0;
            this.PDiscountPercentage = 0;
        }


        private clsSales(int pSalesID,int pProductID,int pOrderID,int pAmount,Decimal pSellingPrice,double pDiscountPercentage)
        {
            this._mode = MODE.UPDATE;
            this.SalesID = pSalesID;

            this.ProductID = pProductID;
            this.OrderID = pOrderID;
            this.Amount = pAmount;
            this.PSellingPrice = pSellingPrice;
            this.PDiscountPercentage = pDiscountPercentage;

        }

        public static clsSales Find(int pSalesID)
        {


      
        
            int pProductID = -1;
            int pOrderID = -1;
            int pAmount = 0;
            Decimal pSellingPrice = 0 ;
            double pDiscountPercentage = 0;

            if (clsSalesDA.GetByID(pSalesID, ref pProductID,ref pOrderID,ref pAmount,ref pSellingPrice,ref pDiscountPercentage))
            {
                return new clsSales(pSalesID, pProductID, pOrderID, pAmount, pSellingPrice, pDiscountPercentage);
            }
            else
            {
                return null;
            }


        }       
        
        
        public static clsSales FindbyProductID(int pProductID,int pOrderID)
        {




            int pSalesID = -1;
         
            int pAmount = 0;
            Decimal pSellingPrice = 0;
            double pDiscountPercentage = 0;

            if (clsSalesDA.FindbyProductID(ref pSalesID,  pProductID,  pOrderID,ref pAmount, ref pSellingPrice, ref pDiscountPercentage))
            {
                return new clsSales(pSalesID, pProductID, pOrderID, pAmount, pSellingPrice, pDiscountPercentage);
            }
            else
            {
                return null;
            }


        }

        bool AddNewItem()
        {

            this.SalesID = clsSalesDA.AddNew(this.ProductID,this.OrderID,this.Amount,this.PSellingPrice,this.PDiscountPercentage);

            return (this.SalesID != -1);

        }
        bool UpdateItem()
        {
            return clsSalesDA.Update(this.SalesID, this.ProductID,this.OrderID,this.Amount, this.PSellingPrice, this.PDiscountPercentage);
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

        public static bool DeleteItem(int pSalesID)
        {
            return clsSalesDA.DELETE(pSalesID);
        }

        public static DataTable GetAllItems()
        {
            return clsSalesDA.GetAll();
        }    
        
        public static DataTable GetAllItemsByOrder(int orderID)
        {
            return clsSalesDA.GetAllByOrder(orderID);
        }

        public void AddOneToThisSale()
        {
            this.Amount++;
            this.Save();
        }

        public void DropOneFromThisSale()
        {
            this.Amount--;
            this.Save();
        }




    }
}
