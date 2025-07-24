using Microsoft.EntityFrameworkCore;
using TaskStudDeptCore.Models;

namespace TaskStudDeptCore.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=DESKTOP-OEHO5RO;Initial Catalog=EFCore;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }

        ///\/\/\/\/\/\/\/\/\/\/\/\

        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{
        //}
        //public DbSet<Student> Students => Set<Student>();
        //public DbSet<Department> Departments => Set<Department>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // بيانات أولية للأقسام
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Computer Science" },
                new Department { Id = 2, Name = "Mathematics" }
            );

            // بيانات أولية للطلاب
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Noura", DepartmentId = 1 },
                new Student { Id = 2, Name = "Ahmed", DepartmentId = 2 }
            );
        }
    }
}
