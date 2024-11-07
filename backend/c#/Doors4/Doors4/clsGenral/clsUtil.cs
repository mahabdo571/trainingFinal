using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace Doors4.clsGenral
{
    public class clsUtil
    {


        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }
        private static string GetNextFileName(string dir, string fileName)
        {
            FileInfo fie = new FileInfo(fileName);
            FileInfo fii = new FileInfo(dir);

            Random rnd = new Random();
            int num = rnd.Next(999);



            string supdir = fii.Directory.Parent.Name;

            string name = dir + fie.Name;


            name = string.Format("Scan_{0}_{1}{2}", supdir, num, fie.Extension);

            return Path.GetFileNameWithoutExtension(name) + fie.Extension;
        }
             
        private static string GetNextFileNameadd(string dir, string fileName)
        {
            FileInfo fie = new FileInfo(fileName);
            FileInfo fii = new FileInfo(dir);

            Random rnd = new Random();
            int num = rnd.Next(999);



            string supdir = fii.Directory.Parent.Name;

            string name = dir + fie.Name;


            name = string.Format("ADD_{0}_{1}_{2}{3}", supdir , Path.GetFileNameWithoutExtension(fileName), num, fie.Extension);

            return Path.GetFileNameWithoutExtension(name) + fie.Extension;
        }



        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }

        public static string ReplaceFileNameWithGUID(string sourceFile, string Dir, bool isScaneed)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            //return GenerateGUID() + extn;
            if (isScaneed)
            {

                return GetNextFileName(Dir, fileName);
            }
            else
            {



                return GetNextFileNameadd(Dir, fileName);
            }


        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile, string DestinationFolder, bool isScan)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.


            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile, DestinationFolder, isScan);
            try
            {

                File.Copy(sourceFile, destinationFile, false);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

        public static void rotateImage(string filename, int angle)
        {
            WIA.ImageFile img = new WIA.ImageFile();
            img.LoadFile(filename);

            WIA.ImageProcess IP = new WIA.ImageProcess();

            Object ix1 = (Object)"RotateFlip";
            WIA.FilterInfo fi1 = IP.FilterInfos.get_Item(ref ix1);
            IP.Filters.Add(fi1.FilterID, 0);

            Object p1 = (Object)"RotationAngle";
            Object pv1 = (Object)angle;
            IP.Filters[1].Properties.get_Item(ref p1).set_Value(ref pv1);

            img = IP.Apply(img);

            File.Delete(filename);
            img.SaveFile(filename);



            //BitmapImage imagetemp = new BitmapImage();
            //using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            //{
            //    imagetemp.BeginInit();
            //    imagetemp.CacheOption = BitmapCacheOption.OnLoad;
            //    imagetemp.StreamSource = stream;
            //    imagetemp.EndInit();
            //}




        }


        public static List<string> TypeNameFrame()
        {
            return new List<string>()
            {
                "RegularStandartF1BT",
                "RegularStandartF2BT",
                "RegularStandartF1GV",
                "RegularStandartF2GV",
                "RegularStandartAQ60BT",
                "RegularStandartAQ80BT",
                "RegularStandartAQ60GV",
                "RegularStandartAQ80GV",
                "RegularClick",
                "RegularMishtalev",
                "RegularHalbasha",
                "RegularKantTiachF1BT",
                "RegularKantTiachF2BT",
                "RegularKantTiachF1GV",
                "RegularKantTiachF2GV",
                "RegularArusi",
                "AlphaStandartF1BT",
                "AlphaStandartF2BT",
                "AlphaStandartF1GV",
                "AlphaStandartF2GV",
                "AlphaStandartAQ60BT",
                "AlphaStandartAQ80BT",
                "AlphaStandartAQ60GV",
                "AlphaStandartAQ80GV",
                "AlphaClick",
                "AlphaHalbasha",
                "AlphaKantTiachF1BT",
                "AlphaKantTiachF2BT",
                "AlphaKantTiachF1GV",
                "AlphaKantTiachF2GV",
                "PivotStandartBT",
                "PivotStandartGV",
                "PivotClick",
                "BlindStandartBT",
                "BlindStandartGV",
                "BlindHalbasha",
                "PendelStandartBT",
                "PendelStandartGV",
                "PendelKantTiachBT",
                "PendelKantTiachGV",
                "PendelClick",
                "SlidingBT",
                "SlidingGV",
                "SlidingPocketBT",
                "SlidingPocketGV"


            };
        }

   
    }
}
