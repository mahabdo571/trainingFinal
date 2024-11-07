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
    public partial class frmPoductionProcess : Form
    {
        public frmPoductionProcess()
        {
            InitializeComponent();
            this.dgvPoductionProcess.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvPoductionProcess.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;
            clsPoductionProcess._getAllData += LoadAllData;

        }

        public  void LoadAllData(string ex,DataTable dt)
        {
            if (!dt.Columns.Contains("ProductName"))
            {
                dt.Columns.Add("ProductName", typeof(string));
            }



            foreach (DataRow row in dt.Rows)
            {
                int paid = Convert.ToInt32(row["ProductID"]);
               ;
                row["ProductName"] = clsProducts.FindWithoutAsync(paid).ProductName;
            }

            dgvPoductionProcess.DataSource = dt.DefaultView;

            if (dgvPoductionProcess.Rows.Count > 0)
            {
                var columns = new (int Width, string HeaderText, bool Visible)[]
                {
        (100, "المعرف", true),
        (0, "", false),
        (200, "الكمية المنتجة بالكيلو", true),
        (200, "تاريخ الانتاج ", true),
        (200, "تكلفة الانتاج التقريبية", true),
        (0, "", false),
        (200, "اسم المنتج", true),


                };

                for (int i = 0; i < columns.Length; i++)
                {
                    dgvPoductionProcess.Columns[i].Width = columns[i].Width;
                    dgvPoductionProcess.Columns[i].HeaderText = columns[i].HeaderText;
                    dgvPoductionProcess.Columns[i].Visible = columns[i].Visible;
                }
            }

            clsPoductionProcess._getAllData -= LoadAllData;
        }

        private async void frmPoductionProcess_Load(object sender, EventArgs e)
        {
            dgvPoductionProcess.Height = (this.Height - 100);
            btnAdd.Location = new Point(10, 10);
            clsPoductionProcess._getAllData += LoadAllData;
            await clsPoductionProcess.GetAll();
        }

        private void frmPoductionProcess_Resize(object sender, EventArgs e)
        {
            dgvPoductionProcess.Height = (this.Height - 100);
            btnAdd.Location = new Point(10, 10);
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEdit frmae = new frmAddEdit();
            frmae.ShowDialog();
            clsPoductionProcess._getAllData += LoadAllData;
            await clsPoductionProcess.GetAll();
        }

        private async void dgvPoductionProcess_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAddEdit frmae = new frmAddEdit((int)dgvPoductionProcess.Rows[dgvPoductionProcess.CurrentRow.Index].Cells[0].Value, -1);
            frmae.ShowDialog();
            clsPoductionProcess._getAllData += LoadAllData;
            await clsPoductionProcess.GetAll();
        }

        private async void tsmiEdit_Click(object sender, EventArgs e)
        {
            frmAddEdit frmae = new frmAddEdit((int)dgvPoductionProcess.Rows[dgvPoductionProcess.CurrentRow.Index].Cells[0].Value, -1);
            frmae.ShowDialog();
            clsPoductionProcess._getAllData += LoadAllData;
            await clsPoductionProcess.GetAll();
        }

        private void tsmiShow_Click(object sender, EventArgs e)
        {

        }

        private async void tsmiRefresh_Click(object sender, EventArgs e)
        {
            clsPoductionProcess._getAllData += LoadAllData;
            await clsPoductionProcess.GetAll();
        }

        private async void tsmiDelete_Click(object sender, EventArgs e)
        {
            frmAddEdit frmae = new frmAddEdit((int)dgvPoductionProcess.Rows[dgvPoductionProcess.CurrentRow.Index].Cells[0].Value,77);
           
            frmae.ShowDialog();

            await clsPoductionProcess.Delete((int)dgvPoductionProcess.Rows[dgvPoductionProcess.CurrentRow.Index].Cells[0].Value);
            clsPoductionProcess._getAllData += LoadAllData;
            await clsPoductionProcess.GetAll();

        }
    }
}
