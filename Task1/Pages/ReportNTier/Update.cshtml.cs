using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data;
using Core.BussinessObject;
using ServiceLayer;
using Task1.AppCode;

namespace Task1.Pages.ReportNTier
{
    [BindProperties]
    public class UpdateModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Employee { get; set; }

        public List<string> EmployeeList { get; set; }

        public int Id {  get; set; }

        public string Status { get; set; }

        public List<string> StatusList { get; set; }
        public void OnGet(int id)
        {
            StatusList = CommonFunction.GetReportStatusList();
            EmployeeList = CommonFunction.GetEmployeesFromDataBase();
            ReportManager reportManager = new ReportManager();
            Report report = reportManager.GetById(id);

            Id = report.Id;
            Name = report.Name;
            Description = report.Description;
            Employee = report.Employee;
            Status = report .Status;
        }

        public IActionResult OnPost()
        {

            Report report = new Report();
            report.Id = Id;
            report.Name = Name;
            report.Description = Description;
            report.Employee = Employee;
            report.Status = Status;
            report.UpdatedBy = "System";
            report.UpdatedOnUTC = DateTime.UtcNow;
            report.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            ReportManager reportManager = new ReportManager();
            reportManager.Update(report);
            if (report.Id != default(int))
            {
                Sucess(Messages.ReportUpdatedSucessMessage);
            }
            else
            {
                Warning(Messages.ReportUpdatedFailureMessage);
            }
            return RedirectToPage("List");
        }
    }
}
