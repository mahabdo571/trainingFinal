using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsFrameDefaultDataAccess
    {





        public static bool GetByID(int ID, ref string Name, ref string Dec,
            ref decimal A1,
            ref decimal A2,
            ref decimal B1,
            ref decimal B2,
            ref decimal C1,
            ref decimal C2,
            ref decimal D1,
            ref decimal D2,
            ref decimal E1,
            ref decimal E2,
            ref decimal F1,
            ref decimal F2,
            ref decimal G1,
            ref decimal G2,
            ref decimal Bends,
            ref decimal F1A,
            ref decimal F1B,
            ref decimal F2A,
            ref decimal F2B,
            ref decimal MG,
            ref decimal K125,
            ref decimal K15,
            ref decimal K2


            )
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    string myQuery = "SELECT * FROM FrameDefault WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                Name = (string)myReader["Name"];

                                if (myReader["Dec"] == DBNull.Value)
                                {
                                    Dec = "";
                                }
                                else
                                {
                                    Dec = (string)myReader["Dec"];

                                }

                                K2 = (decimal)myReader["K2"];
                                K15 = (decimal)myReader["K15"];
                                K125 = (decimal)myReader["K125"];
                                MG = (decimal)myReader["MG"];
                                F2B = (decimal)myReader["F2B"];
                                F2A = (decimal)myReader["F2A"];
                                F1B = (decimal)myReader["F1B"];
                                F1A = (decimal)myReader["F1A"];
                                Bends = (decimal)myReader["Bends"];
                                A1 = (decimal)myReader["A1"];
                                A2 = (decimal)myReader["A2"];
                                B1 = (decimal)myReader["B1"];
                                B2 = (decimal)myReader["B2"];
                                C1 = (decimal)myReader["C1"];
                                C2 = (decimal)myReader["C2"];
                                D1 = (decimal)myReader["D1"];
                                D2 = (decimal)myReader["D2"];
                                E1 = (decimal)myReader["E1"];
                                E2 = (decimal)myReader["E2"];
                                F1 = (decimal)myReader["F1"];
                                F2 = (decimal)myReader["F2"];
                                G1 = (decimal)myReader["G1"];
                                G2 = (decimal)myReader["G2"];




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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsFrameDefaultDataAccess__FUNCTION__getByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;


        }




        public static int Add(
             string Name,
             string Dec,
             decimal A1,
             decimal A2,
             decimal B1,
             decimal B2,
             decimal C1,
             decimal C2,
             decimal D1,
             decimal D2,
             decimal E1,
             decimal E2,
             decimal F1,
             decimal F2,
             decimal G1,
             decimal G2,
             decimal Bends,
             decimal F1A,
             decimal F1B,
             decimal F2A,
             decimal F2B,
             decimal MG,
             decimal K125,
             decimal K15,
             decimal K2


            )
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO FrameDefault
(
Name, 
Dec,
A1,
A2,
B1,
B2,
C1,
C2,
D1,
D2,
E1,
E2,
F1,
F2,
G1,
G2,
Bends,
F1A,
F1B,
F2A,
F2B,
MG,
K125,
K15,
K2
 )
 VALUES
