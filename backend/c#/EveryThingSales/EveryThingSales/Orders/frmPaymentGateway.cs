using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using EveryThingSales.General;
using EveryThingSales.Products;
using EveryThingSales.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EveryThingSales.Orders
{
    public partial class frmPaymentGateway : Form
    {

        decimal _AmountRequired = 0;
        int _orderID;
        int currntp1 = 1;
        public frmPaymentGateway(decimal AmountRequired, int orderID)
        {
            InitializeComponent();
            _AmountRequired = AmountRequired;
            _orderID = orderID;
            lblTotalPrice.Text = _AmountRequired.ToString();
            txtbay.Focus();

        }

        private async void btnclos_Click(object sender, EventArgs e)
        {

            while (!this.IsHandleCreated)
                System.Threading.Thread.Sleep(100);

            await bprintRedport();




        }
        async Task bprintRedport()
        {
            Close();

            await Task.Run(() =>
            {
                crPurchasesBill crprint = new crPurchasesBill();


                
                crprint.SetParameterValue("@POrderID", _orderID);
                crprint.SetParameterValue("AmountPaid",txtbay.Text);
                crprint.SetParameterValue("AddPres", txtAddPris.Text);
                // "NPI7AD53F (HP LaserJet M110w)";//"Stikers";//
                crprint.PrintOptions.PrinterName = "Stikers";

                crprint.PrintToPrinter(1, false, 0, 0);

            });

        }


        private void txtbay_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {

                btnclos_Click(null, null);




            }





        }

        private void txtbay_TextChanged(object sender, EventArgs e)
        {
            lblbackMony.Text = (_AmountRequired - clsValidateInputs.TextToDecimal(txtbay.Text)).ToString();
            if(clsValidateInputs.TextToInt(txtbay.Text) <= 0)
            {
                btnplus1.Enabled = false;
                button1.Enabled = false;

            }
            else
            {
                btnplus1.Enabled = true;
                button1.Enabled = true;

            }

        }

        private void EventClickprice(object sender, MouseEventArgs e)
        {


            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _menus(sender);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _add(sender);
            }

            txtbay.Focus();

        }


        void _add(object sender)
        {
            int currnt = 0;

            if (!string.IsNullOrEmpty(txtbay.Text))
            {
                currnt = clsValidateInputs.TextToInt(txtbay.Text);
            }



            txtbay.Text = (currnt += clsValidateInputs.TextToInt(((Button)sender).Text)).ToString();

        }

        void _menus(object sender)
        {
            int currnt = 0;

            if (!string.IsNullOrEmpty(txtbay.Text))
            {
                currnt = clsValidateInputs.TextToInt(txtbay.Text);
            }



            txtbay.Text = (currnt -= clsValidateInputs.TextToInt(((Button)sender).Text)).ToString();

        }


        private void btnplus1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtbay.Text))
            {
                currntp1 = clsValidateInputs.TextToInt(txtbay.Text);
                currntp1++;
                txtbay.Text = currntp1.ToString();
            }
            txtbay.Focus();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbay.Text))
            {
                currntp1 = clsValidateInputs.TextToInt(txtbay.Text);
                currntp1--;
                txtbay.Text = currntp1.ToString();
            }

            txtbay.Focus();
        }

        private void btn10_Click(object sender, EventArgs e)
        {

        }
    }
}
