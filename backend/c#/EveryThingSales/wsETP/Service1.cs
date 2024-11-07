using EveryThingSales;
using EveryThingSales.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace wsETP
{
    public partial class Service1 : ServiceBase
    {
        int _orderid;
        public Service1(int orderID)
        {
            InitializeComponent();
            _orderid = orderID;
        }

        protected override void OnStart(string[] args)
        {
            bprintRedport();
        }
         void bprintRedport()
        {

            crPurchasesBill crprint = new crPurchasesBill();

           

            //crprint.SetParameterValue("@POrderID", _orderid);
            //// "NPI7AD53F (HP LaserJet M110w)";//
            //crprint.PrintOptions.PrinterName = "Microsoft Print to PDF";

            //crprint.PrintToPrinter(1, false, 0, 0);
        }

        protected override void OnStop()
        {
            
        }
    }
}
