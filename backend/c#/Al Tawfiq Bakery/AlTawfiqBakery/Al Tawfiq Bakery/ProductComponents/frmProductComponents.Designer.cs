namespace Al_Tawfiq_Bakery.ProductComponents
{
    partial class frmProductComponents
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProductComponents = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductComponents
            // 
            this.dgvProductComponents.AllowUserToAddRows = false;
            this.dgvProductComponents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductComponents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductComponents.Location = new System.Drawing.Point(0, 0);
            this.dgvProductComponents.Margin = new System.Windows.Forms.Padding(6);
            this.dgvProductComponents.MultiSelect = false;
            this.dgvProductComponents.Name = "dgvProductComponents";
            this.dgvProductComponents.ReadOnly = true;
            this.dgvProductComponents.RowHeadersWidth = 10;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductComponents.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductComponents.RowTemplate.Height = 70;
            this.dgvProductComponents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductComponents.Size = new System.Drawing.Size(1174, 1329);
            this.dgvProductComponents.TabIndex = 0;
            this.dgvProductComponents.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductComponents_CellContentDoubleClick);
            // 
            // frmProductComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 1329);
            this.Controls.Add(this.dgvProductComponents);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmProductComponents";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "المكونات ";
            this.Load += new System.EventHandler(this.frmProductComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductComponents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductComponents;
    }
}