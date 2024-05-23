using Microsoft.AspNetCore.Mvc.RazorPages;
using NLog;

namespace Task1.Pages
{
    public class BaseModel : PageModel
    {
        public static Logger Log = LogManager.GetLogger("Tasl1");

        public void Warning(string message)
        {
            TempData["WarningMessage"] = message;
        }

        public void Sucess(string message)
        {
            TempData["SucessMessage"] = message;
        }
    }
}
