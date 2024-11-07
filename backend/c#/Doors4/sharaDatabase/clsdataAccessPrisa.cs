using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsdataAccessPrisa
    {


        public static bool GetPrisaByID(int ID
            , ref decimal magnet
            , ref decimal corner1
            , ref decimal corner2
            , ref decimal corner3
            , ref decimal corner4
            , ref decimal corner5
            , ref decimal corner6
            , ref decimal corner7
            , ref decimal corner8
            , ref decimal corner9
            , ref decimal corner10
            , ref decimal corner11
            , ref decimal corner12
            , ref decimal corner13
            , ref decimal corner14
            , ref decimal corner15
            , ref decimal corner16
            , ref decimal corner17
            , ref decimal corner18
            , ref decimal corner19
            , ref decimal corner20
            , ref int FrameID


            )
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    string myQuery = "SELECT * FROM Prisa WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                magnet = Convert.ToDecimal(myReader["magnet"]);
                                corner1 = Convert.ToDecimal(myReader["corner1"]);
                                corner2 = Convert.ToDecimal(myReader["corner2"]);
                                corner3 = Convert.ToDecimal(myReader["corner3"]);
                                corner4 = Convert.ToDecimal(myReader["corner4"]);
                                corner5 = Convert.ToDecimal(myReader["corner5"]);
                                corner6 = Convert.ToDecimal(myReader["corner6"]);
                                corner7 = Convert.ToDecimal(myReader["corner7"]);
                                corner8 = Convert.ToDecimal(myReader["corner8"]);
                                corner9 = Convert.ToDecimal(myReader["corner9"]);
                                corner10 = Convert.ToDecimal(myReader["corner10"]);
                                corner11= Convert.ToDecimal(myReader["corner11"]);
                                corner12 = Convert.ToDecimal(myReader["corner12"]);
                                corner13 = Convert.ToDecimal(myReader["corner13"]);
                                corner14 = Convert.ToDecimal(myReader["corner14"]);
                                corner15 = Convert.ToDecimal(myReader["corner15"]);
                                corner16= Convert.ToDecimal(myReader["corner16"]);
                                corner17 = Convert.ToDecimal(myReader["corner17"]);
                                corner18 = Convert.ToDecimal(myReader["corner18"]);
                                corner19 = Convert.ToDecimal(myReader["corner19"]);
                                corner20 = Convert.ToDecimal(myReader["corner20"]);
                                FrameID = Convert.ToInt32(myReader["FrameID"]);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsdataAccessPrisa__FUNCTION__GetPrisaByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;


        }


        public static bool GetPrisaByFrameID(ref int ID ,  int FrameID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    string myQuery = "SELECT * FROM Prisa WHERE FrameID=@FrameID";

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
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsdataAccessPrisa__FUNCTION__GetPrisaByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;


        }



        public static int Add(
              decimal  magnet
             , decimal corner1
             , decimal corner2
             , decimal corner3
             , decimal corner4
             , decimal corner5
             , decimal corner6
             , decimal corner7
             , decimal corner8
             , decimal corner9
             , decimal corner10
             , decimal corner11
             , decimal corner12
             , decimal corner13
             , decimal corner14
             , decimal corner15
             , decimal corner16
             , decimal corner17
             , decimal corner18
             , decimal corner19
             , decimal corner20
             , int     FrameID


            )
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"
INSERT INTO Prisa
(
 magnet
 ,corner1
 ,corner2
 ,corner3
 ,corner4
 ,corner5
 ,corner6
 ,corner7
 ,corner8
 ,corner9
 ,corner10
 ,corner11
 ,corner12
 ,corner13
 ,corner14
 ,corner15
 ,corner16
 ,corner17
 ,corner18
 ,corner19
 ,corner20
 ,FrameID

)
     VALUES 
(
  @magnet
 ,@corner1
 ,@corner2
 ,@corner3
 ,@corner4
 ,@corner5
 ,@corner6
 ,@corner7
 ,@corner8
 ,@corner9
 ,@corner10
 ,@corner11
 ,@corner12
 ,@corner13
 ,@corner14
 ,@corner15
 ,@corner16
 ,@corner17
 ,@corner18
 ,@corner19
 ,@corner20
 ,@FrameID
);
     
SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@magnet", magnet);
                        myCommand.Parameters.AddWithValue("@corner1", corner1);
                        myCommand.Parameters.AddWithValue("@corner2", corner2);
                        myCommand.Parameters.AddWithValue("@corner3", corner3);
                        myCommand.Parameters.AddWithValue("@corner4", corner4);
                        myCommand.Parameters.AddWithValue("@corner5", corner5);
                        myCommand.Parameters.AddWithValue("@corner6", corner6);
                        myCommand.Parameters.AddWithValue("@corner7", corner7);
                        myCommand.Parameters.AddWithValue("@corner8", corner8);
                        myCommand.Parameters.AddWithValue("@corner9", corner9);
                        myCommand.Parameters.AddWithValue("@corner10", corner10);
                        myCommand.Parameters.AddWithValue("@corner11", corner11);
                        myCommand.Parameters.AddWithValue("@corner12", corner12);
                        myCommand.Parameters.AddWithValue("@corner13", corner13);
                        myCommand.Parameters.AddWithValue("@corner14", corner14);
                        myCommand.Parameters.AddWithValue("@corner15", corner15);
                        myCommand.Parameters.AddWithValue("@corner16", corner16);
                        myCommand.Parameters.AddWithValue("@corner17", corner17);
                        myCommand.Parameters.AddWithValue("@corner18", corner18);
                        myCommand.Parameters.AddWithValue("@corner19", corner19);
                        myCommand.Parameters.AddWithValue("@corner20", corner20);
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
            catch
               (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAColorSide__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;

            }


            return ID;

        }

        public static bool Update(int ID,
             decimal magnet
             , decimal corner1
             , decimal corner2
             , decimal corner3
             , decimal corner4
             , decimal corner5
             , decimal corner6
             , decimal corner7
             , decimal corner8
             , decimal corner9
             , decimal corner10
             , decimal corner11
             , decimal corner12
             , decimal corner13
             , decimal corner14
             , decimal corner15
             , decimal corner16
             , decimal corner17
             , decimal corner18
             , decimal corner19
             , decimal corner20
             , int FrameID


            )
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE Prisa SET 
magnet=@magnet 
 ,corner1   =@corner1
 ,corner2   =@corner2
 ,corner3   =@corner3
 ,corner4   =@corner4
 ,corner5   =@corner5
 ,corner6   =@corner6
 ,corner7   =@corner7
 ,corner8   =@corner8
 ,corner9   =@corner9
 ,corner10  =@corner10
 ,corner11  =@corner11
 ,corner12  =@corner12
 ,corner13  =@corner13
 ,corner14  =@corner14
 ,corner15  =@corner15
 ,corner16  =@corner16
 ,corner17  =@corner17
 ,corner18  =@corner18
 ,corner19  =@corner19
 ,corner20  =@corner20
 ,FrameID   =@FrameID


WHERE ID=@id";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@magnet", magnet);
                        myCommand.Parameters.AddWithValue("@corner1", corner1);
                        myCommand.Parameters.AddWithValue("@corner2", corner2);
                        myCommand.Parameters.AddWithValue("@corner3", corner3);
                        myCommand.Parameters.AddWithValue("@corner4", corner4);
                        myCommand.Parameters.AddWithValue("@corner5", corner5);
                        myCommand.Parameters.AddWithValue("@corner6", corner6);
                        myCommand.Parameters.AddWithValue("@corner7", corner7);
                        myCommand.Parameters.AddWithValue("@corner8", corner8);
                        myCommand.Parameters.AddWithValue("@corner9", corner9);
                        myCommand.Parameters.AddWithValue("@corner10", corner10);
                        myCommand.Parameters.AddWithValue("@corner11", corner11);
                        myCommand.Parameters.AddWithValue("@corner12", corner12);
                        myCommand.Parameters.AddWithValue("@corner13", corner13);
                        myCommand.Parameters.AddWithValue("@corner14", corner14);
                        myCommand.Parameters.AddWithValue("@corner15", corner15);
                        myCommand.Parameters.AddWithValue("@corner16", corner16);
                        myCommand.Parameters.AddWithValue("@corner17", corner17);
                        myCommand.Parameters.AddWithValue("@corner18", corner18);
                        myCommand.Parameters.AddWithValue("@corner19", corner19);
                        myCommand.Parameters.AddWithValue("@corner20", corner20);
                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);




                        myCommand.Parameters.AddWithValue("@id", ID);


                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();

                    }

                }
            }
            catch
                        (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAColorSide__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM Prisa WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAColorSide__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);
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

                    string myQuery = "SELECT Found=1 FROM Prisa WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAColorSide__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);
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

                    string myQuery = "SELECT * FROM Prisa"; //"SELECT * FROM  dbo.funColorSide()"; //;

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAColorSide__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);
                myDataTable = null;
            }

            return myDataTable;
        }


    }
}
