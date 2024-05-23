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

namespace Task1.Pages.CategoryNTier
{
    [BindProperties]
    public class UpdateModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Mandatory { get; set; }

        public int Id { get; set; }

        public List<string> MandatoryList { get; set; }
        public void OnGet(int id)
        {
            MandatoryList = CommonFunction.GetMandatoryList();
            CategoryManager categoryManager = new CategoryManager();
            Category category = categoryManager.GetById(id);


            Id = category.Id;
            Name = category.Name;
            Description = category.Description;
            Mandatory = category.Mandatory;

        }

        public IActionResult OnPost()
        {

            Category category = new Category();
            category.Id = Id;
            category.Name = Name;
            category.Description = Description;
            category.Mandatory = Mandatory;
            category.UpdatedBy = "System";
            category.UpdatedOnUTC = DateTime.UtcNow;
            category.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            CategoryManager categoryManager = new CategoryManager();
            categoryManager.Update(category);
            if (category.Id != default(int))
            {
                Sucess(Messages.CategoryUpdatedSucessMessage);
            }
            else
            {
                Warning(Messages.CategoryUpdatedFailureMessage);
            }
            return RedirectToPage("List");
        }
    }
}
