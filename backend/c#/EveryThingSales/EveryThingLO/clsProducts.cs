using everythingDA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingLO
{
    public class clsProducts
    {

        public enum MODE { ADD=1,UPDATE=2};

       public MODE _mode = MODE.ADD;

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductBarCode { get; set; }
        public Decimal PriceOnSeller { get; set; }
        public Decimal SellingPrice { get; set; }
        public Decimal SellingPriceTraders { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public int QuantityAvailablePerPiece { get; set; }
        public double DiscountPercentage { get; set; }
        public string Notes { get; set; }

        public clsProducts()
        {
            this._mode = MODE.ADD;
            this.ProductID = -1;
            this.ProductName = "";
            this.ProductBarCode = "";
            this.PriceOnSeller = 0;
            this.SellingPrice = 0;
            this.SellingPriceTraders = 0;
            this.DateCreated = DateTime.Now;
            this.LastUpdated = DateTime.Now;
            this.QuantityAvailablePerPiece = 0;
            this.DiscountPercentage = -1;
            this.Notes = "";
        }    
        
        
        private clsProducts(int pProductID,string pProductName,string pProductBarCode, Decimal pPriceOnSeller, Decimal pSellingPrice,
            Decimal pSellingPriceTraders,DateTime pDateCreated,DateTime pLastUpdated,int pQuantityAvailablePerPiece, double pDiscountPercentage,string pNotes)
        {
            this._mode = MODE.UPDATE;
            this.ProductID = pProductID;
            this.ProductName = pProductName;
            this.ProductBarCode = pProductBarCode;
            this.PriceOnSeller = pPriceOnSeller;
            this.SellingPrice = pSellingPrice;
            this.SellingPriceTraders = pSellingPriceTraders;
            this.DateCreated = pDateCreated;
            this.LastUpdated = pLastUpdated;
            this.QuantityAvailablePerPiece = pQuantityAvailablePerPiece;
            this.DiscountPercentage = pDiscountPercentage;
            this.Notes = pNotes;
        }

        public static clsProducts Find(int pProductID)
        {
           
           string pProductName = "";
           string pProductBarCode = "";
            Decimal pPriceOnSeller = 0;
            Decimal pSellingPrice = 0;
            Decimal pSellingPriceTraders = 0;
           DateTime pDateCreated = DateTime.Now;
           DateTime pLastUpdated = DateTime.Now;
           int pQuantityAvailablePerPiece = 0;
            double pDiscountPercentage = -1;
           string pNotes = "";

            if(clsProductsDA.GetByID(pProductID,ref pProductName,ref pProductBarCode,ref pPriceOnSeller,
                ref pSellingPrice,ref pSellingPriceTraders,ref pDateCreated,ref pLastUpdated,ref pQuantityAvailablePerPiece,ref pDiscountPercentage,
                ref pNotes))
            {
                return new clsProducts(pProductID, pProductName, pProductBarCode, pPriceOnSeller,
                 pSellingPrice, pSellingPriceTraders, pDateCreated, pLastUpdated, pQuantityAvailablePerPiece,
                 pDiscountPercentage,pNotes);
            }
            else
            {
                return null;
            }


        }     
        
        
        public static clsProducts FindByBarCode(string pProductBarCode)
        {
           
           string pProductName = "";
          
            Decimal pPriceOnSeller = 0;
            Decimal pSellingPrice = 0;
            Decimal pSellingPriceTraders = 0;
           DateTime pDateCreated = DateTime.Now;
           DateTime pLastUpdated = DateTime.Now;
           int pQuantityAvailablePerPiece = 0;
           int pProductID = -1;
            double pDiscountPercentage = -1;
           string pNotes = "";

            if(clsProductsDA.GetByBarCode(ref pProductID,ref pProductName, pProductBarCode,ref pPriceOnSeller,
                ref pSellingPrice,ref pSellingPriceTraders,ref pDateCreated,ref pLastUpdated,ref pQuantityAvailablePerPiece,ref pDiscountPercentage,
                ref pNotes))
            {
                return new clsProducts(pProductID, pProductName, pProductBarCode, pPriceOnSeller,
                 pSellingPrice, pSellingPriceTraders, pDateCreated, pLastUpdated, pQuantityAvailablePerPiece,
                 pDiscountPercentage,pNotes);
            }
            else
            {
                return null;
            }


        }

        bool AddNewItem(out Exception ex)
        {

            this.ProductID = clsProductsDA.AddNew(this.ProductName,this.ProductBarCode,this.PriceOnSeller,
                this.SellingPrice,this.SellingPriceTraders,this.DateCreated,this.LastUpdated,this.QuantityAvailablePerPiece,
                this.DiscountPercentage,this.Notes, out ex);

            return (this.ProductID != -1);

        }  
        bool UpdateItem(out Exception ex)
        {
            return clsProductsDA.Update(this.ProductID,this.ProductName, this.ProductBarCode, this.PriceOnSeller,
                this.SellingPrice, this.SellingPriceTraders, this.DateCreated, this.LastUpdated, this.QuantityAvailablePerPiece,
                 this.DiscountPercentage, this.Notes,out ex);
        }

        public bool Save(out Exception ex)
        {
            ex = null;
            switch (_mode)
            {
                case MODE.ADD:
                    if (AddNewItem(out ex))
                    {
                        _mode = MODE.UPDATE;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case MODE.UPDATE:
                    return UpdateItem(out ex);
            }

            return false;
        }

        public static bool DeleteItem(int pProductID)
        {
            return clsProductsDA.DELETE(pProductID);
        }    
        
        public static DataTable GetAllItems()
        {
            return clsProductsDA.GetAll();
        }     
        
        public static async Task< IEnumerable<Products>> GetAlllist()
        {
            return await clsProductsDA.GetAlllist();
        } 
   
          public static DataTable FetchAvailableProducts()
        {
            return clsProductsDA.FetchAvailableProducts();
        }

        public void AddOneToStore()
        {
            this.QuantityAvailablePerPiece++;
            this.Save(out Exception ex);
        }
        
        public void DropOneFromStore()
        {
            this.QuantityAvailablePerPiece--;
            this.Save(out Exception ex);
        }

      

    }
}
