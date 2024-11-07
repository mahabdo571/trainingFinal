using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsCustomers
    {



        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;

        public int ID { get; set; }
        public string FullName { get; set; }
        public string identityNumber { get; set; }
        public string PhoneNumbe { get; set; }
        public string PhoneNumbe2 { get; set; }
        public string CompanyName { get; set; }
        public int CompanyNumber { get; set; }
        public string Email { get; set; }
        public int AccountantNumber { get; set; }
        public DateTime UpdateDate { get; set; }






        private clsCustomers(int id, string fullname, string identity, string phone1, string phone2, string coName, int coNum, int accountan, string email,DateTime updateDate)

        {
            this.ID = id;
            this.FullName = fullname;
            this.identityNumber = identity;
            this.PhoneNumbe = phone1;
            this.PhoneNumbe2 = phone2;
            this.CompanyName = coName;
            this.CompanyNumber = coNum;
            this.AccountantNumber = accountan;
            this.Email = email;
            this.UpdateDate = updateDate;

            this._Mode = _myMode.Update;

        }

        public clsCustomers()
        {

            this._Mode = _myMode.Addnew;

            this.ID = -1;
            this.FullName = "";
            this.identityNumber = "";
            this.PhoneNumbe = "";
            this.PhoneNumbe2 = "";
            this.CompanyName = "";
            this.CompanyNumber = -1;
            this.AccountantNumber = -1;
            this.Email = "";
            this.UpdateDate = DateTime.Now;



        }


        public static clsCustomers Find(int Id)
        {


            int accountantNumber = -1;
            string fullName = "";
            string identity = "";
            string ph1 = "";
            string ph2 = "";
            string email = "";
            string coName = "";
            int coNo = -1;
            DateTime updateDate = DateTime.Now ;


            if (clsDataAccessCustomers.GetCustomersByID(Id, ref fullName, ref identity, ref ph1, ref ph2, ref coName, ref coNo, ref accountantNumber, ref email,ref updateDate))
            {
                return new clsCustomers(Id, fullName, identity, ph1, ph2, coName, coNo, accountantNumber, email, updateDate);

            }
            else
            {
                return null;
            }

        }



        private bool _AddNewPhone()
        {


            this.ID = clsDataAccessCustomers.Add(this.FullName, this.identityNumber, this.PhoneNumbe, this.PhoneNumbe2, this.CompanyName,
                this.CompanyNumber, this.AccountantNumber, this.Email,this.UpdateDate
                );

            return (this.ID != -1);
        }

        private bool _UpdatePhone()
        {


            return clsDataAccessCustomers.Update(this.ID, this.FullName, this.identityNumber, this.PhoneNumbe, this.PhoneNumbe2, this.CompanyName,
                this.CompanyNumber, this.AccountantNumber, this.Email, this.UpdateDate);

        }


        public bool Save()

        {

            switch (_Mode)
            {

                case _myMode.Addnew:

                    if (_AddNewPhone())
                    {
                        _Mode = _myMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case _myMode.Update:
                    return _UpdatePhone();
            }

            return false;

        }


        public static bool Delete(int ID)
        {
            return clsDataAccessCustomers.Delete(ID);
        }

        public static  DataTable  getAll()
        {
            return  clsDataAccessCustomers.GetAll();
        }    
        
        public static  DataTable GetAllOrderByLastUpdet()
        {
            return  clsDataAccessCustomers.GetAllOrderByLastUpdet();
        }    
        
        public static DataTable Search(string search)
        {
            return clsDataAccessCustomers.SearchCustomer(search);
        }

        public static bool IsExist(int ID)
        {
            return clsDataAccessCustomers.IsExist(ID);
        }



    }
}
