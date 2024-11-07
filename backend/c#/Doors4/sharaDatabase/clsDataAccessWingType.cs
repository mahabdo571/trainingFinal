using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace sharaDatabase
{
    public class clsDataAccessWingType
    {



        public static bool GetByID(int ID, ref string TEST1,ref string TEST2,ref string TEST3,ref string TEST4,ref int WingID)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM wingType WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);


                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                TEST1 = (string)myReader["TEST1"];
                                TEST2 = (string)myReader["TEST2"];
                                TEST3 = (string)myReader["TEST3"];
                                TEST4 = (string)myReader["TEST4"];
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
            catch(Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingType__FUNCTION__GetByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }
            return isFound;





        }

        public static bool GetByWingID(ref int ID, ref string TEST1, ref string TEST2, ref string TEST3, ref string TEST4,  int WingID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM wingType WHERE WingID=@WingID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@WingID", WingID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {


                                TEST1 = (string)myReader["TEST1"];
                                TEST2 = (string)myReader["TEST2"];
                                TEST3 = (string)myReader["TEST3"];
                                TEST4 = (string)myReader["TEST4"];




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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingType__FUNCTION__GetByWingID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }




        public static int Add(string TEST1, string TEST2, string TEST3, string TEST4, int WingID)
        {

            int ID = -1;

            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO wingType
(TEST1,TEST2,TEST3,TEST4,WingID)
VALUES
(@TEST1,@TEST2,@TEST3,@TEST4,@WingID); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@TEST1", TEST1);
                        myCommand.Parameters.AddWithValue("@TEST2", TEST2);
                        myCommand.Parameters.AddWithValue("@TEST3", TEST3);
                        myCommand.Parameters.AddWithValue("@TEST4", TEST4);
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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingType__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }

            return ID;

        }



        public static bool Update(int ID, string TEST1, string TEST2, string TEST3, string TEST4, int WingID)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE wingType SET 
TEST1=@TEST1,
TEST2=@TEST2,
TEST3=@TEST3,
TEST4=@TEST4,
WingID=@WingID



WHERE ID=@ID";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@TEST1", TEST1);
                        myCommand.Parameters.AddWithValue("@TEST2", TEST2);
                        myCommand.Parameters.AddWithValue("@TEST3", TEST3);
                        myCommand.Parameters.AddWithValue("@TEST4", TEST4);
                        myCommand.Parameters.AddWithValue("@WingID", WingID);





                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();


                    }
                }
            }
            catch
               (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingType__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM wingType WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingType__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT * FROM wingType";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingType__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM wingType WHERE ID = @id";

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
            catch
                  (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingType__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }
            return isFound;
        }






    }
}
