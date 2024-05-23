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

namespace Task1.Pages.EmployeeNTier
{
    [BindProperties]
    public class AddModel : BaseModel
    {
        
        [Required(ErrorMessage = "Please! Enter Your Name")]
        [StringLength(50, ErrorMessage = "Max 50 Characters Allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please! Enter Your Email")]
        [EmailAddress(ErrorMessage = "Please Enter Valid EmailId")]
        public string Email { get; set; }
        [StringLength(15, ErrorMessage = "Max 15 Characters Allowed")]
        public string Phone { get; set; }

        public List<string> DepartmentList { get; set; }   

        public string Department { get; set; }

        public string Status { get; set; }  

        public List<string> StatusList { get; set; }

        public void OnGet()
        {
            DepartmentList = CommonFunction.GetDepartmentsFromDataBase();
            StatusList = CommonFunction.GetStatusList();

        }

        public IActionResult OnPost()
        {

            Employee employee = new Employee();
            employee.Name = Name;  
            employee.Email = Email; 
            employee.Phone = Phone;
            employee.Department = Department;
            employee.Status = Status;
            employee.CreatedOnUTC = DateTime.UtcNow;
            employee.UpdatedOnUTC = DateTime.UtcNow;
            employee.CreatedBy = "System";
            employee.UpdatedBy = "System";
            employee.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            EmployeeManager employeeManager = new EmployeeManager();
            OperationResult operationResult = employeeManager.Add(employee);
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
