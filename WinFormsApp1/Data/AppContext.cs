using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models; // ✅ Chỉ nếu bạn định nghĩa User và TaskItem ở đây

namespace TaskManagerApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
