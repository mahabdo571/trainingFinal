using SharaLogic.WingCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doors4.ReportWing
{
    public class clsUpdateSetdataAfterCalc
    {

        clsMainWingCalc _MainCalc;
    

        public clsUpdateSetdataAfterCalc(int id) //stikrs formioca 
        {
          

            _MainCalc = new clsMainWingCalc(id);


            _MainCalc.EXECUTE();


          
            


        }




     public   clsSetParameterToReportWing data()
        {

            clsSetParameterToReportWing p = new clsSetParameterToReportWing();

            //stikrs

            p.R_DoorFinalWidth = _MainCalc.OUT.outDoorFinalWidth.ToString();
            p.R_DoorFinalHight = _MainCalc.OUT.outDoorFinalHight.ToString();

            p.R_ProjectName = _MainCalc.OUT.outProjectName;
            p.R_customer = _MainCalc.OUT.outcustomer;
            p.R_OrderNo = _MainCalc.OUT.outOrderNo;
            p.R_ID = _MainCalc.OUT.outID;
            p.R_DoorIdentification = _MainCalc.OUT.outDoorIdentification;

            p.R_Direction = _MainCalc.OUT.outDirection;
            p.R_WingType = _MainCalc.OUT.outWingType;
            p.R_Comments = _MainCalc.OUT.outComments;
            p.R_Location = _MainCalc.OUT.outLocation;
            p.R_Colorwing = _MainCalc.OUT.outColorwing;
            p.R_MeterialWidth = _MainCalc.OUT.outMeterialWidth;
            p.R_WingDeptSize = _MainCalc.OUT.outWingDeptSize;
            p.R_Date11 = _MainCalc.OUT.outDate11;
            p.R_Injection = _MainCalc.OUT.outInjection;


            return p;
        }
    }
}
