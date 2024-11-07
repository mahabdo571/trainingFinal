using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsWingAdvanced
    {
        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;
        public int ID { get; set; }
        public int WingShorteningFromBottom { get; set; }
        public int WingShorteningFromAbove { get; set; }
        public int ThicknessWing { get; set; }
        public bool EvacuationHandle { get; set; }
        public bool PushSideLever { get; set; }
        public bool PushHandle { get; set; }
        public bool PullSideLever { get; set; }
        public bool PullHandle { get; set; }
        public bool HandleHoles { get; set; }
        public bool ClearanceTheCylinder { get; set; }
        public bool Cylinder { get; set; }
        public bool HolesCylinder { get; set; }
        public int WingID { get; set; }

        public bool woodLockBasic { get; set; }
        public bool woodUpeerLock { get; set; }
        public bool woodBehalaLock { get; set; }
        public bool woodSpeacilCasesHingeUP { get; set; }
        public bool woodSpeacilCasesHingeDN { get; set; }
        public int woodLockBasicWidth { get; set; }
        public int woodLockBasicHeight { get; set; }
        public int woodLockBasicLocation { get; set; }
        public int woodUpeerWidth { get; set; }
        public int woodUpeerHeight { get; set; }
        public int woodUpeerLockLocation { get; set; }
        public int woodBehalaLockWidth { get; set; }
        public int woodBehalaLockHeight { get; set; }
        public int woodBehalaLockLocation { get; set; }
        public int woodSpeacilCasesHingeUPWidth { get; set; }
        public int woodSpeacilCasesHingeUPHeight { get; set; }
        public int woodSpeacilCasesHingeUPLocation { get; set; }
        public int woodSpeacilCasesHingeDNWidth { get; set; }
        public int woodSpeacilCasesHingeDNHeight { get; set; }
        public int woodSpeacilCasesHingeDNLocation { get; set; }
        public int KantA { get; set; }
        public int KantB { get; set; }
        public bool woodBehalaLockManual { get; set; }

        public clsWings Wing { get; set; }

        public clsKantWingManual KantManual;

        private clsWingAdvanced(
              int __ID,
  int __WingShorteningFromBottom,
  int __WingShorteningFromAbove,
  int __ThicknessWing,
  bool __EvacuationHandle,

    bool __PullSideLever,
  bool __PushHandle,
    bool __PushSideLever,
  bool __PullHandle,
  bool __HandleHoles,
  bool __ClearanceTheCylinder,
  bool __Cylinder,
  bool __HolesCylinder,
  int __WingID,

   bool woodLockBasic_,
 bool woodUpeerLock_,
 bool woodBehalaLock_,
 bool woodSpeacilCasesHingeUP_,
bool woodSpeacilCasesHingeDN_,
 int woodLockBasicWidth_,
int woodLockBasicHeight_,
int woodLockBasicLocation_,
 int woodUpeerWidth_,
 int woodUpeerHeight_,
int woodUpeerLockLocation_,
int woodBehalaLockWidth_,
 int woodBehalaLockHeight_,
 int woodBehalaLockLocation_,
int woodSpeacilCasesHingeUPWidth_,
 int woodSpeacilCasesHingeUPHeight_,
 int woodSpeacilCasesHingeUPLocation_,
 int woodSpeacilCasesHingeDNWidth_,
int woodSpeacilCasesHingeDNHeight_,
 int woodSpeacilCasesHingeDNLocation_,
 int KantA_,
 int KantB_,bool woodBehalaLockManual_

            )
        {

            this.ID = __ID;
            this.WingShorteningFromBottom = __WingShorteningFromBottom;
            this.WingShorteningFromAbove = __WingShorteningFromAbove;
            this.ThicknessWing = __ThicknessWing;
            this.EvacuationHandle = __EvacuationHandle;
            this.PushSideLever = __PushSideLever;
            this.PushHandle = __PushHandle;
            this.PullSideLever = __PullSideLever;
            this.PullHandle = __PullHandle;
            this.HandleHoles = __HandleHoles;
            this.ClearanceTheCylinder = __ClearanceTheCylinder;
            this.Cylinder = __Cylinder;
            this.HolesCylinder = __HolesCylinder;
            this.WingID = __WingID;

            this.woodLockBasic = woodLockBasic_;
            this.woodUpeerLock = woodUpeerLock_;
            this.woodBehalaLock = woodBehalaLock_;
            this.woodSpeacilCasesHingeUP = woodSpeacilCasesHingeUP_;
            this.woodSpeacilCasesHingeDN = woodSpeacilCasesHingeDN_;
            this.woodLockBasicWidth = woodLockBasicWidth_;
            this.woodLockBasicHeight = woodLockBasicHeight_;
            this.woodLockBasicLocation = woodLockBasicLocation_;
            this.woodUpeerWidth = woodUpeerWidth_;
            this.woodUpeerHeight = woodUpeerHeight_;
            this.woodUpeerLockLocation = woodUpeerLockLocation_;
            this.woodBehalaLockWidth = woodBehalaLockWidth_;
            this.woodBehalaLockHeight = woodBehalaLockHeight_;
            this.woodBehalaLockLocation = woodBehalaLockLocation_;
            this.woodSpeacilCasesHingeUPWidth = woodSpeacilCasesHingeUPWidth_;
            this.woodSpeacilCasesHingeUPHeight = woodSpeacilCasesHingeUPHeight_;
            this.woodSpeacilCasesHingeUPLocation = woodSpeacilCasesHingeUPLocation_;
            this.woodSpeacilCasesHingeDNWidth = woodSpeacilCasesHingeDNWidth_;
            this.woodSpeacilCasesHingeDNHeight = woodSpeacilCasesHingeDNHeight_;
            this.woodSpeacilCasesHingeDNLocation = woodSpeacilCasesHingeDNLocation_;
            this.KantA = KantA_;
            this.KantB = KantB_;
            this.woodBehalaLockManual = woodBehalaLockManual_;

            this.Wing = clsWings.Find(__WingID);
            this.KantManual = clsKantWingManual.FindByWingID(__WingID);
            this._Mode = _myMode.Update;

        }

        public clsWingAdvanced()
        {
            this.ID = -1;
            this.WingShorteningFromBottom = -1;
            this.WingShorteningFromAbove = -1;
            this.ThicknessWing = -1;
            this.EvacuationHandle = false;
            this.PushSideLever = false;
            this.PushHandle = false;
            this.PullSideLever = false;
            this.PullHandle = false;
            this.HandleHoles = false;
            this.ClearanceTheCylinder = false;
            this.Cylinder = false;
            this.HolesCylinder = false;
            this.WingID = -1;
             this.woodLockBasic = false;
             this.woodUpeerLock = false;
             this.woodBehalaLock = false;
             this.woodSpeacilCasesHingeUP = false;
             this.woodSpeacilCasesHingeDN = false;
             this.woodBehalaLockManual = false;
             this.woodLockBasicWidth = -1;
             this.woodLockBasicHeight = -1;
             this.woodLockBasicLocation = -1;
             this.woodUpeerWidth = -1;
             this.woodUpeerHeight = -1;
             this.woodUpeerLockLocation = -1;
             this.woodBehalaLockWidth = -1;
             this.woodBehalaLockHeight = -1;
             this.woodBehalaLockLocation = -1;
             this.woodSpeacilCasesHingeUPWidth = -1;
             this.woodSpeacilCasesHingeUPHeight = -1;
             this.woodSpeacilCasesHingeUPLocation = -1;
             this.woodSpeacilCasesHingeDNWidth = -1;
             this.woodSpeacilCasesHingeDNHeight = -1;
            this.woodSpeacilCasesHingeDNLocation=-1;
            this.KantA=0;
            this.KantB= 0;
            this._Mode = _myMode.Addnew;
        }


        public static clsWingAdvanced Find(int __ID)
        {



            int __WingShorteningFromBottom = -1;
            int __WingShorteningFromAbove = -1;
            int __ThicknessWing = -1;
            bool __EvacuationHandle = false;
            bool __PushSideLever = false;
            bool __PushHandle = false;
            bool __PullSideLever = false;
            bool __PullHandle = false;
            bool __HandleHoles = false;
            bool __ClearanceTheCylinder = false;
            bool __Cylinder = false;
            bool __HolesCylinder = false;
            int __WingID = -1;

            bool woodLockBasic__ = false;
            bool woodUpeerLock__ = false;
            bool woodBehalaLock__ = false;
            bool woodSpeacilCasesHingeUP__ = false;
            bool woodSpeacilCasesHingeDN__ =false;
            bool woodBehalaLockManual_ = false;
            int woodLockBasicWidth__ = -1;
            int woodLockBasicHeight__ = -1;
            int woodLockBasicLocation__ = -1;
            int woodUpeerWidth__ = -1;
            int woodUpeerHeight__ = -1;
            int woodUpeerLockLocation__ = -1;
            int woodBehalaLockWidth__ = -1;
            int woodBehalaLockHeight__ = -1;
            int woodBehalaLockLocation__ = -1;
            int woodSpeacilCasesHingeUPWidth__ = -1;
            int woodSpeacilCasesHingeUPHeight__ = -1;
            int woodSpeacilCasesHingeUPLocation__ = -1;
            int woodSpeacilCasesHingeDNWidth__ = -1;
            int woodSpeacilCasesHingeDNHeight__ = -1;
            int woodSpeacilCasesHingeDNLocation = -1;
            int kanA = 0;
            int kanB = 0;

            if (clsDataAccessWingAdvanced.GetByID(__ID, ref __WingShorteningFromBottom, ref __WingShorteningFromAbove, ref __ThicknessWing, ref __EvacuationHandle, ref __PullSideLever, ref __PushHandle, ref __PushSideLever, ref __PullHandle, ref __HandleHoles,
            ref __ClearanceTheCylinder, ref __Cylinder, ref __HolesCylinder, ref __WingID,

 ref    woodLockBasic__,
 ref woodUpeerLock__, 
 ref woodBehalaLock__, ref
woodSpeacilCasesHingeUP__, ref
woodSpeacilCasesHingeDN__, ref
woodLockBasicWidth__, ref
woodLockBasicHeight__, ref
woodLockBasicLocation__, ref
woodUpeerWidth__, ref
woodUpeerHeight__, ref
woodUpeerLockLocation__, ref
woodBehalaLockWidth__, ref
woodBehalaLockHeight__, ref
woodBehalaLockLocation__, ref
woodSpeacilCasesHingeUPWidth__, ref
woodSpeacilCasesHingeUPHeight__, ref
woodSpeacilCasesHingeUPLocation__, ref
woodSpeacilCasesHingeDNWidth__, ref
woodSpeacilCasesHingeDNHeight__, ref
woodSpeacilCasesHingeDNLocation,ref kanA,ref kanB,ref woodBehalaLockManual_

            ))
            {
                return new clsWingAdvanced(__ID, __WingShorteningFromBottom, __WingShorteningFromAbove, __ThicknessWing, __EvacuationHandle, __PullSideLever, __PushHandle, __PushSideLever, __PullHandle, __HandleHoles,
             __ClearanceTheCylinder, __Cylinder, __HolesCylinder, __WingID,
               woodLockBasic__,
  woodUpeerLock__,
  woodBehalaLock__, 
woodSpeacilCasesHingeUP__, 
woodSpeacilCasesHingeDN__, 
woodLockBasicWidth__, 
woodLockBasicHeight__, 
woodLockBasicLocation__, 
woodUpeerWidth__, 
woodUpeerHeight__, 
woodUpeerLockLocation__, 
woodBehalaLockWidth__, 
woodBehalaLockHeight__, 
woodBehalaLockLocation__, 
woodSpeacilCasesHingeUPWidth__, 
woodSpeacilCasesHingeUPHeight__, 
woodSpeacilCasesHingeUPLocation__, 
woodSpeacilCasesHingeDNWidth__, 
woodSpeacilCasesHingeDNHeight__, 
woodSpeacilCasesHingeDNLocation,kanA,kanB, woodBehalaLockManual_

             );

            }
            else
            {
                return null;
            }

        }


        public static clsWingAdvanced FindByWingID(int __WingID)
        {



            int __WingShorteningFromBottom = -1;
            int __WingShorteningFromAbove = -1;
            int __ThicknessWing = -1;
            bool __EvacuationHandle = false;
            bool __PushSideLever = false;
            bool __PushHandle = false;
            bool __PullSideLever = false;
            bool __PullHandle = false;
            bool __HandleHoles = false;
            bool __ClearanceTheCylinder = false;
            bool __Cylinder = false;
            bool __HolesCylinder = false;
            int __ID = -1;
            bool woodLockBasic__ = false;
            bool woodUpeerLock__ = false;
            bool woodBehalaLock__ = false;
            bool woodSpeacilCasesHingeUP__ = false;
            bool woodSpeacilCasesHingeDN__ = false;
            bool woodBehalaLockManual_ = false;
            int woodLockBasicWidth__ = -1;
            int woodLockBasicHeight__ = -1;
            int woodLockBasicLocation__ = -1;
            int woodUpeerWidth__ = -1;
            int woodUpeerHeight__ = -1;
            int woodUpeerLockLocation__ = -1;
            int woodBehalaLockWidth__ = -1;
            int woodBehalaLockHeight__ = -1;
            int woodBehalaLockLocation__ = -1;
            int woodSpeacilCasesHingeUPWidth__ = -1;
            int woodSpeacilCasesHingeUPHeight__ = -1;
            int woodSpeacilCasesHingeUPLocation__ = -1;
            int woodSpeacilCasesHingeDNWidth__ = -1;
            int woodSpeacilCasesHingeDNHeight__ = -1;
            int woodSpeacilCasesHingeDNLocation = -1;
            int kanA = 0;
            int kanB = 0;
            if (clsDataAccessWingAdvanced.GetByWingID(ref __ID, ref __WingShorteningFromBottom, ref __WingShorteningFromAbove, ref __ThicknessWing, ref __EvacuationHandle, ref __PullSideLever, ref __PushHandle, ref __PushSideLever, ref __PullHandle, ref __HandleHoles,
            ref __ClearanceTheCylinder, ref __Cylinder, ref __HolesCylinder, __WingID,
             ref woodLockBasic__,
 ref woodUpeerLock__,
 ref woodBehalaLock__, ref
woodSpeacilCasesHingeUP__, ref
woodSpeacilCasesHingeDN__, ref
woodLockBasicWidth__, ref
woodLockBasicHeight__, ref
woodLockBasicLocation__, ref
woodUpeerWidth__, ref
woodUpeerHeight__, ref
woodUpeerLockLocation__, ref
woodBehalaLockWidth__, ref
woodBehalaLockHeight__, ref
woodBehalaLockLocation__, ref
woodSpeacilCasesHingeUPWidth__, ref
woodSpeacilCasesHingeUPHeight__, ref
woodSpeacilCasesHingeUPLocation__, ref
woodSpeacilCasesHingeDNWidth__, ref
woodSpeacilCasesHingeDNHeight__, ref
woodSpeacilCasesHingeDNLocation, ref kanA, ref kanB,ref woodBehalaLockManual_

            ))
            {
                return new clsWingAdvanced(__ID, __WingShorteningFromBottom, __WingShorteningFromAbove, __ThicknessWing, __EvacuationHandle, __PullSideLever, __PushHandle, __PushSideLever, __PullHandle, __HandleHoles,
             __ClearanceTheCylinder, __Cylinder, __HolesCylinder, __WingID,

                            woodLockBasic__,
  woodUpeerLock__,
  woodBehalaLock__,
woodSpeacilCasesHingeUP__,
woodSpeacilCasesHingeDN__,
woodLockBasicWidth__,
woodLockBasicHeight__,
woodLockBasicLocation__,
woodUpeerWidth__,
woodUpeerHeight__,
woodUpeerLockLocation__,
woodBehalaLockWidth__,
woodBehalaLockHeight__,
woodBehalaLockLocation__,
woodSpeacilCasesHingeUPWidth__,
woodSpeacilCasesHingeUPHeight__,
woodSpeacilCasesHingeUPLocation__,
woodSpeacilCasesHingeDNWidth__,
woodSpeacilCasesHingeDNHeight__,
woodSpeacilCasesHingeDNLocation,  kanA,  kanB, woodBehalaLockManual_


             );

            }
            else
            {
                return null;
            }

        }

        public void copyAdvdonWing(int idwing)
        {

            this.ID = clsDataAccessWingAdvanced.Add(this.WingShorteningFromBottom, this.WingShorteningFromAbove
                , this.ThicknessWing, this.EvacuationHandle, this.PushSideLever, this.PushHandle, this.PullSideLever,
                this.PullHandle, this.HandleHoles, this.ClearanceTheCylinder, this.Cylinder, this.HolesCylinder,
                idwing, this.woodLockBasic,
 this.woodUpeerLock,
                this.woodBehalaLock,
this.woodSpeacilCasesHingeUP,
 this.woodSpeacilCasesHingeDN,
 this.woodLockBasicWidth,
this.woodLockBasicHeight,
this.woodLockBasicLocation,
 this.woodUpeerWidth,
 this.woodUpeerHeight,
this.woodUpeerLockLocation,
this.woodBehalaLockWidth,
 this.woodBehalaLockHeight,
 this.woodBehalaLockLocation,
this.woodSpeacilCasesHingeUPWidth,
 this.woodSpeacilCasesHingeUPHeight,
 this.woodSpeacilCasesHingeUPLocation,
 this.woodSpeacilCasesHingeDNWidth,
this.woodSpeacilCasesHingeDNHeight,
 this.woodSpeacilCasesHingeDNLocation,this.KantA,this.KantB,this.woodBehalaLockManual);

        }

        private bool _AddNew()
        {


            this.ID = clsDataAccessWingAdvanced.Add(this.WingShorteningFromBottom, this.WingShorteningFromAbove
                , this.ThicknessWing, this.EvacuationHandle, this.PushSideLever, this.PushHandle, this.PullSideLever,
                this.PullHandle, this.HandleHoles, this.ClearanceTheCylinder, this.Cylinder, this.HolesCylinder,
                this.WingID, this.woodLockBasic,
 this.woodUpeerLock,
                this.woodBehalaLock,
this.woodSpeacilCasesHingeUP,
 this.woodSpeacilCasesHingeDN,
 this.woodLockBasicWidth,
this.woodLockBasicHeight,
this.woodLockBasicLocation,
 this.woodUpeerWidth,
 this.woodUpeerHeight,
this.woodUpeerLockLocation,
this.woodBehalaLockWidth,
 this.woodBehalaLockHeight,
 this.woodBehalaLockLocation,
this.woodSpeacilCasesHingeUPWidth,
 this.woodSpeacilCasesHingeUPHeight,
 this.woodSpeacilCasesHingeUPLocation,
 this.woodSpeacilCasesHingeDNWidth,
this.woodSpeacilCasesHingeDNHeight,
 this.woodSpeacilCasesHingeDNLocation, this.KantA, this.KantB,this.woodBehalaLockManual);

            return (this.ID != -1);
        }

        private bool _Update()
        {


            return clsDataAccessWingAdvanced.Update(this.ID,
                this.WingShorteningFromBottom, this.WingShorteningFromAbove
                , this.ThicknessWing, this.EvacuationHandle, this.PushSideLever, this.PushHandle, this.PullSideLever,
                this.PullHandle, this.HandleHoles, this.ClearanceTheCylinder, this.Cylinder, this.HolesCylinder,



                this.WingID
                , this.woodLockBasic,
 this.woodUpeerLock,
                this.woodBehalaLock,
this.woodSpeacilCasesHingeUP,
 this.woodSpeacilCasesHingeDN,
 this.woodLockBasicWidth,
this.woodLockBasicHeight,
this.woodLockBasicLocation,
 this.woodUpeerWidth,
 this.woodUpeerHeight,
this.woodUpeerLockLocation,
this.woodBehalaLockWidth,
 this.woodBehalaLockHeight,
 this.woodBehalaLockLocation,
this.woodSpeacilCasesHingeUPWidth,
 this.woodSpeacilCasesHingeUPHeight,
 this.woodSpeacilCasesHingeUPLocation,
 this.woodSpeacilCasesHingeDNWidth,
this.woodSpeacilCasesHingeDNHeight,
 this.woodSpeacilCasesHingeDNLocation, this.KantA, this.KantB,this.woodBehalaLockManual


                );

        }


        public bool Save()

        {

            switch (_Mode)
            {

                case _myMode.Addnew:

                    if (_AddNew())
                    {
                        _Mode = _myMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case _myMode.Update:
                    return _Update();
            }

            return false;

        }


        public async void CalcKant()
        {
          
            if(this.ThicknessWing != 45 && this.Wing != null && this.Wing.WingType != null && this.Wing.WingType.TEST2 == "A")
            {
                if (this.KantManual != null)
                {
                    this.KantManual.KantA = (this.ThicknessWing - 2);
                }

            }else if (this.ThicknessWing != 45 && this.Wing != null && this.Wing.WingType != null && this.Wing.WingType.TEST2 == "F")
            {
                if (this.KantManual != null)
                {
                    this.KantManual.KantA = (this.ThicknessWing - ((int)Wing.FormaicaThickness * 2));

                    if (this.Wing.WingType.TEST3 == "0" || this.Wing.WingType.TEST3 == "Medic")
                    {
                        this.KantManual.KantB = this.KantA;
                    }
                    else
                    {
                        this.KantManual.KantB = 0;
                    }
                }
            }
            else
            {
                if (this.KantManual != null)
                {
                    this.KantManual.KantA = 0;
                }

            }
            if (this.KantManual != null)
            {
                await this.KantManual.SaveAsync();
            }
        }


        public static bool Delete(int ID)
        {
            return clsDataAccessWingAdvanced.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessWingAdvanced.GetAll();
        }

        public static bool IsExist(int ID)
        {
            return clsDataAccessWingAdvanced.IsExist(ID);
        }

        public void clear()
        {
          
            this.WingShorteningFromBottom = -1;
            this.WingShorteningFromAbove = -1;
            this.ThicknessWing = 45;
            this.EvacuationHandle = false;
            this.PushSideLever = true;
            this.PushHandle = false;
            this.PullSideLever = true;
            this.PullHandle = false;
            this.HandleHoles = true;
            this.ClearanceTheCylinder = true;
            this.Cylinder = true;
            this.HolesCylinder = true;  
            this.woodLockBasic = true;
            this.woodUpeerLock = false;
            this.woodBehalaLock = false;
            this.woodSpeacilCasesHingeUP = false;
            this.woodSpeacilCasesHingeDN = false;
            this.woodBehalaLockManual = false;
            this.woodLockBasicWidth = -1;
            this.woodLockBasicHeight = -1;
            this.woodLockBasicLocation = -1;
            this.woodUpeerWidth = -1;
            this.woodUpeerHeight = -1;
            this.woodUpeerLockLocation = -1;
            this.woodBehalaLockWidth = -1;
            this.woodBehalaLockHeight = -1;
            this.woodBehalaLockLocation = -1;
            this.woodSpeacilCasesHingeUPWidth = -1;
            this.woodSpeacilCasesHingeUPHeight = -1;
            this.woodSpeacilCasesHingeUPLocation = -1;
            this.woodSpeacilCasesHingeDNWidth = -1;
            this.woodSpeacilCasesHingeDNHeight = -1;
            this.woodSpeacilCasesHingeDNLocation = -1;
            this.KantA = 0;
            this.KantB = 0;
            this._Mode = _myMode.Update;
        }

    }
}
