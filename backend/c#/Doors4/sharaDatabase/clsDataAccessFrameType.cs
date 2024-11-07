using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessFrameType
    {



        public static bool GetFrameTypeByID(int ID, ref string AgroupOfDoorFrames, ref string TypeOfDoorFrame,
            ref string LevelType, ref string WallType,ref int FrameID)
        {

            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM FrameType WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                AgroupOfDoorFrames = (string)myReader["AgroupOfDoorFrames"];
                                TypeOfDoorFrame = (string)myReader["TypeOfDoorFrame"];
                                LevelType = (string)myReader["LevelType"];
                                WallType = (string)myReader["WallType"];
                                FrameID = (int)myReader["FrameID"];



                                //if (myReader["Image"] != DBNull.Value)
                                //{
                                //    Image = (string)myReader["Image"];
                                //}
                                //else
                                //{
                                //    Image = "";
                                //}


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameType__FUNCTION__GetFrameTypeByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }
            return isFound;





        }

        public static bool GetByFrameID(ref int ID, ref string AgroupOfDoorFrames, ref string TypeOfDoorFrame,
           ref string LevelType, ref string WallType, int FrameID)
        {

            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = "SELECT * FROM FrameType WHERE FrameID=@FrameID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                if (myReader["AgroupOfDoorFrames"] == DBNull.Value ||

                               myReader["TypeOfDoorFrame"] == DBNull.Value ||
                                myReader["LevelType"] == DBNull.Value ||
                              myReader["WallType"] == DBNull.Value

                                    )

                                {
                                    AgroupOfDoorFrames = "";
                                    TypeOfDoorFrame = "";
                                    LevelType = "";
                                    WallType = "";


                                }
                                else
                                {
                                    AgroupOfDoorFrames = (string)myReader["AgroupOfDoorFrames"];
                                    TypeOfDoorFrame = (string)myReader["TypeOfDoorFrame"];
                                    LevelType = (string)myReader["LevelType"];
                                    WallType = (string)myReader["WallType"];
                                    ID = (int)myReader["ID"];
                                }




                                //if (myReader["Image"] != DBNull.Value)
                                //{
                                //    Image = (string)myReader["Image"];
                                //}
                                //else
                                //{
                                //    Image = "";
                                //}


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameType__FUNCTION__GetByFrameID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

return isFound;





        }




        public static int Add(string AgroupOfDoorFrames,  string TypeOfDoorFrame,
             string LevelType,  string WallType,int FrameID)
        {

            int ID = -1;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO FrameType
(AgroupOfDoorFrames,TypeOfDoorFrame,LevelType,WallType,FrameID)
VALUES
(@AgroupOfDoorFrames ,@TypeOfDoorFrame ,@LevelType ,@WallType,@FrameID); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@AgroupOfDoorFrames", AgroupOfDoorFrames);
                        myCommand.Parameters.AddWithValue("@TypeOfDoorFrame", TypeOfDoorFrame);
                        myCommand.Parameters.AddWithValue("@LevelType", LevelType);
                        myCommand.Parameters.AddWithValue("@WallType", WallType);
                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);
                        //if (Image != "" && Image != null)
                        //    myCommand.Parameters.AddWithValue("@Image", Image);
                        //else
                        //    myCommand.Parameters.AddWithValue("@Image", System.DBNull.Value);


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameType__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }

            return ID;

        }



        public static bool Update(int ID,string AgroupOfDoorFrames, string TypeOfDoorFrame,
             string LevelType, string WallType,int FrameID)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE FrameType SET 
AgroupOfDoorFrames=@AgroupOfDoorFrames,
LevelType=@LevelType,
TypeOfDoorFrame=@TypeOfDoorFrame,
WallType=@WallType,
FrameID=@FrameID


WHERE ID=@id";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);
                        myCommand.Parameters.AddWithValue("@AgroupOfDoorFrames", AgroupOfDoorFrames);
                        myCommand.Parameters.AddWithValue("@TypeOfDoorFrame", TypeOfDoorFrame);
                        myCommand.Parameters.AddWithValue("@LevelType", LevelType);
                        myCommand.Parameters.AddWithValue("@WallType", WallType);
                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);
                        //if (Image != "" && Image != null)
                        //    myCommand.Parameters.AddWithValue("@Image", Image);
                        //else
                        //    myCommand.Parameters.AddWithValue("@Image", System.DBNull.Value);





                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameType__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM FrameType WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameType__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT * FROM FrameType";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {


                        myConnection.Open();

                        SqlDataReader myReader = myCommand.ExecuteReader();

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
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameType__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM FrameType WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrameType__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }




    }
}
