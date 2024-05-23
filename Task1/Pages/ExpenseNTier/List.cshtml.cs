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

namespace Task1.Pages.ExpenseNTier
{
    public class ListModel : BaseModel
    {
        public List<Expense> ExpenseList { get; set; }


        public string Message { get; set; }
        public void OnGet()
        {
            ExpenseManager expenseManager = new ExpenseManager();
            Log.Debug("Calling List on get method");
            ExpenseList = expenseManager.GetAll();
            Log.Debug("List Page on get method completed");

        }
        public IActionResult OnGetDelete(int id)
        {
            Log.Debug($"Calling List on Get By Delete:{id} method");
            ExpenseManager expenseManager = new ExpenseManager();
            expenseManager.Delete(id);
            Sucess(Messages.ExpenseDeletedSucessMessage);
            Log.Debug($"Called List on Get By Delete:{id} method");
            return RedirectToPage("List");
        }

    }
}
