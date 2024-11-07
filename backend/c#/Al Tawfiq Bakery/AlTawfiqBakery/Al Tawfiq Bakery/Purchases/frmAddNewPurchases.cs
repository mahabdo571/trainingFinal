using Al_Tawfiq_Bakery.Genral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPLO;

namespace Al_Tawfiq_Bakery.Purchases
{
    public partial class frmAddNewPurchases : Form
    {

        enum Mode { add = 1, update = 2 };
        Mode _mode = Mode.add;
        clsPurchases Purchases;
        int _PurchaseID = -1;
        int _storeID = -1;
        clsStore _store;
        decimal xxx = 0;
        public frmAddNewPurchases(int storeID)
        {
            InitializeComponent();
            dtpExp.MinDate = DateTime.Today;

            _mode = Mode.add;
            _storeID = storeID;
            callBack();


        }

        public frmAddNewPurchases(int purchaseID, int storeID)
        {
            InitializeComponent();

            _PurchaseID = purchaseID;
            _storeID = storeID;
            _mode = Mode.update;


            callBack();



        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // checkMode();
            if (Purchases == null) return;
            xxx = Purchases.Quantity;


            Purchases.ProductName = txtProductName.Text;
            Purchases.Quantity = clsValidation.StringToDecimal(txtQuantity.Text);
            Purchases.paid = cbPaid.SelectedIndex == 1 ?false:true;
            Purchases.UnitPrice = clsValidation.StringToDecimal(txtUnitPrice.Text);
            Purchases.TotalPrice = (Purchases.Quantity * Purchases.UnitPrice);
            txtTotalPrice.Text = Purchases.TotalPrice.ToString();
            Purchases.ItemSupplier = txtItemSupplier.Text;
            Purchases.InvoiceNumber = txtInvoiceNumber.Text;
            Purchases.Notes = txtNotes.Text;
            Purchases.ExpiryDate = dtpExp.Value;
            Purchases.PurchaseDate = DateTime.Now;
            if (_storeID != -1)
            {
                Purchases.StoreID = _storeID;
            }
            else
            {
                Purchases.StoreID = (int)cbStore.SelectedValue;
            }
            TaskFactory taskFactory = new TaskFactory(new CancellationTokenSource().Token,
                TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);

            Task t1 = taskFactory.StartNew(async () =>
            {

                var (exp, dd) = await Purchases.Save();
                if (!dd)
                {
                    MessageBox.Show(exp.Message);
                }

                this.Text = $"تحديث العنصر : {Purchases.ProductName}";
            });
            try
            {
                // Wait for both tasks to complete
                Task.WaitAll(t1);

            }
            catch (AggregateException ae)
            {

                MessageBox.Show(ae.Message);
            }



            if (_store != null || Purchases != null)
            {
             
                _store.LastUpdatedPrice = Purchases.UnitPrice;
                await _store.Save();
            }



            clsStore.UpdateQuantityStore(_store, Purchases, xxx);

            Close();

        }

        void callBack()
        {
            clsPurchases.CallbackEvent += getDataFromId;
            clsStore._getAllData += getalldataaa;
            clsStore.CallbackEvent_Find += CallbackEvent_Finddd;


        }
        private async void checkMode()
        {

            switch (_mode)
            {
                case Mode.add:
                    if (!(await AddNew()))
                    {
                        _mode = Mode.update;


                        checkMode();
                    }
                    else
                    {
                        MessageBox.Show("خطأ");

                    }
                    break;
                case Mode.update:
                    updateItem();
                    break;
                default:
                    return;

            }

        }

        private async Task<bool> AddNew()
        {
            this.Text = "اضافة عنصر جديد";
            Purchases = new clsPurchases();


            var (exp, iswrong) = await Purchases.Save();

            _PurchaseID = Purchases.PurchaseID;
            _storeID = Purchases.StoreID;

            //  MessageBox.Show("" + _PurchaseID);

            if (iswrong)
            {
                MessageBox.Show(exp.Message);


            }
            return iswrong;
        }

        private async void updateItem()
        {

            //  MessageBox.Show(_PurchaseID.ToString());
            await clsPurchases.Find(_PurchaseID);

        }

        public async void getDataFromId(object sender, clsPurchases e)
        {


            if (e != null)
            {

                Purchases = e;
                dtpExp.MinDate = Purchases.ExpiryDate;
                this.Text = $"تحديث العنصر : {Purchases.ProductName}";
                txtQuantity.Text = Purchases.Quantity.ToString();
                cbPaid.SelectedIndex = Purchases.paid ? 0 : 1;
                txtUnitPrice.Text = Purchases.UnitPrice.ToString();
                txtTotalPrice.Text = Purchases.TotalPrice.ToString();
                try { dtpExp.Value = Purchases.ExpiryDate; } catch { }
                txtInvoiceNumber.Text = Purchases.InvoiceNumber;
                txtItemSupplier.Text = Purchases.ItemSupplier;
                txtNotes.Text = Purchases.Notes;
                await clsStore.Find(Purchases.StoreID);

            }

            clsPurchases.CallbackEvent -= getDataFromId;

        }

