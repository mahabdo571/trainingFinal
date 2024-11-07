using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessFrameLockType
    {


        public static bool GetFrameLockTypeByID(int ID, ref string LockType, ref int LockMeasure,
            ref int LockMeasureFloor, ref int UpperLockMeasure, ref int UpperLockMeasureFloor,ref int FrameHiegth,ref int FrameId,ref bool NoCalcu,ref bool SlipCan)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM FrameLockType WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                LockType = (string)myReader["LockType"];
                                LockMeasure = (int)myReader["LockMeasure"];
                                LockMeasureFloor = (int)myReader["LockMeasureFloor"];
                                UpperLockMeasure = (int)myReader["UpperLockMeasure"];
                                UpperLockMeasureFloor = (int)myReader["UpperLockMeasureFloor"];
                                FrameHiegth = (int)myReader["FrameHiegth"];
                                FrameId = (int)myReader["FrameId"];
                                NoCalcu = (bool)myReader["NoCalcu"];
                                SlipCan = (bool)myReader["SlipCan"];






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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameLockType__FUNCTION__GetFrameLockTypeByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }

        public static bool GetByFrameID(ref int ID, ref string LockType, ref int LockMeasure,
           ref int LockMeasureFloor, ref int UpperLockMeasure,ref int UpperLockMeasureFloor,ref int FrameHiegth, int FrameId,ref bool NoCalcu,ref bool SlipCan)
        {
            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM FrameLockType WHERE FrameId=@FrameId";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@FrameId", FrameId);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                LockType = (string)myReader["LockType"];
                                LockMeasure = (int)myReader["LockMeasure"];
                                LockMeasureFloor = (int)myReader["LockMeasureFloor"];
                                UpperLockMeasure = (int)myReader["UpperLockMeasure"];
                                UpperLockMeasureFloor = (int)myReader["UpperLockMeasureFloor"];
                                FrameHiegth = (int)myReader["FrameHiegth"];
                                FrameId = (int)myReader["FrameId"];
                                ID = (int)myReader["ID"];
                                NoCalcu = (bool)myReader["NoCalcu"];
                                SlipCan = (bool)myReader["SlipCan"];


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameLockType__FUNCTION__GetByFrameID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }




        public static int Add(string LockType, int LockMeasure,
             int LockMeasureFloor, int UpperLockMeasure, int UpperLockMeasureFloor,int FrameHiegth,int FrameId,bool NoCalcu,bool SlipCan)
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO FrameLockType
(LockType,LockMeasure,LockMeasureFloor,UpperLockMeasure,UpperLockMeasureFloor,FrameHiegth,FrameId,NoCalcu,SlipCan)
VALUES
(@LockType ,@LockMeasure ,@LockMeasureFloor ,@UpperLockMeasure,@UpperLockMeasureFloor,@FrameHiegth,@FrameId,@NoCalcu,@SlipCan); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@LockType", LockType);
                        myCommand.Parameters.AddWithValue("@LockMeasure", LockMeasure);
                        myCommand.Parameters.AddWithValue("@LockMeasureFloor", LockMeasureFloor);
                        myCommand.Parameters.AddWithValue("@UpperLockMeasure", UpperLockMeasure);
                        myCommand.Parameters.AddWithValue("@UpperLockMeasureFloor", UpperLockMeasureFloor);
                        myCommand.Parameters.AddWithValue("@FrameHiegth", FrameHiegth);
                        myCommand.Parameters.AddWithValue("@FrameId", FrameId);
                        myCommand.Parameters.AddWithValue("@NoCalcu", NoCalcu);
                        myCommand.Parameters.AddWithValue("@SlipCan", SlipCan);




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
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameLockType__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }

            return ID;

        }



        public static bool Update(int ID, string LockType, int LockMeasure,
             int LockMeasureFloor, int UpperLockMeasure, int UpperLockMeasureFloor,int FrameHiegth,int FrameId,bool NoCalcu,bool SlipCan)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE FrameLockType SET 
LockType=@LockType,
LockMeasure=@LockMeasure,
LockMeasureFloor=@LockMeasureFloor,
UpperLockMeasure=@UpperLockMeasure,
UpperLockMeasureFloor=@UpperLockMeasureFloor,
FrameHiegth=@FrameHiegth,
FrameId=@FrameId,
NoCalcu=@NoCalcu,
SlipCan=@SlipCan


WHERE ID=@ID";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@LockType", LockType);
                        myCommand.Parameters.AddWithValue("@LockMeasure", LockMeasure);
                        myCommand.Parameters.AddWithValue("@LockMeasureFloor", LockMeasureFloor);
                        myCommand.Parameters.AddWithValue("@UpperLockMeasure", UpperLockMeasure);
                        myCommand.Parameters.AddWithValue("@UpperLockMeasureFloor", UpperLockMeasureFloor);
                        myCommand.Parameters.AddWithValue("@FrameHiegth", FrameHiegth);
                        myCommand.Parameters.AddWithValue("@FrameId", FrameId);
                        myCommand.Parameters.AddWithValue("@NoCalcu", NoCalcu);
                        myCommand.Parameters.AddWithValue("@SlipCan", SlipCan);




                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameLockType__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM FrameLockType WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);


                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameLockType__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

                rowsAffected = -1;
            }

            return (rowsAffected > 0);

        }


        public static DataTable GetAll()
        {
            DataTable myDataTable = new DataTable();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT * FROM FrameLockType";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {


                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader()) { 

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
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameLockType__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


                return myDataTable;
        }


        public static bool IsExist(int ID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT Found=1 FROM FrameLockType WHERE ID = @id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);


                        myConnection.Open();
                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            isFound = myReader.HasRows;

                            myReader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameLockType__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }




    }
}
