using Doors4.Projects;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
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

namespace Doors4.Report
{
    /// <summary>
    /// Interaction logic for WpfPrintView.xaml
    /// </summary>
    public partial class WpfPrintView : Window
    {
        clsParameterForPrint _Pprint;
    
        

        public WpfPrintView(clsParameterForPrint P)
        {
            InitializeComponent();
         
                _Pprint = P;
            
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_Pprint != null)
            {


                crvPrint.ViewerCore.Zoom(78);
                crvPrint.ViewerCore.ReportSource = new clsSetParameterToReport(_Pprint).returnReport();
               
                
                crvPrint_Stik.ViewerCore.ReportSource = new clsSetParameterToStikarsReport(_Pprint).returnReport();
            
            
            }
        }

    }
}
