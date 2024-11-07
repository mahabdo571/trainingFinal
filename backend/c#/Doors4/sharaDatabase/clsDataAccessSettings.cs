using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;

namespace sharaDatabase
{
    public class clsDataAccessSettings
    {

   
        static string __PathRegMachin = @"HKEY_CURRENT_USER\Software\SharabanyDoorOrder";
        static string __IpServer_RegName = "IpServer";
        static string ___DataBaseName_RegName = "DataBaseName";
        static string ___IUserDatabase_RegName = "IUserDatabase";
        static string ___PasswordDataBase_RegName = "PasswordDataBase";
        static string ___KeyF = "KeyF";

        static string ___ModeDataBase_RegName = "ModeDataBase";

        public static string ConnectionString()
        {
            //return "Server=192.168.130.222;Database=sharabanyDBorderNew;User Id=sa;Password=m22A!@#456;";


            string KEY = Registry.GetValue(__PathRegMachin, ___KeyF, null) as string;// clsAPI.ApiKeyEnc1();

                string _IpServer="";
         string _DataBaseName="";
         string _IUserDatabase = "";
         string _PasswordDataBase=  "";
        string ConnectionS;
            try
            {

                if (!string.IsNullOrEmpty(Registry.GetValue( __PathRegMachin, __IpServer_RegName, null) as string))
                {
                    _IpServer = clsStringEncrypt.Decrypt(Registry.GetValue(__PathRegMachin, __IpServer_RegName, null) as string, KEY);
                    _DataBaseName = clsStringEncrypt.Decrypt(Registry.GetValue(__PathRegMachin, ___DataBaseName_RegName, null) as string, KEY);
                    _IUserDatabase = clsStringEncrypt.Decrypt(Registry.GetValue(__PathRegMachin, ___IUserDatabase_RegName, null) as string, KEY);
                    _PasswordDataBase = clsStringEncrypt.Decrypt(Registry.GetValue(__PathRegMachin, ___PasswordDataBase_RegName, null) as string, KEY);


                    if (Registry.GetValue(__PathRegMachin, ___ModeDataBase_RegName, null) as string == "USER")
                    {
                        ConnectionS = $@"Server={_IpServer};Database={_DataBaseName};User Id={_IUserDatabase};Password={_PasswordDataBase};";
                    }
                    else
                    {
                        ConnectionS = $@"Server={_IpServer};Database={_DataBaseName};Integrated Security=True;";
                  
                    }
                }
                else
                {
                    ConnectionS = "";
                }

                //throw new Exception(ConnectionS);
            }
            catch(Exception ex)
            {
                SetEventLogMsg(ex.Message, "CLS_clsDataAccessSettings__FUNCTION_NAME_ConnectionString", EventLogEntryType.Error);
                return "";
            }

                return ConnectionS;

            
        
        }


        public static bool CheckConnection()
        {
            try
            {
                if (Registry.GetValue(__PathRegMachin,__IpServer_RegName,null) as string != null)
                {

                    using (SqlConnection connection = new SqlConnection(ConnectionString()))
                    {

                        connection.Open();
                     

                        return true;                   

                    }

                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                SetEventLogMsg(ex.Message, "CLS_clsDataAccessSettings__FUNCTION_NAME_CheckConnection", EventLogEntryType.Error);
                return false;
            }
        }



        public static bool Update(byte StickerAmountPerDoor_Frame,byte StickerAmountPerDoor_F,byte StickerAmountPerDoor_A,byte StickerAmountPerDoor_Alpha,
            byte StickerAmountPerDoor_Windo,byte StickerAmountPerDoor_Tris,byte PaperAmountPerDoor_Frame,byte PaperAmountPerDoor_F, byte PaperAmountPerDoor_A,
            byte PaperAmountPerDoor_Alpha,byte PaperAmountPerDoor_Windo,byte PaperAmountPerDoor_Tris
            )
        {

            int rowsAffected = 0;
            try
            {

                using (SqlConnection myConnection = new SqlConnection(ConnectionString()))
            {


                string myQuery = @"UPDATE Settings SET 
StickerAmountPerDoor_Frame=@StickerAmountPerDoor_Frame,
StickerAmountPerDoor_F=@StickerAmountPerDoor_F,
StickerAmountPerDoor_A=@StickerAmountPerDoor_A,
StickerAmountPerDoor_Alpha=@StickerAmountPerDoor_Alpha,
StickerAmountPerDoor_Windo=@StickerAmountPerDoor_Windo,
StickerAmountPerDoor_Tris=@StickerAmountPerDoor_Tris,
PaperAmountPerDoor_Frame=@PaperAmountPerDoor_Frame,
PaperAmountPerDoor_F=@PaperAmountPerDoor_F,
PaperAmountPerDoor_A=@PaperAmountPerDoor_A,
PaperAmountPerDoor_Alpha=@PaperAmountPerDoor_Alpha,
PaperAmountPerDoor_Windo=@PaperAmountPerDoor_Windo,
PaperAmountPerDoor_Tris=@PaperAmountPerDoor_Tris

WHERE ID=@id";


                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", 1);
    
                        myCommand.Parameters.AddWithValue("@StickerAmountPerDoor_Frame", StickerAmountPerDoor_Frame);
                        myCommand.Parameters.AddWithValue("@StickerAmountPerDoor_F", StickerAmountPerDoor_F);
                        myCommand.Parameters.AddWithValue("@StickerAmountPerDoor_A", StickerAmountPerDoor_A);
                        myCommand.Parameters.AddWithValue("@StickerAmountPerDoor_Alpha", StickerAmountPerDoor_Alpha);
                        myCommand.Parameters.AddWithValue("@StickerAmountPerDoor_Windo", StickerAmountPerDoor_Windo);
                        myCommand.Parameters.AddWithValue("@StickerAmountPerDoor_Tris", StickerAmountPerDoor_Tris);
                        myCommand.Parameters.AddWithValue("@PaperAmountPerDoor_Frame", PaperAmountPerDoor_Frame);
                        myCommand.Parameters.AddWithValue("@PaperAmountPerDoor_F", PaperAmountPerDoor_F);
                        myCommand.Parameters.AddWithValue("@PaperAmountPerDoor_A", PaperAmountPerDoor_A);
                        myCommand.Parameters.AddWithValue("@PaperAmountPerDoor_Alpha", PaperAmountPerDoor_Alpha);
                        myCommand.Parameters.AddWithValue("@PaperAmountPerDoor_Windo", PaperAmountPerDoor_Windo);
                        myCommand.Parameters.AddWithValue("@PaperAmountPerDoor_Tris", PaperAmountPerDoor_Tris);




                        myConnection.Open();

                        rowsAffected = myCommand.ExecuteNonQuery();
                    }

            
          
             

            }
        
            }
            catch(Exception ex)
            {
                rowsAffected = 0;
                SetEventLogMsg(ex.Message, "CLS_clsDataAccessSettings__FUNCTION_NAME_Update", EventLogEntryType.Error);

            }
            return (rowsAffected > 0);


        }



