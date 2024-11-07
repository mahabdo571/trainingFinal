using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everythingDA
{
    public class clsSalesDA
    {


        public static bool GetByID(int SalesID,ref int ProductID, ref int OrderID, ref int Amount,ref Decimal PSellingPrice,ref double PDiscountPercentage)
        {
            bool isFound = false;

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {
                using (var Command = new SqlCommand("SP_Sales_Find", Connction))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;

                    Command.Parameters.AddWithValue("@PSalesID", SalesID);

                    Connction.Open();

                    using (var Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            isFound = true;

                            ProductID = (int)Reader["ProductID"];
                            OrderID = (int)Reader["OrderID"];
                            Amount = (int)Reader["Amount"];
                            PSellingPrice = (Decimal)Reader["SellingPrice"];
                            PDiscountPercentage = (double)Reader["DiscountPercentage"];



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


         public static bool FindbyProductID(ref int SalesID, int ProductID,  int OrderID, ref int Amount,ref Decimal PSellingPrice,ref double PDiscountPercentage)
        {
            bool isFound = false;

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {
                using (var Command = new SqlCommand("SP_Sales_FindbyProductID", Connction))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;

                    Command.Parameters.AddWithValue("@PProductID", ProductID);
                    Command.Parameters.AddWithValue("@POrderID", OrderID);

                    Connction.Open();

                    using (var Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            isFound = true;

                            SalesID = (int)Reader["SalesID"];
                        
                            Amount = (int)Reader["Amount"];
                            PSellingPrice = (Decimal)Reader["SellingPrice"];
                            PDiscountPercentage = (double)Reader["DiscountPercentage"];
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


        public static int AddNew(  int ProductID,  int OrderID,  int Amount,Decimal PSellingPrice,double PDiscountPercentage)
        {
            int SalesID = -1;

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {

                using (var command = new SqlCommand("SP_Sales_ADD", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@PProductID", ProductID);
                    command.Parameters.AddWithValue("@POrderID", OrderID);
                    command.Parameters.AddWithValue("@PAmount", Amount);
                    command.Parameters.AddWithValue("@PSellingPrice", PSellingPrice);
                    command.Parameters.AddWithValue("@PDiscountPercentage", PDiscountPercentage);

                    SqlParameter sqlParameter = new SqlParameter("@PSalesID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(sqlParameter);


                    Connction.Open();

                    command.ExecuteNonQuery();

                    SalesID = (int)command.Parameters["@PSalesID"].Value;
                }
            }

            return SalesID;
        }


        public static bool Update(int SalesID ,int ProductID, int OrderID, int Amount, Decimal PSellingPrice, double PDiscountPercentage)
        {
            int rowsAffected = -1;

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {

                using (var command = new SqlCommand("SP_Sales_UPDATE", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PSalesID", SalesID);

                    command.Parameters.AddWithValue("@PProductID", ProductID);
                    command.Parameters.AddWithValue("@POrderID", OrderID);
                    command.Parameters.AddWithValue("@PAmount", Amount);

                    command.Parameters.AddWithValue("@PSellingPrice", PSellingPrice);
                    command.Parameters.AddWithValue("@PDiscountPercentage", PDiscountPercentage);


                    Connction.Open();



                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return (rowsAffected > 0);
        }



        public static bool DELETE(int ProductID)
        {
            int rowsAffected = -1;

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {

                using (var command = new SqlCommand("SP_Sales_DELETE", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PSalesID", ProductID);




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

                using (var command = new SqlCommand("SP_Sales_GetAll", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    Connction.Open();

                    using (var redar = command.ExecuteReader())
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
        
        
        public static DataTable GetAllByOrder(int POrderID)
        {
            DataTable Dt = new DataTable();

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {

                using (var command = new SqlCommand("SP_Sales_GetAllByOrderID", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@POrderID", POrderID);
                    Connction.Open();

                    using (var redar = command.ExecuteReader())
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
