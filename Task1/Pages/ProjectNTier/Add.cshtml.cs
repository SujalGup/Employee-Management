using Core.BussinessObject;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using System.ComponentModel.DataAnnotations;

namespace Task1.Pages.ProjectNTier
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

            Project project = new Project();
            project.Name = Name;
            project.Description = Description;
            project.CreatedOnUTC = DateTime.UtcNow;
            project.UpdatedOnUTC = DateTime.UtcNow;
            project.CreatedBy = "System";
            project.UpdatedBy = "System";
            project.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            ProjectManager projectManager = new ProjectManager();
            OperationResult operationResult = projectManager.Add(project);
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