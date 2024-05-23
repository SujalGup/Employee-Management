using Core.BussinessObject;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using System.ComponentModel.DataAnnotations;
using Task1.AppCode;

namespace Task1.Pages.DepartmentNTier
{ 
    
    [BindProperties]
    public class UpdateModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int Id { get; set; }
        public void OnGet(int id)
        {
            DepartmentManager departmentManager = new DepartmentManager();
            Department department = departmentManager.GetById(id);



            Id = department.Id;
            Name = department.Name;
            Description = department.Description;
        }

        public IActionResult OnPost()
        {

            Department department = new Department();
            department.Id = Id;
            department.Name = Name;
            department.Description = Description;
            department.UpdatedBy = "System";
            department.UpdatedOnUTC = DateTime.UtcNow;
            department.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            DepartmentManager departmentManager = new DepartmentManager();
            departmentManager.Update(department);
            if (department.Id != default(int))
            {
                Sucess(Messages.DepartmentUpdatedSucessMessage);
            }
            else
            {
                Warning(Messages.DepartmentUpdatedFailureMessage);
            }
            return RedirectToPage("List");
        }
    }
}
