using EveryThingLO;
using EveryThingSales.General;
using EveryThingSales.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace EveryThingSales.Orders
{
    public partial class frmNewOrder : Form
    {
        clsProducts _Product;
        clsOrder _Order;
        clsSales _Sales;
        clsProducts tempProd = null;
        int _OrderId = -1;
        decimal total;
        DataTable dt_prodect;
        public frmNewOrder()
        {
            InitializeComponent();

            NewOrder();

            txtBarcode.Focus();
            this.dgvSales.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvSales.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;

            this.dgvProdacts.RowsDefaultCellStyle.BackColor = Color.Bisque;


            this.dgvProdacts.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;



            dgvSales.RowTemplate.Height = 40;
            dgvProdacts.RowTemplate.Height = 40;
            rbCustomers.Select();


        }

        void NewOrder()
        {
            _Order = new clsOrder();

            _Order.DateCreated = DateTime.Now;

            if (_Order.Save())
            {
                _OrderId = _Order.OrderID;


            }
        }

        void newSales(string barCode)
        {

            if (string.IsNullOrEmpty(barCode))
            {
                return;
            }

            if (_Product != null)
            {
                tempProd = _Product;
            }


            _Product = clsProducts.FindByBarCode(barCode);




            if (_Product == null)
            {
                MessageBox.Show("المنتج غير متوفر");
                txtBarcode.Text = "";
                return;
            }

            if (_Product.QuantityAvailablePerPiece <= 0)
            {
                MessageBox.Show("غير متوفر");

                dgvProdacts.DataSource = clsProducts.FetchAvailableProducts();

                return;
            }


            _Sales = clsSales.FindbyProductID(_Product.ProductID, _OrderId);

            if (_Sales != null)
            {
                if (_Product != null)
                {
                    tempProd = _Product;
                }
              
                if (tempProd != null && (_Product.ProductBarCode == tempProd.ProductBarCode))
                {

                    AddDiscount();

                    dgvSales.DataSource = clsSales.GetAllItemsByOrder(_OrderId);
                    txtBarcode.Text = "";
                    lblTotalSum.Text = _totalSum();
                    AddToThisSale();
                    txtBarcode.Focus();
               



                }

            }
            else
            {

                _Sales = new clsSales();
             
                _Sales.OrderID = _OrderId;
                if (rbCustomers.Checked)
                {
                    _Sales.PSellingPrice = _Product.SellingPrice;
                }
                else if (rbTraders.Checked)
                {
                    _Sales.PSellingPrice = _Product.SellingPriceTraders;
                }
                else
                {
                    _Sales.PSellingPrice = 0;

                }

                _Sales.PDiscountPercentage = _Product.DiscountPercentage;
                _Sales.ProductID = _Product.ProductID;
                _Sales.Save();
                AddToThisSale();

            }

            
            

            dgvSales.DataSource = clsSales.GetAllItemsByOrder(_OrderId);
            txtBarcode.Text = "";
            lblTotalSum.Text = _totalSum();

            selectCurrntprod();
          //  selectCurrntsale();
            txtBarcode.Focus();


        }

        void AddDiscount()
        {
            if ((_Sales.Amount % 10) == 1)//حساب خصم نسبة بعد عدد معين من الكمية لاحقاا
            {
                if (rbTraders.Checked)
                {
                    _Sales.PDiscountPercentage += 0.008;
                }
                else
                {
                    _Sales.PDiscountPercentage += 0.01;
                }
               
            }
            _Sales.Save();
        }  
        
        void SupDiscount()
        {
            if ((_Sales.Amount % 10) == 1)//حساب خصم نسبة بعد عدد معين من الكمية لاحقاا
            {
                if (rbTraders.Checked)
                {
                    _Sales.PDiscountPercentage -= 0.008;
                }
                else
                {
                    _Sales.PDiscountPercentage -= 0.01;
                }
            }
            _Sales.Save();
        }

        private void frmNewOrder_Load(object sender, EventArgs e)
        {
            dt_prodect = clsProducts.FetchAvailableProducts();
            dgvProdacts.DataSource = dt_prodect;

           dgvProdacts.Columns[0].Width = 20;
           dgvProdacts.Columns[0].HeaderText = "#";
           dgvProdacts.Columns[1].Width = 210;
           dgvProdacts.Columns[1].HeaderText = "اسم الصنف";
           dgvProdacts.Columns[2].Visible = false;

           dgvProdacts.Columns[3].Width = 70;
           dgvProdacts.Columns[3].HeaderText = "السعر الاساسي";
            if (rbTraders.Checked)
            {
                dgvProdacts.Columns[4].Visible = false;
         
                dgvProdacts.Columns[5].Visible = true;
                dgvProdacts.Columns[5].Width = 70;
                dgvProdacts.Columns[5].HeaderText = "السعر للتجار";
            }
            else
            {
                dgvProdacts.Columns[4].Visible = true;
                dgvProdacts.Columns[5].Visible = false;
                dgvProdacts.Columns[4].Width = 70;
                dgvProdacts.Columns[4].HeaderText = "السعر للزبائن";
            }
  

      
           dgvProdacts.Columns[6].Visible = false;
           dgvProdacts.Columns[7].Visible = false;
     
           
           dgvProdacts.Columns[8].Width = 70;
           dgvProdacts.Columns[8].HeaderText = "الكمية المتاحة ";
           dgvProdacts.Columns[9].Width = 70;
           dgvProdacts.Columns[9].HeaderText = "نسبة الخصم";
           dgvProdacts.Columns[10].Width = 150;
            dgvProdacts.Columns[10].HeaderText = "ملاحظات";


        }


        string _totalSum()
        {

            total = dgvSales.Rows.Cast<DataGridViewRow>()
               .Sum(t =>
               {


                   decimal price = clsValidateInputs.TextToDecimal(t.Cells[2].Value.ToString());
                   double descount = clsValidateInputs.TextToDouble(t.Cells[3].Value.ToString());
                   int amount = clsValidateInputs.TextToInt(t.Cells[4].Value.ToString());

                   if (price == -2 || descount == -2)
                   {
                       MessageBox.Show("خطأ في المدخلات ");
                       return 0;
                   }


                   if (descount > 0)
                   {


                       return ((price - (price * Convert.ToDecimal(descount))) * amount);
                   }
                   else
                   {
                       return (price * amount);
                   }

               });
            return total.ToString();
        }


        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            txtordernum.Text = "الطلبية الحالية ورقمها " + _OrderId;
            if (e == null)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                newSales(txtBarcode.Text.Trim());

             


            }


            if (e.KeyCode == Keys.Home)
            {


                frmPaymentGateway endSetion = new frmPaymentGateway(total, _OrderId);
                endSetion.ShowDialog();
                NewOrder();
                dgvSales.DataSource = clsSales.GetAllItemsByOrder(_OrderId);
                lblTotalSum.Text = "???";
                txtordernum.Text = "طلبية جديدة";
                txtBarcode.Focus();


            }

            if (e.KeyCode == Keys.Oemplus)
            {

                txtBarcode.ForeColor = Color.White;
                if (_Sales != null)
                {
                    AddToThisSale();
                    AddDiscount();
                    if (_Sales.Amount <= 0)
                    {
                        MessageBox.Show("لا يمكن ان تكون الكمية صفر ! ");
                        return;
                    }
                    if(_Product.QuantityAvailablePerPiece <= 0)
                    {
                        MessageBox.Show("نفذ المخزون ! ");
                        dgvProdacts.DataSource = clsProducts.FetchAvailableProducts();
                        dgvSales.DataSource = clsSales.GetAllItemsByOrder(_OrderId);

                        return;
                    }

                    try {
                        dgvSales.Rows[dgvSales.SelectedRows[0].Index].Cells["DiscountPercentage"].Value = _Sales.PDiscountPercentage;

                        dgvSales.Rows[dgvSales.SelectedRows[0].Index].Cells["Amount"].Value = _Sales.Amount; } catch { }
                    dgvProdacts.Rows[dgvProdacts.SelectedRows[0].Index].Cells["QuantityAvailablePerPiece"].Value = _Product.QuantityAvailablePerPiece;
            
                }
                txtBarcode.Text = "";
                lblTotalSum.Text = _totalSum();
            }

            if (e.KeyCode == Keys.OemMinus)
            {
                txtBarcode.ForeColor = Color.White;
                if (_Sales != null)
                {
                    DrupFromthisSale();
                    SupDiscount();

                    if (_Sales.Amount <= 0)
                    {
                        MessageBox.Show("لا يمكن ان تكون الكمية صفر ! ");
                        return;
                    }
                    if (_Product.QuantityAvailablePerPiece <= 0)
                    {
                        MessageBox.Show("نفذ المخزون ! ");
                        return;
                    }
                    dgvSales.Rows[dgvSales.SelectedRows[0].Index].Cells["DiscountPercentage"].Value = _Sales.PDiscountPercentage;
                    dgvSales.Rows[dgvSales.SelectedRows[0].Index].Cells["Amount"].Value = _Sales.Amount;
                     dgvProdacts.Rows[dgvProdacts.SelectedRows[0].Index].Cells["QuantityAvailablePerPiece"].Value = _Product.QuantityAvailablePerPiece;
                    lblTotalSum.Text = _totalSum();
                }
                txtBarcode.Text = "";
            }




        }

        void AddToThisSale()
        {
            if(_Product != null && _Sales != null)
            {
                _Product.DropOneFromStore();
                _Sales.AddOneToThisSale();

            }
        }
        void DrupFromthisSale()
        {
            if(_Product != null && _Sales != null)
            {
                _Product.AddOneToStore();
                _Sales.DropOneFromThisSale();
            }
        }


        private void btnAddProdect_Click(object sender, EventArgs e)
        {
            Products.Products newProd = new Products.Products();
            newProd.ShowDialog();
            dt_prodect = clsProducts.FetchAvailableProducts();
            dgvProdacts.DataSource = dt_prodect;
            txtBarcode.Focus();
        }


        private void txtSeacrch_TextChanged(object sender, EventArgs e)
        {

            if (dt_prodect == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(txtSeacrch.Text))
            {
                dt_prodect.DefaultView.RowFilter = null;
            }

            try
            {

                dt_prodect.DefaultView.RowFilter = string.Format("[{0}] like '%{2}%' OR [{1}] like '%{2}%'", "ProductName", "Notes", txtSeacrch.Text);
               if(dt_prodect != null)
                {
                    dgvProdacts.DataSource = dt_prodect;
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ " + ex.Message);
            }
  
        }

        private void deleteItemOnSale_Click(object sender, EventArgs e)
        {
            var sals = clsSales.Find((int)dgvSales.Rows[dgvSales.CurrentRow.Index].Cells[0].Value);
            var prod = clsProducts.Find(sals.ProductID);

            prod.QuantityAvailablePerPiece += sals.Amount;

            prod.Save(out Exception exx);
            dgvProdacts.DataSource = clsProducts.FetchAvailableProducts();


            try
            {


                clsSales.DeleteItem((int)dgvSales.Rows[dgvSales.CurrentRow.Index].Cells[0].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvSales.DataSource = clsSales.GetAllItemsByOrder(_OrderId);
           lblTotalSum.Text = _totalSum();
            txtBarcode.Focus();

        }

        private void RefreshSales_Click(object sender, EventArgs e)
        {
            dgvSales.DataSource = clsSales.GetAllItemsByOrder(_OrderId);
            dgvProdacts.DataSource = clsProducts.FetchAvailableProducts();
        }




        private void btnNewOrder_Click_1(object sender, EventArgs e)
        {
            frmNewOrder frmnewor = new frmNewOrder();
            frmnewor.Show();
        }
        int index = -1;
        private void dgvProdacts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                return;
            }
            txtBarcode.Text = (string)dgvProdacts.Rows[dgvProdacts.CurrentRow.Index].Cells[2].Value;
          
     

            txtBarcode_KeyUp(null, new KeyEventArgs(Keys.Enter));
            

            dgvProdacts.DataSource = clsProducts.FetchAvailableProducts();
            dgvProdacts.Rows[e.RowIndex].Selected = true;
           
            txtBarcode.Focus();
            try
            {
                dgvProdacts.FirstDisplayedScrollingRowIndex = e.RowIndex;
            }
            catch
            {

            }
          
            txtSeacrch.Text = "";

        }

        void selectCurrntprod()
        {
            try
            {
                int dd = (int)dgvProdacts.Rows[dgvProdacts.CurrentRow.Index].Cells[0].Value;

                int index = (dgvSales.Rows.Cast<DataGridViewRow>()
                        .Where(r => (int)r.Cells["ProductID"].Value == dd)
                        .Select(r => r.Index)).First();

                dgvSales.Rows[index].Selected = true;
            }
            catch
            {

            }
        }    
        
        void selectCurrntsale()
        {
            try
            {
                int dd = (int)dgvSales.Rows[dgvSales.CurrentRow.Index].Cells["ProductID"].Value;

                int index = (dgvProdacts.Rows.Cast<DataGridViewRow>()
                        .Where(r => (int)r.Cells["ProductID"].Value == dd)
                        .Select(r => r.Index)).First();

                dgvProdacts.Rows[index].Selected = true;
            }
            catch
            {

            }
        }

        private void rbTraders_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTraders.Checked)
            {
                if (MessageBox.Show("هل انت متأكد انك تريد البيع الى تاجر", "البع لتاجر", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rbTraders.Checked = true;
                    NewOrder();
                    frmNewOrder_Load(null, null);
                }
                else
                {
                    rbCustomers.Checked = true;
                    NewOrder();
                    frmNewOrder_Load(null, null);
                }
            }
            else
            {
                rbCustomers.Checked = true;
                NewOrder();
                frmNewOrder_Load(null, null);
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSales_SelectionChanged(object sender, EventArgs e)
        {
          

        }

        private void dgvSales_KeyUp(object sender, KeyEventArgs e)
        {





        }

        private void dgvProdacts_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSales_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dgvSales.CurrentCell.Selected = false;
            }
            else
            {
                dgvSales.CurrentCell.Selected = true;
            }
        }

        private void rbCustomers_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Sales != null)
            {
                _Sales = clsSales.Find((int)dgvSales.Rows[dgvSales.CurrentRow.Index].Cells["SalesID"].Value);
                try
                {
                    dgvSales.Rows[dgvSales.SelectedRows[0].Index].Selected = true;
                    selectCurrntsale();
                    txtBarcode.Focus();
                    _Product = clsProducts.Find(_Sales.ProductID);
                }
                catch
                {

                }
            }
        }

        private void dgvProdacts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvProdacts.Rows)
            {
          

                if (Convert.ToInt32(row.Cells["QuantityAvailablePerPiece"].Value) > 30)
                {
                    row.Cells["QuantityAvailablePerPiece"].Style.BackColor = Color.LightGreen;

                }
                else if (Convert.ToInt32(row.Cells["QuantityAvailablePerPiece"].Value) > 15)
                {
                    row.Cells["QuantityAvailablePerPiece"].Style.BackColor = Color.Orange;

                }
                else if (Convert.ToInt32(row.Cells["QuantityAvailablePerPiece"].Value) > 0)
                {
                    row.Cells["QuantityAvailablePerPiece"].Style.BackColor = Color.DarkOrange;
                }
                else if (Convert.ToInt32(row.Cells["QuantityAvailablePerPiece"].Value) == 0)
                {
                    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

                    row.Cells["QuantityAvailablePerPiece"].Style.BackColor = Color.Red;
                }
            }
        }

        private void dgvProdacts_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
      
        }

        private void frmNewOrder_MouseMove(object sender, MouseEventArgs e)
        {
            if (dgvProdacts != null)
            {
                index = dgvProdacts.CurrentRow.Index;
            }
        }
    }
}

