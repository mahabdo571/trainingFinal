using SharaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for wpfAddNewOrder.xaml
    /// </summary>
    public partial class wpfAddNewOrder : Window
    {

        int _IDorder;
        int _IDproject;
        enum MyMode { addnew =1,update=2};

        MyMode _MyMode = MyMode.addnew;

        clsOrders _order;

        public wpfAddNewOrder(int idOrder, int iDproject)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            _IDorder = idOrder;
            _IDproject = iDproject;
            if (_IDorder == -1)
            {
                _MyMode = MyMode.addnew;
            }
            else
            {
                _MyMode = MyMode.update;
                _order = clsOrders.Find(_IDorder);

            }

        }
       void  _loadData()
        {


            if (Doors4.Properties.Settings.Default.lang == "HE" || Doors4.Properties.Settings.Default.lang == "AR")
            {
                lbltitle.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                lbltitle.FlowDirection = FlowDirection.LeftToRight;
            }

            if (_MyMode == MyMode.addnew)
            {
                btnSave.Content = FindResource("lang_btnSaveSetting");
                this.Title = FindResource("langbtnAddNewOrder").ToString();
                lbltitle.Content = this.Title;
                txtManger.Text = clsProjects.Find(_IDproject).Manger.ToString();
            }
            else
            {
                txtManger.Text = _order.Marketer;
                txtOrderNumber.Text = _order.OrderNumber.ToString();    
                btnSave.Content = FindResource("langSaveUpdaeted")+" "+ _order.OrderNumber;
                this.Title = FindResource("langUpdeteOrder")+ " "+ _order.OrderNumber;
                lbltitle.Content = this.Title;


            }

        }
       void _addNewOrder()
        {

            _order = new clsOrders();

            _order.ProjectID = _IDproject;
            _order.Marketer = txtManger.Text;
            _order.Date = DateTime.Now;
            _order.OrderNumber = int.Parse(txtOrderNumber.Text);
            if (_order.Save())
            {
                MessageBox.Show(FindResource("langAddNewsuccessfully").ToString());
                _MyMode = MyMode.update;
               _IDorder = _order.ID ;
                _loadData();
            }


        }

        void _updateOrder()
        {
            _order.ProjectID = _IDproject;
            _order.Marketer = txtManger.Text;
            _order.Date = DateTime.Now;
            _order.OrderNumber = int.Parse(txtOrderNumber.Text);
            if (_order.Save())
            {
                MessageBox.Show(FindResource("langSaveUpdaeted").ToString());
                _MyMode = MyMode.update;
                _IDorder = _order.ID;
                _loadData();
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            switch(_MyMode)
            {
                case MyMode.addnew:
                    _addNewOrder();
                    this.Close();
                    return;
                    case MyMode.update:

                    _updateOrder();

                    this.Close();
                    return;
            }
        

        }

        private void wpfAddnewOrderScreen_Loaded(object sender, RoutedEventArgs e)
        {
            _loadData();
        }

        private void txtOrderNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Handled)
            {
                poptxtOrderNumber.IsOpen = true;





            }
            else
            {
                poptxtOrderNumber.IsOpen = false;

            }
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
