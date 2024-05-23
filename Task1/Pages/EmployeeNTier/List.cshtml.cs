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

namespace Task1.Pages.EmployeeNTier
{
    public class ListModel : BaseModel
    {
        public List<Employee> EmployeeList { get; set; }


        public string Message {get; set; }
        public void OnGet()
        {

            EmployeeManager employeeManager = new EmployeeManager();
            Log.Debug("Calling List on get method");
            EmployeeList = employeeManager.GetAll();
            Log.Debug("List Page on get method completed");


        }

        public IActionResult OnGetByName(string name)
        {

            Log.Debug($"Calling List on Get By Name:{name} method");
            EmployeeManager employeeManager = new EmployeeManager();
            Employee employee = employeeManager.GetByName(name);
            Log.Debug($"Called List on Get By Name:{name} method");

            return RedirectToPage("List");
        }

        public IActionResult OnGetDelete(int id)
        {
            Log.Debug($"Calling List on Get By Delete:{id} method");
            EmployeeManager employeeManager = new EmployeeManager();
            employeeManager.Delete(id);
            Sucess(Messages.EmployeeDeletedSucessMessage);
            Log.Debug($"Called List on Get By Delete:{id} method");
            return RedirectToPage("List");
        }
    }
}
