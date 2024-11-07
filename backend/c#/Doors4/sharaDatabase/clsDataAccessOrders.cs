using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessOrders
    {


        public static bool GetOtherContactsByID(int ID, ref DateTime Date, ref int ProjectID, ref string Marketer,ref int OrderNumber,ref DateTime DateManual)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    string myQuery = "SELECT * FROM Orders WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                Date = (DateTime)myReader["Date"];
                                ProjectID = (int)myReader["ProjectID"];
                                Marketer = (string)myReader["Marketer"];
                                OrderNumber = (int)myReader["OrderNumber"];
                                DateManual = (DateTime)myReader["DateManual"];

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessOrders__FUNCTION__GetOtherContactsByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;


        }




        public static int Add(DateTime Date, int ProjectID, string Marketer, int OrderNumber,DateTime DateManual)
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"
INSERT INTO [dbo].[Orders]
           ([Date]
           ,[ProjectID]
           ,[Marketer]
           ,[OrderNumber]
           ,[DateManual]
          
           )
     VALUES(@Date,@ProjectID,@Marketer,@OrderNumber,@DateManual);
     SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@Date", Date);
                        myCommand.Parameters.AddWithValue("@ProjectID", ProjectID);
                        myCommand.Parameters.AddWithValue("@Marketer", Marketer);
                        myCommand.Parameters.AddWithValue("@OrderNumber", OrderNumber);
                        myCommand.Parameters.AddWithValue("@DateManual", DateManual);



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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessOrders__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;

            }
            

            return ID;

        }



        public static bool Update(int ID, DateTime date, int projectID, string marketer,int OrderNumber, DateTime DateManual)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE Orders SET Date=@Date,ProjectID=@ProjectID , Marketer=@Marketer ,OrderNumber=@OrderNumber,DateManual=@DateManual WHERE ID=@id";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@Date", date);
                        myCommand.Parameters.AddWithValue("@ProjectID", projectID);
                        myCommand.Parameters.AddWithValue("@Marketer", marketer);
                        myCommand.Parameters.AddWithValue("@OrderNumber", OrderNumber);
                        myCommand.Parameters.AddWithValue("@DateManual", DateManual);

                        myCommand.Parameters.AddWithValue("@id", ID);


                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessOrders__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM Orders WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessOrders__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

                rowsAffected = -1;
            }

            return (rowsAffected > 0);

        }


        public static DataTable getAllFromProject(int projectID)
        {
            DataTable myDataTable = new DataTable();

            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT * FROM Orders where ProjectID=@ProjectID Order By Date DESC ";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ProjectID", projectID);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessOrders__FUNCTION__getAllFromProject", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


            return myDataTable;
        }
        
        public static DataTable Search(string search,int projectID)
        {
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT * FROM Orders where  (Marketer LIKE @search OR OrderNumber LIKE @search) AND ProjectID=@ProjectID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ProjectID", projectID);
                        myCommand.Parameters.AddWithValue("@search", "%" + search + "%");

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessOrders__FUNCTION__Search", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


            return myDataTable;
        } 
        
        
        public static  DataTable BakegWing(int OrdirID)
        {
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    using (SqlCommand myCommand =  new SqlCommand("SP_pakegWingStikrs", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@id", OrdirID);
                      

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessOrders__FUNCTION__BakegWing", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


            return myDataTable;
        } 
        
        
        public static  DataTable pakegFrameStikrs(int OrdirID)
        {
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    using (SqlCommand myCommand =  new SqlCommand("SP_pakegFrameStikrs", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@id", OrdirID);
                      

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessOrders__FUNCTION__pakegFrameStikrs", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM Orders WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessOrders__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }





    }
}
