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
    public partial class frmProductComponents : Form
    {

        int _prodectID = -1;
        public frmProductComponents(int prodectID)
        {
            InitializeComponent();
            _prodectID = prodectID;
            this.dgvProductComponents.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvProductComponents.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;
            clsProductComponents._getAllData += getByProdectID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        public void getByProdectID(string ex, DataTable dt )
        {





            dgvProductComponents.DataSource = dt;

            if (dgvProductComponents.Rows.Count > 0)
            {
                var columns = new (int Width, string HeaderText, bool Visible)[]
                {
        (100, "المعرف", true),
        (150, "اسم الصنف", true),
      
        (150, " الكمية لكل كيلو منتج", true),
        (0, "", false),
        (0, "", false),
    
        (150, "اخر سعر للكيلو", true),


                };

                for (int i = 0; i < columns.Length; i++)
                {
                    dgvProductComponents.Columns[i].Width = columns[i].Width;
                    dgvProductComponents.Columns[i].HeaderText = columns[i].HeaderText;
                    dgvProductComponents.Columns[i].Visible = columns[i].Visible;
                }
            }
            clsProductComponents._getAllData -= getByProdectID;
            // clsProductComponents._getAllData -= getByProdectID;

        }

        private async void frmProductComponents_Load(object sender, EventArgs e)
        {
            await clsProductComponents.GetAll(_prodectID);
        }

        private async void dgvProductComponents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEdit edit = new frmEdit((int)dgvProductComponents.Rows[dgvProductComponents.CurrentRow.Index].Cells[0].Value);
            edit.ShowDialog();
            clsProductComponents._getAllData += getByProdectID;
            await clsProductComponents.GetAll(_prodectID);

        }
    }
}
