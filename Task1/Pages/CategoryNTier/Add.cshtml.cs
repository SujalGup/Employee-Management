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
namespace Task1.Pages.CategoryNTier
{
    [BindProperties]

    public class AddModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Mandatory { get; set; }

        public List<string> MandatoryList { get; set; }
        public void OnGet()
        {
            MandatoryList = CommonFunction.GetMandatoryList();
        }
        public IActionResult OnPost()
        {

            Category category = new Category();
            category.Name = Name;
            category.Description = Description;
            category.Mandatory = Mandatory;


            category.CreatedOnUTC = DateTime.UtcNow;
            category.UpdatedOnUTC = DateTime.UtcNow;
            category.CreatedBy = "System";
            category.UpdatedBy = "System";
            category.IPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            CategoryManager categoryManager = new CategoryManager();
            OperationResult operationResult = categoryManager.Add(category);
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
