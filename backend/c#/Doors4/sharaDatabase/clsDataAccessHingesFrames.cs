using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessHingesFrames
    {


        public static bool GetHingesFramesByID(int ID, ref int HingeDimension, ref int Hinge1,
            ref int Hinge2, ref int Hinge3, ref int Hinge4, ref int Hinge5,ref int Hinge6
            , ref int HeightToBottomHinge, ref int HingeAmount,ref bool TopMeddleHinge,ref string HingeMetal,
            ref string HingeType,ref string HingeConnection,ref int FrameID,ref bool NoCalcu


            )
        {
            bool isFound = false;
            try
            {


                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM HingesFrames WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                HingeDimension = (int)myReader["HingeDimension"];
                                Hinge1 = (int)myReader["Hinge1"];
                                Hinge2 = (int)myReader["Hinge2"];
                                Hinge3 = (int)myReader["Hinge3"];
                                Hinge4 = (int)myReader["Hinge4"];
                                Hinge5 = (int)myReader["Hinge5"];
                                Hinge6 = (int)myReader["Hinge6"];
                                FrameID = (int)myReader["FrameID"];
                                HeightToBottomHinge = (int)myReader["HeightToBottomHinge"];
                                HingeAmount = (int)myReader["HingeAmount"];
                                TopMeddleHinge = (bool)myReader["TopMeddleHinge"];
                                NoCalcu = (bool)myReader["NoCalcu"];
                                HingeMetal = (string)myReader["HingeMetal"];
                                HingeType = (string)myReader["HingeType"];
                                HingeConnection = (string)myReader["HingeConnection"];



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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessHingesFrames__FUNCTION__GetHingesFramesByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }
        public static bool GetByFrameID(ref int ID, ref int HingeDimension, ref int Hinge1,
         ref int Hinge2, ref int Hinge3, ref int Hinge4, ref int Hinge5, ref int Hinge6
         , ref int HeightToBottomHinge, ref int HingeAmount, ref bool TopMeddleHinge, ref string HingeMetal,
         ref string HingeType, ref string HingeConnection,  int FrameID,ref bool NoCalcu


         )
        {
            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM HingesFrames WHERE FrameID=@FrameID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                HingeDimension = (int)myReader["HingeDimension"];
                                Hinge1 = (int)myReader["Hinge1"];
                                Hinge2 = (int)myReader["Hinge2"];
                                Hinge3 = (int)myReader["Hinge3"];
                                Hinge4 = (int)myReader["Hinge4"];
                                Hinge5 = (int)myReader["Hinge5"];
                                Hinge6 = (int)myReader["Hinge6"];
                                ID = (int)myReader["ID"];
                                HeightToBottomHinge = (int)myReader["HeightToBottomHinge"];
                                HingeAmount = (int)myReader["HingeAmount"];
                                TopMeddleHinge = (bool)myReader["TopMeddleHinge"];
                                NoCalcu = (bool)myReader["NoCalcu"];
                                HingeMetal = (string)myReader["HingeMetal"];
                                HingeType = (string)myReader["HingeType"];
                                HingeConnection = (string)myReader["HingeConnection"];



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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessHingesFrames__FUNCTION__GetByFrameID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }
            return isFound;





        }

        public static int Add( int HingeDimension,  int Hinge1,
             int Hinge2,  int Hinge3,  int Hinge4,  int Hinge5,  int Hinge6
            ,  int HeightToBottomHinge,  int HingeAmount,  bool TopMeddleHinge,  string HingeMetal,
             string HingeType,  string HingeConnection,int FrameID,bool NoCalcu


            )
        {

            int ID = -1;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO HingesFrames 
(HingeDimension,Hinge1,Hinge2,Hinge3,Hinge4,Hinge5,Hinge6,HeightToBottomHinge,HingeAmount,
TopMeddleHinge,HingeMetal,HingeType,HingeConnection,FrameID,NoCalcu)
VALUES
(@HingeDimension,@Hinge1,@Hinge2,@Hinge3,@Hinge4,@Hinge5,@Hinge6,@HeightToBottomHinge,@HingeAmount,
@TopMeddleHinge,@HingeMetal,@HingeType,@HingeConnection,@FrameID,@NoCalcu); 

SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@HingeDimension", HingeDimension);
                        myCommand.Parameters.AddWithValue("@Hinge1", Hinge1);
                        myCommand.Parameters.AddWithValue("@Hinge2", Hinge2);
                        myCommand.Parameters.AddWithValue("@Hinge3", Hinge3);
                        myCommand.Parameters.AddWithValue("@Hinge4", Hinge4);
                        myCommand.Parameters.AddWithValue("@Hinge5", Hinge5);
                        myCommand.Parameters.AddWithValue("@Hinge6", Hinge6);
                        myCommand.Parameters.AddWithValue("@HeightToBottomHinge", HeightToBottomHinge);
                        myCommand.Parameters.AddWithValue("@HingeAmount", HingeAmount);
                        myCommand.Parameters.AddWithValue("@TopMeddleHinge", TopMeddleHinge);
                        myCommand.Parameters.AddWithValue("@HingeMetal", HingeMetal);
                        myCommand.Parameters.AddWithValue("@HingeType", HingeType);
                        myCommand.Parameters.AddWithValue("@HingeConnection", HingeConnection);
                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);
                        myCommand.Parameters.AddWithValue("@NoCalcu", NoCalcu);



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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessHingesFrames__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }
            return ID;

        }



        public static bool Update(int ID,
            int HingeDimension, int Hinge1,
             int Hinge2, int Hinge3, int Hinge4, int Hinge5, int Hinge6
            , int HeightToBottomHinge, int HingeAmount, bool TopMeddleHinge, string HingeMetal,
             string HingeType, string HingeConnection,int FrameID,bool NoCalcu

            )
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE HingesFrames SET
HingeDimension=@HingeDimension,
Hinge1=@Hinge1,
Hinge2=@Hinge2,
Hinge3=@Hinge3,
Hinge4=@Hinge4,
Hinge5=@Hinge5,
Hinge6=@Hinge6,
HeightToBottomHinge=@HeightToBottomHinge,
HingeAmount=@HingeAmount,
TopMeddleHinge=@TopMeddleHinge,
HingeMetal=@HingeMetal,
HingeType=@HingeType,
HingeConnection=@HingeConnection,
FrameID=@FrameID,
NoCalcu=@NoCalcu

