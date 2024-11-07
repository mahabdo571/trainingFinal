using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPLO;

namespace Al_Tawfiq_Bakery.Purchases
{
    public partial class frmPurchases : Form
    {
        int StoryID = -1;

        public frmPurchases(int soryID)
        {
            InitializeComponent();
            StoryID = soryID;
            this.dgvPurchase.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvPurchase.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            frmAddNewPurchases newPurchases = new frmAddNewPurchases(StoryID);
            newPurchases.ShowDialog();
       
            if (StoryID != -1)
            {
                await clsPurchases.GetAllDatabyStoryID(StoryID);
            }
            else
            {
                await clsPurchases.GetAll();


            }

        }

        private async void frmPurchases_Load(object sender, EventArgs e)
        {

         
            clsPurchases._getAllDatabystoyid += getAllData;
            clsPurchases._getAllData += getAllData;


            if (StoryID != -1)
            {
                await clsPurchases.GetAllDatabyStoryID(StoryID);
            }
            else
            {
                await clsPurchases.GetAll();


            }
          
    
        }

        public void getAllData(string exp , DataTable dt)
        {
            if(exp != "ok")
            {
                MessageBox.Show(exp);
            }
            if (!dt.Columns.Contains("paid_new"))
            {
                dt.Columns.Add("paid_new", typeof(string));
            }



            foreach (DataRow row in dt.Rows)
            {
                bool paid = Convert.ToBoolean(row["paid"]);
                row["paid_new"] = paid ? "مدفوع" : "غير مدفوع";
            }
    


            dgvPurchase.DataSource = dt.DefaultView;

            if (dgvPurchase.Rows.Count > 0)
            {
                var columns = new (int Width, string HeaderText, bool Visible)[]
                {
        (100, "المعرف", true),
        (200, "اسم الصنف", true),
        (150, "تاريخ الشراء", true),
        (150, "الكمية المشتراه", true),
     
        (150, "سعر الوحدة", true),
        (150, "السعر الكلي", true),
        (150, "رقم الفاتورة", false),
        (150, "اسم المورد او الشركة", false),
        (150, "تاريخ الانتهاء", true),
        (0, "", false), // column 10 (index 10) should be hidden
        (250, "ملاحظات", true),
        (0, "", false),
        (150, "حالة الدفع", true)
                };

                for (int i = 0; i < columns.Length; i++)
                {
                    dgvPurchase.Columns[i].Width = columns[i].Width;
                    dgvPurchase.Columns[i].HeaderText = columns[i].HeaderText;
                    dgvPurchase.Columns[i].Visible = columns[i].Visible;
                }
            }
        }

        private void frmPurchases_Resize(object sender, EventArgs e)
        {
            dgvPurchase.Height = this.Height-160;
            button1.Location =new Point(10,10);

        }

        private async void dgvPurchase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dgvPurchase.Rows[dgvPurchase.CurrentRow.Index].Cells[0].Value.ToString());
            frmAddNewPurchases newPurchases = new frmAddNewPurchases((int)dgvPurchase.Rows[dgvPurchase.CurrentRow.Index].Cells[0].Value,StoryID);
            newPurchases.ShowDialog();
            if (StoryID != -1)
            {
                await clsPurchases.GetAllDatabyStoryID(StoryID);
            }
            else
            {
                await clsPurchases.GetAll();


            }
        }
         


        private async void cmsDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد من انك تريد ازالة وحذف عملية الشراء هذه وازالتها من المخزون ...! ", "حذف عملية شراء", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsStore.UpdateQuantityStoreIfDeleteItem((int)dgvPurchase.Rows[dgvPurchase.CurrentRow.Index].Cells[0].Value);
               
                var (itsok, ex) = await clsPurchases.Delete((int)dgvPurchase.Rows[dgvPurchase.CurrentRow.Index].Cells[0].Value);
                if (itsok)
                {
                    MessageBox.Show("تم الحذف بنجاح", "عملية حذف ناجحة ", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
                }
                else
                {
                    MessageBox.Show(ex.Message, "خطأ . لم يتم الحذف ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (StoryID != -1)
            {
                await clsPurchases.GetAllDatabyStoryID(StoryID);
            }
            else
            {
                await clsPurchases.GetAll();


            }
        }

        private async void tcsRefresh(object sender, EventArgs e)
        {
            if (StoryID != -1)
            {
                await clsPurchases.GetAllDatabyStoryID(StoryID);
            }
            else
            {
                await clsPurchases.GetAll();


            }

        }
    }
}
