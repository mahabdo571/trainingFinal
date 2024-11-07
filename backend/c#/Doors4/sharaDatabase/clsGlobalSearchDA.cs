using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsGlobalSearchDA
    {

        public static bool GetByIDCUSTOMER(int IDCUSTOMER, ref string CompanyName, ref string PhoneNumbe,ref string FullName,
            ref string CompanyNumber,ref string AccountantNumber,ref string ProjectName,ref string ProjectNumber,
            ref string Notes,ref string Address,ref string Manger,ref string OrderNumber,ref int IDORDER
            ,ref int IDPROJECT

            )
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    string myQuery = "select * from SearchGlobal where IDCUSTOMER = @IDCUSTOMER";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@IDCUSTOMER", IDCUSTOMER);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {
    

                                CompanyName = Convert.ToString(myReader["CompanyName"]);
                                PhoneNumbe = Convert.ToString(myReader["PhoneNumbe"]);
                                FullName = Convert.ToString(myReader["FullName"]);
                                CompanyNumber = Convert.ToString(myReader["CompanyNumber"]);
                                AccountantNumber = Convert.ToString(myReader["AccountantNumber"]);
                                ProjectName = Convert.ToString(myReader["ProjectName"]);
                                ProjectNumber = Convert.ToString(myReader["ProjectNumber"]);
                                Notes = Convert.ToString(myReader["Notes"]);
                                Address = Convert.ToString(myReader["Address"]);
                                Manger = Convert.ToString(myReader["Manger"]);
                                OrderNumber = Convert.ToString(myReader["OrderNumber"]);
                                IDORDER = Convert.ToInt32(myReader["IDORDER"]);                       
                                IDPROJECT = Convert.ToInt32(myReader["IDPROJECT"]);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsGlobalSearch__FUNCTION__GetByIDCUSTOMER", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;


        }
        
        public static bool GetByIDORDER(int IDORDER, ref string CompanyName, ref string PhoneNumbe,ref string FullName,
            ref string CompanyNumber,ref string AccountantNumber,ref string ProjectName,ref string ProjectNumber,
            ref string Notes,ref string Address,ref string Manger,ref string OrderNumber,ref int IDCUSTOMER
            , ref int IDPROJECT

            )
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    string myQuery = "select * from SearchGlobal where IDORDER = @IDORDER";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@IDORDER", IDORDER);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {
    

                                CompanyName = Convert.ToString(myReader["CompanyName"]);
                                PhoneNumbe = Convert.ToString(myReader["PhoneNumbe"]);
                                FullName = Convert.ToString(myReader["FullName"]);
                                CompanyNumber = Convert.ToString(myReader["CompanyNumber"]);
                                AccountantNumber = Convert.ToString(myReader["AccountantNumber"]);
                                ProjectName = Convert.ToString(myReader["ProjectName"]);
                                ProjectNumber = Convert.ToString(myReader["ProjectNumber"]);
                                Notes = Convert.ToString(myReader["Notes"]);
                                Address = Convert.ToString(myReader["Address"]);
                                Manger = Convert.ToString(myReader["Manger"]);
                                OrderNumber = Convert.ToString(myReader["OrderNumber"]);
                                IDCUSTOMER = Convert.ToInt32(myReader["IDCUSTOMER"]);                       
                                IDPROJECT = Convert.ToInt32(myReader["IDPROJECT"]);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsGlobalSearch__FUNCTION__GetByIDORDER", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;


        }
      
        public static bool GetByIDPROJECT(int IDPROJECT, ref string CompanyName, ref string PhoneNumbe,ref string FullName,
            ref string CompanyNumber,ref string AccountantNumber,ref string ProjectName,ref string ProjectNumber,
            ref string Notes,ref string Address,ref string Manger,ref string OrderNumber,ref int IDCUSTOMER
            , ref int IDORDER

            )
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    string myQuery = "select * from SearchGlobal where IDPROJECT = @IDPROJECT";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@IDPROJECT", IDPROJECT);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {
    

                                CompanyName = Convert.ToString(myReader["CompanyName"]);
                                PhoneNumbe = Convert.ToString(myReader["PhoneNumbe"]);
                                FullName = Convert.ToString(myReader["FullName"]);
                                CompanyNumber = Convert.ToString(myReader["CompanyNumber"]);
                                AccountantNumber = Convert.ToString(myReader["AccountantNumber"]);
                                ProjectName = Convert.ToString(myReader["ProjectName"]);
                                ProjectNumber = Convert.ToString(myReader["ProjectNumber"]);
                                Notes = Convert.ToString(myReader["Notes"]);
                                Address = Convert.ToString(myReader["Address"]);
                                Manger = Convert.ToString(myReader["Manger"]);
                                OrderNumber = Convert.ToString(myReader["OrderNumber"]);
                                IDCUSTOMER = Convert.ToInt32(myReader["IDCUSTOMER"]);
                                IDORDER = Convert.ToInt32(myReader["IDORDER"]);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsGlobalSearch__FUNCTION__GetByIDPROJECT", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;


        }

        public  static async Task<DataTable> GetAll()
        {
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    // WAITFOR DELAY '00:00:5' --for test if data slowly

                    string myQuery = "SELECT * FROM SearchGlobal";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {


                       await myConnection.OpenAsync();

                        using (SqlDataReader myReader =await myCommand.ExecuteReaderAsync())
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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsGlobalSearch__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);
                myDataTable = null;
            }

            return myDataTable;
        }   
        
        public  static async Task<DataTable> SearchByAny(string Any,int PageNumber ,int RowsPerPage)
        {
            DataTable myDataTable = new DataTable();
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    // WAITFOR DELAY '00:00:5' --for test if data slowly

                   

                    using (SqlCommand myCommand = new SqlCommand("SP_SearchGlobalWhereAny", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@Search", Any);
                        //myCommand.Parameters.AddWithValue("@PageNumber", PageNumber);
                        //myCommand.Parameters.AddWithValue("@RowsPerPage", RowsPerPage);

                       await myConnection.OpenAsync();

                        using (SqlDataReader myReader =await myCommand.ExecuteReaderAsync())
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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsGlobalSearch__FUNCTION__any", System.Diagnostics.EventLogEntryType.Error);
                myDataTable = null;
            }

            return myDataTable;
        }



    }
}
