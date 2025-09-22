using ECommerceALLInOne.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceALLInOne.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Order> Orders { get; set; }



    }
}
