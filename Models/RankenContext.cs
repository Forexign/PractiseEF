using Microsoft.EntityFrameworkCore;

namespace TEST_EF.Models
{
    public class RankenContext : DbContext
    {
        public RankenContext(DbContextOptions<RankenContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "John Doe", FinancialAidStatus = "Passed" },
                new Student { Id = 2, Name = "Jane Doe", FinancialAidStatus = "Passed" },
                new Student { Id = 3, Name = "Bobby Gibson", FinancialAidStatus = "Passed" },
                new Student { Id = 4, Name = "Chuck Noris", FinancialAidStatus = "Passed" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Math" },
                new Course { Id = 2, Name = "Science" },
                new Course { Id = 3, Name = "Physics" },
                new Course { Id = 4, Name = "Biology" }
            );

            modelBuilder.Entity<Student>().HasMany(s => s.Courses).WithMany(c => c.Students).UsingEntity(sc => sc.HasData(
                new { StudentsId = 1, CoursesId = 1 },
                new { StudentsId = 2, CoursesId = 1 },
                new { StudentsId = 3, CoursesId = 1 },
                new { StudentsId = 4, CoursesId = 1 },
                new { StudentsId = 1, CoursesId = 2 },
                new { StudentsId = 2, CoursesId = 2 },
                new { StudentsId = 3, CoursesId = 2 }
                ));
        }
    }
}
