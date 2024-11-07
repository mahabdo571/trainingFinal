using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDAKantWingManual
    {
        public static bool GetByID(int ID, ref int KantA, ref int KantB, ref int KantC, ref int KantD, ref int KantE, ref int KantF, ref int KantG, ref int KantH, ref int KantI,ref int WingID)

        {

            bool isFound = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    using (SqlCommand myCommand = new SqlCommand("SP_KantWingManual_FindByID", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {


                                KantA = (int)myReader["KantA"];
                                KantB = (int)myReader["KantB"];
                                KantC = (int)myReader["KantC"];
                                KantD = (int)myReader["KantD"];
                                KantE = (int)myReader["KantE"];
                                KantF = (int)myReader["KantF"];
                                KantG = (int)myReader["KantG"];
                                KantH = (int)myReader["KantH"];
                                KantI = (int)myReader["KantI"];
                                WingID = (int)myReader["WingID"];




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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAKantWingManual__FUNCTION__GetByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;

        } 
        
        
        public static bool GetByWingID(ref int ID, ref int KantA, ref int KantB, ref int KantC, ref int KantD, ref int KantE, ref int KantF, ref int KantG, ref int KantH, ref int KantI, int WingID)

        {

            bool isFound = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    using (SqlCommand myCommand = new SqlCommand("SP_KantWingManual_FindByWingID", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@id", WingID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {


                                KantA = (int)myReader["KantA"];
                                KantB = (int)myReader["KantB"];
                                KantC = (int)myReader["KantC"];
                                KantD = (int)myReader["KantD"];
                                KantE = (int)myReader["KantE"];
                                KantF = (int)myReader["KantF"];
                                KantG = (int)myReader["KantG"];
                                KantH = (int)myReader["KantH"];
                                KantI = (int)myReader["KantI"];
                                ID = (int)myReader["ID"];




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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAKantWingManual__FUNCTION__GetByWingID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;

        }

        public static async Task<bool> UpdateAsync(int ID, int KantA, int KantB, int KantC, int KantD, int KantE, int KantF, int KantG, int KantH, int KantI,int WingID)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {





                    using (SqlCommand myCommand = new SqlCommand("SP_Update_KantWingManual", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        myCommand.Parameters.AddWithValue("@ID", ID);
                
                        myCommand.Parameters.AddWithValue("@KantA", KantA);
                        myCommand.Parameters.AddWithValue("@KantB", KantB);
                        myCommand.Parameters.AddWithValue("@KantC", KantC);
                        myCommand.Parameters.AddWithValue("@KantD", KantD);
                        myCommand.Parameters.AddWithValue("@KantE", KantE);
                        myCommand.Parameters.AddWithValue("@KantF", KantF);
                        myCommand.Parameters.AddWithValue("@KantG", KantG);
                        myCommand.Parameters.AddWithValue("@KantH", KantH);
                        myCommand.Parameters.AddWithValue("@KantI", KantI);
                        myCommand.Parameters.AddWithValue("@WingID", WingID);




                    await    myConnection.OpenAsync();

                        rowsAffected = await myCommand.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAKantWingManual__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

                rowsAffected = -1;
            }

            return (rowsAffected > 0);


        }
        
        
        public static async Task<int> AddAsync( int KantA, int KantB, int KantC, int KantD, int KantE, int KantF, int KantG, int KantH, int KantI,int WingID)
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    using (SqlCommand myCommand = new SqlCommand("SP_Add_KantWingManual", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        myCommand.Parameters.AddWithValue("@KantA", KantA);
                        myCommand.Parameters.AddWithValue("@KantB", KantB);
                        myCommand.Parameters.AddWithValue("@KantC", KantC);
                        myCommand.Parameters.AddWithValue("@KantD", KantD);
                        myCommand.Parameters.AddWithValue("@KantE", KantE);
                        myCommand.Parameters.AddWithValue("@KantF", KantF);
                        myCommand.Parameters.AddWithValue("@KantG", KantG);
                        myCommand.Parameters.AddWithValue("@KantH", KantH);
                        myCommand.Parameters.AddWithValue("@KantI", KantI);
                        myCommand.Parameters.AddWithValue("@WingID", WingID);

                        SqlParameter sqlParameter = new SqlParameter("@NewID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        myCommand.Parameters.Add(sqlParameter);


                    await    myConnection.OpenAsync();

                      await myCommand.ExecuteNonQueryAsync();

                        ID = (int)myCommand.Parameters["@NewID"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAKantWingManual__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }

            return ID;


        }
  
    
    
    }
}
