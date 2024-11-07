using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsKantWingDefault
    {
  
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int KantA { get; set; }
        public int KantB { get; set; }
        public int KantC { get; set; }
        public int KantD { get; set; }
        public int KantE { get; set; }
        public int KantF { get; set; }
        public int KantG { get; set; }
        public int KantH { get; set; }
        public int KantI { get; set; }

       private clsKantWingDefault(int id,string name,string description, int kantA, int kantB, int kantC, int kantD, int kantE, int kantF, int kantG, int kantH, int kantI)
        {
            
           
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.KantA = kantA;
            this.KantB = kantB;
            this.KantC = kantC;
            this.KantD = kantD;
            this.KantE = kantE;
            this.KantF = kantF;
            this.KantG = kantG;
            this.KantH = kantH;
            this.KantI = kantI;

        }

        public static clsKantWingDefault Find(int id)
        {
           
           string  _Name = "";
           string  _Description = "";
           int _KantA = 0;
           int _KantB = 0;
           int _KantC = 0;
           int _KantD = 0;
           int _KantE = 0;
           int _KantF = 0;
           int _KantG = 0;
           int _KantH = 0;
           int _KantI = 0;

            if(clsDAKantWingDefault.GetByID(id,ref _Name,ref _Description,ref _KantA,ref _KantB,ref _KantC,ref _KantD,ref _KantE,ref _KantF,ref _KantG,ref _KantH,ref _KantI))
            {
                return new clsKantWingDefault(id, _Name, _Description, _KantA, _KantB, _KantC, _KantD, _KantE, _KantF, _KantG, _KantH, _KantI);
            }
            else
            {
                return null;
            }

        }
    
    
        private async Task<bool> _UpdateAsync()
        {
            return await clsDAKantWingDefault.UpdateAsync(this.ID, this.Name, this.Description, this.KantA, this.KantB, this.KantC, this.KantD, this.KantE, this.KantF, this.KantG, this.KantH, this.KantI);
        }

        public async Task<bool> SaveAsync()
        {
            return await _UpdateAsync();
        }

        public static async Task<DataTable> GetAllAsync()
        {
            return await clsDAKantWingDefault.GetAllAsync();
        }
    }
}
