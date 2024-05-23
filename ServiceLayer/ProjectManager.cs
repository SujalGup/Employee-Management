using Core.BussinessObject;
using Core;
using DataLayer;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProjectManager
    {
        public static Logger Log = LogManager.GetLogger("Service Layer");

        /// <summary>
        /// Adding Project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public OperationResult Add(Project project)
        {
            Log.Debug("Adding Project");
            Project ProjectAlreadyExist = GetByName(project.Name);
            if (ProjectAlreadyExist != null)
            {
                Log.Debug("Not Added Project to DB");
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.PROJECT_ADDED_FAILURE_MESSAGE, project);
            }
            ProjectDB.Add(project);
            Log.Debug("Added Project to DB");
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.PROJECT_ADDED_SUCESS_MESSAGE, project);
        }


        /// <summary>
        /// getting Project by name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Project GetByName(string name)
        {
            return ProjectDB.GetByName(name);
        }

        /// <summary>
        /// Fetching list of all Project
        /// </summary>
        /// <returns></returns>

        public List<Project> GetAll()
        {
            return ProjectDB.GetAll();
        }

        /// <summary>
        ///  Deleting Project from DB
        /// </summary>
        /// <param name="id"></param>

        public void Delete(int id)
        {
            ProjectDB.Delete(id);

        }

        /// <summary>
        /// Updating exixting Project
        /// </summary>
        /// <param name="project"></param>
        public void Update(Project project)
        {
            Log.Debug("Updating Project to DB");
            ProjectDB.Update(project);

        }

        /// <summary>
        ///deleting Project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Project GetById(int id)
        {
            Log.Debug("Deleting Project to DB");
            Project project = ProjectDB.GetById(id);
            Log.Debug("Deleted Project to DB");
            return project;
        }
    }
}
