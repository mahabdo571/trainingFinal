using Doors4;
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

namespace Door3
{
    /// <summary>
    /// Interaction logic for MainCustomers.xaml
    /// </summary>
    public partial class MainCustomers : Window
    {


   

        public MainCustomers()
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
       
        }


        private  void OpenCustomersCreate(object sender, RoutedEventArgs e)
        {
           new CustomersCreate(-1).ShowDialog();
         
            _loadData( clsCustomers.GetAllOrderByLastUpdet());
        }

        void _loadData(DataTable dt)
        {

          
        
            if (dt == null)
            {
                dgvCoustomers.ItemsSource = null;
            }
            else
            {
                //dt.Columns["ID"].SetOrdinal(0);
                //dt.Columns["FullName"].SetOrdinal(4);
                //dt.Columns["PhoneNumbe"].SetOrdinal(3);
                //dt.Columns["CompanyName"].SetOrdinal(1);
                //dt.Columns["CompanyNumber"].SetOrdinal(5);
                //dt.Columns["AccountantNumber"].SetOrdinal(6);

                dgvCoustomers.ItemsSource = dt.DefaultView;
               
                if (dgvCoustomers.Items.Count > 0)
                {
                    dgvCoustomers.Columns[0].Header = FindResource("langdgvID");
                    dgvCoustomers.Columns[0].Width = 100;  
                    dgvCoustomers.Columns[1].Header = FindResource("langCustomerName");
                    dgvCoustomers.Columns[1].Width = 300;

                    dgvCoustomers.Columns[3].Header = FindResource("langtxtPhone");
                    dgvCoustomers.Columns[3].Width = 300;

                    dgvCoustomers.Columns[4].Header = FindResource("langtxtPersonalName");
                    dgvCoustomers.Columns[4].Width = 300;

                    dgvCoustomers.Columns[5].Header = FindResource("langtxtCoustomerNumber");
                    dgvCoustomers.Columns[5].Width = 300;
                    
                    dgvCoustomers.Columns[6].Header = FindResource("langtxtAccountantNumber");
                    dgvCoustomers.Columns[6].Width = 300;

                    dgvCoustomers.Columns[2].Visibility = Visibility.Hidden;
                    dgvCoustomers.Columns[7].Visibility = Visibility.Hidden;
                    dgvCoustomers.Columns[8].Visibility = Visibility.Hidden;
                

                }
            }
         

        }


        private  void  wpfCoustomers_Loaded(object sender, RoutedEventArgs e)
        {
            _loadData(  clsCustomers.GetAllOrderByLastUpdet());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            new MainTapi().Show();

            this.Close();
     
        }
    
        private void MenuItem_Click_OpenProject(object sender, RoutedEventArgs e)
        {

            new MainProjects((int)((DataRowView)dgvCoustomers.SelectedItem).Row.ItemArray[0]).Show();
            this .Close();
        
       
        
        }

    

        private void DataGridCell_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            new MainProjects((int)((DataRowView)dgvCoustomers.SelectedItem).Row.ItemArray[0]).Show();
            this.Close();

        }

        private  void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {


            //if (txtSearch.Text.All(char.IsDigit) || txtSearch.Text !="" &&  int.TryParse(txtSearch.Text, out _))
            //{

            if (clsCustomers.Search(txtSearch.Text) == null)
            {
                _loadData(null);
                lblNoResult.Visibility = Visibility.Visible;
             
                return;
            }
            else {
                lblNoResult.Visibility = Visibility.Hidden;
                _loadData(clsCustomers.Search(txtSearch.Text));


        }

            //}

  
            if(txtSearch.Text == "")
            {
                lblNoResult.Visibility = Visibility.Hidden;
                _loadData( clsCustomers.GetAllOrderByLastUpdet());
            }

        }

        private  void MenuItem_Click_EditCustomer(object sender, RoutedEventArgs e)
        {
       
            new CustomersCreate((int)((DataRowView)dgvCoustomers.SelectedItem).Row.ItemArray[0]).ShowDialog();
        
            _loadData( clsCustomers.GetAllOrderByLastUpdet());


        }

        private void MenuItem_Click_DeleteCustomer(object sender, RoutedEventArgs e)
        {

            if(MessageBox.Show("After deletion many things will be deleted include\r\nClient\r\nClient's projects\r\norders\r\nAll its own Frame\r\nAnd all the doors .", "are you sure ?", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning)==MessageBoxResult.Yes)
            {
                if(MessageBox.Show("are you sure ?", "Woring", MessageBoxButton.OKCancel, MessageBoxImage.Hand) == MessageBoxResult.OK)
                {

                    MessageBox.Show(((DataRowView)dgvCoustomers.SelectedItem).Row.ItemArray[0].ToString());

                }
            }


        }

        private  void MenuItem_Click_Refresh(object sender, RoutedEventArgs e)
        {
            _loadData( clsCustomers.GetAllOrderByLastUpdet());
        }

        private void btnhome_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();

        }

        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

     
    }
}
