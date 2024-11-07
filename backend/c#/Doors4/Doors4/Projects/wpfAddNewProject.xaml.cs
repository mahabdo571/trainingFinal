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
    /// Interaction logic for wpfAddNewProject.xaml
    /// </summary>
    public partial class wpfAddNewProject : Window
    {
        int _IdCustomers;
        int _IdProject;
        enum MyMode { addNew=1,update=2}

        clsProjects _Project;

        MyMode _MyMode=MyMode.addNew;

        public wpfAddNewProject(int idCustomer,int idProject)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            _IdCustomers = idCustomer;
            _IdProject = idProject;

            if (_IdProject == -1)
            {
                _MyMode = MyMode.addNew;


            }
            else
            {
                _MyMode = MyMode.update;
                _Project = clsProjects.Find(_IdProject);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            save();
            this.Close();


        }
        void _loadData()
        {
            
    
            if( _Project != null && _MyMode == MyMode.update)
            {
                txtAddress.Text = _Project.Address;
                txtNotes.Text = _Project.notes;
                txtProjectName.Text = _Project.projectName;
                txtProjectNumber.Text = _Project.projectNumber.ToString();
                txtManger.Text = _Project.Manger;
                txtContactPerson.Text = _Project.ContactPerson;
                txtContactPhone.Text = _Project.ContactPhone;
                btnSave.Content = FindResource("langSaveUpdaeted");
                this.Title = FindResource("langUpdeteProject") + " " + _Project.projectName;
                lbltitle.Content = this.Title;
            }
            else
            {
                btnSave.Content = FindResource("lang_btnSaveSetting");
                this.Title = FindResource("langAddnewProject").ToString();
                lbltitle.Content = this.Title;
            }

         





        }

        void _AddNewProject()
        {

            _Project = new clsProjects();

            _Project.projectName =txtProjectName.Text;
            _Project.projectNumber =int.TryParse(txtProjectNumber.Text,out int res) ? res:-1;
            _Project.ContactPhone =txtContactPhone.Text;
            _Project.ContactPerson = txtContactPerson.Text;
            _Project.Address = txtAddress.Text;
            _Project.notes= txtNotes.Text;
            _Project.Manger = txtManger.Text;
            _Project.DateOfCreate= DateTime.Now;
            _Project.DateOfUpdate = DateTime.Now;
            _Project.iDcustomer = _IdCustomers;

            if (_Project.Save())
            {
                MessageBox.Show(FindResource("langAddNewsuccessfully").ToString());
         
                _MyMode = MyMode.update;
                _IdProject = _Project.ID;
                _loadData();
            }
            else
            {
                MessageBox.Show(FindResource("langErorrInsertData").ToString());
            }

        }
        void _updateProject()
        {

            _Project.projectName = txtProjectName.Text;
            _Project.projectNumber = int.TryParse(txtProjectNumber.Text,out int res)?res:-1;
            _Project.ContactPhone = txtContactPhone.Text;
            _Project.ContactPerson = txtContactPerson.Text;
            _Project.Address = txtAddress.Text;
            _Project.notes = txtNotes.Text;
            _Project.Manger = txtManger.Text;

            _Project.DateOfUpdate = DateTime.Now;


            if (_Project.Save())
            {
                MessageBox.Show(FindResource("langUpdated").ToString());
                _MyMode = MyMode.update;
                _IdProject = _Project.ID;
                _loadData();
            }
            else
            {
                MessageBox.Show(FindResource("langErorrInsertData").ToString());
            }


        }

        void save()
        {
            switch(_MyMode)
            {
                case MyMode.addNew:
                    _AddNewProject();
                    return;
                    case MyMode.update:
                    _updateProject();
                    return;
            }
        }

        private void wpfAddnewProjectScreen_Loaded(object sender, RoutedEventArgs e)
        {
            _loadData();
        }

        private void txtProjectNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Handled)
            {
                poptxtProjectNumber.IsOpen = true;
           




            }
            else
            {
                poptxtProjectNumber.IsOpen = false;

            }
        }

        private void btnwxit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
