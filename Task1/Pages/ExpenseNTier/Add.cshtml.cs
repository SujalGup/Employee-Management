using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data;
using System.Xml.Linq;
using Core.BussinessObject;
using ServiceLayer;
using Task1.AppCode;
using Core;


namespace Task1.Pages.ExpenseNTier
{
    [BindProperties]
    public class AddModel : BaseModel
    {
        [Required]
        public string Amount { get; set; }

        [Required]
        public string Category { get; set; }
        public List<string> CategoryList { get; set; }

        [Required]
        public string Report { get; set; }
        public List<string> ReportList { get; set; }

        [Required]
        public string Name { get; set; }

        public List<string> NameList { get; set; }
        public void OnGet()
        {
            CategoryList = CommonFunction.GetCategoryFromDataBase();
            ReportList = CommonFunction.GetReportFromDataBase();
            NameList = CommonFunction.GetEmployeesFromDataBase();


        }

        public IActionResult OnPost()
        {

            Expense expense = new Expense();
            expense.Name =Name;
            expense.Report = Report;
            expense.Category = Category;
            expense.Amount = Amount;
            expense.CreatedOnUTC = DateTime.UtcNow;
            expense.UpdatedOnUTC = DateTime.UtcNow;
            expense.CreatedBy = "System";
            expense.UpdatedBy = "System";
            expense.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            ExpenseManager expenseManager = new ExpenseManager();
            OperationResult operationResult = expenseManager.Add(expense);
            if (operationResult.Status == (int)OperationStatus.Success)
            {
                Sucess(operationResult.Message);
            }
            else
            {
                Warning(operationResult.Message);
                return Page();
            }
            return RedirectToPage("List");
        }
    }
}
