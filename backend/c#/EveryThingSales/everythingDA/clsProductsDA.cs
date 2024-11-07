using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using static Azure.Core.HttpHeader;


namespace everythingDA
{
    public class clsProductsDA
    {



        public static bool GetByID(int ProductID, ref string ProductName, ref string ProductBarCode, ref Decimal PriceOnSeller,
            ref Decimal SellingPrice, ref Decimal SellingPriceTraders, ref DateTime DateCreated, ref DateTime LastUpdated, ref int QuantityAvailablePerPiece,
            ref double DiscountPercentage , ref string Notes
            )
        {
            bool isFound = false;

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {
                using (var Command = new SqlCommand("SP_Products_Find", Connction))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;

                    Command.Parameters.AddWithValue("@PProductID", ProductID);

                    Connction.Open();

                    using (var Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            isFound = true;

                            ProductName = (string)Reader["ProductName"];
                            ProductBarCode = (string)Reader["ProductBarCode"];
                            PriceOnSeller = (Decimal)Reader["PriceOnSeller"];
                            SellingPrice = (Decimal)Reader["SellingPrice"];
                            SellingPriceTraders = (Decimal)Reader["SellingPriceTraders"];
                            DateCreated = (DateTime)Reader["DateCreated"];
                            LastUpdated = (DateTime)Reader["LastUpdated"];
                            QuantityAvailablePerPiece = (int)Reader["QuantityAvailablePerPiece"];
                            DiscountPercentage = (double)Reader["DiscountPercentage"];
                            Notes = (string)Reader["Notes"];
                        }
                        else
                        {
                            isFound = false;
                        }

                        Reader.Close();
                        Connction.Close();
                    }

                }

            }

            return isFound;
        }  
        
        
        public static bool GetByBarCode(ref int ProductID, ref string ProductName,  string ProductBarCode, ref Decimal PriceOnSeller,
            ref Decimal SellingPrice, ref Decimal SellingPriceTraders, ref DateTime DateCreated, ref DateTime LastUpdated, ref int QuantityAvailablePerPiece,
            ref double DiscountPercentage , ref string Notes
            )
        {
            bool isFound = false;

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {
                using (var Command = new SqlCommand("SP_Products_GetByBarCode", Connction))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;

                    Command.Parameters.AddWithValue("@PProductBarCode", ProductBarCode);

                    Connction.Open();

                    using (var Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            isFound = true;

                            ProductName = (string)Reader["ProductName"];
                            ProductID = (int)Reader["ProductID"];
                            PriceOnSeller = (Decimal)Reader["PriceOnSeller"];
                            SellingPrice = (Decimal)Reader["SellingPrice"];
                            SellingPriceTraders = (Decimal)Reader["SellingPriceTraders"];
                            DateCreated = (DateTime)Reader["DateCreated"];
                            LastUpdated = (DateTime)Reader["LastUpdated"];
                            QuantityAvailablePerPiece = (int)Reader["QuantityAvailablePerPiece"];
                            DiscountPercentage = (double)Reader["DiscountPercentage"];
                            Notes = (string)Reader["Notes"];
                        }
                        else
                        {
                            isFound = false;
                        }

                        Reader.Close();
                        Connction.Close();
                    }

                }

            }

            return isFound;
        }


        public static int AddNew(string ProductName, string ProductBarCode, Decimal PriceOnSeller,
             Decimal SellingPrice, Decimal SellingPriceTraders, DateTime DateCreated, DateTime LastUpdated, int QuantityAvailablePerPiece,
              double DiscountPercentage,string Notes, out Exception exception)
        {
            int ProductID = -1;
            exception = null;

            try
            {
                using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
                {

                    using (var command = new SqlCommand("SP_Products_ADD", Connction))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PProductName", ProductName);
                        command.Parameters.AddWithValue("@PProductBarCode", ProductBarCode);
                        command.Parameters.AddWithValue("@PPriceOnSeller", PriceOnSeller);
                        command.Parameters.AddWithValue("@PSellingPrice", SellingPrice);
                        command.Parameters.AddWithValue("@PSellingPriceTraders", SellingPriceTraders);
                        command.Parameters.AddWithValue("@PDateCreated", DateCreated);
                        command.Parameters.AddWithValue("@PLastUpdated", LastUpdated);
                        command.Parameters.AddWithValue("@PQuantityAvailablePerPiece", QuantityAvailablePerPiece);
                        command.Parameters.AddWithValue("@PNotes", Notes);
                        command.Parameters.AddWithValue("@PDiscountPercentage", DiscountPercentage);

                        SqlParameter sqlParameter = new SqlParameter("@PProductID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };
                        command.Parameters.Add(sqlParameter);


                        Connction.Open();

                        command.ExecuteNonQuery();

                        ProductID = (int)command.Parameters["@PProductID"].Value;
                    }
                }
            }catch(Exception ex)
            {
                exception = ex;
            }
            return ProductID;
        } 
        
        
        public static bool Update(int ProductID, string ProductName, string ProductBarCode, Decimal PriceOnSeller,
             Decimal SellingPrice, Decimal SellingPriceTraders, DateTime DateCreated, DateTime LastUpdated, int QuantityAvailablePerPiece,
             double DiscountPercentage,string Notes, out Exception exception)
        {
            int rowsAffected = -1;
            exception = null;
            try
            {
                using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
                {

                    using (var command = new SqlCommand("SP_Products_UPDATE", Connction))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PProductID", ProductID);
                        command.Parameters.AddWithValue("@PProductName", ProductName);
                        command.Parameters.AddWithValue("@PProductBarCode", ProductBarCode);
                        command.Parameters.AddWithValue("@PPriceOnSeller", PriceOnSeller);
                        command.Parameters.AddWithValue("@PSellingPrice", SellingPrice);
                        command.Parameters.AddWithValue("@PSellingPriceTraders", SellingPriceTraders);
                        command.Parameters.AddWithValue("@PDateCreated", DateCreated);
                        command.Parameters.AddWithValue("@PLastUpdated", LastUpdated);
                        command.Parameters.AddWithValue("@PQuantityAvailablePerPiece", QuantityAvailablePerPiece);
                        command.Parameters.AddWithValue("@PNotes", Notes);
                        command.Parameters.AddWithValue("@PDiscountPercentage", DiscountPercentage);



                        Connction.Open();


                   
                        rowsAffected = command.ExecuteNonQuery();
                        
                     

                    }
                }
            }catch(Exception ex)
            {
                exception = ex;
            }

            return (rowsAffected > 0);
        } 
        


