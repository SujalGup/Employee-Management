using Core.BussinessObject;
using Core;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Org.BouncyCastle.Asn1.Crmf;


namespace ServiceLayer
{
    public class DepartmentManager
    {
        public static Logger Log = LogManager.GetLogger("Service Layer");
        public bool DeptAlreadyExist = false;
        /// <summary>
        /// Adding Department 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public OperationResult Add(Department department)
        {
            Log.Debug("Adding Depatment");
            Department DepartmentAlreadyExist = GetByName(department.Name);
            if (DepartmentAlreadyExist != null)
            {
                Log.Debug("Not Added Department to DB");
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.DEPARTMENT_ADDED_FAILURE_MESSAGE, department);
            }
            DepartmentDB.Add(department);
            Log.Debug("Added Department to DB");
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.DEPARTMENT_ADDED_SUCESS_MESSAGE, department); 
        }


        /// <summary>
        /// getting department by name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Department GetByName(string name)
        {
            return DepartmentDB.GetByName(name);    
        }

        /// <summary>
        /// Fetching list of all department
        /// </summary>
        /// <returns></returns>
        public List<Department> GetAll()
        {
            return DepartmentDB.GetAll();
        }
        /// <summary>
        /// Deleting Department from DB
        /// </summary>
        /// <param name="id"></param>
        /// 

        public void Delete(int id) {
            DepartmentDB.Delete(id);

        }
        /// <summary>
        /// Updating exixting department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public void  Update(Department department)
        {
            Log.Debug("Updating Department to DB");
            DepartmentDB.Update(department);

        }
        /// <summary>
        ///  deleting department by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetById(int id)
        {
            Log.Debug("Deleting Department to DB");
            Department department = DepartmentDB.GetById(id);
            Log.Debug("Deleted Department to DB");
            return department;
        }

    }
}
