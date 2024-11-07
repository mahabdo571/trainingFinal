using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Printing;
using System.Security.Policy;
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
using static Doors4.Projects.ShowImageOrderScaned;


namespace Doors4.Projects
{
    /// <summary>
    /// Interaction logic for ShowImageOrderScaned.xaml
    /// </summary>
    public partial class ShowImageOrderScaned : Window
    {

        public delegate void CheckIfDelete(object sender, bool statue);
        string Pathuri;
        public event CheckIfDelete _checkifdelete;
        ImageSource Uriimage { get; set; }
      
        public ShowImageOrderScaned(ImageSource uri,string pathuri )
        {
            InitializeComponent();
        
            Uriimage = uri;
            Pathuri = pathuri;




        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

     


            imageorder.Source = Uriimage;

            _checkifdelete?.Invoke(this, false);
        }



        private void btndeleteimge_Click(object sender, RoutedEventArgs e)
        {
           // string path = ((BitmapImage)imageorder.Source).UriSource.LocalPath;
            imageorder.Source = null;
            File.Delete(Pathuri);
            _checkifdelete?.Invoke(this, true);
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        
        }

        private void btnsaveimge_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
