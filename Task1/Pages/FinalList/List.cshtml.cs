using Core.BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using Task1.AppCode;

namespace Task1.Pages.FinalList
{
    public class ListModel : BaseModel
    {
        public List<Employee> EmployeeList { get; set; }


        public string Message { get; set; }
        public void OnGet()
        {

            EmployeeManager employeeManager = new EmployeeManager();
            Log.Debug("Calling List on get method");
            EmployeeList = employeeManager.GetAll();
            Log.Debug("List Page on get method completed");


        }

        }
    }

