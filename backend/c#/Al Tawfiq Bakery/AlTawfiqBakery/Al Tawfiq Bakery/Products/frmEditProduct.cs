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

namespace Al_Tawfiq_Bakery.Products
{
    public partial class frmEditProduct : Form
    {
        int _productID = -1;
        clsProducts _products;

        public frmEditProduct(int ProductID)
        {
            InitializeComponent();
            _productID = ProductID;
            clsProducts._eventHandler_Find += FindData;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(_products != null)
            {
                _products.ProductName = txtProductName.Text;
                _products.LastUpdate = DateTime.Now;
               await _products.Save();
            }
            Close();
        }

        public void FindData(clsProducts e)
        {
            if (e != null)
            {
                _products = e;
                txtProductName.Text = e.ProductName;

            }
        }

        private async void frmEditProduct_Load(object sender, EventArgs e)
        {
            await clsProducts.Find(_productID);

        }
    }
}
