using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessWingHinge
    {


        public static bool GetByID(int ID, ref int H1, ref int H2, ref int H3, ref int H4, ref int H5, ref int H6,
            ref int Amount, ref int Size, ref int HeightToBottomHinge, ref string HingeType, ref bool UpperMid,
            ref int WingID)
        {

            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM WingHinge WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                H1 = (int)myReader["H1"];
                                H2 = (int)myReader["H2"];
                                H3 = (int)myReader["H3"];
                                H4 = (int)myReader["H4"];
                                H5 = (int)myReader["H5"];
                                H6 = (int)myReader["H6"];
                                Amount = (int)myReader["Amount"];
                                Size = (int)myReader["Size"];
                                HeightToBottomHinge = (int)myReader["HeightToBottomHinge"];
                                HingeType = (string)myReader["HingeType"];
                                UpperMid = (bool)myReader["UpperMid"];
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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingHinge__FUNCTION__GetByID",System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }
            return isFound;





        }

        public static bool GetByWingID(ref int ID, ref int H1, ref int H2, ref int H3, ref int H4, ref int H5, ref int H6,
            ref int Amount, ref int Size, ref int HeightToBottomHinge, ref string HingeType, ref bool UpperMid,
             int WingID)
        {
            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM WingHinge WHERE WingID=@WingID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@WingID", WingID);


                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {


                                H1 = (int)myReader["H1"];
                                H2 = (int)myReader["H2"];
                                H3 = (int)myReader["H3"];
                                H4 = (int)myReader["H4"];
                                H5 = (int)myReader["H5"];
                                H6 = (int)myReader["H6"];
                                Amount = (int)myReader["Amount"];
                                Size = (int)myReader["Size"];
                                HeightToBottomHinge = (int)myReader["HeightToBottomHinge"];
                                HingeType = (string)myReader["HingeType"];
                                UpperMid = (bool)myReader["UpperMid"];
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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingHinge__FUNCTION__GetByWingID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }




        public static int Add(int H1, int H2, int H3, int H4, int H5, int H6,
             int Amount, int Size, int HeightToBottomHinge, string HingeType, bool UpperMid,
             int WingID)
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO WingHinge
(H1,H2,H3,H4,H5,H6,Amount,Size,HeightToBottomHinge,HingeType,UpperMid,WingID)
VALUES
(@H1,@H2,@H3,@H4,@H5,@H6,@Amount,@Size,@HeightToBottomHinge,@HingeType,@UpperMid,@WingID); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@H1", H1);
                        myCommand.Parameters.AddWithValue("@H2", H2);
                        myCommand.Parameters.AddWithValue("@H3", H3);
                        myCommand.Parameters.AddWithValue("@H4", H4);
                        myCommand.Parameters.AddWithValue("@H5", H5);
                        myCommand.Parameters.AddWithValue("@H6", H6);
                        myCommand.Parameters.AddWithValue("@Amount", Amount);
                        myCommand.Parameters.AddWithValue("@Size", Size);
                        myCommand.Parameters.AddWithValue("@HeightToBottomHinge", HeightToBottomHinge);
                        myCommand.Parameters.AddWithValue("@HingeType", HingeType);
                        myCommand.Parameters.AddWithValue("@UpperMid", UpperMid);
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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingHinge__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }

return ID;

        }



        public static bool Update(int ID, int H1, int H2, int H3, int H4, int H5, int H6,
             int Amount, int Size, int HeightToBottomHinge, string HingeType, bool UpperMid,
             int WingID)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE WingHinge SET 
H1=@H1,
H2=@H2,
H3=@H3,
H4=@H4,
H5=@H5,
H6=@H6,
Amount=@Amount,
Size=@Size,
HeightToBottomHinge=@HeightToBottomHinge,
HingeType=@HingeType,
UpperMid=@UpperMid,
WingID=@WingID



WHERE ID=@ID";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@H1", H1);
                        myCommand.Parameters.AddWithValue("@H2", H2);
                        myCommand.Parameters.AddWithValue("@H3", H3);
                        myCommand.Parameters.AddWithValue("@H4", H4);
                        myCommand.Parameters.AddWithValue("@H5", H5);
                        myCommand.Parameters.AddWithValue("@H6", H6);
                        myCommand.Parameters.AddWithValue("@Amount", Amount);
                        myCommand.Parameters.AddWithValue("@Size", Size);
                        myCommand.Parameters.AddWithValue("@HeightToBottomHinge", HeightToBottomHinge);
                        myCommand.Parameters.AddWithValue("@HingeType", HingeType);
                        myCommand.Parameters.AddWithValue("@UpperMid", UpperMid);
                        myCommand.Parameters.AddWithValue("@WingID", WingID);




                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingHinge__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM WingHinge WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingHinge__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT * FROM WingHinge";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingHinge__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM WingHinge WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingHinge__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }





    }
}
