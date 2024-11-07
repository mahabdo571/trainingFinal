using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace sharaDatabase
{
    public class claDataAccessWingWindows
    {



        public static bool GetByID(int ID, ref string WindowType, ref string GlassType, ref string TrisType, ref string OpeningDirection, ref int CircleDiameter, ref int CircleLocationFromBottom,
            ref int WindowHeight, ref int WindowWidth, ref int WindowPositionFromAbove, ref int WindowPositionFromHandle, ref int TrisHeight,
            ref int TrisWidth, ref int TrisPositionFromHandle, ref int TrisPositionFromAbove, ref int TrisPositionFromBottom,
            ref int WingID,ref bool WindoInCenter,ref bool  TrisInCenter,ref bool AorHole)
        {
            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM WingWindows WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                WindowType = (string)myReader["WindowType"];
                                GlassType = (string)myReader["GlassType"];
                                TrisType = (string)myReader["TrisType"];
                                OpeningDirection = (string)myReader["OpeningDirection"];
                                CircleDiameter = (int)myReader["CircleDiameter"];
                                CircleLocationFromBottom = (int)myReader["CircleLocationFromBottom"];
                                WindowHeight = (int)myReader["WindowHeight"];
                                WindowWidth = (int)myReader["WindowWidth"];
                                WindowPositionFromAbove = (int)myReader["WindowPositionFromAbove"];
                                WindowPositionFromHandle = (int)myReader["WindowPositionFromHandle"];
                                TrisHeight = (int)myReader["TrisHeight"];
                                TrisWidth = (int)myReader["TrisWidth"];
                                TrisPositionFromHandle = (int)myReader["TrisPositionFromHandle"];
                                TrisPositionFromAbove = (int)myReader["TrisPositionFromAbove"];
                                TrisPositionFromBottom = (int)myReader["TrisPositionFromBottom"];
                                WindoInCenter = (bool)myReader["WindoInCenter"];
                                TrisInCenter = (bool)myReader["TrisInCenter"];
                                AorHole = (bool)myReader["AorHole"];


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_claDataAccessWingWindows__FUNCTION__GetByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }
          



            return isFound;


        }

        public static bool GetByWingID(ref int ID, ref string WindowType, ref string GlassType, ref string TrisType, ref string OpeningDirection, ref int CircleDiameter, ref int CircleLocationFromBottom,
            ref int WindowHeight, ref int WindowWidth, ref int WindowPositionFromAbove, ref int WindowPositionFromHandle, ref int TrisHeight,
            ref int TrisWidth,   ref int TrisPositionFromHandle, ref int TrisPositionFromAbove, ref int TrisPositionFromBottom,
             int WingID,ref bool WindoInCenter,ref bool TrisInCenter,ref bool AorHole)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM WingWindows WHERE WingID=@WingID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@WingID", WingID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {


                                WindowType = (string)myReader["WindowType"];
                                GlassType = (string)myReader["GlassType"];
                                TrisType = (string)myReader["TrisType"];
                                OpeningDirection = (string)myReader["OpeningDirection"];
                                CircleDiameter = (int)myReader["CircleDiameter"];
                                CircleLocationFromBottom = (int)myReader["CircleLocationFromBottom"];
                                WindowHeight = (int)myReader["WindowHeight"];
                                WindowWidth = (int)myReader["WindowWidth"];
                                WindowPositionFromAbove = (int)myReader["WindowPositionFromAbove"];
                                WindowPositionFromHandle = (int)myReader["WindowPositionFromHandle"];
                                TrisHeight = (int)myReader["TrisHeight"];
                                TrisWidth = (int)myReader["TrisWidth"];
                                TrisPositionFromHandle = (int)myReader["TrisPositionFromHandle"];
                                TrisPositionFromAbove = (int)myReader["TrisPositionFromAbove"];
                                TrisPositionFromBottom = (int)myReader["TrisPositionFromBottom"];
                                WindoInCenter = (bool)myReader["WindoInCenter"];
                                TrisInCenter = (bool)myReader["TrisInCenter"];
                                AorHole = (bool)myReader["AorHole"];



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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_claDataAccessWingWindows__FUNCTION__GetByWingID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }




        public static int Add(string WindowType, string GlassType, string TrisType, string OpeningDirection, int CircleDiameter, int CircleLocationFromBottom,
             int WindowHeight, int WindowWidth, int WindowPositionFromAbove, int WindowPositionFromHandle, int TrisHeight, int TrisWidth, int TrisPositionFromHandle,
             int TrisPositionFromAbove,  int TrisPositionFromBottom, int WingID,bool WindoInCenter,bool TrisInCenter
            , bool AorHole)
        {

            int ID = -1;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO WingWindows
(WindowType,GlassType,TrisType,OpeningDirection,CircleDiameter,CircleLocationFromBottom,WindowHeight,WindowWidth,WindowPositionFromAbove,WindowPositionFromHandle,TrisHeight,TrisWidth,TrisPositionFromHandle,TrisPositionFromAbove,TrisPositionFromBottom,WingID,WindoInCenter,TrisInCenter,AorHole)
VALUES
(@WindowType,@GlassType,@TrisType,@OpeningDirection,@CircleDiameter,@CircleLocationFromBottom,@WindowHeight,@WindowWidth,@WindowPositionFromAbove,@WindowPositionFromHandle,@TrisHeight,@TrisWidth,@TrisPositionFromHandle,@TrisPositionFromAbove,@TrisPositionFromBottom,@WingID,@WindoInCenter,@TrisInCenter,@AorHole); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@WindowType", WindowType);
                        myCommand.Parameters.AddWithValue("@GlassType", GlassType);
                        myCommand.Parameters.AddWithValue("@TrisType", TrisType);
                        myCommand.Parameters.AddWithValue("@OpeningDirection", OpeningDirection);
                        myCommand.Parameters.AddWithValue("@CircleDiameter", CircleDiameter);
                        myCommand.Parameters.AddWithValue("@CircleLocationFromBottom", CircleLocationFromBottom);
                        myCommand.Parameters.AddWithValue("@WindowHeight", WindowHeight);
                        myCommand.Parameters.AddWithValue("@WindowWidth", WindowWidth);
                        myCommand.Parameters.AddWithValue("@WindowPositionFromAbove", WindowPositionFromAbove);
                        myCommand.Parameters.AddWithValue("@WindowPositionFromHandle", WindowPositionFromHandle);
                        myCommand.Parameters.AddWithValue("@TrisHeight", TrisHeight);
                        myCommand.Parameters.AddWithValue("@TrisWidth", TrisWidth);
                        myCommand.Parameters.AddWithValue("@TrisPositionFromHandle", TrisPositionFromHandle);
                        myCommand.Parameters.AddWithValue("@TrisPositionFromAbove", TrisPositionFromAbove);
                        myCommand.Parameters.AddWithValue("@TrisPositionFromBottom", TrisPositionFromBottom);
                        myCommand.Parameters.AddWithValue("@WingID", WingID);
                        myCommand.Parameters.AddWithValue("@WindoInCenter", WindoInCenter);
                        myCommand.Parameters.AddWithValue("@TrisInCenter", TrisInCenter);
                        myCommand.Parameters.AddWithValue("@AorHole", AorHole);


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_claDataAccessWingWindows__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }
            return ID;

        }



        public static bool Update(int ID, string WindowType, string GlassType, string TrisType, string OpeningDirection, int CircleDiameter, int CircleLocationFromBottom,
             int WindowHeight, int WindowWidth, int WindowPositionFromAbove, int WindowPositionFromHandle, int TrisHeight, int TrisWidth, int TrisPositionFromHandle,
             int TrisPositionFromAbove,int TrisPositionFromBottom, int WingID,bool WindoInCenter,bool TrisInCenter,bool AorHole)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE WingWindows SET 
