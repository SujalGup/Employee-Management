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
    public class ReportManager
    {
        public static Logger Log = LogManager.GetLogger("Service Layer");


        /// <summary>
        /// Adding Report
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        public OperationResult Add(Report report)
        {
            Log.Debug("Adding Report");
            Report ReportAlreadyExist = GetByName(report.Name);
            if (ReportAlreadyExist != null)
            {
                Log.Debug("Not Added Report to DB");
                return new OperationResult((int)OperationStatus.Failure, SLConstants.Messages.REPORT_ADDED_FAILURE_MESSAGE, report);
            }
            ReportDB.Add(report);
            Log.Debug("Added Report to DB");
            return new OperationResult((int)OperationStatus.Success, SLConstants.Messages.REPORT_ADDED_SUCESS_MESSAGE, report);
        }

        /// <summary>
        /// getting Report by name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Report GetByName(string name)
        {
            return ReportDB.GetByName(name);
        }
        /// <summary>
        ///  Fetching list of all Report
        /// </summary>
        /// <returns></returns>

        public List<Report> GetAll()
        {
            return ReportDB.GetAll();
        }

        /// <summary>
        /// Deleting Report from DB
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            ReportDB.Delete(id);

        }

        /// <summary>
        /// Updating exixting Report
        /// </summary>
        /// <param name="report"></param>
        public void Update(Report report)
        {
            Log.Debug("Updating Report to DB");
            ReportDB.Update(report);

        }

        /// <summary>
        /// deleting Report by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Report GetById(int id)
        {
            Log.Debug("Deleting Report to DB");
            Report report = ReportDB.GetById(id);
            Log.Debug("Deleted Report to DB");
            return report;
        }
    }
}
