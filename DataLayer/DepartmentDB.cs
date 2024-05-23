using Core.BussinessObject;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataLayer
{
    public class DepartmentDB
    {
        public static Logger Log = LogManager.GetLogger("Data Layer");

        /// <summary>
        /// Adding new department to db
        /// </summary>
        /// <param name="department"></param>
        public static void Add(Department department)
        {
            Log.Debug("Adding Department to DB");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Insert INTO department(Name, Description, CreatedBy, UpdatedBy, IPAddress, CreatedOnUTC, UpdatedOnUTC) Values(@Name, @Description, @CreatedBy, @UpdatedBy, @IPAddress, @CreatedOnUTC, @UpdatedOnUTC)");
            db.AddInParameter(cmd, "Name", DbType.String, department.Name);
            db.AddInParameter(cmd, "Description", DbType.String, department.Description);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, department.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, department.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, department.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, department.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, department.UpdatedOnUTC);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Added Department to DB");

        }

        /// <summary>
        /// Updating exixting Department
        /// </summary>
        /// <param name="department"></param>
        public static void Update(Department department)
        {
            Log.Debug("Updating Department to DB");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Update department set Name=@Name,Description=@Description,  CreatedBy=@CreatedBy, UpdatedBy=@UpdatedBy, IPAddress=@IPAddress, CreatedOnUTC=@CreatedOnUTC, UpdatedOnUTC=@UpdatedOnUTC where Id=@Id");
            db.AddInParameter(cmd, "Id", DbType.String, department.Id);
            db.AddInParameter(cmd, "Name", DbType.String, department.Name);
            db.AddInParameter(cmd, "Description", DbType.String, department.Description);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, department.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, department.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, department.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, department.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, department.UpdatedOnUTC);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// Deleting department with given department.Id
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            Log.Debug("Deleting Department to DB");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("delete from department where Id=@id");
            db.AddInParameter(cmd, "id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Deleting Department to DB");
        }

        /// <summary>
        ///Fetching department using department.Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Department GetByName(string name)
        {
            Log.Debug("Fetching Department to DB by name");
            Department department = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from department where Name=@name");
            db.AddInParameter(cmd, "name", DbType.String, name);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                department  = new Department(reader);
            }
            Log.Debug("Fetching Department to DB by Name");
            return department;

        }

        /// <summary>
        /// Fetching department using its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Department GetById(int id)
        {
            Log.Debug("Deleting Department to DB");
            Department department = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from department where Id=@Iid");
            db.AddInParameter(cmd, "Iid", DbType.Int32, id);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                department = new Department(reader);
            }
            Log.Debug("Deleted Department to DB");
            return department;

        }

        /// <summary>
        /// fertching list of all department 
        /// </summary>
        /// <returns></returns>

        public static List<Department> GetAll()
        {
            Log.Debug("Fetching Record From DB");
            List<Department> departmentList = new List<Department>();

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from department");
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                Department department = new Department(reader);
                departmentList.Add(department);
            }
            Log.Debug($"Fetched Record From DB count - {departmentList.Count}");
            return departmentList;

        }


    }
}
