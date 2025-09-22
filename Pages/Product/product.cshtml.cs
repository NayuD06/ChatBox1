using ECommerceALLInOne.Data;
using ECommerceALLInOne.Models;
using ECommerceALLInOne.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceALLInOne.Pages.Product
{
    public class ProductMode(AppDbContext context, IWebHostEnvironment environment) : PageModel
    {
        private readonly AppDbContext _context = context;
        private readonly IWebHostEnvironment _environment = environment;
        [BindProperty] public required string Name { get; set; }
        [BindProperty] public required string Dicription { get; set; }
        [BindProperty] public required decimal Price { get; set; }
        [BindProperty] public required int Stock { get; set; }
        [BindProperty] public required IFormFile UploadImg { get; set; }
        public void OnGet()
        {

        }
        public IActionResult Onpost()
        {
            var UserRole = HttpContext.Session.GetUserRole();
            if (UserRole != "Admin")
            {
                TempData["ErrorMassage"]="UnAuthorized!";
                return RedirectToPage("/Account/Login");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string? imageFileName = null;
            if (UploadImg != null)
            {
                var fileName = Path.GetFileName(UploadImg.FileName);
                var savePath = Path.Combine(_environment.WebRootPath, "img", fileName);

                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    UploadImg.CopyTo(fileStream);
                }
                imageFileName = fileName;
            }
            var products = new Products
            {
                Name = Name,
                Dicription = Dicription,
                Price = Price,
                Stock = Stock,
                ImgPath = imageFileName,
                CreateDate = DateTime.Now
            };
            _context.Products.Add(products);
            _context.SaveChanges();
            return RedirectToPage("/Products/Index");
        }
    }

}
