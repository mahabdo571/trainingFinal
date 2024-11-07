using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace everythingDA
{
    public class clsOrderDA
    {


        public static bool GetByID(int OderID, ref DateTime DateCreated
            )
        {
            bool isFound = false;

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {
                using (var Command = new SqlCommand("SP_Orders_Find", Connction))
                {
                    Command.CommandType = System.Data.CommandType.StoredProcedure;

                    Command.Parameters.AddWithValue("@POderID", OderID);

                    Connction.Open();

                    using (var Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            isFound = true;

                            DateCreated = (DateTime)Reader["DateCreated"];
                
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


        public static int AddNew(DateTime DateCreated)
        {
            int ProductID = -1;

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {

                using (var command = new SqlCommand("SP_Orders_ADD", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@PDateCreated", DateCreated);
        

                    SqlParameter sqlParameter = new SqlParameter("@POrderID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(sqlParameter);


                    Connction.Open();

                    command.ExecuteNonQuery();

                    ProductID = (int)command.Parameters["@POrderID"].Value;
                }
            }

            return ProductID;
        }


        public static bool Update(int OderID,  DateTime DateCreated)
        {
            int rowsAffected = -1;

            using (var Connction = new SqlConnection(clsConnctionDA.ConctionStr))
            {

                using (var command = new SqlCommand("SP_Orders_UPDATE", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@POderID", OderID);

                    command.Parameters.AddWithValue("@PDateCreated", DateCreated);
   



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

                using (var command = new SqlCommand("SP_Orders_DELETE", Connction))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@POderID", ProductID);




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

                using (var command = new SqlCommand("SP_Orders_GetAll", Connction))
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


    }
}
