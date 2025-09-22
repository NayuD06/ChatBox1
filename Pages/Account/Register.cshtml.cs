using System;
using System.Security.Cryptography;
using System.Text;
using ECommerceALLInOne.Data;
using ECommerceALLInOne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceAllInOne.Pages.Account
{
    public class RegisterModel(AppDbContext db) : PageModel
    {
        private readonly AppDbContext _db = db;
        [BindProperty] public required string Username { get; set; }
        [BindProperty] public required string Password { get; set; }
        [BindProperty] public required string Email { get; set; }
        [BindProperty] public required string Role { get; set; }
        public IActionResult Onpost()
        {
            var user = new User
            {
                Username = Username,
                Email = Email,
                PasswordHash = HashPassword(Password),
                Role = Role,
                CreateDate = DateTime.Now
            };
            _db.Users.Add(user);
            _db.SaveChanges();
            return RedirectToPage();
        }
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "").ToLower();
        }
    }


}