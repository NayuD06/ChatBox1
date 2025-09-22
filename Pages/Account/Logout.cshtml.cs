using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerceALLInOne.Helpers;

namespace ECommerceALLInOne.Pages.Account
{
    public class LogoutModel : PageModel
    {

        public void OnGet()
        {
            HttpContext.Session.ClearUser();


        }
    }
}