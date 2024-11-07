using Al_Tawfiq_Bakery.Purchases;
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

namespace Al_Tawfiq_Bakery.Store
{
    public partial class frmStore : Form
    {
        public frmStore()
        {
            InitializeComponent();
            this.dgvStore.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvStore.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;
            clsStore._getAllData += fillDatastore;
        }


        private void tsmiAddPurchases_Click(object sender, EventArgs e)
        {

            if (dgvStore.CurrentRow == null)
            {
                MessageBox.Show("الرجاء الاختيار بشكل صحيح");
                return;
            }
       

            frmPurchases frmPursh = new frmPurchases((int)dgvStore.Rows[dgvStore.CurrentRow.Index].Cells[0].Value);
        //    frmPurchases frmPursh = new frmPurchases(1);
            frmPursh.ShowDialog();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {

        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {

        }

        private async void frmStore_Load(object sender, EventArgs e)
        {
          await clsStore.GetAll();
        }

        void fillDatastore(string s,DataTable dt)
        {



            dgvStore.DataSource = dt;

            if (dgvStore.Rows.Count > 0)
            {
                var columns = new (int Width, string HeaderText, bool Visible)[]
                {
        (100, "المعرف", true),
        (200, "اسم الصنف", true),
        (200, "اخر تحديث", true),
        (200, "الكمية المتوفرة في المخزن", true),

        (200, "اخر سعر للوحدة", true),

                };

                for (int i = 0; i < columns.Length; i++)
                {
                    dgvStore.Columns[i].Width = columns[i].Width;
                    dgvStore.Columns[i].HeaderText = columns[i].HeaderText;
                    dgvStore.Columns[i].Visible = columns[i].Visible;
                }
            }


            clsStore._getAllData -= fillDatastore;
        }

        private async void dgvStore_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStore.CurrentRow == null)
            {
                return;
            }


        }

        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvStore.Rows)
            {
                if (Convert.ToInt32(row.Cells["QuantityAvailable"].Value) > 30)
                {
                    row.Cells["QuantityAvailable"].Style.BackColor = Color.LightGreen;

                }
                else if (Convert.ToInt32(row.Cells["QuantityAvailable"].Value) > 15)
                {
                    row.Cells["QuantityAvailable"].Style.BackColor = Color.Orange;

                }
                else if (Convert.ToInt32(row.Cells["QuantityAvailable"].Value) > 0)
                {
                    row.Cells["QuantityAvailable"].Style.BackColor = Color.DarkOrange;
                }
                else if (Convert.ToInt32(row.Cells["QuantityAvailable"].Value) <= 0)
                {
                    // row.DefaultCellStyle.BackColor = Color.LightSalmon; // Use it in order to colorize all cells of the row

                    row.Cells["QuantityAvailable"].Style.BackColor = Color.Red;
                }
            }
        }
    }
}