(
@Name, 
@Dec,
@A1,
@A2,
@B1,
@B2,
@C1,
@C2,
@D1,
@D2,
@E1,
@E2,
@F1,
@F2,
@G1,
@G2,
@Bends,
@F1A,
@F1B,
@F2A,
@F2B,
@MG,
@K125,
@K15,
@K2
);
SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@Name", Name);
                        myCommand.Parameters.AddWithValue("@Dec", Dec);
                        myCommand.Parameters.AddWithValue("@A1", A1);
                        myCommand.Parameters.AddWithValue("@A2", A2);
                        myCommand.Parameters.AddWithValue("@B1", B1);
                        myCommand.Parameters.AddWithValue("@B2", B2);
                        myCommand.Parameters.AddWithValue("@C1", C1);
                        myCommand.Parameters.AddWithValue("@C2", C2);
                        myCommand.Parameters.AddWithValue("@D1", D1);
                        myCommand.Parameters.AddWithValue("@D2", D2);
                        myCommand.Parameters.AddWithValue("@E1", E1);
                        myCommand.Parameters.AddWithValue("@E2", E2);
                        myCommand.Parameters.AddWithValue("@F1", F1);
                        myCommand.Parameters.AddWithValue("@F2", F2);
                        myCommand.Parameters.AddWithValue("@G1", G1);
                        myCommand.Parameters.AddWithValue("@G2", G2);
                        myCommand.Parameters.AddWithValue("@Bends", Bends);
                        myCommand.Parameters.AddWithValue("@F1A", F1A);
                        myCommand.Parameters.AddWithValue("@F1B", F1B);
                        myCommand.Parameters.AddWithValue("@F2A", F2A);
                        myCommand.Parameters.AddWithValue("@F2B", F2B);
                        myCommand.Parameters.AddWithValue("@MG", MG);
                        myCommand.Parameters.AddWithValue("@K125", K125);
                        myCommand.Parameters.AddWithValue("@K15", K15);
                        myCommand.Parameters.AddWithValue("@K2", K2);





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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsFrameDefaultDataAccess__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;

            }


            return ID;

        }


        public static bool Update(
            int ID,
           string Name,
             string Dec,
             decimal A1,
             decimal A2,
             decimal B1,
             decimal B2,
             decimal C1,
             decimal C2,
             decimal D1,
             decimal D2,
             decimal E1,
             decimal E2,
             decimal F1,
             decimal F2,
             decimal G1,
             decimal G2,
             decimal Bends,
             decimal F1A,
             decimal F1B,
             decimal F2A,
             decimal F2B,
             decimal MG,
             decimal K125,
             decimal K15,
             decimal K2
            )
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE FrameDefault SET
Name=@Name, 
Dec=@Dec,
A1=@A1,
A2=@A2,
B1=@B1,
B2=@B2,
C1=@C1,
C2=@C2,
D1=@D1,
D2=@D2,
E1=@E1,
E2=@E2,
F1=@F1,
F2=@F2,
G1=@G1,
G2=@G2,
Bends=@Bends,
F1A=@F1A,
F1B=@F1B,
F2A=@F2A,
F2B=@F2B,
MG=@MG,
K125=@K125,
K15=@K15,
K2=@K2


WHERE ID=@id";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@Name", Name);
                        myCommand.Parameters.AddWithValue("@Dec", Dec);
                        myCommand.Parameters.AddWithValue("@A1", A1);
                        myCommand.Parameters.AddWithValue("@A2", A2);
                        myCommand.Parameters.AddWithValue("@B1", B1);
                        myCommand.Parameters.AddWithValue("@B2", B2);
                        myCommand.Parameters.AddWithValue("@C1", C1);
                        myCommand.Parameters.AddWithValue("@C2", C2);
                        myCommand.Parameters.AddWithValue("@D1", D1);
                        myCommand.Parameters.AddWithValue("@D2", D2);
                        myCommand.Parameters.AddWithValue("@E1", E1);
                        myCommand.Parameters.AddWithValue("@E2", E2);
                        myCommand.Parameters.AddWithValue("@F1", F1);
                        myCommand.Parameters.AddWithValue("@F2", F2);
                        myCommand.Parameters.AddWithValue("@G1", G1);
                        myCommand.Parameters.AddWithValue("@G2", G2);
                        myCommand.Parameters.AddWithValue("@Bends", Bends);
                        myCommand.Parameters.AddWithValue("@F1A", F1A);
                        myCommand.Parameters.AddWithValue("@F1B", F1B);
                        myCommand.Parameters.AddWithValue("@F2A", F2A);
                        myCommand.Parameters.AddWithValue("@F2B", F2B);
                        myCommand.Parameters.AddWithValue("@MG", MG);
                        myCommand.Parameters.AddWithValue("@K125", K125);
                        myCommand.Parameters.AddWithValue("@K15", K15);
                        myCommand.Parameters.AddWithValue("@K2", K2);

                        myCommand.Parameters.AddWithValue("@id", ID);


                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsFrameDefaultDataAccess__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM FrameDefault WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsFrameDefaultDataAccess__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }


        public static bool Delete(int ID)
        {


            int rowsAffected = 0;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "DELETE FROM FrameDefault WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsFrameDefaultDataAccess__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

                rowsAffected = -1;
            }

            return (rowsAffected > 0);

        }

        public static DataTable getAll()
        {
            DataTable myDataTable = new DataTable();

            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT * FROM FrameDefault";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsFrameDefaultDataAccess__FUNCTION__getAll", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


            return myDataTable;
        }
    }
}
