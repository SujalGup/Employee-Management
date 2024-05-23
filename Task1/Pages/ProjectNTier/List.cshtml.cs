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

namespace Task1.Pages.ProjectNTier
{
    public class ListModel : BaseModel
    {

        public List<Project> ProjectList { get; set; }


        public string Message { get; set; }
        public void OnGet()
        {
            ProjectManager projectManager = new ProjectManager();
            Log.Debug("Calling List on get method");
            ProjectList = projectManager.GetAll();
            Log.Debug("List Page on get method completed");
        }
        public IActionResult OnGetByName(string name)
        {

            Log.Debug($"Calling List on Get By Name:{name} method");
            ProjectManager projectManager = new ProjectManager();
            Project project = projectManager.GetByName(name);
            Log.Debug($"Called List on Get By Name:{name} method");

            return RedirectToPage("List");
        }

        public IActionResult OnGetDelete(int id)
        {
            Log.Debug($"Calling List on Get By Delete:{id} method");
            ProjectManager projectManager = new ProjectManager();
            projectManager.Delete(id);
            Sucess(Messages.ProjectDeletedSucessMessage);
            Log.Debug($"Called List on Get By Delete:{id} method");
            return RedirectToPage("List");
        }

    }
}
