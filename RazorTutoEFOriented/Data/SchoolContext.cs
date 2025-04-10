using Microsoft.EntityFrameworkCore;
using RazorTutoEFOriented.Models;

namespace RazorTutoEFOriented.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssigment> OfficeAssigments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable(nameof(Course))
                .HasMany(c => c.Instructors)
                .WithMany(i => i.Courses);
            modelBuilder.Entity<Instructor>().ToTable(nameof(Instructor));
            modelBuilder.Entity<Student>().ToTable(nameof(Student));
            modelBuilder.Entity<Department>()
                .Property(d => d.ConcurrencyToken)
                .IsConcurrencyToken();
        }
    }
}
