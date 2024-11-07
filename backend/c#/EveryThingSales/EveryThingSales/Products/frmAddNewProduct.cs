using EveryThingLO;
using EveryThingSales.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveryThingSales.Products
{
    public partial class frmAddNewProduct : Form
    {
        int _ProductID;

        enum MODE { Add=1,Update=2};

        MODE _mode = MODE.Add;

        clsProducts _Products;

        public frmAddNewProduct(int ProductID)
        {
            InitializeComponent();
            _ProductID = ProductID;
            _mode = MODE.Update;
            ReLoad();
        }      
        
        public frmAddNewProduct()
        {
            InitializeComponent();
            _ProductID = -1;
            _mode = MODE.Add;
            ReLoad();
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        void ReLoad()
        {
         if(_mode == MODE.Update)
            {
                _Products = clsProducts.Find(_ProductID);
                if (_Products != null)
                {
                    txtProductName.Text = _Products.ProductName;
                    txtProductBarCode.Text = _Products.ProductBarCode;
                    txtPriceOnSeller.Text = _Products.PriceOnSeller.ToString();
                    txtSellingPrice.Text = _Products.SellingPrice.ToString();
                    txtSellingPriceTraders.Text = _Products.SellingPriceTraders.ToString();
                    txtQuantityAvailablePerPiece.Text = _Products.QuantityAvailablePerPiece.ToString();
                    txtDiscountPercentage.Text = _Products.DiscountPercentage.ToString();
                    txtNotes.Text = _Products.Notes.ToString();
                    txtProductName.Focus();
                    this.Text = $"تحديث المنتج -  {_Products.ProductName}";
                }

            }else if(_mode == MODE.Add)
            {
                _Products = new clsProducts();
                this.Text = $"Add N ew Item";
                txtProductName.Text = "";
                txtProductBarCode.Text = "";
                txtPriceOnSeller.Text = "";
                txtSellingPrice.Text = "";
                txtSellingPriceTraders.Text = "";
                txtQuantityAvailablePerPiece.Text = "";
                txtDiscountPercentage.Text = "";
                txtNotes.Text = "";
                txtProductName.Focus();
            }
        }

        private void frmAddNewProduct_Load(object sender, EventArgs e)
        {

        }

        bool MessageBoxValidate()
        {
            bool statu = true;
            if (clsValidateInputs.TextToDecimal(txtPriceOnSeller.Text) == -2)
            {
                MessageBox.Show("خطأ في المدخلات - السعر");
                txtPriceOnSeller.Focus();
                txtPriceOnSeller.BackColor = Color.Red;
                txtPriceOnSeller.ForeColor = Color.Wheat;
                statu = false;
            }
            else {
           
                txtPriceOnSeller.BackColor = Color.Wheat;
                txtPriceOnSeller.ForeColor = Color.Black;
           
            }
            
            
            if (clsValidateInputs.TextToDecimal(txtSellingPrice.Text) == -2)
            {
                MessageBox.Show("خطأ في المدخلات - سعر البيع");
                txtSellingPrice.Focus();
                txtSellingPrice.BackColor = Color.Red;
                txtSellingPrice.ForeColor = Color.Wheat;
                statu = false;
            }
            else {
         
                txtSellingPrice.BackColor = Color.Wheat;
                txtSellingPrice.ForeColor = Color.Black;
      
            } if (clsValidateInputs.TextToInt(txtQuantityAvailablePerPiece.Text) == -2)
            {
                MessageBox.Show("خطأ في المدخلات - الكمية");
                txtQuantityAvailablePerPiece.Focus();
                txtQuantityAvailablePerPiece.BackColor = Color.Red;
                txtQuantityAvailablePerPiece.ForeColor = Color.Wheat;
                statu = false;
            }
            else {
                txtQuantityAvailablePerPiece.BackColor = Color.Wheat;
                txtQuantityAvailablePerPiece.ForeColor = Color.Black;
       
            }

            if (clsValidateInputs.TextToDouble(txtDiscountPercentage.Text) == -2)
            {
                MessageBox.Show("خطأ في المدخلات - الخصم");
                txtDiscountPercentage.Focus();
                txtDiscountPercentage.BackColor = Color.Red;
                txtDiscountPercentage.ForeColor = Color.Wheat;
                statu = false;
            }
            else
            {
                txtDiscountPercentage.BackColor = Color.Wheat;
                txtDiscountPercentage.ForeColor = Color.Black;
            
            }

                return statu;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (MessageBoxValidate())
            {


                _Products.ProductName = txtProductName.Text;
                _Products.ProductBarCode = txtProductBarCode.Text;
                _Products.SellingPriceTraders = clsValidateInputs.TextToDecimal(txtSellingPriceTraders.Text);
                _Products.Notes = txtNotes.Text;
                _Products.PriceOnSeller = clsValidateInputs.TextToDecimal(txtPriceOnSeller.Text);
                _Products.SellingPrice = clsValidateInputs.TextToDecimal(txtSellingPrice.Text);
                _Products.QuantityAvailablePerPiece = clsValidateInputs.TextToInt(txtQuantityAvailablePerPiece.Text);
                _Products.DiscountPercentage = clsValidateInputs.TextToDouble(txtDiscountPercentage.Text);


                if (_mode == MODE.Add)
                {
                    _Products.DateCreated = DateTime.Now;
                }
                else
                {
                    _Products.LastUpdated = DateTime.Now;

                }

                if (_Products.Save(out Exception ex))
                {
                    _mode = MODE.Update;
                    _ProductID = _Products.ProductID;
                    ReLoad();
                    //MessageBox.Show("Sucss");
                    Close();

                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtPriceOnSeller_TextChanged(object sender, EventArgs e)
        {
            txtSellingPrice.Text = (clsValidateInputs.TextToDecimal(txtPriceOnSeller.Text) * clsValidateInputs.TextToDecimal("1.25")).ToString();
            txtSellingPriceTraders.Text = (clsValidateInputs.TextToDecimal(txtPriceOnSeller.Text) * clsValidateInputs.TextToDecimal("1.15")).ToString();
       
        }
    }
}
