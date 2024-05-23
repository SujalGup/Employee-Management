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

namespace Task1.Pages.EmployeeNTier
{
    [BindProperties]
    public class UpdateModel : BaseModel
    {
        [Required(ErrorMessage = "Please! Enter Your Name")]
        [StringLength(50, ErrorMessage = "Max 50 Characters Allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please! Enter Your Email")]
        [EmailAddress(ErrorMessage = "Please Enter Valid EmailId")]
        public string Email { get; set; }
        [StringLength(15, ErrorMessage = "Max 15 Characters Allowed")]
        public string Phone { get; set; }
        public int Id { get; set; }

        public string Status { get; set; }

        public string Department { get; set; }

        public List<string> StatusList { get; set; }
        public List<string> DepartmentList { get; set; }

        public void OnGet(int id)
        {

            StatusList = CommonFunction.GetStatusList();
            DepartmentList = CommonFunction.GetDepartmentsFromDataBase();
            EmployeeManager employeeManager = new EmployeeManager();
            Employee employee = employeeManager.GetById(id);
            
            

            Id = employee.Id;
            Name = employee.Name;
            Email = employee.Email;
            Phone = employee.Phone;
            Department = employee.Department;
            Status = employee.Status;
        }

        public IActionResult OnPost()
        {

            Employee employee = new Employee();
            employee.Id = Id;
            employee.Name = Name;
            employee.Email = Email;
            employee.Phone = Phone;
            employee.Department = Department;
            employee.Status = Status;
            employee.UpdatedBy = "System";
            employee.UpdatedOnUTC = DateTime.UtcNow;
            employee.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            EmployeeManager employeeManager = new EmployeeManager();
            employeeManager.Update(employee);
            if (employee.Id != default(int))
            {
                Sucess(Messages.EmployeeUpdatedSucessMessage);
            }
            else
            {
                Warning(Messages.EmployeeUpdatedFailureMessage);
            }
            return RedirectToPage("List");
        }
    }
}
