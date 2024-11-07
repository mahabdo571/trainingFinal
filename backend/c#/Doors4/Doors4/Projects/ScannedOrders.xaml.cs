using Doors4.clsGenral;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using WIA;

namespace Doors4.Projects
{
    /// <summary>
    /// Interaction logic for ScannedOrders.xaml
    /// </summary>
    public partial class ScannedOrders : Window
    {
       
        public enum Mode { Coustomer=1,Project=2,Order=3}
        public List<MyItem> _ItemsImg { get; private set; }

        static string _DocumentsPath = clsSettings.GetData().DocumentsPath;

        clsOrders _order;
        clsProjects _project;
        clsCustomers _Customer;
        string genreterPathOrder;
        string DefultImage;
        string TempImage;
        Mode _mode;
        MyItem item;
        DirectoryInfo place;
        int _IDe;
        string[] ImageFileFormats = {
                ".jpg", ".JPG", ".BMP",".bmp" , ".PNG", ".png" , ".GIF",".gif", ".WEBP",".webp", ".TIFF",".tiff", ".PSD",".psd",".raw",".RAW",
                ".HEIF",".heif",".INDD",".indd",".JPEG",".jpeg"
                };
        public ScannedOrders(int ID, Mode mode)
        {
            InitializeComponent();
            DataContext = this;
            _IDe = ID;
        
            _mode = mode;
        //  \\DC01

            if(string.IsNullOrEmpty(_DocumentsPath))
            {
                MessageBox.Show("Documents Path Not Found : Fix This From Settings");
                return;
                
            }

            DefultImage = $@"{_DocumentsPath}\Defult.jpg";
            TempImage = $@"{_DocumentsPath}\Temp.jpg";
   
         
            selectMode();
            if (string.IsNullOrEmpty(genreterPathOrder))
            {
                MessageBox.Show("Erorr uri");
                return;
            }
            fillimage();

        }

