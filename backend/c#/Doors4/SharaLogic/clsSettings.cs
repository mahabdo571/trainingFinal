using Microsoft.Win32;
using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsSettings
    {
        // save data current user
        static string _PathRegUSER = @"HKEY_CURRENT_USER\Software\SharabanyDoorOrder";
        static string _DocumentsPath_RegName = "DocumentsPath";
        static string _ImagePath_RegName = "ImagePath";
        static string _MainPrinterName_RegName = "MainPrinterName";
        static string _StikersPrinterName_RegName = "StikersPrinterName";




        public string DocumentsPath { get; set; }
        public string ImagePath { get; set; }
        public string MainPrinterName { get; set; }
        public string StikersPrinterName { get; set; }
        public byte StickerAmountPerDoor_Frame { get; set; }
        public byte StickerAmountPerDoor_F { get; set; }
        public byte StickerAmountPerDoor_A { get; set; }
        public byte StickerAmountPerDoor_Alpha { get; set; }
        public byte StickerAmountPerDoor_Windo { get; set; }
        public byte StickerAmountPerDoor_Tris { get; set; }
        public byte PaperAmountPerDoor_Frame { get; set; }
        public byte PaperAmountPerDoor_F { get; set; }
        public byte PaperAmountPerDoor_A { get; set; }
        public byte PaperAmountPerDoor_Alpha { get; set; }
        public byte PaperAmountPerDoor_Windo { get; set; }
        public byte PaperAmountPerDoor_Tris { get; set; }



        private clsSettings(string imagePath,string mainPrinterName,string stikersPrinterName,byte stickerAmountPerDoor_Frame, byte stickerAmountPerDoor_F, byte stickerAmountPerDoor_A, byte stickerAmountPerDoor_Alpha,
            byte stickerAmountPerDoor_Windo, byte stickerAmountPerDoor_Tris, byte paperAmountPerDoor_Frame, byte paperAmountPerDoor_F, byte paperAmountPerDoor_A,
            byte paperAmountPerDoor_Alpha, byte paperAmountPerDoor_Windo, byte paperAmountPerDoor_Tris,string __DocumentsPath)

        {

            this.DocumentsPath = __DocumentsPath;
            this.ImagePath = imagePath;
            this.MainPrinterName =mainPrinterName;
            this.StikersPrinterName = stikersPrinterName;
            this.StickerAmountPerDoor_Frame = stickerAmountPerDoor_Frame;
            this.StickerAmountPerDoor_F = stickerAmountPerDoor_F;
            this.StickerAmountPerDoor_A = stickerAmountPerDoor_A;
            this.StickerAmountPerDoor_Alpha = stickerAmountPerDoor_Alpha;
            this.StickerAmountPerDoor_Windo = stickerAmountPerDoor_Windo;
            this.StickerAmountPerDoor_Tris = stickerAmountPerDoor_Tris;
            this.PaperAmountPerDoor_Frame = paperAmountPerDoor_Frame;
            this.PaperAmountPerDoor_F = paperAmountPerDoor_F;
            this.PaperAmountPerDoor_A = paperAmountPerDoor_A;
            this.PaperAmountPerDoor_Alpha = paperAmountPerDoor_Alpha;
            this.PaperAmountPerDoor_Windo = paperAmountPerDoor_Windo;
            this.PaperAmountPerDoor_Tris = paperAmountPerDoor_Tris;
         

        }

        public static clsSettings GetData()
        {

            try
            {

                if (Registry.GetValue(_PathRegUSER, _ImagePath_RegName, null) as string != null )
                {
                    string __DocumentsPath = Registry.GetValue(_PathRegUSER, _DocumentsPath_RegName, null) as string;
                    string ImagePath = Registry.GetValue(_PathRegUSER, _ImagePath_RegName, null) as string;
                    string MainPrinterName = Registry.GetValue(_PathRegUSER, _MainPrinterName_RegName, null) as string;
                    string StikersPrinterName = Registry.GetValue(_PathRegUSER, _StikersPrinterName_RegName, null) as string;

                    byte stickerAmountPerDoor_Frame = 0;
                    byte StickerAmountPerDoor_F = 0; byte StickerAmountPerDoor_A = 0; byte StickerAmountPerDoor_Alpha = 0;
                    byte StickerAmountPerDoor_Windo = 0; byte StickerAmountPerDoor_Tris = 0; byte PaperAmountPerDoor_Frame = 0; byte PaperAmountPerDoor_F = 0; byte PaperAmountPerDoor_A = 0;
                    byte PaperAmountPerDoor_Alpha = 0; byte PaperAmountPerDoor_Windo = 0; byte PaperAmountPerDoor_Tris = 0;


                    if (clsDataAccessSettings.GetByID(ref stickerAmountPerDoor_Frame ,ref StickerAmountPerDoor_F, ref StickerAmountPerDoor_A, ref StickerAmountPerDoor_Alpha,
            ref StickerAmountPerDoor_Windo, ref StickerAmountPerDoor_Tris, ref PaperAmountPerDoor_Frame, ref PaperAmountPerDoor_F, ref PaperAmountPerDoor_A,
            ref PaperAmountPerDoor_Alpha, ref PaperAmountPerDoor_Windo, ref PaperAmountPerDoor_Tris))
                    {
                        return new clsSettings(ImagePath, MainPrinterName, StikersPrinterName,  stickerAmountPerDoor_Frame,  StickerAmountPerDoor_F,  StickerAmountPerDoor_A,  StickerAmountPerDoor_Alpha,
             StickerAmountPerDoor_Windo,  StickerAmountPerDoor_Tris,  PaperAmountPerDoor_Frame,  PaperAmountPerDoor_F,  PaperAmountPerDoor_A,
             PaperAmountPerDoor_Alpha,  PaperAmountPerDoor_Windo,  PaperAmountPerDoor_Tris, __DocumentsPath);
                    }
                    else
                    {
                        return null;

                    }




                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                SetEventLogMsg(ex.Message, "CLS_clsSettings__FUNCTION_NAME_GetData", EventLogEntryType.Error);
                return null;
            }
        }




        private bool _UpdatePhone()
        {


            return clsDataAccessSettings.Update(this.StickerAmountPerDoor_Frame,this.StickerAmountPerDoor_F,this.StickerAmountPerDoor_A,this.StickerAmountPerDoor_Alpha,
                this.StickerAmountPerDoor_Windo,this.StickerAmountPerDoor_Tris,this.PaperAmountPerDoor_Frame,this.PaperAmountPerDoor_F,this.PaperAmountPerDoor_A,
                this.PaperAmountPerDoor_Alpha,this.PaperAmountPerDoor_Windo,this.PaperAmountPerDoor_Tris
                
                );

        }


        public bool Save()

        {

            return _UpdatePhone();



        }

        public static bool CheckConnection()
        {
            return clsDataAccessSettings.CheckConnection();
        }


        public static string Encrypt(string data, string key)
        {
            return clsStringEncrypt.Encrypt(data, key);
        }

        public static string Decrypt(string data, string key)
        {
            return clsStringEncrypt.Decrypt(data, key);
        }

        public static byte CalcAmountPrintStikrsWing(int WingID,byte ManualPrint)
        {
            if (ManualPrint > 0)
            {
                return ManualPrint;
            }
            else
            {

                byte amount = 0;

                clsWings wing = clsWings.Find(WingID);

                if (wing == null) return 0;
                if (wing.WingType == null) return 0;

                clsSettings getdatasett = clsSettings.GetData();
                if (getdatasett == null) return 0;

                clsWingWindows windo = clsWingWindows.FindByWingID(WingID);


                if (wing.WingType.TEST2 == "A")
                {
                    amount = getdatasett.StickerAmountPerDoor_A;
                }
                else
                {
                    amount = getdatasett.StickerAmountPerDoor_F;

                }

                if (wing.WingType.TEST1 == "ALPH")
                {
                    amount += getdatasett.StickerAmountPerDoor_Alpha;
                }

               
                if (windo == null)
                {
                    return amount;
                }
                else
                {

                    if (windo.WindowType == "Normal")
                    {
                        amount += getdatasett.StickerAmountPerDoor_Windo;

                    }

                    if (windo.TrisType == "Wood")
                    {
                        amount += getdatasett.StickerAmountPerDoor_Tris;
                    }
                }

                return amount;
            }
        }
        public static byte CalcAmountPrintPeperWing(int WingID,byte ManualPrint)
        {
            if (ManualPrint > 0)
            {
                return ManualPrint;
            }
            else
            {

                byte amount = 0;

                clsWings wing = clsWings.Find(WingID);
                if (wing == null) return amount;
                if (wing.WingType == null) return amount;

                clsSettings getdatasett = clsSettings.GetData();
                if (getdatasett == null) return amount;

                clsWingWindows windo = clsWingWindows.FindByWingID(WingID);
            


                if (wing.WingType.TEST2 == "A")
                {
                    amount = getdatasett.PaperAmountPerDoor_A;
                }
                else
                {
                    amount = getdatasett.PaperAmountPerDoor_F;

                }

                if (wing.WingType.TEST1 == "ALPH")
                {
                    amount += getdatasett.PaperAmountPerDoor_Alpha;
                }
                if (windo == null)
                {
                    return amount;
                }
                else
                {
                    if (windo.WindowType == "Normal")
                    {
                        amount += getdatasett.PaperAmountPerDoor_Windo;

                    }

                    if (windo.TrisType == "Wood")
                    {
                        amount += getdatasett.PaperAmountPerDoor_Tris;
                    }

                }
                return amount;
            }
        }
             
        public static byte CalcAmountPrintStikrsFrame(byte manualPrint)
        {
    
           if(manualPrint > 0)
            {
                return  manualPrint;
            }
            else
            {
            
                clsSettings getdatasett = clsSettings.GetData();
                if (getdatasett == null) return 0;

                return getdatasett.StickerAmountPerDoor_Frame;

                
            }
     
        }     
        
        public static byte CalcAmountPrintPaperFrame(byte manualPrint)
        {
    
           if(manualPrint > 0)
            {
                return  manualPrint;
            }
            else
            {
            
                clsSettings getdatasett = clsSettings.GetData();
                if (getdatasett == null) return 0;

                return getdatasett.PaperAmountPerDoor_Frame;

                
            }
     
        }



        public static void SetEventLogMsg(string Message,string FUNCTION_NAME, EventLogEntryType eType)
        {
            clsDataAccessSettings.SetEventLogMsg(Message, FUNCTION_NAME,eType);
        }
    }
}
