using Microsoft.EntityFrameworkCore;

namespace TrasuaMON.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Khai báo các bảng sẽ xuất hiện trong SQL Server
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}