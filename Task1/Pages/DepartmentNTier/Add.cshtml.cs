using Core;
using Core.BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using System.ComponentModel.DataAnnotations;
using Task1.AppCode;

namespace Task1.Pages.DepartmentNTier
{
    [BindProperties]
    public class AddModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }



        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            Department department = new Department();
            department.Name = Name;
            department.Description = Description;
            department.CreatedOnUTC = DateTime.UtcNow;
            department.UpdatedOnUTC = DateTime.UtcNow;
            department.CreatedBy = "System";
            department.UpdatedBy = "System";
            department.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            DepartmentManager departmentManager = new DepartmentManager();
            OperationResult operationResult = departmentManager.Add(department);
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