        void selectMode()
        {

            switch (_mode)
            {
                case Mode.Order:
                    _order = clsOrders.Find(_IDe);
                    if (_order == null)
                    {
                        return;
                    }
                    genreterPathOrder = $@"{_DocumentsPath}\Costumers_{clsProjects.Find(_order.ProjectID).iDcustomer}_{ReplaceInvalidChars(clsCustomers.Find(clsProjects.Find(_order.ProjectID).iDcustomer).CompanyName)}_{clsCustomers.Find(clsProjects.Find(_order.ProjectID).iDcustomer).CompanyNumber}\Projects_{_order.ProjectID}_{ReplaceInvalidChars(clsProjects.Find(_order.ProjectID).projectName)}_{clsProjects.Find(_order.ProjectID).projectNumber}\Orders\{_order.OrderNumber}\";
                    break;  
                case Mode.Project:
                    _project = clsProjects.Find(_IDe);
                    if (_project == null)
                    {
                        return;
                    }
                    genreterPathOrder = $@"{_DocumentsPath}\Costumers_{_project.iDcustomer}_{ReplaceInvalidChars(clsCustomers.Find(_project.iDcustomer).CompanyName)}_{clsCustomers.Find(_project.iDcustomer).CompanyNumber}\Projects_{_IDe}_{ReplaceInvalidChars(_project.projectName)}_{_project.projectNumber}\Project\";

                    break; 
                case Mode.Coustomer:
                    _Customer = clsCustomers.Find(_IDe);
                    if (_Customer == null)
                    {
                        return;
                    }
                    genreterPathOrder = $@"{_DocumentsPath}\Costumers_{_IDe}_{ReplaceInvalidChars(_Customer.CompanyName)}_{_Customer.CompanyNumber}\Coustomr\";
                    break;
                default:
                    genreterPathOrder = "";
                    break;

            }
        }
        public  string ReplaceInvalidChars(string filename)
        {
            return string.Join(" ", filename.Split(Path.GetInvalidFileNameChars()));
        }
        void fillimage()
        {
            _ItemsImg = new List<MyItem>();
            if (!clsUtil.CreateFolderIfDoesNotExist(genreterPathOrder))
            {
                return;

            }

            place = null;
            place = new DirectoryInfo(genreterPathOrder);
            FileInfo[] Files;
            try
            {

                place.Refresh();
                Files = place.GetFiles();
                foreach (FileInfo i in Files)
                {
                    if (ImageFileFormats.Contains(i.Extension))
                    {


                        _ItemsImg.Add(new MyItem { Text = Path.GetFileNameWithoutExtension(i.Name), ImageSource = BitmapFromUri(i.FullName), pathuri = i.FullName });

                    }
                    else
                    {
                        _ItemsImg.Add(new MyItem { Text = Path.GetFileNameWithoutExtension(i.Name), ImageSource = BitmapFromUri(DefultImage), pathuri = i.FullName });
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;

            }

            this.TvBox.ItemsSource = _ItemsImg;
        }
        public BitmapImage BitmapFromUri(string source)
        {
            //bitmapsurs = new BitmapImage();


            //bitmapsurs.BeginInit();
            //bitmapsurs.UriSource = source;
            //bitmapsurs.CacheOption = BitmapCacheOption.OnLoad;




            //bitmapsurs.EndInit();

            BitmapImage bitmap = new BitmapImage();

            using (var stream = new FileStream(source, FileMode.Open))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
            }

            bitmap.Freeze();


            return bitmap;
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        bool checkDivice()
        {
            DeviceManager deviceManager;
            DeviceInfos devices;

            deviceManager = new DeviceManager();
            devices = deviceManager.DeviceInfos;

            for (int i = 1; i <= devices.Count; i++)
            {
                DeviceInfo device;

                device = devices[i];

                if (device.Type == WiaDeviceType.ScannerDeviceType)
                {
                    return true;
                }
            }

            return false;
        }

        private void btnScan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!checkDivice())
                {
                    MessageBox.Show("No scaner");
                    return;
                }

                var dlg = new WIA.CommonDialog();
                if(dlg == null)
                {
                    return;
                }
                ImageFile image = dlg.ShowAcquireImage(
                    DeviceType: WiaDeviceType.ScannerDeviceType,
                    Intent: WiaImageIntent.ColorIntent,
                    Bias: WiaImageBias.MinimizeSize,
                    FormatID: "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}",//jpg code
                    AlwaysSelectDevice: false,
                    UseCommonUI: true,
                    CancelError: true);

                if (image != null)
                {



                    //   var path = $@"\\DC01\documents\ScanProjNew\Costumers\Temp.jpg";
                    var path = TempImage; // $@"C:\DC01\documents\ScanProjNew\Costumers\Temp.jpg";

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    image.SaveFile(path);

                    string SourceImageFile = path;
                   if(int.TryParse(Registry.GetValue(@"HKEY_CURRENT_USER\Software\SharabanyDoorOrder", "ScanRotate", null) as string,out int angilres))
                    {
                        clsUtil.rotateImage(SourceImageFile, angilres);
                    }
                    else
                    {
                        clsUtil.rotateImage(SourceImageFile, 180);
                    }
                    
                   
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile, genreterPathOrder,true))
                    {
                        _ItemsImg.Add(new MyItem { Text = Path.GetFileName(SourceImageFile), ImageSource = BitmapFromUri(SourceImageFile), pathuri = SourceImageFile });

                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error");

                    }
                }

            }
            catch (IOException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.TvBox.ItemsSource = _ItemsImg;
                TvBox.Items.Refresh();
            }




        }

        private void btnAddFile_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
                if (openFileDialog1 == null)
                {
                    return;
                }
                if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
       
                FileInfo infofilev = new FileInfo(openFileDialog1.FileName);

         




                    try
                    {

                        if (ImageFileFormats.Contains(infofilev.Extension))
                        {

                            //then we copy the new image to the image folder after we rename it
                            string SourceImageFile = openFileDialog1.FileName.ToString();

                            if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile, genreterPathOrder, false))
                            {

                                _ItemsImg.Add(new MyItem { Text = Path.GetFileName(SourceImageFile), ImageSource = BitmapFromUri(SourceImageFile), pathuri = SourceImageFile });

                            }
                            else
                            {
                                MessageBox.Show("Error Copying Image File", "Error");

                            }


                        }
                        else
                        {
                            string SourceImageFile = openFileDialog1.FileName.ToString();
                            if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile, genreterPathOrder, false))
                            {
                                _ItemsImg.Add(new MyItem { Text = Path.GetFileName(SourceImageFile), ImageSource = BitmapFromUri(DefultImage), pathuri = SourceImageFile });

                            }
                            else
                            {
                                MessageBox.Show("Error Copying Image File", "Error");

                            }

                        }










                    }
                    catch (IOException ex )
                    {

                    }

                

            }
            catch (IOException ex)
            {

            }

            this.TvBox.ItemsSource = _ItemsImg;
            TvBox.Items.Refresh();

        }





        private void btnRemoveImage(object sender, RoutedEventArgs e)
        {
            item = TvBox.SelectedItem as MyItem;
            if (item == null)
            {
                return;
            }


            try
            {
                File.Delete(item.pathuri);
                _ItemsImg.Remove(item);
                TvBox.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btnopenImagewindo(object sender, RoutedEventArgs e)
        {
            item = TvBox.SelectedItem as MyItem;
            if (item == null)
            {
                return;
            }
            try
            {
                Process.Start(item.pathuri);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRotetImage(object sender, RoutedEventArgs e)
        {
            item = TvBox.SelectedItem as MyItem;
            if (item == null)
            {
                return;
            }
            try
            {

                clsUtil.rotateImage(item.pathuri, 90);



                _ItemsImg.Remove(item);
                _ItemsImg.Clear();
                _ItemsImg = null;


                TvBox.ItemsSource = null;
                TvBox.Items.Clear();






                fillimage();


                place.Refresh();
                TvBox.Items.Refresh();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRefreshImage(object sender, RoutedEventArgs e)
        {
            item = TvBox.SelectedItem as MyItem;
            if (item == null)
            {
                return;
            }
            try
            {
                _ItemsImg.Clear();
                _ItemsImg = null;


                TvBox.ItemsSource = null;
                TvBox.Items.Clear();




                fillimage();
                place.Refresh();
                TvBox.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void fucheckIfDelete(object sender, bool statu)
        {
            if (statu)
            {
                _ItemsImg.Remove(item);
            }
        }
        public class MyItem
        {
            public string Text { get; set; }
            public ImageSource ImageSource { get; set; }
            public string pathuri { get; set; }
            public string ImageSourceRotet { get; set; }
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item2 = sender as ListViewItem;
            if (item2 != null && item2.IsSelected)
            {
                if (TvBox.SelectedItem == null)
                {
                    return;
                }

                item = TvBox.SelectedItem as MyItem;


                ShowImageOrderScaned dele = new ShowImageOrderScaned(item.ImageSource, item.pathuri);
                dele._checkifdelete += fucheckIfDelete;
                dele.ShowDialog();



                TvBox.Items.Refresh();
            }


        }



    }
}
