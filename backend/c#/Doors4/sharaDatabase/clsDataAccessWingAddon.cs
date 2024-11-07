using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessWingAddon
    {





        public static bool GetByID(int ID, ref string StainlessBand, ref string Offirt, 
            ref float ThicknessOffirt, ref bool PullHandle, ref bool ReturnHidden, 
            ref int PullHandleHeight, ref int PullHandleWidth,
            ref int PullHandleLocationFromBottom , ref int PullHandleLocationFromabove,ref int WingID

            )
        {

            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM WingAddon WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                StainlessBand = (string)myReader["StainlessBand"];
                                Offirt = (string)myReader["Offirt"];
                                ThicknessOffirt = Convert.ToSingle(myReader["ThicknessOffirt"]);
                                PullHandle = (bool)myReader["PullHandle"];
                                ReturnHidden = (bool)myReader["ReturnHidden"];
                                PullHandleHeight = (int)myReader["PullHandleHeight"];
                                PullHandleWidth = (int)myReader["PullHandleWidth"];
                                PullHandleLocationFromBottom = (int)myReader["PullHandleLocationFromBottom"];
                                PullHandleLocationFromabove = (int)myReader["PullHandleLocationFromabove"];
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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAddon__FUNCTION__GetByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }
            return isFound;





        }

        public static bool GetByWingID(ref int ID, ref string StainlessBand, 
            ref string Offirt, ref float ThicknessOffirt, ref bool PullHandle,
            ref bool ReturnHidden, ref int PullHandleHeight,ref int PullHandleWidth,
            ref int PullHandleLocationFromBottom  ,ref int PullHandleLocationFromabove, int WingID)
        {
            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM WingAddon WHERE WingID=@WingID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@WingID", WingID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {


                                StainlessBand = (string)myReader["StainlessBand"];
                                Offirt = (string)myReader["Offirt"];
                                ThicknessOffirt = Convert.ToSingle(myReader["ThicknessOffirt"]);
                                PullHandle = (bool)myReader["PullHandle"];
                                ReturnHidden = (bool)myReader["ReturnHidden"];
                                PullHandleHeight = (int)myReader["PullHandleHeight"];
                                PullHandleLocationFromBottom = (int)myReader["PullHandleLocationFromBottom"];
                                PullHandleLocationFromabove = (int)myReader["PullHandleLocationFromabove"];
                                PullHandleWidth = (int)myReader["PullHandleWidth"];




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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAddon__FUNCTION__GetByWingID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }




        public static int Add(string StainlessBand, string Offirt, float ThicknessOffirt,
            bool PullHandle, bool ReturnHidden, int PullHandleHeight, int PullHandleWidth,
            int PullHandleLocationFromBottom,   int PullHandleLocationFromabove,int WingID)
        {

            int ID = -1;

            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO WingAddon
(StainlessBand,Offirt,ThicknessOffirt,PullHandle,ReturnHidden,PullHandleHeight,PullHandleWidth,PullHandleLocationFromBottom,PullHandleLocationFromabove,WingID)
VALUES
(@StainlessBand,@Offirt,@ThicknessOffirt,@PullHandle,@ReturnHidden,@PullHandleHeight,@PullHandleWidth,@PullHandleLocationFromBottom,@PullHandleLocationFromabove,@WingID); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@StainlessBand", StainlessBand);
                        myCommand.Parameters.AddWithValue("@Offirt", Offirt);
                        myCommand.Parameters.AddWithValue("@ThicknessOffirt", ThicknessOffirt);
                        myCommand.Parameters.AddWithValue("@PullHandle", PullHandle);
                        myCommand.Parameters.AddWithValue("@ReturnHidden", ReturnHidden);
                        myCommand.Parameters.AddWithValue("@PullHandleHeight", PullHandleHeight);
                        myCommand.Parameters.AddWithValue("@PullHandleWidth", PullHandleWidth);
                        myCommand.Parameters.AddWithValue("@PullHandleLocationFromBottom", PullHandleLocationFromBottom);
                        myCommand.Parameters.AddWithValue("@PullHandleLocationFromabove", PullHandleLocationFromabove);
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
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAddon__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }

            return ID;

        }



        public static bool Update(int ID, string StainlessBand, string Offirt,
            float ThicknessOffirt, bool PullHandle, bool ReturnHidden, 
            int PullHandleHeight, int PullHandleWidth,int PullHandleLocationFromBottom, 
            int PullHandleLocationFromabove,int WingID)
        {

            int rowsAffected = 0;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE WingAddon SET 
StainlessBand=@StainlessBand,
Offirt=@Offirt,
ThicknessOffirt=@ThicknessOffirt,
PullHandle=@PullHandle,
ReturnHidden=@ReturnHidden,
PullHandleHeight=@PullHandleHeight,
PullHandleWidth=@PullHandleWidth,
PullHandleLocationFromBottom=@PullHandleLocationFromBottom,
PullHandleLocationFromabove=@PullHandleLocationFromabove,
WingID=@WingID



WHERE ID=@ID";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@StainlessBand", StainlessBand);
                        myCommand.Parameters.AddWithValue("@Offirt", Offirt);
                        myCommand.Parameters.AddWithValue("@ThicknessOffirt", ThicknessOffirt);
                        myCommand.Parameters.AddWithValue("@PullHandle", PullHandle);
                        myCommand.Parameters.AddWithValue("@ReturnHidden", ReturnHidden);
                        myCommand.Parameters.AddWithValue("@PullHandleHeight", PullHandleHeight);
                        myCommand.Parameters.AddWithValue("@PullHandleWidth", PullHandleWidth);
                        myCommand.Parameters.AddWithValue("@PullHandleLocationFromBottom", PullHandleLocationFromBottom);
                        myCommand.Parameters.AddWithValue("@PullHandleLocationFromabove", PullHandleLocationFromabove);
                        myCommand.Parameters.AddWithValue("@WingID", WingID);





                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAddon__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM WingAddon WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAddon__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT * FROM WingAddon";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAddon__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM WingAddon WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAddon__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }
    }
}
