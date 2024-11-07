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

namespace Al_Tawfiq_Bakery
{
    public partial  class Home : Form
    {
        public  Home()
        {
            InitializeComponent();
            var start = new Mainstart();
            start.MdiParent = this;
            start.Show();
            //clsPurchases.CallbackEvent += OnCallbackReceived;
            //clsPurchases._getAllData += OnCallbackReceivedAlldata;

        }

        private async void button1_Click(object sender, EventArgs e)
        {

          // await clsPurchases.GetAll();

         
           //  await clsPurchases.Find(1);

            //var ii = new clsPurchases { ProductName = "888888" };
            //var ddd = await ii.Save();
            //if (!ddd.Item2)
            //{
            //    MessageBox.Show(ddd.Item1.Message);
            //}

           
        }

        private  async void OnCallbackReceived(object sender, clsPurchases e)
        {
          //  e.ProductName = textBox1.Text;
          //  e.TotalPrice = (decimal)55.654;
          
          //var (exp, itsok) =  await e.Save();
          //  if (!itsok)
          //  {
          //      MessageBox.Show(exp.Message);
          //  }

        }  
        
        
        private   void OnCallbackReceivedAlldata(string sender, DataTable e)
        {

            //if (sender != "ok")
            //{
            //    MessageBox.Show(sender);
            //}
            //else
            //{
            //    dgvPur.DataSource = e.DefaultView;
            //}

        }
    }
}
