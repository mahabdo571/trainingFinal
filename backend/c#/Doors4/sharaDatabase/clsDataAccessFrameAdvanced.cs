using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessFrameAdvanced
    {

        public static bool GetByID(int ID, ref int FrameID,ref int FromAbove,ref int FromBottom,ref bool HiddenOil,ref bool ManualSize)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    string myQuery = "SELECT * FROM FrameAdvanced WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                FrameID = (int)myReader["FrameID"];
                                FromAbove = (int)myReader["FromAbove"];
                                FromBottom = (int)myReader["FromBottom"];
                                HiddenOil = (bool)myReader["HiddenOil"];
                                ManualSize = (bool)myReader["ManualSize"];

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAFrameAdvanced__FUNCTION__GetByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;


        }


        public static bool GetByFrameID(ref int ID, int FrameID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    string myQuery = "SELECT * FROM FrameAdvanced WHERE FrameID=@FrameID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAFrameAdvanced__FUNCTION__GetByFrameID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;


        }

        public static int Add(int FrameID,  int FromAbove,  int FromBottom,  bool HiddenOil,  bool ManualSize)
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"
INSERT INTO FrameAdvanced
           (FrameID,FromAbove,FromBottom,HiddenOil,ManualSize)
     VALUES(@FrameID,@FromAbove,@FromBottom,@HiddenOil,@ManualSize);
     SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);
                        myCommand.Parameters.AddWithValue("@FromAbove", FromAbove);
                        myCommand.Parameters.AddWithValue("@FromBottom", FromBottom);
                        myCommand.Parameters.AddWithValue("@HiddenOil", HiddenOil);
                        myCommand.Parameters.AddWithValue("@ManualSize", ManualSize);




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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAFrameAdvanced__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;

            }


            return ID;

        }



        public static bool Update(int ID, int FrameID , int FromAbove, int FromBottom, bool HiddenOil, bool ManualSize)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE FrameAdvanced SET 
FrameID=@FrameID , 
FromAbove=@FromAbove , 
FromBottom=@FromBottom , 
HiddenOil=@HiddenOil , 
ManualSize=@ManualSize


WHERE ID=@id";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);
                        myCommand.Parameters.AddWithValue("@FromAbove", FromAbove);
                        myCommand.Parameters.AddWithValue("@FromBottom", FromBottom);
                        myCommand.Parameters.AddWithValue("@HiddenOil", HiddenOil);
                        myCommand.Parameters.AddWithValue("@ManualSize", ManualSize);


                        myCommand.Parameters.AddWithValue("@id", ID);


                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();

                    }

                }
            }
            catch
                        (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAFrameAdvanced__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM FrameAdvanced WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAFrameAdvanced__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);
                rowsAffected = -1;
            }

            return (rowsAffected > 0);

        }




        public static bool IsExist(int ID)
        {
            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT Found=1 FROM FrameAdvanced WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAFrameAdvanced__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);
                isFound = false;
            }

            return isFound;
        }

        public static DataTable GetAll()
        {
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT * FROM FrameAdvanced"; //"SELECT * FROM  dbo.funFrameAdvanced()"; //;

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAFrameAdvanced__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);
                myDataTable = null;
            }

            return myDataTable;
        }



    }
}
