using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Core.BussinessObject;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NLog;

namespace DataLayer
{
    public class EmployeeDB
    {
        public static Logger Log = LogManager.GetLogger("Data Layer");
        /// <summary>
        ///  Add employee in database
        /// </summary>
        /// <param name="employee"></param>
        public static void Add(Employee employee)
        {
            Log.Debug("Adding {employee.Name} in employee Db");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Insert INTO Employee(Name, Email, Phone, Department, Status,CreatedBy, UpdatedBy, IPAddress, CreatedOnUTC, UpdatedOnUTC) Values(@Name, @Email, @Phone, @department,  @Status, @CreatedBy, @UpdatedBy, @IPAddress, @CreatedOnUTC, @UpdatedOnUTC); SELECT LAST_INSERT_ID()");
            db.AddInParameter(cmd, "Name", DbType.String, employee.Name);
            db.AddInParameter(cmd, "Email", DbType.String, employee.Email);
            db.AddInParameter(cmd, "Phone", DbType.String, employee.Phone);
            db.AddInParameter(cmd, "Department", DbType.String, employee.Department);
            db.AddInParameter(cmd, "Status", DbType.String, employee.Status);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, employee.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, employee.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, employee.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, employee.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, employee.UpdatedOnUTC);
            employee.Id = int.Parse(db.ExecuteScalar(cmd).ToString());
            Log.Debug("Added {employee.Name} in employee Db");

        }
         
        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="employee"></param>
        public static void Update(Employee employee) 
        {
            Log.Debug("Updating employee having {employee.Id} in Db");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Update Employee set Name=@Name, Email=@Email,  Phone=@Phone, Department=@Department, Status=@Status, CreatedBy=@CreatedBy, UpdatedBy=@UpdatedBy, IPAddress=@IPAddress, CreatedOnUTC=@CreatedOnUTC, UpdatedOnUTC=@UpdatedOnUTC where Id=@Id");
            db.AddInParameter(cmd, "Id", DbType.String, employee.Id);
            db.AddInParameter(cmd, "Name", DbType.String, employee.Name);
            db.AddInParameter(cmd, "Email", DbType.String, employee.Email);
            db.AddInParameter(cmd, "Phone", DbType.String, employee.Phone);
            db.AddInParameter(cmd, "Department", DbType.String, employee.Department);
            db.AddInParameter(cmd, "Status", DbType.String, employee.Status);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, employee.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, employee.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, employee.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, employee.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, employee.UpdatedOnUTC);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Updated employee having {employee.Id} in Db");
        }

        /// <summary>
        /// delete employee from database with employee id
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id) 
        {
            Log.Debug("Deleting employee having {employee.Id} in Db");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("delete from Employee where Id=@id");
            db.AddInParameter(cmd, "id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Deleted employee having {employee.Id} in Db");
        }
        /// <summary>
        /// getting info of employee by employee.Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Employee GetByName(string name)
        {
            Log.Debug("Getting employee having {employee.Name} in Db");
            Employee employee = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Employee where Name=@name");
            db.AddInParameter(cmd, "name", DbType.String, name);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                employee = new Employee(reader);
            }
            Log.Debug("Getted employee having {employee.Name} in Db");
            return employee;

        }
        /// <summary>
        /// Fetching employee by employe.Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Employee GetById(int id )
        {
            Log.Debug("Fetching employee having {employee.Id} in Db");
            Employee employee = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Employee where Id=@Iid");
            db.AddInParameter(cmd, "Iid", DbType.Int32, id);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                employee = new Employee(reader);
            }
            Log.Debug("Fetched employee having {employee.Id} in Db");
            return employee;

        }
        /// <summary>
        /// fetching all record form db
        /// </summary>
        /// <returns></returns>
        public static List<Employee> GetAll() 
        {
            Log.Debug("Fetching Record From DB");
            List<Employee> employeeList = new List<Employee>();

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("SELECT e.*, d.Description FROM Employee e INNER JOIN Department d ON e.Department = d.Name");
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                Employee employee = new Employee(reader);
                employee.Description = DBNull.Value != reader["Description"] ? (string)reader["Description"] : default(string);
                employeeList.Add(employee);
            }
            Log.Debug($"Fetched Record From DB count - {employeeList.Count}");
            return employeeList;

        }

        /// <summary>
        /// fetching employee with employee.Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Employee GetByEmail(string email)
        {
            Log.Debug("Fetching employee having {employee.Email} in Db");

            Employee employee = null;

            Database db = ConnectionFactory.CreateDataBase();

            DbCommand cmd2 = db.GetSqlStringCommand("select * from Employee where Email=@Email");
            db.AddInParameter(cmd2, "Email", DbType.String, email);
            IDataReader reader = db.ExecuteReader(cmd2);
            while (reader.Read())
            {
                employee = new Employee(reader);
            }
            Log.Debug("Fetching employee having {employee.Email} in Db");
            return employee;
        }
    }
}
