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

namespace Al_Tawfiq_Bakery.PoductionProcess
{
    public partial class frmAddEdit : Form
    {
        int _PoductionProcessID = -1;
        clsPoductionProcess _clsPP;
        decimal _oldQ = -1;
        int _dele = -1;
        public frmAddEdit()
        {
            InitializeComponent();
            _PoductionProcessID = -1;
            clsProducts._getAllData += FillCb;
            Check();
        } 
        
        public frmAddEdit(int poductionProcessID,int dele)
        {
            InitializeComponent();
            _PoductionProcessID = poductionProcessID;
            _dele = dele;
            clsPoductionProcess._EV_FIND += FindFill;
            clsProducts._getAllData += FillCb;
            Check();
        }

        async void Check()
        {
            if(_PoductionProcessID == -1)
            {
                _clsPP = new clsPoductionProcess();

            }
            else
            {
                await clsPoductionProcess.Find(_PoductionProcessID);
            }
        }

        void FindFill(clsPoductionProcess e)
        {
            _clsPP = e;
            if (_clsPP != null)
            {
                txtQuantity.Text = _clsPP.Quantity.ToString();
                _oldQ = clsValidation.StringToDecimal(txtQuantity.Text);
            
            }
        }



        private async void btnSave_Click(object sender, EventArgs e)
        {
            clsmathCalculations mathcalc = new clsmathCalculations(clsValidation.StringToDecimal(txtQuantity.Text), (int)cbProducts.SelectedValue);
           await mathcalc.FindProducts();

            _clsPP.Quantity = Convert.ToDecimal(txtQuantity.Text);

      
           
            if (_PoductionProcessID == -1) {
                _clsPP.TotalCost = await mathcalc.TotalCost(-1);
                _clsPP.PoductionProcessDate = DateTime.Now;
            }
            else
            {
                _clsPP.TotalCost = await mathcalc.TotalCost(_oldQ);
            }
            _clsPP.ProductID = (int)cbProducts.SelectedValue;
            //_clsPP.CostDetailsID = -1;
            await _clsPP.Save();
           Close();

        }

        private async void frmAddEdit_Load(object sender, EventArgs e)
        {
            await clsProducts.GetAll();
           if(_dele == 77)
            {
                txtQuantity.Text = "0";
                btnSave_Click(null, null);
            }

        }

        void FillCb(string ex,DataTable dt)
        {
            cbProducts.DataSource = dt;
            cbProducts.DisplayMember = "ProductName";
            cbProducts.ValueMember = "ProductID";
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
