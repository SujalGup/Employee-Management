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
namespace Task1.Pages.ProjectNTier
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
            ProjectManager projectManager = new ProjectManager();
            Project project = projectManager.GetById(id);


            Id = project.Id;
            Name = project.Name;
            Description = project.Description;
        }

        public IActionResult OnPost()
        {

            Project project = new Project();
            project.Id = Id;
            project.Name = Name;
            project.Description = Description;
            project.UpdatedBy = "System";
            project.UpdatedOnUTC = DateTime.UtcNow;
            project.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            ProjectManager projectManager = new ProjectManager();
            projectManager.Update(project);
            if (project.Id != default(int))
            {
                Sucess(Messages.ProjectUpdatedSucessMessage);
            }
            else
            {
                Warning(Messages.ProjectUpdatedFailureMessage);
            }
            return RedirectToPage("List");
        }
    }
}
