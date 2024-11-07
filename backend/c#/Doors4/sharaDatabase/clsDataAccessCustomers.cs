using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessCustomers
    {





        public static bool GetCustomersByID(int ID, ref string FullName, ref string identityNumber, ref string PhoneNumbe,
            ref string PhoneNumbe2, ref string CompanyName, ref int CompanyNumber,
            ref int AccountantNumber, ref string Email,ref DateTime UpdateDate)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                   

                    string myQuery = "SELECT * FROM Customers WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                FullName = (string)myReader["FullName"];
                                identityNumber = (string)myReader["identityNumber"];
                                PhoneNumbe = (string)myReader["PhoneNumbe"];
                                PhoneNumbe2 = (string)myReader["PhoneNumbe2"];
                                CompanyName = (string)myReader["CompanyName"];
                                CompanyNumber = (int)myReader["CompanyNumber"];
                                AccountantNumber = (int)myReader["AccountantNumber"];
                                Email = (string)myReader["Email"];
                                UpdateDate = (DateTime)myReader["UpdateDate"];

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessCustomers__FUNCTION__GetCustomersByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }



        public static int Add(string FullName, string identityNumber, string PhoneNumbe,
            string PhoneNumbe2, string CompanyName, int CompanyNumber, int AccountantNumber, string Email,DateTime UpdateDate)
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"
INSERT INTO Customers
           (FullName
           ,identityNumber
           ,PhoneNumbe
           ,CompanyName
,CompanyNumber
,AccountantNumber
,PhoneNumbe2
,Email
,UpdateDate
           )
     VALUES(
@FullName
           ,@identityNumber
           ,@PhoneNumbe
           ,@CompanyName
,@CompanyNumber
,@AccountantNumber
,@PhoneNumbe2
,@Email
,@UpdateDate

);
     SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@FullName", FullName);
                        myCommand.Parameters.AddWithValue("@identityNumber", identityNumber);
                        myCommand.Parameters.AddWithValue("@PhoneNumbe", PhoneNumbe);
                        myCommand.Parameters.AddWithValue("@CompanyName", CompanyName);
                        myCommand.Parameters.AddWithValue("@CompanyNumber", CompanyNumber);
                        myCommand.Parameters.AddWithValue("@AccountantNumber", AccountantNumber);
                        myCommand.Parameters.AddWithValue("@PhoneNumbe2", PhoneNumbe2);
                        myCommand.Parameters.AddWithValue("@Email", Email);
                        myCommand.Parameters.AddWithValue("@UpdateDate", UpdateDate);


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessCustomers__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }
            return ID;

        }



        public static  bool Update(int ID, string FullName, string identityNumber, string PhoneNumbe,
            string PhoneNumbe2, string CompanyName, int CompanyNumber, int AccountantNumber, string Email,DateTime UpdateDate)
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE Customers SET
FullName=@FullName,
identityNumber=@identityNumber ,
PhoneNumbe=@PhoneNumbe,
CompanyName=@CompanyName ,
CompanyNumber=@CompanyNumber ,
AccountantNumber=@AccountantNumber ,
PhoneNumbe2=@PhoneNumbe2 ,
Email=@Email ,
UpdateDate=@UpdateDate 

WHERE ID=@id";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@FullName", FullName);
                        myCommand.Parameters.AddWithValue("@identityNumber", identityNumber);
                        myCommand.Parameters.AddWithValue("@PhoneNumbe", PhoneNumbe);
                        myCommand.Parameters.AddWithValue("@CompanyName", CompanyName);
                        myCommand.Parameters.AddWithValue("@CompanyNumber", CompanyNumber);
                        myCommand.Parameters.AddWithValue("@AccountantNumber", AccountantNumber);
                        myCommand.Parameters.AddWithValue("@PhoneNumbe2", PhoneNumbe2);
                        myCommand.Parameters.AddWithValue("@Email", Email);
                        myCommand.Parameters.AddWithValue("@id", ID);
                        myCommand.Parameters.AddWithValue("@UpdateDate", UpdateDate);


                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessCustomers__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM Customers WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessCustomers__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

                rowsAffected = -1;
                    
            }

            return (rowsAffected > 0);

        }


        public static DataTable GetAll()
        {
            DataTable myDataTable = new DataTable();
            try
            {
                using ( SqlConnection myConnection = new SqlConnection( clsDataAccessSettings.ConnectionString()))
                {
                    myConnection.Open();
                    string myQuery = "SELECT * FROM Customers";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {


                      

                        using (SqlDataReader myReader =   myCommand.ExecuteReader())
                        {

                            if ( myReader.HasRows)
                            {
                                myDataTable.Load( myReader);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessCustomers__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


            return myDataTable;
        }   
        
        
        public static DataTable GetAllOrderByLastUpdet()
        {
            DataTable myDataTable = new DataTable();
            try
            {
                using ( SqlConnection myConnection = new SqlConnection( clsDataAccessSettings.ConnectionString()))
                {
                    myConnection.Open();
                    string myQuery = @"SELECT * FROM Customers  ORDER BY UpdateDate DESC";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {


                      

                        using (SqlDataReader myReader =   myCommand.ExecuteReader())
                        {

                            if ( myReader.HasRows)
                            {
                                myDataTable.Load( myReader);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessCustomers__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


            return myDataTable;
        }

        public static DataTable SearchCustomer(string search)
        {


   

            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT * FROM Customers WHERE( PhoneNumbe LIKE @search OR FullName LIKE  @search OR CompanyName LIKE @search OR AccountantNumber LIKE @search OR CompanyNumber LIKE @search)";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {
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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessCustomers__FUNCTION__SearchCustomer", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM Customers WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessCustomers__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;

            }

            return isFound;
        }




    }
}
