using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsWingAddon
    {
        enum myMode { addNew = 1, Update = 2 }

        myMode _mode = myMode.addNew;

        public int ID { get; set; }
        public string StainlessBand { get; set; }
        public string Offirt { get; set; }
        public float ThicknessOffirt { get; set; }
        public bool PullHandle { get; set; }
        public bool ReturnHidden { get; set; }
        public int PullHandleHeight { get; set; }
        public int PullHandleWidth { get; set; }
        public int PullHandleLocationFromBottom { get; set; }
        public int PullHandleLocationFromabove { get; set; }
        public int WingID { get; set; }


        private clsWingAddon(int ID__, string StainlessBand__, string Offirt__,
            float ThicknessOffirt__, bool PullHandle__, bool ReturnHidden__,
            int PullHandleHeight__, int PullHandleWidth__, int PullHandleLocationFromBottom__,
            int PullHandleLocationFromabove__, int WingID__)
        {
            this.ID = ID__;
            this.StainlessBand = StainlessBand__;
            this.Offirt = Offirt__;
            this.ThicknessOffirt = ThicknessOffirt__;
            this.PullHandle = PullHandle__;
            this.ReturnHidden = ReturnHidden__;
            this.PullHandleHeight = PullHandleHeight__;
            this.PullHandleWidth = PullHandleWidth__;
            this.PullHandleLocationFromBottom = PullHandleLocationFromBottom__;
            this.PullHandleLocationFromabove = PullHandleLocationFromabove__;
            this.WingID = WingID__;

            _mode = myMode.Update;
        }

        public clsWingAddon()
        {
            this.ID = -1;
            this.StainlessBand = "";
            this.Offirt = "";
            this.ThicknessOffirt = -1f;
            this.PullHandle = false;
            this.ReturnHidden = false;
            this.PullHandleHeight = -1;
            this.PullHandleWidth = -1;
            this.PullHandleLocationFromBottom = -1;
            this.PullHandleLocationFromabove = -1;
            this.WingID = -1;

            _mode = myMode.addNew;
        }

        public static clsWingAddon Find(int __ID)
        {
           
           string __StainlessBand = "";
           string __Offirt = "";
           float __ThicknessOffirt = -1f;
           bool __PullHandle = false;
           bool __ReturnHidden = false;
           int __PullHandleHeight = -1;
           int __PullHandleWidth = -1;
           int __PullHandleLocationFromBottom = -1;
           int __PullHandleLocationFromabove = -1;
           int __WingID = -1;


            if (clsDataAccessWingAddon.GetByID(__ID, ref __StainlessBand, ref __Offirt, ref __ThicknessOffirt, ref __PullHandle, ref __ReturnHidden, 
                ref __PullHandleHeight, ref __PullHandleWidth,ref __PullHandleLocationFromBottom,ref __PullHandleLocationFromabove,ref __WingID))
            {
                return new clsWingAddon(__ID,  __StainlessBand,  __Offirt,  __ThicknessOffirt,  __PullHandle,  __ReturnHidden,
                 __PullHandleHeight,  __PullHandleWidth,  __PullHandleLocationFromBottom,  __PullHandleLocationFromabove,  __WingID);
            }
            else
            {

                return null;
            }


        }
        public static clsWingAddon FindByWingID(int __WingID)
        {

            string __StainlessBand = "";
            string __Offirt = "";
            float __ThicknessOffirt = -1f;
            bool __PullHandle = false;
            bool __ReturnHidden = false;
            int __PullHandleHeight = -1;
            int __PullHandleWidth = -1;
            int __PullHandleLocationFromBottom = -1;
            int __PullHandleLocationFromabove = -1;
            int __ID = -1;


            if (clsDataAccessWingAddon.GetByWingID(ref __ID, ref __StainlessBand, ref __Offirt, ref __ThicknessOffirt, ref __PullHandle, ref __ReturnHidden,
                ref __PullHandleHeight, ref __PullHandleWidth, ref __PullHandleLocationFromBottom, ref __PullHandleLocationFromabove,  __WingID))
            {
                return new clsWingAddon(__ID, __StainlessBand, __Offirt, __ThicknessOffirt, __PullHandle, __ReturnHidden,
                 __PullHandleHeight, __PullHandleWidth, __PullHandleLocationFromBottom, __PullHandleLocationFromabove, __WingID);
            }
            else
            {

                return null;
            }


        }

        public void copyAddonWing(int wingid)
        {

            this.ID = clsDataAccessWingAddon.Add(this.StainlessBand, this.Offirt, this.ThicknessOffirt,
                this.PullHandle, this.ReturnHidden, this.PullHandleHeight, this.PullHandleWidth, this.PullHandleLocationFromBottom,
                this.PullHandleLocationFromabove,
                wingid);


        }

        private bool _Add()
        {
            this.ID = clsDataAccessWingAddon.Add(this.StainlessBand, this.Offirt, this.ThicknessOffirt,
                this.PullHandle, this.ReturnHidden, this.PullHandleHeight,this.PullHandleWidth,this.PullHandleLocationFromBottom,
                this.PullHandleLocationFromabove,       
                this.WingID);

            return (this.ID != -1);
        }

        private bool _Update()
        {

            return clsDataAccessWingAddon.Update(this.ID, this.StainlessBand, this.Offirt, this.ThicknessOffirt,
                this.PullHandle, this.ReturnHidden, this.PullHandleHeight, this.PullHandleWidth, this.PullHandleLocationFromBottom,
                this.PullHandleLocationFromabove,
                this.WingID);


        }

        public bool Save()

        {

            switch (_mode)
            {

                case myMode.addNew:

                    if (_Add())
                    {
                        _mode = myMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case myMode.Update:
                    return _Update();
            }

            return false;

        }


        public static bool Delete(int ID)
        {
            return clsDataAccessWingAddon.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessWingAddon.GetAll();
        }



        public static bool IsExist(int ID)
        {
            return clsDataAccessWingAddon.IsExist(ID);
        }

        public void clear()
        {
      
            this.StainlessBand = "NoBand";
            this.Offirt = "NoOffirt";
            this.ThicknessOffirt = -1f;
            this.PullHandle = false;
            this.ReturnHidden = false;
            this.PullHandleHeight = -1;
            this.PullHandleWidth = -1;
            this.PullHandleLocationFromBottom = -1;
            this.PullHandleLocationFromabove = -1;
         

            _mode = myMode.Update;
        }
    }
}
