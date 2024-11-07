using Doors4.clsGenral;
using SharaLogic;
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

namespace Doors4.Projects
{
    /// <summary>
    /// Interaction logic for DFEditValue.xaml
    /// </summary>
    public partial class DFEditValue : Window
    {
        int _ID;
        clsFrameDefault _DF;
        public DFEditValue(int ID)
        {
            InitializeComponent();
            _ID = ID;
            _DF = clsFrameDefault.Find(_ID);
            if(_DF == null)
            {
                MessageBox.Show("Error");
                return;
            }
        }

  
        

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            _DF.Name = txtName.Text;
            _DF.Dec = txtDec.Text;
            _DF.A1 = clsValidationData.TextToDecimal(txtA1.Text);
            _DF.A2 = clsValidationData.TextToDecimal(txtA2.Text);
            _DF.B1 = clsValidationData.TextToDecimal(txtB1.Text);
            _DF.B2= clsValidationData.TextToDecimal(txtB2.Text);
            _DF.C1= clsValidationData.TextToDecimal(txtC1.Text);
            _DF.C2= clsValidationData.TextToDecimal(txtC2.Text);
            _DF.D2= clsValidationData.TextToDecimal(txtD2.Text);
            _DF.D1= clsValidationData.TextToDecimal(txtD1.Text);
            _DF.E1= clsValidationData.TextToDecimal(txtE1.Text);
            _DF.E2= clsValidationData.TextToDecimal(txtE2.Text);
            _DF.F2= clsValidationData.TextToDecimal(txtF2.Text);
            _DF.F1= clsValidationData.TextToDecimal(txtF1.Text);
            _DF.G1= clsValidationData.TextToDecimal(txtG1.Text);
            _DF.G2= clsValidationData.TextToDecimal(txtG2.Text);
            _DF.K125= clsValidationData.TextToDecimal(txtK125.Text);
            _DF.K15= clsValidationData.TextToDecimal(txtK15.Text);
            _DF.K2= clsValidationData.TextToDecimal(txtK2.Text);
            _DF.Bends= clsValidationData.TextToDecimal(txtBends.Text);
            _DF.F2A= clsValidationData.TextToDecimal(txtF2A.Text);
            _DF.F2B= clsValidationData.TextToDecimal(txtF2B.Text);
            _DF.F1B= clsValidationData.TextToDecimal(txtF1B.Text);
            _DF.F1A= clsValidationData.TextToDecimal(txtF1A.Text);
            _DF.MG= clsValidationData.TextToDecimal(txtMG.Text);


            if (_DF.Save())
            {
                Close();
            }
            else
            {
                MessageBox.Show("Error");
                Close();
            }
           
        }

        void FillData()
        {
            if (_DF != null)
            {
                txtName.Text = _DF.Name;
                txtDec.Text = _DF.Dec;

                txtA1.Text = _DF.A1.ToString();
                txtA2.Text = _DF.A2.ToString();
                txtB1.Text = _DF.B1.ToString();
                txtB2.Text = _DF.B2.ToString();
                txtC2.Text = _DF.C2.ToString();
                txtC1.Text = _DF.C1.ToString();
                txtD1.Text = _DF.D1.ToString();
                txtD2.Text = _DF.D2.ToString();
                txtE2.Text = _DF.E2.ToString();
                txtE1.Text = _DF.E1.ToString();
                txtF1.Text = _DF.F1.ToString();
                txtF2.Text = _DF.F2.ToString();
                txtG2.Text = _DF.G2.ToString();
                txtG1.Text = _DF.G1.ToString();
                txtF1A.Text = _DF.F1A.ToString();
                txtF1B.Text = _DF.F1B.ToString();
                txtF2B.Text = _DF.F2B.ToString();
                txtF2A.Text = _DF.F2A.ToString();
                txtBends.Text = _DF.Bends.ToString();
                txtMG.Text = _DF.MG.ToString();
                txtK125.Text = _DF.K125.ToString();
                txtK15.Text = _DF.K15.ToString();
                txtK2.Text = _DF.K2.ToString();
          
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillData();
        }
    }
}
