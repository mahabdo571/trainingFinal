using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessFrameUpperPart
    {


        public static bool GetFrameUpperPartByID(int ID, ref bool Kitum,ref bool Nerousta,ref int BottomSize,
            ref string upperPartType,ref int upperPartSize , ref int FrameID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM FrameUpperPart WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                Kitum = (bool)myReader["Kitum"];
                                Nerousta = (bool)myReader["Nerousta"];
                                BottomSize = (int)myReader["BottomSize"];
                                upperPartType = (string)myReader["upperPartType"];
                                upperPartSize = (int)myReader["upperPartSize"];
                                FrameID = (int)myReader["FrameID"];






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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameUpperPart__FUNCTION__GetFrameUpperPartByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;  
            }

            return isFound;





        }

        public static bool GetByFrameID(ref int ID, ref bool Kitum, ref bool Nerousta, ref int BottomSize,
            ref string upperPartType, ref int upperPartSize, int FrameID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM FrameUpperPart WHERE FrameID=@FrameID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection)) { 

                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);



                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {

                        if (myReader.Read())
                        {

                            Kitum = (bool)myReader["Kitum"];
                            Nerousta = (bool)myReader["Nerousta"];
                            BottomSize = (int)myReader["BottomSize"];
                            upperPartType = (string)myReader["upperPartType"];
                            upperPartSize = (int)myReader["upperPartSize"];
                            FrameID = (int)myReader["FrameID"];


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameUpperPart__FUNCTION__GetByFrameID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }




        public static int Add(  bool Kitum,  bool Nerousta,  int BottomSize,
             string upperPartType,  int upperPartSize, int FrameID)
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO FrameUpperPart
(Kitum,Nerousta,BottomSize,upperPartType,upperPartSize,FrameID)
VALUES
(@Kitum ,@Nerousta ,@BottomSize ,@upperPartType,@upperPartSize,@FrameID); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@Kitum", Kitum);
                        myCommand.Parameters.AddWithValue("@Nerousta", Nerousta);
                        myCommand.Parameters.AddWithValue("@BottomSize", BottomSize);
                        myCommand.Parameters.AddWithValue("@upperPartType", upperPartType);
                        myCommand.Parameters.AddWithValue("@upperPartSize", upperPartSize);

                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);




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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameUpperPart__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }

            return ID;

        }



        public static bool Update(int ID,bool Kitum, bool Nerousta, int BottomSize,
             string upperPartType, int upperPartSize, int FrameID)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE FrameUpperPart SET 
Kitum=@Kitum,
Nerousta=@Nerousta,
BottomSize=@BottomSize,
upperPartType=@upperPartType,
upperPartSize=@upperPartSize,
FrameID=@FrameID


WHERE ID=@ID";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@Kitum", Kitum);
                        myCommand.Parameters.AddWithValue("@Nerousta", Nerousta);
                        myCommand.Parameters.AddWithValue("@BottomSize", BottomSize);
                        myCommand.Parameters.AddWithValue("@upperPartType", upperPartType);
                        myCommand.Parameters.AddWithValue("@upperPartSize", upperPartSize);

                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);





                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameUpperPart__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM FrameUpperPart WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameUpperPart__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT * FROM FrameUpperPart";

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
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameUpperPart__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM FrameUpperPart WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameUpperPart__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }





    }
}
