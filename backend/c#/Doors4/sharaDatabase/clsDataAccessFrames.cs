using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace sharaDatabase
{
    public class clsDataAccessFrames
    {


        public static bool GetFrameByID(
            int ID, ref int OrderID, ref string FrameType,
           ref int Width, ref int Height, ref int WallThickness,
           ref float IronThickness, ref DateTime Date, ref string Direction,
            ref string LockType, ref string MaterialType,
            ref string Notes, ref int Quantity
            , ref int FrameThickness,
             ref int DoorNumber, ref bool Meksher, ref bool RHS70,
             ref bool DoubleDoor, ref bool FlakhGV, ref string Location, ref string DoorIdentity
            , ref string FactoryNotes, ref int FrameUnderFloor, ref bool isHand, ref int tbPrintAmount,
             ref int tbStickers, ref int tbAmount
            )
        {
            bool isFound = false;

            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM Frames WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                OrderID = (int)myReader["OrderID"];
                                FrameType = (string)myReader["FrameType"];
                                Width = (int)myReader["Width"];
                                Height = (int)myReader["Height"];
                                WallThickness = (int)myReader["WallThickness"];
                                IronThickness = Convert.ToSingle(myReader["IronThickness"]);
                                Date = (DateTime)myReader["Date"];
                                Direction = (string)myReader["Direction"];
                                LockType = (string)myReader["LockType"];
                                MaterialType = (string)myReader["MaterialType"];
                                Notes = (string)myReader["Notes"];
                                Quantity = (int)myReader["Quantity"];//presa value save

                                FrameThickness = (int)myReader["FrameThickness"];
                                DoorNumber = (int)myReader["DoorNumber"];
                                Meksher = (bool)myReader["Meksher"];
                                RHS70 = (bool)myReader["RHS70"];
                                DoubleDoor = (bool)myReader["DoubleDoor"];
                                FlakhGV = (bool)myReader["FlakhGV"];
                                Location = (string)myReader["Location"];
                                DoorIdentity = (string)myReader["DoorIdentity"];
                                FactoryNotes = (string)myReader["FactoryNotes"];
                                FrameUnderFloor = (int)myReader["FrameUnderFloor"];
                                isHand = (bool)myReader["isHand"];
                                tbPrintAmount = (int)myReader["tbPrintAmount"];
                                tbStickers = (int)myReader["tbStickers"];
                                tbAmount = (int)myReader["tbAmount"];




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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrames__FUNCTION__GetFrameByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }

        public static int Add(
                 int OrderID, string FrameType,
            int Width, int Height, int WallThickness,
            float IronThickness, DateTime Date, string Direction,
             string LockType, string MaterialType,
             string Notes, int Quantity
            , int FrameThickness,
              int DoorNumber, bool Meksher, bool RHS70,
              bool DoubleDoor, bool FlakhGV, string Location, string DoorIdentity
            , string FactoryNotes, int FrameUnderFloor, bool isHand, int tbPrintAmount,
              int tbStickers, int tbAmount

            )
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"

INSERT INTO [dbo].[Frames]
           (
            [OrderID]
           ,[FrameType]
           ,[Width]
           ,[Height]
           ,[WallThickness]
           ,[IronThickness]
           ,[Date]
           ,[Direction]
           ,[LockType]
           ,[MaterialType]  
           ,[Notes]
           ,[Quantity]
          
,[FrameThickness]
,DoorNumber
,Meksher
,RHS70
,DoubleDoor
,FlakhGV
,Location
,DoorIdentity
,FactoryNotes
,FrameUnderFloor
,isHand
,tbPrintAmount
,tbStickers
,tbAmount
)
     VALUES(

              @OrderID 
           , @FrameType 
           , @Width 
           , @Height 
           , @WallThickness 
           , @IronThickness 
           , @Date 
           , @Direction 
           , @LockType 
           , @MaterialType         
           , @Notes 
           , @Quantity 
         
,@FrameThickness
,@DoorNumber
,@Meksher
,@RHS70
,@DoubleDoor
,@FlakhGV
,@Location
,@DoorIdentity
,@FactoryNotes
,@FrameUnderFloor
,@isHand
,@tbPrintAmount
,@tbStickers
,@tbAmount

)



SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@OrderID", OrderID);
                        myCommand.Parameters.AddWithValue("@FrameType", FrameType);
                        myCommand.Parameters.AddWithValue("@Width", Width);
                        myCommand.Parameters.AddWithValue("@Height", Height);
                        myCommand.Parameters.AddWithValue("@WallThickness", WallThickness);
                        myCommand.Parameters.AddWithValue("@IronThickness", IronThickness);
                        myCommand.Parameters.AddWithValue("@Date", Date);
                        myCommand.Parameters.AddWithValue("@Direction", Direction);
                        myCommand.Parameters.AddWithValue("@LockType", LockType);
                        myCommand.Parameters.AddWithValue("@MaterialType", MaterialType);
                        myCommand.Parameters.AddWithValue("@Notes", Notes);
                        myCommand.Parameters.AddWithValue("@Quantity", Quantity);

                        myCommand.Parameters.AddWithValue("@FrameThickness", FrameThickness);
                        myCommand.Parameters.AddWithValue("@DoorNumber", DoorNumber);
                        myCommand.Parameters.AddWithValue("@Meksher", Meksher);
                        myCommand.Parameters.AddWithValue("@RHS70", RHS70);
                        myCommand.Parameters.AddWithValue("@DoubleDoor", DoubleDoor);
                        myCommand.Parameters.AddWithValue("@FlakhGV", FlakhGV);
                        myCommand.Parameters.AddWithValue("@Location", Location);
                        myCommand.Parameters.AddWithValue("@DoorIdentity", DoorIdentity);
                        myCommand.Parameters.AddWithValue("@FactoryNotes", FactoryNotes);
                        myCommand.Parameters.AddWithValue("@FrameUnderFloor", FrameUnderFloor);
                        myCommand.Parameters.AddWithValue("@isHand", isHand);
                        myCommand.Parameters.AddWithValue("@tbPrintAmount", tbPrintAmount);
                        myCommand.Parameters.AddWithValue("@tbStickers", tbStickers);
                        myCommand.Parameters.AddWithValue("@tbAmount", tbAmount);


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrames__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }

            return ID;

        }



        public static bool Update(int ID,
                    int OrderID, string FrameType,
            int Width, int Height, int WallThickness,
            float IronThickness, DateTime Date, string Direction,
             string LockType, string MaterialType,
             string Notes, int Quantity
            , int FrameThickness,
              int DoorNumber, bool Meksher, bool RHS70,
              bool DoubleDoor, bool FlakhGV, string Location, string DoorIdentity
            , string FactoryNotes, int FrameUnderFloor, bool isHand, int tbPrintAmount,
              int tbStickers, int tbAmount
            )
        {

            int rowsAffected = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"
UPDATE [dbo].[Frames]
   SET
[OrderID] =  @OrderID,  
      [FrameType] =  @FrameType,  
      [Width] =  @Width,  
      [Height] =  @Height,  
      [WallThickness] =  @WallThickness,  
      [IronThickness] =  @IronThickness,  
      [Date] =  @Date,
      [Direction] =  @Direction,  
      [LockType] =  @LockType,  
      [MaterialType] =  @MaterialType,  
      [Notes] =  @Notes, 
      [Quantity] =  @Quantity,  
     
[FrameThickness]=@FrameThickness
,[DoorNumber]=@DoorNumber
,[Meksher]=@Meksher
,[RHS70]=@RHS70
,[DoubleDoor]=@DoubleDoor
,[FlakhGV]=@FlakhGV
,[Location]=@Location
,[DoorIdentity]=@DoorIdentity
,[FactoryNotes]=@FactoryNotes
,[FrameUnderFloor]=@FrameUnderFloor
,[isHand]=@isHand
,[tbPrintAmount]=@tbPrintAmount
,[tbStickers]=@tbStickers
,[tbAmount]=@tbAmount

WHERE ID=@id";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@OrderID", OrderID);
                        myCommand.Parameters.AddWithValue("@FrameType", FrameType);
                        myCommand.Parameters.AddWithValue("@Width", Width);
                        myCommand.Parameters.AddWithValue("@Height", Height);
                        myCommand.Parameters.AddWithValue("@WallThickness", WallThickness);
                        myCommand.Parameters.AddWithValue("@IronThickness", IronThickness);
                        myCommand.Parameters.AddWithValue("@Date", Date);
                        myCommand.Parameters.AddWithValue("@Direction", Direction);
                        myCommand.Parameters.AddWithValue("@LockType", LockType);
                        myCommand.Parameters.AddWithValue("@MaterialType", MaterialType);
                        myCommand.Parameters.AddWithValue("@Notes", Notes);
                        myCommand.Parameters.AddWithValue("@Quantity", Quantity);


                        myCommand.Parameters.AddWithValue("@id", ID);

                        myCommand.Parameters.AddWithValue("@FrameThickness", FrameThickness);

                        myCommand.Parameters.AddWithValue("@DoorNumber", DoorNumber);
                        myCommand.Parameters.AddWithValue("@Meksher", Meksher);
                        myCommand.Parameters.AddWithValue("@RHS70", RHS70);
                        myCommand.Parameters.AddWithValue("@DoubleDoor", DoubleDoor);
                        myCommand.Parameters.AddWithValue("@FlakhGV", FlakhGV);

                        myCommand.Parameters.AddWithValue("@Location", Location);
                        myCommand.Parameters.AddWithValue("@DoorIdentity", DoorIdentity);
                        myCommand.Parameters.AddWithValue("@FactoryNotes", FactoryNotes);
                        myCommand.Parameters.AddWithValue("@FrameUnderFloor", FrameUnderFloor);
                        myCommand.Parameters.AddWithValue("@isHand", isHand);
                        myCommand.Parameters.AddWithValue("@tbPrintAmount", tbPrintAmount);
                        myCommand.Parameters.AddWithValue("@tbStickers", tbStickers);
                        myCommand.Parameters.AddWithValue("@tbAmount", tbAmount);


                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrames__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM Frames WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrames__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT * FROM Frames";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrames__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


            return myDataTable;
        }


        public static DataTable getFrameForOrderID(int OrderID)
        {
            DataTable myDataTable = new DataTable();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT * FROM Frames WHERE OrderID=@OrderID Order By Date DESC";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@OrderID", OrderID);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrames__FUNCTION__getFrameForOrderID", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM Frames WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrames__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }  
        
        
        public static bool FindByOrderframeNumber(string DoorNumber,int OrderID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = "SELECT Found=1 FROM Frames WHERE OrderID=@OrderID and  DoorNumber = @DoorNumber ";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        int.TryParse(DoorNumber, out int res);

                        myCommand.Parameters.AddWithValue("@DoorNumber", res);
                        myCommand.Parameters.AddWithValue("@OrderID", OrderID);


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrames__FUNCTION__FindByOrderframeNumber", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }




        public static DataTable Search(string search, int OrderID)
        {




            DataTable myDataTable = new DataTable();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"SELECT * FROM Frames WHERE
(Notes LIKE @search )

AND

OrderID=@OrderID


";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                        myCommand.Parameters.AddWithValue("@OrderID", OrderID);

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrames__FUNCTION__Search", System.Diagnostics.EventLogEntryType.Error);

                myDataTable = null;
            }


            return myDataTable;
        }


        public static async Task<List<clsExportDoorFrameDetailsToExcelFileDTO>> DAL_ExportDoorFrameDetailsToExcelFile(int orderId)
        {
            List<clsExportDoorFrameDetailsToExcelFileDTO> EDFDTEF = new List<clsExportDoorFrameDetailsToExcelFileDTO>();

            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {
                    using (SqlCommand myCommand = new SqlCommand("SP_ExportDoorFrameDetailsToExcelFile", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        myCommand.Parameters.AddWithValue("@OrderID", orderId);

                       await myConnection.OpenAsync();

                        using (SqlDataReader myReader =await myCommand.ExecuteReaderAsync())
                        {

                            while (await myReader.ReadAsync()) {


                                EDFDTEF.Add(new clsExportDoorFrameDetailsToExcelFileDTO
                                {

                                    ID= myReader["ID"] != DBNull.Value ? (int)myReader["ID"] : -1,
                                    UpperLockMeasureFloor = myReader["UpperLockMeasureFloor"] != DBNull.Value ? (int)myReader["UpperLockMeasureFloor"] : -1,
                                    WallThickness = myReader["WallThickness"] != DBNull.Value ? (int)myReader["WallThickness"] : -1,
                                    LockMeasureFloor = myReader["LockMeasureFloor"] != DBNull.Value ? (int)myReader["LockMeasureFloor"] : -1,
                                    OrderNumber= myReader["OrderNumber"] != DBNull.Value ? (int)myReader["OrderNumber"] : -1,
                                    DoorNumber = myReader["DoorNumber"] != DBNull.Value ? (int)myReader["DoorNumber"] : -1,
                                    DoorIdentity = myReader["DoorIdentity"] != DBNull.Value ? (string)myReader["DoorIdentity"] : string.Empty,
                                    CompanyName = myReader["CompanyName"] != DBNull.Value ? (string)myReader["CompanyName"] : string.Empty,
                                    ProjectName = myReader["ProjectName"] != DBNull.Value ? (string)myReader["ProjectName"] : string.Empty,
                                    FrameType = myReader["FrameType"] != DBNull.Value ? (string)myReader["FrameType"] : string.Empty,
                                    Location = myReader["Location"] != DBNull.Value ? (string)myReader["Location"] : string.Empty,
                                    Notes = myReader["FactoryNotes"] != DBNull.Value ? (string)myReader["FactoryNotes"] : string.Empty,
                                    FactoryNotes = myReader["Notes"] != DBNull.Value ? (string)myReader["Notes"] : string.Empty,
                                    Date = myReader["Date"] != DBNull.Value ? (DateTime)myReader["Date"] :DateTime.MinValue,
                                    MaterialType = myReader["MaterialType"] != DBNull.Value ? (string)myReader["MaterialType"] : string.Empty,
                                    IronThickness = myReader["IronThickness"] != DBNull.Value ? Convert.ToSingle(myReader["IronThickness"]) : -1,
                                    Height = myReader["Height"] != DBNull.Value ? (int)myReader["Height"] : -1,
                                    Width = myReader["Width"] != DBNull.Value ? (int)myReader["Width"] : -1,
                                    FrameThickness = myReader["FrameThickness"] != DBNull.Value ? (int)myReader["FrameThickness"] : -1,
                                    Direction = myReader["Direction"] != DBNull.Value ? (string)myReader["Direction"] : string.Empty,
                                    Quantity = myReader["tbAmount"] != DBNull.Value ? (int)myReader["tbAmount"] : -1,
                                    LockType = myReader["LockType"] != DBNull.Value ? (string)myReader["LockType"] : string.Empty,
                                    LockMeasure = myReader["LockMeasure"] != DBNull.Value ? (int)myReader["LockMeasure"] : -1,
                                    UpperLockMeasure = myReader["UpperLockMeasure"] != DBNull.Value ? (int)myReader["UpperLockMeasure"] : -1,
                                    HingeAmount = myReader["HingeAmount"] != DBNull.Value ? (int)myReader["HingeAmount"] : -1,
                                    Hinge1 = myReader["Hinge1"] != DBNull.Value ? (int)myReader["Hinge1"] : -1,
                                    Hinge2 = myReader["Hinge2"] != DBNull.Value ? (int)myReader["Hinge2"] : -1,
                                    Hinge3 = myReader["Hinge3"] != DBNull.Value ? (int)myReader["Hinge3"] : -1,
                                    Hinge4 = myReader["Hinge4"] != DBNull.Value ? (int)myReader["Hinge4"] : -1,
                                    Hinge5 = myReader["Hinge5"] != DBNull.Value ? (int)myReader["Hinge5"] : -1,
                                    Hinge6 = myReader["Hinge6"] != DBNull.Value ? (int)myReader["Hinge6"] : -1,
                                    HingeType = myReader["HingeType"] != DBNull.Value ? (string)myReader["HingeType"] : string.Empty,
                                    HingeConnection = myReader["HingeConnection"] != DBNull.Value ? (string)myReader["HingeConnection"] : string.Empty,
                                    HingeMetal = myReader["HingeMetal"] != DBNull.Value ? (string)myReader["HingeMetal"] : string.Empty,
                                    FrameUnderFloor = myReader["FrameUnderFloor"] != DBNull.Value ? (int)myReader["FrameUnderFloor"] : -1,
                                    Meksher = myReader["Meksher"] != DBNull.Value && (bool)myReader["Meksher"],
                                    Kitum = myReader["Kitum"] != DBNull.Value && (bool)myReader["Kitum"],
                                     Nerousta = myReader["Nerousta"] != DBNull.Value && (bool)myReader["Nerousta"],
                                    BottomSize = myReader["BottomSize"] != DBNull.Value ? (int)myReader["BottomSize"] : -1,
                                    upperPartType = myReader["upperPartType"] != DBNull.Value ? (string)myReader["upperPartType"] : string.Empty,
                                    upperPartSize = myReader["upperPartSize"] != DBNull.Value ? (int)myReader["upperPartSize"] : -1,
                                    HiddenOil = myReader["HiddenOil"] != DBNull.Value && (bool)myReader["HiddenOil"],
                                    DoubleDoor = myReader["DoubleDoor"] != DBNull.Value && (bool)myReader["DoubleDoor"],
                                    RHS70 = myReader["RHS70"] != DBNull.Value && (bool)myReader["RHS70"],


                                });



                            }
                            
                            myReader.Close();

                        }

                    }
                }
        }catch(Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessFrames__FUNCTION__DAL_ExportDoorFrameDetailsToExcelFile", System.Diagnostics.EventLogEntryType.Error);
                EDFDTEF = null;
                throw new Exception(ex.Message);
               
            }

            return EDFDTEF;
                }




    }
}
