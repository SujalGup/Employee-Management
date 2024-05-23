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
    public class ReportDB
    {
        public static Logger Log = LogManager.GetLogger("Data Layer");

        /// <summary>
        /// Adding Data to Report Table
        /// </summary>
        /// <param name="report"></param>
        public static void Add(Report report)
        {
            Log.Debug("Adding Report to DB");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Insert INTO Report(Name, Description, Employee, Status, CreatedBy, UpdatedBy, IPAddress, CreatedOnUTC, UpdatedOnUTC) Values(@Name, @Description, @Employee, @Status, @CreatedBy, @UpdatedBy, @IPAddress, @CreatedOnUTC, @UpdatedOnUTC)");
            db.AddInParameter(cmd, "Name", DbType.String, report.Name);
            db.AddInParameter(cmd, "Description", DbType.String, report.Description);
            db.AddInParameter(cmd, "Employee", DbType.String, report.Employee);
            db.AddInParameter(cmd, "Status", DbType.String, report.Status);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, report.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, report.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, report.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, report.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, report.UpdatedOnUTC);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Added Report to DB");

        }

        /// <summary>
        /// Updating Data of Report Table
        /// </summary>
        /// <param name="report"></param>
        public static void Update(Report report)
        {
            Log.Debug("Updating Report to DB");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Update Report set Name=@Name,Description=@Description, Employee=@Employee, Status=@Status,  CreatedBy=@CreatedBy, UpdatedBy=@UpdatedBy, IPAddress=@IPAddress, CreatedOnUTC=@CreatedOnUTC, UpdatedOnUTC=@UpdatedOnUTC where Id=@Id");
            db.AddInParameter(cmd, "Id", DbType.String, report.Id);
            db.AddInParameter(cmd, "Name", DbType.String, report.Name);
            db.AddInParameter(cmd, "Description", DbType.String, report.Description);
            db.AddInParameter(cmd, "Employee", DbType.String, report.Employee);
            db.AddInParameter(cmd, "Status", DbType.String, report.Status);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, report.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, report.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, report.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, report.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, report.UpdatedOnUTC);
            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// Deleting Data from Report Table
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            Log.Debug("Deleting Report to DB");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("delete from Report where Id=@id");
            db.AddInParameter(cmd, "id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Deleting Report to DB");
        }

        /// <summary>
        /// Fetching data from Table with given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Report GetByName(string name)
        {
            Log.Debug("Fetching Report to DB by name");
            Report report = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Report where Name=@name");
            db.AddInParameter(cmd, "name", DbType.String, name);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                report = new Report(reader);
            }
            Log.Debug("Fetching Report to DB by Name");
            return report;

        }
        /// <summary>
        /// Fetching data from Table with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Report GetById(int id)
        {
            Log.Debug("Deleting Report to DB");
            Report report = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Report where Id=@Iid");
            db.AddInParameter(cmd, "Iid", DbType.Int32, id);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                report = new Report(reader);
            }
            Log.Debug("Deleted Report to DB");
            return report;

        }

        /// <summary>
        /// Fetching List 
        /// </summary>
        /// <returns></returns>
        public static List<Report> GetAll()
        {
            Log.Debug("Fetching Record From DB");
            List<Report> reportList = new List<Report>();

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Report");
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                Report report = new Report(reader);
                reportList.Add(report);
            }
            Log.Debug($"Fetched Record From DB count - {reportList.Count}");
            return reportList;

        }
    }
}
