using Al_Tawfiq_Bakery.PoductionProcess;
using Al_Tawfiq_Bakery.Products;
using Al_Tawfiq_Bakery.Purchases;
using Al_Tawfiq_Bakery.Store;
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

namespace Al_Tawfiq_Bakery
{
    public partial class Mainstart : Form
    {
        public Mainstart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPurchases frmPurchases = new frmPurchases(-1);
            frmPurchases.MdiParent = Home.ActiveForm;
            frmPurchases.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStore frmStore = new frmStore();
            frmStore.MdiParent = Home.ActiveForm;
            frmStore.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmProducts prod = new frmProducts();
            prod.MdiParent = Home.ActiveForm;
            prod.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
       frmPoductionProcess frmpp = new frmPoductionProcess();
            frmpp.MdiParent = Home.ActiveForm;
            frmpp.Show();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (clsLOSettings.BackupDB())
            {
                MessageBox.Show("تم حفظ البيانات بنجاح","حفظ",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("خطأ في حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