WindowType=@WindowType,
GlassType=@GlassType,
TrisType=@TrisType,
OpeningDirection=@OpeningDirection,
CircleDiameter=@CircleDiameter,
CircleLocationFromBottom=@CircleLocationFromBottom,
WindowHeight=@WindowHeight,
WindowWidth=@WindowWidth,
WindowPositionFromAbove=@WindowPositionFromAbove,
WindowPositionFromHandle=@WindowPositionFromHandle,
TrisHeight=@TrisHeight,
TrisWidth=@TrisWidth,
TrisPositionFromHandle=@TrisPositionFromHandle,
TrisPositionFromAbove=@TrisPositionFromAbove,
TrisPositionFromBottom=@TrisPositionFromBottom,
WindoInCenter=@WindoInCenter,
TrisInCenter=@TrisInCenter,
AorHole=@AorHole,
WingID=@WingID



WHERE ID=@ID";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@WindowType", WindowType);
                        myCommand.Parameters.AddWithValue("@GlassType", GlassType);
                        myCommand.Parameters.AddWithValue("@TrisType", TrisType);
                        myCommand.Parameters.AddWithValue("@OpeningDirection", OpeningDirection);
                        myCommand.Parameters.AddWithValue("@CircleDiameter", CircleDiameter);
                        myCommand.Parameters.AddWithValue("@CircleLocationFromBottom", CircleLocationFromBottom);
                        myCommand.Parameters.AddWithValue("@WindowHeight", WindowHeight);
                        myCommand.Parameters.AddWithValue("@WindowWidth", WindowWidth);
                        myCommand.Parameters.AddWithValue("@WindowPositionFromAbove", WindowPositionFromAbove);
                        myCommand.Parameters.AddWithValue("@WindowPositionFromHandle", WindowPositionFromHandle);
                        myCommand.Parameters.AddWithValue("@TrisHeight", TrisHeight);
                        myCommand.Parameters.AddWithValue("@TrisWidth", TrisWidth);
                        myCommand.Parameters.AddWithValue("@TrisPositionFromHandle", TrisPositionFromHandle);
                        myCommand.Parameters.AddWithValue("@TrisPositionFromAbove", TrisPositionFromAbove);
                        myCommand.Parameters.AddWithValue("@TrisPositionFromBottom", TrisPositionFromBottom);
                        myCommand.Parameters.AddWithValue("@WingID", WingID);
                        myCommand.Parameters.AddWithValue("@WindoInCenter", WindoInCenter);
                        myCommand.Parameters.AddWithValue("@TrisInCenter", TrisInCenter);
                        myCommand.Parameters.AddWithValue("@AorHole", AorHole);





                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_claDataAccessWingWindows__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM WingWindows WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_claDataAccessWingWindows__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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


                    string myQuery = "SELECT * FROM WingWindows";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_claDataAccessWingWindows__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


            return myDataTable;
        }


        public static bool IsExist(int ID)
        {
            bool isFound = false;
            try { 
            using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
            {

                string myQuery = "SELECT Found=1 FROM WingWindows WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_claDataAccessWingWindows__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }


    }
}
