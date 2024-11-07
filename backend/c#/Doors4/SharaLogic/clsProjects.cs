using sharaDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharaLogic
{
    public class clsProjects
    {


        private enum _myMode { Addnew = 1, Update = 2 };

        private _myMode _Mode = _myMode.Addnew;

        public int ID { get; set; }
        public string projectName { get; set; }
        public string notes { get; set; }
        public string Address { get; set; }
        public string Manger { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime DateOfUpdate { get; set; }
        public int projectNumber { get; set; }
        public int iDcustomer { get; set; }







        private clsProjects(int id, string projectname, string address, int projectnumber, int idcustomer, string note
            ,string manger,string contactPerson, string contactPhone, DateTime dateOfCreate, DateTime dateOfUpdate)

        {
            this.ID = id;
            this.projectName = projectname;
            this.Address = address;
            this.projectNumber = projectnumber;
            this.iDcustomer = idcustomer;
            this.notes = note;
            this.Manger = manger;
            this.ContactPerson = contactPerson;
            this.ContactPhone = contactPhone;
            this.DateOfCreate = dateOfCreate;
            this.DateOfUpdate = dateOfUpdate;


            this._Mode = _myMode.Update;

        }

        public clsProjects()
        {

            this._Mode = _myMode.Addnew;

            this.ID = -1;
            this.projectName = "";
            this.Address ="";
            this.projectNumber = -1;
            this.iDcustomer = -1;
            this.notes = "";
            this.Manger = "";
            this.ContactPerson = "";
            this.ContactPhone = "";
            this.DateOfCreate = DateTime.Now;
            this.DateOfUpdate = DateTime.Now;



        }


        public static clsProjects Find(string projectname)
        {


            int id = -1;


            id = clsDataAccessProjects.GetProjectByName(projectname);

            if (id != -1)
            {


                return Find( id);


            }


            return null;



        }

        public static clsProjects Find(int id)
        {



        
            string projectName = "";
            string address = "";
            int idcoustomer = -1;
            int projectnumber = -1;
            string note = "";
            string manger = "";
            string contactPerson = "";
            string contactPhone = "";
            DateTime dateofCreate = DateTime.Now;
            DateTime dateOFupdate = DateTime.Now;


            if (clsDataAccessProjects.GetProjectByID(id, ref projectName, ref address, ref projectnumber, ref idcoustomer, ref note
                    , ref manger, ref contactPerson, ref contactPhone, ref dateofCreate, ref dateOFupdate))
            {
                return new clsProjects(id, projectName, address, projectnumber, idcoustomer, note, manger, contactPerson, contactPhone, dateofCreate, dateOFupdate);
            }



            return null;


        }

        public static clsProjects FindByCoostomerId(int idcoustomer)
        {



            int id = -1;
            string projectName = "";
            string address = "";
        
            int projectnumber = -1;
            string note = "";
            string manger = "";
            string contactPerson = "";
            string contactPhone = "";
            DateTime dateofCreate = DateTime.Now;
            DateTime dateOFupdate = DateTime.Now;


            if (clsDataAccessProjects.getByCostomerID(ref id, ref projectName, ref address, ref projectnumber,  idcoustomer, ref note
                    , ref manger, ref contactPerson, ref contactPhone, ref dateofCreate, ref dateOFupdate))
            {
                return new clsProjects(id, projectName, address, projectnumber, idcoustomer, note, manger, contactPerson, contactPhone, dateofCreate, dateOFupdate);
            }



            return null;


        }

        private bool _AddNewPhone()
        {


            this.ID = clsDataAccessProjects.Add(this.projectName, this.Address, this.projectNumber, this.iDcustomer, this.notes,this.Manger,this.ContactPerson,this.ContactPhone,this.DateOfCreate,this.DateOfUpdate);

            return (this.ID != -1);
        }

        private bool _UpdatePhone()
        {


            return clsDataAccessProjects.Update(this.ID, this.projectName, this.Address, this.projectNumber, this.iDcustomer, this.notes,this.Manger 
                ,this.ContactPerson,this.ContactPhone,this.DateOfCreate,this.DateOfUpdate
                
                );

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
            return clsDataAccessProjects.Delete(ID);
        }

        public static DataTable getAll()
        {
            return clsDataAccessProjects.GetAll();
        } 
        
        public static DataTable Search(string search,int IDcustomer)
        {
            return clsDataAccessProjects.SearchProject(search, IDcustomer);
        }

        public static DataTable getWithCustomer(int IDcustomer)
        {
            return clsDataAccessProjects.getWithCustomer(IDcustomer);
        }

        public static bool IsExist(int ID)
        {
            return clsDataAccessProjects.IsExist(ID);
        }



    }
}
