using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Core.BussinessObject;
using ServiceLayer;
using System.Xml.Linq;
using NLog;
using Task1.AppCode;

namespace Task1.Pages.ReportNTier
{
    public class ListModel : BaseModel
    {

        public List<Report> ReportList { get; set; }


        public string Message { get; set; }
        public void OnGet()
        {
            ReportManager reportManager = new ReportManager();
            Log.Debug("Calling List on get method");
            ReportList = reportManager.GetAll();
            Log.Debug("List Page on get method completed");


        }

        public IActionResult OnGetByName(string name)
        {

            Log.Debug($"Calling List on Get By Name:{name} method");
            ReportManager reportManager = new ReportManager();
            Report report = reportManager.GetByName(name);
            Log.Debug($"Called List on Get By Name:{name} method");

            return RedirectToPage("List");
        }

        public IActionResult OnGetDelete(int id)
        {
            Log.Debug($"Calling List on Get By Delete:{id} method");
            ReportManager reportManager = new ReportManager();
            reportManager.Delete(id);
            Sucess(Messages.ReportDeletedSucessMessage);
            Log.Debug($"Called List on Get By Delete:{id} method");
            return RedirectToPage("List");
        }
    }
}
