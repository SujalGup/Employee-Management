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


namespace Task1.Pages.CategoryNTier
{
    public class ListModel : BaseModel
    {
        public List<Category> CategoryList { get; set; }


        public string Message { get; set; }
        public void OnGet()
        {

            CategoryManager categoryManager = new CategoryManager();
            Log.Debug("Calling List on get method");
            CategoryList = categoryManager.GetAll();
            Log.Debug("List Page on get method completed");
        }


        public IActionResult OnGetByName(string name)
        {

            Log.Debug($"Calling List on Get By Name:{name} method");
            CategoryManager categoryManager = new CategoryManager();
            Category category = categoryManager.GetByName(name);
            Log.Debug($"Called List on Get By Name:{name} method");

            return RedirectToPage("List");
        }

        public IActionResult OnGetDelete(int id)
        {
            Log.Debug($"Calling List on Get By Delete:{id} method");
            CategoryManager categoryManager = new CategoryManager();
            categoryManager.Delete(id);
            Sucess(Messages.CategoryDeletedSucessMessage);
            Log.Debug($"Called List on Get By Delete:{id} method");
            return RedirectToPage("List");
        }

    }
}
