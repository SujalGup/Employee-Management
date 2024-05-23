using Core.BussinessObject;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProjectDB
    {
        public static Logger Log = LogManager.GetLogger("Data Layer");
        /// <summary>
        /// Adding Data to Project Table
        /// </summary>
        /// <param name="project"></param>
        public static void Add(Project project)
        {
            Log.Debug("Adding {project.Name} in Project Db");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Insert INTO Project(Name, Description,CreatedBy, UpdatedBy, IPAddress, CreatedOnUTC, UpdatedOnUTC) Values(@Name, @Description, @CreatedBy, @UpdatedBy, @IPAddress, @CreatedOnUTC, @UpdatedOnUTC); SELECT LAST_INSERT_ID()");
            db.AddInParameter(cmd, "Name", DbType.String, project.Name);
            db.AddInParameter(cmd, "Description", DbType.String, project.Description);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, project.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, project.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, project.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, project.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, project.UpdatedOnUTC);
            project.Id = int.Parse(db.ExecuteScalar(cmd).ToString());
            Log.Debug("Added {project.Name} in Project Db");

        }

        /// <summary>
        /// Updating Data From project Table
        /// </summary>
        /// <param name="project"></param>
        public static void Update(Project project)
        {
            Log.Debug("Updating project having {project.Id} in Db");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand($"Update Project set Name=@Name, Description=@Description, CreatedBy=@CreatedBy, UpdatedBy=@UpdatedBy, IPAddress=@IPAddress, CreatedOnUTC=@CreatedOnUTC, UpdatedOnUTC=@UpdatedOnUTC where Id=@Id");
            db.AddInParameter(cmd, "Id", DbType.String, project.Id); 
            db.AddInParameter(cmd, "Name", DbType.String, project.Name);
            db.AddInParameter(cmd, "Description", DbType.String, project.Description);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, project.CreatedBy);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, project.UpdatedBy);
            db.AddInParameter(cmd, "IPAddress", DbType.String, project.IPAddress);
            db.AddInParameter(cmd, "CreatedOnUTC", DbType.DateTime, project.CreatedOnUTC);
            db.AddInParameter(cmd, "UpdatedOnUTC", DbType.DateTime, project.UpdatedOnUTC);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Updated project having {project.Id} in Db");
        }

        /// <summary>
        /// Deleting Data From Project Table
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            Log.Debug("Deleting Project having {Project.Id} in Db");
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("delete from Project where Id=@id");
            db.AddInParameter(cmd, "id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);
            Log.Debug("Deleted Project having {Project.Id} in Db");
        }

        /// <summary>
        /// Fetching data from Table with given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Project GetByName(string name)
        {
            Log.Debug("Getting Project having {Project.Name} in Db");
            Project project = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Project where Name=@name");
            db.AddInParameter(cmd, "name", DbType.String, name);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                project = new Project(reader);
            }
            Log.Debug("Getted Project having {project.Name} in Db");
            return project;

        }

        /// <summary>
        /// Fetching data from Table with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Project GetById(int id)
        {
            Log.Debug("Fetching Project having {project.Id} in Db");
            Project project = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from Project where Id=@Iid");
            db.AddInParameter(cmd, "Iid", DbType.Int32, id);
            IDataReader reader = db.ExecuteReader(cmd);

            while (reader.Read())
            {
                project = new Project(reader);
            }
            Log.Debug("Fetched Project having {project.Id} in Db");
            return project;

        }

        /// <summary>
        /// Fetching List from Project Table
        /// </summary>
        /// <returns></returns>
        public static List<Project> GetAll()
        {
            Log.Debug("Fetching Record From DB");
            List<Project> projectList = new List<Project>();

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("select * from project");
            IDataReader reader = db.ExecuteReader(cmd);
            while (reader.Read())
            {
                Project project = new Project(reader);
                projectList.Add(project);
            }
            Log.Debug($"Fetched Record From DB count - {projectList.Count}");
            return projectList;

        }
    }
}