        void CallbackEvent_Finddd(clsStore e)
        {
            //   MessageBox.Show(e.ProductName);
            if (e != null)
            {
                _store = e;
                cbStore.SelectedIndex = cbStore.FindString(e.ProductName);
                txtProductName.Text = _store.ProductName;

            }

            // cbStore.SelectedText = e.ProductName;
            clsStore.CallbackEvent_Find -= CallbackEvent_Finddd;

        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuantity.Text) && !string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                txtTotalPrice.Text = (clsValidation.StringToDecimal(txtUnitPrice.Text) * (clsValidation.StringToDecimal(txtQuantity.Text))).ToString();
            }
            else
            {
                txtTotalPrice.Text = "";
            }
        }

        private async void frmAddNewPurchases_Load(object sender, EventArgs e)
        {

            this.Location = new Point(0, 0);
            this.Size = new System.Drawing.Size(600, Screen.PrimaryScreen.Bounds.Height - 100);



            checkMode();

            await clsStore.GetAll();

            if (_storeID == -1)
            {
                cbStore.Enabled = true;
            }
            else
            {
                await clsStore.Find(_storeID);

                cbStore.Enabled = false;
            }



        }

        public void getalldataaa(string s, DataTable dt)
        {
            if (dt != null)
            {
                try
                {
                    cbStore.DataSource = dt;
                    cbStore.DisplayMember = "ProductName";
                    cbStore.ValueMember = "StoreID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ" + ex.Message);
                }
            }
            clsStore._getAllData -= getalldataaa;
        }

        private async void cbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await clsStore.Find((int)cbStore.SelectedValue);
                statusFilde();


            }
            catch
            {

            }
            //   MessageBox.Show(cbStore.SelectedValue.ToString());
        }


        void statusFilde()
        {
            var settings = new Dictionary<string, (string unitPrice, string unitText, string unitPriceText, Font font,bool isen)>
{
    { "غاز", ("5.834", "الكمية بالكيلو غرام", "سعر الكيلو", new Font("Arial", 14, FontStyle.Bold),false) },
    { "كهربا", ("0.77", "الكمية بالكيلو واط", "سعر الكيلو", new Font("Arial", 14, FontStyle.Bold),false) },
    { "ماء", ("0.0005", "الكمية باللتر", "سعر اللتر", new Font("Arial", 18, FontStyle.Bold),false) },
    { "طحين ابيض", ("2.6", "الكمية بالكيلو غرام", "سعر الكيلو", new Font("Arial", 14, FontStyle.Bold),false) },
    { "سمسم", ("13.2", "الكمية بالكيلو غرام", "سعر الكيلو", new Font("Arial", 14, FontStyle.Bold),false) },
    { "سكر", ("3.6", "الكمية بالكيلو غرام", "سعر الكيلو", new Font("Arial", 14, FontStyle.Bold),false) },
    { "خميرة", ("15", "الكمية بالكيلو غرام", "سعر الكيلو", new Font("Arial", 14, FontStyle.Bold),false) },
    { "ملح", ("1", "الكمية بالكيلو غرام", "سعر الكيلو", new Font("Arial", 14, FontStyle.Bold),false) },
    { "نخالة", ("1.4", "الكمية بالكيلو غرام", "سعر الكيلو", new Font("Arial", 14, FontStyle.Bold),false) },
    { "خومر كرشلة", ("5", "الكمية بالكيلو غرام", "سعر الكيلو", new Font("Arial", 14, FontStyle.Bold),false) },
    { "خومر لخمنيوت", ("2", "الكمية بالكيلو غرام", "سعر الكيلو", new Font("Arial", 14, FontStyle.Bold),false) },
    { "حليب ناشف", ("7.6", "الكمية بالكيلو غرام", "سعر الكيلو", new Font("Arial", 14, FontStyle.Bold),false) },
    { "زيت نباتي", ("5.4", "الكمية باللتؤ", "سعر اللتر", new Font("Arial", 14, FontStyle.Bold),false) },
    { "اجور عمال", ("50", "عدد الايام", "السعر باليوم", new Font("Arial", 14, FontStyle.Bold),true) },
    { "طحين قمح", ("3", "الكمية بالكيلو غرام", "سعر الكيلو", new Font("Arial", 18, FontStyle.Bold),false) }
};

            if (settings.ContainsKey(cbStore.Text))
            {
                var setting = settings[cbStore.Text];
                txtUnitPrice.Text = setting.unitPrice;
                txtUnitPrice.Enabled = setting.isen;
                lblunit.Text = setting.unitText;
                lblunpris.Text = setting.unitPriceText;
                lblunit.Font = setting.font;
            }
            else
            {
                txtUnitPrice.Text = "";
                txtUnitPrice.Enabled = true;
                lblunit.Text = "الكمية";
                lblunpris.Text = "سعر الوحدة";
                lblunit.Font = new Font("Arial", 22, FontStyle.Bold);
            }

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuantity.Text) && !string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                txtTotalPrice.Text = (clsValidation.StringToDecimal(txtUnitPrice.Text) * (clsValidation.StringToDecimal(txtQuantity.Text))).ToString();
            }
            else
            {
                txtTotalPrice.Text = "";
            }
        }
    }
}
