using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDAColorSide
    {

        public static bool GetColorByID(int ID, ref string ColorName)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    string myQuery =  "SELECT * FROM ColorSide WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                ColorName = Convert.ToString(myReader["ColorName"]);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAColorSide__FUNCTION__GetColorByID", System.Diagnostics.EventLogEntryType.Error);
               
                isFound = false;
            }

            return isFound;


        }


        public static bool GetColorByColorName(ref int ID,  string ColorName)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    string myQuery = "SELECT * FROM ColorSide WHERE ColorName=@ColorName";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@ColorName", ColorName);



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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDAColorSide__FUNCTION__GetColorByColorName", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;


        }

        public static int Add(  string ColorName)
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"
INSERT INTO [dbo].[ColorSide]
           ([ColorName]
    
          
           )
     VALUES(@ColorName);
     SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@ColorName", ColorName);




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



        public static bool Update(int ID, string ColorName)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE ColorSide SET ColorName=@ColorName WHERE ID=@id";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@ColorName", ColorName);
           

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

                    string myQuery = @"if NOT EXISTS (select fff=1  from Wings where ColorSide =CAST(@id AS varchar))
BEGIN
DELETE FROM ColorSide WHERE ID=@id
	END";

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

                    string myQuery = "SELECT Found=1 FROM ColorSide WHERE ID = @id";

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

                    string myQuery = @"SELECT * FROM ColorSide order by 
CASE 
WHEN ASCII([ColorName])  like '%שהרבני%'  THEN '1'
               END  COLLATE Hebrew_CI_AS"; 

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
         
        
        public static DataTable getAllSortByID()
        {
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"SELECT * FROM ColorSide order by ID DESC"; 

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
