using Core.BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using System.Collections.Generic;
using Task1.AppCode;

namespace Task1.Pages.DepartmentNTier
{
    public class ListModel : BaseModel
    {
        public List<Department> DepartmentList { get; set; }


        public string Message { get; set; }
        public void OnGet()
        {

            DepartmentManager departmentManager = new DepartmentManager();
            Log.Debug("Calling List on get method");
            DepartmentList = departmentManager.GetAll();
            Log.Debug("List Page on get method completed");


        }

        public IActionResult OnGetByName(string name)
        {

            Log.Debug($"Calling List on Get By Name:{name} method");
            DepartmentManager departmentManager = new DepartmentManager();
            Department department = departmentManager.GetByName(name);
            Log.Debug($"Called List on Get By Name:{name} method");

            return RedirectToPage("List");
        }

        public IActionResult OnGetDelete(int id)
        {
            Log.Debug($"Calling List on Get By Delete:{id} method");
            DepartmentManager departmentManager = new DepartmentManager();
            departmentManager.Delete(id);
            Sucess(Messages.DepartmentDeletedSucessMessage);
            Log.Debug($"Called List on Get By Delete:{id} method");
            return RedirectToPage("List");
        }
    }
}
