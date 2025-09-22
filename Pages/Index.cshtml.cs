using ECommerceALLInOne.Data;
using ECommerceALLInOne.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceALLInOne.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public List<Products> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _db.Products.ToListAsync(); 
        }
    }
}