using EveryThingLO;
using EveryThingSales.Orders;
using System;
using System.Drawing;
using System.Windows.Forms;



namespace EveryThingSales.Products
{

    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            this.dgvAllItems.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvAllItems.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;
        }

   
        private void Products_Load(object sender, EventArgs e)
        {
            dgvAllItems.DataSource = clsProducts.GetAllItems();
            dgvAllItems.Columns[0].Width = 50;
            dgvAllItems.Columns[0].HeaderText = "#";
            dgvAllItems.Columns[1].Width = 250;
            dgvAllItems.Columns[1].HeaderText = "اسم الصنف"; 
            dgvAllItems.Columns[2].Width = 100;
            dgvAllItems.Columns[2].HeaderText = "باركود";  
            dgvAllItems.Columns[3].Width = 70;
            dgvAllItems.Columns[3].HeaderText = "السعر الاساسي";     
            dgvAllItems.Columns[4].Width = 70;
            dgvAllItems.Columns[4].HeaderText = "السعر للزبائن";    
            dgvAllItems.Columns[5].Width = 70;
            dgvAllItems.Columns[5].HeaderText = "السعر للتجار";     
            dgvAllItems.Columns[6].Width = 150;
            dgvAllItems.Columns[6].HeaderText = "تاريخ الاضافة";
            dgvAllItems.Columns[7].Width = 150;
            dgvAllItems.Columns[7].HeaderText = "تاريخ التعديل";   
            
            dgvAllItems.Columns[8].Width = 70;
            dgvAllItems.Columns[8].HeaderText = "الكمية المتاحة "; 
            dgvAllItems.Columns[9].Width = 70;
            dgvAllItems.Columns[9].HeaderText = "نسبة الخصم";  
            dgvAllItems.Columns[10].Width = 150;
            dgvAllItems.Columns[10].HeaderText = "ملاحظات";

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddNewProduct frmadd = new frmAddNewProduct();
            frmadd.ShowDialog();
            dgvAllItems.DataSource = clsProducts.GetAllItems();
            //kjjjj
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmAddNewProduct frmupd = new frmAddNewProduct((int)dgvAllItems.Rows[dgvAllItems.CurrentRow.Index].Cells[0].Value);
            frmupd.ShowDialog();
            dgvAllItems.DataSource = clsProducts.GetAllItems();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsProducts.DeleteItem((int)dgvAllItems.Rows[dgvAllItems.CurrentRow.Index].Cells[0].Value))
            {
                MessageBox.Show("delete Sucess");
            }
            else
            {
                MessageBox.Show("Error");

            }

            dgvAllItems.DataSource = clsProducts.GetAllItems();
        }

        private void dgvAllItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            frmAddNewProduct frmupd = new frmAddNewProduct((int)dgvAllItems.Rows[dgvAllItems.CurrentRow.Index].Cells[0].Value);
            frmupd.ShowDialog();
            dgvAllItems.DataSource = clsProducts.GetAllItems();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvAllItems.DataSource = clsProducts.GetAllItems();

        }

        private void dgvAllItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvAllItems.Rows)
            {
                if (Convert.ToInt32(row.Cells["QuantityAvailablePerPiece"].Value) > 30)
                {
                    row.Cells["QuantityAvailablePerPiece"].Style.BackColor = Color.LightGreen;

                }else if (Convert.ToInt32(row.Cells["QuantityAvailablePerPiece"].Value) > 15)
                {
                    row.Cells["QuantityAvailablePerPiece"].Style.BackColor = Color.Orange;

                }else if (Convert.ToInt32(row.Cells["QuantityAvailablePerPiece"].Value) > 0)
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
    }
}