public static bool DELETE(int ProductID)
        {
            int rowsAffected = -1;

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {

                using (var command = new SqlCommand("SP_Products_DELETE", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PProductID", ProductID);


          

                    Connction.Open();



                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return (rowsAffected > 0);
        }
        
        
        public static DataTable GetAll()
        {
            DataTable Dt = new DataTable();

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {

                using (var command = new SqlCommand("SP_Products_GetAll", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    Connction.Open();

                    using(var redar = command.ExecuteReader())
                    {
                        if (redar.HasRows)
                        {
                            Dt.Load(redar);
                        }
                        else
                        {
                            Dt = null;
                        }
                    }



                }
            }

            return Dt;
        }
        
        public static async Task<IEnumerable<Products>> GetAlllist()
        {
            List<Products> Dt = new List<Products>();

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {

                using (var command = new SqlCommand("SP_Products_GetAll", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    Connction.Open();

                    using (var redar =await command.ExecuteReaderAsync())
                    {
                        while (await redar.ReadAsync())
                        {
                            Dt.Add(new Products
                            {
                                id = redar.GetInt32(0),
                                ProductName = redar.GetString(1),
                                ProductBarCode =redar.GetString(2),
                                PriceOnSeller = redar.GetDecimal(3),
                                SellingPrice =redar.GetDecimal(4),
                                SellingPriceTraders = redar.GetDecimal(5),
                                LastUpdated = redar.GetDateTime(7),
                                QuantityAvailablePerPiece = redar.GetInt32(8),
                                DiscountPercentage = redar.GetDouble(9),
                                Notes = redar.GetString(10)


                            });
                        }
                    }
                    }



                }
            return Dt;
        }

         
        
        
        
        public static DataTable FetchAvailableProducts()
        {
            DataTable Dt = new DataTable();

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {

                using (var command = new SqlCommand("SP_Fetch_Available_Products", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    Connction.Open();

                    using(var redar = command.ExecuteReader())
                    {
                        if (redar.HasRows)
                        {
                            Dt.Load(redar);
                        }
                        else
                        {
                            Dt = null;
                        }
                    }



                }
            }

            return Dt;
        }

    }

}



