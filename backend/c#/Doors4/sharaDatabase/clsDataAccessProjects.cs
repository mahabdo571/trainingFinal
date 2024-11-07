using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessProjects
    {

        public static bool GetProjectByID(int ID, ref string projectName, ref string Address, ref int projectNumber, ref int iDcustomer, ref string notes
            ,ref string Manger,ref string ContactPerson,ref string  ContactPhone,ref DateTime DateOfCreate,ref DateTime DateOfUpdate

            )
        {
            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM Projects WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                projectName = (string)myReader["ProjectName"];
                                notes = (string)myReader["Notes"];
                                Address = (string)myReader["Address"];
                                projectNumber = (int)myReader["ProjectNumber"];
                                iDcustomer = (int)myReader["IDcustomer"];
                                Manger = (string)myReader["Manger"];
                                ContactPerson = (string)myReader["ContactPerson"];
                                ContactPhone = (string)myReader["ContactPhone"];
                                DateOfCreate = (DateTime)myReader["DateOfCreate"];
                                DateOfUpdate = (DateTime)myReader["DateOfUpdate"];



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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessProjects__FUNCTION__GetProjectByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }


            return isFound;





        }  
        
        
        public static bool getByCostomerID(ref int ID, ref string projectName, ref string Address, ref int projectNumber,  int iDcustomer, ref string notes
            ,ref string Manger,ref string ContactPerson,ref string  ContactPhone,ref DateTime DateOfCreate,ref DateTime DateOfUpdate

            )
        {
            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM Projects WHERE IDcustomer=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", iDcustomer);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                projectName = (string)myReader["ProjectName"];
                                notes = (string)myReader["Notes"];
                                Address = (string)myReader["Address"];
                                projectNumber = (int)myReader["ProjectNumber"];
                                ID = (int)myReader["ID"];
                                Manger = (string)myReader["Manger"];
                                ContactPerson = (string)myReader["ContactPerson"];
                                ContactPhone = (string)myReader["ContactPhone"];
                                DateOfCreate = (DateTime)myReader["DateOfCreate"];
                                DateOfUpdate = (DateTime)myReader["DateOfUpdate"];



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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessProjects__FUNCTION__GetProjectByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }


            return isFound;





        }



        public static int GetProjectByName(string projectName)
        {
            int id = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = $"SELECT * FROM Projects WHERE ProjectName LIKE  '%'+@name+'%'";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@name", projectName);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {


                                id = (int)myReader["ID"];






                            }
                            else
                            {
                                id = -1;
                            }

                            myReader.Close();




                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessProjects__FUNCTION__GetProjectByName", System.Diagnostics.EventLogEntryType.Error);

                id = -1;
            }

            return id;





        }

        public static int Add(string projectName, string  Address, int projectNumber, int iDcustomer, string notes,string Manger,string ContactPerson,string ContactPhone,DateTime DateOfCreate,DateTime DateOfUpdate)
        {

            int ID = -1;

            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO Projects 
(ProjectName,Address,ProjectNumber,IDcustomer,Notes,Manger,ContactPerson,ContactPhone,DateOfCreate,DateOfUpdate) 
VALUES
(@projectName,@Address,@projectNumber,@iDcustomer,@notes,@Manger,@ContactPerson,@ContactPhone,@DateOfCreate,@DateOfUpdate); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@projectName", projectName);
                        myCommand.Parameters.AddWithValue("@Address", Address);
                        myCommand.Parameters.AddWithValue("@projectNumber", projectNumber);
                        myCommand.Parameters.AddWithValue("@iDcustomer", iDcustomer);
                        myCommand.Parameters.AddWithValue("@notes", notes);
                        myCommand.Parameters.AddWithValue("@Manger", Manger);
                        myCommand.Parameters.AddWithValue("@ContactPerson", ContactPerson);
                        myCommand.Parameters.AddWithValue("@ContactPhone", ContactPhone);
                        myCommand.Parameters.AddWithValue("@DateOfCreate", DateOfCreate);
                        myCommand.Parameters.AddWithValue("@DateOfUpdate", DateOfUpdate);



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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessProjects__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }
            return ID;

        }



        public static bool Update(int ID, string projectName, string Address, int projectNumber, int iDcustomer, string notes, string Manger, string ContactPerson, string ContactPhone, DateTime DateOfCreate,DateTime DateOfUpdate)
        {

            int rowsAffected = 0;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE Projects SET 
DateOfUpdate=@DateOfUpdate,
DateOfCreate =@DateOfCreate , 
ContactPhone=@ContactPhone,
ProjectName=@projectName , 
Address=@Address ,
ProjectNumber = @projectNumber ,
IDcustomer=@iDcustomer,
Notes=@notes ,
Manger=@Manger ,
ContactPerson=@ContactPerson 


WHERE ID=@id";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@projectName", projectName);
                        myCommand.Parameters.AddWithValue("@Address", Address);
                        myCommand.Parameters.AddWithValue("@projectNumber", projectNumber);
                        myCommand.Parameters.AddWithValue("@iDcustomer", iDcustomer);
                        myCommand.Parameters.AddWithValue("@notes", notes);
                        myCommand.Parameters.AddWithValue("@Manger", Manger);
                        myCommand.Parameters.AddWithValue("@id", ID);
                        myCommand.Parameters.AddWithValue("@ContactPerson", ContactPerson);
                        myCommand.Parameters.AddWithValue("@ContactPhone", ContactPhone);
                        myCommand.Parameters.AddWithValue("@DateOfCreate", DateOfCreate);
                        myCommand.Parameters.AddWithValue("@DateOfUpdate", DateOfUpdate);



                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessProjects__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM Projects WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessProjects__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT * FROM Projects";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessProjects__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }

            return myDataTable;
        }


        public static DataTable SearchProject(string search,int IDcustomer)
        {
            DataTable myDataTable = new DataTable();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT * FROM Projects WHERE (ProjectName LIKE @search OR ProjectNumber LIKE @search OR Notes LIKE @search OR Address LIKE @search OR Manger LIKE @search OR ContactPerson LIKE @search OR ContactPhone LIKE @search ) AND IDcustomer=@IDcustomer";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                        myCommand.Parameters.AddWithValue("@IDcustomer", IDcustomer);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessProjects__FUNCTION__SearchProject", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }

            return myDataTable;
        }



        public static DataTable getWithCustomer(int IDcustomer)
        {
            DataTable myDataTable = new DataTable();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT * FROM Projects WHERE IDcustomer=@IDcustomer Order By DateOfUpdate DESC ";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@IDcustomer", IDcustomer);


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessProjects__FUNCTION__getWithCustomer", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM Projects WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessProjects__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }
            return isFound;
        }







    }
}
