using Doors4.Projects;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doors4.Report
{
    public class clsSetParameterToStikarsReport
    {


        clsParameterForPrint _Pprint;

        static string _imagePath = clsSettings.GetData().ImagePath;

        public clsSetParameterToStikarsReport(clsParameterForPrint P)
        {

            _Pprint = P;
        }

        public CrpStikarsFrame returnReport()
        {
            var newCulture = CultureInfo.CreateSpecificCulture("us");//for lang report

            Thread.CurrentThread.CurrentUICulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;




            CrpStikarsFrame CRreport = new CrpStikarsFrame();

            string HingeConection()
            {
                if (_Pprint.HingeConection == "Hole")
                {
                    return "מוברג";
                }
                else if (_Pprint.HingeConection == "Soldering")
                {
                    return "מרותך";
                }
                else
                {
                    return "Hidd";
                }

            }

            //text
            _checkIfEmptytext("FrameType", _Pprint.FrameType1, CRreport);
            _checkIfEmptytext("OrderNo", _Pprint.OrderNo1, CRreport);
            _checkIfEmptytext("ID", _Pprint.ID, CRreport);
            _checkIfEmptytext("DoorIdentification", _Pprint.DoorIdentification1, CRreport);
            _checkIfEmptytext("Metal", _Pprint.Metal1, CRreport);
            _checkIfEmptytext("MetalWidth", _Pprint.MetalWidth1, CRreport);
            _checkIfEmptytext("LockType", _Pprint.LockType1, CRreport);
            _checkIfEmptytext("Direction", _Pprint.Direction1, CRreport);
            _checkIfEmptytext("Location", _Pprint.Location1, CRreport);
            _checkIfEmptytext("ProjectName", _Pprint.ProjectName1, CRreport);
            _checkIfEmptytext("Date11", _Pprint.Date111, CRreport);
            _checkIfEmptytext("PlatzFrameSize1", _Pprint.PlatzFrameSize11, CRreport);
            _checkIfEmptytext("FrameSize1", _Pprint.FrameSize11, CRreport);
            _checkIfEmptytext("customer", _Pprint.customer1, CRreport);
            _checkIfEmptytext("Comments", _Pprint.CommentStikrs, CRreport);
            _checkIfEmptytext("Mekasher", _Pprint.Mekasher, CRreport);
            _checkIfEmptytext("HingeType", _Pprint.HingeType, CRreport);
            _checkIfEmptytext("HingeConection", HingeConection(), CRreport);
            return CRreport;


        }

      

        void _checkIfEmptytext(string ParameterInReport, string Text, CrpStikarsFrame Report)
        {


            if (Text == "Empty" || Text == null)
            {
                Report.SetParameterValue(ParameterInReport, "Hidd");


            }
            else
            {
                Report.SetParameterValue(ParameterInReport, Text);
            }
        }
    


}
}
