using Al_Tawfiq_Bakery.ProductComponents;
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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
            this.dgvProducts.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvProducts.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;
            clsProducts._getAllData += GetAllProdectEv;
        }

        private async void frmProducts_Load(object sender, EventArgs e)
        {
            await clsProducts.GetAll();
        }

        public  void GetAllProdectEv(string ex,DataTable dt)
        {
         
            dgvProducts.DataSource = dt;

            if (dgvProducts.Rows.Count > 0)
            {
                var columns = new (int Width, string HeaderText, bool Visible)[]
                {
        (100, "المعرف", true),
        (200, "اسم الصنف", true),
        (200, "اخر تحديث", true),
  

                };

                for (int i = 0; i < columns.Length; i++)
                {
                    dgvProducts.Columns[i].Width = columns[i].Width;
                    dgvProducts.Columns[i].HeaderText = columns[i].HeaderText;
                    dgvProducts.Columns[i].Visible = columns[i].Visible;
                }
            }
            clsProducts._getAllData -= GetAllProdectEv;
        }

        private void dgvProducts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frmProductComponents frmPC = new frmProductComponents((int)dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[0].Value);
            frmPC.ShowDialog();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditProduct editProd = new frmEditProduct((int)dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[0].Value);
            editProd.ShowDialog();
            clsProducts._getAllData += GetAllProdectEv;
            await clsProducts.GetAll();

        }

        private void showCompountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductComponents frmPC = new frmProductComponents((int)dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[0].Value);
            frmPC.ShowDialog();

        }
    }
}
