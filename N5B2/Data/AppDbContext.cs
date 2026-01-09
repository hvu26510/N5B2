using AppData.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<NhanVien> nhanViens { get; set; }
    }
}
