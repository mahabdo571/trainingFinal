using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsGlobalSearch
    {
        public string CompanyName { get; set; }
        public string PhoneNumbe { get; set; }
        public string FullName { get; set; }
        public string CompanyNumber { get; set; }
        public string AccountantNumber { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
        public string Manger { get; set; }
        public string OrderNumber { get; set; }
        public int IDORDER { get; set; }
        public int IDCUSTOMER { get; set; }
        public int IDPROJECT { get; set; }

        private clsGlobalSearch(
            string companyName ,
            string phoneNumbe ,
            string fullName ,
                    string companyNumber ,
                        string accountantNumbe,
                    string projectName ,
            string projectNumber ,
                                string notes ,
                                string address ,
                                        string manger ,
                                        string orderNumber ,
                                                int iDORDER ,
                                                int iDCUSTOMER ,
                                                        int iDPROJECT 
                                                        
            )
        {

            this.CompanyName = companyName;
            this.PhoneNumbe = phoneNumbe;
            this.FullName = fullName;
            this.CompanyNumber = companyNumber;
            this.AccountantNumber = accountantNumbe;
            this.ProjectName = projectName;
            this.ProjectNumber = projectNumber;
            this.Notes = notes;
            this.Address = address;
            this.Manger = manger;
            this.OrderNumber = orderNumber;
            this.IDORDER = iDORDER;
            this.IDCUSTOMER = iDCUSTOMER;
            this.IDPROJECT = iDPROJECT;

            

        }


        public static clsGlobalSearch FindByIDCustomer(int ID)
        {
            string companyName = "";
            string phoneNumbe = "";
            string fullName = "";
            string companyNumber = "";
            string accountantNumbe = "";
            string projectName = "";
            string projectNumber = "";
            string notes = "";
            string address = "";
            string manger = "";
            string orderNumber = "";
            int iDORDER = -1;     
            int iDPROJECT = -1;

            if(clsGlobalSearchDA.GetByIDCUSTOMER(ID,ref companyName,ref phoneNumbe,ref fullName,ref companyNumber,ref accountantNumbe,ref projectName,ref projectNumber,ref notes,ref address,ref manger,ref orderNumber,ref iDORDER,ref iDPROJECT))
            {
                return new clsGlobalSearch( companyName,  phoneNumbe,  fullName,  companyNumber,  accountantNumbe,  projectName,  projectNumber,  notes,  address,  manger,  orderNumber,  iDORDER,ID, iDPROJECT);
            }
            else
            {
                return null;
            }

        }      
        
        public static clsGlobalSearch FindByIDORDER(int ID)
        {
            string companyName = "";
            string phoneNumbe = "";
            string fullName = "";
            string companyNumber = "";
            string accountantNumbe = "";
            string projectName = "";
            string projectNumber = "";
            string notes = "";
            string address = "";
            string manger = "";
            string orderNumber = "";
            int idCoustomer = -1;     
            int iDPROJECT = -1;

            if(clsGlobalSearchDA.GetByIDORDER(ID,ref companyName,ref phoneNumbe,ref fullName,ref companyNumber,ref accountantNumbe,ref projectName,ref projectNumber,ref notes,ref address,ref manger,ref orderNumber,ref idCoustomer, ref iDPROJECT))
            {
                return new clsGlobalSearch( companyName,  phoneNumbe,  fullName,  companyNumber,  accountantNumbe,  projectName,  projectNumber,  notes,  address,  manger,  orderNumber,ID, idCoustomer, iDPROJECT);
            }
            else
            {
                return null;
            }

        }    
        
        public static clsGlobalSearch FindByIDPROJECT(int ID)
        {
            string companyName = "";
            string phoneNumbe = "";
            string fullName = "";
            string companyNumber = "";
            string accountantNumbe = "";
            string projectName = "";
            string projectNumber = "";
            string notes = "";
            string address = "";
            string manger = "";
            string orderNumber = "";
            int idCoustomer = -1;     
            int idorder = -1;

            if(clsGlobalSearchDA.GetByIDPROJECT(ID,ref companyName,ref phoneNumbe,ref fullName,ref companyNumber,ref accountantNumbe,ref projectName,ref projectNumber,ref notes,ref address,ref manger,ref orderNumber,ref idCoustomer,ref idorder))
            {
                return new clsGlobalSearch( companyName,  phoneNumbe,  fullName,  companyNumber,  accountantNumbe,  projectName,  projectNumber,  notes,  address,  manger,  orderNumber, idorder, idCoustomer, ID);
            }
            else
            {
                return null;
            }

        }

        public static async Task<DataTable> GetAll()
        {
            return await clsGlobalSearchDA.GetAll();
        }    
        public static async Task<DataTable> SearchByAny(string any, int PageNumber, int RowsPerPage)
        {
            return await clsGlobalSearchDA.SearchByAny(any,  PageNumber,  RowsPerPage);
        }
    }
}
