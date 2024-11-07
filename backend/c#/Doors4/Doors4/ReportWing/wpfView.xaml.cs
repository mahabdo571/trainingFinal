using Doors4.Report;
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

namespace Doors4.ReportWing
{
    /// <summary>
    /// Interaction logic for wpfView.xaml
    /// </summary>
    public partial class wpfView : Window
    {
        clsSetParameterToReportWing _parama;
        public wpfView(clsSetParameterToReportWing p)
        {
            InitializeComponent();
            _parama = p;
        }

        private void winView_Loaded(object sender, RoutedEventArgs e)
        {
       
             crvPrintWing.ViewerCore.Zoom(70);
            crvPrintWing.ViewerCore.ReportSource = new clsParameterForPrintWing(_parama).returnReport();


            crvPrintWingstikrs.ViewerCore.Zoom(70);
            crvPrintWingstikrs.ViewerCore.ReportSource = new clsSetParameterToStikarsReportWing(_parama).returnReport();


        }
    }
}
