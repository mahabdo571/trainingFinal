using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
   public class clsKantWingManual
    {

        enum Mode { add=1,update=2}

        Mode _mode = Mode.add;

        public int ID { get; set; }
        public int WingID { get; set; }
        public int KantA { get; set; }
        public int KantB { get; set; }
        public int KantC { get; set; }
        public int KantD { get; set; }
        public int KantE { get; set; }
        public int KantF { get; set; }
        public int KantG { get; set; }
        public int KantH { get; set; }
        public int KantI { get; set; }

        private clsKantWingManual(int id,  int kantA, int kantB, int kantC, int kantD, int kantE, int kantF, int kantG, int kantH, int kantI,int wingID)
        {

            this._mode = Mode.update;
            this.ID = id;   
            this.KantA = kantA;
            this.KantB = kantB;
            this.KantC = kantC;
            this.KantD = kantD;
            this.KantE = kantE;
            this.KantF = kantF;
            this.KantG = kantG;
            this.KantH = kantH;
            this.KantI = kantI;
            this.WingID = wingID;

        }    
        
        
        public clsKantWingManual()
        {

            this._mode = Mode.add;
            this.ID = -1;   
            this.KantA = 0;
            this.KantB = 0;
            this.KantC = 0;
            this.KantD = 0;
            this.KantE = 0;
            this.KantF = 0;
            this.KantG = 0;
            this.KantH = 0;
            this.KantI = 0;
            this.WingID = -1;

        }

        public static clsKantWingManual Find(int id)
        {

           
            int _KantA = 0;
            int _KantB = 0;
            int _KantC = 0;
            int _KantD = 0;
            int _KantE = 0;
            int _KantF = 0;
            int _KantG = 0;
            int _KantH = 0;
            int _KantI = 0;
            int _wingId = -1;

            if (clsDAKantWingManual.GetByID(id, ref _KantA, ref _KantB, ref _KantC, ref _KantD, ref _KantE, ref _KantF, ref _KantG, ref _KantH, ref _KantI,ref _wingId))
            {
                return new clsKantWingManual(id, _KantA, _KantB, _KantC, _KantD, _KantE, _KantF, _KantG, _KantH, _KantI,_wingId);
            }
            else
            {
                return null;
            }

        }  
        
        
        public static clsKantWingManual FindByWingID(int Wingid)
        {

           
            int _KantA = 0;
            int _KantB = 0;
            int _KantC = 0;
            int _KantD = 0;
            int _KantE = 0;
            int _KantF = 0;
            int _KantG = 0;
            int _KantH = 0;
            int _KantI = 0;
            int id = -1;

            if (clsDAKantWingManual.GetByWingID(ref id, ref _KantA, ref _KantB, ref _KantC, ref _KantD, ref _KantE, ref _KantF, ref _KantG, ref _KantH, ref _KantI, Wingid))
            {
                return new clsKantWingManual(id, _KantA, _KantB, _KantC, _KantD, _KantE, _KantF, _KantG, _KantH, _KantI, Wingid);
            }
            else
            {
                return null;
            }

        }


        private async Task<bool> _UpdateAsync()
        {
            return await clsDAKantWingManual.UpdateAsync(this.ID,  this.KantA, this.KantB, this.KantC, this.KantD, this.KantE, this.KantF, this.KantG, this.KantH, this.KantI,this.WingID);
        }   
        
        private async Task<bool> _AddAsync()
        {
            this.ID =  await clsDAKantWingManual.AddAsync( this.KantA, this.KantB, this.KantC, this.KantD, this.KantE, this.KantF, this.KantG, this.KantH, this.KantI,this.WingID);

            return this.ID != -1;
        }

        public async Task<bool> SaveAsync()
        {
            switch (_mode)
            {

                case Mode.add:

                    if (await _AddAsync())
                    {
                        _mode = Mode.update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case Mode.update:
                    return await _UpdateAsync();
            }

            return false;
        }

  

    }
}
