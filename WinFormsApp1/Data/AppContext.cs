using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models; // ✅ Chỉ nếu bạn định nghĩa User và TaskItem ở đây

namespace TaskManagerApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=task_db;User Id=sa;Password=123456;TrustServerCertificate=True;");
        }
    }
}
