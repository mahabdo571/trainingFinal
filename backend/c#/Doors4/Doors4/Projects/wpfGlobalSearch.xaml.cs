using Door3;
using Doors4.clsGenral;
using Doors4.Projects;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Doors4
{
    /// <summary>
    /// Interaction logic for wpfGlobalSearch.xaml
    /// </summary>
    public partial class wpfGlobalSearch : Window
    {
        //   List<string> fileNames = new List<string>();

        DataTable dt;
        clsGlobalSearch Gsearch;
        public  wpfGlobalSearch()
        {
            InitializeComponent();
          
         

            txtSearchbox.Focus();

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();


        }



        private void DataGridCell_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
         //   new MainProjects((int)((DataRowView)dgvCoustomers.SelectedItem).Row.ItemArray[0]).Show();
            //this.Close();
        }

  

     
        
        
        
        
        
        
        
        
        public void SearchFolder(string folderName)
        {
    
         

            //string path = @"C:\DC01\documents\ScanProjNew\Costumers\";
            //DirectoryInfo Dictiontory = new DirectoryInfo(path);
            //DirectoryInfo[] Dir = Dictiontory.GetDirectories("*", SearchOption.AllDirectories);// this get all subfolder //name in folder NetOffice.
            //var matchingDirs = Dir.Where(info => Regex.Match(info.Name, folderName, RegexOptions.Compiled).Success);

            //if (Dir.Length <= 0 )
            //{
            //    fileNames.Clear();
                
            //    lvResultSearch.Items.Refresh();
          
            //}
            //else
            //{
            //    foreach (var file in matchingDirs)
            //    {
                
            //        fileNames.Add(file.Name);
            //    }
         
            //    lvResultSearch.ItemsSource = fileNames;
            //}


           
           
        }

  
        private async void txtSearchbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchbox.Text))
            {
                dt = null;
                projload.Visibility = Visibility.Hidden;
                return;
            }

      
            projload.Visibility = Visibility.Visible;
            //   dt = await  clsGlobalSearch.GetAll();
            dt = null;
            if (txtSearchbox.Text.Length > 2)
            {
                dt = await clsGlobalSearch.SearchByAny(txtSearchbox.Text, 1, 1);
            }



            if (dt != null)
            {
                projload.Visibility = Visibility.Hidden;
                dgvSearch.ItemsSource = dt.DefaultView;
                if (dgvSearch.Items.Count > 0)
                {
                    dgvSearch.Columns[2].Header = FindResource("langCustomerName");
                    dgvSearch.Columns[2].Width = 300;


                    dgvSearch.Columns[3].Visibility = Visibility.Hidden;


                    dgvSearch.Columns[4].Visibility = Visibility.Hidden;


                    dgvSearch.Columns[5].Visibility = Visibility.Hidden;

                    dgvSearch.Columns[6].Header = FindResource("langtxtAccountantNumber");
                    dgvSearch.Columns[6].Width = 200;

                    dgvSearch.Columns[7].Header = FindResource("langtxtProjectName");
                    dgvSearch.Columns[7].Width = 300;

                    dgvSearch.Columns[8].Header = FindResource("langtxtProjectNumber");
                    dgvSearch.Columns[8].Width = 150;


                    dgvSearch.Columns[9].Visibility = Visibility.Hidden;


                    dgvSearch.Columns[10].Visibility = Visibility.Hidden;

                    dgvSearch.Columns[11].Header = FindResource("langtxtManger");
                    dgvSearch.Columns[11].Width = 150;

                    dgvSearch.Columns[12].Header = FindResource("langtxtOrderNumber");
                    dgvSearch.Columns[12].Width = 150;

                    dgvSearch.Columns[13].Visibility = Visibility.Hidden;
                    dgvSearch.Columns[0].Visibility = Visibility.Hidden;
                    dgvSearch.Columns[1].Visibility = Visibility.Hidden;


                }

            }
            else
            {
                projload.Visibility = Visibility.Hidden;
                dgvSearch.ItemsSource = null;
            }

        
            //if (dt == null)
            //{
            //    return;
            //}


            //try
            //{
            //    dt.DefaultView.RowFilter = string.Format("[{0}] like '%{6}%' or [{1}] like '%{6}%' or Convert([{2}], System.String) like '%{6}%' or Convert([{3}], System.String) like '%{6}%' or [{4}] like '%{6}%' or Convert([{5}], System.String) like '%{6}%'", "CompanyName", "ProjectName", "OrderNumber", "AccountantNumber", "Manger", "ProjectNumber", txtSearchbox.Text);
            //}
            //catch (Exception ex)
            //{
            //    clsSettings.SetEventLogMsg(ex.Message, "CLS_wpfGlobalSearch_FUN_txtSearch_TextChanged", System.Diagnostics.EventLogEntryType.Warning);
            //}


            //fileNames.Clear();

            //lvResultSearch.Items.Refresh();


            //SearchFolder(txtSearch.Text);
        }





        private void openOrders_Click(object sender, RoutedEventArgs e)
        {
            Gsearch = clsGlobalSearch.FindByIDPROJECT((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[1]);
            if(Gsearch != null)
            {
                wpfOrders ordPage = new wpfOrders((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[1]);
                ordPage.ShowDialog();
            }
        }

        private void openOrderScan_Click(object sender, RoutedEventArgs e)
        {
            Gsearch = clsGlobalSearch.FindByIDORDER((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[13]);
            if (Gsearch != null)
            {
                ScannedOrders ordPage = new ScannedOrders((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[13],ScannedOrders.Mode.Order);
                ordPage.ShowDialog();
            }
        }

        private void openProjects_Click(object sender, RoutedEventArgs e)
        {
            Gsearch = clsGlobalSearch.FindByIDCustomer((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[0]);
            if (Gsearch != null)
            {
                MainProjects ordPage = new MainProjects((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[0]);
                ordPage.ShowDialog();
            }
        }

        private void openDoorAndFrame_Click(object sender, RoutedEventArgs e)
        {
            Gsearch = clsGlobalSearch.FindByIDORDER((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[13]);
            if (Gsearch != null)
            {
                wpfOrderPage ordPage = new wpfOrderPage((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[13]);
                ordPage.ShowDialog();
            }

        }

        private void openProjectScan_Click(object sender, RoutedEventArgs e)
        {
            Gsearch = clsGlobalSearch.FindByIDPROJECT((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[1]);
            if (Gsearch != null)
            {
                ScannedOrders ordPage = new ScannedOrders((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[1], ScannedOrders.Mode.Project);
                ordPage.ShowDialog();
            }
        }

        private void opencustomerscan_Click(object sender, RoutedEventArgs e)
        {
            Gsearch = clsGlobalSearch.FindByIDCustomer((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[0]);
            if (Gsearch != null)
            {
                ScannedOrders ordPage = new ScannedOrders((int)((DataRowView)dgvSearch.SelectedItem).Row.ItemArray[0], ScannedOrders.Mode.Coustomer);
                ordPage.ShowDialog();
            }
        }

        private void txtSearchbox_GotFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void txtSearchbox_LostFocus(object sender, RoutedEventArgs e)
        {
           

        }
    }
}
