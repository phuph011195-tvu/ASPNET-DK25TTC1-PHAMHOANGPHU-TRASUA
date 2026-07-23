using Microsoft.EntityFrameworkCore;
using QuanLyTraSua.Models;

namespace QuanLyTraSua.Data
{
    public class QuanLyTraSuaContext : DbContext
    {
        public QuanLyTraSuaContext(DbContextOptions<QuanLyTraSuaContext> options)
            : base(options)
        {
        }

        public DbSet<LoaiTraSua> LoaiTraSuas { get; set; }

        public DbSet<SanPham> SanPhams { get; set; }
    }
}