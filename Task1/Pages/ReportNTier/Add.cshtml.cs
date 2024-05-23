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

namespace Task1.Pages.ReportNTier
{
    [BindProperties]
    public class AddModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Employee {  get; set; }

        public List<string> EmployeeList { get; set; }

        public string Status { get; set; }

        public List<string> StatusList { get; set; }


        public void OnGet()
        {
            StatusList = CommonFunction.GetReportStatusList();
            EmployeeList = CommonFunction.GetEmployeesFromDataBase();
        }
        public IActionResult OnPost()
        {

            Report report = new Report();
            report.Name = Name;
            report.Description = Description;
            report.Employee = Employee;
            report.Status = Status;
            report.CreatedOnUTC = DateTime.UtcNow;
            report.UpdatedOnUTC = DateTime.UtcNow;
            report.CreatedBy = "System";
            report.UpdatedBy = "System";
            report.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            ReportManager reportManager = new ReportManager();
            OperationResult operationResult = reportManager.Add(report);
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
