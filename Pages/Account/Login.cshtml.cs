using System.Security.Cryptography;
using System.Text;
using ECommerceALLInOne.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerceALLInOne.Helpers;

namespace ECommerceALLInOne.Pages.Account
{
    public class LoginModel(AppDbContext db) : PageModel
    {
        private readonly AppDbContext _db = db;
        [BindProperty] public required string Username { get; set; }
        [BindProperty] public required string Password { get; set; }
        public IActionResult OnPost(){
            var user =_db.Users.First(u => u.Username == Username && u.PasswordHash == HashPassword(Password));
            HttpContext.Session.SetUserId(user.Id);
            HttpContext.Session.SetUserRole(user.Role);
            return RedirectToPage("/Index");

        }
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "").ToLower();
        }
    }
}