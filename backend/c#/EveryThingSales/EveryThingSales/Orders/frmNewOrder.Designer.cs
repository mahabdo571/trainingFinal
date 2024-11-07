namespace EveryThingSales.Orders
{
    partial class frmNewOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItemOnSale = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshSales = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalSum = new System.Windows.Forms.Label();
            this.txtordernum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSeacrch = new System.Windows.Forms.TextBox();
            this.btnAddProdect = new System.Windows.Forms.Button();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.dgvProdacts = new System.Windows.Forms.DataGridView();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbTraders = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCustomers = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteItemOnSale,
            this.RefreshSales});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(359, 120);
            // 
            // deleteItemOnSale
            // 
            this.deleteItemOnSale.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteItemOnSale.ForeColor = System.Drawing.Color.Red;
            this.deleteItemOnSale.Name = "deleteItemOnSale";
            this.deleteItemOnSale.Size = new System.Drawing.Size(358, 58);
            this.deleteItemOnSale.Text = "حذف هذا العنصر";
            this.deleteItemOnSale.Click += new System.EventHandler(this.deleteItemOnSale_Click);
            // 
            // RefreshSales
            // 
            this.RefreshSales.Name = "RefreshSales";
            this.RefreshSales.Size = new System.Drawing.Size(358, 58);
            this.RefreshSales.Text = "تحديث";
            this.RefreshSales.Click += new System.EventHandler(this.RefreshSales_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1216, 1567);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(654, 87);
            this.label2.TabIndex = 4;
            this.label2.Text = "المجموع الكلي";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalSum
            // 
            this.lblTotalSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSum.ForeColor = System.Drawing.Color.Red;
            this.lblTotalSum.Location = new System.Drawing.Point(1272, 35);
            this.lblTotalSum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalSum.Name = "lblTotalSum";
            this.lblTotalSum.Size = new System.Drawing.Size(520, 71);
            this.lblTotalSum.TabIndex = 5;
            this.lblTotalSum.Text = "???";
            this.lblTotalSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtordernum
            // 
            this.txtordernum.AutoSize = true;
            this.txtordernum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtordernum.Location = new System.Drawing.Point(476, 46);
            this.txtordernum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtordernum.Name = "txtordernum";
            this.txtordernum.Size = new System.Drawing.Size(160, 55);
            this.txtordernum.TabIndex = 8;
            this.txtordernum.Text = "الطلبيات";
            this.txtordernum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2282, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(441, 55);
            this.label4.TabIndex = 9;
            this.label4.Text = "قائمة المنتوجات المتوفرة ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1210, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 231);
            this.label1.TabIndex = 21;
            this.label1.Text = "كل شي بلاستك \r\n(نقطة بيع)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1208, 448);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 45);
            this.label3.TabIndex = 21;
            this.label3.Text = "ابحث عن اسم المنتج ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSeacrch
            // 
            this.txtSeacrch.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeacrch.Location = new System.Drawing.Point(1216, 496);
            this.txtSeacrch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtSeacrch.Multiline = true;
            this.txtSeacrch.Name = "txtSeacrch";
            this.txtSeacrch.Size = new System.Drawing.Size(636, 92);
            this.txtSeacrch.TabIndex = 22;
            this.txtSeacrch.TextChanged += new System.EventHandler(this.txtSeacrch_TextChanged);
            // 
            // btnAddProdect
            // 
            this.btnAddProdect.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProdect.Location = new System.Drawing.Point(1216, 802);
            this.btnAddProdect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAddProdect.Name = "btnAddProdect";
            this.btnAddProdect.Size = new System.Drawing.Size(640, 96);
            this.btnAddProdect.TabIndex = 23;
            this.btnAddProdect.Text = "المنتجات";
            this.btnAddProdect.UseVisualStyleBackColor = true;
            this.btnAddProdect.Click += new System.EventHandler(this.btnAddProdect_Click);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewOrder.Location = new System.Drawing.Point(1216, 675);
            this.btnNewOrder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(640, 96);
            this.btnNewOrder.TabIndex = 24;
            this.btnNewOrder.Text = "طلب جديد";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click_1);
            // 
            // dgvProdacts
            // 
            this.dgvProdacts.AllowUserToAddRows = false;
            this.dgvProdacts.AllowUserToDeleteRows = false;
            this.dgvProdacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdacts.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvProdacts.Location = new System.Drawing.Point(0, 81);
            this.dgvProdacts.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvProdacts.MultiSelect = false;
            this.dgvProdacts.Name = "dgvProdacts";
            this.dgvProdacts.ReadOnly = true;
            this.dgvProdacts.RowHeadersWidth = 82;
            this.dgvProdacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdacts.Size = new System.Drawing.Size(1200, 1099);
            this.dgvProdacts.TabIndex = 25;
            this.dgvProdacts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProdacts_CellFormatting);
            this.dgvProdacts.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdacts_CellLeave);
            this.dgvProdacts.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProdacts_CellMouseClick);
            this.dgvProdacts.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdacts_CellMouseEnter);
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvSales.Location = new System.Drawing.Point(1876, 81);
            this.dgvSales.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvSales.MultiSelect = false;
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            this.dgvSales.RowHeadersWidth = 82;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new System.Drawing.Size(1200, 1099);
            this.dgvSales.TabIndex = 26;
            this.dgvSales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSales_CellDoubleClick);
            this.dgvSales.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSales_CellMouseClick);
            this.dgvSales.SelectionChanged += new System.EventHandler(this.dgvSales_SelectionChanged);
            this.dgvSales.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvSales_KeyUp);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBarcode.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(0, 0);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(3076, 81);
            this.txtBarcode.TabIndex = 27;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtordernum);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblTotalSum);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 1180);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3076, 137);
            this.panel1.TabIndex = 28;
            // 
            // rbTraders
            // 
            this.rbTraders.AutoSize = true;
            this.rbTraders.Location = new System.Drawing.Point(12, 62);
            this.rbTraders.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbTraders.Name = "rbTraders";
            this.rbTraders.Size = new System.Drawing.Size(74, 29);
            this.rbTraders.TabIndex = 29;
            this.rbTraders.TabStop = true;
            this.rbTraders.Text = "تاجر";
            this.rbTraders.UseVisualStyleBackColor = true;
            this.rbTraders.CheckedChanged += new System.EventHandler(this.rbTraders_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCustomers);
            this.groupBox1.Controls.Add(this.rbTraders);
            this.groupBox1.Location = new System.Drawing.Point(1216, 937);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(634, 106);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "البيع ل";
            // 
            // rbCustomers
            // 
            this.rbCustomers.AutoSize = true;
            this.rbCustomers.Location = new System.Drawing.Point(528, 62);
            this.rbCustomers.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbCustomers.Name = "rbCustomers";
            this.rbCustomers.Size = new System.Drawing.Size(78, 29);
            this.rbCustomers.TabIndex = 30;
            this.rbCustomers.TabStop = true;
            this.rbCustomers.Text = "زبون";
            this.rbCustomers.UseVisualStyleBackColor = true;
            this.rbCustomers.CheckedChanged += new System.EventHandler(this.rbCustomers_CheckedChanged);
            // 
            // frmNewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3076, 1317);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvSales);
            this.Controls.Add(this.dgvProdacts);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.btnAddProdect);
            this.Controls.Add(this.txtSeacrch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmNewOrder";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "نقطة بيع";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNewOrder_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmNewOrder_MouseMove);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalSum;
        private System.Windows.Forms.Label txtordernum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteItemOnSale;
        private System.Windows.Forms.ToolStripMenuItem RefreshSales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSeacrch;
        private System.Windows.Forms.Button btnAddProdect;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.DataGridView dgvProdacts;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbTraders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCustomers;
    }
}