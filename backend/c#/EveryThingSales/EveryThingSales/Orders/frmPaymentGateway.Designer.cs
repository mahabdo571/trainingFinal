namespace EveryThingSales.Orders
{
    partial class frmPaymentGateway
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblbackMony = new System.Windows.Forms.Label();
            this.btnclos = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn20 = new System.Windows.Forms.Button();
            this.btn15 = new System.Windows.Forms.Button();
            this.btn50 = new System.Windows.Forms.Button();
            this.btn70 = new System.Windows.Forms.Button();
            this.btn200 = new System.Windows.Forms.Button();
            this.btn120 = new System.Windows.Forms.Button();
            this.btn150 = new System.Windows.Forms.Button();
            this.btn170 = new System.Windows.Forms.Button();
            this.btn100 = new System.Windows.Forms.Button();
            this.btnplus1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAddPris = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "المبلغ الكلي للدفع ";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.lblTotalPrice.Location = new System.Drawing.Point(388, 19);
            this.lblTotalPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(490, 45);
            this.lblTotalPrice.TabIndex = 1;
            this.lblTotalPrice.Text = "؟؟؟";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "المبلغ المدفوع";
            // 
            // txtbay
            // 
            this.txtbay.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtbay.Location = new System.Drawing.Point(388, 72);
            this.txtbay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtbay.Multiline = true;
            this.txtbay.Name = "txtbay";
            this.txtbay.Size = new System.Drawing.Size(490, 78);
            this.txtbay.TabIndex = 3;
            this.txtbay.Text = "0";
            this.txtbay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbay.TextChanged += new System.EventHandler(this.txtbay_TextChanged);
            this.txtbay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbay_KeyUp);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(382, 497);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(490, 70);
            this.label3.TabIndex = 4;
            this.label3.Text = "المتبقي للزبون";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblbackMony
            // 
            this.lblbackMony.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblbackMony.ForeColor = System.Drawing.Color.Red;
            this.lblbackMony.Location = new System.Drawing.Point(378, 580);
            this.lblbackMony.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbackMony.Name = "lblbackMony";
            this.lblbackMony.Size = new System.Drawing.Size(490, 63);
            this.lblbackMony.TabIndex = 5;
            this.lblbackMony.Text = "؟؟؟";
            this.lblbackMony.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnclos
            // 
            this.btnclos.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnclos.Location = new System.Drawing.Point(58, 672);
            this.btnclos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnclos.Name = "btnclos";
            this.btnclos.Size = new System.Drawing.Size(822, 127);
            this.btnclos.TabIndex = 6;
            this.btnclos.Text = "طباعة ";
            this.btnclos.UseVisualStyleBackColor = true;
            this.btnclos.Click += new System.EventHandler(this.btnclos_Click);
            // 
            // btn10
            // 
            this.btn10.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn10.Location = new System.Drawing.Point(718, 157);
            this.btn10.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(160, 147);
            this.btn10.TabIndex = 7;
            this.btn10.Text = "10";
            this.btn10.UseVisualStyleBackColor = true;
            this.btn10.Click += new System.EventHandler(this.btn10_Click);
            this.btn10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventClickprice);
            // 
            // btn20
            // 
            this.btn20.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn20.Location = new System.Drawing.Point(388, 161);
            this.btn20.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn20.Name = "btn20";
            this.btn20.Size = new System.Drawing.Size(160, 147);
            this.btn20.TabIndex = 8;
            this.btn20.Text = "20";
            this.btn20.UseVisualStyleBackColor = true;
            this.btn20.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventClickprice);
            // 
            // btn15
            // 
            this.btn15.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn15.Location = new System.Drawing.Point(554, 157);
            this.btn15.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(160, 147);
            this.btn15.TabIndex = 9;
            this.btn15.Text = "15";
            this.btn15.UseVisualStyleBackColor = true;
            this.btn15.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventClickprice);
            // 
            // btn50
            // 
            this.btn50.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn50.Location = new System.Drawing.Point(222, 161);
            this.btn50.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(160, 147);
            this.btn50.TabIndex = 10;
            this.btn50.Text = "50";
            this.btn50.UseVisualStyleBackColor = true;
            this.btn50.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventClickprice);
            // 
            // btn70
            // 
            this.btn70.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn70.Location = new System.Drawing.Point(58, 161);
            this.btn70.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn70.Name = "btn70";
            this.btn70.Size = new System.Drawing.Size(160, 147);
            this.btn70.TabIndex = 11;
            this.btn70.Text = "70";
            this.btn70.UseVisualStyleBackColor = true;
            this.btn70.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventClickprice);
            // 
            // btn200
            // 
            this.btn200.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn200.Location = new System.Drawing.Point(58, 310);
            this.btn200.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn200.Name = "btn200";
            this.btn200.Size = new System.Drawing.Size(160, 147);
            this.btn200.TabIndex = 12;
            this.btn200.Text = "200";
            this.btn200.UseVisualStyleBackColor = true;
            this.btn200.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventClickprice);
            // 
            // btn120
            // 
            this.btn120.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn120.Location = new System.Drawing.Point(554, 314);
            this.btn120.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn120.Name = "btn120";
            this.btn120.Size = new System.Drawing.Size(160, 147);
            this.btn120.TabIndex = 13;
            this.btn120.Text = "120";
            this.btn120.UseVisualStyleBackColor = true;
            this.btn120.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventClickprice);
            // 
            // btn150
            // 
            this.btn150.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn150.Location = new System.Drawing.Point(388, 314);
            this.btn150.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn150.Name = "btn150";
            this.btn150.Size = new System.Drawing.Size(160, 147);
            this.btn150.TabIndex = 14;
            this.btn150.Text = "150";
            this.btn150.UseVisualStyleBackColor = true;
            this.btn150.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventClickprice);
            // 
            // btn170
            // 
            this.btn170.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn170.Location = new System.Drawing.Point(222, 310);
            this.btn170.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn170.Name = "btn170";
            this.btn170.Size = new System.Drawing.Size(160, 147);
            this.btn170.TabIndex = 15;
            this.btn170.Text = "170";
            this.btn170.UseVisualStyleBackColor = true;
            this.btn170.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventClickprice);
            // 
            // btn100
            // 
            this.btn100.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn100.Location = new System.Drawing.Point(718, 314);
            this.btn100.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(160, 147);
            this.btn100.TabIndex = 16;
            this.btn100.Text = "100";
            this.btn100.UseVisualStyleBackColor = true;
            this.btn100.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EventClickprice);
            // 
            // btnplus1
            // 
            this.btnplus1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnplus1.Location = new System.Drawing.Point(222, 497);
            this.btnplus1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnplus1.Name = "btnplus1";
            this.btnplus1.Size = new System.Drawing.Size(134, 123);
            this.btnplus1.TabIndex = 12;
            this.btnplus1.Text = "+1";
            this.btnplus1.UseVisualStyleBackColor = true;
            this.btnplus1.Click += new System.EventHandler(this.btnplus1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Location = new System.Drawing.Point(58, 497);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 123);
            this.button1.TabIndex = 17;
            this.button1.Text = "-1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAddPris
            // 
            this.txtAddPris.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAddPris.Location = new System.Drawing.Point(747, 580);
            this.txtAddPris.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAddPris.Multiline = true;
            this.txtAddPris.Name = "txtAddPris";
            this.txtAddPris.Size = new System.Drawing.Size(130, 86);
            this.txtAddPris.TabIndex = 18;
            this.txtAddPris.Text = "0";
            this.txtAddPris.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(811, 561);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "خصم اضافي";
            // 
            // frmPaymentGateway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 792);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddPris);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.btn170);
            this.Controls.Add(this.btn150);
            this.Controls.Add(this.btn120);
            this.Controls.Add(this.btnplus1);
            this.Controls.Add(this.btn200);
            this.Controls.Add(this.btn70);
            this.Controls.Add(this.btn50);
            this.Controls.Add(this.btn15);
            this.Controls.Add(this.btn20);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.btnclos);
            this.Controls.Add(this.lblbackMony);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmPaymentGateway";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "الدفع";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblbackMony;
        private System.Windows.Forms.Button btnclos;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn20;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Button btn50;
        private System.Windows.Forms.Button btn70;
        private System.Windows.Forms.Button btn200;
        private System.Windows.Forms.Button btn120;
        private System.Windows.Forms.Button btn150;
        private System.Windows.Forms.Button btn170;
        private System.Windows.Forms.Button btn100;
        private System.Windows.Forms.Button btnplus1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAddPris;
        private System.Windows.Forms.Label label4;
    }
}