WHERE ID=@id";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);

                        myCommand.Parameters.AddWithValue("@HingeDimension", HingeDimension);
                        myCommand.Parameters.AddWithValue("@Hinge1", Hinge1);
                        myCommand.Parameters.AddWithValue("@Hinge2", Hinge2);
                        myCommand.Parameters.AddWithValue("@Hinge3", Hinge3);
                        myCommand.Parameters.AddWithValue("@Hinge4", Hinge4);
                        myCommand.Parameters.AddWithValue("@Hinge5", Hinge5);
                        myCommand.Parameters.AddWithValue("@Hinge6", Hinge6);
                        myCommand.Parameters.AddWithValue("@HeightToBottomHinge", HeightToBottomHinge);
                        myCommand.Parameters.AddWithValue("@HingeAmount", HingeAmount);
                        myCommand.Parameters.AddWithValue("@TopMeddleHinge", TopMeddleHinge);
                        myCommand.Parameters.AddWithValue("@HingeMetal", HingeMetal);
                        myCommand.Parameters.AddWithValue("@HingeType", HingeType);
                        myCommand.Parameters.AddWithValue("@HingeConnection", HingeConnection);
                        myCommand.Parameters.AddWithValue("@FrameID", FrameID);
                        myCommand.Parameters.AddWithValue("@NoCalcu", NoCalcu);



                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();


                    }

                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessHingesFrames__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM HingesFrames WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessHingesFrames__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT * FROM HingesFrames";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessHingesFrames__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM HingesFrames WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessHingesFrames__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }









    }
}
