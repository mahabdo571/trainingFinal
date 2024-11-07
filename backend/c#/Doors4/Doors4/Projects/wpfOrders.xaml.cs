using Door3;
using Doors4.Projects;
using SharaLogic;
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

namespace Doors4
{
    /// <summary>
    /// Interaction logic for wpfOrders.xaml
    /// </summary>
    public partial class wpfOrders : Window
    {
        int IDproject;
        clsProjects _project;
 

        public wpfOrders(int idProject)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            IDproject = idProject;
            _project = clsProjects.Find(idProject);
            this.Title = FindResource("langOrdersForthe") +" "+ _project.projectName+" "+ FindResource("langProjectthat")+" "+ clsCustomers.Find(_project.iDcustomer).FullName+" "+  FindResource("langCustomer");
            lbltitle.Content = this.Title;

            if(Doors4.Properties.Settings.Default.lang == "HE" || Doors4.Properties.Settings.Default.lang == "AR")
            {
                lbltitle.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                lbltitle.FlowDirection = FlowDirection.LeftToRight;
            }

        }


        void _LoadeData(DataTable dt)
        {
            if(dt == null)
            {
                dgvOrders.ItemsSource =null;
            }
            else
            {
                dgvOrders.ItemsSource = dt.DefaultView;
                if(dgvOrders.Items.Count > 0)
                {
                    dgvOrders.Columns[0].Header = FindResource("langdgvID");
                    dgvOrders.Columns[0].Width = 100;

                    
                    dgvOrders.Columns[1].Header =FindResource("langDateOrderUpdate");
                    dgvOrders.Columns[1].Width = 300;  

                    dgvOrders.Columns[3].Header = FindResource("langtxtManger");
                    dgvOrders.Columns[3].Width = 300;

                    dgvOrders.Columns[4].Header = FindResource("langtxtOrderNumber");
                    dgvOrders.Columns[4].Width = 300;

                    dgvOrders.Columns[2].Visibility = Visibility.Hidden;



                }
            }
           

        }


        private void btnAddNewOrder_Click(object sender, RoutedEventArgs e)
        {

            new wpfAddNewOrder(-1, IDproject).ShowDialog();
            _LoadeData(clsOrders.getAllFromProject(IDproject));

        }

        private void wpfOrdersScreen_Loaded(object sender, RoutedEventArgs e)
        {
            _LoadeData(clsOrders.getAllFromProject(IDproject));
        }

        private void MenuItem_Click_OpenOrder(object sender, RoutedEventArgs e)
        {
            new wpfOrderPage((int)((DataRowView)dgvOrders.SelectedItem).Row.ItemArray[0]).Show();
            this.Close();
        }

        private void MenuItem_Click_EditOrder(object sender, RoutedEventArgs e)
        {

            new wpfAddNewOrder((int)((DataRowView)dgvOrders.SelectedItem).Row.ItemArray[0], IDproject) .ShowDialog();
            _LoadeData(clsOrders.getAllFromProject(IDproject));
        }

        private void MenuItem_Click_Deleteorder(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_orderRefres(object sender, RoutedEventArgs e)
        {
            _LoadeData(clsOrders.getAllFromProject(IDproject));
        }

        private void DataGridCell_MouseDoubleClick_Order(object sender, MouseButtonEventArgs e)
        {
            new wpfOrderPage((int)((DataRowView)dgvOrders.SelectedItem).Row.ItemArray[0]).Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            new MainProjects(_project.iDcustomer).Show();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
          

            if (clsOrders.Search(txtSearch.Text, IDproject) == null)
            {
                _LoadeData(null);
              

                return;
            }
            else
            {
                _LoadeData(clsOrders.Search(txtSearch.Text,IDproject));
            


            }

            //}


            if (txtSearch.Text == "")
            {

                _LoadeData(clsOrders.getAllFromProject(IDproject));
            }
        }

        private void btncustomer_Click(object sender, RoutedEventArgs e)
        {
            new MainCustomers().Show();
            Close();
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnScan_Click(object sender, RoutedEventArgs e)
        {
            ScannedOrders scan = new ScannedOrders(IDproject, ScannedOrders.Mode.Project);
            scan.ShowDialog();
        }
    }
}
