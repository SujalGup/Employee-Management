using Core.BussinessObject;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Xml.Linq;
using DataLayer;
using NLog;
using System.Reflection.Metadata.Ecma335;
using Core;

namespace ServiceLayer
{
    public class EmployeeManager
    {
        public static Logger Log = LogManager.GetLogger("Service Layer");
        
        /// <summary>
        ///  Adding employee to DB
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public OperationResult Add(Employee employee)
        {

            Log.Debug("Adding employee from serviec layer");
            Employee alreadyExitEmployeeByName = GetByName(employee.Name);
            if (alreadyExitEmployeeByName != null)
            {
                return new OperationResult((int)OperationStatus.Failure,SLConstants.Messages.EMPLOYEE_ADDED_FAILURE_NAME_UNIQUE, employee);
            }

            if (!string.IsNullOrEmpty(employee.Phone) && employee.Phone.Length > 15)
            {
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.EMPLOYEE_ADDED_FAILURE_PHONE_LENTH, employee);
            }

            Employee alreadyExitEmployee = GetByEmail(employee.Email);
            if (alreadyExitEmployee != null)
            {
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.EmployeeAddedFailureMessage, employee);
            }
            Log.Debug("Added employee from serviec layer");
            EmployeeDB.Add(employee);

            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.EmployeeAddedSucessMessage, employee);

        }
        /// <summary>
        /// Updating employee
        /// </summary>
        /// <param name="employee"></param>
        public void Update(Employee employee)
        {

            EmployeeDB.Update(employee);
        }

        /// <summary>
        /// Fetching list of employee
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAll()
        {
            Log.Debug("Fetching all record");
            List<Employee> employeeList = EmployeeDB.GetAll();
            Log.Debug("Fetched all record");
            return employeeList;
        }

        /// <summary>
        /// Fetchig employee with name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Employee GetByName(string name)
        {
            Log.Debug("Fetching employee to DB");
            Employee employee = EmployeeDB.GetByName(name);
            Log.Debug("Fetched employee to DB");

            return employee;
        }


        /// <summary>
        ///  Fetching  Employee by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetById(int id)
        {
            Log.Debug("Fetching employee to DB");

            Employee employee = EmployeeDB.GetById(id);
            Log.Debug("Fetched employee to DB");

            return employee;
        }

        /// <summary>
        /// Fetching employee with email 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Employee GetByEmail(string email) 
        {
            Log.Debug("Fetching employee to DB");

            Employee employee = EmployeeDB.GetByEmail(email);
            Log.Debug("Fetched employee to DB");

            return employee;


        }

        /// <summary>
        /// deleting Data from Db
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            EmployeeDB.Delete(id);
        }
    }
}
