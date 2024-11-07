using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CrystalDecisions.CrystalReports.Engine;
using Doors4;
using Doors4.Projects;
using SharaLogic;

namespace Door3
{
    /// <summary>
    /// Interaction logic for MainProjects.xaml
    /// </summary>
    public partial class MainProjects : Window
    {
        int _IDcustomer;

        public MainProjects(int IdCustomer)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            _IDcustomer = IdCustomer;
            this.Title = FindResource("Listof") +" "+ clsCustomers.Find(_IDcustomer).CompanyName + " " + FindResource("projects") ;
            lbltitle.Content = this.Title;
            if (Doors4.Properties.Settings.Default.lang == "HE" || Doors4.Properties.Settings.Default.lang == "AR")
            {
                lbltitle.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                lbltitle.FlowDirection = FlowDirection.LeftToRight;

            }
        }

        void _dataLoad(DataTable dt)
        {
            if(dt == null)
            {
                dgvProjectsForCustomer.ItemsSource =null;
            }
            else
            {
                dgvProjectsForCustomer.ItemsSource = dt.DefaultView;

                if(dgvProjectsForCustomer.Items.Count > 0)
                {
                    dgvProjectsForCustomer.Columns[0].Header = FindResource("langdgvID");
                    dgvProjectsForCustomer.Columns[0].Width = 100;

                             dgvProjectsForCustomer.Columns[1].Header = FindResource("langtxtProjectName");
                    dgvProjectsForCustomer.Columns[1].Width = 300;

                             dgvProjectsForCustomer.Columns[2].Header = FindResource("langtxtProjectNumber");
                    dgvProjectsForCustomer.Columns[2].Width = 300;

                             dgvProjectsForCustomer.Columns[3].Header = FindResource("langtxtNotes");
                    dgvProjectsForCustomer.Columns[3].Width = 300;

                    
                             dgvProjectsForCustomer.Columns[4].Header = FindResource("langtxtAddress");
                    dgvProjectsForCustomer.Columns[4].Width = 300;
                    
                             dgvProjectsForCustomer.Columns[6].Header = FindResource("langtxtManger");
                    dgvProjectsForCustomer.Columns[6].Width = 300;

                     
                             dgvProjectsForCustomer.Columns[7].Header = FindResource("langtxtContactPerson");
                    dgvProjectsForCustomer.Columns[7].Width = 300;

                    
                             dgvProjectsForCustomer.Columns[8].Header = FindResource("langtxtContactPhone");
                    dgvProjectsForCustomer.Columns[8].Width = 300;

                    
                             dgvProjectsForCustomer.Columns[10].Header = FindResource("langDateProjectUpdate");
                    dgvProjectsForCustomer.Columns[10].Width = 300;



                    dgvProjectsForCustomer.Columns[5].Visibility = Visibility.Hidden;
                    dgvProjectsForCustomer.Columns[9].Visibility = Visibility.Hidden;



                }
            }
       
        }

        private void btn_Add_New_Project_Click(object sender, RoutedEventArgs e)
        {

            new wpfAddNewProject(_IDcustomer, -1).ShowDialog();
            _dataLoad(clsProjects.getWithCustomer(_IDcustomer));
        }

   

        private void wpfProjectsScreen_Loaded(object sender, RoutedEventArgs e)
        {
            _dataLoad(clsProjects.getWithCustomer(_IDcustomer));

        }

        private void DataGridCell_MouseDoubleClick_Project(object sender, MouseButtonEventArgs e)
        {
            new wpfOrders((int)((DataRowView)dgvProjectsForCustomer.SelectedItem).Row.ItemArray[0]).Show();
            this.Close();
        }

        private void MenuItem_Click_OpenOrder(object sender, RoutedEventArgs e)
        {
            new wpfOrders((int)((DataRowView)dgvProjectsForCustomer.SelectedItem).Row.ItemArray[0]).Show();
            this.Close();
        }

        private void MenuItem_Click_EditProject(object sender, RoutedEventArgs e)
        {
            new wpfAddNewProject(_IDcustomer, (int)((DataRowView)dgvProjectsForCustomer.SelectedItem).Row.ItemArray[0]).ShowDialog();
            _dataLoad(clsProjects.getWithCustomer(_IDcustomer));
        }

        private void MenuItem_Click_DeleteProject(object sender, RoutedEventArgs e)
        {

        }  
        private void MenuItem_Click_RefreshProject(object sender, RoutedEventArgs e)
        {
            _dataLoad(clsProjects.getWithCustomer(_IDcustomer));
        }

        private void txtSearchProject_TextChanged(object sender, TextChangedEventArgs e)
        {


            if (clsProjects.Search(txtSearchProject.Text, _IDcustomer) == null)
            {
                _dataLoad(null);

             //   lblNoResultPrj.Content = "No Result ";
                return;
            }
            else
            {
               // lblNoResultPrj.Content = "....";
                _dataLoad(clsProjects.Search(txtSearchProject.Text, _IDcustomer));


            }




            if (txtSearchProject.Text == "")
            {
               // lblNoResultPrj.Content = ".....";
                _dataLoad(clsProjects.getWithCustomer(_IDcustomer));
            }


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainCustomers().Show();
            this.Close();
        }

        private void btntf_Click(object sender, RoutedEventArgs e)
        {
            new MainTapi().Show();
            this.Close();
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnScan_Click(object sender, RoutedEventArgs e)
        {
            ScannedOrders scan = new ScannedOrders(_IDcustomer, ScannedOrders.Mode.Coustomer);
            scan.ShowDialog();
        }
    }
}
