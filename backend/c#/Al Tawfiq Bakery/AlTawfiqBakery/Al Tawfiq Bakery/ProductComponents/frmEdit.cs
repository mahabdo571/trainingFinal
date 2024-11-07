using Al_Tawfiq_Bakery.Genral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPLO;

namespace Al_Tawfiq_Bakery.ProductComponents
{
    public partial class frmEdit : Form
    {
        int _productComponentsID = -1;
        clsProductComponents _clsPC;
        public frmEdit(int productComponentsID)
        {
            InitializeComponent();
            _productComponentsID = productComponentsID;
            clsProductComponents._eventHandler_Find += getData;
            
            
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            if(_clsPC != null)
            {
         
                _clsPC.ComponentName = txtComponentName.Text;
                _clsPC.Quantity = clsValidation.StringToDecimal(txtQuantity.Text);
               // _clsPC.Unit = cbUnit.SelectedIndex.ToString();
                
              await  _clsPC.Save();
            }

            Close();


        }

        private async void frmEdit_Load(object sender, EventArgs e)
        {
            await clsProductComponents.Find(_productComponentsID);
        }

        public void getData(clsProductComponents e)
        {
          
            if(e != null)
            {

                _clsPC = e;
                txtComponentName.Text = e.ComponentName;
                txtQuantity.Text = e.Quantity.ToString() ;
                //cbUnit.SelectedIndex =clsValidation.StringToInt( e.Unit);
            }
        }
    }
}
