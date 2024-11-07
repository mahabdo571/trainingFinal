using Doors4.clsGenral;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Interaction logic for DefultKantWingValue.xaml
    /// </summary>
    public partial class DefultKantWingValue : Window
    {

        int _ID;
        clsKantWingDefault _KWD;

        public DefultKantWingValue(int ID)
        {
            InitializeComponent();

            _ID = ID;
           

            _KWD = clsKantWingDefault.Find(_ID);

            if(_KWD == null)
            {
                MessageBox.Show("Error");
               
      
                return;
            }

            _FillData();
        }

        void _FillData()
        {
            if (_KWD != null)
            {
                txtName.Text = _KWD.Name;
                txtDec.Text = _KWD.Description;
                txtKantA.Text = _KWD.KantA.ToString();
                txtKantB.Text = _KWD.KantB.ToString();
                txtKantC.Text = _KWD.KantC.ToString();
                txtKantD.Text = _KWD.KantD.ToString();
                txtKantE.Text = _KWD.KantE.ToString();
                txtKantF.Text = _KWD.KantF.ToString();
                txtKantG.Text = _KWD.KantG.ToString();
                txtKantH.Text = _KWD.KantH.ToString();
                txtKantI.Text = _KWD.KantI.ToString();
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        { 
            
            
            if (_KWD != null)
            {


                _KWD.Name = txtName.Text;
                _KWD.Description = txtDec.Text;
                _KWD.KantA = clsValidationData.TextToInt(txtKantA.Text);
                _KWD.KantB = clsValidationData.TextToInt(txtKantB.Text);
                _KWD.KantC = clsValidationData.TextToInt(txtKantC.Text);
                _KWD.KantD = clsValidationData.TextToInt(txtKantD.Text);
                _KWD.KantE = clsValidationData.TextToInt(txtKantE.Text);
                _KWD.KantF = clsValidationData.TextToInt(txtKantF.Text);
                _KWD.KantG = clsValidationData.TextToInt(txtKantG.Text);
                _KWD.KantH = clsValidationData.TextToInt(txtKantH.Text);
                _KWD.KantI = clsValidationData.TextToInt(txtKantI.Text);

                if (await _KWD.SaveAsync())
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Error");
                    Close();
                }
            
            
            
            }


        }
    }
}
