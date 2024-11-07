using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace sharaDatabase
{
    public class clsDataAccessWing
    {




        public static bool GetByID(

        int ID, ref int OdrerId,
           ref string DoorNumber, ref DateTime DateAdded,
           ref string DoorType, ref string Direction,
           ref string LockType, ref string Location,
           ref string FactoryNotes, ref string Notes,
           ref int tbPrintAmount, ref int tbStickers,
           ref int tbAmount, ref string AccID,
           ref DateTime UpdateDate, ref string ColorDoor,
           ref string ColorSide, ref float FormaicaThickness,
           ref int WidthFinal, ref int HeightFinal,
           ref int WidthCut, ref int HeightCut,
           ref bool DoubleDoor, ref bool SupportHelpless,
           ref bool MakhzerShemen, ref bool Atmer,
           ref bool Side,ref int DDWingID,ref string DDAK



            )
        {

            bool isFound = false;
          
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                 

                    using (SqlCommand myCommand = new SqlCommand("SP_FindWingByID", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                OdrerId = (int)myReader["OdrerId"];
                                DoorNumber = (string)myReader["DoorNumber"];
                                DateAdded = (DateTime)myReader["DateAdded"];
                                DoorType = (string)myReader["DoorType"];
                                Direction = (string)myReader["Direction"];
                                LockType = (string)myReader["LockType"];
                                Location = (string)myReader["Location"];
                                FactoryNotes = (string)myReader["FactoryNotes"];
                                Notes = (string)myReader["Notes"];
                                tbPrintAmount = (int)myReader["tbPrintAmount"];
                                tbStickers = (int)myReader["tbStickers"];
                                tbAmount = (int)myReader["tbAmount"];
                                AccID = (string)myReader["AccID"];
                                UpdateDate = (DateTime)myReader["UpdateDate"];
                                ColorDoor = (string)myReader["ColorDoor"];
                                ColorSide = (string)myReader["ColorSide"];
                                FormaicaThickness = Convert.ToSingle(myReader["FormaicaThickness"]);
                                WidthFinal = (int)myReader["WidthFinal"];
                                HeightFinal = (int)myReader["HeightFinal"];
                                WidthCut = (int)myReader["WidthCut"];
                                HeightCut = (int)myReader["HeightCut"];
                                DoubleDoor = (bool)myReader["DoubleDoor"];
                                SupportHelpless = (bool)myReader["SupportHelpless"];
                                MakhzerShemen = (bool)myReader["MakhzerShemen"];
                                Atmer = (bool)myReader["Atmer"];
                                Side = (bool)myReader["Side"];
                                DDWingID = (int)myReader["DDWingID"];
                                DDAK = (string)myReader["DDAK"];





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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWing__FUNCTION__GetByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

                    return isFound;





        }




        public static int Add(
            int OdrerId,
            string DoorNumber, DateTime DateAdded,
            string DoorType, string Direction,
            string LockType, string Location,
            string FactoryNotes, string Notes,
            int tbPrintAmount, int tbStickers,
            int tbAmount, string AccID,
            DateTime UpdateDate, string ColorDoor,
            string ColorSide, float FormaicaThickness,
            int WidthFinal, int HeightFinal,
            int WidthCut, int HeightCut,
            bool DoubleDoor, bool SupportHelpless,
            bool MakhzerShemen, bool Atmer,
            bool Side ,int DDWingID,string DDAK

            )
        {

            int ID = -1;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO Wings
(
OdrerId,
DoorNumber,
DateAdded,
DoorType,
Direction,
LockType,
Location,
FactoryNotes,
Notes,
tbPrintAmount,
tbStickers,
tbAmount,
AccID,
UpdateDate,
ColorDoor,
ColorSide,
FormaicaThickness,
WidthFinal,
HeightFinal,
WidthCut,
HeightCut,
DoubleDoor,
SupportHelpless,
MakhzerShemen,
Atmer,
Side,
DDWingID,
DDAK
)

VALUES
(
@OdrerId,
@DoorNumber,
@DateAdded,
@DoorType,
@Direction,
@LockType,
@Location,
@FactoryNotes,
@Notes,
@tbPrintAmount,
@tbStickers,
@tbAmount,
@AccID,
@UpdateDate,
@ColorDoor,
@ColorSide,
@FormaicaThickness,
@WidthFinal,
@HeightFinal,
@WidthCut,
@HeightCut,
@DoubleDoor,
@SupportHelpless,
@MakhzerShemen,
@Atmer,
@Side,
@DDWingID,
@DDAK
); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@OdrerId", OdrerId);
                        myCommand.Parameters.AddWithValue("@DoorNumber", DoorNumber);
                        myCommand.Parameters.AddWithValue("@DateAdded", DateAdded);
                        myCommand.Parameters.AddWithValue("@DoorType", DoorType);
                        myCommand.Parameters.AddWithValue("@Direction", Direction);
                        myCommand.Parameters.AddWithValue("@LockType", LockType);
                        myCommand.Parameters.AddWithValue("@Location", Location);
                        myCommand.Parameters.AddWithValue("@FactoryNotes", FactoryNotes);
                        myCommand.Parameters.AddWithValue("@Notes", Notes);
                        myCommand.Parameters.AddWithValue("@tbPrintAmount", tbPrintAmount);
                        myCommand.Parameters.AddWithValue("@tbStickers", tbStickers);
                        myCommand.Parameters.AddWithValue("@tbAmount", tbAmount);
                        myCommand.Parameters.AddWithValue("@AccID", AccID);
                        myCommand.Parameters.AddWithValue("@UpdateDate", UpdateDate);
                        myCommand.Parameters.AddWithValue("@ColorDoor", ColorDoor);
                        myCommand.Parameters.AddWithValue("@ColorSide", ColorSide);
                        myCommand.Parameters.AddWithValue("@FormaicaThickness", FormaicaThickness);
                        myCommand.Parameters.AddWithValue("@WidthFinal", WidthFinal);
                        myCommand.Parameters.AddWithValue("@HeightFinal", HeightFinal);
                        myCommand.Parameters.AddWithValue("@WidthCut", WidthCut);
                        myCommand.Parameters.AddWithValue("@HeightCut", HeightCut);
                        myCommand.Parameters.AddWithValue("@DoubleDoor", DoubleDoor);
                        myCommand.Parameters.AddWithValue("@SupportHelpless", SupportHelpless);
                        myCommand.Parameters.AddWithValue("@MakhzerShemen", MakhzerShemen);
                        myCommand.Parameters.AddWithValue("@Atmer", Atmer);
                        myCommand.Parameters.AddWithValue("@Side", Side);
                        myCommand.Parameters.AddWithValue("@DDWingID", DDWingID);
                        myCommand.Parameters.AddWithValue("@DDAK", DDAK);


                        myConnection.Open();

                        object myResult =  myCommand.ExecuteScalar();

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWing__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }
            return ID;

        }


// orginal
//        public static bool  Update(int ID,

//                        int OdrerId,
//            string DoorNumber, DateTime DateAdded,
//            string DoorType, string Direction,
//            string LockType, string Location,
//            string FactoryNotes, string Notes,
//            int tbPrintAmount, int tbStickers,
//            int tbAmount, string AccID,
//            DateTime UpdateDate, string ColorDoor,
//            string ColorSide, float FormaicaThickness,
//            int WidthFinal, int HeightFinal,
//            int WidthCut, int HeightCut,
//            bool DoubleDoor, bool SupportHelpless,
//            bool MakhzerShemen, bool Atmer,
//            bool Side,int DDWingID,string DDAK
//            )
//        {

//            int rowsAffected = 0;
//            try
//            {
//                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
//                {


//                    string myQuery = @"UPDATE Wings SET 
//OdrerId =@OdrerId,
//DoorNumber =@DoorNumber,
//DateAdded =@DateAdded,
//DoorType =@DoorType,
//Direction =@Direction,
//LockType =@LockType,
//Location =@Location,
//FactoryNotes =@FactoryNotes,
//Notes =@Notes,
//tbPrintAmount =@tbPrintAmount,
//tbStickers =@tbStickers,
//tbAmount =@tbAmount,
//AccID =@AccID,
//UpdateDate =@UpdateDate,
//ColorDoor =@ColorDoor,
//ColorSide =@ColorSide,
//FormaicaThickness =@FormaicaThickness,
//WidthFinal =@WidthFinal,
//HeightFinal =@HeightFinal,
//WidthCut =@WidthCut,
//HeightCut =@HeightCut,
//DoubleDoor =@DoubleDoor,
//SupportHelpless =@SupportHelpless,
//MakhzerShemen =@MakhzerShemen,
//Atmer =@Atmer,
//Side=@Side,
//DDWingID=@DDWingID,
//DDAK=@DDAK



//WHERE ID=@ID";


//                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
//                    {

//                        myCommand.Parameters.AddWithValue("@ID", ID);
//                        myCommand.Parameters.AddWithValue("@OdrerId", OdrerId);
//                        myCommand.Parameters.AddWithValue("@DoorNumber", DoorNumber);
//                        myCommand.Parameters.AddWithValue("@DateAdded", DateAdded);
//                        myCommand.Parameters.AddWithValue("@DoorType", DoorType);
//                        myCommand.Parameters.AddWithValue("@Direction", Direction);
//                        myCommand.Parameters.AddWithValue("@LockType", LockType);
//                        myCommand.Parameters.AddWithValue("@Location", Location);
//                        myCommand.Parameters.AddWithValue("@FactoryNotes", FactoryNotes);
//                        myCommand.Parameters.AddWithValue("@Notes", Notes);
//                        myCommand.Parameters.AddWithValue("@tbPrintAmount", tbPrintAmount);
//                        myCommand.Parameters.AddWithValue("@tbStickers", tbStickers);
//                        myCommand.Parameters.AddWithValue("@tbAmount", tbAmount);
//                        myCommand.Parameters.AddWithValue("@AccID", AccID);
//                        myCommand.Parameters.AddWithValue("@UpdateDate", UpdateDate);
//                        myCommand.Parameters.AddWithValue("@ColorDoor", ColorDoor);
//                        myCommand.Parameters.AddWithValue("@ColorSide", ColorSide);
//                        myCommand.Parameters.AddWithValue("@FormaicaThickness", FormaicaThickness);
//                        myCommand.Parameters.AddWithValue("@WidthFinal", WidthFinal);
//                        myCommand.Parameters.AddWithValue("@HeightFinal", HeightFinal);
//                        myCommand.Parameters.AddWithValue("@WidthCut", WidthCut);
//                        myCommand.Parameters.AddWithValue("@HeightCut", HeightCut);
//                        myCommand.Parameters.AddWithValue("@DoubleDoor", DoubleDoor);
//                        myCommand.Parameters.AddWithValue("@SupportHelpless", SupportHelpless);
//                        myCommand.Parameters.AddWithValue("@MakhzerShemen", MakhzerShemen);
//                        myCommand.Parameters.AddWithValue("@Atmer", Atmer);
//                        myCommand.Parameters.AddWithValue("@Side", Side);
//                        myCommand.Parameters.AddWithValue("@DDWingID", DDWingID);
//                        myCommand.Parameters.AddWithValue("@DDAK", DDAK);




//                        myConnection.Open();

//                        rowsAffected =  myCommand.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWing__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

//                rowsAffected = -1;
//            }

//            return (rowsAffected > 0);


//        } 
        
        
        public static bool  Update(int ID,

                        int OdrerId,
            string DoorNumber, DateTime DateAdded,
            string DoorType, string Direction,
            string LockType, string Location,
            string FactoryNotes, string Notes,
            int tbPrintAmount, int tbStickers,
            int tbAmount, string AccID,
            DateTime UpdateDate, string ColorDoor,
            string ColorSide, float FormaicaThickness,
            int WidthFinal, int HeightFinal,
            int WidthCut, int HeightCut,
            bool DoubleDoor, bool SupportHelpless,
            bool MakhzerShemen, bool Atmer,
            bool Side,int DDWingID,string DDAK
            )
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                


                    using (SqlCommand myCommand = new SqlCommand("SP_UpdateWings", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@OdrerId", OdrerId);
                        myCommand.Parameters.AddWithValue("@DoorNumber", DoorNumber);
                        myCommand.Parameters.AddWithValue("@DateAdded", DateAdded);
                        myCommand.Parameters.AddWithValue("@DoorType", DoorType);
                        myCommand.Parameters.AddWithValue("@Direction", Direction);
                        myCommand.Parameters.AddWithValue("@LockType", LockType);
                        myCommand.Parameters.AddWithValue("@Location", Location);
                        myCommand.Parameters.AddWithValue("@FactoryNotes", FactoryNotes);
                        myCommand.Parameters.AddWithValue("@Notes", Notes);
                        myCommand.Parameters.AddWithValue("@tbPrintAmount", tbPrintAmount);
                        myCommand.Parameters.AddWithValue("@tbStickers", tbStickers);
                        myCommand.Parameters.AddWithValue("@tbAmount", tbAmount);
                        myCommand.Parameters.AddWithValue("@AccID", AccID);
                        myCommand.Parameters.AddWithValue("@UpdateDate", UpdateDate);
                        myCommand.Parameters.AddWithValue("@ColorDoor", ColorDoor);
                        myCommand.Parameters.AddWithValue("@ColorSide", ColorSide);
                        myCommand.Parameters.AddWithValue("@FormaicaThickness", FormaicaThickness);
                        myCommand.Parameters.AddWithValue("@WidthFinal", WidthFinal);
                        myCommand.Parameters.AddWithValue("@HeightFinal", HeightFinal);
                        myCommand.Parameters.AddWithValue("@WidthCut", WidthCut);
                        myCommand.Parameters.AddWithValue("@HeightCut", HeightCut);
                        myCommand.Parameters.AddWithValue("@DoubleDoor", DoubleDoor);
                        myCommand.Parameters.AddWithValue("@SupportHelpless", SupportHelpless);
                        myCommand.Parameters.AddWithValue("@MakhzerShemen", MakhzerShemen);
                        myCommand.Parameters.AddWithValue("@Atmer", Atmer);
                        myCommand.Parameters.AddWithValue("@Side", Side);
                        myCommand.Parameters.AddWithValue("@DDWingID", DDWingID);
                        myCommand.Parameters.AddWithValue("@DDAK", DDAK);




                        myConnection.Open();

                        rowsAffected =  myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWing__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = @"
DELETE FROM wingType WHERE WingID = @id ;
DELETE FROM WingLock WHERE WingID = @id;
DELETE FROM WingWindows WHERE WingID = @id;
DELETE FROM WingHinge WHERE WingID = @id;
DELETE FROM WingAdvanced WHERE WingID = @id;
DELETE FROM WingAddon WHERE WingID = @id;
DELETE FROM Wings WHERE ID = @id;

";
                   

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWing__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT * FROM Wings";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {


                        myConnection.Open();

                        using ( SqlDataReader myReader =   myCommand.ExecuteReader())
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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWing__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


            return myDataTable;
        }

        
        public static DataTable getbyOrderID(int OdrerId)
        {
            DataTable myDataTable = new DataTable();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT * FROM Wings where OdrerId=@OdrerId Order By UpdateDate DESC";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@OdrerId", OdrerId);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWing__FUNCTION__getbyOrderID", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM Wings WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWing__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }

        public static bool IsExistNumberDoor( int OdrerId, string DoorNumber)
        {
            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT Found=1 FROM Wings WHERE OdrerId=@OdrerId and DoorNumber=@DoorNumber";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        
                        myCommand.Parameters.AddWithValue("@DoorNumber", DoorNumber);
                        myCommand.Parameters.AddWithValue("@OdrerId", OdrerId);
 


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWing__FUNCTION__IsExistNumberDoor", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }




    }
}

