using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDAKantWingDefault
    {
   

        public static bool GetByID(int ID,ref string Name,ref string Description,ref int KantA,ref int KantB,ref int KantC,ref int KantD,ref int KantE,ref int KantF,ref int KantG,ref int KantH,ref int KantI)

        {

            bool isFound = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    using (SqlCommand myCommand = new SqlCommand("SP_KantWingDefault_FindByID", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if ( myReader.Read())
                            {

                               
                                Name = (string)myReader["Name"];
                                Description = myReader["Description"] == DBNull.Value ? "":(string)myReader["Description"];
                                KantA = myReader["KantA"] == DBNull.Value ? 0 : (int)myReader["KantA"];
                                KantB =myReader["KantB"] == DBNull.Value ? 0 :(int)myReader["KantB"];
                                KantC =myReader["KantC"] == DBNull.Value ? 0 :(int)myReader["KantC"];
                                KantD =myReader["KantD"] == DBNull.Value ? 0 :(int)myReader["KantD"];
                                KantE =myReader["KantE"] == DBNull.Value ? 0 :(int)myReader["KantE"];
                                KantF =myReader["KantF"] == DBNull.Value ? 0 :(int)myReader["KantF"];
                                KantG =myReader["KantG"] == DBNull.Value ? 0 :(int)myReader["KantG"];
                                KantH =myReader["KantH"] == DBNull.Value ? 0 :(int)myReader["KantH"];
                                KantI = myReader["KantI"] == DBNull.Value ? 0 : (int)myReader["KantI"];
                             



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
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAKantWingDefault__FUNCTION__GetByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;

        }



        public static async Task<bool> UpdateAsync(int ID,  string Name,  string Description,  int KantA,  int KantB,  int KantC,  int KantD,  int KantE,  int KantF,  int KantG,  int KantH,  int KantI)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {





                    using (SqlCommand myCommand = new SqlCommand("SP_Update_KantWingDefault", myConnection))
                    {
                        myCommand.CommandType =  CommandType.StoredProcedure;

                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@Name", Name);
                        myCommand.Parameters.AddWithValue("@Description", Description);
                        myCommand.Parameters.AddWithValue("@KantA", KantA);
                        myCommand.Parameters.AddWithValue("@KantB", KantB);
                        myCommand.Parameters.AddWithValue("@KantC", KantC);
                        myCommand.Parameters.AddWithValue("@KantD", KantD);
                        myCommand.Parameters.AddWithValue("@KantE", KantE);
                        myCommand.Parameters.AddWithValue("@KantF", KantF);
                        myCommand.Parameters.AddWithValue("@KantG", KantG);
                        myCommand.Parameters.AddWithValue("@KantH", KantH);
                        myCommand.Parameters.AddWithValue("@KantI", KantI);
                        



                       await myConnection.OpenAsync();

                        rowsAffected =await myCommand.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAKantWingDefault__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

                rowsAffected = -1;
            }

            return (rowsAffected > 0);


        }


        public static async Task<DataTable> GetAllAsync()
        {
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    // WAITFOR DELAY '00:00:5' --for test if data slowly

             

                    using (SqlCommand myCommand = new SqlCommand("SP_GetAll_KantWingDefault", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                     await   myConnection.OpenAsync();

                        using (SqlDataReader myReader = await myCommand.ExecuteReaderAsync())
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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAKantWingDefault__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);
                myDataTable = null;
            }

            return myDataTable;
        }


    }
}
