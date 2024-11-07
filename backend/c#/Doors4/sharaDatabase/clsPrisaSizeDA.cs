using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsPrisaSizeDA
    {
     



        public static bool GetByFrameID(int FrameID, ref decimal PRT1, ref decimal PRT2, ref decimal PRT3, ref decimal PRT4, ref int ID)
        {

            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM PrisaSize WHERE FrameID=@FrameID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {



                                ID = (int)myReader["ID"];
                                PRT1 = (decimal)myReader["PRT1"];
                                PRT2 = (decimal)myReader["PRT2"];
                                PRT3 = (decimal)myReader["PRT3"];
                                PRT4 = (decimal)myReader["PRT4"];








                                isFound = true;


                            }
                            else
                            {
                                isFound = false;
                            }

                            myReader.Close();




                        }
                    }
                }
            }
            catch
                                 (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsPrisaSizeDA__FUNCTION__GetByFrameID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }




        public static int Add(int FrameID, decimal PRT1, decimal PRT2, decimal PRT3, decimal PRT4)
        {

            int ID = -1;

            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO [dbo].[PrisaSize]
           ([FrameID]
           ,[PRT1]
           ,[PRT2]
           ,[PRT3]
           ,[PRT4]) VALUES (@FrameID,@PRT1,@PRT2,@PRT3,@PRT4); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);
                        myCommand.Parameters.AddWithValue("@PRT1", PRT1);
                        myCommand.Parameters.AddWithValue("@PRT2", PRT2);
                        myCommand.Parameters.AddWithValue("@PRT3", PRT3);
                        myCommand.Parameters.AddWithValue("@PRT4", PRT4);





                        myConnection.Open();

                        object myResult = myCommand.ExecuteScalar();

                        if (myResult != null && int.TryParse(myResult.ToString(), out int idResult))
                        {

                            ID = idResult;
                        }
                        else
                        {
                            ID = -1;
                        }
                    }
                }
            }
            catch
                                   (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsPrisaSizeDA__FUNCTION__|Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }

            return ID;

        }



        public static bool Update(int ID, int FrameID, decimal PRT1, decimal PRT2, decimal PRT3, decimal PRT4)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE PrisaSize SET 
FrameID=@FrameID,
PRT1=@PRT1,
PRT2=@PRT2,
PRT3=@PRT3,
PRT4=@PRT4




WHERE ID=@ID";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);
                        myCommand.Parameters.AddWithValue("@PRT1", PRT1);
                        myCommand.Parameters.AddWithValue("@PRT2", PRT2);
                        myCommand.Parameters.AddWithValue("@PRT3", PRT3);
                        myCommand.Parameters.AddWithValue("@PRT4", PRT4);
                        myCommand.Parameters.AddWithValue("@ID", ID);




                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();

                    }
                }
            }
            catch
                                             (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsPrisaSizeDA__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

                rowsAffected = -1;
            }


            return (rowsAffected > 0);


        }


        public static bool Delete(int ID)
        {


            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "DELETE FROM PrisaSize WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);

                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();

                    }
                }
            }
            catch
                                                      (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsPrisaSizeDA__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

                rowsAffected = -1;
            }

            return (rowsAffected > 0);

        }





        public static DataTable GruopPrisaSizesHeight(int OrderID,string FrameType)
        {
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                  

                    using (SqlCommand myCommand = new SqlCommand("SP_GruopPrisaSizesHeight", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@ID", OrderID);
                        myCommand.Parameters.AddWithValue("@TypeName", FrameType);

             
       

                        myConnection.Open();


                        
                       

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.HasRows)
                            {
                                myDataTable.Load(myReader);

                            }
                            else
                            {
                                myDataTable = null;
                            }
                            myReader.Close();


                        }
                    }
                }
            }
            catch
                                   (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsPrisaSizeDA__FUNCTION__GetAllPrisaSizes", System.Diagnostics.EventLogEntryType.Error);
                myDataTable = null;
            }

            return myDataTable;
        } 
       
        
        public static DataTable GruopPrisaSizesWidth(int OrderID,string FrameType)
        {
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                  

                    using (SqlCommand myCommand = new SqlCommand("SP_GruopPrisaSizesWidth", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@ID", OrderID);
                        myCommand.Parameters.AddWithValue("@TypeName", FrameType);

             
       

                        myConnection.Open();


                        
                       

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.HasRows)
                            {
                                myDataTable.Load(myReader);

                            }
                            else
                            {
                                myDataTable = null;
                            }
                            myReader.Close();


                        }
                    }
                }
            }
            catch
                                   (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsPrisaSizeDA__FUNCTION__GetAllPrisaSizes", System.Diagnostics.EventLogEntryType.Error);
                myDataTable = null;
            }

            return myDataTable;
        } 
        
        
        
        public static DataTable GetAmountRLPrisaSizes(int OrderID,string FrameType)
        {
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                  

                    using (SqlCommand myCommand = new SqlCommand("SP_GruopPrisaSizesAmuntRL", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@ID", OrderID);
                        myCommand.Parameters.AddWithValue("@TypeName", FrameType);

                        //SqlParameter RAmountp = new SqlParameter("@RAmount", SqlDbType.Int)
                        //{
                        //    Direction = ParameterDirection.Output
                        //};  
                        //SqlParameter LAmountp = new SqlParameter("@LAmount", SqlDbType.Int)
                        //{
                        //    Direction = ParameterDirection.Output
                        //};
                        //myCommand.Parameters.Add(RAmountp);
                        //myCommand.Parameters.Add(LAmountp);

                        myConnection.Open();


                      //  myCommand.ExecuteNonQuery();


                        // Retrieve the ID of the new person
                        
                       

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.HasRows)
                            {
                                myDataTable.Load(myReader);

                            }
                            else
                            {
                                myDataTable = null;
                            }
                            myReader.Close();

                           //  RAmount = (int)myCommand.Parameters["@RAmount"].Value;
                           //int   lAmount = (int)myCommand.Parameters["@LAmount"].Value;
                        }
                    }
                }
            }
            catch
                                   (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsPrisaSizeDA__FUNCTION__GetAllPrisaSizes", System.Diagnostics.EventLogEntryType.Error);
                myDataTable = null;
            }

            return myDataTable;
        }


    }
}
