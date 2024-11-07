using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessWingLock
    {



        public static bool GetByID(int ID, ref string LockType, ref bool UpperLock, ref int LockMeasure, ref int UpperLockMeasure,ref int LockMeasureFrame, ref int UpperLockMeasureFrame, ref int WingID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM WingLock WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                LockType = (string)myReader["LockType"];
                                UpperLock = (bool)myReader["UpperLock"];
                                LockMeasure = (int)myReader["LockMeasure"];
                                UpperLockMeasure = (int)myReader["UpperLockMeasure"];
                                LockMeasureFrame = (int)myReader["LockMeasureFrame"];
                                UpperLockMeasureFrame = (int)myReader["UpperLockMeasureFrame"];
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
            catch
                       (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingLock__FUNCTION__GetByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }
            return isFound;





        }

        public static bool GetByWingID(ref int ID, ref string LockType, ref bool UpperLock, ref int LockMeasure, ref int UpperLockMeasure, ref int LockMeasureFrame, ref int UpperLockMeasureFrame, int WingID)
        {

            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM WingLock WHERE WingID=@WingID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@WingID", WingID);


                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {


                                LockType = (string)myReader["LockType"];
                                UpperLock = (bool)myReader["UpperLock"];
                                LockMeasure = (int)myReader["LockMeasure"];
                                UpperLockMeasure = (int)myReader["UpperLockMeasure"];
                                LockMeasureFrame = (int)myReader["LockMeasureFrame"];
                                UpperLockMeasureFrame = (int)myReader["UpperLockMeasureFrame"];




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
            catch
                                 (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingLock__FUNCTION__GetByWingID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }




        public static int Add(string LockType, bool UpperLock, int LockMeasure, int UpperLockMeasure, int LockMeasureFrame, int UpperLockMeasureFrame, int WingID)
        {

            int ID = -1;

            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO WingLock
(LockType,UpperLock,LockMeasure,UpperLockMeasure,LockMeasureFrame,UpperLockMeasureFrame,WingID)
VALUES
(@LockType,@UpperLock,@LockMeasure,@UpperLockMeasure,@LockMeasureFrame,@UpperLockMeasureFrame,@WingID); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@LockType", LockType);
                        myCommand.Parameters.AddWithValue("@UpperLock", UpperLock);
                        myCommand.Parameters.AddWithValue("@LockMeasure", LockMeasure);
                        myCommand.Parameters.AddWithValue("@UpperLockMeasure", UpperLockMeasure);
                        myCommand.Parameters.AddWithValue("@LockMeasureFrame", LockMeasureFrame);
                        myCommand.Parameters.AddWithValue("@UpperLockMeasureFrame", UpperLockMeasureFrame);
                        myCommand.Parameters.AddWithValue("@WingID", WingID);




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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingLock__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }

            return ID;

        }



        public static bool Update(int ID, string LockType, bool UpperLock, int LockMeasure, int UpperLockMeasure,  int LockMeasureFrame,int UpperLockMeasureFrame, int WingID)
        {

            int rowsAffected = 0;
            try {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString())) {


                    string myQuery = @"UPDATE WingLock SET 
LockType=@LockType,
UpperLock=@UpperLock,
LockMeasure=@LockMeasure,
UpperLockMeasure=@UpperLockMeasure,
LockMeasureFrame=@LockMeasureFrame,
UpperLockMeasureFrame=@UpperLockMeasureFrame,
WingID=@WingID



WHERE ID=@ID";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@LockType", LockType);
                        myCommand.Parameters.AddWithValue("@UpperLock", UpperLock);
                        myCommand.Parameters.AddWithValue("@LockMeasure", LockMeasure);
                        myCommand.Parameters.AddWithValue("@UpperLockMeasure", UpperLockMeasure);
                        myCommand.Parameters.AddWithValue("@LockMeasureFrame", LockMeasureFrame);
                        myCommand.Parameters.AddWithValue("@UpperLockMeasureFrame", UpperLockMeasureFrame);
                        myCommand.Parameters.AddWithValue("@WingID", WingID);




                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();

                    }
                }
            }
            catch
                                             (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingLock__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM WingLock WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingLock__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT * FROM WingLock";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingLock__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


                    return myDataTable;
        }


        public static bool IsExist(int ID)
        {
            bool isFound = false;

            try {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString())) {

                    string myQuery = "SELECT Found=1 FROM WingLock WHERE ID = @id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);

                        myConnection.Open();
                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            isFound = myReader.HasRows;

                            myReader.Close();
                        }
                    }   }
            }
            catch
                                                                    (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingLock__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }


    }
}
