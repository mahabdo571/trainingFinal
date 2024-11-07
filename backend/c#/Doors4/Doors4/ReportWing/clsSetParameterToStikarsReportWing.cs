using Doors4.Projects;
using Doors4.Report;
using SharaLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Doors4.ReportWing
{
    internal class clsSetParameterToStikarsReportWing
    {

        clsSetParameterToReportWing _Pprint;

        static string _imagePath = clsSettings.GetData().ImagePath;

        public clsSetParameterToStikarsReportWing(clsSetParameterToReportWing P)
        {

            _Pprint = P;
        }

        public CrpStikarsWing returnReport()
        {
            var newCulture = CultureInfo.CreateSpecificCulture("us");//for lang report

            Thread.CurrentThread.CurrentUICulture = newCulture;
            Thread.CurrentThread.CurrentCulture = newCulture;




            CrpStikarsWing CRreport = new CrpStikarsWing();


            //text
            _checkIfEmptytext("ProjectName", _Pprint.R_ProjectName, CRreport);
            _checkIfEmptytext("customer", _Pprint.R_customer, CRreport);
            _checkIfEmptytext("OrderNo", _Pprint.R_OrderNo, CRreport);
            _checkIfEmptytext("ID", _Pprint.R_ID, CRreport);
            _checkIfEmptytext("Direction", Direction(_Pprint.R_Direction), CRreport);
            _checkIfEmptytext("DoorIdentification", _Pprint.R_DoorIdentification, CRreport);
            _checkIfEmptytext("WingType", _Pprint.R_WingType, CRreport);
            _checkIfEmptytext("Comments", _Pprint.R_Comments, CRreport);
            _checkIfEmptytext("Location", _Pprint.R_Location, CRreport);
            _checkIfEmptytext("Color", _Pprint.R_Colorwing, CRreport);
            _checkIfEmptytext("MeterialWidth", _Pprint.R_MeterialWidth, CRreport);
            _checkIfEmptytext("WingDeptSize", _Pprint.R_WingDeptSize, CRreport);
            _checkIfEmptytext("MesorSofet", FinalSize(), CRreport);
            _checkIfEmptytext("Date11", _Pprint.R_Date11, CRreport);
            _checkIfEmptytext("Injection", _Pprint.R_Injection, CRreport);
            _checkIfEmptytext("MetalMesor", MetalMesor(), CRreport);
            _checkIfEmptytext("PletzMesor", PletzMesor(), CRreport);
            _checkIfEmptytext("FormicaSmallDD", _Pprint.DDWidthFormica2, CRreport);



            return CRreport;


        }

        string PletzMesor()
        {
            if (chechtxt(_Pprint.R_PletzWidth) || chechtxt(_Pprint.R_PletzHight))
            {
                return "Hidd";
            }
            else
            {
                return _Pprint.R_PletzWidth + "X" + _Pprint.R_PletzHight;
            }
        }

        string MetalMesor()
        {
            if (_Pprint.R_Test2 == "A")
            {
                return "Hidd";
            }
            else if (chechtxt(_Pprint.R_MetalWidth) || chechtxt(_Pprint.R_MetalHight))
            {
                return "Hidd";
            }
            else
            {
                return _Pprint.R_MetalWidth + "X" + _Pprint.R_MetalHight;
            }
        }

        bool chechtxt(string Text)
        {
            if (Text == "Empty" || string.IsNullOrEmpty(Text) || Text == "-1" || Text == "0")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        string FinalSize()
        {
            if (!string.IsNullOrEmpty(_Pprint.R_DoorFinalHight))
                return _Pprint.R_DoorFinalWidth + " X " + _Pprint.R_DoorFinalHight;
            else
                return "Hidd";
        }

        string Direction(string txt)
        {
            if (txt == "Right_A")
            {
                return Application.Current.FindResource("lang_btnDirectionRight_AWing").ToString();

            }
            else if (txt == "Right_K")
            {

                return Application.Current.FindResource("lang_btnDirectionRight_KWing").ToString();

            }
            else if (txt == "Left_A")
            {
                return Application.Current.FindResource("lang_btnDirectionLeft_AWing").ToString();

            }
            else if (txt == "Left_K")
            {

                return Application.Current.FindResource("lang_btnDirectionLeft_KWing").ToString();
            }
            else if (txt == "Left")
            {
                return Application.Current.FindResource("lang_btnDirectionLWing").ToString();
            }
            else if (txt == "Right")
            {
                return Application.Current.FindResource("lang_btnDirectionRWing").ToString();
            }
            else
            {
                return "";
            }

        }

        void _checkIfEmptytext(string ParameterInReport, string Text, CrpStikarsWing Report)
        {


            if (Text == "Empty" || string.IsNullOrEmpty(Text) || Text == "-1")
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
