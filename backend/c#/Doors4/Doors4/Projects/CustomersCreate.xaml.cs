using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using SharaLogic;
using System.Text.RegularExpressions;
using Doors4;
using System.Threading;

namespace Door3
{
    /// <summary>
    /// Interaction logic for CustomersCreate.xaml
    /// </summary>
    public partial class CustomersCreate : Window
    {


        enum _myMode { addNew = 0, update = 1 }

        _myMode _mode;

        int _ID = -1;


        clsCustomers _customer;


        public CustomersCreate(int id)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            _ID = id;

            if (_ID == -1)
            {
                _mode = _myMode.addNew;

            }
            else
            {
                _mode = _myMode.update;

            }


        }
        private void _LoadData()
        {

            if (_mode == _myMode.addNew)
            {

                this.Title = FindResource("langAddNewCoustomerTitle").ToString();
                lbltitle.Content = FindResource("langAddNewCoustomerTitle").ToString();
                _customer = new clsCustomers();



                return;
            }


            _customer = clsCustomers.Find(this._ID);

            if (_customer == null)
            {
                MessageBox.Show(FindResource("lang_MissingData").ToString());
                this.Close();

                return;
            }
            this.Title = FindResource("langUpdateCoustomerTitle").ToString() + _customer.FullName;
            lbltitle.Content = FindResource("langUpdateCoustomerTitle").ToString() + _customer.FullName;
            _FillDataBeforeUpdate();



        }
        private void _FillDataBeforeUpdate()
        {

            txtName.Text = _customer.CompanyName;
            txtAccountantNumber.Text = _customer.AccountantNumber.ToString();
            txtCoustomerNumber.Text = _customer.CompanyNumber.ToString();
            txtPersonalName.Text = _customer.FullName;
            txtPhone.Text = _customer.PhoneNumbe;


        }
        private bool _InsertCustomer()
        {


          

                _customer.CompanyName = txtName.Text;
                _customer.AccountantNumber = int.TryParse(txtAccountantNumber.Text, out int res) ? res : -1;
                _customer.CompanyNumber = int.TryParse(txtCoustomerNumber.Text, out int ress) ? ress : -1;
                _customer.FullName = txtPersonalName.Text;
                _customer.PhoneNumbe = txtPhone.Text;



                return _customer.Save();
           


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (_InsertCustomer())
            {
                if (_mode == _myMode.addNew)
                    MessageBox.Show(FindResource("langAddNewsuccessfully").ToString());
                else
                    MessageBox.Show(FindResource("langUpdated").ToString());


            }
            else
            {
                MessageBox.Show(FindResource("langErorrInsertData").ToString());


            }

            _mode = _myMode.update;
            this.Title = FindResource("langUpdateCoustomerTitle").ToString() + _customer.FullName;
            lbltitle.Content = FindResource("langUpdateCoustomerTitle").ToString() + _customer.FullName;
           this. Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

     

        private void txtPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Handled)
            {
               
                if(((TextBox)sender).Name == "txtCoustomerNumber")
                {
                    popCoustomerNumber.IsOpen = true;
                }
                else if(((TextBox)sender).Name == "txtAccountantNumber")
                {
                    popAcc.IsOpen = true;
                }
             


              
            }
            else
            {
                if (((TextBox)sender).Name == "txtCoustomerNumber")
                {
                    popCoustomerNumber.IsOpen = false;
                }
                else if (((TextBox)sender).Name == "txtAccountantNumber")
                {
                    popAcc.IsOpen = false;
                }
              
            }
        }
    }
}