        public static bool GetByID(ref byte StickerAmountPerDoor_Frame, ref byte StickerAmountPerDoor_F, ref byte StickerAmountPerDoor_A, ref byte StickerAmountPerDoor_Alpha,
           ref byte StickerAmountPerDoor_Windo, ref byte StickerAmountPerDoor_Tris, ref byte PaperAmountPerDoor_Frame, ref byte PaperAmountPerDoor_F, ref byte PaperAmountPerDoor_A,
          ref byte PaperAmountPerDoor_Alpha, ref byte PaperAmountPerDoor_Windo, ref byte PaperAmountPerDoor_Tris)
        {

            bool isFound = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionString()))
            {

               

                string myQuery = "SELECT * FROM Settings WHERE ID=@id";

                    using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@id", 1);



                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {

                            if (myReader.Read())
                            {

                      
                                StickerAmountPerDoor_Frame =Convert.ToByte(myReader["StickerAmountPerDoor_Frame"]);
                                StickerAmountPerDoor_F = Convert.ToByte(myReader["StickerAmountPerDoor_F"]);
                                StickerAmountPerDoor_A = Convert.ToByte(myReader["StickerAmountPerDoor_A"]);
                                StickerAmountPerDoor_Alpha = Convert.ToByte(myReader["StickerAmountPerDoor_Alpha"]);
                                StickerAmountPerDoor_Windo = Convert.ToByte(myReader["StickerAmountPerDoor_Windo"]);
                                StickerAmountPerDoor_Tris = Convert.ToByte(myReader["StickerAmountPerDoor_Tris"]);
                                PaperAmountPerDoor_Frame = Convert.ToByte(myReader["PaperAmountPerDoor_Frame"]);
                                PaperAmountPerDoor_F = Convert.ToByte(myReader["PaperAmountPerDoor_F"]);
                                PaperAmountPerDoor_A = Convert.ToByte(myReader["PaperAmountPerDoor_A"]);
                                PaperAmountPerDoor_Alpha = Convert.ToByte(myReader["PaperAmountPerDoor_Alpha"]);
                                PaperAmountPerDoor_Windo = Convert.ToByte(myReader["PaperAmountPerDoor_Windo"]);
                                PaperAmountPerDoor_Tris = Convert.ToByte(myReader["PaperAmountPerDoor_Tris"]);



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
                SetEventLogMsg(ex.Message, "CLS_clsDataAccessSettings__FUNCTION_NAME_GetByID", EventLogEntryType.Error);

                isFound = false;
            }
           

            return isFound;





        }

        public static void SetEventLogMsg(string meesag,string FUNCTION_NAME, EventLogEntryType type)
        {
            try
            {
                if (!EventLog.SourceExists("SharabanyDoors"))
                {
                    EventLog.CreateEventSource("SharabanyDoors", "Application");

                }

                EventLog eventLog = new EventLog();

                eventLog.Source = "SharabanyDoors";
                EventLog.WriteEntry("SharabanyDoors", FUNCTION_NAME + "\n\n" + meesag + "\n\nVersion : " + Assembly.GetExecutingAssembly().GetName().Version, type);
            }
            catch
            {

            }
        }

    }
}
