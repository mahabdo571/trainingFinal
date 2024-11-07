using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharaDatabase
{
    public class clsDataAccessWingAdvanced
    {

        public static bool GetByID(int ID, ref int WingShorteningFromBottom, ref int WingShorteningFromAbove,
            ref int ThicknessWing, ref bool EvacuationHandle, ref bool PullSideLever,
            ref bool PushHandle, ref bool PushSideLever, ref bool PullHandle, ref bool HandleHoles,
            ref bool ClearanceTheCylinder, ref bool Cylinder, ref bool HolesCylinder, ref int WingID
            , ref bool woodLockBasic, ref bool woodUpeerLock, ref bool woodBehalaLock, ref bool woodSpeacilCasesHingeUP,
            ref bool woodSpeacilCasesHingeDN, ref int woodLockBasicWidth, ref int woodLockBasicHeight,
            ref int woodLockBasicLocation, ref int woodUpeerWidth, ref int woodUpeerHeight, ref int woodUpeerLockLocation,
            ref int woodBehalaLockWidth, ref int woodBehalaLockHeight, ref int woodBehalaLockLocation,
            ref int woodSpeacilCasesHingeUPWidth, ref int woodSpeacilCasesHingeUPHeight, ref int woodSpeacilCasesHingeUPLocation,
            ref int woodSpeacilCasesHingeDNWidth, ref int woodSpeacilCasesHingeDNHeight, ref int woodSpeacilCasesHingeDNLocation
            ,ref int KantA,ref int KantB,ref bool woodBehalaLockManual
            )
        {
            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM WingAdvanced WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", ID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                                WingShorteningFromBottom = (int)myReader["WingShorteningFromBottom"];
                                WingShorteningFromAbove = (int)myReader["WingShorteningFromAbove"];
                                ThicknessWing = (int)myReader["ThicknessWing"];
                                EvacuationHandle = (bool)myReader["EvacuationHandle"];
                                PushSideLever = (bool)myReader["PushSideLever"];
                                PushHandle = (bool)myReader["PushHandle"];
                                PullSideLever = (bool)myReader["PullSideLever"];
                                PullHandle = (bool)myReader["PullHandle"];
                                HandleHoles = (bool)myReader["HandleHoles"];
                                ClearanceTheCylinder = (bool)myReader["ClearanceTheCylinder"];
                                Cylinder = (bool)myReader["Cylinder"];
                                HolesCylinder = (bool)myReader["HolesCylinder"];
                                WingID = (int)myReader["WingID"];
                                woodSpeacilCasesHingeDNLocation = (int)myReader["woodSpeacilCasesHingeDNLocation"];
                                woodSpeacilCasesHingeDNHeight = (int)myReader["woodSpeacilCasesHingeDNHeight"];
                                woodSpeacilCasesHingeDNWidth = (int)myReader["woodSpeacilCasesHingeDNWidth"];
                                woodSpeacilCasesHingeUPLocation = (int)myReader["woodSpeacilCasesHingeUPLocation"];
                                woodSpeacilCasesHingeUPHeight = (int)myReader["woodSpeacilCasesHingeUPHeight"];
                                woodSpeacilCasesHingeUPWidth = (int)myReader["woodSpeacilCasesHingeUPWidth"];
                                woodBehalaLockLocation = (int)myReader["woodBehalaLockLocation"];
                                woodBehalaLockHeight = (int)myReader["woodBehalaLockHeight"];
                                woodBehalaLockWidth = (int)myReader["woodBehalaLockWidth"];
                                woodUpeerLockLocation = (int)myReader["woodUpeerLockLocation"];
                                woodUpeerHeight = (int)myReader["woodUpeerHeight"];
                                woodUpeerWidth = (int)myReader["woodUpeerWidth"];
                                woodLockBasicLocation = (int)myReader["woodLockBasicLocation"];
                                woodLockBasicHeight = (int)myReader["woodLockBasicHeight"];
                                woodLockBasicWidth = (int)myReader["woodLockBasicWidth"];
                                woodSpeacilCasesHingeDN = (bool)myReader["woodSpeacilCasesHingeDN"];
                                woodSpeacilCasesHingeUP = (bool)myReader["woodSpeacilCasesHingeUP"];
                                woodBehalaLock = (bool)myReader["woodBehalaLock"];
                                woodUpeerLock = (bool)myReader["woodUpeerLock"];
                                woodLockBasic = (bool)myReader["woodLockBasic"];

                                KantA = (int)myReader["KantA"];
                                KantB = (int)myReader["KantB"];
                                woodBehalaLockManual = (bool)myReader["woodBehalaLockManual"];
                            



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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAdvanced__FUNCTION__GetByID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }
            return isFound;





        }

        public static bool GetByWingID(ref int ID, ref int WingShorteningFromBottom, ref int WingShorteningFromAbove,
            ref int ThicknessWing, ref bool EvacuationHandle, ref bool PullSideLever,
            ref bool PushHandle, ref bool PushSideLever, ref bool PullHandle, ref bool HandleHoles,
            ref bool ClearanceTheCylinder, ref bool Cylinder, ref bool HolesCylinder, int WingID
                , ref bool woodLockBasic, ref bool woodUpeerLock, ref bool woodBehalaLock, ref bool woodSpeacilCasesHingeUP,
            ref bool woodSpeacilCasesHingeDN, ref int woodLockBasicWidth, ref int woodLockBasicHeight,
            ref int woodLockBasicLocation, ref int woodUpeerWidth, ref int woodUpeerHeight, ref int woodUpeerLockLocation,
            ref int woodBehalaLockWidth, ref int woodBehalaLockHeight, ref int woodBehalaLockLocation,
            ref int woodSpeacilCasesHingeUPWidth, ref int woodSpeacilCasesHingeUPHeight, ref int woodSpeacilCasesHingeUPLocation,
            ref int woodSpeacilCasesHingeDNWidth, ref int woodSpeacilCasesHingeDNHeight, ref int woodSpeacilCasesHingeDNLocation
               , ref int KantA, ref int KantB,ref bool woodBehalaLockManual
            )
        {
            bool isFound = false;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {



                    string myQuery = "SELECT * FROM WingAdvanced WHERE WingID=@WingID";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@WingID", WingID);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {


                                WingShorteningFromBottom = (int)myReader["WingShorteningFromBottom"];
                                WingShorteningFromAbove = (int)myReader["WingShorteningFromAbove"];
                                ThicknessWing = (int)myReader["ThicknessWing"];
                                EvacuationHandle = (bool)myReader["EvacuationHandle"];
                                PushSideLever = (bool)myReader["PushSideLever"];
                                PushHandle = (bool)myReader["PushHandle"];
                                PullSideLever = (bool)myReader["PullSideLever"];
                                PullHandle = (bool)myReader["PullHandle"];
                                HandleHoles = (bool)myReader["HandleHoles"];
                                ClearanceTheCylinder = (bool)myReader["ClearanceTheCylinder"];
                                Cylinder = (bool)myReader["Cylinder"];
                                HolesCylinder = (bool)myReader["HolesCylinder"];




                                ID = (int)myReader["ID"];

                                woodSpeacilCasesHingeDNLocation = (int)myReader["woodSpeacilCasesHingeDNLocation"];
                                woodSpeacilCasesHingeDNHeight = (int)myReader["woodSpeacilCasesHingeDNHeight"];
                                woodSpeacilCasesHingeDNWidth = (int)myReader["woodSpeacilCasesHingeDNWidth"];
                                woodSpeacilCasesHingeUPLocation = (int)myReader["woodSpeacilCasesHingeUPLocation"];
                                woodSpeacilCasesHingeUPHeight = (int)myReader["woodSpeacilCasesHingeUPHeight"];
                                woodSpeacilCasesHingeUPWidth = (int)myReader["woodSpeacilCasesHingeUPWidth"];
                                woodBehalaLockLocation = (int)myReader["woodBehalaLockLocation"];
                                woodBehalaLockHeight = (int)myReader["woodBehalaLockHeight"];
                                woodBehalaLockWidth = (int)myReader["woodBehalaLockWidth"];
                                woodUpeerLockLocation = (int)myReader["woodUpeerLockLocation"];
                                woodUpeerHeight = (int)myReader["woodUpeerHeight"];
                                woodUpeerWidth = (int)myReader["woodUpeerWidth"];
                                woodLockBasicLocation = (int)myReader["woodLockBasicLocation"];
                                woodLockBasicHeight = (int)myReader["woodLockBasicHeight"];
                                woodLockBasicWidth = (int)myReader["woodLockBasicWidth"];
                                woodSpeacilCasesHingeDN = (bool)myReader["woodSpeacilCasesHingeDN"];
                                woodSpeacilCasesHingeUP = (bool)myReader["woodSpeacilCasesHingeUP"];
                                woodBehalaLock = (bool)myReader["woodBehalaLock"];
                                woodUpeerLock = (bool)myReader["woodUpeerLock"];
                                woodLockBasic = (bool)myReader["woodLockBasic"];

                                KantA = (int)myReader["KantA"];
                                KantB = (int)myReader["KantB"];
                                woodBehalaLockManual = (bool)myReader["woodBehalaLockManual"];




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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAdvanced__FUNCTION__GetByWingID", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;





        }




        public static int Add(int WingShorteningFromBottom, int WingShorteningFromAbove, int ThicknessWing,
            bool EvacuationHandle, bool PushSideLever, bool PushHandle, bool PullSideLever,
            bool PullHandle, bool HandleHoles, bool ClearanceTheCylinder, bool Cylinder, bool HolesCylinder, int WingID
          ,  bool woodLockBasic,  bool woodUpeerLock,  bool woodBehalaLock,  bool woodSpeacilCasesHingeUP,
             bool woodSpeacilCasesHingeDN,  int woodLockBasicWidth,  int woodLockBasicHeight,
             int woodLockBasicLocation,  int woodUpeerWidth,  int woodUpeerHeight,  int woodUpeerLockLocation,
             int woodBehalaLockWidth,  int woodBehalaLockHeight,  int woodBehalaLockLocation,
             int woodSpeacilCasesHingeUPWidth,  int woodSpeacilCasesHingeUPHeight,  int woodSpeacilCasesHingeUPLocation,
             int woodSpeacilCasesHingeDNWidth,  int woodSpeacilCasesHingeDNHeight,  int woodSpeacilCasesHingeDNLocation
                   ,  int KantA,  int KantB,bool woodBehalaLockManual
            )
        {

            int ID = -1;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {

                    string myQuery = @"INSERT INTO WingAdvanced
(WingShorteningFromBottom,WingShorteningFromAbove,
ThicknessWing,EvacuationHandle,PushSideLever,PushHandle,
PullSideLever,PullHandle,HandleHoles,ClearanceTheCylinder,Cylinder,HolesCylinder,WingID,woodLockBasic,woodUpeerLock,woodBehalaLock,woodSpeacilCasesHingeUP
,woodSpeacilCasesHingeDN,woodLockBasicWidth,woodLockBasicHeight,woodLockBasicLocation,woodUpeerWidth,woodUpeerHeight,woodUpeerLockLocation,woodBehalaLockWidth
,woodBehalaLockHeight,woodBehalaLockLocation,woodSpeacilCasesHingeUPWidth,woodSpeacilCasesHingeUPHeight,woodSpeacilCasesHingeUPLocation,woodSpeacilCasesHingeDNWidth,
woodSpeacilCasesHingeDNHeight,woodSpeacilCasesHingeDNLocation,KantA,KantB,woodBehalaLockManual
)
VALUES
(@WingShorteningFromBottom,@WingShorteningFromAbove,@ThicknessWing,@EvacuationHandle,
@PushSideLever,@PushHandle,@PullSideLever,@PullHandle,@HandleHoles,@ClearanceTheCylinder,
@Cylinder,@HolesCylinder,@WingID,@woodLockBasic,@woodUpeerLock,@woodBehalaLock,@woodSpeacilCasesHingeUP,@woodSpeacilCasesHingeDN,
@woodLockBasicWidth,@woodLockBasicHeight,@woodLockBasicLocation,@woodUpeerWidth,@woodUpeerHeight,@woodUpeerLockLocation,@woodBehalaLockWidth
,@woodBehalaLockHeight,@woodBehalaLockLocation,@woodSpeacilCasesHingeUPWidth,@woodSpeacilCasesHingeUPHeight,@woodSpeacilCasesHingeUPLocation,@woodSpeacilCasesHingeDNWidth
,@woodSpeacilCasesHingeDNHeight,@woodSpeacilCasesHingeDNLocation,@KantA,@KantB,@woodBehalaLockManual
); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@KantA", KantA);
                        myCommand.Parameters.AddWithValue("@KantB", KantB);
                        myCommand.Parameters.AddWithValue("@WingShorteningFromBottom", WingShorteningFromBottom);
                        myCommand.Parameters.AddWithValue("@WingShorteningFromAbove", WingShorteningFromAbove);
                        myCommand.Parameters.AddWithValue("@ThicknessWing", ThicknessWing);
                        myCommand.Parameters.AddWithValue("@EvacuationHandle", EvacuationHandle);
                        myCommand.Parameters.AddWithValue("@PushSideLever", PushSideLever);
                        myCommand.Parameters.AddWithValue("@PushHandle", PushHandle);
                        myCommand.Parameters.AddWithValue("@PullSideLever", PullSideLever);
                        myCommand.Parameters.AddWithValue("@PullHandle", PullHandle);
                        myCommand.Parameters.AddWithValue("@HandleHoles", HandleHoles);
                        myCommand.Parameters.AddWithValue("@ClearanceTheCylinder", ClearanceTheCylinder);
                        myCommand.Parameters.AddWithValue("@Cylinder", Cylinder);
                        myCommand.Parameters.AddWithValue("@HolesCylinder", HolesCylinder);
                        myCommand.Parameters.AddWithValue("@WingID", WingID);
                        myCommand.Parameters.AddWithValue("@woodLockBasic", woodLockBasic);
                        myCommand.Parameters.AddWithValue("@woodUpeerLock", woodUpeerLock);
                        myCommand.Parameters.AddWithValue("@woodBehalaLock", woodBehalaLock);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeUP", woodSpeacilCasesHingeUP);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeDN", woodSpeacilCasesHingeDN);
                        myCommand.Parameters.AddWithValue("@woodLockBasicWidth", woodLockBasicWidth);
                        myCommand.Parameters.AddWithValue("@woodLockBasicHeight", woodLockBasicHeight);
                        myCommand.Parameters.AddWithValue("@woodLockBasicLocation", woodLockBasicLocation);
                        myCommand.Parameters.AddWithValue("@woodUpeerWidth", woodUpeerWidth);
                        myCommand.Parameters.AddWithValue("@woodUpeerHeight", woodUpeerHeight);
                        myCommand.Parameters.AddWithValue("@woodUpeerLockLocation", woodUpeerLockLocation);
                        myCommand.Parameters.AddWithValue("@woodBehalaLockWidth", woodBehalaLockWidth);
                        myCommand.Parameters.AddWithValue("@woodBehalaLockHeight", woodBehalaLockHeight);
                        myCommand.Parameters.AddWithValue("@woodBehalaLockLocation", woodBehalaLockLocation);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeUPWidth", woodSpeacilCasesHingeUPWidth);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeUPHeight", woodSpeacilCasesHingeUPHeight);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeUPLocation", woodSpeacilCasesHingeUPLocation);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeDNWidth", woodSpeacilCasesHingeDNWidth);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeDNHeight", woodSpeacilCasesHingeDNHeight);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeDNLocation", woodSpeacilCasesHingeDNLocation);
                        myCommand.Parameters.AddWithValue("@woodBehalaLockManual", woodBehalaLockManual);




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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAdvanced__FUNCTION__Add", System.Diagnostics.EventLogEntryType.Error);

                ID = -1;
            }
            return ID;

        }



        public static bool Update(int ID, int WingShorteningFromBottom, int WingShorteningFromAbove,
            int ThicknessWing, bool EvacuationHandle, bool PushSideLever, bool PushHandle,
            bool PullSideLever, bool PullHandle, bool HandleHoles, bool ClearanceTheCylinder
            , bool Cylinder, bool HolesCylinder, int WingID
                , bool woodLockBasic, bool woodUpeerLock, bool woodBehalaLock, bool woodSpeacilCasesHingeUP,
             bool woodSpeacilCasesHingeDN, int woodLockBasicWidth, int woodLockBasicHeight,
             int woodLockBasicLocation, int woodUpeerWidth, int woodUpeerHeight, int woodUpeerLockLocation,
             int woodBehalaLockWidth, int woodBehalaLockHeight, int woodBehalaLockLocation,
             int woodSpeacilCasesHingeUPWidth, int woodSpeacilCasesHingeUPHeight, int woodSpeacilCasesHingeUPLocation,
             int woodSpeacilCasesHingeDNWidth, int woodSpeacilCasesHingeDNHeight, int woodSpeacilCasesHingeDNLocation
              , int KantA, int KantB,bool woodBehalaLockManual 
            )
        {

            int rowsAffected = 0;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
                {


                    string myQuery = @"UPDATE WingAdvanced SET 
WingShorteningFromBottom=@WingShorteningFromBottom,
WingShorteningFromAbove=@WingShorteningFromAbove,
ThicknessWing=@ThicknessWing,
EvacuationHandle=@EvacuationHandle,
PushSideLever=@PushSideLever,
PushHandle=@PushHandle,
PullSideLever=@PullSideLever,
PullHandle=@PullHandle,
HandleHoles=@HandleHoles,
ClearanceTheCylinder=@ClearanceTheCylinder,
Cylinder=@Cylinder,
HolesCylinder=@HolesCylinder,
WingID=@WingID,
woodLockBasic=@woodLockBasic,
woodUpeerLock=@woodUpeerLock,
woodBehalaLock=@woodBehalaLock,
woodSpeacilCasesHingeUP=@woodSpeacilCasesHingeUP,
woodSpeacilCasesHingeDN=@woodSpeacilCasesHingeDN,
woodLockBasicWidth=@woodLockBasicWidth,
woodLockBasicHeight=@woodLockBasicHeight,
woodLockBasicLocation=@woodLockBasicLocation,
woodUpeerWidth=@woodUpeerWidth,
woodUpeerHeight=@woodUpeerHeight,
woodUpeerLockLocation=@woodUpeerLockLocation,
woodBehalaLockWidth=@woodBehalaLockWidth,
woodBehalaLockHeight=@woodBehalaLockHeight,
woodBehalaLockLocation=@woodBehalaLockLocation,
woodSpeacilCasesHingeUPWidth=@woodSpeacilCasesHingeUPWidth,
woodSpeacilCasesHingeUPHeight=@woodSpeacilCasesHingeUPHeight,
woodSpeacilCasesHingeUPLocation=@woodSpeacilCasesHingeUPLocation,
woodSpeacilCasesHingeDNWidth=@woodSpeacilCasesHingeDNWidth,
woodSpeacilCasesHingeDNHeight=@woodSpeacilCasesHingeDNHeight,
woodSpeacilCasesHingeDNLocation=@woodSpeacilCasesHingeDNLocation,
KantA=@KantA,
KantB=@KantB,
woodBehalaLockManual=@woodBehalaLockManual



WHERE ID=@ID";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@KantB", KantB);
                        myCommand.Parameters.AddWithValue("@KantA", KantA);
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@WingShorteningFromBottom", WingShorteningFromBottom);
                        myCommand.Parameters.AddWithValue("@WingShorteningFromAbove", WingShorteningFromAbove);
                        myCommand.Parameters.AddWithValue("@ThicknessWing", ThicknessWing);
                        myCommand.Parameters.AddWithValue("@EvacuationHandle", EvacuationHandle);
                        myCommand.Parameters.AddWithValue("@PushSideLever", PushSideLever);
                        myCommand.Parameters.AddWithValue("@PushHandle", PushHandle);
                        myCommand.Parameters.AddWithValue("@PullSideLever", PullSideLever);
                        myCommand.Parameters.AddWithValue("@PullHandle", PullHandle);
                        myCommand.Parameters.AddWithValue("@HandleHoles", HandleHoles);
                        myCommand.Parameters.AddWithValue("@ClearanceTheCylinder", ClearanceTheCylinder);
                        myCommand.Parameters.AddWithValue("@Cylinder", Cylinder);
                        myCommand.Parameters.AddWithValue("@HolesCylinder", HolesCylinder);
                        myCommand.Parameters.AddWithValue("@WingID", WingID);

                        myCommand.Parameters.AddWithValue("@woodLockBasic", woodLockBasic);
                        myCommand.Parameters.AddWithValue("@woodUpeerLock", woodUpeerLock);
                        myCommand.Parameters.AddWithValue("@woodBehalaLock", woodBehalaLock);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeUP", woodSpeacilCasesHingeUP);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeDN", woodSpeacilCasesHingeDN);
                        myCommand.Parameters.AddWithValue("@woodLockBasicWidth", woodLockBasicWidth);
                        myCommand.Parameters.AddWithValue("@woodLockBasicHeight", woodLockBasicHeight);
                        myCommand.Parameters.AddWithValue("@woodLockBasicLocation", woodLockBasicLocation);
                        myCommand.Parameters.AddWithValue("@woodUpeerWidth", woodUpeerWidth);
                        myCommand.Parameters.AddWithValue("@woodUpeerHeight", woodUpeerHeight);
                        myCommand.Parameters.AddWithValue("@woodUpeerLockLocation", woodUpeerLockLocation);
                        myCommand.Parameters.AddWithValue("@woodBehalaLockWidth", woodBehalaLockWidth);
                        myCommand.Parameters.AddWithValue("@woodBehalaLockHeight", woodBehalaLockHeight);
                        myCommand.Parameters.AddWithValue("@woodBehalaLockLocation", woodBehalaLockLocation);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeUPWidth", woodSpeacilCasesHingeUPWidth);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeUPHeight", woodSpeacilCasesHingeUPHeight);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeUPLocation", woodSpeacilCasesHingeUPLocation);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeDNWidth", woodSpeacilCasesHingeDNWidth);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeDNHeight", woodSpeacilCasesHingeDNHeight);
                        myCommand.Parameters.AddWithValue("@woodSpeacilCasesHingeDNLocation", woodSpeacilCasesHingeDNLocation);
                        myCommand.Parameters.AddWithValue("@woodBehalaLockManual", woodBehalaLockManual);





                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAdvanced__FUNCTION__Update", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "DELETE FROM WingAdvanced WHERE ID=@id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAdvanced__FUNCTION__Delete", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT * FROM WingAdvanced";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {


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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAdvanced__FUNCTION__GetAll", System.Diagnostics.EventLogEntryType.Error);

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

                    string myQuery = "SELECT Found=1 FROM WingAdvanced WHERE ID = @id";

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
                clsDataAccessSettings.SetEventLogMsg(ex.Message, "CLS_clsDataAccessWingAdvanced__FUNCTION__IsExist", System.Diagnostics.EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }



    }
}
